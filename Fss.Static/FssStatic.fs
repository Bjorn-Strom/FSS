namespace Fss

open Fss

module Static =
    let fss (styleName: string) (styles: Fss.Types.Rule list) : (string * (string * string)) =
        styleName, createFss styles
    let fssWithClassname (styleName: string) (styles: Fss.Types.Rule list) : (string * (string * string)) =
        styleName, createFssWithClassname styleName styles
    let global' (styles: Fss.Types.Rule list) : (string * (string * string)) = 
        "", ("", createGlobal styles) 
    let counterStyle (styleName: string) (styles: Fss.Types.CounterRule list) : (string * (string * string)) =
        let name, counterStyle = createCounterStyle styles
        styleName, (name, $"@counter-style {counterStyle}")
    let fontFaces  (styleName: string) (styles: Fss.Types.FontFaceRule list list) : (string * (string * string)) =
        let fontFaces = 
            styles
            |> List.map (fun ff -> createFontFace styleName ff)
            |> List.map (fun f ->  fst f, $"@font-face {snd f}")
        let fontStyles = 
            fontFaces
            |> List.map snd
            |> String.concat ""
        let fontName =
            fontFaces
            |> List.head
            |> fst
        styleName, (fontName, fontStyles)
    let fontFace (styleName: string) (styles: Fss.Types.FontFaceRule list) : (string * (string * string)) =
        let name, fontFace = createFontFace styleName styles
        styleName, (name, $"@font-face {fontFace}")
    let keyframes  (styleName: string) (styles: Fss.Keyframes.Keyframes list) : (string * (string * string)) = 
        let name, animation = createAnimation styles
        styleName, (name, $"@keyframes {animation}")
