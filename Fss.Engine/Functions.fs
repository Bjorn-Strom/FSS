namespace Fss

open Fss.FssTypes
open Fss.Utilities

[<AutoOpen>]
module rec Functions =
    let private isSecondary (_: Property.Property, value: ICssValue) =
        match value with
            | :? Pseudo as _ -> true
            | :? Combinator as _ -> true
            | :? Media.MediaQuery as _ -> true
            | _ -> false
    let private isCombinator (_, value: ICssValue) =
        match value with
        | :? Combinator as _ -> true
        | _ -> false
    let private isMedia (_, value: ICssValue) =
        match value with
        | :? Media.MediaQuery as _ -> true
        | _ -> false
    let private isPseudo (_, value: ICssValue) =
        match value with
        | :? Pseudo as _ -> true
        | _ -> false
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
        
    // Creates a single line of "normal" CSS
    let private createMainCssString (propertyName, propertyValue): string * string =
        stringifyICssValue propertyName, $"{stringifyICssValue propertyValue}"
    
    // Creates "normal" css, IE not pseudo elements/classes or combinators
    let private createMainCSS (properties: Rule list): Css =
        let cssStrings =
            properties
            |> List.filter (isLabel >> not)
            |> List.map createMainCssString
        
        let cssString =         
            cssStrings
            |> List.map (fun (n, v) -> $"{n}: {v}")
            |> String.concat ";"
            |> sprintf "%s;"
            |> addBrackets
        
        $"{cssString}"
        
    // Creates a single line of pseudo CSS
    let private createPseudoCssString (propertyName: ICssValue, propertyValue: ICssValue): string * string =
        let colons =
            match propertyValue with
            | :? Pseudo as p ->
                match p with
                | PseudoClass _ -> ":"
                | PseudoElement _ -> "::"
            | _ -> ""
            
        $"{colons}{stringifyICssValue propertyName}", $"{{ {stringifyICssValue propertyValue}; }}"
        
    // Creates all pseudo css, 
    let private createPseudoCss (properties: Rule list): (ClassName * Css) list =
        properties
        |> List.map createPseudoCssString
        |> List.map (fun (name, value) -> $"{name}", $"{value}")
        
    // Creates media CSS. As media queries can contain any type of CSS it calls the createFSS function.
    let private createMediaCssString className (_, propertyValue: ICssValue): string * string =
        let stringifyMedia features rules =
            let features = List.map (fun x -> $"({x.ToString()})") features |> String.concat " and "
            let css =
                let _, css = createFssInternal (Some className) rules
                css
                |> List.map (fun (x,y) ->
                    $"{x} {y}")
                |> String.concat ""
                |> addBrackets
            features, css
        match propertyValue with
        | :? Media.MediaQuery as m ->
            match m with
            | Media.MediaQuery(features, rules ) ->
                let features, css = stringifyMedia features rules
                $"@media {features}", css
            | Media.MediaQueryFor(device, features, rules ) ->
                let device = stringifyICssValue device
                let featureString, css = stringifyMedia features rules
                let featureString =
                    if List.isEmpty features |> not then
                        $"and {featureString}"
                    else
                        ""
                $"@media {device} {featureString}", css
        | _ -> "", ""
        
    // Creates all media css
    let createMediaCss className (properties: Rule list): (ClassName * Css) list =
        properties
        |> List.map (fun m -> createMediaCssString className m)
        
    // Creates combinator CSS. As media queries can contain any type of CSS it calls the createFSS function.
    let private createCombinatorCssString (propertyName: ICssValue, propertyValue: ICssValue) =
        match propertyValue with
        | :? Combinator as c ->
            let _, css =
                c.Unwrap()
                |> createFssInternal (Some "")
            css
            |> List.map (fun (x, y) ->
                // This is an edge case, as media queries dont fit the normal pattern
                // In that case we force it to be correct
                // FIXME: Make this less fragile
                if x.Contains("@media") then
                    stringifyICssValue propertyName, y.Replace("{  {", $"{{ {x} {{")
                else
                    $"{stringifyICssValue propertyName}{x}", y)
        | _ -> [ "", "" ]
        
    // Creates all combinator css
    let private createCombinatorCss (properties: Rule list): (ClassName * Css) list =
        properties
        |> List.collect (fun m -> createCombinatorCssString m)

    // Creates all CSS
    // Creates all different types of CSS, creates and adds the classname
    // Combines them all
    let private createFssInternal (name: string option) (properties: Rule list): ClassName * (ClassName * Css) list =
        // As labels are not real css we filter them out here and use them to change the classname
        let label =
            properties
            |> List.filter isLabel
            |> List.map (fun (_,y) -> y )
            |> List.rev
            |> List.tryHead
            
        // Create the classname and append a label if needed
        let label =
            match label with
            | Some l -> $"-{stringifyICssValue l}"
            | None -> ""
            
        let className =
            match name with
            | Some n -> n
            | _ -> $".css{FNV_1A.hash (properties.ToString())}{label}"
            
        let properties =
            properties
            |> List.filter (isLabel >> not)
            
        let mainStyles =
            properties
            |> List.filter (isSecondary >> not)
            |> createMainCSS
        
        let pseudoStyles =
            properties
            |> List.filter isPseudo
            |> createPseudoCss
            |> List.map (fun (n,v) -> $"{className}{n}", v)
            
        let mediaStyles =
            properties
            |> List.filter isMedia
            |> createMediaCss className
            
        let combinatorStyles =
            properties
            |> List.filter isCombinator
            |> createCombinatorCss 
            |> List.map (fun (n,v) -> $"{className}{n}", v)
        
        let newCss =
            [className, mainStyles] @ pseudoStyles @ mediaStyles @ combinatorStyles
            |> List.filter (fun (_, v) -> v <> "{ ; }")
            
        className[1..], newCss

    /// Creates CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFss (properties: Rule list): ClassName * (ClassName * Css) list =
        createFssInternal None properties
        
    /// Creates CSS with a specific classname based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname, this is what you give to your classnames.
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFssWithClassname className (properties: Rule list): ClassName * (ClassName * Css) list =
        createFssInternal (Some className) properties
    
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
           
    /// Creates the CSS for a counter style based on a list of CounterStyle rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created counter style. This is the value you use in your CSS.
    /// The second element is the generated CSS for the counter.
    let createCounterStyle (properties: CounterRule list) : CounterName * CounterStyle =
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
        let counterName =
            match label with
            | Some l -> $"counter-{stringifyICounterValue l}"
            | None -> $"counter{FNV_1A.hash propertyString}"

        counterName, addBrackets propertyString 
           
    let private stringifyFontFaceProperty (property: FontFaceRule) =
        let propertyName, propertyValue = property

        $"{stringifyICssValue propertyName}: {propertyValue.StringifyFontFace()};"
        
    /// Creates the CSS for a font face based on a list of FontFace rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created font. This is the value you use in your CSS.
    /// The second element is the generated CSS for the font face.
    let createFontFace (name: string) (properties: FontFaceRule list) : FontName * FontFaceStyle =
        let properties = [ FontFace.FontFamily.string name ] @ properties
        let properties =
            List.map stringifyFontFaceProperty properties
            |> String.concat ""
        
        name, addBrackets properties
        
    /// Creates the CSS for several font faces based on FontFace rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created font. This is the value you use in your CSS.
    /// The second element is the generated CSS for the font face.
    let createFontFaces (name: string) (properties: FontFaceRule list list) : FontName * FontFaceStyle =
        let fontFace = List.map (fun ruleList -> createFontFace name ruleList) properties
        let fontName = fst <| List.head fontFace
        let fontFaceString =
                fontFace
                |> List.map (fun (_, x) -> x)
                |> String.concat "\n"
                
        fontName, fontFaceString
        
    /// Creates the CSS for an animation based on a list of KeyframeAttributes
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created animation. This is the value you use in your CSS.
    /// The second element is the generated CSS for the animation.
    let createAnimation (attributeList: KeyframeAttribute list) : AnimationName * Css =
        let framePositionToString frames =
            List.map (fun n -> $"{n}%%") frames
            |> String.concat ","

        let animationStyles = 
            List.fold
                (fun acc x ->
                    match x with
                    | Frame (n, rules) ->
                        let _, rules = List.head <| snd (createFss rules)
                        $"{acc} {n}%% {rules}"
                    | Frames (ns, rules) ->
                        let _, rules = List.head <| snd (createFss rules)
                        let frameNumbers = framePositionToString ns
                        $"{acc} {frameNumbers} {rules}")
                ""
                attributeList

        $"animation-{FNV_1A.hash animationStyles}", addBrackets animationStyles

    // Important
    let important (propertyName, propertyValue) =
        (propertyName, Important propertyValue) |> Rule

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
