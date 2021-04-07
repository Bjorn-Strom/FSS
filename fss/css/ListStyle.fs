namespace Fss

open Fable.Core

[<AutoOpen>]
module ListStyle =
    let private listStyleToString (style: FssTypes.IListStyle) =
        match style with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown list style"

    let private listStyleImageToString (image: FssTypes.IListStyleImage) =
        let stringifyImage =
            function
                | FssTypes.ListStyle.Image u -> sprintf "url('%s')" u

        match image with
        | :? FssTypes.ListStyle.Image as l -> stringifyImage l
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown list style image"

    let private stylePositionToString (stylePosition: FssTypes.IListStylePosition) =
        match stylePosition with
        | :? FssTypes.ListStyle.Position as l -> Utilities.Helpers.duToLowercase l
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown list style position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style
    let private listStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStyle
    let private listStyleValue' = listStyleToString >> listStyleValue

    [<Erase>]
    type ListStyle =
        static member value (style: FssTypes.IListStyle) = style |> listStyleValue'

        static member none = FssTypes.None' |> listStyleValue'
        static member inherit' = FssTypes.Inherit |> listStyleValue'
        static member initial = FssTypes.Initial |> listStyleValue'
        static member unset = FssTypes.Unset |> listStyleValue'

    /// <summary>Resets list style.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStyle' = ListStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-image
    let private listStyleImageValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStyleImage
    let private listStyleImageValue' = listStyleImageToString >> listStyleImageValue

    [<Erase>]
    type ListStyleImage =
        static member value (styleImage: FssTypes.IListStyleImage) = styleImage |> listStyleImageValue'
        static member url (url: string) = FssTypes.ListStyle.Image url |> listStyleImageValue'

        static member none = FssTypes.None' |> listStyleImageValue'
        static member inherit' = FssTypes.Inherit |> listStyleImageValue'
        static member initial = FssTypes.Initial |> listStyleImageValue'
        static member unset = FssTypes.Unset |> listStyleImageValue'

    /// <summary>Specifies an image to be used as the list item marker..</summary>
    /// <param name="image">
    ///     can be:
    ///     - <c> ListStyleImage</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStyleImage' = ListStyleImage.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-position
    let private listStylePositionProperty = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStylePosition
    let private listStylePositionProperty' = stylePositionToString >> listStylePositionProperty

    [<Erase>]
    type ListStylePosition =
        static member value (stylePosition: FssTypes.IListStylePosition) = stylePosition |> listStylePositionProperty'
        static member inside = FssTypes.ListStyle.Inside |> listStylePositionProperty'
        static member outside = FssTypes.ListStyle.Outside |> listStylePositionProperty'

        static member inherit' = FssTypes.Inherit |> listStylePositionProperty'
        static member initial = FssTypes.Initial |> listStylePositionProperty'
        static member unset = FssTypes.Unset |> listStylePositionProperty'

    /// <summary>Specifies the position of the marker of the list item.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> ListStylePosition</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStylePosition' = ListStylePosition.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-type
    let private listStyleTypeProperty = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStyleType
    let private listStyleTypeProperty' = FssTypes.listStyleHelpers.styleTypeToString >> listStyleTypeProperty
    [<Erase>]
    type ListStyleType =
        static member value (styleType: FssTypes.IListStyleType) = styleType |> listStyleTypeProperty'
        static member value(counter: FssTypes.Counter.Style) = FssTypes.counterStyleHelpers.counterStyleToString counter |> listStyleTypeProperty
        static member disc = FssTypes.ListStyle.Disc |> listStyleTypeProperty'
        static member circle = FssTypes.ListStyle.Circle |> listStyleTypeProperty'
        static member square = FssTypes.ListStyle.Square |> listStyleTypeProperty'
        static member decimal = FssTypes.ListStyle.Decimal |> listStyleTypeProperty'
        static member cjkDecimal = FssTypes.ListStyle.CjkDecimal |> listStyleTypeProperty'
        static member decimalLeadingZero = FssTypes.ListStyle.DecimalLeadingZero |> listStyleTypeProperty'
        static member lowerRoman = FssTypes.ListStyle.LowerRoman |> listStyleTypeProperty'
        static member upperRoman = FssTypes.ListStyle.UpperRoman |> listStyleTypeProperty'
        static member lowerGreek = FssTypes.ListStyle.LowerGreek |> listStyleTypeProperty'
        static member lowerAlpha = FssTypes.ListStyle.LowerAlpha |> listStyleTypeProperty'
        static member lowerLatin = FssTypes.ListStyle.LowerLatin |> listStyleTypeProperty'
        static member upperAlpha = FssTypes.ListStyle.UpperAlpha |> listStyleTypeProperty'
        static member upperLatin = FssTypes.ListStyle.UpperLatin |> listStyleTypeProperty'
        static member arabicIndic = FssTypes.ListStyle.ArabicIndic |> listStyleTypeProperty'
        static member armenian = FssTypes.ListStyle.Armenian |> listStyleTypeProperty'
        static member bengali = FssTypes.ListStyle.Bengali |> listStyleTypeProperty'
        static member cambodian = FssTypes.ListStyle.Cambodian |> listStyleTypeProperty'
        static member cjkEarthlyBranch = FssTypes.ListStyle.CjkEarthlyBranch |> listStyleTypeProperty'
        static member cjkHeavenlyStem = FssTypes.ListStyle.CjkHeavenlyStem |> listStyleTypeProperty'
        static member cjkIdeographic = FssTypes.ListStyle.CjkIdeographic |> listStyleTypeProperty'
        static member devanagari = FssTypes.ListStyle.Devanagari |> listStyleTypeProperty'
        static member ethiopicNumeric = FssTypes.ListStyle.EthiopicNumeric |> listStyleTypeProperty'
        static member georgian = FssTypes.ListStyle.Georgian |> listStyleTypeProperty'
        static member gujarati = FssTypes.ListStyle.Gujarati |> listStyleTypeProperty'
        static member gurmukhi = FssTypes.ListStyle.Gurmukhi |> listStyleTypeProperty'
        static member hebrew = FssTypes.ListStyle.Hebrew |> listStyleTypeProperty'
        static member hiragana = FssTypes.ListStyle.Hiragana |> listStyleTypeProperty'
        static member hiraganaIroha = FssTypes.ListStyle.HiraganaIroha |> listStyleTypeProperty'
        static member japaneseFormal = FssTypes.ListStyle.JapaneseFormal |> listStyleTypeProperty'
        static member japaneseInformal = FssTypes.ListStyle.JapaneseInformal |> listStyleTypeProperty'
        static member kannada = FssTypes.ListStyle.Kannada |> listStyleTypeProperty'
        static member katakana = FssTypes.ListStyle.Katakana |> listStyleTypeProperty'
        static member katakanaIroha = FssTypes.ListStyle.KatakanaIroha |> listStyleTypeProperty'
        static member khmer = FssTypes.ListStyle.Khmer |> listStyleTypeProperty'
        static member koreanHangulFormal = FssTypes.ListStyle.KoreanHangulFormal |> listStyleTypeProperty'
        static member koreanHanjaFormal = FssTypes.ListStyle.KoreanHanjaFormal |> listStyleTypeProperty'
        static member koreanHanjaInformal = FssTypes.ListStyle.KoreanHanjaInformal |> listStyleTypeProperty'
        static member lao = FssTypes.ListStyle.Lao |> listStyleTypeProperty'
        static member lowerArmenian = FssTypes.ListStyle.LowerArmenian |> listStyleTypeProperty'
        static member malayalam = FssTypes.ListStyle.Malayalam |> listStyleTypeProperty'
        static member mongolian = FssTypes.ListStyle.Mongolian |> listStyleTypeProperty'
        static member myanmar = FssTypes.ListStyle.Myanmar |> listStyleTypeProperty'
        static member oriya = FssTypes.ListStyle.Oriya |> listStyleTypeProperty'
        static member persian = FssTypes.ListStyle.Persian |> listStyleTypeProperty'
        static member simpChineseFormal = FssTypes.ListStyle.SimpChineseFormal |> listStyleTypeProperty'
        static member simpChineeInformal = FssTypes.ListStyle.SimpChineseInformal |> listStyleTypeProperty'
        static member tamil = FssTypes.ListStyle.Tamil |> listStyleTypeProperty'
        static member telugu = FssTypes.ListStyle.Telugu |> listStyleTypeProperty'
        static member thai = FssTypes.ListStyle.Thai |> listStyleTypeProperty'
        static member tibetan = FssTypes.ListStyle.Tibetan |> listStyleTypeProperty'
        static member tradChineseFormal = FssTypes.ListStyle.TradChineseFormal |> listStyleTypeProperty'
        static member tradChineseInformal = FssTypes.ListStyle.TradChineseInformal |> listStyleTypeProperty'
        static member upperArmenian = FssTypes.ListStyle.UpperArmenian |> listStyleTypeProperty'
        static member disclosureOpen = FssTypes.ListStyle.DisclosureOpen |> listStyleTypeProperty'
        static member disclosureClosed = FssTypes.ListStyle.DisclosureClosed |> listStyleTypeProperty'

        static member none = FssTypes.None' |> listStyleTypeProperty'
        static member inherit' = FssTypes.Inherit |> listStyleTypeProperty'
        static member initial = FssTypes.Initial |> listStyleTypeProperty'
        static member unset = FssTypes.Unset |> listStyleTypeProperty'

    /// <summary>Specifies list style marker.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> ListStyleType</c>
    ///     - <c> CounterStyle </c>
    ///     - <c> CssString </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStyleType': (FssTypes.IListStyleType -> FssTypes.CssProperty) = ListStyleType.value
