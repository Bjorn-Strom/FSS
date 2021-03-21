namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type ListStyleImage =
        | ListStyleImage of string
        interface Types.IListStyleImage

    type ListStylePosition =
        | Inside
        | Outside
        interface Types.IListStylePosition

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
        interface Types.IListStyleType

    let styleTypeToString (styleType: Types.IListStyleType) =
        match styleType with
        | :? ListStyleType as l -> Fss.Utilities.Helpers.duToKebab l
        | :? Types.CounterStyle as c -> Types.counterStyleToString c
        | :? Types.String as s -> Types.StringToString s |> sprintf "'%s'"
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown list style type"