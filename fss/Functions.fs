namespace Fss

open Value
open Selector
open Media
open Html
open Units.Size
open Color
open FontFace
open Keyframes

[<AutoOpen>]
module Functions =
    // Constructors
    let fss (attributeList: CSSProperty list) = 
        attributeList |> createCSSObject |> css'

    let keyframes (attributeList: KeyframeAttribute list) = 
        attributeList |> createAnimationObject |> kframes'

    let fontFace (fontFamily: string) (attributeList: FontFace list) =
        attributeList |> createFontFaceObject fontFamily |> css'
        FontName fontFamily

    // Media
    let Media (r: MediaFeature list) (p: CSSProperty list) = Media(r, p)
    let MediaFor (d: Device) (r: MediaFeature list) (p: CSSProperty list) = MediaFor(d, r, p)

    // Text shadow
    let TextShadows (textShadows: (Size * Size * Size * CssColor) list): CSSProperty =
        textShadows
        |> List.map (
            (fun (x, y, b, c) -> TextShadow.TextShadow(x, y, b, c)) >>
            (fun x -> x :> Types.ITextShadow))
        |> TextShadows

    let TextShadow (x: Size) (y: Size) (blur: Size) (color: CssColor): CSSProperty = 
        TextShadow (TextShadow.TextShadow(x, y, blur, color))

    // Selectors
    let (!+) (html: Html) (propertyList: CSSProperty list) = Selector (AdjacentSibling html, propertyList)
    let (!~) (html: Html) (propertyList: CSSProperty list) = Selector (GeneralSibling html, propertyList)
    let (!>) (html: Html) (propertyList: CSSProperty list) = Selector (Child html, propertyList)
    let (! ) (html: Html) (propertyList: CSSProperty list) = Selector (Descendant html, propertyList)

    // Cursor
    let Auto = Cursor.Auto
    let Default = Cursor.Default
    let None = Cursor.None
    let ContextMenu = Cursor.ContextMenu
    let Help = Cursor.Help
    let Pointer = Cursor.Pointer
    let Progress = Cursor.Progress
    let Wait = Cursor.Wait
    let Cell = Cursor.Cell
    let Crosshair = Cursor.Crosshair
    let Text = Cursor.Text
    let VerticalText = Cursor.VerticalText
    let Alias = Cursor.Alias
    let Copy = Cursor.Copy
    let Move = Cursor.Move
    let NoDrop = Cursor.NoDrop
    let NotAllowed = Cursor.NotAllowed
    let AllScroll = Cursor.AllScroll
    let ColResize = Cursor.ColResize
    let RowResize = Cursor.RowResize
    let NResize = Cursor.NResize
    let EResize = Cursor.EResize
    let SResize = Cursor.SResize
    let WResize = Cursor.WResize
    let NsResize = Cursor.NsResize
    let EwResize = Cursor.EwResize
    let NeResize = Cursor.NeResize
    let NwResize = Cursor.NwResize
    let SeResize = Cursor.SeResize
    let SwResize = Cursor.SwResize
    let NeswResize = Cursor.NeswResize
    let NwseResize = Cursor.NwseResize
    let Cursor (cursorType: Cursor.CursorType): CSSProperty = Cursor.Cursor cursorType |> Cursor
