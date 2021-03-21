namespace Fss

open System
open Fable.Core
open Fable.Core.JsInterop

open Media
open Keyframes
open FssTypes

[<AutoOpen>]
module Functions =
    [<Import("css", from="@emotion/css")>]
    let private css(x) = jsNative
    let css' x = css(x)

    // Constructors
    let private fssObject (attributeList: CssProperty list) =
        attributeList
        |> List.map GlobalValue.CssValue
        |> createObj
        |> css'

    let fss (attributeList: CssProperty list) =
        attributeList
        |> fssObject
        |> string

    // Keyframes
    let keyframes (attributeList: KeyframeAttribute list) =
        attributeList
        |> createAnimationObject
        |> keyframes'
        |> CssString
        :> IAnimationName

    /// <summary>Write Css as key value string pairs.
    /// Allows you to add values not supported by Fss.</summary>
    /// <param name="key">Css property</param>
    /// <param name="value">Css value </param>
    /// <returns>Css property for fss.</returns>
    let Custom (key: string) (value: string) = key ==> value |> CssProperty

    let frame (f: int) (properties: CssProperty list) = (f, properties) |> Keyframes.Frame
    let frames (f: int list) (properties: CssProperty list) = (f, properties) |> Keyframes.Frames

    let counterStyle (attributeList: CounterProperty list) =
        let counterName = sprintf "counter_%s" <| Guid.NewGuid().ToString()

        createCounterObject attributeList counterName |> css' |> ignore

        counterName |> CounterStyle

    // Media
    let MediaQueryFor (device: Device) (features: MediaFeature list) (attributeList: CssProperty list) =
        Media.Media(device, features, attributeList)
    let MediaQuery (features: MediaFeature list) (attributeList: CssProperty list) =
        Media.Media(features, attributeList)

    // Font
    let fontFace (fontFamily: string) (attributeList: CssProperty list) =
        attributeList
        |> createFontFaceObject fontFamily
        |> css'
        FssTypes.FontName fontFamily

    let fontFaces (fontFamily: string) (attributeLists: CssProperty list list) =
        attributeLists
        |> List.map (createFontFaceObject fontFamily)
        |> css'

        FssTypes.FontName fontFamily

    // Color
    let rgb (r: int) (g: int) (b: int) = CssColor.Rgb(r,g,b)
    let rgba (r: int) (g: int) (b: int) (a: float) = CssColor.Rgba(r,g,b,a)

    let hex (value: string) = CssColor.Hex value

    let hsl (h: int) (s: float) (l: float) = CssColor.Hsl(h,s,l)
    let hsla (h: int) (s: float) (l: float) (a: float) = CssColor.Hsla(h,s,l,a)

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