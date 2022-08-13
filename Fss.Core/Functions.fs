namespace Fss

open System.Text
open Fss
open Fss.Types
open Fss.Utilities

[<AutoOpen>]
module Functions =
    type Selector =
    | Global of Property.CssProperty
    | ClassName of Property.CssProperty
    | Id of Property.CssProperty
    | PseudoClass of Property.CssProperty
    | PseudoElement of Property.CssProperty
    | Combinator of Property.CssProperty
    | Media2 of Media.Feature list
    | MediaFor2 of Media.Device * Media.Feature list

    and CssScope = Selector * CssItem list
    and CssItem =
        | Rule2 of Rule
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
        // TODO: Her vil vi sende typene gjennom
        // Denne føles litt teit ut
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
                            CssScope (Media2 features, rules)
                        | Media.MediaQueryFor (device, features, rules) ->
                            let rules = generator rules
                            CssScope (MediaFor2 (device, features), rules)
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
            let stringify rule =
                let x, y = rule
                $"{stringifyICssValue x}-{stringifyICssValue y}"
            match name with
            | Some n -> n
            | _ ->
                let fullCssString =
                    rules
                    |> List.map (fun (x, y) ->
                        match y with
                        | :? Media.MediaQueryMaster as m ->
                            match m with
                            | Media.MediaQuery (_, rules) -> List.map stringify rules |> String.concat ";"
                            | Media.MediaQueryFor (_, _, rules) -> List.map stringify rules |> String.concat ";"
                        | _ -> stringify (x,y))
                    |> String.concat ";"
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
            | Media2 features -> true, $"""@media {mediaFeaturesToCss "" features}"""
            | MediaFor2 (device, features) -> true, $"@media {mediaFeaturesToCss (stringifyICssValue device) features}"

        let chunky f listofstuff =
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

        if isMedia then
            let mediaQuery = selector
            cssItems
            |> chunky (function | Rule2 _ -> true | _ -> false)
            |> List.map (fun items ->
                match List.head items with
                | Rule2 _ ->
                    List.map (fun x ->
                        match x with
                        | Rule2 (name, value) -> $"{stringifyICssValue name}:{stringifyICssValue value};"
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
            |> chunky (function | Rule2 _ -> true | _ -> false)
            |> List.map (fun items ->
                match List.head items with
                | Rule2 _ ->
                    List.map (fun x ->
                        match x with
                        | Rule2 (name, value) -> $"{stringifyICssValue name}:{stringifyICssValue value};"
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

    let private createFssInternal name (rules: Rule list): ClassName * string =
        let classname, cssScope = generateCssScope name rules
        let css = createCssFromScope "" cssScope
        classname, css

    // #####

    let private addBrackets string =
        $"{{{string}}}"

    /// Creates CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFss (rules: Rule list): ClassName * string =
        createFssInternal None rules

    /// Creates CSS with a specific classname based on a list of CSS rules
    /// WARNING: This function does not create any kind of hash for your classname so use this with care
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFssWithClassname name (rules: Rule list): ClassName * string =
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

        $"{stringifyICssValue propertyName}:{propertyValue.StringifyCounter()};"

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
                        let _, rules = createFssWithClassname "" rules
                        $"{acc}{n}%%{rules[1..]}"
                    | Frames (ns, rules) ->
                        let _, rules = createFssWithClassname "" rules
                        let frameNumbers = framePositionToString ns
                        $"{acc}{frameNumbers}{rules[1..]}")
                ""
                attributeList
        match name with
        | Some name -> name, addBrackets animationStyles
        | _ ->
            let animationName = $"animation-{FNV_1A.hash animationStyles}"
            animationName, $"{animationName}{addBrackets animationStyles}"

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
