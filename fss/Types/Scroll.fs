namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type ScrollBehavior =
        | Smooth
        interface Types.IScrollBehavior

    type OverscrollBehavior =
        | Contain
        interface Types.IOverscrollBehaviorX
        interface Types.IOverscrollBehaviorY
