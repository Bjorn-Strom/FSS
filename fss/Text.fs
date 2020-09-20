namespace Fss

open Types
open Global
open Units.Percent
open Units.Size
open Utilities.Helpers

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
        | None
        | Underline
        | Overline
        | LineThrough
        interface ITextDecorationLine

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    type TextDecorationThickness =
        | Auto
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

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    type TextDecorationSkipInk =
        | None
        | Auto
        | All
        interface ITextDecorationSkipInk

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    type TextTransform =
        | None
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
            | :? TextDecorationLine as t -> duToKebab t
            | _                          -> "unknown text decoration line"

    let textDecorationThickness (v: ITextDecorationThickness): string = 
        match v with
            | :? Global                  as g -> GlobalValue.globalValue g
            | :? Percent                 as p -> Units.Percent.value p
            | :? Size                    as s -> Units.Size.value s
            | :? TextDecorationThickness as t -> duToKebab t
            | _                               -> "unkown text decoration thickness"

    let textDecorationStyle (v: ITextDecorationStyle): string =
        match v with
            | :? Global              as g -> GlobalValue.globalValue g
            | :? TextDecorationStyle as t -> duToLowercase t 
            | _                           -> "unknown text decoration style"

    let textDecorationSkipInk (v: ITextDecorationSkipInk): string =
        match v with
            | :? Global                as g -> GlobalValue.globalValue g
            | :? TextDecorationSkipInk as t -> duToLowercase t 
            | _                             -> "unknown text decoration skip ink"

    let textTransform (v: ITextTransform): string =
        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? TextTransform as t -> duToLowercase t 
            | _                     -> "unknown text transform"

    let textIndent (v: ITextIndent): string =
        match v with 
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Percent    as p -> Units.Percent.value p
            | :? Size       as s -> Units.Size.value s
            | :? TextIndent as t -> duToKebab t 
            | _                  -> "unknown text transform"

    let textShadow (v: ITextShadow) : string = 
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