namespace Fss

namespace Fss.FssTypes
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
            | ColorXY of ColorType * Size * Size
            | ColorXYBlur of ColorType * Size * Size * Size

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
            | TextEmphasisColor of Color.ColorType
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

        type HangingPunctuation =
            | First
            | Last
            | ForceEnd
            | AllowEnd
            interface IHangingPunctuation

    type TextDecorationColor (valueFunction: ITextDecorationColor -> CssProperty) =
        inherit ColorBase<CssProperty>(valueFunction)
        member this.value color = color |> valueFunction
        member this.inherit' = Inherit |> valueFunction
        member this.initial = Initial |> valueFunction
        member this.unset = Unset |> valueFunction

    type TextEmphasisColor (valueFunction: ITextEmphasisColor -> CssProperty) =
        inherit ColorBase<CssProperty>(valueFunction)
        member this.value color = color |> valueFunction
        member this.inherit' = Inherit |> valueFunction
        member this.initial = Initial |> valueFunction
        member this.unset = Unset |> valueFunction

