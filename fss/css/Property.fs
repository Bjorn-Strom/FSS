namespace Fss

open Fable.Core.JsInterop
open Utilities.Helpers

module Property =
    type Property =
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
        | JustifyContent
        | JustifyItems
        | JustifySelf
        | Label
        | Left
        | LetterSpacing
        | LineBreak
        | LineHeight
        | ListStyleImage
        | ListStylePosition
        | ListStyleType
        | MarginBottom
        | MarginLeft
        | MarginRight
        | MarginTop
        | Margin
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
        | PaddingBottom
        | PaddingLeft
        | PaddingRight
        | PaddingTop
        | Padding
        | PageBreakAfter
        | PageBreakBefore
        | PageBreakInside
        | Page
        | PauseAfter
        | PauseBefore
        | Pause
        | PaintOrder
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
        | TransitionDelay
        | TransitionDuration
        | TransitionProperty
        | TransitionTimingFunction
        | UnicodeBidi
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

        | Active
        | AnyLink
        | Blank
        | Checked
        | Disabled
        | Empty
        | Enabled
        | FirstChild
        | FirstOfType
        | Focus
        | Hover
        | Indeterminate
        | Invalid
        | Lang
        | LastChild
        | LastOfType
        | Link
        | NthChild
        | NthLastChild
        | NthLastOfType
        | NthOfType
        | OnlyChild
        | OnlyOfType
        | Optional
        | OutOfRange
        | ReadOnly
        | ReadWrite
        | Required
        | Target
        | Valid
        | Visited

        | After
        | Before
        | FirstLetter
        | FirstLine
        | Selection
        interface ITransitionProperty

module PropertyValue =
    open Property

    let value (v: Property): string = duToCamel v

    let toKebabCase (property: Property): string =
        property
        |> value
        |> pascalToKebabCase

    let cssValue (property: Property) cssValue =
        property |> value ==> cssValue |> CSSProperty

