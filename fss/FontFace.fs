namespace Fss

open Fable.Core.JsInterop

open FssTypes

[<AutoOpen>]
module FontFace =
     // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
    let private stringifySource =
        function
            | Url s -> sprintf "url('%s')" s
            | UrlFormat (s, f) -> sprintf "url('%s') format('%s')" s (Utilities.Helpers.duToKebab f)
            | Local l -> sprintf "local('%s')" l

    let private sourceValue value = PropertyValue.cssValue Property.Src value
    let private styleValue value = PropertyValue.cssValue Property.FontStyle value
    let private displayValue value = PropertyValue.cssValue Property.FontDisplay value
    let private stretchValue value = PropertyValue.cssValue Property.FontStretch value
    let private weightValue value = PropertyValue.cssValue Property.FontWeight value

    type FontFace =
        static member Source (source: Source) = source |> stringifySource |> sourceValue
        static member Sources (sources: Source list) = Utilities.Helpers.combineComma stringifySource sources |> sourceValue
        static member Style (style: IFontStyle) = style |> Font.fontStyleToString |> styleValue
        static member Display (display: IFontDisplay) = display |> Font.fontDisplayToString |> displayValue
        static member Stretch (stretch: IFontStretch) = stretch |> Font.fontStretchToString |> stretchValue
        static member Weight (weight: IFontWeight) = weight |> Font.fontWeightToString |> weightValue

    let createFontFaceObject (fontName: string) (attributeList: CssProperty list) =
        let attributeList' =  List.map CssValue attributeList
        createObj
            [
                "@font-face" ==>
                    createObj
                        ([
                            "fontFamily" ==> fontName
                        ] @ attributeList')
            ]