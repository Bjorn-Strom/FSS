namespace Feliz.Fss

open Feliz
open Fss
open Fss.Word

[<RequireQualifiedAccess>]
module Counter =
    type System = Counter.System
    type Negative = Counter.Negative
    type Prefix = Counter.Prefix
    type Suffix = Counter.Suffix
    type Range = Counter.Range
    type Pad = Counter.Pad
    type Symbols = Counter.Symbols
    type AdditiveSymbol = Counter.AdditiveSymbol
    type SpeakAs = Counter.SpeakAs
    type CounterReset = Counter.CounterReset
    type CounterIncrement = Counter.CounterIncrement

[<AutoOpen>]
module fss =
    type prop with
        static member css (properties: FssTypes.CssProperty list) =
            prop.className (fss properties)

    // Keyframes
    let keyframes attributeList = keyframes attributeList
    let frame f properties = frame f properties
    let frames f properties = frames f properties
    // Counter
    let counterStyle attributeList = counterStyle attributeList
    // Media
    let MediaQueryFor device features attributeList =
        MediaQueryFor device features attributeList
    let MediaQuery features attributeList=
        MediaQuery features attributeList
    // Font
    type Format = Format
    type Source = Source
    type FontFace = FontFace.FontFace
    let fontFace (fontFamily: string) (attributeList: FssTypes.CssProperty list) = fontFace fontFamily attributeList
    let fontFaces (fontFamily: string) (attributeLists: FssTypes.CssProperty list list) = fontFaces fontFamily attributeLists
    // Color
    let rgb r g b = rgb r g b
    let rgba r g b a = rgba r g b a
    let hex value = hex value
    let hsl h s l = hsl h s l
    let hsla h s l a = hsla h s l a
    // Sizes
    let px v = px v
    let inc v = inc v
    let cm v = cm v
    let mm v = mm v
    let pt v = pt v
    let pc v = pc v
    let em v = em v
    let rem v = rem v
    let ex v = ex v
    let ch v = ch v
    let vw v = vw v
    let vh v = vh v
    let vmax v = vmax v
    let vmin v = vmin v
    let deg v = deg v
    let grad v = grad v
    let rad v = rad v
    let turn v = turn v
    let pct v = pct v
    let sec v = sec v
    let ms v = ms v
    let fr v = fr v

    // Selectors
    let (!+) html propertyList = !+ html propertyList
    let (!~) html propertyList = !~ html propertyList
    let (!>) html propertyList = !> html propertyList
    let (! ) html propertyList = ! html propertyList

    // PseudoClass

    let Active attributeList = Active attributeList
    let AnyLink attributeList = AnyLink attributeList
    let Blank attributeList = Blank attributeList
    let Checked attributeList = Checked attributeList
    let Current attributeList = Current attributeList
    let Disabled attributeList = Disabled attributeList
    let Empty attributeList = Empty attributeList
    let Enabled attributeList = Enabled attributeList
    let FirstOfType attributeList = FirstOfType attributeList
    let Focus attributeList = Focus attributeList
    let FocusVisible attributeList = FocusVisible attributeList
    let FocusWithin attributeList = FocusWithin attributeList
    let Future attributeList = Future attributeList
    let Hover attributeList = Hover attributeList
    let Indeterminate attributeList = Indeterminate attributeList
    let Invalid attributeList = Invalid attributeList
    let InRange attributeList = InRange attributeList
    let Lang language attributeList = Lang language attributeList
    let LastChild attributeList = LastChild attributeList
    let LastOfType attributeList = LastOfType attributeList
    let LocalLink attributeList = LocalLink attributeList
    let Link attributeList = Link attributeList
    let NthChild n attributeList = NthChild n attributeList
    let NthLastChild n attributeList = NthLastChild n attributeList
    let NthLastOfType n attributeList = NthLastOfType n attributeList
    let NthOfType attributeList = NthOfType attributeList
    let OnlyChild attributeList = OnlyChild attributeList
    let OnlyOfType attributeList = OnlyOfType attributeList
    let Optional attributeList = Optional attributeList
    let OutOfRange attributeList = OutOfRange attributeList
    let Past attributeList = Past attributeList
    let Playing attributeList = Playing attributeList
    let Paused attributeList = Paused attributeList
    let PlaceholderShown attributeList = PlaceholderShown attributeList
    let ReadOnly attributeList = ReadOnly attributeList
    let ReadWrite attributeList = ReadWrite attributeList
    let Required attributeList = Required attributeList
    let Root attributeList = Root attributeList
    let Scope attributeList = Scope attributeList
    let Target attributeList = Target attributeList
    let TargetWithin attributeList = TargetWithin attributeList
    let Valid attributeList = Valid attributeList
    let Visited attributeList = Visited attributeList
    let FirstChild attributeList = FirstChild attributeList
    let UserInvalid attributeList = UserInvalid attributeList
    // PseudoElement
    let After       attributeList = After attributeList
    let Before      attributeList = Before attributeList
    let FirstLetter attributeList = FirstLetter attributeList
    let FirstLine   attributeList = FirstLine attributeList
    let Selection   attributeList = Selection attributeList
    let Marker      attributeList = Marker attributeList


