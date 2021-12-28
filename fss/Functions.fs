namespace Fss

open Fss.FssTypes
open Fss.Utilities

//open Media
//open Keyframes

[<AutoOpen>]
module Functions =
    (*
    let css' x = x

    let injectGlobal' x = x

    // Constructors
    let private fssObject (attributeList: CssProperty list) =
        attributeList
        |> List.map masterTypeHelpers.CssValue
        |> css'

    let fss (attributeList: CssProperty list) =
        attributeList
        |> fssObject
        |> string

    let global' (attributeList: CssProperty list) =
        attributeList
        |> List.map masterTypeHelpers.CssValue
        //|> createObj
        |> injectGlobal'


    /// <summary>Write Css as key value string pairs.
    /// Allows you to add values not supported by Fss.</summary>
    /// <param name="key">Css property</param>
    /// <param name="value">Css value </param>
    /// <returns>Css property for fss.</returns>
    let Custom (key: string) (value: string) =
        //key ==> value |> CssProperty
        key :> obj


    let counterStyle (attributeList: CounterProperty list) =
        let counterName = sprintf "counter_%s" <| Guid.NewGuid().ToString()

        // createCounterObject attributeList counterName |> css' |> ignore

        counterName |> Counter.Style

    // Media
    let MediaQueryFor (device: Media.Device) (features: Media.Feature list) (attributeList: CssProperty list) =
        Media.Media(device, features, fss attributeList)
    let MediaQuery (features: Media.Feature list) (attributeList: CssProperty list) =
        Media.Media(features, fss attributeList)

    // Font
    let fontFace (fontFamily: string) (attributeList: CssProperty list) =
        attributeList
        |> createFontFaceObject fontFamily
        |> css'
        Font.Family.Name (Font.Name fontFamily)

    let fontFaces (fontFamily: string) (attributeLists: CssProperty list list) =
        attributeLists
        |> List.map (createFontFaceObject fontFamily)
       // |> List.iter css'

        Font.Family.Name (Font.Name fontFamily)

    // Important
    let important property =
        let key, value = masterTypeHelpers.CssValue property
        //key ==> $"{value} !important" |> CssProperty
        key :> obj

    // Classnames
    let combine styles stylesPred =
        (styles
        |> List.map (fun s -> s, true)
        |> List.append) stylesPred
        |> List.filter snd
        |> List.map fst
        |> String.concat " "
[ *)
            
    // TODO RYDD OPP LITT HER
    // Vi trenger 4 funksjoner
    // - Fss som lager CSS - X
    // - Counter som lager counter style - X
    // - Font Face som lager font face - X
    // - Keyframes som lager animasjoner
    
    type internal Properties =
        { Main: Rule list
          Secondary: Rule list }
    let private isSecondary (_: Property.Property, value: ICssValue) =
        match value with
            | :? Pseudo as _ -> true
            | :? Combinator as _ -> true
            | :? Media.MediaQuery as _ -> true
            | _ -> false
    let isCombinator (_, value: ICssValue) =
        match value with
        | :? Combinator as _ -> true
        | _ -> false
    let isMedia (_, value: ICssValue) =
        match value with
        | :? Media.MediaQuery as _ -> true
        | _ -> false
    let isPseudo (_, value: ICssValue) =
        match value with
        | :? Pseudo as _ -> true
        | _ -> false
    let isLabel (_, value: ICssValue) =
        match value with
        | :? NameLabel as _ -> true
        | _ -> false
        
    let private createMainCss (propertyName, propertyValue) =
        $"{stringifyICssValue propertyName}: {stringifyICssValue propertyValue};"
        
    let private createPseudoCss (propertyName: ICssValue, propertyValue: ICssValue) =
        let colons =
            match propertyValue with
            | :? Pseudo as p ->
                match p with
                | PseudoClass _ -> ":"
                | PseudoElement _ -> "::"
            | _ -> ""
            
        $"{colons}{propertyName.Stringify()}", $"{propertyValue.Stringify()};"
        
    let private createMediaCss (_, propertyValue) =
        let splitMedia = ($"{stringifyICssValue propertyValue};").Split '|'
        $"@media {splitMedia[0]}", $"{splitMedia[1]}"
        
    // TODO: ÆSJ
    let private unwrapCombinator (Combinator rules) = rules
        
    // TODO: FIX
    let private createCombinatorCss (propertyName, propertyValue: ICssValue): (string * string) list =
        let propertyValue = unwrapCombinator (propertyValue :?> Combinator)
        
        let mainProperties =
            List.filter (isSecondary >> not) propertyValue
            |> List.map createMainCss
            |> List.map (fun x -> $"{stringifyICssValue propertyName}", x)
        let pseudoProperties =
            List.filter isPseudo propertyValue
            |> List.map createPseudoCss
            |> List.map (fun (p, s) -> $"{stringifyICssValue propertyName}{p}", s)
        let mediaProperties =
            List.filter isMedia propertyValue
            |> List.map createMediaCss
            |> List.map (fun (m, s) -> m, $"{s}")
        
        mainProperties @ pseudoProperties @ mediaProperties    
        
    let fss (properties: Rule list): (ClassName * Css) list =
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
        let className =
            let label =
                match label with
                | Some l -> l.Stringify()
                | None -> ""
                
            $".css-{FNV_1A.hash mainCss}-{label}"
        let mainProperties =
            className, mainCss
        let pseudoProperties =
            List.filter isPseudo properties
            |> List.map createPseudoCss
            |> List.map (fun (p, s) -> $"{className}{p}", s)
        let mediaProperties =
            List.filter isMedia properties
            |> List.map createMediaCss
            |> List.map (fun (m, s) -> m, $"{className} {s}")
        let combinatorProperties =
            List.filter isCombinator properties
            |> List.collect createCombinatorCss
            |> List.map (fun (c, s) -> $"{className}{c}", s)
        
        [mainProperties] @ pseudoProperties @ mediaProperties @ combinatorProperties
        
    let private stringifyCounterProperty (property: CounterRule) =
        let propertyName, propertyValue = property

        $"{Helpers.toKebabCase
           <| propertyName.ToString()}: {propertyValue.Stringify()};"
           
    let counterStyle (properties: CounterRule list) : CounterName * CounterStyle =

        let properties =
            List.map stringifyCounterProperty properties
            |> String.concat "\n"
        let counterName = $"counter-{FNV_1A.hash properties}"

        counterName, properties
           
    let private stringifyFontFaceProperty (property: FontFaceRule) =
        let propertyName, propertyValue = property

        $"{Helpers.toKebabCase
           <| propertyName.ToString()}: {propertyValue.Stringify()};"
        
    let fontFace (name: string) (properties: FontFaceRule list) : FontName * FontFaceStyle =
        let properties = [ FontFace.FontFamily.string name ] @ properties
        let properties =
            List.map stringifyFontFaceProperty properties
            |> String.concat "\n"
        
        name, properties
        
    let keyframes (attributeList: KeyframeAttribute list) : AnimationName * Css =
        let framePositionToString frames =
            List.map (fun n -> $"{n}%%") frames
            |> String.concat ","

        let foo = 
            List.fold
                (fun acc x ->
                    match x with
                    | Frame (n, rules) ->
                        let _, rules = List.head <| fss rules
                        $"{acc} {n}%% {{ {rules} }}"
                    | Frames (ns, rules) ->
                        let _, rules = List.head <| fss rules
                        let frameNumbers = framePositionToString ns
                        $"{acc} {frameNumbers} {{ {rules} }}")
                ""
                attributeList

        $"animation-{FNV_1A.hash foo}", foo
        

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
