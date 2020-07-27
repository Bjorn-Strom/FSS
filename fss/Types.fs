namespace Fss

module Types =
    type IAnimation            = interface end
    type IGlobal               = interface end
    type IFontSize             = interface end
    type IColor                = interface end
    type IBorderStyle          = interface end
    type IBorderWidth          = interface end
    type IMargin               = interface end
    type IPadding              = interface end
    type IDisplay              = interface end
    type IFlexDirection        = interface end
    type IFlexWrap             = interface end
    type IJustifyContent       = interface end
    type IAlignItems           = interface end
    type IAlignContent         = interface end
    type IAlignSelf            = interface end
    type IOrder                = interface end
    type IFlexGrow             = interface end
    type IFlexShrink           = interface end
    type IFlexBasis            = interface end
    type ITransform            = interface end
    type ITransition           = interface end
    type ILinearGradient       = interface end
    type IRadialGradient       = interface end
    type IBackgroundPosition   = interface end
    type IBackgroundOrigin     = interface end
    type IBackgroundClip       = interface end
    type IBackgroundRepeat     = interface end
    type IBackgroundSize       = interface end
    type IBackgroundAttachment = interface end
    type IContentSize          = interface end

module Global =
    open Types

    type Global =
        | Initial
        | Inherit
        | Unset
        | Revert
        interface IGlobal
        interface IFontSize
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
        interface ITransform
        interface ITransition
        interface IBackgroundPosition
        interface IBackgroundOrigin
        interface IBackgroundClip
        interface IBackgroundRepeat
        interface IBackgroundSize
        interface IBackgroundAttachment
        interface IContentSize

    let value (v: Global): string =
        match v with
            | Initial -> "initial"
            | Inherit -> "inherit"
            | Unset -> "unset"
            | Revert -> "revert"