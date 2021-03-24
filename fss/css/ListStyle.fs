namespace Fss

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
    let private listStyleValue (value: string) = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStyle value
    let private listStyleValue' value =
        value
        |> listStyleToString
        |> listStyleValue

    type ListStyle =
        static member Value (style: FssTypes.IListStyle) = style |> listStyleValue'

        static member None = FssTypes.None' |> listStyleValue'
        static member Inherit = FssTypes.Inherit |> listStyleValue'
        static member Initial = FssTypes.Initial |> listStyleValue'
        static member Unset = FssTypes.Unset |> listStyleValue'

    /// <summary>Resets list style.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStyle' (style: FssTypes.IListStyle) = ListStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-image
    let private listStyleImageValue (value: string) = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStyleImage value
    let private listStyleImageValue' value =
        value
        |> listStyleImageToString
        |> listStyleImageValue

    type ListStyleImage =
        static member Value (styleImage: FssTypes.IListStyleImage) = styleImage |> listStyleImageValue'
        static member Url (url: string) = FssTypes.ListStyle.Image url |> listStyleImageValue'

        static member None = FssTypes.None' |> listStyleImageValue'
        static member Inherit = FssTypes.Inherit |> listStyleImageValue'
        static member Initial = FssTypes.Initial |> listStyleImageValue'
        static member Unset = FssTypes.Unset |> listStyleImageValue'

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
    let ListStyleImage' (image: FssTypes.IListStyleImage) = ListStyleImage.Value(image)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-position
    let private listStylePositionProperty (value: string) = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStylePosition value
    let private listStylePositionProperty' value =
        value
        |> stylePositionToString
        |> listStylePositionProperty

    type ListStylePosition =
        static member Value (stylePosition: FssTypes.IListStylePosition) = stylePosition |> listStylePositionProperty'
        static member Inside = FssTypes.ListStyle.Inside |> listStylePositionProperty'
        static member Outside = FssTypes.ListStyle.Outside |> listStylePositionProperty'

        static member Inherit = FssTypes.Inherit |> listStylePositionProperty'
        static member Initial = FssTypes.Initial |> listStylePositionProperty'
        static member Unset = FssTypes.Unset |> listStylePositionProperty'

    /// <summary>Specifies the position of the marker of the list item.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> ListStylePosition</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStylePosition' (position: FssTypes.IListStylePosition) = ListStylePosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-type
    let private listStyleTypeProperty (value: string) = FssTypes.propertyHelpers.cssValue FssTypes.Property.ListStyleType value
    let private listStyleTypeProperty' value =
        value
        |> FssTypes.listStyleHelpers.styleTypeToString
        |> listStyleTypeProperty
    type ListStyleType =
        static member Value (styleType: FssTypes.IListStyleType) = styleType |> listStyleTypeProperty'
        static member Value(counter: FssTypes.Counter.Style) = FssTypes.counterStyleHelpers.counterStyleToString counter |> listStyleTypeProperty
        static member Disc = FssTypes.ListStyle.Disc |> listStyleTypeProperty'
        static member Circle = FssTypes.ListStyle.Circle |> listStyleTypeProperty'
        static member Square = FssTypes.ListStyle.Square |> listStyleTypeProperty'
        static member Decimal = FssTypes.ListStyle.Decimal |> listStyleTypeProperty'
        static member CjkDecimal = FssTypes.ListStyle.CjkDecimal |> listStyleTypeProperty'
        static member DecimalLeadingZero = FssTypes.ListStyle.DecimalLeadingZero |> listStyleTypeProperty'
        static member LowerRoman = FssTypes.ListStyle.LowerRoman |> listStyleTypeProperty'
        static member UpperRoman = FssTypes.ListStyle.UpperRoman |> listStyleTypeProperty'
        static member LowerGreek = FssTypes.ListStyle.LowerGreek |> listStyleTypeProperty'
        static member LowerAlpha = FssTypes.ListStyle.LowerAlpha |> listStyleTypeProperty'
        static member LowerLatin = FssTypes.ListStyle.LowerLatin |> listStyleTypeProperty'
        static member UpperAlpha = FssTypes.ListStyle.UpperAlpha |> listStyleTypeProperty'
        static member UpperLatin = FssTypes.ListStyle.UpperLatin |> listStyleTypeProperty'
        static member ArabicIndic = FssTypes.ListStyle.ArabicIndic |> listStyleTypeProperty'
        static member Armenian = FssTypes.ListStyle.Armenian |> listStyleTypeProperty'
        static member Bengali = FssTypes.ListStyle.Bengali |> listStyleTypeProperty'
        static member Cambodian = FssTypes.ListStyle.Cambodian |> listStyleTypeProperty'
        static member CjkEarthlyBranch = FssTypes.ListStyle.CjkEarthlyBranch |> listStyleTypeProperty'
        static member CjkHeavenlyStem = FssTypes.ListStyle.CjkHeavenlyStem |> listStyleTypeProperty'
        static member CjkIdeographic = FssTypes.ListStyle.CjkIdeographic |> listStyleTypeProperty'
        static member Devanagari = FssTypes.ListStyle.Devanagari |> listStyleTypeProperty'
        static member EthiopicNumeric = FssTypes.ListStyle.EthiopicNumeric |> listStyleTypeProperty'
        static member Georgian = FssTypes.ListStyle.Georgian |> listStyleTypeProperty'
        static member Gujarati = FssTypes.ListStyle.Gujarati |> listStyleTypeProperty'
        static member Gurmukhi = FssTypes.ListStyle.Gurmukhi |> listStyleTypeProperty'
        static member Hebrew = FssTypes.ListStyle.Hebrew |> listStyleTypeProperty'
        static member Hiragana = FssTypes.ListStyle.Hiragana |> listStyleTypeProperty'
        static member HiraganaIroha = FssTypes.ListStyle.HiraganaIroha |> listStyleTypeProperty'
        static member JapaneseFormal = FssTypes.ListStyle.JapaneseFormal |> listStyleTypeProperty'
        static member JapaneseInformal = FssTypes.ListStyle.JapaneseInformal |> listStyleTypeProperty'
        static member Kannada = FssTypes.ListStyle.Kannada |> listStyleTypeProperty'
        static member Katakana = FssTypes.ListStyle.Katakana |> listStyleTypeProperty'
        static member KatakanaIroha = FssTypes.ListStyle.KatakanaIroha |> listStyleTypeProperty'
        static member Khmer = FssTypes.ListStyle.Khmer |> listStyleTypeProperty'
        static member KoreanHangulFormal = FssTypes.ListStyle.KoreanHangulFormal |> listStyleTypeProperty'
        static member KoreanHanjaFormal = FssTypes.ListStyle.KoreanHanjaFormal |> listStyleTypeProperty'
        static member KoreanHanjaInformal = FssTypes.ListStyle.KoreanHanjaInformal |> listStyleTypeProperty'
        static member Lao = FssTypes.ListStyle.Lao |> listStyleTypeProperty'
        static member LowerArmenian = FssTypes.ListStyle.LowerArmenian |> listStyleTypeProperty'
        static member Malayalam = FssTypes.ListStyle.Malayalam |> listStyleTypeProperty'
        static member Mongolian = FssTypes.ListStyle.Mongolian |> listStyleTypeProperty'
        static member Myanmar = FssTypes.ListStyle.Myanmar |> listStyleTypeProperty'
        static member Oriya = FssTypes.ListStyle.Oriya |> listStyleTypeProperty'
        static member Persian = FssTypes.ListStyle.Persian |> listStyleTypeProperty'
        static member SimpChineseFormal = FssTypes.ListStyle.SimpChineseFormal |> listStyleTypeProperty'
        static member SimpChineeInformal = FssTypes.ListStyle.SimpChineseInformal |> listStyleTypeProperty'
        static member Tamil = FssTypes.ListStyle.Tamil |> listStyleTypeProperty'
        static member Telugu = FssTypes.ListStyle.Telugu |> listStyleTypeProperty'
        static member Thai = FssTypes.ListStyle.Thai |> listStyleTypeProperty'
        static member Tibetan = FssTypes.ListStyle.Tibetan |> listStyleTypeProperty'
        static member TradChineseFormal = FssTypes.ListStyle.TradChineseFormal |> listStyleTypeProperty'
        static member TradChineseInformal = FssTypes.ListStyle.TradChineseInformal |> listStyleTypeProperty'
        static member UpperArmenian = FssTypes.ListStyle.UpperArmenian |> listStyleTypeProperty'
        static member DisclosureOpen = FssTypes.ListStyle.DisclosureOpen |> listStyleTypeProperty'
        static member DisclosureClosed = FssTypes.ListStyle.DisclosureClosed |> listStyleTypeProperty'

        static member None = FssTypes.None' |> listStyleTypeProperty'
        static member Inherit = FssTypes.Inherit |> listStyleTypeProperty'
        static member Initial = FssTypes.Initial |> listStyleTypeProperty'
        static member Unset = FssTypes.Unset |> listStyleTypeProperty'

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
    let ListStyleType' (style: FssTypes.IListStyleType) = ListStyleType.Value(style)
