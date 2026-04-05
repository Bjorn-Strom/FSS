namespace Fss

open System
open System.Text
open Fss
open Fss.Types
open Fss.Utilities

[<AutoOpen>]
module Functions =
    type LengthUnit = ILengthUnit

    type private Selector =
        | Global of Property.CssProperty
        | ClassName of Property.CssProperty
        | Id of Property.CssProperty
        | PseudoClass of Property.CssProperty
        | PseudoElement of Property.CssProperty
        | Combinator of Property.CssProperty
        | SelectorMedia of Media.Feature list
        | SelectorMediaFor of Media.Device * Media.Feature list
        | SelectorContainer of Container.Feature list
        | SelectorContainerNamed of string * Container.Feature list
        | SelectorLayer of string
        | SelectorLayerAnonymous
        | SelectorScope of string
        | SelectorScopeTo of string * string
        | SelectorScopeImplicit
        | SelectorStartingStyle
        | Attribute of Property.CssProperty * Attribute.Attribute
        | AttributeWithCase of Property.CssProperty * Attribute.Attribute * AttributeHelpers.Match * string * Attribute.Case option

    and private CssScope = Selector * CssItem list
    and private CssItem =
        | CssRule of Rule
        | CssScope of CssScope

    let private isLabel (_, value: ICssValue) =
        match value with
        | :? NameLabel as _ -> true
        | _ -> false
    let private isCounterLabel (_, value: ICounterValue) =
        match value with
        | :? NameLabel as _ -> true
        | _ -> false

    /// Hash rules incrementally without allocating a concatenated string
    let private hashRules (rules: Rule list) =
        let mutable h = 0
        for (prop, value) in rules do
            h <- FNV_1A.hashInto h (stringifyICssValue prop)
            h <- FNV_1A.hashInto h "-"
            h <- FNV_1A.hashInto h (stringifyICssValue value)
            h <- FNV_1A.hashInto h ";"
        h

    /// Single-pass: extract label and non-label rules without double traversal
    let private extractLabel (rules: Rule list) =
        let mutable label = ""
        let filtered =
            rules |> List.filter (fun (_, value) ->
                match value with
                | :? NameLabel as l ->
                    label <- stringifyICssValue l
                    false
                | _ -> true)
        label, filtered

    let private generateCssScope (name: string option) (rules: Rule list) =
        let rec generator (rules_to_generate: Rule list): CssItem list =
            rules_to_generate
            |> List.map (fun x ->
                    let selector, value = x
                    match value with
                    | :? ClassnameMaster as c ->
                        match c with
                        | ClassnameMaster c ->
                            let rules = generator c
                            CssScope (ClassName selector, rules)
                    | :? IdMaster as i ->
                        match i with
                        | IdMaster i ->
                            let rules = generator i
                            CssScope (Id selector, rules)
                    | :? PseudoMaster as p ->
                        match p with
                        | PseudoClassMaster p ->
                            let rules = generator p
                            CssScope (PseudoClass selector, rules)
                        | PseudoElementMaster p ->
                            let rules = generator p
                            CssScope (PseudoElement selector, rules)
                    | :? CombinatorMaster as c ->
                        match c with
                        | CombinatorMaster c ->
                            let rules = generator c
                            CssScope (Combinator selector, rules )
                    | :? Media.MediaQueryMaster as m ->
                        match m with
                        | Media.MediaQuery (features, rules) ->
                            let rules = generator rules
                            CssScope (SelectorMedia features, rules)
                        | Media.MediaQueryFor (device, features, rules) ->
                            let rules = generator rules
                            CssScope (SelectorMediaFor (device, features), rules)
                    | :? Container.ContainerQueryMaster as c ->
                        match c with
                        | Container.ContainerQuery (features, rules) ->
                            let rules = generator rules
                            CssScope (SelectorContainer features, rules)
                        | Container.ContainerQueryNamed (name, features, rules) ->
                            let rules = generator rules
                            CssScope (SelectorContainerNamed (name, features), rules)
                    | :? Layer.LayerMaster as l ->
                        match l with
                        | Layer.LayerNamed (name, rules) ->
                            let rules = generator rules
                            CssScope (SelectorLayer name, rules)
                        | Layer.LayerAnonymous rules ->
                            let rules = generator rules
                            CssScope (SelectorLayerAnonymous, rules)
                    | :? ScopeAtRule.ScopeMaster as s ->
                        match s with
                        | ScopeAtRule.ScopeRoot (root, rules) ->
                            let rules = generator rules
                            CssScope (SelectorScope root, rules)
                        | ScopeAtRule.ScopeRootTo (root, limit, rules) ->
                            let rules = generator rules
                            CssScope (SelectorScopeTo (root, limit), rules)
                        | ScopeAtRule.ScopeImplicit rules ->
                            let rules = generator rules
                            CssScope (SelectorScopeImplicit, rules)
                    | :? StartingStyleAtRule.StartingStyleMaster as s ->
                        match s with
                        | StartingStyleAtRule.StartingStyle rules ->
                            let rules = generator rules
                            CssScope (SelectorStartingStyle, rules)
                    | :? Attribute.AttributeMaster as a ->
                        match a with
                        | Attribute.Normal (attribute, rules) ->
                            let rules = generator rules
                            CssScope ((Attribute (selector, attribute), rules))
                        | Attribute.Exactly (attribute, match', case, rules) ->
                            let rules = generator rules
                            CssScope ((AttributeWithCase (selector, attribute, AttributeHelpers.Exactly, match', case), rules))
                        | Attribute.Contains (attribute, match', case, rules) ->
                            let rules = generator rules
                            CssScope ((AttributeWithCase (selector, attribute, AttributeHelpers.Contains, match', case), rules))
                        | Attribute.ValueOrContinuation (attribute, match', case, rules) ->
                            let rules = generator rules
                            CssScope ((AttributeWithCase (selector, attribute, AttributeHelpers.ValueOrContinuation, match', case), rules))
                        | Attribute.Prefix (attribute, match', case, rules) ->
                            let rules = generator rules
                            CssScope ((AttributeWithCase (selector, attribute, AttributeHelpers.Prefix, match', case), rules))
                        | Attribute.Suffix (attribute, match', case, rules) ->
                            let rules = generator rules
                            CssScope ((AttributeWithCase (selector, attribute, AttributeHelpers.Suffix, match', case), rules))
                        | Attribute.AtLeastOne (attribute, match', case, rules) ->
                            let rules = generator rules
                            CssScope ((AttributeWithCase (selector, attribute, AttributeHelpers.AtLeastOne, match', case), rules))

                    | _ -> CssRule x
                )
        let label, rules = extractLabel rules
        let generatedItems = generator rules
        let className =
            match name with
            | Some n -> n
            | _ ->
                let hash = hashRules rules
                $"css{hash}{label}"

        match name with
        | Some name when name = "*" ->
            className, (Global (Property.Class className), generatedItems)
        | _ ->
            className, (ClassName (Property.Class className), generatedItems)

    let private appendMediaFeatures (sb: StringBuilder) (device: string) features =
        if device <> "" then
            sb.Append(device) |> ignore
            if not (List.isEmpty features) then
                sb.Append(" and ") |> ignore
        features |> List.iteri (fun i x ->
            if i > 0 then sb.Append(" and ") |> ignore
            sb.Append('(').Append(x.ToString()).Append(')') |> ignore)

    let private appendContainerFeatures (sb: StringBuilder) features =
        features |> List.iteri (fun i x ->
            if i > 0 then sb.Append(" and ") |> ignore
            sb.Append('(').Append(x.ToString()).Append(')') |> ignore)

    let rec private renderItemsSb (sb: StringBuilder) (items: CssItem list): unit =
        for item in items do
            match item with
            | CssRule (name, value) ->
                sb.Append(stringifyICssValue name).Append(':').Append(stringifyICssValue value).Append(';') |> ignore
            | CssScope scope -> renderScopeSb sb scope

    and private renderScopeSb (sb: StringBuilder) (scope: CssScope): unit =
        let currentSelector, cssItems = scope
        match currentSelector with
        | SelectorMedia features ->
            sb.Append("@media ") |> ignore
            appendMediaFeatures sb "" features
            sb.Append(" {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorMediaFor (device, features) ->
            sb.Append("@media ") |> ignore
            appendMediaFeatures sb (stringifyICssValue device) features
            sb.Append(" {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorContainer features ->
            sb.Append("@container ") |> ignore
            appendContainerFeatures sb features
            sb.Append(" {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorContainerNamed (name, features) ->
            sb.Append("@container ").Append(name).Append(' ') |> ignore
            appendContainerFeatures sb features
            sb.Append(" {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorLayer name ->
            sb.Append("@layer ").Append(name).Append(" {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorLayerAnonymous ->
            sb.Append("@layer {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorScope root ->
            sb.Append("@scope (").Append(root).Append(") {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorScopeTo (root, limit) ->
            sb.Append("@scope (").Append(root).Append(") to (").Append(limit).Append(") {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorScopeImplicit ->
            sb.Append("@scope {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | SelectorStartingStyle ->
            sb.Append("@starting-style {&{") |> ignore
            renderItemsSb sb cssItems
            sb.Append("}}") |> ignore
        | _ ->
            sb.Append('&') |> ignore
            match currentSelector with
            | Global currentSelector -> sb.Append(stringifyICssValue currentSelector) |> ignore
            | ClassName currentSelector -> sb.Append('.').Append(stringifyICssValue currentSelector) |> ignore
            | Id currentSelector -> sb.Append('#').Append(stringifyICssValue currentSelector) |> ignore
            | PseudoClass currentSelector -> sb.Append(':').Append(stringifyICssValue currentSelector) |> ignore
            | PseudoElement currentSelector -> sb.Append("::").Append(stringifyICssValue currentSelector) |> ignore
            | Combinator currentSelector -> sb.Append(stringifyICssValue currentSelector) |> ignore
            | Attribute (property, attribute) ->
                sb.Append(stringifyICssValue property).Append(AttributeHelpers.stringifyAttribute attribute None "" None) |> ignore
            | AttributeWithCase (property, attribute, matcher, match', case) ->
                sb.Append(stringifyICssValue property).Append(AttributeHelpers.stringifyAttribute attribute (Some matcher) match' case) |> ignore
            | _ -> ()
            sb.Append('{') |> ignore
            renderItemsSb sb cssItems
            sb.Append('}') |> ignore

    let private createCssFromScope (scope: CssScope): string =
        let currentSelector, cssItems = scope
        let sb = StringBuilder()
        match currentSelector with
        | Global currentSelector -> sb.Append(stringifyICssValue currentSelector) |> ignore
        | ClassName currentSelector -> sb.Append('.').Append(stringifyICssValue currentSelector) |> ignore
        | _ -> ()
        sb.Append('{') |> ignore
        renderItemsSb sb cssItems
        sb.Append('}') |> ignore
        sb.ToString()

    let private createFssInternal name (rules: Rule list): string * string =
        let classname, cssScope = generateCssScope name rules
        let css = createCssFromScope cssScope
        classname, css

    /// Creates CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFss (rules: Rule list): string * string =
        createFssInternal None rules

    /// Creates CSS with a specific classname based on a list of CSS rules
    /// WARNING: This function does not create any kind of hash for your classname so use this with care
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFssWithClassname name (rules: Rule list): string * string =
        createFssInternal (Some name) rules

    /// Creates global CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the global classname
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createGlobal (properties: Rule list): string =
        let _, css = createFssInternal (Some "*") properties
        css

    /// Creates a CSS layer order declaration from CascadeLayer values
    /// Returns the CSS string: @layer name1, name2, name3;
    let createLayerOrder (layers: CascadeLayer list): string =
        let names = layers |> List.map (fun (CascadeLayer name) -> name) |> String.concat ", "
        sprintf "@layer %s;" names

    /// Creates an @property rule for registering a custom CSS property
    /// Returns the CSS string: @property --name { syntax: "..."; inherits: ...; initial-value: ...; }
    let createProperty (name: string) (syntax: CustomProperty.Syntax) (inherits: bool) (initialValue: string): string =
        let inheritsStr = if inherits then "true" else "false"
        sprintf "@property %s{syntax:\"%s\";inherits:%s;initial-value:%s;}" name (syntax.Stringify()) inheritsStr initialValue

    let private stringifyCounterProperty (property: CounterRule) =
        let propertyName, propertyValue = property

        (stringifyICssValue propertyName) + ":" + propertyValue.StringifyCounter() + ";"

    /// Creates all counter styles and combines them
    let private createCounterStyleInternal (name: string option) (properties: CounterRule list) : string * string =
        // As labels are not real css we filter them out here and use them to change the classname
        let label =
            properties
            |> List.filter isCounterLabel
            |> List.map (fun (_,y) -> y )
            |> List.rev
            |> List.tryHead

        let propertyString =
            properties
            |> List.filter (isCounterLabel >> not)
            |> List.map stringifyCounterProperty
            |> String.concat ""
        // Sometimes we actually want to create empty counters
        // In that case they need a unique name
        let label =
            match label with
            | Some l -> $"{stringifyICounterValue l}"
            | None -> ""

        let counterName =
            match name with
            | Some n -> n
            | _ -> $"counter{FNV_1A.hash propertyString}{label}"

        counterName, sprintf "%s{%s}" counterName propertyString

    /// Creates the CSS for a counter style based on a list of CounterStyle rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created counter style. This is the value you use in your CSS.
    /// The second element is the generated CSS for the counter.
    let createCounterStyle (properties: CounterRule list): string * string =
        createCounterStyleInternal None properties

    /// Creates Css for a counter with a specific name based on a list of CounterStyle rules
    /// WARNING: This function does not create any kind of hash for your classname so use this with care
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is the generated CSS for the counter.
    let createCounterStyleWithName className (properties: CounterRule list): string * string =
        createCounterStyleInternal (Some className) properties

    let private stringifyFontFaceProperty (property: FontFaceRule) =
        let propertyName, propertyValue = property

        $"{stringifyICssValue propertyName}:{propertyValue.StringifyFontFace()};"

    /// Creates the CSS for a font face based on a list of FontFace rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created font. This is the value you use in your CSS.
    /// The second element is the generated CSS for the font face.
    let createFontFace (name: string) (properties: FontFaceRule list) : string * string =
        let properties = [ Fss.FontFace.FontFamily.string name ] @ properties
        let properties =
            List.map stringifyFontFaceProperty properties
            |> String.concat ""

        name, sprintf "{%s}" properties

    /// Creates the CSS for several font faces based on FontFace rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created font. This is the value you use in your CSS.
    /// The second element is the generated CSS for the font face.
    let createFontFaces (name: string) (properties: FontFaceRule list list) : string * string =
        let fontFace = List.map (fun ruleList -> createFontFace name ruleList) properties
        let fontName = fst <| List.head fontFace
        let fontFaceString =
                fontFace
                |> List.map (fun (_, x) -> x)
                |> String.concat "\n"

        fontName, fontFaceString

    let private createAnimationInternal (name: string option) (attributeList: Keyframes list) : string * string =
        let framePositionToString frames =
            List.map (fun n -> $"{n}%%") frames
            |> String.concat ","

        let animationStyles =
            List.fold
                (fun acc x ->
                    match x with
                    | Frame (n, rules) ->
                        let _, rules = createFssWithClassname "" rules
                        $"{acc}{n}%%{rules[1..]}"
                    | Frames (ns, rules) ->
                        let _, rules = createFssWithClassname "" rules
                        let frameNumbers = framePositionToString ns
                        $"{acc}{frameNumbers}{rules[1..]}")
                ""
                attributeList
        match name with
        | Some name -> name, sprintf "{%s}" animationStyles
        | _ ->
            let animationName = sprintf "animation-%d" (FNV_1A.hash animationStyles)
            animationName, sprintf "%s{%s}" animationName animationStyles

    /// Creates the CSS for an animation based on a list of KeyframeAttributes
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created animation. This is the value you use in your CSS.
    /// The second element is the generated CSS for the animation.
    let createAnimation (attributeList: Keyframes list) : string * string =
        createAnimationInternal None attributeList

    /// Creates the CSS with specific name for an animation based on a list of KeyframeAttributes
    /// WARNING: This function does not create any kind of hash for your classname so use this with care
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is the generated CSS for the animation.
    let createAnimationWithName name (attributeList: Keyframes list) : string * string =
        createAnimationInternal name attributeList

    // Important
    let important (propertyName, propertyValue) =
        (propertyName, ImportantMaster propertyValue) |> Rule

    let Classname (classname: string) (rules: Rule list) =
        (Property.Class classname, ClassnameMaster rules) |> Rule

    let Id (id: string) (rules: Rule list) =
        (Property.Id id, IdMaster rules) |> Rule

    // Classnames
    let combine styles stylesPred =
        (styles
        |> List.map (fun s -> s, true)
        |> List.append) stylesPred
        |> List.filter snd
        |> List.map fst
        |> String.concat " "

    // Color
    let rgb (red: int) (green: int) (blue: int) = Rgb(red, green, blue)

    let rgba (red: int) (green: int) (blue: int) (alpha: float) = Rgba(red, green, blue, alpha)

    let hex (value: string) = Hex value

    let hsl (hue: int) (saturation: int) (lightness: int) = Hsl(hue, saturation, lightness)

    let hsla (hue: int) (saturation: int) (lightness: int) (alpha: float) = Hsla(hue, saturation, lightness, alpha)

    let hwb (hue: float) (whiteness: float) (blackness: float) = Hwb(hue, whiteness, blackness)

    let hwba (hue: float) (whiteness: float) (blackness: float) (alpha: float) = HwbAlpha(hue, whiteness, blackness, alpha)

    let lab (lightness: float) (a: float) (b: float) = Lab(lightness, a, b)

    let lch (lightness: float) (chroma: float) (hue: float) = Lch(lightness, chroma, hue)

    let oklab (lightness: float) (a: float) (b: float) = Oklab(lightness, a, b)

    let oklch (lightness: float) (chroma: float) (hue: float) = Oklch(lightness, chroma, hue)

    let colorMix (colorSpace: string) (color1: Color) (pct1: int) (color2: Color) (pct2: int) = ColorMix(colorSpace, color1, pct1, color2, pct2)

    let lightDark (light: Color) (dark: Color) = LightDark(light, dark)

    // Sizes
    // Absolute
    let px (v: int) : Length = Px v
    let inc (v: float) : Length = In v
    let cm (v: float) : Length = Cm v
    let mm (v: float) : Length = Mm v
    let pt (v: float) : Length = Pt v
    let pc (v: float) : Length = Pc v

    // Relative
    let em (v: float) : Length = Em' v
    let rem (v: float) : Length = Rem v
    let ex (v: float) : Length = Ex v
    let ch (v: float) : Length = Ch v
    let vw (v: float) : Length = Vw v
    let vh (v: float) : Length = Vh v
    let vmax (v: float) : Length = VMax v
    let vmin (v: float) : Length = VMin v
    let dvw (v: float) : Length = Dvw v
    let dvh (v: float) : Length = Dvh v
    let svw (v: float) : Length = Svw v
    let svh (v: float) : Length = Svh v
    let lvw (v: float) : Length = Lvw v
    let lvh (v: float) : Length = Lvh v
    let cqw (v: float) : Length = Cqw v
    let cqh (v: float) : Length = Cqh v
    let cqi (v: float) : Length = Cqi v
    let cqb (v: float) : Length = Cqb v

    // Angles
    let deg (v: float) : Angle = Deg v
    let grad (v: float) : Angle = Grad v
    let rad (v: float) : Angle = Rad v
    let turn (v: float) : Angle = Turn v

    // Percent
    let pct (v: int) : Percent = Percent v

    // Auto
    let auto = Auto

    // Zero
    let zero = Zero

    // Time
    let sec (v: float) : Time = Sec v
    let ms (v: float) : Time = Ms v

    // Fractions
    let fr (v: float) : Fraction = Fr v

    // Fonts
    let On = Fss.Types.Font.On
    let Off = Fss.Types.Font.Off
