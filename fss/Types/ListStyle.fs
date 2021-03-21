namespace FssTypes

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

module ListStyleType =
    let styleTypeToString (styleType: IListStyleType) =
        match styleType with
        | :? ListStyleType as l -> Fss.Utilities.Helpers.duToKebab l
        | :? CounterStyle as c -> Counter.counterValue c
        | :? CssString as s -> string s |> sprintf "'%s'"
        | :? Global as g -> global' g
        | :? None' -> none
        | _ -> "Unknown list style type"