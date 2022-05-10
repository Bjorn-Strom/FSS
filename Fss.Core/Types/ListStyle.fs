namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module ListStyle =
    type Position =
        | Inside
        | Outside
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Inside -> "inside"
                | Outside -> "outside"

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
            member this.StringifyCss() =
                match this with
                | Disc -> "disc"
                | Circle -> "circle"
                | Square -> "square"
                | Decimal -> "decimal"
                | CjkDecimal -> "cjk-decimal"
                | DecimalLeadingZero -> "decimal-leading-zero"
                | LowerRoman -> "lower-roman"
                | UpperRoman -> "upper-roman"
                | LowerGreek -> "lower-greek"
                | LowerAlpha -> "lower-alpha"
                | LowerLatin -> "lower-latin"
                | UpperAlpha -> "upper-alpha"
                | UpperLatin -> "upper-latin"
                | ArabicIndic -> "arabic-indic"
                | Armenian -> "armenian"
                | Bengali -> "bengali"
                | Cambodian -> "cambodian"
                | CjkEarthlyBranch -> "cjk-earthly-branch"
                | CjkHeavenlyStem -> "cjk-heavenly-stem"
                | CjkIdeographic -> "cjk-ideographic"
                | Devanagari -> "devanagari"
                | EthiopicNumeric -> "ethiopic-numeric"
                | Georgian -> "georgian"
                | Gujarati -> "gujarati"
                | Gurmukhi -> "gurmukhi"
                | Hebrew -> "hebrew"
                | Hiragana -> "hiragana"
                | HiraganaIroha -> "hiragana-iroha"
                | JapaneseFormal -> "japanese-formal"
                | JapaneseInformal -> "japanese-informal"
                | Kannada -> "kannada"
                | Katakana -> "katakana"
                | KatakanaIroha -> "katakana-iroha"
                | Khmer -> "khmer"
                | KoreanHangulFormal -> "korean-hangul-formal"
                | KoreanHanjaFormal -> "korean-hanja-formal"
                | KoreanHanjaInformal -> "korean-hanja-informal"
                | Lao -> "lao"
                | LowerArmenian -> "lower-armenian"
                | Malayalam -> "malayalam"
                | Mongolian -> "mongolian"
                | Myanmar -> "myanmar"
                | Oriya -> "oriya"
                | Persian -> "persian"
                | SimpChineseFormal -> "simp-chinese-formal"
                | SimpChineseInformal -> "simp-chinese-informal"
                | Tamil -> "tamil"
                | Telugu -> "telugu"
                | Thai -> "thai"
                | Tibetan -> "tibetan"
                | TradChineseFormal -> "trad-chinese-formal"
                | TradChineseInformal -> "trad-chinese-informal"
                | UpperArmenian -> "upper-armenian"
                | DisclosureOpen -> "disclosure-open"
                | DisclosureClosed -> "disclosure-closed"


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
        /// A filled circle. This is the default value
        member this.disc = (property, ListStyle.Disc) |> Rule
        /// A hollow circle
        member this.circle = (property, ListStyle.Circle) |> Rule
        /// A filled square
        member this.square = (property, ListStyle.Square) |> Rule
        /// Decimal numbers beginning with 1
        member this.decimal = (property, ListStyle.Decimal) |> Rule
        /// Han decimal numbers
        member this.cjkDecimal = (property, ListStyle.CjkDecimal) |> Rule
        /// Decimal numbers padded with zeros
        member this.decimalLeadingZero = (property, ListStyle.DecimalLeadingZero) |> Rule
        /// Lower case roman numerals
        member this.lowerRoman = (property, ListStyle.LowerRoman) |> Rule
        /// Upper case roman numerals
        member this.upperRoman = (property, ListStyle.UpperRoman) |> Rule
        /// Lowercase classical greek
        member this.lowerGreek = (property, ListStyle.LowerGreek) |> Rule
        /// Lowercase ASCII letters
        member this.lowerAlpha = (property, ListStyle.LowerAlpha) |> Rule
        /// Lowercase ASCII letters
        member this.lowerLatin = (property, ListStyle.LowerLatin) |> Rule
        /// Uppercase ASCII letters
        member this.upperAlpha = (property, ListStyle.UpperAlpha) |> Rule
        /// Uppercase ASCII letters
        member this.upperLatin = (property, ListStyle.UpperLatin) |> Rule
        /// Arabic-indic numbers
        member this.arabicIndic = (property, ListStyle.ArabicIndic) |> Rule
        /// Traditional armenian numbering
        member this.armenian = (property, ListStyle.Armenian) |> Rule
        /// Bengali numbering
        member this.bengali = (property, ListStyle.Bengali) |> Rule
        /// Cambodian numbering
        member this.cambodian = (property, ListStyle.Cambodian) |> Rule
        /// Han earthly branch ordinals
        member this.cjkEarthlyBranch = (property, ListStyle.CjkEarthlyBranch) |> Rule
        /// Han heavenly stem ordinals
        member this.cjkHeavenlyStem = (property, ListStyle.CjkHeavenlyStem) |> Rule
        /// Traditional chinese numbering
        member this.cjkIdeographic = (property, ListStyle.CjkIdeographic) |> Rule
        /// Devangari numbering
        member this.devanagari = (property, ListStyle.Devanagari) |> Rule
        /// Ethiopic numbering
        member this.ethiopicNumeric = (property, ListStyle.EthiopicNumeric) |> Rule
        /// Traditional georgian numbering
        member this.georgian = (property, ListStyle.Georgian) |> Rule
        /// Gujarati numbering
        member this.gujarati = (property, ListStyle.Gujarati) |> Rule
        /// gurmukhi numbering
        member this.gurmukhi = (property, ListStyle.Gurmukhi) |> Rule
        // Traditional Hebrew numbering
        member this.hebrew = (property, ListStyle.Hebrew) |> Rule
        /// Hiragana lettering
        member this.hiragana = (property, ListStyle.Hiragana) |> Rule
        /// Iroha hiragana lettering
        member this.hiraganaIroha = (property, ListStyle.HiraganaIroha) |> Rule
        /// Formal japanese numbering
        member this.japaneseFormal = (property, ListStyle.JapaneseFormal) |> Rule
        /// Informal japanese numbering
        member this.japaneseInformal = (property, ListStyle.JapaneseInformal) |> Rule
        /// Kannada numbering
        member this.kannada = (property, ListStyle.Kannada) |> Rule
        /// Katakana lettering
        member this.katakana = (property, ListStyle.Katakana) |> Rule
        /// Iroha katakana lettering
        member this.katakanaIroha = (property, ListStyle.KatakanaIroha) |> Rule
        /// Khmer numbering
        member this.khmer = (property, ListStyle.Khmer) |> Rule
        /// Korean hangul numbering
        member this.koreanHangulFormal = (property, ListStyle.KoreanHangulFormal) |> Rule
        /// Formal Korean hanja numbering
        member this.koreanHanjaFormal = (property, ListStyle.KoreanHanjaFormal) |> Rule
        /// Informal Korean hanja numbering 
        member this.koreanHanjaInformal = (property, ListStyle.KoreanHanjaInformal) |> Rule
        // Laotian numbering
        member this.lao = (property, ListStyle.Lao) |> Rule
        /// Lowercase armenian numbering
        member this.lowerArmenian = (property, ListStyle.LowerArmenian) |> Rule
        /// Malayalam numbering
        member this.malayalam = (property, ListStyle.Malayalam) |> Rule
        /// Mongolian numbering
        member this.mongolian = (property, ListStyle.Mongolian) |> Rule
        /// Myanmbar numbering
        member this.myanmar = (property, ListStyle.Myanmar) |> Rule
        /// Oriya numbering
        member this.oriya = (property, ListStyle.Oriya) |> Rule
        /// Persian numbering
        member this.persian = (property, ListStyle.Persian) |> Rule
        /// Formal simplified chinese numbering
        member this.simpChineseFormal = (property, ListStyle.SimpChineseFormal) |> Rule
        /// Informal simplified chinese numbering
        member this.simpChineseInformal = (property, ListStyle.SimpChineseInformal) |> Rule
        /// Tamil numbering
        member this.tamil = (property, ListStyle.Tamil) |> Rule
        /// Telugu numbering
        member this.telugu = (property, ListStyle.Telugu) |> Rule
        /// Thai numbering
        member this.thai = (property, ListStyle.Thai) |> Rule
        /// Tibetan numbering
        member this.tibetan = (property, ListStyle.Tibetan) |> Rule
        /// Formal traditional chinese numbering
        member this.tradChineseFormal = (property, ListStyle.TradChineseFormal) |> Rule
        /// Informal traditional chinese numbering
        member this.tradChineseInformal = (property, ListStyle.TradChineseInformal) |> Rule
        /// Traditional uppercase armenian numbering
        member this.upperArmenian = (property, ListStyle.UpperArmenian) |> Rule
        /// Symbol indicating a disclosure widget is open
        member this.disclosureOpen = (property, ListStyle.DisclosureOpen) |> Rule
        /// Symbol indicating a disclosure widget is closed
        member this.disclosureClosed = (property, ListStyle.DisclosureClosed) |> Rule