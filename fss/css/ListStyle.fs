namespace Fss

[<RequireQualifiedAccess>]
module ListStyleType =
    type ListStyleImage =
        | ListStyleImage of string
        interface IListStyleImage

    type ListStylePosition =
        | Inside
        | Outside
        interface IListStylePosition

    type ListStyleType =
        | Disc
        | Circle
        | Square
        | Decimal
        | CjkDecimal
        | DecimalLeadingZero
        | LowerRoman
        | UpperRoman
        | LowerGreek
        | LowerAlpha
        | LowerLatin
        | UpperAlpha
        | UpperLatin
        | ArabicIndic
        | Armenian
        | Bengali
        | Cambodian
        | CjkEarthlyBranch
        | CjkHeavenlyStem
        | CjkIdeographic
        | Devanagari
        | EthiopicNumeric
        | Georgian
        | Gujarati
        | Gurmukhi
        | Hebrew
        | Hiragana
        | HiraganaIroha
        | JapaneseFormal
        | JapaneseInformal
        | Kannada
        | Katakana
        | KatakanaIroha
        | Khmer
        | KoreanHangulFormal
        | KoreanHanjaFormal
        | KoreanHanjaInformal
        | Lao
        | LowerArmenian
        | Malayalam
        | Mongolian
        | Myanmar
        | Oriya
        | Persian
        | SimpChineseFormal
        | SimpChineseInformal
        | Tamil
        | Telugu
        | Thai
        | Tibetan
        | TradChineseFormal
        | TradChineseInformal
        | UpperArmenian
        | DisclosureOpen
        | DisclosureClosed
        interface IListStyleType

    let styleTypeToString (styleType: IListStyleType) =
        match styleType with
        | :? ListStyleType as l -> Utilities.Helpers.duToKebab l
        | :? CounterType.CounterStyle as c -> counterValue c
        | :? CssString as s -> GlobalValue.string s |> sprintf "'%s'"
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown list style type"

