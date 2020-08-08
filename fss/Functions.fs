namespace Fss

open Value
open Selector
open Media
open Html
open FontFace
open Types

[<AutoOpen>]
module Functions =
    let Media (r: MediaFeature list) (p: CSSProperty list) = Media(r, p)
    let MediaFor (d: Device) (r: MediaFeature list) (p: CSSProperty list) = MediaFor(d, r, p)

    let (!+) (html: Html) (propertyList: CSSProperty list) = Selector (AdjacentSibling html, propertyList)
    let (!~) (html: Html) (propertyList: CSSProperty list) = Selector (GeneralSibling html, propertyList)
    let (!>) (html: Html) (propertyList: CSSProperty list) = Selector (Child html, propertyList)
    let (! ) (html: Html) (propertyList: CSSProperty list) = Selector (Descendant html, propertyList)

    //let FontFace (name: string) (properties: IFontFace list): FontFaceFoo = { FontFamily = name; Properties = properties}