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
