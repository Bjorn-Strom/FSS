namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module BoxShadow =
        type BoxShadow =
            | Color of Size * Size * ColorType
            | BlurColor of Size * Size * Size * ColorType
            | BlurSpreadColor of Size * Size * Size * Size * ColorType
            | Inset of BoxShadow
