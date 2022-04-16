namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module ListStyle =
    type Position =
        | Inside
        | Outside
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module ListStyleClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style
    type ListStyle(property) =
        inherit CssRuleWithNone(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-image
    type ListStyleImage(property) =
        inherit ImageClasses.ImageClass(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-position
    type ListStylePosition(property) =
        inherit CssRule(property)
        member this.inside = (property, ListStyle.Inside) |> Rule
        member this.outside = (property, ListStyle.Outside) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/list-style-type
    type ListStyleType(property) =
        inherit CssRuleWithNone(property)
        member this.value(value: string) = (property, String value) |> Rule
        member this.string(value: string) = (property, Char value) |> Rule
        member this.disc = (property, ListStyle.Disc) |> Rule
        member this.circle = (property, ListStyle.Circle) |> Rule
        member this.square = (property, ListStyle.Square) |> Rule
        member this.decimal = (property, ListStyle.Decimal) |> Rule
        member this.cjkDecimal = (property, ListStyle.CjkDecimal) |> Rule
        member this.decimalLeadingZero = (property, ListStyle.DecimalLeadingZero) |> Rule
        member this.lowerRoman = (property, ListStyle.LowerRoman) |> Rule
        member this.upperRoman = (property, ListStyle.UpperRoman) |> Rule
        member this.lowerGreek = (property, ListStyle.LowerGreek) |> Rule
        member this.lowerAlpha = (property, ListStyle.LowerAlpha) |> Rule
        member this.lowerLatin = (property, ListStyle.LowerLatin) |> Rule
        member this.upperAlpha = (property, ListStyle.UpperAlpha) |> Rule
        member this.upperLatin = (property, ListStyle.UpperLatin) |> Rule
        member this.arabicIndic = (property, ListStyle.ArabicIndic) |> Rule
        member this.armenian = (property, ListStyle.Armenian) |> Rule
        member this.bengali = (property, ListStyle.Bengali) |> Rule
        member this.cambodian = (property, ListStyle.Cambodian) |> Rule
        member this.cjkEarthlyBranch = (property, ListStyle.CjkEarthlyBranch) |> Rule
        member this.cjkHeavenlyStem = (property, ListStyle.CjkHeavenlyStem) |> Rule
        member this.cjkIdeographic = (property, ListStyle.CjkIdeographic) |> Rule
        member this.devanagari = (property, ListStyle.Devanagari) |> Rule
        member this.ethiopicNumeric = (property, ListStyle.EthiopicNumeric) |> Rule
        member this.georgian = (property, ListStyle.Georgian) |> Rule
        member this.gujarati = (property, ListStyle.Gujarati) |> Rule
        member this.gurmukhi = (property, ListStyle.Gurmukhi) |> Rule
        member this.hebrew = (property, ListStyle.Hebrew) |> Rule
        member this.hiragana = (property, ListStyle.Hiragana) |> Rule
        member this.hiraganaIroha = (property, ListStyle.HiraganaIroha) |> Rule
        member this.japaneseFormal = (property, ListStyle.JapaneseFormal) |> Rule
        member this.japaneseInformal = (property, ListStyle.JapaneseInformal) |> Rule
        member this.kannada = (property, ListStyle.Kannada) |> Rule
        member this.katakana = (property, ListStyle.Katakana) |> Rule
        member this.katakanaIroha = (property, ListStyle.KatakanaIroha) |> Rule
        member this.khmer = (property, ListStyle.Khmer) |> Rule
        member this.koreanHangulFormal = (property, ListStyle.KoreanHangulFormal) |> Rule
        member this.koreanHanjaFormal = (property, ListStyle.KoreanHanjaFormal) |> Rule
        member this.koreanHanjaInformal = (property, ListStyle.KoreanHanjaInformal) |> Rule
        member this.lao = (property, ListStyle.Lao) |> Rule
        member this.lowerArmenian = (property, ListStyle.LowerArmenian) |> Rule
        member this.malayalam = (property, ListStyle.Malayalam) |> Rule
        member this.mongolian = (property, ListStyle.Mongolian) |> Rule
        member this.myanmar = (property, ListStyle.Myanmar) |> Rule
        member this.oriya = (property, ListStyle.Oriya) |> Rule
        member this.persian = (property, ListStyle.Persian) |> Rule
        member this.simpChineseFormal = (property, ListStyle.SimpChineseFormal) |> Rule
        member this.simpChineseInformal = (property, ListStyle.SimpChineseInformal) |> Rule
        member this.tamil = (property, ListStyle.Tamil) |> Rule
        member this.telugu = (property, ListStyle.Telugu) |> Rule
        member this.thai = (property, ListStyle.Thai) |> Rule
        member this.tibetan = (property, ListStyle.Tibetan) |> Rule
        member this.tradChineseFormal = (property, ListStyle.TradChineseFormal) |> Rule
        member this.tradChineseInformal = (property, ListStyle.TradChineseInformal) |> Rule
        member this.upperArmenian = (property, ListStyle.UpperArmenian) |> Rule
        member this.disclosureOpen = (property, ListStyle.DisclosureOpen) |> Rule
        member this.disclosureClosed = (property, ListStyle.DisclosureClosed) |> Rule