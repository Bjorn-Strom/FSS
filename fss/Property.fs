namespace Fss

open Utilities.Helpers
open Types

module Property =
    type Property =
        | AlignContent
        | AlignItems
        | AlignSelf
        | All
        | Animation
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
        | Background
        | Bleed
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
        | Border
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
        | GridColumnGap
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
        | ListStyle
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
        | Speak
        | SpeechRate
        | Stress
        | TabSize
        | TableLayout
        | TextAlign
        | TextAlignlast
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
        | TextUnderlinePosition
        | TextEmphasis
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
        | ZIndex

        | Hover
        interface ITransitionProperty

    let value (v: Property): string = duToCamel v

    let propertyToKebabCase (property: Property): string =
        property
        |> value
        |> pascalToKebabCase