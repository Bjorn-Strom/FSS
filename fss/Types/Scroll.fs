namespace Fss

namespace Fss.Types
    type ScrollBehavior =
        | Smooth
        interface IScrollBehavior

    type OverscrollBehavior =
        | Contain
        interface IOverscrollBehaviorX
        interface IOverscrollBehaviorY
