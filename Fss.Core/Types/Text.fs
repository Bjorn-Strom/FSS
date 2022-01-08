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
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type AlignLast =
        | Start
        | End
        | Left
        | Right
        | Center
        | Justify
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type DecorationLine =
        | Overline
        | Underline
        | LineThrough
        | Blink
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type DecorationThickness =
        | FromFont
        interface ICssValue with
            member this.StringifyCss() = "from-font"

    type DecorationStyle =
        | Solid
        | Double
        | Dotted
        | Dashed
        | Wavy
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type DecorationSkip =
        | Objects
        | Spaces
        | Edges
        | BoxDecoration
        | LeadingSpaces
        | TrailingSpaces
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type DecorationSkipInk =
        | All
        interface ICssValue with
            member this.StringifyCss() = "all"

    type Transform =
        | Capitalize
        | Uppercase
        | Lowercase
        | FullWidth
        | FullSizeKana
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Indent =
        | Hanging
        | EachLine
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Overflow =
        | Clip
        | Ellipsis
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type EmphasisPosition =
        | Over
        | Under
        | Right
        | Left
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

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
            member this.StringifyCss() =
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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type EmphasisColor =
        | TextEmphasisColor of Color.Color
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Hyphens =
        | Manual
        interface ICssValue with
            member this.StringifyCss() = "manual"

    type Orientation =
        | Mixed
        | Upright
        | SidewaysRight
        | Sideways
        | UseGlyphOrientation
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Rendering =
        | OptimizeSpeed
        | OptimizeLegibility
        | GeometricPrecision
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Justify =
        | InterWord
        | InterCharacter
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type WhiteSpace =
        | Nowrap
        | Pre
        | PreWrap
        | PreLine
        | BreakSpaces
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type UserSelect =
        | Text
        | Contain
        | All
        | Element
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type HangingPunctuation =
        | First
        | Last
        | ForceEnd
        | AllowEnd
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module TextClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-align-last
    type TextAlign(property) =
        inherit CssRule(property)
        member this.left = (property, Text.Align.Left) |> Rule
        member this.right = (property, Text.Align.Right) |> Rule
        member this.center = (property, Text.Align.Center) |> Rule
        member this.justify = (property, Text.Align.Justify) |> Rule
        member this.justifyAll = (property, Text.Align.JustifyAll) |> Rule
        member this.start = (property, Text.Align.Start) |> Rule
        member this.end' = (property, Text.Align.End) |> Rule
        member this.matchParent = (property, Text.Align.MatchParent) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration
    type TextDecoration(property) =
        inherit CssRuleWithNone(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
    type TextDecorationLine(property) =
        inherit CssRuleWithNone(property)

        member this.value(decorations: Text.DecorationLine list) =
            let decorations =
                List.map stringifyICssValue decorations
                |> String.concat " "
            (property, String decorations) |> Rule

        member this.overline = (property, Text.Overline) |> Rule
        member this.underline = (property, Text.Underline) |> Rule
        member this.lineThrough = (property, Text.LineThrough) |> Rule
        member this.blink = (property, Text.Blink) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    type TextDecorationSkip(property) =
        inherit CssRuleWithNone(property)
        member this.value(decorations: Text.DecorationSkip list) =
            let decorations =
                List.map stringifyICssValue decorations
                |> String.concat " "
            (property, String decorations) |> Rule
        member this.objects = (property, Text.Objects) |> Rule
        member this.spaces = (property, Text.Spaces) |> Rule
        member this.edges = (property, Text.Edges) |> Rule
        member this.boxDecoration = (property, Text.BoxDecoration) |> Rule
        member this.leadingSpaces = (property, Text.LeadingSpaces) |> Rule
        member this.trailingSpaces = (property, Text.TrailingSpaces) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    type TextDecorationThickness(property) =
        inherit CssRuleWithAutoLength(property)

        member this.fromFont =
            (property, Text.DecorationThickness.FromFont) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    type TextDecorationStyle(property) =
        inherit CssRule(property)
        member this.solid = (property, Text.Solid) |> Rule
        member this.double = (property, Text.Double) |> Rule
        member this.dotted = (property, Text.Dotted) |> Rule
        member this.dashed = (property, Text.Dashed) |> Rule
        member this.wavy = (property, Text.Wavy) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    type TextDecorationSkipInk(property) =
        inherit CssRuleWithAutoNone(property)

        member this.all =
            (property, Text.DecorationSkipInk.All) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    type TextTransform(property) =
        inherit CssRuleWithNone(property)
        member this.capitalize = (property, Text.Capitalize) |> Rule
        member this.uppercase = (property, Text.Uppercase) |> Rule
        member this.lowercase = (property, Text.Lowercase) |> Rule
        member this.fullWidth = (property, Text.FullWidth) |> Rule
        member this.fullSizeKana = (property, Text.FullSizeKana) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    type TextIndent(property) =
        inherit CssRuleWithLength(property)

        member this.hanging(value: ILengthPercentage) =
            let value = $"{lengthPercentageString value} {stringifyICssValue Text.Indent.Hanging}"
            (property, String value) |> Rule

        member this.eachLine(value: ILengthPercentage) =
            let value = $"{lengthPercentageString value} {stringifyICssValue Text.Indent.EachLine}"
            (property, String value) |> Rule

        member this.hangingEachLine(value: ILengthPercentage) =
            let value = $"{lengthPercentageString value} {stringifyICssValue Text.Indent.Hanging} {stringifyICssValue Text.Indent.EachLine}"
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
        member this.clip = (property, Text.Clip) |> Rule
        member this.ellipsis = (property, Text.Ellipsis) |> Rule
        member this.value(overflow: string) = (property, Stringed overflow) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis
    type TextEmphasis(property) =
        inherit CssRuleWithNone(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-position
    type TextEmphasisPosition(property) =
        inherit CssRule(property)

        member this.value(x: Text.EmphasisPosition, y: Text.EmphasisPosition) =
            let value =
                $"{stringifyICssValue x} {stringifyICssValue y}"
                |> String
            (property, value) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-emphasis-style
    type TextEmphasisStyle(property) =
        inherit CssRule(property)
        member this.value(style: string) = (property, Char style) |> Rule
        member this.filled = (property, Text.Filled) |> Rule
        member this.open' = (property, Text.Open) |> Rule
        member this.dot = (property, Text.Dot) |> Rule
        member this.circle = (property, Text.Circle) |> Rule
        member this.doubleCircle = (property, Text.DoubleCircle) |> Rule
        member this.triangle = (property, Text.Triangle) |> Rule
        member this.filledSesame = (property, Text.FilledSesame) |> Rule
        member this.openSesame = (property, Text.OpenSesame) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-position
    type TextUnderlinePosition(property) =
        inherit CssRuleWithAuto(property)

        member this.value(x: Text.UnderlinePosition, y: Text.UnderlinePosition) =
            let value =
                $"{stringifyICssValue x} {stringifyICssValue y}"
                |> String
            (property, value) |> Rule

        member this.fromFont = (property, Text.FromFont) |> Rule
        member this.under = (property, Text.Under) |> Rule
        member this.left = (property, Text.Left) |> Rule
        member this.right = (property, Text.Right) |> Rule
        member this.autoPos = (property, Text.AutoPos) |> Rule
        member this.above = (property, Text.Above) |> Rule
        member this.below = (property, Text.Below) |> Rule
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
        member this.manual = (property, Text.Manual) |> Rule
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
        member this.mixed = (property, Text.Mixed) |> Rule
        member this.upright = (property, Text.Upright) |> Rule
        member this.sidewaysRight = (property, Text.SidewaysRight) |> Rule
        member this.sideways = (property, Text.Sideways) |> Rule
        member this.useGlyphOrientation = (property, Text.UseGlyphOrientation) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-rendering
    type TextRendering(property) =
        inherit CssRuleWithAuto(property)
        member this.optimizeSpeed = (property, Text.OptimizeSpeed) |> Rule
        member this.optimizeLegibility = (property, Text.OptimizeLegibility) |> Rule
        member this.geometricPrecision = (property, Text.GeometricPrecision) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-justify
    type TextJustify(property) =
        inherit CssRuleWithAutoNone(property)
        member this.interWord = (property, Text.InterWord) |> Rule
        member this.interCharacter = (property, Text.InterCharacter) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/white-space
    type WhiteSpace(property) =
        inherit CssRuleWithNormal(property)
        member this.nowrap = (property, Text.Nowrap) |> Rule
        member this.pre = (property, Text.Pre) |> Rule
        member this.preWrap = (property, Text.PreWrap) |> Rule
        member this.preLine = (property, Text.PreLine) |> Rule
        member this.breakSpaces = (property, Text.BreakSpaces) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/user-select
    type UserSelect(property) =
        inherit CssRuleWithAutoNone(property)
        member this.text = (property, Text.Text) |> Rule
        member this.contain = (property, Text.Contain) |> Rule
        member this.all = (property, Text.All) |> Rule
        member this.element = (property, Text.Element) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/hanging-punctuation
    type HangingPunctuationClass(property) =
        inherit CssRuleWithNone(property)

        member this.value(punctuations: Text.HangingPunctuation list) =
            let punctuations =
                punctuations
                |> List.map stringifyICssValue
                |> String.concat " "
            (property, String punctuations) |> Rule

        member this.first = (property, Text.First) |> Rule
        member this.last = (property, Text.Last) |> Rule
        member this.forceEnd = (property, Text.ForceEnd) |> Rule
        member this.allowEnd = (property, Text.AllowEnd) |> Rule
