namespace Fss
// Interfaces
namespace Fss.FssTypes

open Fss.FssTypes

type IStringify =
    interface
        abstract member Stringify : unit -> string
    end

type ICssValue =
    interface
        abstract member Stringify : unit -> string
    end

type ICounterValue =
    interface
        abstract member Stringify : unit -> string
    end

type IFontFaceValue =
    interface
        abstract member Stringify : unit -> string
    end

// TODO: Clean up all the types and functions
// TODO: Finnes counter og font face properties i denne? Isåfall fjern
[<RequireQualifiedAccess>]
module Property =
    type Property =
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
        | Lang
        | LastChild
        | LastOfType
        | Link
        | LocalLink
        | NthChild
        | NthLastChild
        | NthLastOfType
        | NthOfType
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
            member this.Stringify() =
                match this with
                | AdjacentSibling html -> $" + {html.ToString().ToLower()}"
                | GeneralSibling html -> $" + {html.ToString().ToLower()}"
                | Child html -> $" + {html.ToString().ToLower()}"
                | Descendant html -> $" + {html.ToString().ToLower()}"
                | Custom c -> c.ToLower()
                | _ -> Fss.Utilities.Helpers.toKebabCase this

type CssRule(property: Property.Property) =
    member this.value(keyword: Keywords) = (property, keyword) |> Rule
    // TOdo: Funker dette?
    // member this.value(value: 'T) = (property, value) |> Rule
    member this.initial = (property, Initial) |> Rule
    member this.inherit' = (property, Inherit) |> Rule
    member this.unset = (property, Unset) |> Rule
    member this.revert = (property, Revert) |> Rule

and Keywords =
    | Inherit
    | Initial
    | Unset
    | Revert
    interface ICssValue with
        member this.Stringify() = this.ToString().ToLower()

and Rule = Property.Property * ICssValue

type None' =
    | None'
    interface ICssValue with
        member this.Stringify() = "none"

type Auto =
    | Auto
    interface IFontFaceValue with
        member this.Stringify() = (this :> ICssValue).Stringify()

    interface ICounterValue with
        member this.Stringify() = (this :> ICssValue).Stringify()

    interface ICssValue with
        member this.Stringify() = "auto"

type Normal =
    | Normal
    interface ICssValue with
        member this.Stringify() = "normal"

type Float =
    | Float of float
    interface ICssValue with
        member this.Stringify() =
            match this with
            | Float f -> string f

type Int =
    | Int of int
    interface IFontFaceValue with
        member this.Stringify() = (this :> ICssValue).Stringify()

    interface ICssValue with
        member this.Stringify() =
            match this with
            | Int i -> string i

type Char =
    | Char of string
    interface ICssValue with
        member this.Stringify() =
            match this with
            | Char c -> $"'{c}'"

type String =
    | String of string
    interface IFontFaceValue with
        member this.Stringify() = (this :> ICssValue).Stringify()

    interface ICssValue with
        member this.Stringify() =
            match this with
            | String s -> s

type Stringed =
    | Stringed of string
    interface IFontFaceValue with
        member this.Stringify() = (this :> ICssValue).Stringify()

    interface ICssValue with
        member this.Stringify() =
            match this with
            | Stringed s -> $"\"{s}\""

type NameLabel =
    | NameLabel of string
    member this.Unwrap() =
        match this with
        | NameLabel n -> n
    interface ICssValue with
        member this.Stringify() = this.Unwrap();
type Pseudo =
    | PseudoClass of Rule list
    | PseudoElement of Rule list
    member this.Unwrap() =
        match this with
        | PseudoClass p -> p
        | PseudoElement p -> p

    interface ICssValue with
        member this.Stringify() =
            match this with
            | PseudoClass ps ->
                let ps =
                    ps
                    |> List.map
                        (fun (name, property) -> $"{Fss.Utilities.Helpers.toKebabCase name}: {property.Stringify()}")
                    |> String.concat "; "
                    
                $"{ps}"
            | PseudoElement ps ->
                let ps =
                    ps
                    |> List.map
                        (fun (name, property) -> $"{Fss.Utilities.Helpers.toKebabCase name}: {property.Stringify()}")
                    |> String.concat "; "

                $"{ps}"

// TODO: FIX
type Combinator =
    | Combinator of Rule list
    interface ICssValue with
        member this.Stringify() =
            match this with
            | Combinator ps ->
                let ps =
                    ps
                    |> List.map
                        (fun (name, property) -> $"{Fss.Utilities.Helpers.toKebabCase name}: {property.Stringify()};")
                    |> String.concat "; "

                $"{ps}"

// TODO: Bruk denne på alt som har /
type Divider =
    | Divider of string * string
    interface ICssValue with
        member this.Stringify() =
            match this with
            | Divider (a, b) -> $"{a} / {b}"

type Url =
    | Url of string
    interface IFontFaceValue with
        member this.Stringify() = (this :> ICssValue).Stringify()

    interface ICounterValue with
        member this.Stringify() = (this :> ICssValue).Stringify()

    interface ICssValue with
        member this.Stringify() =
            match this with
            | Url u -> $"url({u})"

type Custom =
    | Custom of string
    interface ICssValue with
        member this.Stringify() =
            match this with
            | Custom value -> value
type Path =
    | Path of string
    interface ICssValue with
        member this.Stringify() =
            match this with
            | Path p -> $"path('{p}')"

type ClassName = string
type AnimationName = string
type CounterName = string
type CounterStyle = string
type FontName = string
type FontFaceStyle = string
type Css = string

// TODO: Bruk disse over alt
type CssRuleWithAuto(property: Property.Property) =
    inherit CssRule(property)
    member this.auto = (property, Auto) |> Rule

type CssRuleWithNone(property: Property.Property) =
    inherit CssRule(property)
    member this.none = (property, None') |> Rule

type CssRuleWithAutoNone(property: Property.Property) =
    inherit CssRule(property)
    member this.auto = (property, Auto) |> Rule
    member this.none = (property, None') |> Rule

type CssRuleWithNormal(property: Property.Property) =
    inherit CssRule(property)
    member this.normal = (property, Normal) |> Rule

type CssRuleWithNormalNone(property: Property.Property) =
    inherit CssRuleWithNormal(property)
    member this.none = (property, None') |> Rule

type CssRuleWithAutoNormal(property: Property.Property) =
    inherit CssRuleWithAuto(property)
    member this.normal = (property, Normal) |> Rule

type CssRuleWithAutoNormalNone(property: Property.Property) =
    inherit CssRuleWithAutoNone(property)
    member this.normal = (property, Normal) |> Rule
    
[<AutoOpen>]
module MasterTypeHelpers = 
    let internal stringifyICssValue cssValue: string =
        (cssValue :> ICssValue).Stringify()
    let internal stringifyICounterValue cssValue: string =
        (cssValue :> ICounterValue).Stringify()
    let internal stringifyIFontFaceValue cssValue: string =
        (cssValue :> IFontFaceValue).Stringify()
