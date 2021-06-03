namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Scroll =
        type ScrollBehavior =
            | Smooth
            interface IScrollBehavior

        type OverscrollBehavior =
            | Contain
            interface IOverscrollBehaviorX
            interface IOverscrollBehaviorY

        type ScrollMargin (valueFunction': IScrollMargin -> CssProperty) =
            member this.value (value: IScrollMargin) = value |> valueFunction'
            member this.inherit' = Inherit |> valueFunction'
            member this.initial = Initial |> valueFunction'
            member this.unset = Unset |> valueFunction'

        type ScrollPadding (valueFunction': IScrollPadding -> CssProperty) =
            member this.value (value: IScrollPadding) = value |> valueFunction'
            member this.inherit' = Inherit |> valueFunction'
            member this.initial = Initial |> valueFunction'
            member this.unset = Unset |> valueFunction'

        module SnapType =
            type Type =
                | None'
                | X
                | Y
                | Block
                | Inline
                | Both
                interface IScrollSnapType

            type Viewport =
                | Mandatory
                | Proximity

        type SnapAlign =
            | Start
            | End
            | Center
            interface IScrollSnapAlign

