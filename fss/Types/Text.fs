namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type TextAlign =
        | Left
        | Right
        | Center
        | Justify
        | JustifyAll
        | Start
        | End
        | MatchParent
        interface Types.ITextAlign

    type TextAlignLast =
        | Start
        | End
        | Left
        | Right
        | Center
        | Justify
        interface Types.ITextAlignLast

    type TextDecorationLine =
        | Overline
        | Underline
        | LineThrough
        | Blink
        interface Types.ITextDecorationLine

    type TextDecorationThickness =
        | TextDecorationThickness
        interface Types.ITextDecorationThickness

    type TextDecorationStyle =
        | Solid
        | Double
        | Dotted
        | Dashed
        | Wavy
        interface Types.ITextDecorationStyle

    type DecorationSkip =
        | Objects
        | Spaces
        | Edges
        | BoxDecoration
        | LeadingSpaces
        | TrailingSpaces
        interface Types.ITextDecorationSkip

    type TextDecorationSkipInk =
        | TextDecorationSkipInk
        interface Types.ITextDecorationSkipInk

    type TextTransform =
        | Capitalize
        | Uppercase
        | Lowercase
        | FullWidth
        | FullSizeKana
        interface Types.ITextTransform

    type TextIndent =
        | Hanging
        | EachLine
        interface Types.ITextIndent

    type TextShadow =
        | XY of Types.Size * Types.Size
        | ColorXY of Types.Color * Types.Size * Types.Size
        | ColorXYBlur of Types.Color * Types.Size * Types.Size * Types.Size

    type TextOverflow =
        | Clip
        | Ellipsis
        interface Types.ITextOverflow

    type EmphasisPosition =
        | Over
        | Under
        | Right
        | Left
        interface Types.ITextEmphasisPosition

    type TextEmphasisStyle =
        | Filled
        | Open
        | Dot
        | Circle
        | DoubleCircle
        | Triangle
        | FilledSesame
        | OpenSesame
        interface Types.ITextEmphasisStyle

    type UnderlinePosition =
        | FromFont
        | Under
        | Left
        | Right
        | AutoPos
        | Above
        | Below
        interface Types.ITextUnderlinePosition

    type TextEmphasisColor =
        | TextEmphasisColor of Types.Color
        interface Types.ITextEmphasisColor

    type Hyphens =
        | Manual
        interface Types.IHyphens

    type TextOrientation =
        | Mixed
        | Upright
        | SidewaysRight
        | Sideways
        | UseGlyphOrientation
        interface Types.ITextOrientation

    type TextRendering =
        | OptimizeSpeed
        | OptimizeLegibility
        | GeometricPrecision
        interface Types.ITextRendering

    type TextJustify =
        | InterWord
        | InterCharacter
        interface Types.ITextJustify

    type WhiteSpace =
        | NoWrap
        | Pre
        | PreWrap
        | PreLine
        | BreakSpaces
        interface Types.IWhiteSpace

    type UserSelect =
        | Text
        | Contain
        | All
        | Element
        interface Types.IUserSelect
