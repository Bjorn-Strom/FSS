namespace Fss

open Fable.Core
open Fable.Core.JsInterop

[<AutoOpen>]
module FontFace =
     // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
    let private stringifySource =
        function
            | FssTypes.FontFace.Url s -> sprintf "url('%s')" s
            | FssTypes.FontFace.UrlFormat (s, f) -> sprintf "url('%s') format('%s')" s (Utilities.Helpers.duToKebab f)
            | FssTypes.FontFace.Local l -> sprintf "local('%s')" l

    let private sourceValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Src
    let private styleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStyle
    let private displayValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontDisplay
    let private stretchValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStretch
    let private weightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontWeight

    [<Erase>]
    type FontFace =
        static member source (source: FssTypes.FontFace.Source) = source |> stringifySource |> sourceValue
        static member sources (sources: FssTypes.FontFace.Source list) = Utilities.Helpers.combineComma stringifySource sources |> sourceValue
        static member style (style: FssTypes.IFontStyle) = style |> FssTypes.fontHelpers.fontStyleToString |> styleValue
        static member display (display: FssTypes.IFontDisplay) = display |> FssTypes.fontHelpers.fontDisplayToString |> displayValue
        static member stretch (stretch: FssTypes.IFontStretch) = stretch |> FssTypes.fontHelpers.fontStretchToString |> stretchValue
        static member weight (weight: FssTypes.IFontWeight) = weight |> FssTypes.fontHelpers.fontWeightToString |> weightValue

    let createFontFaceObject (fontName: string) (attributeList: FssTypes.CssProperty list) =
        let attributeList' =  List.map FssTypes.masterTypeHelpers.CssValue attributeList
        createObj
            [
                "@font-face" ==>
                    createObj
                        ([
                            "fontFamily" ==> fontName
                        ] @ attributeList')
            ]