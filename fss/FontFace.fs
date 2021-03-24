namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module FontFace =
     // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
    let private stringifySource =
        function
            | FssTypes.FontFace.Url s -> sprintf "url('%s')" s
            | FssTypes.FontFace.UrlFormat (s, f) -> sprintf "url('%s') format('%s')" s (Utilities.Helpers.duToKebab f)
            | FssTypes.FontFace.Local l -> sprintf "local('%s')" l

    let private sourceValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Src value
    let private styleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStyle value
    let private displayValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontDisplay value
    let private stretchValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontStretch value
    let private weightValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FontWeight value

    type FontFace =
        static member Source (source: FssTypes.FontFace.Source) = source |> stringifySource |> sourceValue
        static member Sources (sources: FssTypes.FontFace.Source list) = Utilities.Helpers.combineComma stringifySource sources |> sourceValue
        static member Style (style: FssTypes.IFontStyle) = style |> FssTypes.fontHelpers.fontStyleToString |> styleValue
        static member Display (display: FssTypes.IFontDisplay) = display |> FssTypes.fontHelpers.fontDisplayToString |> displayValue
        static member Stretch (stretch: FssTypes.IFontStretch) = stretch |> FssTypes.fontHelpers.fontStretchToString |> stretchValue
        static member Weight (weight: FssTypes.IFontWeight) = weight |> FssTypes.fontHelpers.fontWeightToString |> weightValue

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