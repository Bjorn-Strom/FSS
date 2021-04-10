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
    let private fssObject (attributeList: FssTypes.CssProperty list) =
        attributeList
        |> List.map FssTypes.masterTypeHelpers.CssValue
        |> createObj
        |> css'

    let fss (attributeList: FssTypes.CssProperty list) =
        attributeList
        |> fssObject
        |> string

    // Keyframes
    let keyframes (attributeList: KeyframeAttribute list) =
        attributeList
        |> createAnimationObject
        |> keyframes'
        |> FssTypes.CssString
        :> FssTypes.IAnimationName

    /// <summary>Write Css as key value string pairs.
    /// Allows you to add values not supported by Fss.</summary>
    /// <param name="key">Css property</param>
    /// <param name="value">Css value </param>
    /// <returns>Css property for fss.</returns>
    let Custom (key: string) (value: string) = key ==> value |> FssTypes.CssProperty

    let frame (f: int) (properties: FssTypes.CssProperty list) = (f, properties) |> Frame
    let frames (f: int list) (properties: FssTypes.CssProperty list) = (f, properties) |> Frames

    let counterStyle (attributeList: FssTypes.CounterProperty list) =
        let counterName = sprintf "counter_%s" <| Guid.NewGuid().ToString()

        createCounterObject attributeList counterName |> css' |> ignore

        counterName |> FssTypes.Counter.Style

    // Media
    let MediaQueryFor (device: FssTypes.Media.Device) (features: FssTypes.Media.Feature list) (attributeList: FssTypes.CssProperty list) =
        Media.Media(device, features, fss attributeList)
    let MediaQuery (features: FssTypes.Media.Feature list) (attributeList: FssTypes.CssProperty list) =
        Media.Media(features, fss attributeList)

    // Font
    let fontFace (fontFamily: string) (attributeList: FssTypes.CssProperty list) =
        attributeList
        |> createFontFaceObject fontFamily
        |> css'
        FssTypes.Font.Family.Name (FssTypes.Font.Name fontFamily)

    let fontFaces (fontFamily: string) (attributeLists: FssTypes.CssProperty list list) =
        attributeLists
        |> List.map (createFontFaceObject fontFamily)
        |> List.iter css'

        FssTypes.Font.Family.Name (FssTypes.Font.Name fontFamily)

    // Important
    let important property =
        let key, value = FssTypes.masterTypeHelpers.CssValue property
        key ==> $"{value} !important" |> FssTypes.CssProperty

    // Classnames
    let combine styles stylesPred =
        (styles
        |> List.map (fun s -> s, true)
        |> List.append) stylesPred
        |> List.filter snd
        |> List.map fst
        |> String.concat " "

    // Color
    let rgb (r: int) (g: int) (b: int) = FssTypes.Color.Color.rgb r g b
    let rgba (r: int) (g: int) (b: int) (a: float) = FssTypes.Color.Color.rgba r g b a

    let hex (value: string) = FssTypes.Color.Color.hex value

    let hsl (h: int) (s: float) (l: float) = FssTypes.Color.Color.hsl h s l
    let hsla (h: int) (s: float) (l: float) (a: float) = FssTypes.Color.Color.hsla h s l a

    // Sizes
    // Absolute
    let px (v: int): FssTypes.Size = sprintf "%dpx" v |> FssTypes.Px
    let inc (v: float): FssTypes.Size = sprintf "%.1fin" v |> FssTypes.In
    let cm (v: float): FssTypes.Size = sprintf "%.1fcm" v |> FssTypes.Cm
    let mm (v: float): FssTypes.Size = sprintf "%.1fmm" v |> FssTypes.Mm
    let pt (v: float): FssTypes.Size = sprintf "%.1fpt" v |> FssTypes.Pt
    let pc (v: float): FssTypes.Size = sprintf "%.1fpc" v |> FssTypes.Pc

    // Relative
    let em (v: float): FssTypes.Size = sprintf "%.1fem" v |> FssTypes.Em'
    let rem (v: float): FssTypes.Size = sprintf "%.1frem" v |> FssTypes.Rem
    let ex (v: float): FssTypes.Size = sprintf "%.1fex" v |> FssTypes.Ex
    let ch (v: float): FssTypes.Size = sprintf "%.1fch" v |> FssTypes.Ch
    let vw (v: float): FssTypes.Size = sprintf "%.1fvw" v |> FssTypes.Vw
    let vh (v: float): FssTypes.Size = sprintf "%.1fvh" v |> FssTypes.Vh
    let vmax (v: float): FssTypes.Size = sprintf "%.1fvmax" v |> FssTypes.VMax
    let vmin (v: float): FssTypes.Size = sprintf "%.1fvmin" v |> FssTypes.VMin

    // Angles
    let deg (v: float): FssTypes.Angle = sprintf "%.2fdeg" v |> FssTypes.Deg
    let grad (v: float): FssTypes.Angle = sprintf "%.2fgrad" v |> FssTypes.Grad
    let rad (v: float): FssTypes.Angle = sprintf "%.4frad" v |> FssTypes.Rad
    let turn (v: float): FssTypes.Angle = sprintf "%.2fturn" v |> FssTypes.Turn

    // Percent
    let pct (v: int): FssTypes.Percent = sprintf "%d%%" v |> FssTypes.Percent

    // Time
    let sec (v: float): FssTypes.Time = sprintf "%.2fs" v |> FssTypes.Sec
    let ms (v: float): FssTypes.Time = sprintf "%.2fms" v |> FssTypes.Ms

    // Fractions
    let fr (v: float): FssTypes.Fraction = sprintf "%.2ffr" v |> FssTypes.Fr