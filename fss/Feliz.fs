namespace Feliz.Fss

open Feliz
open Fss
open Fss.CssColor
open Fss.ScrollBehavior
open Fss.Visibility
open Fss.Word
open FssTypes

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
        static member css (properties: CssProperty list) =
            prop.className (fss properties)
    type CssColor = CssColor.CssColor

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
    let fontFace (fontFamily: string) (attributeList: CssProperty list) = fontFace fontFamily attributeList
    let fontFaces (fontFamily: string) (attributeLists: CssProperty list list) = fontFaces fontFamily attributeLists
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

    let Active attributeList = PseudoClass.Active attributeList
    let AnyLink attributeList = PseudoClass.AnyLink attributeList
    let Blank attributeList = PseudoClass.Blank attributeList
    let Checked attributeList = PseudoClass.Checked attributeList
    let Current attributeList = PseudoClass.Current attributeList
    let Disabled attributeList = PseudoClass.Disabled attributeList
    let Empty attributeList = PseudoClass.Empty attributeList
    let Enabled attributeList = PseudoClass.Enabled attributeList
    let FirstOfType attributeList = PseudoClass.FirstOfType attributeList
    let Focus attributeList = PseudoClass.Focus attributeList
    let FocusVisible attributeList = PseudoClass.FocusVisible attributeList
    let FocusWithin attributeList = PseudoClass.FocusWithin attributeList
    let Future attributeList = PseudoClass.Future attributeList
    let Hover attributeList = PseudoClass.Hover attributeList
    let Indeterminate attributeList = PseudoClass.Indeterminate attributeList
    let Invalid attributeList = PseudoClass.Invalid attributeList
    let InRange attributeList = PseudoClass.InRange attributeList
    let Lang language attributeList = PseudoClass.Lang language attributeList
    let LastChild attributeList = PseudoClass.LastChild attributeList
    let LastOfType attributeList = PseudoClass.LastOfType attributeList
    let LocalLink attributeList = PseudoClass.LocalLink attributeList
    let Link attributeList = PseudoClass.Link attributeList
    let NthChild n attributeList = PseudoClass.NthChild n attributeList
    let NthLastChild n attributeList = PseudoClass.NthLastChild n attributeList
    let NthLastOfType n attributeList = PseudoClass.NthLastOfType n attributeList
    let NthOfType attributeList = PseudoClass.NthOfType attributeList
    let OnlyChild attributeList = PseudoClass.OnlyChild attributeList
    let OnlyOfType attributeList = PseudoClass.OnlyOfType attributeList
    let Optional attributeList = PseudoClass.Optional attributeList
    let OutOfRange attributeList = PseudoClass.OutOfRange attributeList
    let Past attributeList = PseudoClass.Past attributeList
    let Playing attributeList = PseudoClass.Playing attributeList
    let Paused attributeList = PseudoClass.Paused attributeList
    let PlaceholderShown attributeList = PseudoClass.PlaceholderShown attributeList
    let ReadOnly attributeList = PseudoClass.ReadOnly attributeList
    let ReadWrite attributeList = PseudoClass.ReadWrite attributeList
    let Required attributeList = PseudoClass.Required attributeList
    let Root attributeList = PseudoClass.Root attributeList
    let Scope attributeList = PseudoClass.Scope attributeList
    let Target attributeList = PseudoClass.Target attributeList
    let TargetWithin attributeList = PseudoClass.TargetWithin attributeList
    let Valid attributeList = PseudoClass.Valid attributeList
    let Visited attributeList = PseudoClass.Visited attributeList
    let FirstChild attributeList = PseudoClass.FirstChild attributeList
    let UserInvalid attributeList = PseudoClass.UserInvalid attributeList
    // PseudoElement
    let After       attributeList = PseudoElement.After attributeList
    let Before      attributeList = PseudoElement.Before attributeList
    let FirstLetter attributeList = PseudoElement.FirstLetter attributeList
    let FirstLine   attributeList = PseudoElement.FirstLine attributeList
    let Selection   attributeList = PseudoElement.Selection attributeList
    let Marker      attributeList = PseudoElement.Marker attributeList


