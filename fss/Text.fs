namespace Fss

open Types
open Global
open Units.Percent
open Units.Size
open Utilities.Helpers
open Color

module Text =

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
    type TextAlign =
        | Left
        | Right
        | Center
        | Justify
        | JustifyAll
        | Start
        | End
        | MatchParent
        interface ITextAlign

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
    type TextDecorationLine =
        | Underline
        | Overline
        | LineThrough
        | Blink
        interface ITextDecorationLine

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    type TextDecorationThickness =
        | FromFont
        interface ITextDecorationThickness

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    type TextDecorationStyle =
        | Solid
        | Double
        | Dotted
        | Dashed
        | Wavy
        interface ITextDecorationStyle

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    type TextDecorationSkip =
        | Objects
        | Spaces
        | LeadingSpaces
        | TrailingSpaces
        | Edges
        | BoxDecoration
        interface ITextDecorationSkip

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    type TextDecorationSkipInk =
        | All
        interface ITextDecorationSkipInk

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    type TextTransform =
        | Capitalize
        | Uppercase
        | Lowercase
        | FullWidth
        | FullSizeKana
        interface ITextTransform

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    type TextIndent =
        | Hanging
        | EachLine
        interface ITextIndent

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
    // https://css-tricks.com/almanac/properties/t/text-shadow/
    open Color
    type TextShadowType =
        | TextShadow of Size * Size * Size * CssColor
        interface ITextShadow

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow
    type TextOverflow =
        | Clip
        | Ellipsis
        | Custom of string
        
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis
    type Keyword =
        | Filled
        | Open
        | FilledSesame
        | OpenSesame
    
    type TextEmphasis =
        | KeywordValue of Keyword
        | KeywordValueAndColor of Keyword * CssColor
        | String of string
        | StringAndColor of string * CssColor
        interface ITextEmphasis

module TextValue =
    open Text

    let textAlign (v: ITextAlign): string =
        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? TextAlign as t -> duToKebab t
            | _                 -> "Unknown text align"

    let textDecorationLine (v: ITextDecorationLine): string =
        match v with
            | :? Global             as g -> GlobalValue.globalValue g
            | :? None               as n -> GlobalValue.none n
            | :? TextDecorationLine as t -> duToKebab t
            | _                          -> "unknown text decoration line"

    let textDecorationThickness (v: ITextDecorationThickness): string =
        match v with
            | :? Global                  as g -> GlobalValue.globalValue g
            | :? Auto                    as a -> GlobalValue.auto a
            | :? Percent                 as p -> Units.Percent.value p
            | :? Size                    as s -> Units.Size.value s
            | :? TextDecorationThickness as t -> duToKebab t
            | _                               -> "unkown text decoration thickness"

    let textDecorationStyle (v: ITextDecorationStyle): string =
        match v with
            | :? Global              as g -> GlobalValue.globalValue g
            | :? TextDecorationStyle as t -> duToLowercase t
            | _                           -> "unknown text decoration style"

    let textDecorationSkip (v: ITextDecorationSkip): string =
        match v with
            | :? Global             as g -> GlobalValue.globalValue g
            | :? None               as n -> GlobalValue.none n
            | :? TextDecorationSkip as t -> duToKebab t
            | _                             -> "unknown text decoration skip ink"

    let textDecorationSkipInk (v: ITextDecorationSkipInk): string =
        match v with
            | :? Global                as g -> GlobalValue.globalValue g
            | :? Auto                  as a -> GlobalValue.auto a
            | :? None                  as n -> GlobalValue.none n
            | :? TextDecorationSkipInk as t -> duToLowercase t
            | _                             -> "unknown text decoration skip ink"

    let textTransform (v: ITextTransform): string =
        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? None          as n -> GlobalValue.none n
            | :? TextTransform as t -> duToLowercase t
            | _                     -> "unknown text transform"

    let textIndent (v: ITextIndent): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Percent    as p -> Units.Percent.value p
            | :? Size       as s -> Units.Size.value s
            | :? TextIndent as t -> duToKebab t
            | _                  -> "unknown text transform"

    let textShadow (v: ITextShadow): string =
        let getValue (TextShadow(s1, s2, s3, c)) = s1, s2, s3, c
        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? TextShadowType as t ->
                let (s1, s2, s3, c) = getValue t
                sprintf "%s %s %s %s" (Units.Size.value s1) (Units.Size.value s2) (Units.Size.value s3) (Color.value c)
            | _                      -> "Unknown text shadow"

    let textOverflow (v: TextOverflow): string =
        match v with
            | Custom s -> sprintf "\"%s\"" s
            | _        -> duToLowercase v
            
    let textEmphasis (v: ITextEmphasis): string =
        let stringifyTextEmphasis (s: TextEmphasis): string =
            match s with
                | KeywordValue k -> duToSpaced k
                | KeywordValueAndColor (k, c) -> sprintf "%s %s" (duToSpaced k) (Color.value c)
                | String s -> s
                | StringAndColor (s, c) -> sprintf "%s %s" s (Color.value c)
        
        match v with
            | :? Global       as g -> GlobalValue.globalValue g
            | :? None         as n -> GlobalValue.none n
            | :? TextEmphasis as t -> stringifyTextEmphasis t
            | _ -> "Unkown text emphasis"