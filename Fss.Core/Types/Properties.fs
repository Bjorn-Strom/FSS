namespace Fss
namespace Fss.Types

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
            member this.StringifyCss() =
                match this with
                | AscentOverride -> "ascent-override"
                | DescentOverride -> "descent-override"
                | FontDisplay -> "font-display"
                | FontFamily -> "font-family"
                | FontStretch -> "font-stretch"
                | FontStyle -> "font-style"
                | FontWeight -> "font-weight"
                | FontVariant -> "font-variant"
                | FontFeatureSettings -> "font-feature-settings"
                | FontVariationSettings -> "font-variation-settings"
                | LineGapOverride -> "line-gap-override"
                | SizeAdjust -> "size-adjust"
                | Src -> "src"
                | UnicodeRange -> "unicode-range"
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
            member this.StringifyCss() =
                match this with
                | System -> "system"
                | Negative -> "negative"
                | Prefix -> "prefix"
                | Suffix -> "suffix"
                | Range -> "range"
                | Pad -> "pad"
                | Fallback -> "fallback"
                | Symbols -> "symbols"
                | AdditiveSymbols -> "additive-symbols"
                | SpeakAs -> "speak-as"
                // Home made
                | NameLabel -> "name-label"
    type CssProperty =
        // Css
        | AccentColor
        | Appearance
        | ColorScheme
        | Contain
        | ContentVisibility
        | Gap
        | Rotate
        | RowGap
        | Scale
        | Translate
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
        | AnimationTimeline
        | AnimationRange
        | AnimationRangeStart
        | AnimationRangeEnd
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
        | Background
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
        | BorderBlock
        | BorderBlockColor
        | BorderBlockEnd
        | BorderBlockEndColor
        | BorderBlockEndStyle
        | BorderBlockEndWidth
        | BorderBlockStart
        | BorderBlockStartColor
        | BorderBlockStartStyle
        | BorderBlockStartWidth
        | BorderBlockStyle
        | BorderBlockWidth
        | BorderInline
        | BorderInlineColor
        | BorderInlineEnd
        | BorderInlineEndColor
        | BorderInlineEndStyle
        | BorderInlineEndWidth
        | BorderInlineStart
        | BorderInlineStartColor
        | BorderInlineStartStyle
        | BorderInlineStartWidth
        | BorderInlineStyle
        | BorderInlineWidth
        | BlockSize
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
        | Container
        | ContainerName
        | ContainerQuery
        | ContainerType
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
        | Inset
        | InsetBlock
        | InsetBlockEnd
        | InsetBlockStart
        | InsetInline
        | InsetInlineEnd
        | InsetInlineStart
        | InlineSize
        | Layer
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
        | MarginInline
        | MarginBlock
        | MarkerOffset
        | Marks
        | MaxBlockSize
        | MaxHeight
        | MaxInlineSize
        | MaxWidth
        | MinBlockSize
        | MinHeight
        | MinInlineSize
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
        | PaddingInline
        | PaddingBlock
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
        | ScopeRule
        | StartingStyle
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
        | ScrollTimelineName
        | ScrollTimelineAxis
        | ScrollbarColor
        | ScrollbarWidth
        | SizeAdjust
        | OverscrollBehavior
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
        | TransitionBehavior
        | UnicodeBidi
        | UnicodeRange
        | UserSelect
        | VerticalAlign
        | ViewTimelineName
        | ViewTimelineAxis
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
        | TextWrap
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
        | Has of string
        | Is of string
        | Where of string

        | After
        | Before
        | FirstLetter
        | FirstLine
        | Placeholder
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
        | Class of string
        | Id of string
        | NameLabel
        | AdjacentSibling of Selector
        | GeneralSibling of Selector
        | Child of Selector
        | Descendant of Selector
        | Custom of string
        | Media
        | Attribute
        | AttributeSelector of Selector
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | AccentColor -> "accent-color"
                | Appearance -> "appearance"
                | ColorScheme -> "color-scheme"
                | Contain -> "contain"
                | ContentVisibility -> "content-visibility"
                | Gap -> "gap"
                | Rotate -> "rotate"
                | RowGap -> "row-gap"
                | Scale -> "scale"
                | Translate -> "translate"
                | AlignContent -> "align-content"
                | AlignItems -> "align-items"
                | AlignSelf -> "align-self"
                | All -> "all"
                | Animation -> "animation"
                | AnimationDelay -> "animation-delay"
                | AnimationDirection -> "animation-direction"
                | AnimationDuration -> "animation-duration"
                | AnimationFillMode -> "animation-fill-mode"
                | AnimationIterationCount -> "animation-iteration-count"
                | AnimationName -> "animation-name"
                | AnimationPlayState -> "animation-play-state"
                | AnimationTimingFunction -> "animation-timing-function"
                | AnimationTimeline -> "animation-timeline"
                | AnimationRange -> "animation-range"
                | AnimationRangeStart -> "animation-range-start"
                | AnimationRangeEnd -> "animation-range-end"
                | AspectRatio -> "aspect-ratio"
                | BackfaceVisibility -> "backface-visibility"
                | BackgroundAttachment -> "background-attachment"
                | BackgroundBlendMode -> "background-blend-mode"
                | BackgroundClip -> "background-clip"
                | BackgroundColor -> "background-color"
                | BackgroundImage -> "background-image"
                | BackgroundOrigin -> "background-origin"
                | BackgroundPosition -> "background-position"
                | BackgroundRepeat -> "background-repeat"
                | BackgroundSize -> "background-size"
                | Background -> "background"
                | BackdropFilter -> "backdrop-filter"
                | Bleed -> "bleed"
                | Border -> "border"
                | BorderBottomColor -> "border-bottom-color"
                | BorderBottomLeftRadius -> "border-bottom-left-radius"
                | BorderBottomRightRadius -> "border-bottom-right-radius"
                | BorderBottomStyle -> "border-bottom-style"
                | BorderBottomWidth -> "border-bottom-width"
                | BorderBottom -> "border-bottom"
                | BorderCollapse -> "border-collapse"
                | BorderColor -> "border-color"
                | BorderImage -> "border-image"
                | BorderImageOutset -> "border-image-outset"
                | BorderImageRepeat -> "border-image-repeat"
                | BorderImageSource -> "border-image-source"
                | BorderImageSlice -> "border-image-slice"
                | BorderImageWidth -> "border-image-width"
                | BorderLeftColor -> "border-left-color"
                | BorderLeftStyle -> "border-left-style"
                | BorderLeftWidth -> "border-left-width"
                | BorderLeft -> "border-left"
                | BorderRadius -> "border-radius"
                | BorderRightColor -> "border-right-color"
                | BorderRightStyle -> "border-right-style"
                | BorderRightWidth -> "border-right-width"
                | BorderRight -> "border-right"
                | BorderSpacing -> "border-spacing"
                | BorderStyle -> "border-style"
                | BorderTopColor -> "border-top-color"
                | BorderTopLeftRadius -> "border-top-left-radius"
                | BorderTopRightRadius -> "border-top-right-radius"
                | BorderTopStyle -> "border-top-style"
                | BorderTopWidth -> "border-top-width"
                | BorderTop -> "border-top"
                | BorderWidth -> "border-width"
                | BorderBlock -> "border-block"
                | BorderBlockColor -> "border-block-color"
                | BorderBlockEnd -> "border-block-end"
                | BorderBlockEndColor -> "border-block-end-color"
                | BorderBlockEndStyle -> "border-block-end-style"
                | BorderBlockEndWidth -> "border-block-end-width"
                | BorderBlockStart -> "border-block-start"
                | BorderBlockStartColor -> "border-block-start-color"
                | BorderBlockStartStyle -> "border-block-start-style"
                | BorderBlockStartWidth -> "border-block-start-width"
                | BorderBlockStyle -> "border-block-style"
                | BorderBlockWidth -> "border-block-width"
                | BorderInline -> "border-inline"
                | BorderInlineColor -> "border-inline-color"
                | BorderInlineEnd -> "border-inline-end"
                | BorderInlineEndColor -> "border-inline-end-color"
                | BorderInlineEndStyle -> "border-inline-end-style"
                | BorderInlineEndWidth -> "border-inline-end-width"
                | BorderInlineStart -> "border-inline-start"
                | BorderInlineStartColor -> "border-inline-start-color"
                | BorderInlineStartStyle -> "border-inline-start-style"
                | BorderInlineStartWidth -> "border-inline-start-width"
                | BorderInlineStyle -> "border-inline-style"
                | BorderInlineWidth -> "border-inline-width"
                | BlockSize -> "block-size"
                | Bottom -> "bottom"
                | BoxDecorationBreak -> "box-decoration-break"
                | BoxShadow -> "box-shadow"
                | BoxSizing -> "box-sizing"
                | BreakAfter -> "break-after"
                | BreakBefore -> "break-before"
                | BreakInside -> "break-inside"
                | CaptionSide -> "caption-side"
                | CaretColor -> "caret-color"
                | Clear -> "clear"
                | Clip -> "clip"
                | ClipPath -> "clip-path"
                | Color -> "color"
                | ColorAdjust -> "color-adjust"
                | Columns -> "columns"
                | ColumnCount -> "column-count"
                | ColumnFill -> "column-fill"
                | ColumnGap -> "column-gap"
                | ColumnRule -> "column-rule"
                | ColumnRuleColor -> "column-rule-color"
                | ColumnRuleStyle -> "column-rule-style"
                | ColumnRuleWidth -> "column-rule-width"
                | ColumnSpan -> "column-span"
                | ColumnWidth -> "column-width"
                | Container -> "container"
                | ContainerName -> "container-name"
                | ContainerQuery -> "container-query"
                | ContainerType -> "container-type"
                | Content -> "content"
                | CounterIncrement -> "counter-increment"
                | CounterReset -> "counter-reset"
                | CounterSet -> "counter-set"
                | CueAfter -> "cue-after"
                | CueBefore -> "cue-before"
                | Cue -> "cue"
                | Cursor -> "cursor"
                | Direction -> "direction"
                | Display -> "display"
                | Elevation -> "elevation"
                | EmptyCells -> "empty-cells"
                | Filter -> "filter"
                | Flex -> "flex"
                | FlexBasis -> "flex-basis"
                | FlexDirection -> "flex-direction"
                | FontFeatureSettings -> "font-feature-settings"
                | FontVariationSettings -> "font-variation-settings"
                | FlexFlow -> "flex-flow"
                | FlexGrow -> "flex-grow"
                | FlexShrink -> "flex-shrink"
                | FlexWrap -> "flex-wrap"
                | Float -> "float"
                | FontFamily -> "font-family"
                | FontKerning -> "font-kerning"
                | FontLanguageOverride -> "font-language-override"
                | FontSizeAdjust -> "font-size-adjust"
                | FontSize -> "font-size"
                | FontStretch -> "font-stretch"
                | FontStyle -> "font-style"
                | FontDisplay -> "font-display"
                | FontSynthesis -> "font-synthesis"
                | FontVariant -> "font-variant"
                | FontVariantAlternates -> "font-variant-alternates"
                | FontVariantCaps -> "font-variant-caps"
                | FontVariantEastAsian -> "font-variant-east-asian"
                | FontVariantLigatures -> "font-variant-ligatures"
                | FontVariantNumeric -> "font-variant-numeric"
                | FontVariantPosition -> "font-variant-position"
                | FontWeight -> "font-weight"
                | Font -> "font"
                | GridArea -> "grid-area"
                | GridAutoColumns -> "grid-auto-columns"
                | GridAutoFlow -> "grid-auto-flow"
                | GridAutoRows -> "grid-auto-rows"
                | GridColumnEnd -> "grid-column-end"
                | GridColumnStart -> "grid-column-start"
                | GridColumn -> "grid-column"
                | GridGap -> "grid-gap"
                | GridRowEnd -> "grid-row-end"
                | GridRowGap -> "grid-row-gap"
                | GridColumnGap -> "grid-column-gap"
                | GridRowStart -> "grid-row-start"
                | GridRow -> "grid-row"
                | GridTemplateAreas -> "grid-template-areas"
                | GridTemplateColumns -> "grid-template-columns"
                | GridTemplateRows -> "grid-template-rows"
                | GridTemplate -> "grid-template"
                | Grid -> "grid"
                | HangingPunctuation -> "hanging-punctuation"
                | Height -> "height"
                | Hyphens -> "hyphens"
                | Isolation -> "isolation"
                | ImageRendering -> "image-rendering"
                | Inset -> "inset"
                | InsetBlock -> "inset-block"
                | InsetBlockEnd -> "inset-block-end"
                | InsetBlockStart -> "inset-block-start"
                | InsetInline -> "inset-inline"
                | InsetInlineEnd -> "inset-inline-end"
                | InsetInlineStart -> "inset-inline-start"
                | InlineSize -> "inline-size"
                | Layer -> "layer"
                | JustifyContent -> "justify-content"
                | JustifyItems -> "justify-items"
                | JustifySelf -> "justify-self"
                | Left -> "left"
                | LetterSpacing -> "letter-spacing"
                | LineBreak -> "line-break"
                | LineHeight -> "line-height"
                | ListStyle -> "list-style"
                | ListStyleImage -> "list-style-image"
                | ListStylePosition -> "list-style-position"
                | ListStyleType -> "list-style-type"
                | LineGapOverride -> "line-gap-override"
                | MaskClip -> "mask-clip"
                | MaskComposite -> "mask-composite"
                | MaskImage -> "mask-image"
                | MaskMode -> "mask-mode"
                | MaskOrigin -> "mask-origin"
                | MaskPosition -> "mask-position"
                | MaskRepeat -> "mask-repeat"
                | MaskSize -> "mask-size"
                | MarginBottom -> "margin-bottom"
                | MarginLeft -> "margin-left"
                | MarginRight -> "margin-right"
                | MarginTop -> "margin-top"
                | Margin -> "margin"
                | MarginInlineStart -> "margin-inline-start"
                | MarginInlineEnd -> "margin-inline-end"
                | MarginBlockStart -> "margin-block-start"
                | MarginBlockEnd -> "margin-block-end"
                | MarginInline -> "margin-inline"
                | MarginBlock -> "margin-block"
                | MarkerOffset -> "marker-offset"
                | Marks -> "marks"
                | MaxBlockSize -> "max-block-size"
                | MaxHeight -> "max-height"
                | MaxInlineSize -> "max-inline-size"
                | MaxWidth -> "max-width"
                | MinBlockSize -> "min-block-size"
                | MinHeight -> "min-height"
                | MinInlineSize -> "min-inline-size"
                | MinWidth -> "min-width"
                | MixBlendMode -> "mix-blend-mode"
                | NavUp -> "nav-up"
                | NavDown -> "nav-down"
                | NavLeft -> "nav-left"
                | NavRight -> "nav-right"
                | Opacity -> "opacity"
                | Order -> "order"
                | Orphans -> "orphans"
                | OutlineColor -> "outline-color"
                | OutlineOffset -> "outline-offset"
                | OutlineStyle -> "outline-style"
                | OutlineWidth -> "outline-width"
                | Outline -> "outline"
                | Overflow -> "overflow"
                | OverflowWrap -> "overflow-wrap"
                | OverflowX -> "overflow-x"
                | OverflowY -> "overflow-y"
                | ObjectFit -> "object-fit"
                | ObjectPosition -> "object-position"
                | PaddingBottom -> "padding-bottom"
                | PaddingLeft -> "padding-left"
                | PaddingRight -> "padding-right"
                | PaddingTop -> "padding-top"
                | Padding -> "padding"
                | PaddingInlineStart -> "padding-inline-start"
                | PaddingInlineEnd -> "padding-inline-end"
                | PaddingBlockStart -> "padding-block-start"
                | PaddingBlockEnd -> "padding-block-end"
                | PaddingInline -> "padding-inline"
                | PaddingBlock -> "padding-block"
                | Page -> "page"
                | PauseAfter -> "pause-after"
                | PauseBefore -> "pause-before"
                | Pause -> "pause"
                | PaintOrder -> "paint-order"
                | PointerEvents -> "pointer-events"
                | Perspective -> "perspective"
                | PerspectiveOrigin -> "perspective-origin"
                | PitchRange -> "pitch-range"
                | Pitch -> "pitch"
                | PlaceContent -> "place-content"
                | PlaceItems -> "place-items"
                | PlaceSelf -> "place-self"
                | PlayDuring -> "play-during"
                | Position -> "position"
                | Quotes -> "quotes"
                | Resize -> "resize"
                | RestAfter -> "rest-after"
                | RestBefore -> "rest-before"
                | Rest -> "rest"
                | Richness -> "richness"
                | Right -> "right"
                | Size -> "size"
                | SpeakHeader -> "speak-header"
                | SpeakNumeral -> "speak-numeral"
                | SpeakPunctuation -> "speak-punctuation"
                | Src -> "src"
                | Speak -> "speak"
                | SpeechRate -> "speech-rate"
                | Stress -> "stress"
                | ScopeRule -> "scope"
                | StartingStyle -> "starting-style"
                | ScrollBehavior -> "scroll-behavior"
                | ScrollMarginBottom -> "scroll-margin-bottom"
                | ScrollMarginLeft -> "scroll-margin-left"
                | ScrollMarginRight -> "scroll-margin-right"
                | ScrollMarginTop -> "scroll-margin-top"
                | ScrollMargin -> "scroll-margin"
                | ScrollPaddingBottom -> "scroll-padding-bottom"
                | ScrollPaddingLeft -> "scroll-padding-left"
                | ScrollPaddingRight -> "scroll-padding-right"
                | ScrollPaddingTop -> "scroll-padding-top"
                | ScrollPadding -> "scroll-padding"
                | ScrollSnapType -> "scroll-snap-type"
                | ScrollSnapAlign -> "scroll-snap-align"
                | ScrollSnapStop -> "scroll-snap-stop"
                | ScrollTimelineName -> "scroll-timeline-name"
                | ScrollTimelineAxis -> "scroll-timeline-axis"
                | ScrollbarColor -> "scrollbar-color"
                | ScrollbarWidth -> "scrollbar-width"
                | SizeAdjust -> "size-adjust"
                | OverscrollBehavior -> "overscroll-behavior"
                | OverscrollBehaviorX -> "overscroll-behavior-x"
                | OverscrollBehaviorY -> "overscroll-behavior-y"
                | TabSize -> "tab-size"
                | TableLayout -> "table-layout"
                | TextAlign -> "text-align"
                | TextAlignLast -> "text-align-last"
                | TextDecoration -> "text-decoration"
                | TextDecorationColor -> "text-decoration-color"
                | TextDecorationLine -> "text-decoration-line"
                | TextDecorationThickness -> "text-decoration-thickness"
                | TextDecorationSkip -> "text-decoration-skip"
                | TextDecorationSkipInk -> "text-decoration-skip-ink"
                | TextDecorationStyle -> "text-decoration-style"
                | TextIndent -> "text-indent"
                | TextOverflow -> "text-overflow"
                | TextShadow -> "text-shadow"
                | TextTransform -> "text-transform"
                | TextEmphasis -> "text-emphasis"
                | TextEmphasisColor -> "text-emphasis-color"
                | TextEmphasisPosition -> "text-emphasis-position"
                | TextEmphasisStyle -> "text-emphasis-style"
                | TextUnderlineOffset -> "text-underline-offset"
                | TextUnderlinePosition -> "text-underline-position"
                | TextSizeAdjust -> "text-size-adjust"
                | TextOrientation -> "text-orientation"
                | TextRendering -> "text-rendering"
                | TextJustify -> "text-justify"
                | Top -> "top"
                | Transform -> "transform"
                | TransformOrigin -> "transform-origin"
                | TransformStyle -> "transform-style"
                | Transition -> "transition"
                | TransitionDelay -> "transition-delay"
                | TransitionDuration -> "transition-duration"
                | TransitionProperty -> "transition-property"
                | TransitionTimingFunction -> "transition-timing-function"
                | TransitionBehavior -> "transition-behavior"
                | UnicodeBidi -> "unicode-bidi"
                | UnicodeRange -> "unicode-range"
                | UserSelect -> "user-select"
                | VerticalAlign -> "vertical-align"
                | ViewTimelineName -> "view-timeline-name"
                | ViewTimelineAxis -> "view-timeline-axis"
                | Visibility -> "visibility"
                | VoiceBalance -> "voice-balance"
                | VoiceDuration -> "voice-duration"
                | VoiceFamily -> "voice-family"
                | VoicePitch -> "voice-pitch"
                | VoiceRange -> "voice-range"
                | VoiceRate -> "voice-rate"
                | VoiceStress -> "voice-stress"
                | VoiceVolume -> "voice-volume"
                | Volume -> "volume"
                | TextWrap -> "text-wrap"
                | WhiteSpace -> "white-space"
                | Widows -> "widows"
                | Width -> "width"
                | WillChange -> "will-change"
                | WordBreak -> "word-break"
                | WordSpacing -> "word-spacing"
                | WordWrap -> "word-wrap"
                | WritingMode -> "writing-mode"
                | ZIndex -> "z-index"

                // Pseudo
                | Active -> "active"
                | AnyLink -> "any-link"
                | Blank -> "blank"
                | Checked -> "checked"
                | Current -> "current"
                | Disabled -> "disabled"
                | Empty -> "empty"
                | Enabled -> "enabled"
                | FirstChild -> "first-child"
                | FirstOfType -> "first-of-type"
                | Focus -> "focus"
                | FocusVisible -> "focus-visible"
                | FocusWithin -> "focus-within"
                | Future -> "future"
                | Hover -> "hover"
                | Indeterminate -> "indeterminate"
                | Invalid -> "invalid"
                | InRange -> "in-range"
                | LastChild -> "last-child"
                | LastOfType -> "last-of-type"
                | Link -> "link"
                | LocalLink -> "local-link"
                | OnlyChild -> "only-child"
                | OnlyOfType -> "only-of-type"
                | Optional -> "optional"
                | OutOfRange -> "out-of-range"
                | Past -> "past"
                | Playing -> "playing"
                | Paused -> "paused"
                | PlaceholderShown -> "placeholder-shown"
                | ReadOnly -> "read-only"
                | ReadWrite -> "read-write"
                | Required -> "required"
                | Root -> "root"
                | Scope -> "scope"
                | Target -> "target"
                | TargetWithin -> "target-within"
                | Valid -> "valid"
                | Visited -> "visited"
                | UserInvalid -> "user-invalid"
                | Has s -> $"has({s})"
                | Is s -> $"is({s})"
                | Where s -> $"where({s})"

                | After -> "after"
                | Before -> "before"
                | FirstLetter -> "first-letter"
                | FirstLine -> "first-line"
                | Placeholder -> "placeholder"
                | Selection -> "selection"
                | Marker -> "marker"

                // Svg
                | AlignmentBaseline -> "alignment-baseline"
                | BaselineShift -> "baseline-shift"
                | DominantBaseline -> "dominant-baseline"
                | TextAnchor -> "text-anchor"
                | ClipRule -> "clip-rule"
                | FloodColor -> "flood-color"
                | FloodOpacity -> "flood-opacity"
                | LightingColor -> "lighting-color"
                | StopColor -> "stop-color"
                | StopOpacity -> "stop-opacity"
                | ColorInterpolation -> "color-interpolation"
                | ColorInterpolationFilters -> "color-interpolation-filters"
                | Label -> "label"
                | Fill -> "fill"
                | FillOpacity -> "fill-opacity"
                | FillRule -> "fill-rule"
                | ShapeRendering -> "shape-rendering"
                | Stroke -> "stroke"
                | StrokeOpacity -> "stroke-opacity"
                | StrokeDasharray -> "stroke-dasharray"
                | StrokeDashoffset -> "stroke-dashoffset"
                | StrokeLinecap -> "stroke-linecap"
                | StrokeLinejoin -> "stroke-linejoin"
                | StrokeMiterlimit -> "stroke-miterlimit"
                | StrokeWidth -> "stroke-width"

                | Lang l -> $"lang({l})"
                | NthChild n -> $"nth-child({n})"
                | NthLastChild n -> $"nth-last-child({n})"
                | NthOfType n -> $"nth-of-type({n})"
                | NthLastOfType n -> $"nth-last-of-type({n})"
                | AdjacentSibling selector -> $" + {Selector.stringify(selector)}"
                | GeneralSibling selector -> $" ~ {Selector.stringify(selector)}"
                | Child selector -> $" > {Selector.stringify(selector)}"
                | Descendant selector -> $" {Selector.stringify(selector)}"
                | Attribute -> ""
                | AttributeSelector selector -> Selector.stringify(selector)
                | Custom c -> c.ToLower()
                | Media -> "media"
                | NameLabel -> "name-label"
                | Class c -> $"{c}"
                | Id i -> $"{i}"

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

    interface ILengthUnit
    interface ILengthPercentage

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
    /// Rolls back to the value established in a previous cascade layer
    member this.revertLayer = (property, RevertLayer) |> Rule


and Keywords =
    | Inherit
    | Initial
    | Unset
    | Revert
    | RevertLayer
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Inherit -> "inherit"
            | Initial -> "initial"
            | Unset -> "unset"
            | Revert -> "revert"
            | RevertLayer -> "revert-layer"

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

type PseudoMaster =
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
        member this.StringifyCss() =
            match this with
            | CombinatorMaster rules -> stringifyList rules

type DividerMaster =
    | DividerMaster of string * string
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | DividerMaster (a, b) -> $"{a}/{b}"

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

type ClassnameMaster =
    | ClassnameMaster of Rule list
    // used to create classname
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | ClassnameMaster rules -> stringifyList rules

type IdMaster =
    | IdMaster of Rule list
    // used to create classname
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | IdMaster rules -> stringifyList rules


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
