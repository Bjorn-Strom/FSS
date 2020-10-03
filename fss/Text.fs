namespace Fss

open Fss
open Types
open Global
open Units.Percent
open Units.Size
open Utilities.Helpers
open Color

module Text =

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
    type Align =
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
    type DecorationLine =
        | Underline
        | Overline
        | LineThrough
        | Blink
        interface ITextDecorationLine

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    type DecorationThickness =
        | FromFont
        interface ITextDecorationThickness

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    type DecorationStyle =
        | Solid
        | Double
        | Dotted
        | Dashed
        | Wavy
        interface ITextDecorationStyle

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    type DecorationSkip =
        | Objects
        | Spaces
        | LeadingSpaces
        | TrailingSpaces
        | Edges
        | BoxDecoration
        interface ITextDecorationSkip

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    type DecorationSkipInk =
        | All
        interface ITextDecorationSkipInk

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    type Transform =
        | Capitalize
        | Uppercase
        | Lowercase
        | FullWidth
        | FullSizeKana
        interface ITextTransform

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    type Indent =
        | Hanging
        | EachLine
        interface ITextIndent

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
    // https://css-tricks.com/almanac/properties/t/text-shadow/
    open Color
    type Shadow =
        | Shadow of Size * Size * Size * CssColor
        interface ITextShadow

    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow
    type Overflow =
        | Clip
        | Ellipsis
        | String of string
                
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-position
    type Position =
        | Over
        | Under
        | Right
        | Left
    
    type EmphasisPosition =
        | EmphasisPosition of Position * Position
        interface ITextEmphasisPosition
        
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-style
    type Keyword =
        | Filled
        | Open
        | Dot
        | Circle
        | DoubleCircle
        | Triangle
        | FilledSesame
        | OpenSesame
    type EmphasisStyle =
        | StringValue of string
        | KeywordValue of Keyword
        interface ITextEmphasisStyle
        
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-offset
    type UnderlinePosition =
        | FromFont
        | Under
        | Left
        | Right
        | AutoPos
        | Above
        | Below
        interface ITextUnderlinePosition
                      
module TextValue =
    open Text

    let align (v: ITextAlign): string =
        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? Align as t -> duToKebab t
            | _                 -> "Unknown text align"

    let decorationLine (v: ITextDecorationLine): string =
        match v with
            | :? Global             as g -> GlobalValue.globalValue g
            | :? None               as n -> GlobalValue.none n
            | :? DecorationLine as t -> duToKebab t
            | _                          -> "unknown text decoration line"

    let decorationThickness (v: ITextDecorationThickness): string =
        match v with
            | :? Global                  as g -> GlobalValue.globalValue g
            | :? Auto                    as a -> GlobalValue.auto a
            | :? Percent                 as p -> Units.Percent.value p
            | :? Size                    as s -> Units.Size.value s
            | :? DecorationThickness     as t -> duToKebab t
            | _                               -> "unkown text decoration thickness"

    let decorationStyle (v: ITextDecorationStyle): string =
        match v with
            | :? Global              as g -> GlobalValue.globalValue g
            | :? DecorationStyle as t -> duToLowercase t
            | _                           -> "unknown text decoration style"

    let decorationSkip (v: ITextDecorationSkip): string =
        match v with
            | :? Global             as g -> GlobalValue.globalValue g
            | :? None               as n -> GlobalValue.none n
            | :? DecorationSkip as t -> duToKebab t
            | _                             -> "unknown text decoration skip ink"

    let decorationSkipInk (v: ITextDecorationSkipInk): string =
        match v with
            | :? Global                as g -> GlobalValue.globalValue g
            | :? Auto                  as a -> GlobalValue.auto a
            | :? None                  as n -> GlobalValue.none n
            | :? DecorationSkipInk     as t -> duToLowercase t
            | _                             -> "unknown text decoration skip ink"

    let transform (v: ITextTransform): string =
        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? None          as n -> GlobalValue.none n
            | :? Transform as t -> duToLowercase t
            | _                     -> "unknown text transform"

    let indent (v: ITextIndent): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Percent    as p -> Units.Percent.value p
            | :? Size       as s -> Units.Size.value s
            | :? Indent as t -> duToKebab t
            | _                  -> "unknown text transform"

    let shadow (v: ITextShadow): string =
        let getValue (Shadow(s1, s2, s3, c)) = s1, s2, s3, c
        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? Shadow as t ->
                let (s1, s2, s3, c) = getValue t
                sprintf "%s %s %s %s" (Units.Size.value s1) (Units.Size.value s2) (Units.Size.value s3) (Color.value c)
            | _                      -> "Unknown text shadow"

    let overflow (v: Overflow): string =
        match v with
            | String s -> sprintf "\"%s\"" s
            | _        -> duToLowercase v
    let emphasisColor (v: ITextEmphasisColor): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? CssColor as c -> Color.value c
            | _ -> "Unkown text emphasis color"
            
    let emphasisPosition (v: ITextEmphasisPosition): string =
        let stringifyTextEmphasisPosition (EmphasisPosition (p1, p2)): string =
            sprintf "%s %s" (duToLowercase p1) (duToLowercase p2)
        
        match v with
            | :? Global           as g -> GlobalValue.globalValue g
            | :? EmphasisPosition as t -> stringifyTextEmphasisPosition t
            | _                 -> "Unknown text emphasis position"
            
    let keyword (v: Keyword): string =
        match v with
            | FilledSesame -> duToSpaced v
            | OpenSesame -> duToSpaced v
            | _ -> duToKebab v
            
    let emphasisStyle (v: ITextEmphasisStyle): string =
        let stringifyTextEmphasisStyle (s: EmphasisStyle): string =
            match s with
                | StringValue s -> sprintf "'%s'" s
                | KeywordValue k -> keyword k
        
        match v with
            | :? Global            as g -> GlobalValue.globalValue g
            | :? None              as g -> GlobalValue.none g
            | :? EmphasisStyle as t -> stringifyTextEmphasisStyle t
            | _ -> "Unknown text emphasis style"
            
    let underlineOffset (v: ITextUnderlineOffset): string =
        match v with
            | :? Global  as g -> GlobalValue.globalValue g
            | :? Auto    as a -> GlobalValue.auto a
            | :? Percent as p -> Units.Percent.value p
            | :? Size    as s -> Units.Size.value s
            | _ -> "Unknown text underline offset"
            
    let underlinePosition (v: ITextUnderlinePosition): string =
        match v with
            | :? Global             as g -> GlobalValue.globalValue g
            | :? Auto               as n -> GlobalValue.auto n
            | :? UnderlinePosition  as p -> duToKebab p
            | _                          -> "unknown text underline position"