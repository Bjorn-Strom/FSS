namespace Fss
namespace Fss.Types

type ICssValue =
    interface 
        abstract member StringifyCss : unit -> string
    end

type ICounterValue =
    interface
        abstract member StringifyCounter : unit -> string
    end

type IFontFaceValue =
    interface
        abstract member StringifyFontFace : unit -> string
    end
    
[<AutoOpen>]
module internal MasterTypeHelpers =
    let internal cache = System.Collections.Generic.Dictionary<ICssValue, string>()
    let internal stringifyICssValue cssValue: string =
        if cache.ContainsKey(cssValue) then
            cache[cssValue]
        else
            let newValue = (cssValue :> ICssValue).StringifyCss()
            cache.Add(cssValue, newValue)
            newValue
    let internal stringifyICounterValue cssValue: string =
        (cssValue :> ICounterValue).StringifyCounter()
    let internal stringifyIFontFaceValue cssValue: string =
        (cssValue :> IFontFaceValue).StringifyFontFace()

[<RequireQualifiedAccess>]
module Property =
    type FontFaceProperty =
        | AscentOverride
        | DescentOverride
        | FontDisplay
        | FontFamily
        | FontStretch
        | FontStyle
        | FontWeight
        | FontVariant
        | FontFeatureSettings
        | FontVariationSettings
        | LineGapOverride
        | SizeAdjust
        | Src
        | UnicodeRange
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this
    type CounterProperty =
        | System
        | Negative
        | Prefix
        | Suffix
        | Range
        | Pad
        | Fallback
        | Symbols
        | AdditiveSymbols
        | SpeakAs
        // Home made
        | NameLabel 
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this
    type CssProperty =
        // Css
        | Appearance
        | AlignContent
        | AlignItems
        | AlignSelf
        | All
        | AnimationDelay
        | AnimationDirection
        | AnimationDuration
        | AnimationFillMode
        | AnimationIterationCount
        | AnimationName
        | AnimationPlayState
        | AnimationTimingFunction
        | AspectRatio
        | BackfaceVisibility
        | BackgroundAttachment
        | BackgroundBlendMode
        | BackgroundClip
        | BackgroundColor
        | BackgroundImage
        | BackgroundOrigin
        | BackgroundPosition
        | BackgroundRepeat
        | BackgroundSize
        | BackdropFilter
        | Bleed
        | Border
        | BorderBottomColor
        | BorderBottomLeftRadius
        | BorderBottomRightRadius
        | BorderBottomStyle
        | BorderBottomWidth
        | BorderBottom
        | BorderCollapse
        | BorderColor
        | BorderImage
        | BorderImageOutset
        | BorderImageRepeat
        | BorderImageSource
        | BorderImageSlice
        | BorderImageWidth
        | BorderLeftColor
        | BorderLeftStyle
        | BorderLeftWidth
        | BorderLeft
        | BorderRadius
        | BorderRightColor
        | BorderRightStyle
        | BorderRightWidth
        | BorderRight
        | BorderSpacing
        | BorderStyle
        | BorderTopColor
        | BorderTopLeftRadius
        | BorderTopRightRadius
        | BorderTopStyle
        | BorderTopWidth
        | BorderTop
        | BorderWidth
        | BorderBlockColor
        | Bottom
        | BoxDecorationBreak
        | BoxShadow
        | BoxSizing
        | BreakAfter
        | BreakBefore
        | BreakInside
        | CaptionSide
        | CaretColor
        | Clear
        | Clip
        | ClipPath
        | Color
        | ColorAdjust
        | Columns
        | ColumnCount
        | ColumnFill
        | ColumnGap
        | ColumnRule
        | ColumnRuleColor
        | ColumnRuleStyle
        | ColumnRuleWidth
        | ColumnSpan
        | ColumnWidth
        | Content
        | CounterIncrement
        | CounterReset
        | CounterSet
        | CueAfter
        | CueBefore
        | Cue
        | Cursor
        | Direction
        | Display
        | Elevation
        | EmptyCells
        | Filter
        | Flex
        | FlexBasis
        | FlexDirection
        | FontFeatureSettings
        | FontVariationSettings
        | FlexFlow
        | FlexGrow
        | FlexShrink
        | FlexWrap
        | Float
        | FontFamily
        | FontKerning
        | FontLanguageOverride
        | FontSizeAdjust
        | FontSize
        | FontStretch
        | FontStyle
        | FontDisplay
        | FontSynthesis
        | FontVariant
        | FontVariantAlternates
        | FontVariantCaps
        | FontVariantEastAsian
        | FontVariantLigatures
        | FontVariantNumeric
        | FontVariantPosition
        | FontWeight
        | Font
        | GridArea
        | GridAutoColumns
        | GridAutoFlow
        | GridAutoRows
        | GridColumnEnd
        | GridColumnStart
        | GridColumn
        | GridGap
        | GridRowEnd
        | GridRowGap
        | GridColumnGap
        | GridRowStart
        | GridRow
        | GridTemplateAreas
        | GridTemplateColumns
        | GridTemplateRows
        | GridTemplate
        | Grid
        | HangingPunctuation
        | Height
        | Hyphens
        | Isolation
        | ImageRendering
        | JustifyContent
        | JustifyItems
        | JustifySelf
        | Left
        | LetterSpacing
        | LineBreak
        | LineHeight
        | ListStyle
        | ListStyleImage
        | ListStylePosition
        | ListStyleType
        | LineGapOverride
        | MaskClip
        | MaskComposite
        | MaskImage
        | MaskMode
        | MaskOrigin
        | MaskPosition
        | MaskRepeat
        | MaskSize
        | MarginBottom
        | MarginLeft
        | MarginRight
        | MarginTop
        | Margin
        | MarginInlineStart
        | MarginInlineEnd
        | MarginBlockStart
        | MarginBlockEnd
        | MarkerOffset
        | Marks
        | MaxHeight
        | MaxWidth
        | MinHeight
        | MinWidth
        | MixBlendMode
        | NavUp
        | NavDown
        | NavLeft
        | NavRight
        | Opacity
        | Order
        | Orphans
        | OutlineColor
        | OutlineOffset
        | OutlineStyle
        | OutlineWidth
        | Outline
        | Overflow
        | OverflowWrap
        | OverflowX
        | OverflowY
        | ObjectFit
        | ObjectPosition
        | PaddingBottom
        | PaddingLeft
        | PaddingRight
        | PaddingTop
        | Padding
        | PaddingInlineStart
        | PaddingInlineEnd
        | PaddingBlockStart
        | PaddingBlockEnd
        | Page
        | PauseAfter
        | PauseBefore
        | Pause
        | PaintOrder
        | PointerEvents
        | Perspective
        | PerspectiveOrigin
        | PitchRange
        | Pitch
        | PlaceContent
        | PlaceItems
        | PlaceSelf
        | PlayDuring
        | Position
        | Quotes
        | Resize
        | RestAfter
        | RestBefore
        | Rest
        | Richness
        | Right
        | Size
        | SpeakHeader
        | SpeakNumeral
        | SpeakPunctuation
        | Src
        | Speak
        | SpeechRate
        | Stress
        | ScrollBehavior
        | ScrollMarginBottom
        | ScrollMarginLeft
        | ScrollMarginRight
        | ScrollMarginTop
        | ScrollMargin
        | ScrollPaddingBottom
        | ScrollPaddingLeft
        | ScrollPaddingRight
        | ScrollPaddingTop
        | ScrollPadding
        | ScrollSnapType
        | ScrollSnapAlign
        | ScrollSnapStop
        | SizeAdjust
        | OverscrollBehaviorX
        | OverscrollBehaviorY
        | TabSize
        | TableLayout
        | TextAlign
        | TextAlignLast
        | TextDecoration
        | TextDecorationColor
        | TextDecorationLine
        | TextDecorationThickness
        | TextDecorationSkip
        | TextDecorationSkipInk
        | TextDecorationStyle
        | TextIndent
        | TextOverflow
        | TextShadow
        | TextTransform
        | TextEmphasis
        | TextEmphasisColor
        | TextEmphasisPosition
        | TextEmphasisStyle
        | TextUnderlineOffset
        | TextUnderlinePosition
        | TextSizeAdjust
        | TextOrientation
        | TextRendering
        | TextJustify
        | Top
        | Transform
        | TransformOrigin
        | TransformStyle
        | Transition
        | TransitionDelay
        | TransitionDuration
        | TransitionProperty
        | TransitionTimingFunction
        | UnicodeBidi
        | UnicodeRange
        | UserSelect
        | VerticalAlign
        | Visibility
        | VoiceBalance
        | VoiceDuration
        | VoiceFamily
        | VoicePitch
        | VoiceRange
        | VoiceRate
        | VoiceStress
        | VoiceVolume
        | Volume
        | WhiteSpace
        | Widows
        | Width
        | WillChange
        | WordBreak
        | WordSpacing
        | WordWrap
        | WritingMode
        | ZIndex

        // Pseudo
        | Active
        | AnyLink
        | Blank
        | Checked
        | Current
        | Disabled
        | Empty
        | Enabled
        | FirstChild
        | FirstOfType
        | Focus
        | FocusVisible
        | FocusWithin
        | Future
        | Hover
        | Indeterminate
        | Invalid
        | InRange
        | Lang of string
        | LastChild
        | LastOfType
        | Link
        | LocalLink
        | NthChild of string
        | NthLastChild of string
        | NthLastOfType of string
        | NthOfType of string
        | OnlyChild
        | OnlyOfType
        | Optional
        | OutOfRange
        | Past
        | Playing
        | Paused
        | PlaceholderShown
        | ReadOnly
        | ReadWrite
        | Required
        | Root
        | Scope
        | Target
        | TargetWithin
        | Valid
        | Visited
        | UserInvalid

        | After
        | Before
        | FirstLetter
        | FirstLine
        | Selection
        | Marker

        // Svg
        | AlignmentBaseline
        | BaselineShift
        | DominantBaseline
        | TextAnchor
        | ClipRule
        | FloodColor
        | FloodOpacity
        | LightingColor
        | StopColor
        | StopOpacity
        | ColorInterpolation
        | ColorInterpolationFilters
        | Label
        | Fill
        | FillOpacity
        | FillRule
        | ShapeRendering
        | Stroke
        | StrokeOpacity
        | StrokeDasharray
        | StrokeDashoffset
        | StrokeLinecap
        | StrokeLinejoin
        | StrokeMiterlimit
        | StrokeWidth

        // Home made
        | NameLabel 
        | AdjacentSibling of Html.Html
        | GeneralSibling of Html.Html
        | Child of Html.Html
        | Descendant of Html.Html
        | Custom of string
        | Media
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Lang l -> $"lang({l})"
                | NthChild n -> $"nth-child({n})"
                | NthLastChild n -> $"nth-last-child({n})"
                | NthOfType n -> $"nth-of-type({n})"
                | NthLastOfType n -> $"nth-last-of-type({n})"
                | AdjacentSibling html -> $" + {html.Stringify()}"
                | GeneralSibling html -> $" ~ {html.Stringify()}"
                | Child html -> $" > {html.Stringify()}"
                | Descendant html -> $" {html.Stringify()}"
                | Custom c -> c.ToLower()
                | _ -> Fss.Utilities.Helpers.toKebabCase this