[<AutoOpen>]
module ListStyle =
    let private listStyleToString (style: IListStyle) =
        match style with
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown list style"

    let private listStyleImageToString (image: IListStyleImage) =
        let stringifyImage =
            function
                | ListStyleType.ListStyleImage u -> sprintf "url('%s')" u

        match image with
        | :? ListStyleType.ListStyleImage as l -> stringifyImage l
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown list style image"

    let private stylePositionToString (stylePosition: IListStylePosition) =
        match stylePosition with
        | :? ListStyleType.ListStylePosition as l -> Utilities.Helpers.duToLowercase l
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown list style position"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style
    let private listStyleValue (value: string) = PropertyValue.cssValue Property.ListStyle value
    let private listStyleValue' value =
        value
        |> listStyleToString
        |> listStyleValue

    type ListStyle =
        static member Value (style: IListStyle) = style |> listStyleValue'

        static member None = None |> listStyleValue'
        static member Inherit = Inherit |> listStyleValue'
        static member Initial = Initial |> listStyleValue'
        static member Unset = Unset |> listStyleValue'

    /// <summary>Resets list style.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStyle' (style: IListStyle) = ListStyle.Value(style)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-image
    let private listStyleImageValue (value: string) = PropertyValue.cssValue Property.ListStyleImage value
    let private listStyleImageValue' value =
        value
        |> listStyleImageToString
        |> listStyleImageValue

    type ListStyleImage =
        static member Value (styleImage: IListStyleImage) = styleImage |> listStyleImageValue'
        static member Url (url: string) = ListStyleType.ListStyleImage url |> listStyleImageValue'

        static member None = None |> listStyleImageValue'
        static member Inherit = Inherit |> listStyleImageValue'
        static member Initial = Initial |> listStyleImageValue'
        static member Unset = Unset |> listStyleImageValue'

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
    let ListStyleImage' (image: IListStyleImage) = ListStyleImage.Value(image)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-position
    let private listStylePositionProperty (value: string) = PropertyValue.cssValue Property.ListStylePosition value
    let private listStylePositionProperty' value =
        value
        |> stylePositionToString
        |> listStylePositionProperty

    type ListStylePosition =
        static member Value (stylePosition: IListStylePosition) = stylePosition |> listStylePositionProperty'
        static member Inside = ListStyleType.Inside |> listStylePositionProperty'
        static member Outside = ListStyleType.Outside |> listStylePositionProperty'

        static member Inherit = Inherit |> listStylePositionProperty'
        static member Initial = Initial |> listStylePositionProperty'
        static member Unset = Unset |> listStylePositionProperty'

    /// <summary>Specifies the position of the marker of the list item.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> ListStylePosition</c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ListStylePosition' (position: IListStylePosition) = ListStylePosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-type
    let private listStyleTypeProperty (value: string) = PropertyValue.cssValue Property.ListStyleType value
    let private listStyleTypeProperty' value =
        value
        |> ListStyleType.styleTypeToString
        |> listStyleTypeProperty
    type ListStyleType =
        static member Value (styleType: IListStyleType) = styleType |> listStyleTypeProperty'
        static member Value(counter: CounterType.CounterStyle) = counterValue counter |> listStyleTypeProperty
        static member Disc = ListStyleType.Disc |> listStyleTypeProperty'
        static member Circle = ListStyleType.Circle |> listStyleTypeProperty'
        static member Square = ListStyleType.Square |> listStyleTypeProperty'
        static member Decimal = ListStyleType.Decimal |> listStyleTypeProperty'
        static member CjkDecimal = ListStyleType.CjkDecimal |> listStyleTypeProperty'
        static member DecimalLeadingZero = ListStyleType.DecimalLeadingZero |> listStyleTypeProperty'
        static member LowerRoman = ListStyleType.LowerRoman |> listStyleTypeProperty'
        static member UpperRoman = ListStyleType.UpperRoman |> listStyleTypeProperty'
        static member LowerGreek = ListStyleType.LowerGreek |> listStyleTypeProperty'
        static member LowerAlpha = ListStyleType.LowerAlpha |> listStyleTypeProperty'
        static member LowerLatin = ListStyleType.LowerLatin |> listStyleTypeProperty'
        static member UpperAlpha = ListStyleType.UpperAlpha |> listStyleTypeProperty'
        static member UpperLatin = ListStyleType.UpperLatin |> listStyleTypeProperty'
        static member ArabicIndic = ListStyleType.ArabicIndic |> listStyleTypeProperty'
        static member Armenian = ListStyleType.Armenian |> listStyleTypeProperty'
        static member Bengali = ListStyleType.Bengali |> listStyleTypeProperty'
        static member Cambodian = ListStyleType.Cambodian |> listStyleTypeProperty'
        static member CjkEarthlyBranch = ListStyleType.CjkEarthlyBranch |> listStyleTypeProperty'
        static member CjkHeavenlyStem = ListStyleType.CjkHeavenlyStem |> listStyleTypeProperty'
        static member CjkIdeographic = ListStyleType.CjkIdeographic |> listStyleTypeProperty'
        static member Devanagari = ListStyleType.Devanagari |> listStyleTypeProperty'
        static member EthiopicNumeric = ListStyleType.EthiopicNumeric |> listStyleTypeProperty'
        static member Georgian = ListStyleType.Georgian |> listStyleTypeProperty'
        static member Gujarati = ListStyleType.Gujarati |> listStyleTypeProperty'
        static member Gurmukhi = ListStyleType.Gurmukhi |> listStyleTypeProperty'
        static member Hebrew = ListStyleType.Hebrew |> listStyleTypeProperty'
        static member Hiragana = ListStyleType.Hiragana |> listStyleTypeProperty'
        static member HiraganaIroha = ListStyleType.HiraganaIroha |> listStyleTypeProperty'
        static member JapaneseFormal = ListStyleType.JapaneseFormal |> listStyleTypeProperty'
        static member JapaneseInformal = ListStyleType.JapaneseInformal |> listStyleTypeProperty'
        static member Kannada = ListStyleType.Kannada |> listStyleTypeProperty'
        static member Katakana = ListStyleType.Katakana |> listStyleTypeProperty'
        static member KatakanaIroha = ListStyleType.KatakanaIroha |> listStyleTypeProperty'
        static member Khmer = ListStyleType.Khmer |> listStyleTypeProperty'
        static member KoreanHangulFormal = ListStyleType.KoreanHangulFormal |> listStyleTypeProperty'
        static member KoreanHanjaFormal = ListStyleType.KoreanHanjaFormal |> listStyleTypeProperty'
        static member KoreanHanjaInformal = ListStyleType.KoreanHanjaInformal |> listStyleTypeProperty'
        static member Lao = ListStyleType.Lao |> listStyleTypeProperty'
        static member LowerArmenian = ListStyleType.LowerArmenian |> listStyleTypeProperty'
        static member Malayalam = ListStyleType.Malayalam |> listStyleTypeProperty'
        static member Mongolian = ListStyleType.Mongolian |> listStyleTypeProperty'
        static member Myanmar = ListStyleType.Myanmar |> listStyleTypeProperty'
        static member Oriya = ListStyleType.Oriya |> listStyleTypeProperty'
        static member Persian = ListStyleType.Persian |> listStyleTypeProperty'
        static member SimpChineseFormal = ListStyleType.SimpChineseFormal |> listStyleTypeProperty'
        static member SimpChineeInformal = ListStyleType.SimpChineseInformal |> listStyleTypeProperty'
        static member Tamil = ListStyleType.Tamil |> listStyleTypeProperty'
        static member Telugu = ListStyleType.Telugu |> listStyleTypeProperty'
        static member Thai = ListStyleType.Thai |> listStyleTypeProperty'
        static member Tibetan = ListStyleType.Tibetan |> listStyleTypeProperty'
        static member TradChineseFormal = ListStyleType.TradChineseFormal |> listStyleTypeProperty'
        static member TradChineseInformal = ListStyleType.TradChineseInformal |> listStyleTypeProperty'
        static member UpperArmenian = ListStyleType.UpperArmenian |> listStyleTypeProperty'
        static member DisclosureOpen = ListStyleType.DisclosureOpen |> listStyleTypeProperty'
        static member DisclosureClosed = ListStyleType.DisclosureClosed |> listStyleTypeProperty'

        static member None = None |> listStyleTypeProperty'
        static member Inherit = Inherit |> listStyleTypeProperty'
        static member Initial = Initial |> listStyleTypeProperty'
        static member Unset = Unset |> listStyleTypeProperty'

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
    let ListStyleType' (style: IListStyleType) = ListStyleType.Value(style)
