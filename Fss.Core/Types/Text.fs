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
        /// Aligns along the left side. This is the default value
        member this.left = (property, Text.Align.Left) |> Rule
        /// Aligns along the right side
        member this.right = (property, Text.Align.Right) |> Rule
        /// Aligns in the center
        member this.center = (property, Text.Align.Center) |> Rule
        /// First word will be along the left edge
        /// Last word will be along the right edge
        /// All other words spaced evenly between the two
        member this.justify = (property, Text.Align.Justify) |> Rule
        /// First word will be along the left edge
        /// All other words spaced evenly toward the right edge
        member this.justifyAll = (property, Text.Align.JustifyAll) |> Rule
        /// Aligns at the start of the current direction.
        /// If direction is left to right it aligns left
        /// If direction is right left it aligns right
        member this.start = (property, Text.Align.Start) |> Rule
        /// Aligns at the end of the current direction.
        /// If direction is left to right it aligns right
        /// If direction is right left it aligns left
        member this.end' = (property, Text.Align.End) |> Rule
        /// Start and end values calculated according to the parents direction
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

        /// Each line of text has a decorative line above it
        member this.overline = (property, Text.Overline) |> Rule
        /// Each line of text has a decorative line under it
        member this.underline = (property, Text.Underline) |> Rule
        /// Each line of text has a decorative line going through it
        member this.lineThrough = (property, Text.LineThrough) |> Rule
        /// The text blinks (alternates between visible and invisible). Is deprecated.
        member this.blink = (property, Text.Blink) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip
    type TextDecorationSkip(property) =
        inherit CssRuleWithNone(property)
        member this.value(decorations: Text.DecorationSkip list) =
            let decorations =
                List.map stringifyICssValue decorations
                |> String.concat " "
            (property, String decorations) |> Rule
        /// Skips inline objects
        member this.objects = (property, Text.Objects) |> Rule
        /// Skips spaces and anything set with letter-spacing ot word-spacing
        member this.spaces = (property, Text.Spaces) |> Rule
        /// Decoration line starts slightly after the starting edge and ends before the ending edge
        member this.edges = (property, Text.Edges) |> Rule
        /// Skips inherited margin, padding and border
        member this.boxDecoration = (property, Text.BoxDecoration) |> Rule
        /// Skips leading spaces
        member this.leadingSpaces = (property, Text.LeadingSpaces) |> Rule
        /// Skips trailing spaces
        member this.trailingSpaces = (property, Text.TrailingSpaces) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
    type TextDecorationThickness(property) =
        inherit CssRuleWithAutoLength(property)

        member this.fromFont =
            (property, Text.DecorationThickness.FromFont) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-style
    type TextDecorationStyle(property) =
        inherit CssRule(property)
        /// Draws a single line
        member this.solid = (property, Text.Solid) |> Rule
        /// Draws a double line
        member this.double = (property, Text.Double) |> Rule
        /// Draws a dotted line
        member this.dotted = (property, Text.Dotted) |> Rule
        /// Draws a dashed line
        member this.dashed = (property, Text.Dashed) |> Rule
        /// Draws a wavy line
        member this.wavy = (property, Text.Wavy) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-skip-ink
    type TextDecorationSkipInk(property) =
        inherit CssRuleWithAutoNone(property)

        member this.all =
            (property, Text.DecorationSkipInk.All) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    type TextTransform(property) =
        inherit CssRuleWithNone(property)
        /// Converts the first letter of each word to upper case
        member this.capitalize = (property, Text.Capitalize) |> Rule
        /// Converts all characters to upper case
        member this.uppercase = (property, Text.Uppercase) |> Rule
        /// Converts all characters to lower case
        member this.lowercase = (property, Text.Lowercase) |> Rule
        /// Forces the character inside a square, allowing them to be aligned in east asian scripts
        member this.fullWidth = (property, Text.FullWidth) |> Rule
        /// Converts small Kana characters to full size Kana characters
        member this.fullSizeKana = (property, Text.FullSizeKana) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    type TextIndent(property) =
        inherit CssRuleWithLength(property)
        /// Inverts which lines are indented. All lines apart from first gets indent
        member this.hanging(value: ILengthPercentage) =
            let value = $"{lengthPercentageString value} {stringifyICssValue Text.Indent.Hanging}"
            (property, String value) |> Rule

        /// Indents each line after a forced line break (<br>)
        member this.eachLine(value: ILengthPercentage) =
            let value = $"{lengthPercentageString value} {stringifyICssValue Text.Indent.EachLine}"
            (property, String value) |> Rule
        
        /// Inverts which lines are indented. All lines apart from first gets indent
        /// Indents each line after a forced line break (<br>)
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
        /// Truncates any overflow. This is the default property,
        member this.clip = (property, Text.Clip) |> Rule
        /// Will display ellipsis '...' in case of overflow
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
        /// Shapes are filled with a solid color
        member this.filled = (property, Text.Filled) |> Rule
        /// The shapes are hollow
        member this.open' = (property, Text.Open) |> Rule
        /// The shapes are small circles
        member this.dot = (property, Text.Dot) |> Rule
        /// The shapes are large circles
        member this.circle = (property, Text.Circle) |> Rule
        /// The shapes are double circles
        member this.doubleCircle = (property, Text.DoubleCircle) |> Rule
        /// THe shapes are triangles
        member this.triangle = (property, Text.Triangle) |> Rule
        /// The shapes are filled sesames
        member this.filledSesame = (property, Text.FilledSesame) |> Rule
        /// The shapes are open sesames
        member this.openSesame = (property, Text.OpenSesame) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-underline-position
    type TextUnderlinePosition(property) =
        inherit CssRuleWithAuto(property)

        member this.value(x: Text.UnderlinePosition, y: Text.UnderlinePosition) =
            let value =
                $"{stringifyICssValue x} {stringifyICssValue y}"
                |> String
            (property, value) |> Rule

        /// Uses position from font. Uses auto if not provided
        member this.fromFont = (property, Text.FromFont) |> Rule
        /// Forces the line to be under the alphabetic baseline.
        member this.under = (property, Text.Under) |> Rule
        /// Vertical writing mode: places line to the left of text
        /// Horizontal writing mode: places line under text
        member this.left = (property, Text.Left) |> Rule
        /// Vertical writing mode: places line to the right of text
        /// Horizontal writing mode: places line under text
        member this.right = (property, Text.Right) |> Rule
        /// Synonym of auto, use that instead
        member this.autoPos = (property, Text.AutoPos) |> Rule
        /// Places line above text
        member this.above = (property, Text.Above) |> Rule
        /// Places line below text
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
        /// Words are not broken at line breaks, lines will only wrap at whitespace
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
        /// Rotates characters of horizontal scripts 90 degrees clockwise
        /// Lays out vertical scripts naturally
        /// This is the default value
        member this.mixed = (property, Text.Mixed) |> Rule
        /// Lays out characters of horizontal scripts upright
        member this.upright = (property, Text.Upright) |> Rule
        /// Lays out characters as they would be horizontally
        member this.sidewaysRight = (property, Text.SidewaysRight) |> Rule
        /// Lays out characters as they would be horizontally
        member this.sideways = (property, Text.Sideways) |> Rule
        member this.useGlyphOrientation = (property, Text.UseGlyphOrientation) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-rendering
    type TextRendering(property) =
        inherit CssRuleWithAuto(property)
        /// Browser emphasises rendering speed over legibility
        member this.optimizeSpeed = (property, Text.OptimizeSpeed) |> Rule
        /// Browser emphasises legibility over rendering speed
        member this.optimizeLegibility = (property, Text.OptimizeLegibility) |> Rule
        /// Browser emphasies precision over rendering and legibility
        member this.geometricPrecision = (property, Text.GeometricPrecision) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/text-justify
    type TextJustify(property) =
        inherit CssRuleWithAutoNone(property)
        /// Justifies text by adding spaces between words
        member this.interWord = (property, Text.InterWord) |> Rule
        /// Justifies text by adding spaces between characters
        member this.interCharacter = (property, Text.InterCharacter) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/white-space
    type WhiteSpace(property) =
        inherit CssRuleWithNormal(property)
        /// Text does not wrap
        member this.nowrap = (property, Text.Nowrap) |> Rule
        /// Only break at newline characters from the source text and at <br> elements
        member this.pre = (property, Text.Pre) |> Rule
        /// Only break at newline characters from the source text and at <br> elements
        /// Text is also wrapped on overflow
        member this.preWrap = (property, Text.PreWrap) |> Rule
        /// White spaces are collapsed. Lines get broken on newline characters and <br> elements
        member this.preLine = (property, Text.PreLine) |> Rule
        /// Only break at newline characters from the source text and at <br> elements
        /// Text is also wrapped on overflow
        /// Preserved whitespace takes space
        /// Lines can break after each preserver whitespace
        member this.breakSpaces = (property, Text.BreakSpaces) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/user-select
    type UserSelect(property) =
        inherit CssRuleWithAutoNone(property)
        /// All text can be selected by the user
        member this.text = (property, Text.Text) |> Rule
        /// Any selection will be contained by the bounds of the element it is in
        member this.contain = (property, Text.Contain) |> Rule
        /// All of the text must be selected. All or nothing
        member this.all = (property, Text.All) |> Rule
        /// Any selection will be contained by the bounds of the element it is in
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

        /// Hang the first opening bracket or quote
        member this.first = (property, Text.First) |> Rule
        /// Hang the last opening bracket or quote
        member this.last = (property, Text.Last) |> Rule
        /// A stop or comma at the end of the hangs
        member this.forceEnd = (property, Text.ForceEnd) |> Rule
        /// A stop or comma at the end of the hangs if it does not have space
        member this.allowEnd = (property, Text.AllowEnd) |> Rule
