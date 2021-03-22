namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Text =
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

        type AlignLast =
            | Start
            | End
            | Left
            | Right
            | Center
            | Justify
            interface ITextAlignLast

        type DecorationLine =
            | Overline
            | Underline
            | LineThrough
            | Blink
            interface ITextDecorationLine

        type DecorationThickness =
            | DecorationThickness
            interface ITextDecorationThickness

        type DecorationStyle =
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

        type DecorationSkipInk =
            | DecorationSkipInk
            interface ITextDecorationSkipInk

        type Transform =
            | Capitalize
            | Uppercase
            | Lowercase
            | FullWidth
            | FullSizeKana
            interface ITextTransform

        type Indent =
            | Hanging
            | EachLine
            interface ITextIndent

        type Shadow =
            | XY of Size * Size
            | ColorXY of ColorTypeFoo * Size * Size
            | ColorXYBlur of ColorTypeFoo * Size * Size * Size

        type Overflow =
            | Clip
            | Ellipsis
            interface ITextOverflow

        type EmphasisPosition =
            | Over
            | Under
            | Right
            | Left
            interface ITextEmphasisPosition

        type EmphasisStyle =
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

        type EmphasisColor =
            | TextEmphasisColor of Color
            interface ITextEmphasisColor

        type Hyphens =
            | Manual
            interface IHyphens

        type Orientation =
            | Mixed
            | Upright
            | SidewaysRight
            | Sideways
            | UseGlyphOrientation
            interface ITextOrientation

        type Rendering =
            | OptimizeSpeed
            | OptimizeLegibility
            | GeometricPrecision
            interface ITextRendering

        type Justify =
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