type None' =
    | None'
    interface ICssValue with
        member this.StringifyCss() = "none"

type Auto =
    | Auto
    interface IFontFaceValue with
        member this.StringifyFontFace() = stringifyICssValue this

    interface ICounterValue with
        member this.StringifyCounter() = stringifyICssValue this

    interface ICssValue with
        member this.StringifyCss() = "auto"

type Normal =
    | Normal
    interface ICssValue with
        member this.StringifyCss() = "normal"
    interface IFontFaceValue with
        member this.StringifyFontFace() = stringifyICssValue this

type Float =
    | Float of float
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Float f -> string f

type Int =
    | Int of int
    interface IFontFaceValue with
        member this.StringifyFontFace() = stringifyICssValue this

    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Int i -> string i

type Char =
    | Char of string
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Char c -> $"'{c}'"

type String =
    | String of string
    interface ICounterValue with
        member this.StringifyCounter() = stringifyICssValue this
    interface IFontFaceValue with
        member this.StringifyFontFace() = stringifyICssValue this

    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | String s -> s

type Stringed =
    | Stringed of string
    interface IFontFaceValue with
        member this.StringifyFontFace() = stringifyICssValue this
    interface ICounterValue with
        member this.StringifyCounter() = stringifyICssValue this

    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Stringed s -> $"\"{s}\""

