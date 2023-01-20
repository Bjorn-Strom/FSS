namespace Fss

open System
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

    let private generateCssScope (name: string option) (rules: Rule list) =
        // TODO: This feels somewhat pointless. Can this be generated in a better way?
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
                let fullCssString = stringifyList rules
                $"css{FNV_1A.hash fullCssString}{label}"

        match name with
        | Some name when name = "*" ->
            className, (Global (Property.Class className), generatedItems)
        | _ ->
            className, (ClassName (Property.Class className), generatedItems)

    let private mediaFeaturesToCss (device: string) features =
        features
        |> List.map (fun x -> $"({x.ToString()})")
        |> fun x ->
            if device = "" then
                x
            else
                [ device ] @ x
        |> String.concat " and "

    let private chunk f listofstuff =
        match listofstuff with
        | [] -> []
        | [x] -> [ [x] ]
        | x :: y :: rest ->
            List.fold (fun acc y ->
                let lastChunk =
                    acc
                    |> List.rev
                    |> List.head
                let valueOfItemInChunk =
                    lastChunk
                    |> List.head
                    |> f

                if valueOfItemInChunk = f y then
                    let accWithoutLastChunk =
                        acc
                        |> List.rev
                        |> List.tail
                        |> List.rev
                    accWithoutLastChunk @ [ lastChunk @ [ y ] ]
                else
                    acc @ [ [ y ] ]
            ) [ [ x ] ] (y :: rest)

    let rec private createCssFromScope selectorScope (scope: CssScope): string =
        let currentSelector, cssItems = scope
        let isMedia, selector =
            match currentSelector with
            | Global currentSelector -> false, $"{selectorScope}{stringifyICssValue currentSelector}"
            | ClassName currentSelector -> false, $"{selectorScope}.{stringifyICssValue currentSelector}"
            | Id currentSelector -> false, $"{selectorScope}#{stringifyICssValue currentSelector}"
            | PseudoClass currentSelector -> false, $"{selectorScope}:{stringifyICssValue currentSelector}"
            | PseudoElement currentSelector -> false, $"{selectorScope}::{stringifyICssValue currentSelector}"
            | Combinator currentSelector -> false, $"{selectorScope}{stringifyICssValue currentSelector}"
            | SelectorMedia features -> true, $"""@media {mediaFeaturesToCss "" features}"""
            | SelectorMediaFor (device, features) -> true, $"@media {mediaFeaturesToCss (stringifyICssValue device) features}"
            | Attribute (property, attribute) -> false, $"{stringifyICssValue property}{selectorScope}{AttributeHelpers.stringifyAttribute attribute None String.Empty None}"
            | AttributeWithCase (property, attribute, matcher, match', case) -> false, $"{stringifyICssValue property}{selectorScope}{AttributeHelpers.stringifyAttribute attribute (Some matcher) match' case}"

        if isMedia then
            let mediaQuery = selector
            cssItems
            |> chunk (function | CssRule _ -> true | _ -> false)
            |> List.map (fun items ->
                match List.head items with
                | CssRule _ ->
                    List.map (fun x ->
                        match x with
                        | CssRule (name, value) -> $"{stringifyICssValue name}:{stringifyICssValue value};"
                        | _ -> failwith "Error") items
                    |> String.concat ""
                    |> fun x -> $"{selectorScope}{{{x}}}"
                | _ ->
                    List.map (fun x ->
                        match x with
                        | CssScope scope -> createCssFromScope selectorScope scope
                        | _ -> failwith "Error") items
                    |> String.concat ""
            )
            |> String.concat ""
            |> fun x -> $"{mediaQuery} {{{x}}}"
        else
            cssItems
            |> chunk (function | CssRule _ -> true | _ -> false)
            |> List.map (fun items ->
                match List.head items with
                | CssRule _ ->
                    List.map (fun x ->
                        match x with
                        | CssRule (name, value) -> $"{stringifyICssValue name}:{stringifyICssValue value};"
                        | _ -> failwith "Error") items
                    |> String.concat ""
                    |> fun x -> $"{selector}{{{x}}}"
                | _ ->
                    List.map (fun x ->
                        match x with
                        | CssScope scope -> createCssFromScope selector scope
                        | _ -> failwith "Error") items
                    |> String.concat ""
            )
            |> String.concat ""

    let private createFssInternal name (rules: Rule list): string * string =
        let classname, cssScope = generateCssScope name rules
        let css = createCssFromScope "" cssScope
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

        counterName, $"{counterName}{{{propertyString}}}"

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

        name, $"{{{properties}}}"

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
        | Some name -> name, $"{{{animationStyles}}}"
        | _ ->
            let animationName = $"animation-{FNV_1A.hash animationStyles}"
            animationName, $"{animationName}{{{animationStyles}}}"

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
    
    // Auto
    let auto = Auto

    // Time 
    let sec (v: float) : Time = Sec v
    let ms (v: float) : Time = Ms v

    // Fractions
    let fr (v: float) : Fraction = Fr v

    // Fonts
    let On = Font.On
    let Off = Font.Off
