namespace Fss

open Fss.Utilities.Helpers

module Global =
    open Types

    type Auto =
        | Auto
        interface IBackgroundSize
        interface IContentSize
        interface IFlexBasis
        interface IAlignSelf
        interface IMargin
        interface IPadding

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

    type None =
        | None
        interface ITextTransform
        interface IDisplay

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
        interface ITextDecorationSkipInk
        interface ITextTransform
        interface ITextIndent
        interface ITextShadow
        interface IColor
        interface IBorderStyle
        interface IBorderWidth
        interface IBorderRadius
        interface IBorderColor
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
        interface IAnimationName
        interface IAnimationTimingFunction
        interface IPerspective

module GlobalValue =
    open Global

    let globalValue (v: Global): string = duToLowercase v
    let none (v: None): string = duToLowercase v
    let normal (v: Normal): string = duToLowercase v
    let center (v: Center): string = duToLowercase v
    let auto (v: Auto): string = duToLowercase v