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
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type AlignLast =
        | Start
        | End
        | Left
        | Right
        | Center
        | Justify
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type DecorationLine =
        | Overline
        | Underline
        | LineThrough
        | Blink
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type DecorationThickness =
        | FromFont
        interface ICssValue with
            member this.Stringify() = "from-font"

    type DecorationStyle =
        | Solid
        | Double
        | Dotted
        | Dashed
        | Wavy
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type DecorationSkip =
        | Objects
        | Spaces
        | Edges
        | BoxDecoration
        | LeadingSpaces
        | TrailingSpaces
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type DecorationSkipInk =
        | All
        interface ICssValue with
            member this.Stringify() = "all"

    type Transform =
        | Capitalize
        | Uppercase
        | Lowercase
        | FullWidth
        | FullSizeKana
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Indent =
        | Hanging
        | EachLine
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Overflow =
        | Clip
        | Ellipsis
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type EmphasisPosition =
        | Over
        | Under
        | Right
        | Left
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type EmphasisStyle =
        | Filled
        | Open
        | Dot
        | Circle
        | DoubleCircle
        | Triangle
        | FilledSesame
        | OpenSesame
        interface ICssValue with
            member this.Stringify() =
                match this with
                | FilledSesame -> "filled sesame"
                | OpenSesame -> "open sesame"
                | _ -> Fss.Utilities.Helpers.toKebabCase this

    type UnderlinePosition =
        | FromFont
        | Under
        | Left
        | Right
        | AutoPos
        | Above
        | Below
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type EmphasisColor =
        | TextEmphasisColor of Color.Color
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Hyphens =
        | Manual
        interface ICssValue with
            member this.Stringify() = "manual"

    type Orientation =
        | Mixed
        | Upright
        | SidewaysRight
        | Sideways
        | UseGlyphOrientation
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Rendering =
        | OptimizeSpeed
        | OptimizeLegibility
        | GeometricPrecision
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Justify =
        | InterWord
        | InterCharacter
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type WhiteSpace =
        | Nowrap
        | Pre
        | PreWrap
        | PreLine
        | BreakSpaces
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type UserSelect =
        | Text
        | Contain
        | All
        | Element
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type HangingPunctuation =
        | First
        | Last
        | ForceEnd
        | AllowEnd
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module TextClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align-last
        type TextAlign(property) =
            inherit CssRule(property)
            member this.left = (property, Align.Left) |> Rule
            member this.right = (property, Align.Right) |> Rule
            member this.center = (property, Align.Center) |> Rule
            member this.justify = (property, Align.Justify) |> Rule
            member this.justifyAll = (property, Align.JustifyAll) |> Rule
            member this.start = (property, Align.Start) |> Rule
            member this.end' = (property, Align.End) |> Rule
            member this.matchParent = (property, Align.MatchParent) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration
        type TextDecoration(property) =
            inherit CssRuleWithNone(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
        type TextDecorationLine(property) =
            inherit CssRuleWithNone(property)

            member this.value(decorations: DecorationLine list) =
                let decorations =
                    List.map stringifyICssValue decorations
                    |> String.concat " "
                (property, String decorations) |> Rule

            member this.overline = (property, Overline) |> Rule
            member this.underline = (property, Underline) |> Rule
            member this.lineThrough = (property, LineThrough) |> Rule
            member this.blink = (property, Blink) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
        type TextDecorationSkip(property) =
            inherit CssRuleWithNone(property)
            member this.value(decorations: DecorationSkip list) =
                let decorations =
                    List.map stringifyICssValue decorations
                    |> String.concat " "
                (property, String decorations) |> Rule
            member this.objects = (property, Objects) |> Rule
            member this.spaces = (property, Spaces) |> Rule
            member this.edges = (property, Edges) |> Rule
            member this.boxDecoration = (property, BoxDecoration) |> Rule
            member this.leadingSpaces = (property, LeadingSpaces) |> Rule
            member this.trailingSpaces = (property, TrailingSpaces) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
        type TextDecorationThickness(property) =
            inherit CssRuleWithAutoLength(property)

            member this.fromFont =
                (property, DecorationThickness.FromFont) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
        type TextDecorationStyle(property) =
            inherit CssRule(property)
            member this.solid = (property, Solid) |> Rule
            member this.double = (property, Double) |> Rule
            member this.dotted = (property, Dotted) |> Rule
            member this.dashed = (property, Dashed) |> Rule
            member this.wavy = (property, Wavy) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
        type TextDecorationSkipInk(property) =
            inherit CssRuleWithAutoNone(property)

            member this.all =
                (property, DecorationSkipInk.All) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
        type TextTransform(property) =
            inherit CssRuleWithNone(property)
            member this.capitalize = (property, Capitalize) |> Rule
            member this.uppercase = (property, Uppercase) |> Rule
            member this.lowercase = (property, Lowercase) |> Rule
            member this.fullWidth = (property, FullWidth) |> Rule
            member this.fullSizeKana = (property, FullSizeKana) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
        type TextIndent(property) =
            inherit CssRuleWithLength(property)

            member this.hanging(value: ILengthPercentage) =
                let value = $"{lengthPercentageString value} {stringifyICssValue Indent.Hanging}"
                (property, String value) |> Rule

            member this.eachLine(value: ILengthPercentage) =
                let value = $"{lengthPercentageString value} {stringifyICssValue Indent.EachLine}"
                (property, String value) |> Rule

            member this.hangingEachLine(value: ILengthPercentage) =
                let value = $"{lengthPercentageString value} {stringifyICssValue Indent.Hanging} {stringifyICssValue Indent.EachLine}"
                (property, String value) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
        // https://css-tricks.com/almanac/properties/t/text-shadow/
        type TextShadow(property) =
            inherit CssRule(property)
            let stringify (x, y, blur, color) =
                $"{stringifyICssValue x} {stringifyICssValue y} {stringifyICssValue blur} {stringifyICssValue color}"

            member this.value(xOffset: Length, yOffset: Length, blurRadius: Length, color: Color) =
                let value = stringify (xOffset, yOffset, blurRadius, color)
                (property, value |> String) |> Rule

            member this.value(shadows: (Length * Length * Length * Color) list) =
                let value =
                    shadows
                    |> List.map stringify
                    |> String.concat ", "
                (property, value |> String) |> Rule
            
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow
        type TextOverflow(property) =
            inherit CssRule(property)
            member this.clip = (property, Clip) |> Rule
            member this.ellipsis = (property, Ellipsis) |> Rule
            member this.value(overflow: string) = (property, Stringed overflow) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis
        type TextEmphasis(property) =
            inherit CssRuleWithNone(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-position
        type TextEmphasisPosition(property) =
            inherit CssRule(property)

            member this.value(x: EmphasisPosition, y: EmphasisPosition) =
                let value =
                    $"{stringifyICssValue x} {stringifyICssValue y}"
                    |> String
                (property, value) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-style
        type TextEmphasisStyle(property) =
            inherit CssRule(property)
            member this.value(style: string) = (property, Char style) |> Rule
            member this.filled = (property, Filled) |> Rule
            member this.open' = (property, Open) |> Rule
            member this.dot = (property, Dot) |> Rule
            member this.circle = (property, Circle) |> Rule
            member this.doubleCircle = (property, DoubleCircle) |> Rule
            member this.triangle = (property, Triangle) |> Rule
            member this.filledSesame = (property, FilledSesame) |> Rule
            member this.openSesame = (property, OpenSesame) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-position
        type TextUnderlinePosition(property) =
            inherit CssRuleWithAuto(property)

            member this.value(x: UnderlinePosition, y: UnderlinePosition) =
                let value =
                    $"{stringifyICssValue x} {stringifyICssValue y}"
                    |> String
                (property, value) |> Rule

            member this.fromFont = (property, FromFont) |> Rule
            member this.under = (property, Under) |> Rule
            member this.left = (property, Left) |> Rule
            member this.right = (property, Right) |> Rule
            member this.autoPos = (property, AutoPos) |> Rule
            member this.above = (property, Above) |> Rule
            member this.below = (property, Below) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-offset
        type TextUnderlineOffset(property) =
            inherit CssRuleWithAutoLength(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/quotes
        type Quotes(property) =
            inherit CssRuleWithAutoNone(property)

            member this.value(quotes: string list) =
                let quotes =
                    quotes
                    |> List.map (fun x -> $"\"{x}\"")
                    |> String.concat " "
                    
                (property, String quotes)
                |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/hyphens
        type Hyphens(property) =
            inherit CssRuleWithAutoNone(property)
            member this.manual = (property, Manual) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-color
        type TextDecorationColor(property) =
            inherit ColorClass.Color(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-color
        type TextEmphasisColor(property) =
            inherit ColorClass.Color(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-size-adjust
        type TextSizeAdjust(property) =
            inherit CssRuleWithAutoLengthNone(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/tab-size
        type TabSize(property) =
            inherit CssRuleWithLength(property)
            member this.value(size: int) = (property, Int size) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-orientation
        type TextOrientation(property) =
            inherit CssRule(property)
            member this.value(size: int) = (property, Int size) |> Rule
            member this.mixed = (property, Mixed) |> Rule
            member this.upright = (property, Upright) |> Rule
            member this.sidewaysRight = (property, SidewaysRight) |> Rule
            member this.sideways = (property, Sideways) |> Rule
            member this.useGlyphOrientation = (property, UseGlyphOrientation) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-rendering
        type TextRendering(property) =
            inherit CssRuleWithAuto(property)
            member this.optimizeSpeed = (property, OptimizeSpeed) |> Rule
            member this.optimizeLegibility = (property, OptimizeLegibility) |> Rule
            member this.geometricPrecision = (property, GeometricPrecision) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/text-justify
        type TextJustify(property) =
            inherit CssRuleWithAutoNone(property)
            member this.interWord = (property, InterWord) |> Rule
            member this.interCharacter = (property, InterCharacter) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/white-space
        type WhiteSpace(property) =
            inherit CssRuleWithNormal(property)
            member this.nowrap = (property, Nowrap) |> Rule
            member this.pre = (property, Pre) |> Rule
            member this.preWrap = (property, PreWrap) |> Rule
            member this.preLine = (property, PreLine) |> Rule
            member this.breakSpaces = (property, BreakSpaces) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/user-select
        type UserSelect(property) =
            inherit CssRuleWithAutoNone(property)
            member this.text = (property, Text) |> Rule
            member this.contain = (property, Contain) |> Rule
            member this.all = (property, All) |> Rule
            member this.element = (property, Element) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/hanging-punctuation
        type HangingPunctuationClass(property) =
            inherit CssRuleWithNone(property)

            member this.value(punctuations: HangingPunctuation list) =
                let punctuations =
                    punctuations
                    |> List.map stringifyICssValue
                    |> String.concat " "
                (property, String punctuations) |> Rule

            member this.first = (property, First) |> Rule
            member this.last = (property, Last) |> Rule
            member this.forceEnd = (property, ForceEnd) |> Rule
            member this.allowEnd = (property, AllowEnd) |> Rule
