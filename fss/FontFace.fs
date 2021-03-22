namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module FontFace =
     // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
    let private stringifySource =
        function
            | Types.FontFace.Url s -> sprintf "url('%s')" s
            | Types.FontFace.UrlFormat (s, f) -> sprintf "url('%s') format('%s')" s (Utilities.Helpers.duToKebab f)
            | Types.FontFace.Local l -> sprintf "local('%s')" l

    let private sourceValue value = Types.propertyHelpers.cssValue Types.Property.Src value
    let private styleValue value = Types.propertyHelpers.cssValue Types.Property.FontStyle value
    let private displayValue value = Types.propertyHelpers.cssValue Types.Property.FontDisplay value
    let private stretchValue value = Types.propertyHelpers.cssValue Types.Property.FontStretch value
    let private weightValue value = Types.propertyHelpers.cssValue Types.Property.FontWeight value

    type FontFace =
        static member Source (source: Types.FontFace.Source) = source |> stringifySource |> sourceValue
        static member Sources (sources: Types.FontFace.Source list) = Utilities.Helpers.combineComma stringifySource sources |> sourceValue
        static member Style (style: Types.IFontStyle) = style |> Types.fontHelpers.fontStyleToString |> styleValue
        static member Display (display: Types.IFontDisplay) = display |> Types.fontHelpers.fontDisplayToString |> displayValue
        static member Stretch (stretch: Types.IFontStretch) = stretch |> Types.fontHelpers.fontStretchToString |> stretchValue
        static member Weight (weight: Types.IFontWeight) = weight |> Types.fontHelpers.fontWeightToString |> weightValue

    let createFontFaceObject (fontName: string) (attributeList: Types.CssProperty list) =
        let attributeList' =  List.map Types.masterTypeHelpers.CssValue attributeList
        createObj
            [
                "@font-face" ==>
                    createObj
                        ([
                            "fontFamily" ==> fontName
                        ] @ attributeList')
            ]