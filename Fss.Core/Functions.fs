namespace Fss

open Fss
open Fss.Types
open Fss.Utilities

[<AutoOpen>]
module rec Functions =
    // TODO: Trenger properties for classname og ID
    type Selector =
    | ClassName2 of string
    | Id2 of string
    | PseudoClass of Property.CssProperty
    | PseudoElement of Property.CssProperty
    | Combinator of Property.CssProperty
    | Media of Media.Feature list
    | MediaFor of Property.CssProperty

    and CssScope = Selector * CssItem list
    and CssItem =
        | Rule2 of Rule
        | CssScope of CssScope

    let generateCssScope (name: string option) (rules: Rule list) =
        // TODO: Her vil vi sende typene gjennom
        let rec generator (rules_to_generate: Rule list): CssItem list =
            rules_to_generate
            |> List.map (fun x ->
                    let selector, value = x
                    match value with
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
                            CssScope (Media features, rules)
                    | _ -> Rule2 x
                )
        let label =
            rules
            |> List.tryFind isLabel
            |> function
            | Some (_, l) -> stringifyICssValue l
            | None -> ""
        let rules =
            rules
            |> List.filter (isLabel >> not)
        let generatedItems = generator rules
        let className =
            match name with
            | Some n -> n
            | _ ->
            let fullCssString =
                rules
                |> List.map (fun (x, y) -> $"{stringifyICssValue x}-{stringifyICssValue y}")
                |> String.concat ";"

            $"css{FNV_1A.hash fullCssString}{label}"
        className, (ClassName2 className, generatedItems)

    let mediaFeaturesToCss features =
        features
        |> List.map (fun x -> $"({x.ToString()})")
        |> String.concat " and "

    let createCssFromScope selectorScope (scope: CssScope): list<string * string list> =
        let currentSelector, cssItems = scope
        let selector =
            match currentSelector with
            | ClassName2 currentSelector -> $"{selectorScope}.{currentSelector}"
            | PseudoClass currentSelector -> $"{selectorScope}:{stringifyICssValue currentSelector}"
            | PseudoElement currentSelector -> $"{selectorScope}::{stringifyICssValue currentSelector}"
            | Combinator currentSelector -> $"{selectorScope}{stringifyICssValue currentSelector}"
            | Media features -> $"@media {mediaFeaturesToCss features}{{ { selectorScope}"

        cssItems
        |> List.collect (fun item ->
            match item with
            | Rule2 (name, value) -> [ selector, [$"{stringifyICssValue name}: {stringifyICssValue value};"] ]
            | CssScope scope -> createCssFromScope selector scope
        )
        // Todo: Blir dette for treigt?
        // TODO: Sjekke om dette er nødvendig?
        |> List.fold (fun acc (key, value) ->
            match acc with
            | [] -> [key, value]
            | (key2, value2) :: rest ->
                if key = key2 then
                    (key, (value2 @ value)) :: rest
                else
                    (key, value) :: acc
        ) []
        |> List.rev

    let createFssInternal name (rules: Rule list): ClassName * (ClassName * Css) list =
        let classname, cssScope = generateCssScope name rules
        let css = createCssFromScope "" cssScope
        let css = List.map (fun (x, y) -> x, $"""{{ {String.concat "" y} }}""") css
        classname, css




    // #####
    let private isLabel (_, value: ICssValue) =
        match value with
        | :? NameLabel as _ -> true
        | _ -> false
    let private isCounterLabel (_, value: ICounterValue) =
        match value with
        | :? NameLabel as _ -> true
        | _ -> false

    let private addBrackets string =
            $"{{ {string} }}"

    /// Creates CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFss2 (rules: Rule list): ClassName * (ClassName * Css) list =
        createFssInternal None rules

    /// Creates CSS with a specific classname based on a list of CSS rules
    /// WARNING: This function does not create any kind of hash for your classname so use this with care
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFssWithClassname2 name (rules: Rule list): ClassName * (ClassName * Css) list =
        createFssInternal (Some name) rules

    /// Creates global CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the global classname
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createGlobal (properties: Rule list): (ClassName * Css) list =
        let _, css = createFssInternal (Some "*") properties
        css

    let private stringifyCounterProperty (property: CounterRule) =
        let propertyName, propertyValue = property

        $"{stringifyICssValue propertyName}: {propertyValue.StringifyCounter()};"

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
            | Some l -> $"counter-{stringifyICounterValue l}"
            | None -> ""

        let counterName =
            match name with
            | Some n -> n
            | _ -> $"counter{FNV_1A.hash propertyString}{label}"

        counterName, addBrackets propertyString

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

        $"{stringifyICssValue propertyName}: {propertyValue.StringifyFontFace()};"

    /// Creates the CSS for a font face based on a list of FontFace rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created font. This is the value you use in your CSS.
    /// The second element is the generated CSS for the font face.
    let createFontFace (name: string) (properties: FontFaceRule list) : string * string =
        let properties = [ Fss.FontFace.FontFamily.string name ] @ properties
        let properties =
            List.map stringifyFontFaceProperty properties
            |> String.concat ""

        name, addBrackets properties

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

    let private createAnimationInternal (name: string option) (attributeList: Keyframes list) : string * Css =
        let framePositionToString frames =
            List.map (fun n -> $"{n}%%") frames
            |> String.concat ","

        let animationStyles =
            List.fold
                (fun acc x ->
                    match x with
                    | Frame (n, rules) ->
                        let _, rules = List.head <| snd (createFss2 rules)
                        $"{acc} {n}%% {rules}"
                    | Frames (ns, rules) ->
                        let _, rules = List.head <| snd (createFss2 rules)
                        let frameNumbers = framePositionToString ns
                        $"{acc} {frameNumbers} {rules}")
                ""
                attributeList
        match name with
        | Some name -> name, addBrackets animationStyles
        | _ -> $"animation-{FNV_1A.hash animationStyles}", addBrackets animationStyles

    /// Creates the CSS for an animation based on a list of KeyframeAttributes
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created animation. This is the value you use in your CSS.
    /// The second element is the generated CSS for the animation.
    let createAnimation (attributeList: Keyframes list) : string * Css =
        createAnimationInternal None attributeList

    /// Creates the CSS with specific name for an animation based on a list of KeyframeAttributes
    /// WARNING: This function does not create any kind of hash for your classname so use this with care
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is the generated CSS for the animation.
    let createAnimationWithName name (attributeList: Keyframes list) : string * Css =
        createAnimationInternal name attributeList

    // Important
    let important (propertyName, propertyValue) =
        (propertyName, ImportantMaster propertyValue) |> Rule

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

    let hex (value: string) = colorHelpers.hex value

    let hsl (hue: int) (saturation: int) (lightness: int) = Hsl(hue, saturation, lightness)

    let hsla (hue: int) (saturation: int) (lightness: int) (alpha: float) = Hsla(hue, saturation, lightness, alpha)

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

    // Angles
    let deg (v: float) : Angle = Deg v
    let grad (v: float) : Angle = Grad v
    let rad (v: float) : Angle = Rad v
    let turn (v: float) : Angle = Turn v

    // Percent
    let pct (v: int) : Percent = Percent v

    // Time
    let sec (v: float) : Time = Sec v
    let ms (v: float) : Time = Ms v

    // Fractions
    let fr (v: float) : Fraction = Fr v

    // Fonts
    let On = Font.On
    let Off = Font.Off
