namespace Fss

open Fss

module Static =
    type CssValue = string * (string * string)

    let fss (styleName: string) (styles: Fss.Types.Rule list) : CssValue =
        styleName, createFss styles
    let fssWithClassname (styleName: string) (styles: Fss.Types.Rule list) : CssValue =
        styleName, createFssWithClassname styleName styles
    let global' (styles: Fss.Types.Rule list) : CssValue =
        "", ("", createGlobal styles) 
    let counterStyle (styleName: string) (styles: Fss.Types.CounterRule list) : CssValue =
        let name, counterStyle = createCounterStyle styles
        styleName, (name, $"@counter-style {counterStyle}")
    let fontFaces  (styleName: string) (styles: Fss.Types.FontFaceRule list list) : CssValue =
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
    let fontFace (styleName: string) (styles: Fss.Types.FontFaceRule list) : CssValue =
        let name, fontFace = createFontFace styleName styles
        styleName, (name, $"@font-face {fontFace}")
    let keyframes  (styleName: string) (styles: Fss.Keyframes.Keyframes list) : CssValue =
        let name, animation = createAnimation styles
        styleName, (name, $"@keyframes {animation}")

    // FSS Overloads
    type Fss.Types.AnimationClasses.AnimationName with
        member this.value(animation: CssValue) =
            this.value(fst (snd animation))

    type Fss.Types.FontClasses.FontFamily with
        member this.value(font: CssValue) =
            this.value(fst (snd font))

    type Fss.Types.CounterClasses.CounterReset with
        member this.value(counter: CssValue) =
            this.value(fst (snd counter))

    type Fss.Types.CounterClasses.CounterSet with
        member this.value(counter: CssValue) =
            this.value(fst (snd counter))

    type Fss.Types.CounterClasses.CounterIncrement with
        member this.value(counter: CssValue) =
            this.value(fst (snd counter))

    type Fss.Types.ContentClasses.Content with
        member this.counter(counter: CssValue) =
            this.counter(fst (snd counter))

    type Fss.Types.ContentClasses.Content with
        member this.counter(counter: CssValue, separator: string) =
            this.counter(fst (snd counter), separator)

    type Fss.Types.ContentClasses.Content with
        member this.counter(counters: CssValue list, separators: string list) =
            this.counter(List.map (fun counter -> fst (snd counter)) counters, separators)

