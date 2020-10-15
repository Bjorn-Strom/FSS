namespace Fss

open Value
open Selector
open Media
open Html
open Units.Size
open Color
open FontFaceValue
open Keyframes
open Counter

[<AutoOpen>]
module Functions =
    // Constructors
    let fss (attributeList: CSSProperty list) =
        attributeList |> createCSSObject |> css'

    let keyframes (attributeList: KeyframeAttribute list) =
        attributeList |> createAnimationObject |> kframes'

    let fontFace (fontFamily: string) (attributeList: FontFace.FontFace list) =
        attributeList |> createFontFaceObject fontFamily |> css'
        Font.FontName fontFamily

    let fontFaces (fontFamily: string) (attributeLists: FontFace.FontFace list list) =
        attributeLists |> List.map (createFontFaceObject fontFamily) |> css'
        Font.FontName fontFamily

    let counterStyle (attributeList: CounterProperty list) =
        let counterName = sprintf "a%i" <| attributeList.GetHashCode() |> string

        attributeList
        |> List.map (fun _ -> createCounterStyleObject counterName attributeList)
        |> css'
        |> ignore

        counterName
        |> Types.CounterStyle

    // Keyframes
    let frame (f: int) (properties: CSSProperty list) = (f, properties) |> Frame
    let frames (f: int list) (properties: CSSProperty list) = (f, properties) |> Frames

    // Media
    let MediaQuery (r: MediaFeature list) (p: CSSProperty list): CSSProperty = MediaProperty(r, p)
    let MediaQueryFor (d: Device) (r: MediaFeature list) (p: CSSProperty list): CSSProperty = MediaForProperty(d, r, p)

    // Selectors
    let (!+) (html: Html) (propertyList: CSSProperty list) = Selector (AdjacentSibling html, propertyList)
    let (!~) (html: Html) (propertyList: CSSProperty list) = Selector (GeneralSibling html, propertyList)
    let (!>) (html: Html) (propertyList: CSSProperty list) = Selector (Child html, propertyList)
    let (! ) (html: Html) (propertyList: CSSProperty list) = Selector (Descendant html, propertyList)

    // Globals
    let Initial = Global.Initial
    let Inherit = Global.Inherit
    let Unset   = Global.Unset
    let Revert  = Global.Revert
    let Normal  = Global.Normal
    let None    = Global.None
    let Center  = Global.Center
    let Auto    = Global.Auto

    // Color
    let rgb (r: int) (g: int) (b: int): CssColor = Utilities.Color.rgb r g b |> CssColor
    let rgba (r: int) (g: int) (b: int) (a: float): CssColor = Utilities.Color.rgba r g b a |> CssColor

    let hex (value: string): CssColor = Utilities.Color.hex value |> CssColor

    let hsl (h: int) (s: float) (l: float): CssColor = Utilities.Color.hsl h s l |> CssColor
    let hsla (h: int) (s: float) (l: float) (a: float):CssColor = Utilities.Color.hsla h s l a |> CssColor

    // Sizes
    // Absolute
    let px (v: int): Size = sprintf "%dpx" v |> Px
    let inc (v: float): Size = sprintf "%.1fin" v |> In
    let cm (v: float): Size = sprintf "%.1fcm" v |> Cm
    let mm (v: float): Size = sprintf "%.1fmm" v |> Mm
    let pt (v: float): Size = sprintf "%.1fpt" v |> Pt
    let pc (v: float): Size = sprintf "%.1fpc" v |> Pc

    // Relative
    let em (v: float): Size = sprintf "%.1fem" v |> Em
    let rem (v: float): Size = sprintf "%.1frem" v |> Rem
    let ex (v: float): Size = sprintf "%.1fex" v |> Ex
    let ch (v: float): Size = sprintf "%.1fch" v |> Ch
    let vw (v: float): Size = sprintf "%.1fvw" v |> Vw
    let vh (v: float): Size = sprintf "%.1fvh" v |> Vh
    let vmax (v: float): Size = sprintf "%.1fvmax" v |> VMax
    let vmin (v: float): Size = sprintf "%.1fvmin" v |> VMin

    // Angles
    let deg (v: float): Units.Angle.Angle = sprintf "%.2fdeg" v |> Units.Angle.Deg
    let grad (v: float): Units.Angle.Angle = sprintf "%.2fgrad" v |> Units.Angle.Grad
    let rad (v: float): Units.Angle.Angle = sprintf "%.4frad" v |> Units.Angle.Rad
    let turn (v: float): Units.Angle.Angle = sprintf "%.2fturn" v |> Units.Angle.Turn

    // Percent
    let pct (v: int): Units.Percent.Percent = sprintf "%d%%" v |> Units.Percent.Percent

    // Time
    let sec (v: float): Units.Time.Time = sprintf "%.2fs" v |> Units.Time.Sec
    let ms (v: float): Units.Time.Time = sprintf "%.2fms" v |> Units.Time.Ms

    // Shorthand
    let Borders: Border.Border =
        {
            Width = Border.Width.Medium
            Style = None
            Color = currentColor
        }

    let toBorder (border: Border.Border): CSSProperty =
        border :> Types.IBorder |> BorderShorthand
        
    let Backgrounds: Background.Background =
        {
            Image      = None
            Position   = pct 0
            Size       = Auto
            Repeat     = Background.Repeat
            Attachment = Background.Scroll
            Origin     = Background.PaddingBox
            Clip       = Background.Clip.BorderBox
            Color      = transparent
        }
        
    let toBackground (background: Background.Background): CSSProperty =
        background :> Types.IBackground |> BackgroundShorthand