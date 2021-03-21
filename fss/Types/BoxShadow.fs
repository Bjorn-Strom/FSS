namespace Fss

namespace Fss.Types
    type BoxShadow =
        | Color' of Size * Size * Color
        | BlurColor of Size * Size * Size * Color
        | BlurSpreadColor of Size * Size * Size * Size * Color
        | Inset of BoxShadow
