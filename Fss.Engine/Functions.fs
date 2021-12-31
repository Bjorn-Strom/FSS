namespace Fss

open Fss.FssTypes
open Fss.Utilities

[<AutoOpen>]
module Functions =
            
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
        
    let private addBrackets string =
        $"{{ {string} }}"
        
    let private collectClasses (classes: (string * string) list) =
        let collection = System.Collections.Generic.Dictionary<string, string list>()
        classes
        |> List.iter (fun (name, css) ->
            if collection.ContainsKey(name) then
                collection[name] <- collection[name] @ [css]
            else
                collection.Add (name, [css]))
        collection
        |> Seq.toList
        |> List.map (fun x -> x.Key, String.concat "" x.Value)
        |> List.map (fun (k, v) -> k, $"{addBrackets v}" )
        
    let private createMainCss (propertyName, propertyValue) =
        $"{stringifyICssValue propertyName}: {stringifyICssValue propertyValue};"
        
    let private createPseudoCssForCombinator (propertyName: ICssValue, propertyValue: ICssValue) =
        let colons =
            match propertyValue with
            | :? Pseudo as p ->
                match p with
                | PseudoClass _ -> ":"
                | PseudoElement _ -> "::"
            | _ -> ""
            
        $"{colons}{stringifyICssValue propertyName}", $"{stringifyICssValue propertyValue};"
        
    let private createPseudoCss (propertyName: ICssValue, propertyValue: ICssValue) =
        let colons =
            match propertyValue with
            | :? Pseudo as p ->
                match p with
                | PseudoClass _ -> ":"
                | PseudoElement _ -> "::"
            | _ -> ""
            
        $"{colons}{stringifyICssValue propertyName}", $"{{ {stringifyICssValue propertyValue}; }}"
        
    let private createMediaCss (_, propertyValue) =
        let splitMedia = $"{stringifyICssValue propertyValue};".Split '|'
        $"@media {splitMedia[0]}", $"{splitMedia[1]}"
        
    // TODO: Media queries på combinators/pseudo er nok fucked
    // TODO: Combinators er fucked
    // TODO: Counter dokumentasjon side funker ikke helt som den skal
    // TODO: FUnker media queries i global styles?
    // TODO: Media queries MED pseudo funker ikke
    let private createCombinatorCss className (propertyName, propertyValue: ICssValue): (string * string) list =
        let propertyValue = (propertyValue :?> Combinator).Unwrap()
        
        let mainProperties =
            List.filter (isSecondary >> not) propertyValue
            |> List.map createMainCss
            |> List.map (fun x -> $"{stringifyICssValue propertyName}", x)
        let pseudoProperties =
            List.filter isPseudo propertyValue
            |> List.map createPseudoCssForCombinator
            |> List.map (fun (p, s) -> $"{stringifyICssValue propertyName}{p}", s)
        let mediaProperties =
            List.filter isMedia propertyValue
            |> List.map createMediaCss
            |> List.map (fun (m, s) -> m, $"{className} {s}")
        
        mainProperties @ pseudoProperties @ mediaProperties
        
    let private createCSS (name: string option) (properties: Rule list): ClassName * (ClassName * Css) list =
        let label =
            properties
            |> List.filter isLabel
            |> List.map (fun (_,y) -> y )
            |> List.rev
            |> List.tryHead
        let properties =
            properties
            |> List.filter (isLabel >> not)
        
        let mainCss =
            List.filter (isSecondary >> not) properties
            |> List.map createMainCss
            |> String.concat ""
            |> addBrackets
        let className =
            match name with
            | Some n -> n
            | _ ->
                let label =
                    match label with
                    | Some l -> $"-{stringifyICssValue l}"
                    | None -> ""
                    
                $".css-{FNV_1A.hash mainCss}{label}"
        let mainProperties =
            className, mainCss
        let pseudoProperties =
            List.filter isPseudo properties
            |> List.map createPseudoCss
            |> List.map (fun (p, s) -> $"{className}{p}", s)
        let mediaProperties =
            List.filter isMedia properties
            |> List.map createMediaCss
            |> List.map (fun (m, s) -> m, addBrackets $"{className} {s}")
        let combinatorProperties =
            List.filter isCombinator properties
            |> List.collect (createCombinatorCss className)
            |> List.map (fun (c, s) -> $"{className}{c}", s)
            |> collectClasses
            
        className[1..], [mainProperties] @ pseudoProperties @ mediaProperties @ combinatorProperties
        
    /// Creates the CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the classname you want to give to your html component
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createFss (properties: Rule list): ClassName * (ClassName * Css) list =
        createCSS None properties
        
    /// Creates global CSS based on a list of CSS rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the global classname
    /// The second element is a list of ClassName and CSS tuples you want to inject into the DOM.
    let createGlobal (properties: Rule list): ClassName * (ClassName * Css) list =
        createCSS (Some "*") properties
        
    let private stringifyCounterProperty (property: CounterRule) =
        let propertyName, propertyValue = property

        $"{stringifyICssValue propertyName}: {propertyValue.StringifyCounter()};"
           
    /// Creates the CSS for a counter style based on a list of CounterStyle rules
    /// Returns a tuple containing 2 elements
    /// The first element in the tuple is the name of the created counter style. This is the value you use in your CSS.
    /// The second element is the generated CSS for the counter.
    let createCounterStyle (properties: CounterRule list) : CounterName * CounterStyle =

        let properties =
            List.map stringifyCounterProperty properties
            |> String.concat ""
        let counterName = $"counter-{FNV_1A.hash properties}"

        counterName, addBrackets properties 
           
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
