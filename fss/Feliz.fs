namespace Feliz.Fss

open Feliz
open Fss
open Fss.Keyframes
open Fss.Media
open Fss.Word


[<AutoOpen>]
module fss =
    // Todo: FIX
    module FontTypes = FontTypes
    // Todo: FIX
    module Counter = Counter
    type prop with
        static member css (properties: CSSProperty list) =
            prop.className (fss properties)
    type CssColor = CssColor.CssColor
    type CssInt = Global.CssInt
    type CssString = Global.CssString
    type CssFloat = Global.CssFloat
    type Transform = TransformType.Transform


    // Keyframes
    let keyframes (attributeList: KeyframeAttribute list) = keyframes attributeList
    let frame (f: int) (properties: CSSProperty list) = frame f properties
    let frames (f: int list) (properties: CSSProperty list) = frames f properties
    let counterStyle (attributeList: CounterProperty list) = counterStyle attributeList
    // Media
    let MediaQueryFor (device: Device) (features: MediaFeature list) (attributeList: CSSProperty list) =
        MediaQueryFor device features attributeList
    let MediaQuery (features: MediaFeature list) (attributeList: CSSProperty list) =
        MediaQuery features attributeList
    // Font
    let fontFace (fontFamily: string) (attributeList: CSSProperty list) = fontFace fontFamily attributeList
    let fontFaces (fontFamily: string) (attributeLists: CSSProperty list list) = fontFaces fontFamily attributeLists
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

    type color = Color
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
    type transform = Transform.Transform
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

    type borderWidth = BordeWidth
    let borderWidth' width = BorderWidth' width

    type borderTopWidth = BordeTopWidth
    let borderTopWidth' width = BorderTopWidth' width

    type borderRightWidth = BordeRightWidth
    let borderRightWidth' width = BorderRightWidth' width

    type borderBottomWidth = BordeBottomWidth
    let borderBottomWidth' width = BorderBottomWidth' width

    type borderLeftWidth = BordeLeftWidth
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
    type display = Display
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
    type resize = Resize
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
    type visibility = Visibility
    let visibility' visibility = Visibility' visibility

    type opacity = Opacity
    let opacity' opacity = Opacity' opacity

    type paintOrder = PaintOrder
    let paintOrder' paintOrder = PaintOrder' paintOrder

    type overFlow = Overflow
    let overFlow' overFlow = Overflow' overFlow

    type overflowX = OverflowX
    let overFlowX' overFlowX = OverflowX' overFlowX

    type overflowY = OverflowY
    let overflowY' overflowY = OverflowY' overflowY

    type overflowWrap = OverflowWrap
    let overflowWrap' overFlowWrap = OverflowWrap' overFlowWrap
