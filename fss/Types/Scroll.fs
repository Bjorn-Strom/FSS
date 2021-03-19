namespace FssTypes

[<RequireQualifiedAccess>]
module ScrollBehavior =
    type ScrollBehavior =
        | Smooth
        interface IScrollBehavior

[<RequireQualifiedAccess>]
module OverscrollBehavior =
    type OverscrollBehavior =
        | Contain
        interface IOverscrollBehaviorX
        interface IOverscrollBehaviorY
