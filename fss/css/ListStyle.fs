namespace Fss

[<AutoOpen>]
module ListStyle =
    let private listStyleToString (style: Types.IListStyle) =
        match style with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown list style"

    let private listStyleImageToString (image: Types.IListStyleImage) =
        let stringifyImage =
            function
                | Types.ListStyleImage u -> sprintf "url('%s')" u

        match image with
        | :? Types.ListStyleImage as l -> stringifyImage l
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown list style image"

    let private stylePositionToString (stylePosition: Types.IListStylePosition) =
        match stylePosition with
        | :? Types.ListStylePosition as l -> Utilities.Helpers.duToLowercase l
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown list style position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style
    let private listStyleValue (value: string) = Types.cssValue Types.Property.ListStyle value
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
    let private listStyleImageValue (value: string) = Types.cssValue Types.Property.Property.ListStyleImage value
    let private listStyleImageValue' value =
        value
        |> listStyleImageToString
        |> listStyleImageValue

    type ListStyleImage =
        static member Value (styleImage: Types.IListStyleImage) = styleImage |> listStyleImageValue'
        static member Url (url: string) = Types.ListStyleImage url |> listStyleImageValue'

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
    let private listStylePositionProperty (value: string) = Types.cssValue Types.Property.ListStylePosition value
    let private listStylePositionProperty' value =
        value
        |> stylePositionToString
        |> listStylePositionProperty

    type ListStylePosition =
        static member Value (stylePosition: Types.IListStylePosition) = stylePosition |> listStylePositionProperty'
        static member Inside = Types.Inside |> listStylePositionProperty'
        static member Outside = Types.Outside |> listStylePositionProperty'

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
    let private listStyleTypeProperty (value: string) = Types.cssValue Types.Property.ListStyleType value
    let private listStyleTypeProperty' value =
        value
        |> Types.styleTypeToString
        |> listStyleTypeProperty
    type ListStyleType =
        static member Value (styleType: Types.IListStyleType) = styleType |> listStyleTypeProperty'
        static member Value(counter: Types.CounterStyle) = Types.counterStyleToString counter |> listStyleTypeProperty
        static member Disc = Types.Disc |> listStyleTypeProperty'
        static member Circle = Types.Circle |> listStyleTypeProperty'
        static member Square = Types.Square |> listStyleTypeProperty'
        static member Decimal = Types.Decimal |> listStyleTypeProperty'
        static member CjkDecimal = Types.CjkDecimal |> listStyleTypeProperty'
        static member DecimalLeadingZero = Types.DecimalLeadingZero |> listStyleTypeProperty'
        static member LowerRoman = Types.LowerRoman |> listStyleTypeProperty'
        static member UpperRoman = Types.UpperRoman |> listStyleTypeProperty'
        static member LowerGreek = Types.LowerGreek |> listStyleTypeProperty'
        static member LowerAlpha = Types.LowerAlpha |> listStyleTypeProperty'
        static member LowerLatin = Types.LowerLatin |> listStyleTypeProperty'
        static member UpperAlpha = Types.UpperAlpha |> listStyleTypeProperty'
        static member UpperLatin = Types.UpperLatin |> listStyleTypeProperty'
        static member ArabicIndic = Types.ArabicIndic |> listStyleTypeProperty'
        static member Armenian = Types.Armenian |> listStyleTypeProperty'
        static member Bengali = Types.Bengali |> listStyleTypeProperty'
        static member Cambodian = Types.Cambodian |> listStyleTypeProperty'
        static member CjkEarthlyBranch = Types.CjkEarthlyBranch |> listStyleTypeProperty'
        static member CjkHeavenlyStem = Types.CjkHeavenlyStem |> listStyleTypeProperty'
        static member CjkIdeographic = Types.CjkIdeographic |> listStyleTypeProperty'
        static member Devanagari = Types.Devanagari |> listStyleTypeProperty'
        static member EthiopicNumeric = Types.EthiopicNumeric |> listStyleTypeProperty'
        static member Georgian = Types.Georgian |> listStyleTypeProperty'
        static member Gujarati = Types.Gujarati |> listStyleTypeProperty'
        static member Gurmukhi = Types.Gurmukhi |> listStyleTypeProperty'
        static member Hebrew = Types.Hebrew |> listStyleTypeProperty'
        static member Hiragana = Types.Hiragana |> listStyleTypeProperty'
        static member HiraganaIroha = Types.HiraganaIroha |> listStyleTypeProperty'
        static member JapaneseFormal = Types.JapaneseFormal |> listStyleTypeProperty'
        static member JapaneseInformal = Types.JapaneseInformal |> listStyleTypeProperty'
        static member Kannada = Types.Kannada |> listStyleTypeProperty'
        static member Katakana = Types.Katakana |> listStyleTypeProperty'
        static member KatakanaIroha = Types.KatakanaIroha |> listStyleTypeProperty'
        static member Khmer = Types.Khmer |> listStyleTypeProperty'
        static member KoreanHangulFormal = Types.KoreanHangulFormal |> listStyleTypeProperty'
        static member KoreanHanjaFormal = Types.KoreanHanjaFormal |> listStyleTypeProperty'
        static member KoreanHanjaInformal = Types.KoreanHanjaInformal |> listStyleTypeProperty'
        static member Lao = Types.Lao |> listStyleTypeProperty'
        static member LowerArmenian = Types.LowerArmenian |> listStyleTypeProperty'
        static member Malayalam = Types.Malayalam |> listStyleTypeProperty'
        static member Mongolian = Types.Mongolian |> listStyleTypeProperty'
        static member Myanmar = Types.Myanmar |> listStyleTypeProperty'
        static member Oriya = Types.Oriya |> listStyleTypeProperty'
        static member Persian = Types.Persian |> listStyleTypeProperty'
        static member SimpChineseFormal = Types.SimpChineseFormal |> listStyleTypeProperty'
        static member SimpChineeInformal = Types.SimpChineseInformal |> listStyleTypeProperty'
        static member Tamil = Types.Tamil |> listStyleTypeProperty'
        static member Telugu = Types.Telugu |> listStyleTypeProperty'
        static member Thai = Types.Thai |> listStyleTypeProperty'
        static member Tibetan = Types.Tibetan |> listStyleTypeProperty'
        static member TradChineseFormal = Types.TradChineseFormal |> listStyleTypeProperty'
        static member TradChineseInformal = Types.TradChineseInformal |> listStyleTypeProperty'
        static member UpperArmenian = Types.UpperArmenian |> listStyleTypeProperty'
        static member DisclosureOpen = Types.DisclosureOpen |> listStyleTypeProperty'
        static member DisclosureClosed = Types.DisclosureClosed |> listStyleTypeProperty'

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