[<RequireQualifiedAccess>]
module style =
    // Animation
    type animationDelay = AnimationDelay
    let animationDelay' delay = AnimationDelay' delay

    type animationDirection = Fss.Animation.AnimationDirection
    let animationDirection' direction = AnimationDirection' direction

    type animationDuration = AnimationDuration
    let animationDuration' duration = AnimationDuration' duration

    type animationFillMode = Fss.Animation.AnimationFillMode
    let animationFillMode' fillMode = AnimationFillMode' fillMode

    type animationIterationCount = AnimationIterationCount
    let animationIterationCount' count = AnimationIterationCount' count

    type animationName = AnimationName
    let animationName' name = AnimationName' name

    type animationPlayState = Fss.Animation.AnimationPlayState
    let animationPlayState' playState = AnimationName' playState

    type animationTimingFunction = AnimationTimingFunction
    let animationTimingFunction' timing = AnimationTimingFunction' timing

    // Custom
    let custom (key: string) (value: string) = Functions.Custom key value

    // Background
    type backgroundClip = BackgroundClip
    let backgroundClip' clip = BackgroundClip' clip

    type backgroundOrigin = Background.BackgroundOrigin
    let backgroundOrigin' origin = BackgroundOrigin' origin

    type backgroundRepeat = Background.BackgroundRepeat
    let backgroundRepeat' repeat = BackgroundRepeat' repeat

    type backgroundSize = Background.BackgroundSize
    let backgroundSize' size = BackgroundSize' size

    type backgroundAttachment = Background.BackgroundAttachment
    let backgroundAttachment' attachment = BackgroundAttachment' attachment

    type backgroundColor = BackgroundColor
    let backgroundColor' color = BackgroundColor' color

    type backgroundImage = BackgroundImage
    let backgroundImage' image = BackgroundImage' image

    type backgroundPosition = Background.BackgroundPosition
    let backgroundPosition' position = BackgroundPosition' position

    type backgroundBlendMode = Background.BackgroundBlendMode
    let backgroundBlendMode' blendMode = BackgroundBlendMode' blendMode

    type isolation = Background.Isolation
    let isolation' isolation = Isolation' isolation

    // Box
    type boxDecorationBreak = BoxDecorationBreak
    let boxDecorationBreak' decorationBreak = BoxDecorationBreak' decorationBreak

    // Color
    type colorAdjust = ColorAdjust
    let colorAdjust' adjust = ColorAdjust' adjust

    type color = Color
    let color' color = Color' color

    // Font
    type fontSize = Font.FontSize
    let fontSize' size = FontSize' size

    type fontStyle = Font.FontStyle
    let fontStyle' style = FontStyle' style

    type fontStretch = Font.FontStretch
    let fontStretch' stretch = FontStretch' stretch

    type fontWeight = Font.FontWeight
    let fontWeight' weight = FontWeight' weight

    type lineHeight = LineHeight
    let lineHeight' height = LineHeight' height

    type lineBreak = Font.LineBreak
    let lineBreak' ``break`` = LineBreak' ``break``

    type letterSpacing = LetterSpacing
    let letterSpacing' spacing = LetterSpacing' spacing

    type fontDisplay = Font.FontDisplay
    let fontDisplay' display = FontDisplay' display

    type fontFamily = Font.FontFamily
    let fontFamily' family = FontFamily' family

    type fontFeatureSetting = Font.FontFeatureSetting
    let fontFeatureSetting' setting = FontFeatureSetting' setting

    type fontVariantNumeric = Font.FontVariantNumeric
    let fontVariantNumeric' variant = FontVariantNumeric' variant

    type fontVariantCaps = Font.FontVariantCaps
    let fontVariantCaps' caps = FontVariantCaps' caps

    type fontVariantEastAsian = Font.FontVariantEastAsian
    let fontVariantEastAsian' variant = FontVariantEastAsian' variant

    type fontVariantLigatures = Font.FontVariantLigatures
    let fontVariantLigatures' ligature = FontVariantLigatures' ligature

    type fontKerning = Font.FontKerning
    let fontKerning' kerning = FontKerning' kerning

    type fontLanguageOverride = Font.FontLanguageOverride
    let fontLanguageOverride' languageOverride = FontLanguageOverride' languageOverride

    type fontSynthesis = Font.FontSynthesis
    let fontSynthesis' synthesis = FontSynthesis' synthesis

    type fontVariantPosition = Font.FontVariantPosition
    let fontVariantPosition' variantPosition = FontVariantPosition' variantPosition

    // Word
    type wordSpacing = WordSpacing
    let wordSpacing' spacing = WordSpacing' spacing

    type wordBreak = WordBreak
    let wordBreak' ``break`` = WordBreak' ``break``

    // Text
    type textAlign = Text.TextAlign
    let textAlign' align = TextAlign' align

    type textAlignLast = Text.TextAlignLast
    let textAlignLast' align = TextAlignLast' align

    type textDecoration = Text.TextDecoration
    let textDecoration' decoration = TextDecoration' decoration

    type textDecorationLine = Text.TextDecorationLine
    let textDecorationLine' line = TextDecorationLine' line

    type textDecorationThickness = Text.TextDecorationThickness
    let textDecorationThickness' thickness = TextDecorationThickness' thickness

    type textDecorationStyle = Text.TextDecorationStyle
    let textDecorationStyle' style = TextDecorationStyle' style

    type textDecorationSkip = Text.TextDecorationSkip
    let textDecorationSkip' skip = TextDecorationSkip' skip

    type textDecorationSkipInk = Text.TextDecorationSkipInk
    let textDecorationSkipInk' skip = TextDecorationSkipInk' skip

    type textTransform = Text.TextTransform
    let textTransform' transform = TextTransform' transform

    type textIndent = Text.TextIndent
    let textIndent' indent = TextIndent' indent

    type textShadow = Text.TextShadow
    let textShadows shadows = TextShadows shadows

    type textOverflow = Text.TextOverflow
    let textOverflow' overflow = TextOverflow' overflow

    type textEmphasis = Text.TextEmphasis
    let textEmphasis' emphasis = TextEmphasis' emphasis

    type textEmphasisPosition = Text.TextEmphasisPosition
    let textEmphasisPosition' e1 e2 = TextEmphasisPosition' e1 e2

    type textEmphasisStyle = Text.TextEmphasisStyle
    let textEmphasisStyle' style = TextEmphasisStyle' style

    type textUnderlinePosition = Text.TextUnderlinePosition
    let textUnderlinePosition' position = TextUnderlinePosition' position

    type textUnderlineOffset = Text.TextUnderlineOffset
    let textUnderlineOffset' position = TextUnderlineOffset' position

    type quotes = Quotes
    let quotes' position = Quotes' position

    type hyphens = Text.Hyphens
    let hyphens' hyphens = Hyphens' hyphens

    type textDecorationColor = Text.TextDecorationColor
    let textDecorationColor' color = TextDecorationColor' color

    type textEmphasisColor = Text.TextEmphasisColor
    let textEmphasisColor' color = TextEmphasisColor' color

    type textSizeAdjust = Text.TextSizeAdjust
    let textSizeAdjust' color = TextSizeAdjust' color

    type tabSize = TabSize
    let tabSize' size = TabSize' size

    type textOrientation = Text.TextOrientation
    let textOrientation' orientation = TextOrientation' orientation

    type textRendering = Text.TextRendering
    let textRendering' rendering = TextRendering' rendering

    type textJustify = Text.TextJustify
    let textJustify' justify = TextJustify' justify

    type whiteSpace = Text.WhiteSpace
    let whiteSpace' ws = WhiteSpace' ws

    type userSelect = Text.UserSelect
    let userSelect' userSelect = UserSelect' userSelect

    // Transform
    type transform = Transform.Transform
    let transforms transforms = Transforms transforms

    type transformOrigin = Transform.TransformOrigin
    let transformOrigin' origin = Transform.TransformOrigin' origin

    type transformStyle = Transform.TransformStyle
    let transformStyle' style = Transform.TransformStyle' style

    // ListStyle
    type listStyle = ListStyle
    let listStyle' style = ListStyle' style

    type listStyleImage = ListStyle.ListStyleImage
    let listStyleImage' image = ListStyleImage' image

    type listStylePosition = ListStyle.ListStylePosition
    let listStylePosition' position = ListStylePosition' position

    type listStyleType = ListStyle.ListStyleType
    let listStyleType' ``type`` = ListStyleType' ``type``

    // column
    type columnGap = Column.ColumnGap
    let columnGap' column = ColumnGap' column

    type columnSpan = Column.ColumnSpan
    let columnSpan' column = ColumnSpan' column

    type columns = Column.Columns
    let columns' columns = Columns' columns

    type columnRule = Column.ColumnRule
    let columnRule' columnRule = ColumnRule' columnRule

    type columnRuleWidth = Column.ColumnRuleWidth
    let columnRuleWidth' columnRuleWidth = ColumnRuleWidth' columnRuleWidth

    type columnRuleStyle = Column.ColumnRuleStyle
    let columnRuleStyle' columnRuleStyle = ColumnRuleStyle' columnRuleStyle

    type columnRuleColor = Column.ColumnRuleColor
    let columnRuleColor' columnRuleColor = ColumnRuleColor' columnRuleColor

    type columnCount = Column.ColumnCount
    let columnCount' columnCount = ColumnCount' columnCount

    type columnFill = Column.ColumnFill
    let columnFill' columnFill = ColumnFill' columnFill

    type columnWidth = Column.ColumnWidth
    let columnWidth' columnWidth = ColumnWidth' columnWidth

    // border
    type border = Border.Border
    let border' border = Border' border

    type borderRadius = Border.BorderRadius
    let borderRadius' radius = BorderRadius' radius

    type borderBottomLeftRadius = Border.BorderBottomLeftRadius
    let borderBottomLeftRadius' radius = BorderBottomLeftRadius' radius

    type borderBottomRightRadius = Border.BorderBottomRightRadius
    let borderBottomRightRadius' radius = BorderBottomRightRadius' radius

    type borderTopLeftRadius = Border.BorderTopLeftRadius
    let borderTopLeftRadius' radius = BorderTopLeftRadius' radius

    type borderTopRightRadius = Border.BorderTopRightRadius
    let borderTopRightRadius' radius = BorderTopRightRadius' radius

    type borderWidth = Border.BorderWidth
    let borderWidth' width = BorderWidth' width

    type borderTopWidth = Border.BorderTopWidth
    let borderTopWidth' width = BorderTopWidth' width

    type borderRightWidth = Border.BorderRightWidth
    let borderRightWidth' width = BorderRightWidth' width

    type borderBottomWidth = Border.BorderBottomWidth
    let borderBottomWidth' width = BorderBottomWidth' width

    type borderLeftWidth = Border.BorderLeftWidth
    let borderLeftWidth' width = BorderLeftWidth' width

    type borderStyle = Border.BorderStyle
    let borderStyle' style = BorderStyle' style

    type borderTopStyle = Border.BorderTopStyle
    let borderTopStyle' style = BorderTopStyle' style

    type borderRightStyle = Border.BorderRightStyle
    let borderRightStyle' style = BorderRightStyle' style

    type borderBottomStyle = Border.BorderBottomStyle
    let borderBottomStyle' style = BorderBottomStyle' style

    type borderLeftStyle = Border.BorderLeftStyle
    let borderLeftStyle' style = BorderLeftStyle' style

    type borderCollapse = Border.BorderCollapse
    let borderCollapse' collapse = BorderCollapse' collapse

    type borderImageOutset = Border.BorderImageOutset
    let borderImageOutset' outset = BorderImageOutset' outset

    type borderImageRepeat = Border.BorderImageRepeat
    let borderImageRepeat' repeat = BorderImageRepeat' repeat

    type borderImageSlice = Border.BorderImageSlice
    let borderImageSlice' repeat = BorderImageSlice' repeat

    type borderColor = Border.BorderColor
    let borderColor' color = BorderColor' color

    type borderTopColor = Border.BorderTopColor
    let borderTopColor' color = BorderTopColor' color

    type borderRightColor = Border.BorderRightColor
    let borderRightColor' color = BorderRightColor' color

    type borderBottomColor = Border.BorderBottomColor
    let borderBottomColor' color = BorderBottomColor' color

    type borderLeftColor = Border.BorderLeftColor
    let borderLeftColor' color = BorderLeftColor' color

    type borderSpacing = Border.BorderSpacing
    let borderSpacing' spacing = BorderSpacing' spacing

    type borderImageWidth = Border.BorderImageWidth
    let borderImageWidth' imageWidth = BorderImageWidth' imageWidth

    type borderImageSource = Border.BorderImageSource
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

    type overflow = Overflow.Overflow
    let overflow' overFlow = Overflow' overFlow

    type overflowX = Overflow.OverflowX
    let overFlowX' overFlowX = OverflowX' overFlowX

    type overflowY = Overflow.OverflowY
    let overflowY' overflowY = OverflowY' overflowY

    type overflowWrap = Overflow.OverflowWrap
    let overflowWrap' overFlowWrap = OverflowWrap' overFlowWrap

    // Position
    type position = Position.Position
    let position' position = Position' position

    type top = Top
    let top' top = Top' top

    type right = Right
    let right' right = Right' right

    type bottom = Bottom
    let bottom' bottom = Bottom' bottom

    type left = Position.Left
    let left' left = Left' left

    type verticalAlign = Position.VerticalAlign
    let verticalAlign' verticalAlign = VerticalAlign' verticalAlign

    type float = Position.Float
    let float' float = Float' float

    type boxSizing = Position.BoxSizing
    let boxSizing' boxSizing = BoxSizing' boxSizing

    type direction = Position.Direction
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
    type captionSide = Table.CaptionSide
    let captionSide' captionSide = CaptionSide' captionSide

    type emptyCells = Table.EmptyCells
    let emptyCells' emptyCells = EmptyCells' emptyCells

    type tableLayout = Table.TableLayout
    let tableLayout' tableLayout = TableLayout' tableLayout

    // Caret
    type caretColor = CaretColor
    let caretColor' caretColor = CaretColor' caretColor

    // Appearance
    type appearance = Fss.Appearance.Appearance
    let appearance' appearance = Appearance.Appearance' appearance

    // Typography
    type orphans = Orphans
    let orphans' orphans = Orphans' orphans

    type widows = Widows
    let widows' widows = Widows' widows

    // All
    type all = All
    let all' all = All' all

    // Grid
    type repeat = Grid.Repeat
    type minMax = Grid.MinMax

    type gridAutoFlow = Grid.GridAutoFlow
    let gridAutoFlow' gridAutoFlow = GridAutoFlow' gridAutoFlow

    type gridTemplateAreas = Grid.GridTemplateAreas
    let gridTemplateAreas' gridTemplateAreas = GridTemplateAreas' gridTemplateAreas

    type gridGap = Grid.GridGap
    let gridGap' gridGap = GridGap' gridGap

    type gridRowGap = Grid.GridRowGap
    let gridRowGap' gridRowGap = GridRowGap' gridRowGap

    type gridColumnGap = Grid.GridColumnGap
    let gridColumnGap' gridColumnGap = GridColumnGap' gridColumnGap

    type gridPosition = Grid.GridPosition
    let gridPosition' gridPosition = GridPosition' gridPosition

    type gridRowStart = Grid.GridRowStart
    let gridRowStart' gridRowStart = GridRowStart' gridRowStart

    type gridRowEnd = Grid.GridRowEnd
    let gridRowEnd' gridRowEnd = GridRowEnd' gridRowEnd

    type gridRow = Grid.GridRow
    let gridRow' gridRow = GridRow' gridRow

    type gridColumnStart = Grid.GridColumnStart
    let gridColumnStart' gridColumnStart = GridColumnStart' gridColumnStart

    type gridColumnEnd = Grid.GridColumnEnd
    let gridColumnEnd' gridColumnEnd = GridColumnEnd' gridColumnEnd

    type gridColumn = Grid.GridColumn
    let gridColumn' gridColumn = GridColumn' gridColumn

    type gridArea = Grid.GridArea
    let gridArea' gridArea = GridArea' gridArea

    type gridTemplateRows = Grid.GridTemplateRows
    let gridTemplateRows' gridTemplateRows = GridTemplateRows' gridTemplateRows

    type gridTemplateColumns = Grid.GridTemplateColumns
    let gridTemplateColumns' gridTemplateColumns = GridTemplateColumns' gridTemplateColumns

    type gridAutoRows = Grid.GridAutoRows
    let gridAutoRows' gridAutoRows = GridAutoRows' gridAutoRows

    type gridAutoColumns = Grid.GridAutoColumns
    let gridAutoColumns' gridAutoColumns = GridAutoColumns' gridAutoColumns

    // Flex
    type alignContent = Flex.AlignContent
    let alignContent' alignContent = AlignContent' alignContent

    type alignItems = Flex.AlignItems
    let alignItems' alignItems = AlignItems' alignItems

    type alignSelf = Flex.AlignSelf
    let alignSelf' alignSelf = AlignSelf' alignSelf

    type justifyContent = Flex.JustifyContent
    let justifyContent' justifyContent = JustifyContent' justifyContent

    type justifyItems = Flex.JustifyItems
    let justifyItems' justifyItems = JustifyItems' justifyItems

    type justifySelf = Flex.JustifySelf
    let justifySelf' justifySelf = JustifySelf' justifySelf

    type flexDirection = Flex.FlexDirection
    let flexDirection' flexDirection = FlexDirection' flexDirection

    type flexWrap = Flex.FlexWrap
    let flexWrap' flexWrap = FlexWrap' flexWrap

    type order = Order
    let order' order = Order' order

    type flexGrow = Flex.FlexGrow
    let flexGrow' flexGrow = FlexGrow' flexGrow

    type flexShrink = Flex.FlexShrink
    let flexShrink' flexShrink = FlexShrink' flexShrink

    type flexBasis = Flex.FlexBasis
    let flexBasis' flexBasis = FlexBasis' flexBasis

    // Outline
    type outline = Outline.Outline
    let outline' outline = Outline' outline

    type outlineColor = Outline.OutlineColor
    let outlineColor' outlineColor = OutlineColor' outlineColor

    type outlineWidth = Outline.OutlineWidth
    let outlineWidth' outlineWidth = OutlineWidth' outlineWidth

    type outlineStyle = Outline.OutlineStyle
    let outlineStyle' outlineStyle = OutlineStyle' outlineStyle

    type outlineOffset = Outline.OutlineOffset
    let outlineOffset' outlineOffset = OutlineOffset' outlineOffset

    // box shadow
    type boxShadow = BoxShadow
    let boxShadows boxShadows = BoxShadows boxShadows
    let inset shadow = BoxShadow.Inset shadow

    // Scroll
    type scrollBehavior = ScrollBehavior.ScrollBehavior
    let scrollBehavior' scrollBehaviour = ScrollBehavior' scrollBehaviour

    type scrollMargin = ScrollMargin.ScrollMargin
    let scrollMargin' scrollMargin = ScrollMargin' scrollMargin

    type scrollMarginTop = ScrollMargin.ScrollMarginTop
    let scrollMarginTop' scrollMarginTop = ScrollMarginTop' scrollMarginTop

    type scrollMarginRight = ScrollMargin.ScrollMarginRight
    let scrollMarginRight' scrollMarginRight = ScrollMarginRight' scrollMarginRight

    type scrollMarginBottom = ScrollMargin.ScrollMarginBottom
    let scrollMarginBottom' scrollMarginBottom = ScrollMarginBottom' scrollMarginBottom

    type scrollMarginLeft = ScrollMargin.ScrollMarginLeft
    let scrollMarginLeft' scrollMarginLeft = ScrollMarginLeft' scrollMarginLeft

    type scrollPadding = ScrollPadding.ScrollPadding
    let scrollPadding' scrollPadding = ScrollPadding' scrollPadding

    type scrollPaddingTop = ScrollPadding.ScrollPaddingTop
    let scrollPaddingTop' scrollPaddingTop = ScrollPaddingTop' scrollPaddingTop

    type scrollPaddingRight = ScrollPadding.ScrollPaddingRight
    let scrollPaddingRight' scrollPaddingRight = ScrollPaddingRight' scrollPaddingRight

    type scrollPaddingBottom = ScrollPadding.ScrollPaddingBottom
    let scrollPaddingBottom' scrollPaddingBottom = ScrollPaddingBottom' scrollPaddingBottom

    type scrollPaddingLeft = ScrollPadding.ScrollPaddingLeft
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
    type maskClip = Mask.MaskClip
    let maskClip' maskClip = MaskClip' maskClip

    type maskComposite = Mask.MaskComposite
    let maskComposite' maskComposite = MaskComposite' maskComposite

    type maskImage = Mask.MaskImage
    let maskImage' maskImage = MaskImage' maskImage

    type maskMode = Mask.MaskMode
    let maskMode' maskMode = MaskMode' maskMode

    type maskOrigin = Mask.MaskOrigin
    let maskOrigin' maskOrigin = MaskOrigin' maskOrigin

    type maskPosition = Mask.MaskPosition
    let maskPosition' x y = MaskPosition' x y

    type maskRepeat = Mask.MaskRepeat
    let maskRepeat' maskRepeat = MaskRepeat' maskRepeat
