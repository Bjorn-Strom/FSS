namespace Fss

open System
open Fable.Core
open Fable.Core.JsInterop
open Media
open Keyframes

[<AutoOpen>]
module Functions =
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let css' x = css(x)

    // Constructors
    let private fssObject (attributeList: CSSProperty list) =
        attributeList
        |> List.map GlobalValue.CSSValue
        |> createObj
        |> css'

    let fss (attributeList: CSSProperty list) =
        attributeList
        |> fssObject
        |> string

    // Keyframes
    let keyframes (attributeList: KeyframeAttribute list) =
        attributeList
        |> createAnimationObject
        |> kframes'
        |> CssString
        :> IAnimationName

    let frame (f: int) (properties: CSSProperty list) = (f, properties) |> Frame
    let frames (f: int list) (properties: CSSProperty list) = (f, properties) |> Frames

    let counterStyle (attributeList: CounterProperty list) =
        let counterName = sprintf "counter_%s" <| Guid.NewGuid().ToString()

        createCounterObject attributeList counterName |> css' |> ignore

        counterName |> CounterType.CounterStyle

    // Media
    let MediaQueryFor (device: Device) (features: MediaFeature list) (attributeList: CSSProperty list) =
        Media.Media(device, features, attributeList |> fss)
    let MediaQuery (features: MediaFeature list) (attributeList: CSSProperty list) =
        Media.Media(features, attributeList |> fss)

    // Font
    let fontFace (fontFamily: string) (attributeList: CSSProperty list) =
        attributeList
        |> createFontFaceObject fontFamily
        |> css'
        FontTypes.FontName fontFamily

    let fontFaces (fontFamily: string) (attributeLists: CSSProperty list list) =
        attributeLists
        |> List.map (createFontFaceObject fontFamily)
        |> css'

        FontTypes.FontName fontFamily

    // Image
    let stop (color: CSSColor) (stop: ILengthPercentage) = ColorStop(color, stop) :> IColorStop
    let stop2 (color: CSSColor) (stop1: ILengthPercentage) (stop2: ILengthPercentage) = ColorStop2(color, stop1, stop2) :> IColorStop

    // Color
    let rgb (r: int) (g: int) (b: int) = CSSColor.Rgb(r,g,b)
    let rgba (r: int) (g: int) (b: int) (a: float) = CSSColor.Rgba(r,g,b,a)

    let hex (value: string) = CSSColor.Hex value

    let hsl (h: int) (s: float) (l: float) = CSSColor.Hsl(h,s,l)
    let hsla (h: int) (s: float) (l: float) (a: float) = CSSColor.Hsla(h,s,l,a)

    // Sizes
    // Absolute
    let px (v: int): Units.Size.Size = sprintf "%dpx" v |> Units.Size.Px
    let inc (v: float): Units.Size.Size = sprintf "%.1fin" v |> Units.Size.In
    let cm (v: float): Units.Size.Size = sprintf "%.1fcm" v |> Units.Size.Cm
    let mm (v: float): Units.Size.Size = sprintf "%.1fmm" v |> Units.Size.Mm
    let pt (v: float): Units.Size.Size = sprintf "%.1fpt" v |> Units.Size.Pt
    let pc (v: float): Units.Size.Size = sprintf "%.1fpc" v |> Units.Size.Pc

    // Relative
    let em (v: float): Units.Size.Size = sprintf "%.1fem" v |> Units.Size.Em
    let rem (v: float): Units.Size.Size = sprintf "%.1frem" v |> Units.Size.Rem
    let ex (v: float): Units.Size.Size = sprintf "%.1fex" v |> Units.Size.Ex
    let ch (v: float): Units.Size.Size = sprintf "%.1fch" v |> Units.Size.Ch
    let vw (v: float): Units.Size.Size = sprintf "%.1fvw" v |> Units.Size.Vw
    let vh (v: float): Units.Size.Size = sprintf "%.1fvh" v |> Units.Size.Vh
    let vmax (v: float): Units.Size.Size = sprintf "%.1fvmax" v |> Units.Size.VMax
    let vmin (v: float): Units.Size.Size = sprintf "%.1fvmin" v |> Units.Size.VMin

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

    // Fractions
    let fr (v: float): Units.Fraction.Fraction = sprintf "%.2ffr" v |> Units.Fraction.Fr