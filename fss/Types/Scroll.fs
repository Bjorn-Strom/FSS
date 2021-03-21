namespace FssTypes

type ScrollBehavior =
    | Smooth
    interface IScrollBehavior

type OverscrollBehavior =
    | Contain
    interface IOverscrollBehaviorX
    interface IOverscrollBehaviorY
