namespace Fss

[<RequireQualifiedAccess>]
module ListStyleTypeType =
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
        | :? None' -> GlobalValue.none
        | _ -> "Unknown list style type"

[<AutoOpen>]
module ListStyle =
    let private listStyleToString (style: IListStyle) =
        match style with
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown list style"

    let private listStyleImageToString (image: IListStyleImage) =
        let stringifyImage =
            function
                | ListStyleTypeType.ListStyleImage u -> sprintf "url('%s')" u

        match image with
        | :? ListStyleTypeType.ListStyleImage as l -> stringifyImage l
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown list style image"

    let private stylePositionToString (stylePosition: IListStylePosition) =
        match stylePosition with
        | :? ListStyleTypeType.ListStylePosition as l -> Utilities.Helpers.duToLowercase l
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

        static member None = None' |> listStyleValue'
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
        static member Url (url: string) = ListStyleTypeType.ListStyleImage url |> listStyleImageValue'

        static member None = None' |> listStyleImageValue'
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
        static member Inside = ListStyleTypeType.Inside |> listStylePositionProperty'
        static member Outside = ListStyleTypeType.Outside |> listStylePositionProperty'

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
        |> ListStyleTypeType.styleTypeToString
        |> listStyleTypeProperty
    type ListStyleType =
        static member Value (styleType: IListStyleType) = styleType |> listStyleTypeProperty'
        static member Value(counter: CounterType.CounterStyle) = counterValue counter |> listStyleTypeProperty
        static member Disc = ListStyleTypeType.Disc |> listStyleTypeProperty'
        static member Circle = ListStyleTypeType.Circle |> listStyleTypeProperty'
        static member Square = ListStyleTypeType.Square |> listStyleTypeProperty'
        static member Decimal = ListStyleTypeType.Decimal |> listStyleTypeProperty'
        static member CjkDecimal = ListStyleTypeType.CjkDecimal |> listStyleTypeProperty'
        static member DecimalLeadingZero = ListStyleTypeType.DecimalLeadingZero |> listStyleTypeProperty'
        static member LowerRoman = ListStyleTypeType.LowerRoman |> listStyleTypeProperty'
        static member UpperRoman = ListStyleTypeType.UpperRoman |> listStyleTypeProperty'
        static member LowerGreek = ListStyleTypeType.LowerGreek |> listStyleTypeProperty'
        static member LowerAlpha = ListStyleTypeType.LowerAlpha |> listStyleTypeProperty'
        static member LowerLatin = ListStyleTypeType.LowerLatin |> listStyleTypeProperty'
        static member UpperAlpha = ListStyleTypeType.UpperAlpha |> listStyleTypeProperty'
        static member UpperLatin = ListStyleTypeType.UpperLatin |> listStyleTypeProperty'
        static member ArabicIndic = ListStyleTypeType.ArabicIndic |> listStyleTypeProperty'
        static member Armenian = ListStyleTypeType.Armenian |> listStyleTypeProperty'
        static member Bengali = ListStyleTypeType.Bengali |> listStyleTypeProperty'
        static member Cambodian = ListStyleTypeType.Cambodian |> listStyleTypeProperty'
        static member CjkEarthlyBranch = ListStyleTypeType.CjkEarthlyBranch |> listStyleTypeProperty'
        static member CjkHeavenlyStem = ListStyleTypeType.CjkHeavenlyStem |> listStyleTypeProperty'
        static member CjkIdeographic = ListStyleTypeType.CjkIdeographic |> listStyleTypeProperty'
        static member Devanagari = ListStyleTypeType.Devanagari |> listStyleTypeProperty'
        static member EthiopicNumeric = ListStyleTypeType.EthiopicNumeric |> listStyleTypeProperty'
        static member Georgian = ListStyleTypeType.Georgian |> listStyleTypeProperty'
        static member Gujarati = ListStyleTypeType.Gujarati |> listStyleTypeProperty'
        static member Gurmukhi = ListStyleTypeType.Gurmukhi |> listStyleTypeProperty'
        static member Hebrew = ListStyleTypeType.Hebrew |> listStyleTypeProperty'
        static member Hiragana = ListStyleTypeType.Hiragana |> listStyleTypeProperty'
        static member HiraganaIroha = ListStyleTypeType.HiraganaIroha |> listStyleTypeProperty'
        static member JapaneseFormal = ListStyleTypeType.JapaneseFormal |> listStyleTypeProperty'
        static member JapaneseInformal = ListStyleTypeType.JapaneseInformal |> listStyleTypeProperty'
        static member Kannada = ListStyleTypeType.Kannada |> listStyleTypeProperty'
        static member Katakana = ListStyleTypeType.Katakana |> listStyleTypeProperty'
        static member KatakanaIroha = ListStyleTypeType.KatakanaIroha |> listStyleTypeProperty'
        static member Khmer = ListStyleTypeType.Khmer |> listStyleTypeProperty'
        static member KoreanHangulFormal = ListStyleTypeType.KoreanHangulFormal |> listStyleTypeProperty'
        static member KoreanHanjaFormal = ListStyleTypeType.KoreanHanjaFormal |> listStyleTypeProperty'
        static member KoreanHanjaInformal = ListStyleTypeType.KoreanHanjaInformal |> listStyleTypeProperty'
        static member Lao = ListStyleTypeType.Lao |> listStyleTypeProperty'
        static member LowerArmenian = ListStyleTypeType.LowerArmenian |> listStyleTypeProperty'
        static member Malayalam = ListStyleTypeType.Malayalam |> listStyleTypeProperty'
        static member Mongolian = ListStyleTypeType.Mongolian |> listStyleTypeProperty'
        static member Myanmar = ListStyleTypeType.Myanmar |> listStyleTypeProperty'
        static member Oriya = ListStyleTypeType.Oriya |> listStyleTypeProperty'
        static member Persian = ListStyleTypeType.Persian |> listStyleTypeProperty'
        static member SimpChineseFormal = ListStyleTypeType.SimpChineseFormal |> listStyleTypeProperty'
        static member SimpChineeInformal = ListStyleTypeType.SimpChineseInformal |> listStyleTypeProperty'
        static member Tamil = ListStyleTypeType.Tamil |> listStyleTypeProperty'
        static member Telugu = ListStyleTypeType.Telugu |> listStyleTypeProperty'
        static member Thai = ListStyleTypeType.Thai |> listStyleTypeProperty'
        static member Tibetan = ListStyleTypeType.Tibetan |> listStyleTypeProperty'
        static member TradChineseFormal = ListStyleTypeType.TradChineseFormal |> listStyleTypeProperty'
        static member TradChineseInformal = ListStyleTypeType.TradChineseInformal |> listStyleTypeProperty'
        static member UpperArmenian = ListStyleTypeType.UpperArmenian |> listStyleTypeProperty'
        static member DisclosureOpen = ListStyleTypeType.DisclosureOpen |> listStyleTypeProperty'
        static member DisclosureClosed = ListStyleTypeType.DisclosureClosed |> listStyleTypeProperty'

        static member None = None' |> listStyleTypeProperty'
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