[<RequireQualifiedAccess>]
module style =
    // Animation
    type animationDelay = AnimationDelay
    let animationDelay' delay = AnimationDelay' delay

    type animationDirection = AnimationDirection
    let animationDirection' direction = AnimationDirection' direction

    type animationDuration = AnimationDuration
    let animationDuration' duration = AnimationDuration' duration

    type animationFillMode = AnimationFillMode
    let animationFillMode' fillMode = AnimationFillMode' fillMode

    type animationIterationCount = AnimationIterationCount
    let animationIterationCount' count = AnimationIterationCount' count

    type animationName = AnimationName
    let animationName' name = AnimationName' name

    type animationPlayState = AnimationPlayState
    let animationPlayState' playState = AnimationName' playState

    type animationTimingFunction = AnimationTimingFunction
    let animationTimingFunction' timing = AnimationTimingFunction' timing

    // Custom
    let custom (key: string) (value: string) = Custom key value

    // Background
    type backgroundClip = BackgroundClip
    let backgroundClip' clip = BackgroundClip' clip

    type backgroundOrigin = BackgroundOrigin
    let backgroundOrigin' origin = BackgroundOrigin' origin

    type backgroundRepeat = BackgroundRepeat
    let backgroundRepeat' repeat = BackgroundRepeat' repeat

    type backgroundSize = BackgroundSize
    let backgroundSize' size = BackgroundSize' size

    type backgroundAttachment = BackgroundAttachment
    let backgroundAttachment' attachment = BackgroundAttachment' attachment

    type backgroundColor = BackgroundColor
    let backgroundColor' color = BackgroundColor' color

    type backgroundImage = BackgroundImage
    let backgroundImage' image = BackgroundImage' image

    type backgroundPosition = BackgroundPosition
    let backgroundPosition' position = BackgroundPosition' position

    type backgroundBlendMode = BackgroundBlendMode
    let backgroundBlendMode' blendMode = BackgroundBlendMode' blendMode

    type isolation = Isolation
    let isolation' isolation = Isolation' isolation

    // Box
    type boxDecorationBreak = BoxDecorationBreak
    let boxDecorationBreak' decorationBreak = BoxDecorationBreak' decorationBreak

    // Color
    type colorAdjust = ColorAdjust
    let colorAdjust' adjust = ColorAdjust' adjust

    type color = Color.Color
    let color' color = Color' color

    // Font
    type fontSize = FontSize
    let fontSize' size = FontSize' size

    type fontStyle = FontStyle
    let fontStyle' style = FontStyle' style

    type fontStretch = FontStretch
    let fontStretch' stretch = FontStretch' stretch

    type fontWeight = FontWeight
    let fontWeight' weight = FontWeight' weight

    type lineHeight = LineHeight
    let lineHeight' height = LineHeight' height

    type lineBreak = LineBreak
    let lineBreak' ``break`` = LineBreak' ``break``

    type letterSpacing = LetterSpacing
    let letterSpacing' spacing = LetterSpacing' spacing

    type fontDisplay = FontDisplay
    let fontDisplay' display = FontDisplay' display

    type fontFamily = FontFamily
    let fontFamily' family = FontFamily' family

    type fontFeatureSetting = FontFeatureSetting
    let fontFeatureSetting' setting = FontFeatureSetting' setting

    type fontVariantNumeric = FontVariantNumeric
    let fontVariantNumeric' variant = FontVariantNumeric' variant

    type fontVariantCaps = FontVariantCaps
    let fontVariantCaps' caps = FontVariantCaps' caps

    type fontVariantEastAsian = FontVariantEastAsian
    let fontVariantEastAsian' variant = FontVariantEastAsian' variant

    type fontVariantLigatures = FontVariantLigatures
    let fontVariantLigatures' ligature = FontVariantLigatures' ligature

    type fontKerning = FontKerning
    let fontKerning' kerning = FontKerning' kerning

    type fontLanguageOverride = FontLanguageOverride
    let fontLanguageOverride' languageOverride = FontLanguageOverride' languageOverride

    type fontSynthesis = FontSynthesis
    let fontSynthesis' synthesis = FontSynthesis' synthesis

    type fontVariantPosition = FontVariantPosition
    let fontVariantPosition' variantPosition = FontVariantPosition' variantPosition

    // Word
    type wordSpacing = WordSpacing
    let wordSpacing' spacing = WordSpacing' spacing

    type wordBreak = WordBreak
    let wordBreak' ``break`` = WordBreak' ``break``

    // Text
    type textAlign = TextAlign
    let textAlign' align = TextAlign' align

    type textAlignLast = TextAlignLast
    let textAlignLast' align = TextAlignLast' align

    type textDecoration = TextDecoration
    let textDecoration' decoration = TextDecoration' decoration

    type textDecorationLine = TextDecorationLine
    let textDecorationLine' line = TextDecorationLine' line

    type textDecorationThickness = TextDecorationThickness
    let textDecorationThickness' thickness = TextDecorationThickness' thickness

    type textDecorationStyle = TextDecorationStyle
    let textDecorationStyle' style = TextDecorationStyle' style

    type textDecorationSkip = TextDecorationSkip
    let textDecorationSkip' skip = TextDecorationSkip' skip

    type textDecorationSkipInk = TextDecorationSkipInk
    let textDecorationSkipInk' skip = TextDecorationSkipInk' skip

    type textTransform = TextTransform
    let textTransform' transform = TextTransform' transform

    type textIndent = TextIndent
    let textIndent' indent = TextIndent' indent

    type textShadow = TextShadow
    let textShadows shadows = TextShadows shadows

    type textOverflow = TextOverflow
    let textOverflow' overflow = TextOverflow' overflow

    type textEmphasis = TextEmphasis
    let textEmphasis' emphasis = TextEmphasis' emphasis

    type textEmphasisPosition = TextEmphasisPosition
    let textEmphasisPosition' e1 e2 = TextEmphasisPosition' e1 e2

    type textEmphasisStyle = TextEmphasisStyle
    let textEmphasisStyle' style = TextEmphasisStyle' style

    type textUnderlinePosition = TextUnderlinePosition
    let textUnderlinePosition' position = TextUnderlinePosition' position

    type textUnderlineOffset = TextUnderlineOffset
    let textUnderlineOffset' position = TextUnderlineOffset' position

    type quotes = Quotes
    let quotes' position = Quotes' position

    type hyphens = Hyphens
    let hyphens' hyphens = Hyphens' hyphens

    type textDecorationColor = TextDecorationColor
    let textDecorationColor' color = TextDecorationColor' color

    type textEmphasisColor = TextEmphasisColor
    let textEmphasisColor' color = TextEmphasisColor' color

    type textSizeAdjust = TextSizeAdjust
    let textSizeAdjust' color = TextSizeAdjust' color

    type tabSize = TabSize
    let tabSize' size = TabSize' size

    type textOrientation = TextOrientation
    let textOrientation' orientation = TextOrientation' orientation

    type textRendering = TextRendering
    let textRendering' rendering = TextRendering' rendering

    type textJustify = TextJustify
    let textJustify' justify = TextJustify' justify

    type whiteSpace = WhiteSpace
    let whiteSpace' ws = WhiteSpace' ws

    type userSelect = UserSelect
    let userSelect' userSelect = UserSelect' userSelect

    // Transform
    type transform = Transform
    let transforms transforms = Transforms transforms

    type transformOrigin = TransformOrigin
    let transformOrigin' origin = TransformOrigin' origin

    type transformStyle = TransformStyle
    let transformStyle' style = TransformStyle' style

    // ListStyle
    type listStyle = ListStyle
    let listStyle' style = ListStyle' style

    type listStyleImage = ListStyleImage
    let listStyleImage' image = ListStyleImage' image

    type listStylePosition = ListStylePosition
    let listStylePosition' position = ListStylePosition' position

    type listStyleType = ListStyleType
    let listStyleType' ``type`` = ListStyleType' ``type``

    // column
    type columnGap = ColumnGap
    let columnGap' column = ColumnGap' column

    type columnSpan = ColumnSpan
    let columnSpan' column = ColumnSpan' column

    type columns = Columns
    let columns' columns = Columns' columns

    type columnRule = ColumnRule
    let columnRule' columnRule = ColumnRule' columnRule

    type columnRuleWidth = ColumnRuleWidth
    let columnRuleWidth' columnRuleWidth = ColumnRuleWidth' columnRuleWidth

    type columnRuleStyle = ColumnRuleStyle
    let columnRuleStyle' columnRuleStyle = ColumnRuleStyle' columnRuleStyle

    type columnRuleColor = ColumnRuleColor
    let columnRuleColor' columnRuleColor = ColumnRuleColor' columnRuleColor

    type columnCount = ColumnCount
    let columnCount' columnCount = ColumnCount' columnCount

    type columnFill = ColumnFill
    let columnFill' columnFill = ColumnFill' columnFill

    type columnWidth = ColumnWidth
    let columnWidth' columnWidth = ColumnWidth' columnWidth

    // border
    type border = Border
    let border' border = Border' border

    type borderRadius = BorderRadius
    let borderRadius' radius = BorderRadius' radius

    type borderBottomLeftRadius = BorderBottomLeftRadius
    let borderBottomLeftRadius' radius = BorderBottomLeftRadius' radius

    type borderBottomRightRadius = BorderBottomRightRadius
    let borderBottomRightRadius' radius = BorderBottomRightRadius' radius

    type borderTopLeftRadius = BorderTopLeftRadius
    let borderTopLeftRadius' radius = BorderTopLeftRadius' radius

    type borderTopRightRadius = BorderTopRightRadius
    let borderTopRightRadius' radius = BorderTopRightRadius' radius

    type borderWidth = BorderWidth
    let borderWidth' width = BorderWidth' width

    type borderTopWidth = BorderTopWidth
    let borderTopWidth' width = BorderTopWidth' width

    type borderRightWidth = BorderRightWidth
    let borderRightWidth' width = BorderRightWidth' width

    type borderBottomWidth = BorderBottomWidth
    let borderBottomWidth' width = BorderBottomWidth' width

    type borderLeftWidth = BorderLeftWidth
    let borderLeftWidth' width = BorderLeftWidth' width

    type borderStyle = BorderStyle
    let borderStyle' style = BorderStyle' style

    type borderTopStyle = BorderTopStyle
    let borderTopStyle' style = BorderTopStyle' style

    type borderRightStyle = BorderRightStyle
    let borderRightStyle' style = BorderRightStyle' style

    type borderBottomStyle = BorderBottomStyle
    let borderBottomStyle' style = BorderBottomStyle' style

    type borderLeftStyle = BorderLeftStyle
    let borderLeftStyle' style = BorderLeftStyle' style

    type borderCollapse = BorderCollapse
    let borderCollapse' collapse = BorderCollapse' collapse

    type borderImageOutset = BorderImageOutset
    let borderImageOutset' outset = BorderImageOutset' outset

    type borderImageRepeat = BorderImageRepeat
    let borderImageRepeat' repeat = BorderImageRepeat' repeat

    type borderImageSlice = BorderImageSlice
    let borderImageSlice' repeat = BorderImageSlice' repeat

    type borderColor = BorderColor
    let borderColor' color = BorderColor' color

    type borderTopColor = BorderTopColor
    let borderTopColor' color = BorderTopColor' color

    type borderRightColor = BorderRightColor
    let borderRightColor' color = BorderRightColor' color

    type borderBottomColor = BorderBottomColor
    let borderBottomColor' color = BorderBottomColor' color

    type borderLeftColor = BorderLeftColor
    let borderLeftColor' color = BorderLeftColor' color

    type borderSpacing = BorderSpacing
    let borderSpacing' spacing = BorderSpacing' spacing

    type borderImageWidth = BorderImageWidth
    let borderImageWidth' imageWidth = BorderImageWidth' imageWidth

    type borderImageSource = BorderImageSource
    let borderImageSource' imageSource = BorderImageSource' imageSource

    // Transition
    type transition = Transition
    let transition' transition = Transition' transition

    type transitionDelay = TransitionDelay
    let transitionDelay' delay = TransitionDelay' delay

    type transitionDuration = TransitionDuration
    let transitionDuration' duration = TransitionDuration' duration

    type transitionTimingFunction = TransitionTimingFunction
    let transitionTimingFunction' timing = TransitionTimingFunction' timing

    type transitionProperty = TransitionProperty
    let transitionProperty' property = TransitionProperty' property

    // Display
    type display = Display.Display
    let display' display = Display' display

    // Margin
    type margin = Margin
    let margin' margin = Margin' margin

    type marginTop = MarginTop
    let marginTop' top = MarginTop' top

    type marginRight = MarginRight
    let marginRight' right = MarginRight' right

    type marginBottom = MarginBottom
    let marginBottom' bottom = MarginBottom' bottom

    type marginLeft = MarginLeft
    let marginLeft' left = MarginLeft' left

    type marginInlineStart = MarginInlineStart
    let marginInlineStart' margin = MarginInlineStart' margin

    type marginInlineEnd = MarginInlineEnd
    let marginInlineEnd' margin = MarginInlineEnd' margin

    type marginBlockStart = MarginBlockStart
    let marginBlockStart' margin = MarginBlockStart' margin

    type marginBlockEnd = MarginBlockEnd
    let marginBlockEnd' margin = MarginBlockEnd' margin

    // Padding
    type padding = Padding
    let padding' padding = Padding' padding

    type paddingTop = PaddingTop
    let paddingTop' top = PaddingTop' top

    type paddingRight = PaddingRight
    let paddingRight' right = PaddingRight' right

    type paddingBottom = PaddingBottom
    let paddingBottom' bottom = PaddingBottom' bottom

    type paddingLeft = PaddingLeft
    let paddingLeft' left = PaddingLeft' left

    type paddingInlineStart = PaddingInlineStart
    let paddingInlineStart' padding = PaddingInlineStart' padding

    type paddingInlineEnd = PaddingInlineEnd
    let paddingInlineEnd' padding = PaddingInlineEnd' padding

    type paddingBlockStart = PaddingBlockStart
    let paddingBlockStart' padding = PaddingBlockStart' padding

    type paddingBlockEnd = PaddingBlockEnd
    let paddingBlockEnd' padding = PaddingBlockEnd' padding

    // Resize
    type resize = Resize.Resize
    let resize' resize = Resize' resize

    // Content Size
    type width = Width
    let width' width = Width' width

    type minWidth = MinWidth
    let minWidth' width = MinWidth' width

    type maxWidth = MaxWidth
    let maxWidth' width = MaxWidth' width

    type height = Height
    let height' height = Height' height

    type minHeight = MinHeight
    let minHeight' height = MinHeight' height

    type maxHeight = MaxHeight
    let maxHeight' height = MaxHeight' height

    // Visibility
    type visibility = Visibility.Visibility
    let visibility' visibility = Visibility' visibility

    type opacity = Opacity
    let opacity' opacity = Opacity' opacity

    type paintOrder = PaintOrder.PaintOrder
    let paintOrder' paintOrder = PaintOrder' paintOrder

    type overflow = Overflow
    let overflow' overFlow = Overflow' overFlow

    type overflowX = OverflowX
    let overFlowX' overFlowX = OverflowX' overFlowX

    type overflowY = OverflowY
    let overflowY' overflowY = OverflowY' overflowY

    type overflowWrap = OverflowWrap
    let overflowWrap' overFlowWrap = OverflowWrap' overFlowWrap

    // Position
    type position = Position
    let position' position = Position' position

    type top = Top
    let top' top = Top' top

    type right = Right
    let right' right = Right' right

    type bottom = Bottom
    let bottom' bottom = Bottom' bottom

    type left = Left
    let left' left = Left' left

    type verticalAlign = VerticalAlign
    let verticalAlign' verticalAlign = VerticalAlign' verticalAlign

    type float = Float
    let float' float = Float' float

    type boxSizing = BoxSizing
    let boxSizing' boxSizing = BoxSizing' boxSizing

    type direction = Direction
    let direction' direction = Direction' direction

    type writingMode = WritingMode
    let writingMode' writingMode = WritingMode' writingMode

    type breakAfter = BreakAfter
    let breakAfter' breakAfter = BreakAfter' breakAfter

    type breakBefore = BreakBefore
    let breakBefore' breakBefore = BreakBefore' breakBefore

    type breakInside = BreakInside
    let breakInside' breakInside = BreakInside' breakInside

    // Perspective
    type perspective = Perspective
    let perspective' perspective = Perspective' perspective

    type perspectiveOrigin = PerspectiveOrigin
    let perspectiveOrigin' perspectiveOrigin = PerspectiveOrigin' perspectiveOrigin

    type backfaceVisibility = BackfaceVisibility
    let backfaceVisibility' backfaceVisibility = BackfaceVisibility' backfaceVisibility

    // Pointer events
    type pointerEvents = PointerEvents.PointerEvents
    let pointerEvents' pointerEvents = PointerEvents' pointerEvents

    // Cursor
    type cursor = Cursor.Cursor
    let cursor' cursor = Cursor' cursor

    // Content
    type content = Content.Content
    let content' content = Content' content

    type label = Label
    let label' label = Label' label

    // Table
    type captionSide = CaptionSide
    let captionSide' captionSide = CaptionSide' captionSide

    type emptyCells = EmptyCells
    let emptyCells' emptyCells = EmptyCells' emptyCells

    type tableLayout = TableLayout
    let tableLayout' tableLayout = TableLayout' tableLayout

    // Caret
    type caretColor = CaretColor
    let caretColor' caretColor = CaretColor' caretColor

    // Appearance
    type appearance = Appearance.Appearance
    let appearance' appearance = Appearance' appearance

    // Typography
    type orphans = Orphans
    let orphans' orphans = Orphans' orphans

    type widows = Widows
    let widows' widows = Widows' widows

    // All
    type all = All
    let all' all = All' all

    // Grid
    type repeat = FssTypes.Grid.Repeat
    type minMax = FssTypes.Grid.MinMax

    type gridAutoFlow = GridAutoFlow
    let gridAutoFlow' gridAutoFlow = GridAutoFlow' gridAutoFlow

    type gridTemplateAreas = GridTemplateAreas
    let gridTemplateAreas' gridTemplateAreas = GridTemplateAreas' gridTemplateAreas

    type gridGap = GridGap
    let gridGap' gridGap = GridGap' gridGap

    type gridRowGap = GridRowGap
    let gridRowGap' gridRowGap = GridRowGap' gridRowGap

    type gridColumnGap = GridColumnGap
    let gridColumnGap' gridColumnGap = GridColumnGap' gridColumnGap

    type gridPosition = GridPosition
    let gridPosition' gridPosition = GridPosition' gridPosition

    type gridRowStart = GridRowStart
    let gridRowStart' gridRowStart = GridRowStart' gridRowStart

    type gridRowEnd = GridRowEnd
    let gridRowEnd' gridRowEnd = GridRowEnd' gridRowEnd

    type gridRow = GridRow
    let gridRow' gridRow = GridRow' gridRow

    type gridColumnStart = GridColumnStart
    let gridColumnStart' gridColumnStart = GridColumnStart' gridColumnStart

    type gridColumnEnd = GridColumnEnd
    let gridColumnEnd' gridColumnEnd = GridColumnEnd' gridColumnEnd

    type gridColumn = GridColumn
    let gridColumn' gridColumn = GridColumn' gridColumn

    type gridArea = GridArea
    let gridArea' gridArea = GridArea' gridArea

    type gridTemplateRows = GridTemplateRows
    let gridTemplateRows' gridTemplateRows = GridTemplateRows' gridTemplateRows

    type gridTemplateColumns = GridTemplateColumns
    let gridTemplateColumns' gridTemplateColumns = GridTemplateColumns' gridTemplateColumns

    type gridAutoRows = GridAutoRows
    let gridAutoRows' gridAutoRows = GridAutoRows' gridAutoRows

    type gridAutoColumns = GridAutoColumns
    let gridAutoColumns' gridAutoColumns = GridAutoColumns' gridAutoColumns

    // Flex
    type alignContent = AlignContent
    let alignContent' alignContent = AlignContent' alignContent

    type alignItems = AlignItems
    let alignItems' alignItems = AlignItems' alignItems

    type alignSelf = AlignSelf
    let alignSelf' alignSelf = AlignSelf' alignSelf

    type justifyContent = JustifyContent
    let justifyContent' justifyContent = JustifyContent' justifyContent

    type justifyItems = JustifyItems
    let justifyItems' justifyItems = JustifyItems' justifyItems

    type justifySelf = JustifySelf
    let justifySelf' justifySelf = JustifySelf' justifySelf

    type flexDirection = FlexDirection
    let flexDirection' flexDirection = FlexDirection' flexDirection

    type flexWrap = FlexWrap
    let flexWrap' flexWrap = FlexWrap' flexWrap

    type order = Order
    let order' order = Order' order

    type flexGrow = FlexGrow
    let flexGrow' flexGrow = FlexGrow' flexGrow

    type flexShrink = FlexShrink
    let flexShrink' flexShrink = FlexShrink' flexShrink

    type flexBasis = FlexBasis
    let flexBasis' flexBasis = FlexBasis' flexBasis

    // Outline
    type outline = Outline
    let outline' outline = Outline' outline

    type outlineColor = OutlineColor
    let outlineColor' outlineColor = OutlineColor' outlineColor

    type outlineWidth = OutlineWidth
    let outlineWidth' outlineWidth = OutlineWidth' outlineWidth

    type outlineStyle = OutlineStyle
    let outlineStyle' outlineStyle = OutlineStyle' outlineStyle

    type outlineOffset = OutlineOffset
    let outlineOffset' outlineOffset = OutlineOffset' outlineOffset

    // box shadow
    type boxShadow = BoxShadow
    let boxShadows boxShadows = BoxShadows boxShadows
    let inset shadow = Inset shadow

    // Scroll
    type scrollBehavior = ScrollBehavior.ScrollBehavior
    let scrollBehavior' scrollBehaviour = ScrollBehavior' scrollBehaviour

    type scrollMargin = ScrollMargin
    let scrollMargin' scrollMargin = ScrollMargin' scrollMargin

    type scrollMarginTop = ScrollMarginTop
    let scrollMarginTop' scrollMarginTop = ScrollMarginTop' scrollMarginTop

    type scrollMarginRight = ScrollMarginRight
    let scrollMarginRight' scrollMarginRight = ScrollMarginRight' scrollMarginRight

    type scrollMarginBottom = ScrollMarginBottom
    let scrollMarginBottom' scrollMarginBottom = ScrollMarginBottom' scrollMarginBottom

    type scrollMarginLeft = ScrollMarginLeft
    let scrollMarginLeft' scrollMarginLeft = ScrollMarginLeft' scrollMarginLeft

    type scrollPadding = ScrollPadding
    let scrollPadding' scrollPadding = ScrollPadding' scrollPadding

    type scrollPaddingTop = ScrollPaddingTop
    let scrollPaddingTop' scrollPaddingTop = ScrollPaddingTop' scrollPaddingTop

    type scrollPaddingRight = ScrollPaddingRight
    let scrollPaddingRight' scrollPaddingRight = ScrollPaddingRight' scrollPaddingRight

    type scrollPaddingBottom = ScrollPaddingBottom
    let scrollPaddingBottom' scrollPaddingBottom = ScrollPaddingBottom' scrollPaddingBottom

    type scrollPaddingLeft = ScrollPaddingLeft
    let scrollPaddingLeft' scrollPaddingLeft = ScrollPaddingLeft' scrollPaddingLeft

    type overscrollBehaviorX = OverscrollBehaviorX
    let overscrollBehaviorX' overscrollBehaviorX = OverscrollBehaviorX' overscrollBehaviorX

    type overscrollBehaviorY = OverscrollBehaviorY
    let overscrollBehaviorY' overscrollBehaviorY = OverscrollBehaviorY' overscrollBehaviorY

    // Clip path
    type clipPath = ClipPath

    // Clear
    type clear = Clear.Clear
    let clear' clear = Clear' clear

    // filter
    type filter = Filter.Filter
    let filters filters = Filters filters

    type backdropFilter = BackdropFilter.BackdropFilter
    let backdropFilters backdropFilters = BackdropFilters backdropFilters

    // Mix blend mode
    type mixBlendMode = MixBlendMode.MixBlendMode
    let mixBlendMode' mixBlendMode = MixBlendMode' mixBlendMode

    // aspect ratio
    type aspectRatio = AspectRatio
    let aspectRatio' aspectRatio = AspectRatio' aspectRatio

    // Mask
    type maskClip = MaskClip
    let maskClip' maskClip = MaskClip' maskClip

    type maskComposite = MaskComposite
    let maskComposite' maskComposite = MaskComposite' maskComposite

    type maskImage = MaskImage
    let maskImage' maskImage = MaskImage' maskImage

    type maskMode = MaskMode
    let maskMode' maskMode = MaskMode' maskMode

    type maskOrigin = MaskOrigin
    let maskOrigin' maskOrigin = MaskOrigin' maskOrigin

    type maskPosition = MaskPosition
    let maskPosition' x y = MaskPosition' x y

    type maskRepeat = MaskRepeat
    let maskRepeat' maskRepeat = MaskRepeat' maskRepeat
