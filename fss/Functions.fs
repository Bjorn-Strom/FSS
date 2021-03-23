namespace Fss

open System
open Fable.Core
open Fable.Core.JsInterop

open Media
open Keyframes

[<AutoOpen>]
module Functions =
    [<Import("css", from="@emotion/css")>]
    let private css(x) = jsNative
    let css' x = css(x)

    // Constructors
    let private fssObject (attributeList: Types.CssProperty list) =
        attributeList
        |> List.map Types.masterTypeHelpers.CssValue
        |> createObj
        |> css'

    let fss (attributeList: Types.CssProperty list) =
        attributeList
        |> fssObject
        |> string

    // Keyframes
    let keyframes (attributeList: KeyframeAttribute list) =
        attributeList
        |> createAnimationObject
        |> keyframes'
        |> Types.CssString
        :> Types.IAnimationName

    /// <summary>Write Css as key value string pairs.
    /// Allows you to add values not supported by Fss.</summary>
    /// <param name="key">Css property</param>
    /// <param name="value">Css value </param>
    /// <returns>Css property for fss.</returns>
    let Custom (key: string) (value: string) = key ==> value |> Types.CssProperty

    let frame (f: int) (properties: Types.CssProperty list) = (f, properties) |> Frame
    let frames (f: int list) (properties: Types.CssProperty list) = (f, properties) |> Frames

    let counterStyle (attributeList: Types.CounterProperty list) =
        let counterName = sprintf "counter_%s" <| Guid.NewGuid().ToString()

        createCounterObject attributeList counterName |> css' |> ignore

        counterName |> Types.Counter.Style

    // Media
    let MediaQueryFor (device: Types.Media.Device) (features: Types.Media.Feature list) (attributeList: Types.CssProperty list) =
        Media.Media(device, features, fss attributeList)
    let MediaQuery (features: Types.Media.Feature list) (attributeList: Types.CssProperty list) =
        Media.Media(features, fss attributeList)

    // Font
    let fontFace (fontFamily: string) (attributeList: Types.CssProperty list) =
        attributeList
        |> createFontFaceObject fontFamily
        |> css'
        Types.Font.Family.Name (Types.Font.Name fontFamily)

    let fontFaces (fontFamily: string) (attributeLists: Types.CssProperty list list) =
        attributeLists
        |> List.map (createFontFaceObject fontFamily)
        |> css'

        Types.Font.Family.Name (Types.Font.Name fontFamily)

    // Color
    let rgb (r: int) (g: int) (b: int) = Types.Color.Rgb(r,g,b)
    let rgba (r: int) (g: int) (b: int) (a: float) = Types.Color.Rgba(r,g,b,a)

    let hex (value: string) = Types.Color.Hex value

    let hsl (h: int) (s: float) (l: float) = Types.Color.Hsl(h,s,l)
    let hsla (h: int) (s: float) (l: float) (a: float) = Types.Color.Hsla(h,s,l,a)

    // Sizes
    // Absolute
    let px (v: int): Types.Size = sprintf "%dpx" v |> Types.Px
    let inc (v: float): Types.Size = sprintf "%.1fin" v |> Types.In
    let cm (v: float): Types.Size = sprintf "%.1fcm" v |> Types.Cm
    let mm (v: float): Types.Size = sprintf "%.1fmm" v |> Types.Mm
    let pt (v: float): Types.Size = sprintf "%.1fpt" v |> Types.Pt
    let pc (v: float): Types.Size = sprintf "%.1fpc" v |> Types.Pc

    // Relative
    let em (v: float): Types.Size = sprintf "%.1fem" v |> Types.Em'
    let rem (v: float): Types.Size = sprintf "%.1frem" v |> Types.Rem
    let ex (v: float): Types.Size = sprintf "%.1fex" v |> Types.Ex
    let ch (v: float): Types.Size = sprintf "%.1fch" v |> Types.Ch
    let vw (v: float): Types.Size = sprintf "%.1fvw" v |> Types.Vw
    let vh (v: float): Types.Size = sprintf "%.1fvh" v |> Types.Vh
    let vmax (v: float): Types.Size = sprintf "%.1fvmax" v |> Types.VMax
    let vmin (v: float): Types.Size = sprintf "%.1fvmin" v |> Types.VMin

    // Angles
    let deg (v: float): Types.Angle = sprintf "%.2fdeg" v |> Types.Deg
    let grad (v: float): Types.Angle = sprintf "%.2fgrad" v |> Types.Grad
    let rad (v: float): Types.Angle = sprintf "%.4frad" v |> Types.Rad
    let turn (v: float): Types.Angle = sprintf "%.2fturn" v |> Types.Turn

    // Percent
    let pct (v: int): Types.Percent = sprintf "%d%%" v |> Types.Percent

    // Time
    let sec (v: float): Types.Time = sprintf "%.2fs" v |> Types.Sec
    let ms (v: float): Types.Time = sprintf "%.2fms" v |> Types.Ms

    // Fractions
    let fr (v: float): Types.Fraction = sprintf "%.2ffr" v |> Types.Fr