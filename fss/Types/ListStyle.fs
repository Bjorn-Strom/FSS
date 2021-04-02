namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module ListStyle =
        type Image =
            | Image of string
            interface IListStyleImage

        type Position =
            | Inside
            | Outside
            interface IListStylePosition

        type Type =
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

    [<AutoOpen>]
    module listStyleHelpers =
        let internal styleTypeToString (styleType: IListStyleType) =
            match styleType with
            | :? ListStyle.Type as l -> Fss.Utilities.Helpers.duToKebab l
            | :? Counter.Style as c -> counterStyleToString c
            | :? CssString as s -> StringToString s |> sprintf "'%s'"
            | :? Keywords as k -> keywordsToString k
            | :? None' -> none
            | _ -> "Unknown list style type"