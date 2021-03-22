namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Scroll =
        type ScrollBehavior =
            | Smooth
            interface IScrollBehavior

        type OverscrollBehavior =
            | Contain
            interface IOverscrollBehaviorX
            interface IOverscrollBehaviorY
