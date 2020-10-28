namespace Fss

open Fss.Utilities.Helpers

module Global =
    open Types

    type Value =
        | Value of int
        interface IGridRowStart
        interface IGridRowEnd
        interface IGridColumnStart
        interface IGridColumnEnd
        interface IRepeatTypes

    type Ident =
        | Ident of string
        interface IGridRowStart
        interface IGridRowEnd
        interface IGridColumnStart
        interface IGridColumnEnd
        interface IGridArea

    type None =
        | None
        interface IFontVariantLigatures
        interface IBorderStyle
        interface IPerspective
        interface IDisplay
        interface IAnimationFillMode
        interface IAnimationName
        interface ITransform
        interface ITextTransform
        interface ITextDecorationLine
        interface ITextDecorationSkip
        interface ITextDecorationSkipInk
        interface ITextEmphasisStyle
        interface ICursor
        interface IContent
        interface IListStyleImage
        interface IListStyleType
        interface IListStylePosition
        interface IFloat
        interface IQuote
        interface IImage
        interface IGridTemplateAreas
        interface IGridTemplateColumns
        interface IGridTemplateRows
        interface IOutlineStyle

    type Auto =
        | Auto
        interface IContentSize
        interface IFlexBasis
        interface IAlignSelf
        interface IJustifyItems
        interface IMargin
        interface IPadding
        interface ITextDecorationThickness
        interface ITextDecorationSkipInk
        interface IBackgroundSize
        interface ITextUnderlineOffset
        interface ITextUnderlinePosition
        interface ICursor
        interface IRange
        interface ISpeakAs
        interface IPlacement
        interface IQuote
        interface IOverflow
        interface IBorderImageWidth
        interface IGridAutoColumns
        interface IGridAutoRows
        interface IGridTemplateColumns
        interface IGridTemplateRows
        interface IGridRowStart
        interface IGridRowEnd
        interface IGridRow
        interface IGridColumnStart
        interface IGridColumnEnd
        interface IGridColumn
        interface IMinMax
        interface IRepeat
        interface IOutlineStyle

    type Center =
        | Center
        interface IAlignSelf
        interface IAlignItems
        interface IAlignContent
        interface IJustifyContent

    type Normal =
        | Normal
        interface IFontStyle
        interface IFontWeight
        interface IFontStretch
        interface IFontVariant
        interface ILineHeight
        interface IContent
        interface IAnimationDirection
        interface IGridColumnGap
        interface IGridRowGap
        interface IGridGap
        interface IJustifyContent
        interface IJustifyItems
        interface IJustifySelf
        interface IAlignItems
        interface IAlignContent
        interface IAlignSelf

    type Global =
        | Initial
        | Inherit
        | Unset
        | Revert
        interface IGlobal
        interface IFontSize
        interface IFontStretch
        interface IFontStyle
        interface IFontWeight
        interface ILineHeight
        interface IFontFamily
        interface IFontFeatureSetting
        interface IFontVariantNumeric
        interface IFontVariantCaps
        interface IFontVariantEastAsian
        interface IFontVariantLigatures
        interface ITextAlign
        interface ITextDecorationLine
        interface ITextDecorationThickness
        interface ITextDecorationStyle
        interface ITextDecorationSkip
        interface ITextDecorationSkipInk
        interface ITextTransform
        interface ITextEmphasisColor
        interface ITextEmphasisPosition
        interface ITextEmphasisStyle
        interface ITextIndent
        interface ITextShadow
        interface ITextUnderlineOffset
        interface ITextUnderlinePosition
        interface IColor
        interface IBorderStyle
        interface IBorderWidth
        interface IBorderRadius
        interface IBorderColor
        interface IBorderCollapse
        interface IBorderSpacing
        interface IBorderImageWidth
        interface IBorderImageRepeat
        interface IBorderImageSlice
        interface IBorderImageOutset
        interface IMargin
        interface IPadding
        interface IDisplay
        interface IFlexDirection
        interface IFlexWrap
        interface IJustifyContent
        interface IJustifyItems
        interface IJustifySelf
        interface IAlignItems
        interface IAlignContent
        interface IAlignSelf
        interface IPlaceItems
        interface IOrder
        interface IFlexGrow
        interface IFlexShrink
        interface IFlexBasis
        interface IVerticalAlign
        interface ITransform
        interface ITransformOrigin
        interface ITime
        interface IProperty
        interface ITimingFunction
        interface IImagePosition
        interface IBackgroundOrigin
        interface IBackgroundClip
        interface IBackgroundRepeat
        interface IBackgroundSize
        interface IBackgroundAttachment
        interface IContentSize
        interface IVisibility
        interface IAnimationDirection
        interface IAnimationPlayState
        interface IAnimationName
        interface IPerspective
        interface ICursor
        interface IContent
        interface IListStyleImage
        interface IListStylePosition
        interface IListStyleType
        interface IPlacement
        interface IFloat
        interface IQuote
        interface IOverflow
        interface IImage
        interface IGridAutoColumns
        interface IGridAutoRows
        interface IGridAutoFlow
        interface IGridTemplateAreas
        interface IGridTemplateColumns
        interface IGridTemplateRows
        interface IGridColumnGap
        interface IGridRowGap
        interface IGridGap
        interface IGridRowStart
        interface IGridRowEnd
        interface IGridRow
        interface IGridColumnStart
        interface IGridColumnEnd
        interface IGridColumn
        interface IOutlineColor
        interface IOutlineStyle
        interface IOutlineWidth

module GlobalValue =
    open Global

    let value (Value v) = string v
    let ident (Ident i) = i
    let globalValue (v: Global): string = duToLowercase v
    let none (v: None): string = duToLowercase v
    let normal (v: Normal): string = duToLowercase v
    let center (v: Center): string = duToLowercase v
    let auto (v: Auto): string = duToLowercase v