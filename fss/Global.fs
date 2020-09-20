namespace Fss

open Fss.Utilities.Helpers

module Global =
    open Types

    type Global =
        | Initial
        | Inherit
        | Unset
        | Revert
        | Normal
        | None
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
        interface ITextDecorationSkipInk
        interface ITextTransform
        interface ITextIndent
        interface ITextShadow
        interface IColor
        interface IBorderStyle
        interface IBorderWidth
        interface IMargin
        interface IPadding
        interface IDisplay
        interface IFlexDirection
        interface IFlexWrap
        interface IJustifyContent
        interface IAlignItems
        interface IAlignContent
        interface IAlignSelf
        interface IOrder
        interface IFlexGrow
        interface IFlexShrink
        interface IFlexBasis
        interface IVerticalAlign
        interface ITransform
        interface ITransformOrigin
        interface ITransition
        interface IBackgroundPosition
        interface IBackgroundOrigin
        interface IBackgroundClip
        interface IBackgroundRepeat
        interface IBackgroundSize
        interface IBackgroundAttachment
        interface IContentSize
        interface IVisibility
        interface IAnimationDirection
        interface IAnimationPlayState

    let value (v: Global): string = duToLowercase v