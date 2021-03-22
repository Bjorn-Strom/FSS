namespace Fss

[<AutoOpen>]
module ListStyle =
    let private listStyleToString (style: Types.IListStyle) =
        match style with
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown list style"

    let private listStyleImageToString (image: Types.IListStyleImage) =
        let stringifyImage =
            function
                | Types.ListStyle.Image u -> sprintf "url('%s')" u

        match image with
        | :? Types.ListStyle.Image as l -> stringifyImage l
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown list style image"

    let private stylePositionToString (stylePosition: Types.IListStylePosition) =
        match stylePosition with
        | :? Types.ListStyle.Position as l -> Utilities.Helpers.duToLowercase l
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown list style position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style
    let private listStyleValue (value: string) = Types.propertyHelpers.cssValue Types.Property.ListStyle value
    let private listStyleValue' value =
        value
        |> listStyleToString
        |> listStyleValue

    type ListStyle =
        static member Value (style: Types.IListStyle) = style |> listStyleValue'

        static member None = Types.None' |> listStyleValue'
        static member Inherit = Types.Inherit |> listStyleValue'
        static member Initial = Types.Initial |> listStyleValue'
        static member Unset = Types.Unset |> listStyleValue'

    /// <summary>Resets list style.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStyle' (style: Types.IListStyle) = ListStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-image
    let private listStyleImageValue (value: string) = Types.propertyHelpers.cssValue Types.Property.ListStyleImage value
    let private listStyleImageValue' value =
        value
        |> listStyleImageToString
        |> listStyleImageValue

    type ListStyleImage =
        static member Value (styleImage: Types.IListStyleImage) = styleImage |> listStyleImageValue'
        static member Url (url: string) = Types.ListStyle.Image url |> listStyleImageValue'

        static member None = Types.None' |> listStyleImageValue'
        static member Inherit = Types.Inherit |> listStyleImageValue'
        static member Initial = Types.Initial |> listStyleImageValue'
        static member Unset = Types.Unset |> listStyleImageValue'

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
    let ListStyleImage' (image: Types.IListStyleImage) = ListStyleImage.Value(image)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-position
    let private listStylePositionProperty (value: string) = Types.propertyHelpers.cssValue Types.Property.ListStylePosition value
    let private listStylePositionProperty' value =
        value
        |> stylePositionToString
        |> listStylePositionProperty

    type ListStylePosition =
        static member Value (stylePosition: Types.IListStylePosition) = stylePosition |> listStylePositionProperty'
        static member Inside = Types.ListStyle.Inside |> listStylePositionProperty'
        static member Outside = Types.ListStyle.Outside |> listStylePositionProperty'

        static member Inherit = Types.Inherit |> listStylePositionProperty'
        static member Initial = Types.Initial |> listStylePositionProperty'
        static member Unset = Types.Unset |> listStylePositionProperty'

    /// <summary>Specifies the position of the marker of the list item.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> ListStylePosition</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStylePosition' (position: Types.IListStylePosition) = ListStylePosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-type
    let private listStyleTypeProperty (value: string) = Types.propertyHelpers.cssValue Types.Property.ListStyleType value
    let private listStyleTypeProperty' value =
        value
        |> Types.listStyleHelpers.styleTypeToString
        |> listStyleTypeProperty
    type ListStyleType =
        static member Value (styleType: Types.IListStyleType) = styleType |> listStyleTypeProperty'
        static member Value(counter: Types.Counter.Style) = Types.counterStyleHelpers.counterStyleToString counter |> listStyleTypeProperty
        static member Disc = Types.ListStyle.Disc |> listStyleTypeProperty'
        static member Circle = Types.ListStyle.Circle |> listStyleTypeProperty'
        static member Square = Types.ListStyle.Square |> listStyleTypeProperty'
        static member Decimal = Types.ListStyle.Decimal |> listStyleTypeProperty'
        static member CjkDecimal = Types.ListStyle.CjkDecimal |> listStyleTypeProperty'
        static member DecimalLeadingZero = Types.ListStyle.DecimalLeadingZero |> listStyleTypeProperty'
        static member LowerRoman = Types.ListStyle.LowerRoman |> listStyleTypeProperty'
        static member UpperRoman = Types.ListStyle.UpperRoman |> listStyleTypeProperty'
        static member LowerGreek = Types.ListStyle.LowerGreek |> listStyleTypeProperty'
        static member LowerAlpha = Types.ListStyle.LowerAlpha |> listStyleTypeProperty'
        static member LowerLatin = Types.ListStyle.LowerLatin |> listStyleTypeProperty'
        static member UpperAlpha = Types.ListStyle.UpperAlpha |> listStyleTypeProperty'
        static member UpperLatin = Types.ListStyle.UpperLatin |> listStyleTypeProperty'
        static member ArabicIndic = Types.ListStyle.ArabicIndic |> listStyleTypeProperty'
        static member Armenian = Types.ListStyle.Armenian |> listStyleTypeProperty'
        static member Bengali = Types.ListStyle.Bengali |> listStyleTypeProperty'
        static member Cambodian = Types.ListStyle.Cambodian |> listStyleTypeProperty'
        static member CjkEarthlyBranch = Types.ListStyle.CjkEarthlyBranch |> listStyleTypeProperty'
        static member CjkHeavenlyStem = Types.ListStyle.CjkHeavenlyStem |> listStyleTypeProperty'
        static member CjkIdeographic = Types.ListStyle.CjkIdeographic |> listStyleTypeProperty'
        static member Devanagari = Types.ListStyle.Devanagari |> listStyleTypeProperty'
        static member EthiopicNumeric = Types.ListStyle.EthiopicNumeric |> listStyleTypeProperty'
        static member Georgian = Types.ListStyle.Georgian |> listStyleTypeProperty'
        static member Gujarati = Types.ListStyle.Gujarati |> listStyleTypeProperty'
        static member Gurmukhi = Types.ListStyle.Gurmukhi |> listStyleTypeProperty'
        static member Hebrew = Types.ListStyle.Hebrew |> listStyleTypeProperty'
        static member Hiragana = Types.ListStyle.Hiragana |> listStyleTypeProperty'
        static member HiraganaIroha = Types.ListStyle.HiraganaIroha |> listStyleTypeProperty'
        static member JapaneseFormal = Types.ListStyle.JapaneseFormal |> listStyleTypeProperty'
        static member JapaneseInformal = Types.ListStyle.JapaneseInformal |> listStyleTypeProperty'
        static member Kannada = Types.ListStyle.Kannada |> listStyleTypeProperty'
        static member Katakana = Types.ListStyle.Katakana |> listStyleTypeProperty'
        static member KatakanaIroha = Types.ListStyle.KatakanaIroha |> listStyleTypeProperty'
        static member Khmer = Types.ListStyle.Khmer |> listStyleTypeProperty'
        static member KoreanHangulFormal = Types.ListStyle.KoreanHangulFormal |> listStyleTypeProperty'
        static member KoreanHanjaFormal = Types.ListStyle.KoreanHanjaFormal |> listStyleTypeProperty'
        static member KoreanHanjaInformal = Types.ListStyle.KoreanHanjaInformal |> listStyleTypeProperty'
        static member Lao = Types.ListStyle.Lao |> listStyleTypeProperty'
        static member LowerArmenian = Types.ListStyle.LowerArmenian |> listStyleTypeProperty'
        static member Malayalam = Types.ListStyle.Malayalam |> listStyleTypeProperty'
        static member Mongolian = Types.ListStyle.Mongolian |> listStyleTypeProperty'
        static member Myanmar = Types.ListStyle.Myanmar |> listStyleTypeProperty'
        static member Oriya = Types.ListStyle.Oriya |> listStyleTypeProperty'
        static member Persian = Types.ListStyle.Persian |> listStyleTypeProperty'
        static member SimpChineseFormal = Types.ListStyle.SimpChineseFormal |> listStyleTypeProperty'
        static member SimpChineeInformal = Types.ListStyle.SimpChineseInformal |> listStyleTypeProperty'
        static member Tamil = Types.ListStyle.Tamil |> listStyleTypeProperty'
        static member Telugu = Types.ListStyle.Telugu |> listStyleTypeProperty'
        static member Thai = Types.ListStyle.Thai |> listStyleTypeProperty'
        static member Tibetan = Types.ListStyle.Tibetan |> listStyleTypeProperty'
        static member TradChineseFormal = Types.ListStyle.TradChineseFormal |> listStyleTypeProperty'
        static member TradChineseInformal = Types.ListStyle.TradChineseInformal |> listStyleTypeProperty'
        static member UpperArmenian = Types.ListStyle.UpperArmenian |> listStyleTypeProperty'
        static member DisclosureOpen = Types.ListStyle.DisclosureOpen |> listStyleTypeProperty'
        static member DisclosureClosed = Types.ListStyle.DisclosureClosed |> listStyleTypeProperty'

        static member None = Types.None' |> listStyleTypeProperty'
        static member Inherit = Types.Inherit |> listStyleTypeProperty'
        static member Initial = Types.Initial |> listStyleTypeProperty'
        static member Unset = Types.Unset |> listStyleTypeProperty'

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
    let ListStyleType' (style: Types.IListStyleType) = ListStyleType.Value(style)