type NameLabel =
    | NameLabel of string
    member this.Unwrap() =
        match this with
        | NameLabel n -> n
    interface ICssValue with
        member this.StringifyCss() = this.Unwrap()
    interface ICounterValue with
        member this.StringifyCounter() = this.Unwrap()
        
type CssRule(property: Property.CssProperty) =
    member this.value(keyword: Keywords) = (property, keyword) |> Rule
    /// Applies the default value to the element
    member this.initial = (property, Initial) |> Rule
    /// Take computed value from parent element
    member this.inherit' = (property, Inherit) |> Rule
    /// Resets a property to its inherited value if it inherits from its parent
    /// to its initial value if not.
    member this.unset = (property, Unset) |> Rule
    /// Reverts the property to user agent style sheet
    member this.revert = (property, Revert) |> Rule
    

and Keywords =
    | Inherit
    | Initial
    | Unset
    | Revert
    interface ICssValue with
        member this.StringifyCss() = this.ToString().ToLower()

and Rule = Property.CssProperty * ICssValue
type CounterRule = Property.CounterProperty * ICounterValue
type FontFaceRule = Property.FontFaceProperty * IFontFaceValue
        
type ImportantMaster =
    | ImportantMaster of ICssValue
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | ImportantMaster value ->
                $"{stringifyICssValue value} !important"
        
