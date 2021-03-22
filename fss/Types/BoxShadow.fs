namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module BoxShadow =
        type BoxShadow =
            | Color of Size * Size * ColorTypeFoo
            | BlurColor of Size * Size * Size * ColorTypeFoo
            | BlurSpreadColor of Size * Size * Size * Size * ColorTypeFoo
            | Inset of BoxShadow
