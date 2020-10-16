namespace Fss

open Fss.Types

module ListStyle =
    type ListStyleImage =
        | Url of string
        interface IListStyleImage

    type ListStylePosition =
        | Inside
        | Outside
        interface IListStylePosition

    type ListStyleType =
        | String of string
        | Custom of CounterStyle
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
        | SimpChineeInformal
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

    type ListStyle =
        {
            Type : IListStyleType
            Position : IListStylePosition
            Image : IListStyleImage
        }
        with
            interface IListStyle

    let _type (_type: IListStyleType) border =
        { border with Type = _type }

    let position (position: IListStylePosition) border =
        { border with Position = position }

    let image (image: IListStyleImage) border =
        { border with Image = image }

module ListStyleValue =
    open Global
    open ListStyle
    open Utilities.Helpers

    let image (v: IListStyleImage): string =
        let stringifyListStyle (l: ListStyleImage): string =
            match l with
                | Url u -> sprintf "url('%s')" u

        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? None           as n -> GlobalValue.none n
            | :? ListStyleImage as l -> stringifyListStyle l
            | _ -> "Unknown list style image"

    let position (v: IListStylePosition): string =
        match v with
            | :? Global            as g -> GlobalValue.globalValue g
            | :? ListStylePosition as l -> duToLowercase l
            | _ -> "Unknown list style position"

    let styleType (v: IListStyleType): string =
        let stringifyListStyleType (l: ListStyleType) =
            match l with
                | String  s -> sprintf "'%s'" s
                | Custom  c -> counterValue c
                | _ -> duToKebab l

        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? None          as n -> GlobalValue.none n
            | :? ListStyleType as l -> stringifyListStyleType l
            | _ -> "Unknown list style type"

    let listStyle (v: IListStyle): string =
        let stringifyListStyle (l: ListStyle) =
            sprintf "%s %s %s"
                (styleType l.Type)
                (image l.Image)
                (position l.Position)

        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? None      as n -> GlobalValue.none n
            | :? ListStyle as l -> stringifyListStyle l
            | _ -> "Unknown list style"