type Pseudo =
    | PseudoClassMaster of Rule list
    | PseudoElementMaster of Rule list
    member this.Unwrap() =
        match this with
        | PseudoClassMaster p -> p
        | PseudoElementMaster p -> p

    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | PseudoClassMaster ps ->
                let ps =
                    ps
                    |> List.map
                        (fun (name, property) -> $"{stringifyICssValue name}: {property.StringifyCss()}")
                    |> String.concat "; "
                    
                $"{ps}"
            | PseudoElementMaster ps ->
                let ps =
                    ps
                    |> List.map
                        (fun (name, property) -> $"{stringifyICssValue name}: {property.StringifyCss()}")
                    |> String.concat "; "

                $"{ps}"

type CombinatorMaster =
    | CombinatorMaster of Rule list
    member this.Unwrap() =
        match this with
        | CombinatorMaster c -> c
    interface ICssValue with
        member this.StringifyCss() = ""

type DividerMaster =
    | DividerMaster of string * string
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | DividerMaster (a, b) -> $"{a} / {b}"

type UrlMaster =
    | UrlMaster of string
    interface IFontFaceValue with
        member this.StringifyFontFace() = (this :> ICssValue).StringifyCss()

    interface ICounterValue with
        member this.StringifyCounter() = (this :> ICssValue).StringifyCss()

    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | UrlMaster u -> $"url({u})"

type CustomMaster =
    | CustomMaster of string
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | CustomMaster value -> value
type PathMaster =
    | PathMaster of string
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | PathMaster p -> $"path('{p}')"

type ClassName = string
type Css = string

type CssRuleWithAuto(property: Property.CssProperty) =
    inherit CssRule(property)
    member this.auto = (property, Auto) |> Rule

type CssRuleWithNone(property: Property.CssProperty) =
    inherit CssRule(property)
    member this.none = (property, None') |> Rule

type CssRuleWithAutoNone(property: Property.CssProperty) =
    inherit CssRule(property)
    member this.auto = (property, Auto) |> Rule
    member this.none = (property, None') |> Rule

type CssRuleWithNormal(property: Property.CssProperty) =
    inherit CssRule(property)
    member this.normal = (property, Normal) |> Rule

type CssRuleWithNormalNone(property: Property.CssProperty) =
    inherit CssRuleWithNormal(property)
    member this.none = (property, None') |> Rule

type CssRuleWithAutoNormal(property: Property.CssProperty) =
    inherit CssRuleWithAuto(property)
    member this.normal = (property, Normal) |> Rule

type CssRuleWithAutoNormalNone(property: Property.CssProperty) =
    inherit CssRuleWithAutoNone(property)
    member this.normal = (property, Normal) |> Rule
    
type CssRuleWithValueFunctions<'T when 'T :> ICssValue>(property: Property.CssProperty, seperator) =
    inherit CssRule(property)
    member this.value(value: 'T) =
        let value = stringifyICssValue value
        (property, value |> String) |> Rule

    member this.value(values: 'T list) =
        let values =
            values
            |> List.map stringifyICssValue
            |> String.concat seperator
        (property, values |> String) |> Rule

