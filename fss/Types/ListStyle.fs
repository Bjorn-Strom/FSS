namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module ListStyle =
    type Image =
        | Image of string
        interface ICssValue with
            member this.Stringify() = failwith "todo"
    // TODO

    type Position =
        | Inside
        | Outside
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

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
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module ListStyleClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style
        type ListStyle(property) =
            inherit CssRuleWithNone(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-image
        type ListStyleImage(property) =
            inherit Image.ImageClasses.ImageClass(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-position
        type ListStylePosition(property) =
            inherit CssRule(property)
            member this.inside = (property, Inside) |> Rule
            member this.outside = (property, Outside) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-type
        type ListStyleType(property) =
            inherit CssRuleWithNone(property)
            member this.ident(value: string) = (property, String value) |> Rule
            member this.string(value: string) = (property, Char value) |> Rule
            member this.disc = (property, Disc) |> Rule
            member this.circle = (property, Circle) |> Rule
            member this.square = (property, Square) |> Rule
            member this.decimal = (property, Decimal) |> Rule
            member this.cjkDecimal = (property, CjkDecimal) |> Rule
            member this.decimalLeadingZero = (property, DecimalLeadingZero) |> Rule
            member this.lowerRoman = (property, LowerRoman) |> Rule
            member this.upperRoman = (property, UpperRoman) |> Rule
            member this.lowerGreek = (property, LowerGreek) |> Rule
            member this.lowerAlpha = (property, LowerAlpha) |> Rule
            member this.lowerLatin = (property, LowerLatin) |> Rule
            member this.upperAlpha = (property, UpperAlpha) |> Rule
            member this.upperLatin = (property, UpperLatin) |> Rule
            member this.arabicIndic = (property, ArabicIndic) |> Rule
            member this.armenian = (property, Armenian) |> Rule
            member this.bengali = (property, Bengali) |> Rule
            member this.cambodian = (property, Cambodian) |> Rule
            member this.cjkEarthlyBranch = (property, CjkEarthlyBranch) |> Rule
            member this.cjkHeavenlyStem = (property, CjkHeavenlyStem) |> Rule
            member this.cjkIdeographic = (property, CjkIdeographic) |> Rule
            member this.devanagari = (property, Devanagari) |> Rule
            member this.ethiopicNumeric = (property, EthiopicNumeric) |> Rule
            member this.georgian = (property, Georgian) |> Rule
            member this.gujarati = (property, Gujarati) |> Rule
            member this.gurmukhi = (property, Gurmukhi) |> Rule
            member this.hebrew = (property, Hebrew) |> Rule
            member this.hiragana = (property, Hiragana) |> Rule
            member this.hiraganaIroha = (property, HiraganaIroha) |> Rule
            member this.japaneseFormal = (property, JapaneseFormal) |> Rule
            member this.japaneseInformal = (property, JapaneseInformal) |> Rule
            member this.kannada = (property, Kannada) |> Rule
            member this.katakana = (property, Katakana) |> Rule
            member this.katakanaIroha = (property, KatakanaIroha) |> Rule
            member this.khmer = (property, Khmer) |> Rule
            member this.koreanHangulFormal = (property, KoreanHangulFormal) |> Rule
            member this.koreanHanjaFormal = (property, KoreanHanjaFormal) |> Rule
            member this.koreanHanjaInformal = (property, KoreanHanjaInformal) |> Rule
            member this.lao = (property, Lao) |> Rule
            member this.lowerArmenian = (property, LowerArmenian) |> Rule
            member this.malayalam = (property, Malayalam) |> Rule
            member this.mongolian = (property, Mongolian) |> Rule
            member this.myanmar = (property, Myanmar) |> Rule
            member this.oriya = (property, Oriya) |> Rule
            member this.persian = (property, Persian) |> Rule
            member this.simpChineseFormal = (property, SimpChineseFormal) |> Rule
            member this.simpChineseInformal = (property, SimpChineseInformal) |> Rule
            member this.tamil = (property, Tamil) |> Rule
            member this.telugu = (property, Telugu) |> Rule
            member this.thai = (property, Thai) |> Rule
            member this.tibetan = (property, Tibetan) |> Rule
            member this.tradChineseFormal = (property, TradChineseFormal) |> Rule
            member this.tradChineseInformal = (property, TradChineseInformal) |> Rule
            member this.upperArmenian = (property, UpperArmenian) |> Rule
            member this.disclosureOpen = (property, DisclosureOpen) |> Rule
            member this.disclosureClosed = (property, DisclosureClosed) |> Rule