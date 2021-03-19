namespace FssTypes

[<RequireQualifiedAccess>]
module Text =
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

    type TextAlignLast =
        | Start
        | End
        | Left
        | Right
        | Center
        | Justify
        interface ITextAlignLast

    type TextDecorationLine =
        | Overline
        | Underline
        | LineThrough
        | Blink
        interface ITextDecorationLine

    type TextDecorationThickness =
        | TextDecorationThickness
        interface ITextDecorationThickness

    type TextDecorationStyle =
        | Solid
        | Double
        | Dotted
        | Dashed
        | Wavy
        interface ITextDecorationStyle

    type DecorationSkip =
        | Objects
        | Spaces
        | Edges
        | BoxDecoration
        | LeadingSpaces
        | TrailingSpaces
        interface ITextDecorationSkip

    type TextDecorationSkipInk =
        | TextDecorationSkipInk
        interface ITextDecorationSkipInk

    type TextTransform =
        | Capitalize
        | Uppercase
        | Lowercase
        | FullWidth
        | FullSizeKana
        interface ITextTransform

    type TextIndent =
        | Hanging
        | EachLine
        interface ITextIndent

    type TextShadow =
        | XY of Units.Size.Size * Units.Size.Size
        | ColorXY of CssColor * Units.Size.Size * Units.Size.Size
        | ColorXYBlur of CssColor * Units.Size.Size * Units.Size.Size * Units.Size.Size

    type TextOverflow =
        | Clip
        | Ellipsis
        interface ITextOverflow

    type EmphasisPosition =
        | Over
        | Under
        | Right
        | Left
        interface ITextEmphasisPosition

    type TextEmphasisStyle =
        | Filled
        | Open
        | Dot
        | Circle
        | DoubleCircle
        | Triangle
        | FilledSesame
        | OpenSesame
        interface ITextEmphasisStyle

    type UnderlinePosition =
        | FromFont
        | Under
        | Left
        | Right
        | AutoPos
        | Above
        | Below
        interface ITextUnderlinePosition

    type TextEmphasisColor =
        | TextEmphasisColor of CssColor
        interface ITextEmphasisColor

    type Hyphens =
        | Manual
        interface IHyphens

    type TextOrientation =
        | Mixed
        | Upright
        | SidewaysRight
        | Sideways
        | UseGlyphOrientation
        interface ITextOrientation

    type TextRendering =
        | OptimizeSpeed
        | OptimizeLegibility
        | GeometricPrecision
        interface ITextRendering

    type TextJustify =
        | InterWord
        | InterCharacter
        interface ITextJustify

    type WhiteSpace =
        | NoWrap
        | Pre
        | PreWrap
        | PreLine
        | BreakSpaces
        interface IWhiteSpace

    type UserSelect =
        | Text
        | Contain
        | All
        | Element
        interface IUserSelect
