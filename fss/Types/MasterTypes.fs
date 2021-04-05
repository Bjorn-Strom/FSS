namespace Fss
// Interfaces
namespace Fss.FssTypes
    type IAnimationDirection      = interface end
    type IAnimationFillMode       = interface end
    type IAnimationPlayState      = interface end
    type IAnimationIterationCount = interface end
    type IAnimationName           = interface end

    type IColor = interface end

    type IColorStop = interface end

    type ILengthPercentage = interface end

    type ITemplateType = interface end

    type IFontSize             = interface end
    type IFontStyle            = interface end
    type IFontStretch          = interface end
    type IFontWeight           = interface end
    type IFontDisplay          = interface end
    type IFontFamily           = interface end
    type IFontFeatureSetting   = interface end
    type IFontVariantNumeric   = interface end
    type IFontVariantCaps      = interface end
    type IFontVariantEastAsian = interface end
    type IFontVariantLigature  = interface end
    type IFontVariantPosition  = interface end
    type IFontKerning          = interface end
    type IFontSynthesis        = interface end
    type IFontLanguageOverride = interface end
    type ILineHeight           = interface end
    type ILineBreak            = interface end
    type ILetterSpacing        = interface end

    type ITextAlign               = interface end
    type ITextAlignLast           = interface end
    type ITextDecoration          = interface end
    type ITextDecorationLine      = interface end
    type ITextDecorationThickness = interface end
    type ITextDecorationStyle     = interface end
    type ITextDecorationSkip      = interface end
    type ITextDecorationSkipInk   = interface end
    type ITextTransform           = interface end
    type ITextIndent              = interface end
    type ITextEmphasis            = interface end
    type ITextEmphasisPosition    = interface end
    type ITextEmphasisStyle       = interface end
    type ITextUnderlinePosition   = interface end
    type ITextUnderlineOffset     = interface end
    type ITextOverflow            = interface end
    type IQuotes                  = interface end
    type IHyphens                 = interface end
    type ITextDecorationColor     = interface end
    type ITextEmphasisColor       = interface end
    type ITextSizeAdjust          = interface end
    type ITabSize                 = interface end
    type ITextOrientation         = interface end
    type ITextRendering           = interface end
    type ITextJustify             = interface end
    type IWhiteSpace              = interface end
    type IUserSelect              = interface end
    type IHangingPunctuation      = interface end

    type IListStyle         = interface end
    type IListStyleImage    = interface end
    type IListStylePosition = interface end
    type IListStyleType     = interface end

    type IBackgroundColor      = interface end
    type IBackgroundClip       = interface end
    type IBackgroundOrigin     = interface end
    type IBackgroundRepeat     = interface end
    type IBackgroundSize       = interface end
    type IBackgroundAttachment = interface end
    type IBackgroundPosition   = interface end
    type IBackgroundBlendMode  = interface end

    type IBorder            = interface end
    type IBorderRadius      = interface end
    type IBorderWidth       = interface end
    type IBorderStyle       = interface end
    type IBorderCollapse    = interface end
    type IBorderImageOutset = interface end
    type IBorderRepeat      = interface end
    type IBorderImageSlice  = interface end
    type IBorderColor       = interface end
    type IBorderSpacing     = interface end
    type IBorderImageWidth  = interface end
    type IBorderImageSource = interface end

    type ITransform       = interface end
    type ITransformOrigin = interface end
    type ITransformStyle  = interface end

    type ITransition               = interface end
    type ITransitionDelay          = interface end
    type ITransitionDuration       = interface end
    type ITransitionTimingFunction = interface end
    type ITransitionProperty       = interface end
    type IWillChange               = interface end

    type IDisplay        = interface end
    type IAlignContent   = interface end
    type IAlignItems     = interface end
    type IAlignSelf      = interface end
    type IJustifyContent = interface end
    type IJustifyItems   = interface end
    type IJustifySelf    = interface end
    type IFlex           = interface end
    type IFlexDirection  = interface end
    type IFlexWrap       = interface end
    type IOrder          = interface end
    type IFlexGrow       = interface end
    type IFlexShrink     = interface end
    type IFlexBasis      = interface end


    type IMargin        = interface end
    type IPadding       = interface end

    type IScrollBehavior       = interface end
    type IScrollMargin         = interface end
    type IScrollPadding        = interface end
    type IOverscrollBehaviorX  = interface end
    type IOverscrollBehaviorY  = interface end

    type IContentSize = interface end

    type IVisibility = interface end

    type IOverflow      = interface end
    type IOverflowWrap  = interface end
    type IPositioned    = interface end
    type IVerticalAlign = interface end
    type IFloat         = interface end
    type IDirection     = interface end

    type IPerspective        = interface end
    type IPerspectiveOrigin  = interface end
    type IBackfaceVisibility = interface end

    type ICursor        = interface end
    type IPointerEvents = interface end

    type IContent = interface end

    type IOutline       = interface end
    type IOutlineColor  = interface end
    type IOutlineWidth  = interface end
    type IOutlineStyle  = interface end
    type IOutlineOffset = interface end

    type IGridAutoFlow        = interface end
    type IGridTemplateArea    = interface end
    type IGridGap             = interface end
    type IGridRowGap          = interface end
    type IGridColumnGap       = interface end
    type IGridPosition        = interface end
    type IGridTemplateRows    = interface end
    type IGridTemplateColumns = interface end
    type IGridAutoRows        = interface end
    type IGridAutoColumns     = interface end

    type IColumns             = interface end
    type IColumnGap           = interface end
    type IColumnSpan          = interface end
    type IColumnRule          = interface end
    type IColumnRuleWidth     = interface end
    type IColumnRuleStyle     = interface end
    type IColumnRuleColor     = interface end
    type IColumnCount         = interface end
    type IColumnFill          = interface end
    type IColumnWidth         = interface end

    type INthChild = interface end

    type IResize = interface end

    type IWordSpacing = interface end
    type IWordBreak   = interface end

    type IPaintOrder = interface end

    type ICaptionSide = interface end
    type IEmptyCells  = interface end
    type ITableLayout = interface end

    type ICaretColor = interface end

    type IAppearance = interface end

    type IWritingMode = interface end

    type IBreakAfter  = interface end
    type IBreakBefore = interface end
    type IBreakInside = interface end

    type IOrphans = interface end
    type IWidows = interface end

    type IAll = interface end

    type ICounterReset     = interface end
    type ICounterIncrement = interface end

    type IClipPath = interface end

    type IIsolation = interface end

    type IBoxDecorationBreak = interface end

    type IClear = interface end

    type IFilter         = interface end
    type IBackdropFilter = interface end

    type IMixBlendMode = interface end

    type IAspectRatio = interface end

    type IMaskClip      = interface end
    type IMaskComposite = interface end
    type IMaskImage     = interface end
    type IMaskMode      = interface end
    type IMaskOrigin    = interface end
    type IMaskPosition  = interface end
    type IMaskRepeat    = interface end

    // Types
    type CssProperty = CssProperty of string * obj
    type CounterProperty = CounterProperty of string * obj


    type Auto =
        | Auto
        interface IFontDisplay
        interface ITextDecorationThickness
        interface ITextDecorationSkipInk
        interface ITextUnderlinePosition
        interface ITextUnderlineOffset
        interface ITextAlignLast
        interface ITextSizeAdjust
        interface ITextRendering
        interface ITextJustify
        interface IQuotes
        interface IHyphens
        interface IUserSelect
        interface IBackgroundSize
        interface IBorderImageWidth
        interface IFlexBasis
        interface IMargin
        interface IPadding
        interface IContentSize
        interface IOverflow
        interface IPositioned
        interface ICursor
        interface IPointerEvents
        interface IGridPosition
        interface IGridTemplateRows
        interface IGridTemplateColumns
        interface IGridAutoRows
        interface IGridAutoColumns
        interface ILineBreak
        interface IColumnCount
        interface IColumnFill
        interface IColumnWidth
        interface ITableLayout
        interface ICaretColor
        interface IAppearance
        interface IBreakAfter
        interface IBreakBefore
        interface IBreakInside
        interface IFlex
        interface IScrollBehavior
        interface IOverscrollBehaviorX
        interface IOverscrollBehaviorY
        interface IIsolation
        interface IFontKerning
        interface IWillChange

    type None' =
        | None'
        interface IAnimationFillMode
        interface IAnimationName
        interface IFontVariantLigature
        interface ITextDecoration
        interface ITextDecorationLine
        interface ITextDecorationSkip
        interface ITextDecorationSkipInk
        interface ITextEmphasis
        interface ITextEmphasisStyle
        interface ITextTransform
        interface ITextSizeAdjust
        interface ITextJustify
        interface IHangingPunctuation
        interface IUserSelect
        interface IQuotes
        interface IHyphens
        interface IListStyle
        interface IListStyleType
        interface IListStyleImage
        interface IBorderStyle
        interface IBorderImageSource
        interface ITransitionProperty
        interface IDisplay
        interface IFloat
        interface IPerspective
        interface ICursor
        interface IPointerEvents
        interface IContent
        interface IOutlineStyle
        interface IGridTemplateArea
        interface IGridTemplateRows
        interface IGridTemplateColumns
        interface IColumnSpan
        interface IResize
        interface IColumnRuleStyle
        interface IAppearance
        interface IFlex
        interface IBorder
        interface IOutline
        interface ICounterReset
        interface ICounterIncrement
        interface IOverscrollBehaviorX
        interface IOverscrollBehaviorY
        interface ITransform
        interface IClipPath
        interface IClear
        interface IFilter
        interface IBackdropFilter
        interface IFontKerning
        interface IFontSynthesis
        interface IMaskImage

    type Normal =
        | Normal
        interface IAnimationDirection
        interface IFontStyle
        interface IFontStretch
        interface IFontWeight
        interface IFontVariantNumeric
        interface IFontVariantCaps
        interface IFontVariantEastAsian
        interface IFontVariantLigature
        interface IFontVariantPosition
        interface IFontKerning
        interface IFontLanguageOverride
        interface ILineHeight
        interface ILineBreak
        interface ILetterSpacing
        interface IAlignContent
        interface IAlignItems
        interface IAlignSelf
        interface IJustifyContent
        interface IJustifyItems
        interface IJustifySelf
        interface IContent
        interface IGridRowGap
        interface IGridColumnGap
        interface IColumnGap
        interface IWordSpacing
        interface IWordBreak
        interface IOverflowWrap
        interface IPaintOrder
        interface IWhiteSpace
        interface IBackgroundBlendMode
        interface IMixBlendMode

    type Keywords =
        | Inherit
        | Initial
        | Unset
        interface IAnimationDirection
        interface IAnimationPlayState
        interface IAnimationName
        interface IColor
        interface IFontSize
        interface IFontStyle
        interface IFontStretch
        interface IFontWeight
        interface IFontFamily
        interface IFontFeatureSetting
        interface IFontVariantNumeric
        interface IFontVariantCaps
        interface IFontVariantEastAsian
        interface IFontVariantLigature
        interface IFontLanguageOverride
        interface IFontVariantPosition
        interface ILineHeight
        interface ILineBreak
        interface ILetterSpacing
        interface ITextAlign
        interface ITextAlignLast
        interface ITextDecorationLine
        interface ITextDecorationThickness
        interface ITextDecorationStyle
        interface ITextDecorationSkip
        interface ITextDecorationSkipInk
        interface ITextTransform
        interface ITextIndent
        interface ITextEmphasis
        interface ITextEmphasisPosition
        interface ITextEmphasisStyle
        interface ITextUnderlinePosition
        interface ITextUnderlineOffset
        interface ITextOrientation
        interface ITextRendering
        interface IQuotes
        interface IHyphens
        interface ITextDecorationColor
        interface ITextEmphasisColor
        interface ITextSizeAdjust
        interface IHangingPunctuation
        interface IUserSelect
        interface IListStyle
        interface IListStyleImage
        interface IListStylePosition
        interface IListStyleType
        interface IBackgroundColor
        interface IBackgroundClip
        interface IBackgroundOrigin
        interface IBackgroundRepeat
        interface IBackgroundSize
        interface IBackgroundAttachment
        interface IBackgroundPosition
        interface IBackgroundBlendMode
        interface IBorder
        interface IBorderRadius
        interface IBorderWidth
        interface IBorderStyle
        interface IBorderCollapse
        interface IBorderImageOutset
        interface IBorderRepeat
        interface IBorderImageSlice
        interface IBorderColor
        interface IBorderSpacing
        interface IBorderImageWidth
        interface IBorderImageSource
        interface ITransform
        interface ITransformOrigin
        interface ITransformStyle
        interface ITransition
        interface ITransitionDelay
        interface ITransitionDuration
        interface ITransitionTimingFunction
        interface ITransitionProperty
        interface IDisplay
        interface IAlignContent
        interface IAlignItems
        interface IAlignSelf
        interface IJustifyContent
        interface IJustifyItems
        interface IJustifySelf
        interface IFlexDirection
        interface IFlexWrap
        interface IOrder
        interface IFlexGrow
        interface IFlexShrink
        interface IFlexBasis
        interface IMargin
        interface IPadding
        interface IContentSize
        interface IVisibility
        interface IOverflow
        interface IOverflowWrap
        interface IPositioned
        interface IVerticalAlign
        interface IFloat
        interface IPerspective
        interface ICursor
        interface IPointerEvents
        interface IContent
        interface IOutline
        interface IOutlineColor
        interface IOutlineWidth
        interface IOutlineStyle
        interface IOutlineOffset
        interface IGridAutoFlow
        interface IGridTemplateArea
        interface IGridGap
        interface IGridRowGap
        interface IGridColumnGap
        interface IGridPosition
        interface IGridTemplateRows
        interface IGridTemplateColumns
        interface IGridAutoRows
        interface IGridAutoColumns
        interface IDirection
        interface IResize
        interface IWordSpacing
        interface IWordBreak
        interface IColumns
        interface IColumnGap
        interface IColumnSpan
        interface IColumnRule
        interface IColumnRuleWidth
        interface IColumnRuleStyle
        interface IColumnRuleColor
        interface IColumnCount
        interface IColumnFill
        interface IColumnWidth
        interface ICaptionSide
        interface IEmptyCells
        interface ITableLayout
        interface ITabSize
        interface IWhiteSpace
        interface IWritingMode
        interface IBreakAfter
        interface IBreakBefore
        interface IBreakInside
        interface IOrphans
        interface IWidows
        interface IAll
        interface IFlex
        interface IScrollBehavior
        interface IScrollMargin
        interface IScrollPadding
        interface ICounterReset
        interface ICounterIncrement
        interface IOverscrollBehaviorX
        interface IOverscrollBehaviorY
        interface IClipPath
        interface IIsolation
        interface IClear
        interface IBackfaceVisibility
        interface IBoxDecorationBreak
        interface IFilter
        interface IBackdropFilter
        interface IMixBlendMode
        interface IPerspectiveOrigin
        interface IAspectRatio
        interface IMaskClip
        interface IMaskComposite
        interface IMaskImage
        interface IMaskMode
        interface IMaskOrigin
        interface IMaskPosition
        interface IMaskRepeat

    type CssInt =
        | CssInt of int
        interface IAnimationIterationCount
        interface IOrder
        interface IFontWeight
        interface INthChild
        interface IColumnCount
        interface ITabSize
        interface IOrphans
        interface IWidows

    type CssFloat =
        | CssFloat of float
        interface IBorderImageWidth
        interface IFlexGrow
        interface IFlexShrink
        interface ILineHeight

    type CssString =
        | CssString of string
        interface IAnimationName
        interface ITextEmphasisStyle
        interface ITextOverflow
        interface IQuotes
        interface IListStyleType
        interface IContent
        interface INthChild

    [<AutoOpen>]
    module masterTypeHelpers =
        let internal auto = "auto"
        let internal none = "none"
        let internal normal = "normal"

        let internal IntToString (CssInt i) = string i
        let internal FloatToString (CssFloat f) = string f
        let internal StringToString (CssString s) = s

        let internal keywordsToString (g: Keywords) = Fss.Utilities.Helpers.duToLowercase g

        let CssValue (CssProperty (s,o)) = s,o
        let CounterValue (CounterProperty (s,o)) = s,o
