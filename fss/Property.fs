namespace Fss

open Utilities.Types

module Property =
    type Property =
        | AlignContent
        | AlignItems
        | AlignSelf
        | All
        | Animation                     // Done
        | AnimationDelay                // Done
        | AnimationDirection            // Done
        | AnimationDuration             // Done
        | AnimationFillMode             // Done
        | AnimationIterationCount       // Done
        | AnimationName                 // Done
        | AnimationPlayState            // Done
        | AnimationTimingFunction       // Done
        | BackfaceVisibility
        | BackgroundAttachment
        | BackgroundBlendMode
        | BackgroundClip
        | BackgroundColor               // Done
        | BackgroundImage
        | BackgroundOrigin
        | BackgroundPosition
        | BackgroundRepeat
        | BackgroundSize
        | Background
        | Bleed
        | BorderBottomColor             // Done
        | BorderBottomLeftRadius        // Done
        | BorderBottomRightRadius       // Done
        | BorderBottomStyle
        | BorderBottomWidth             // Done
        | BorderBottom
        | BorderCollapse
        | BorderColor                   // Done
        | BorderImage
        | BorderImageOutset
        | BorderImageRepeat
        | BorderImageSource
        | BorderImageSlice
        | BorderImageWidth
        | BorderLeftColor               // Done
        | BorderLeftStyle
        | BorderLeftWidth               // Done
        | BorderLeft
        | BorderRadius                  // Done
        | BorderRightColor              // Done
        | BorderRightStyle
        | BorderRightWidth              // Done
        | BorderRight
        | BorderSpacing
        | BorderStyle                    // Done
        | BorderTopColor                 // Done
        | BorderTopLeftRadius            // Done
        | BorderTopRightRadius           // Done
        | BorderTopStyle
        | BorderTopWidth                 // Done
        | BorderTop
        | BorderWidth                    // Done
        | Border                         // Done
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
        | Color                             // Done
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
        | FontSize                   // Done
        | FontStretch
        | FontStyle
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
        | TextDecorationSkip
        | TextDecorationStyle
        | TextIndent
        | TextOverflow
        | TextShadow
        | TextTransform
        | TextUnderlinePosition
        | Top
        | Transform                      // Done
        | TransformOrigin
        | TransformStyle
        | Transition                     // Done
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

        interface ICSSProperty

    let value = 
        function 
        | Label -> "label"

        | Hover -> ":hover"

        | BackgroundColor -> "backgroundColor"

        | FontSize -> "fontSize"

        | Color -> "color"

        | Border -> "border"
        | BorderStyle -> "borderStyle"
        | BorderWidth -> "borderWidth"
        | BorderTopWidth -> "borderTopWidth"
        | BorderRightWidth -> "borderRightWidth"
        | BorderBottomWidth -> "borderBottomWidth"
        | BorderLeftWidth -> "borderLeftWidth"
        | BorderRadius -> "borderRadius"
        | BorderTopLeftRadius -> "borderTopLeftRadius"
        | BorderTopRightRadius -> "borderTopRightRadius"
        | BorderBottomRightRadius -> "borderBottomRightRadius"
        | BorderBottomLeftRadius -> "borderBottomLeftRadius"
        | BorderColor -> "borderColor"
        | BorderTopColor -> "borderTopCcolor"
        | BorderRightColor -> "borderRightColor"
        | BorderBottomColor -> "borderBottomColor"
        | BorderLeftColor -> "borderLeftColor"

        | Animation -> "animation"
        | AnimationName -> "animationName"
        | AnimationDuration -> "animationDuration"
        | AnimationTimingFunction -> "animationTimingFunction"
        | AnimationDelay -> "animationDelay"
        | AnimationIterationCount -> "animationIterationCount"
        | AnimationDirection -> "animationDirection"
        | AnimationFillMode -> "animationFillMode"
        | AnimationPlayState -> "animationPlayState"

        | Transform -> "transform"

        | Transition -> "transition"

    let label = Label

    let hover = Hover

    let backgroundColor = BackgroundColor

    let fontSize = FontSize

    let color = Color

    let border = Border
    let borderStyle = BorderStyle
    let borderWidth = BorderWidth
    let borderTopWidth = BorderTopWidth
    let borderRightWidth = BorderRightWidth
    let borderBottomWidth = BorderBottomWidth
    let borderLeftWidth = BorderLeftWidth
    let borderRadius = BorderRadius
    let borderTopLeftRadius = BorderTopLeftRadius
    let borderTopRightRadius = BorderTopRightRadius
    let borderBottomRightRadius = BorderBottomRightRadius
    let borderBottomLeftRadius = BorderBottomLeftRadius
    let borderColor = BorderColor
    let borderTopColor = BorderTopColor
    let borderRightColor = BorderRightColor
    let borderBottomColor = BorderBottomColor
    let borderLeftColor = BorderLeftColor

    let animation = Animation
    let animationName = AnimationName
    let animationDuration = AnimationDuration
    let animationTimingFunction = AnimationTimingFunction
    let animationDelay = AnimationDelay
    let animationIterationCount = AnimationIterationCount
    let animationDirection = AnimationDirection
    let animationFillMode = AnimationFillMode
    let animationPlayState = AnimationPlayState

    let transform = Transform

    let transition = Transition