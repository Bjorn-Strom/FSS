namespace Fss

open Value
open Selector
open Media
open Html
open Units.Size
open Color

[<AutoOpen>]
module Functions =
    let Media (r: MediaFeature list) (p: CSSProperty list) = Media(r, p)
    let MediaFor (d: Device) (r: MediaFeature list) (p: CSSProperty list) = MediaFor(d, r, p)

    let TextShadows (textShadows: (Size * Size * Size * CssColor) list): CSSProperty =
        textShadows
        |> List.map (
            (fun (x, y, b, c) -> TextShadow.TextShadow(x, y, b, c)) >>
            (fun x -> x :> Types.ITextShadow))
        |> TextShadows

    let TextShadow (x: Size) (y: Size) (blur: Size) (color: CssColor): CSSProperty = 
        TextShadow (TextShadow.TextShadow(x, y, blur, color))

    let (!+) (html: Html) (propertyList: CSSProperty list) = Selector (AdjacentSibling html, propertyList)
    let (!~) (html: Html) (propertyList: CSSProperty list) = Selector (GeneralSibling html, propertyList)
    let (!>) (html: Html) (propertyList: CSSProperty list) = Selector (Child html, propertyList)
    let (! ) (html: Html) (propertyList: CSSProperty list) = Selector (Descendant html, propertyList)
