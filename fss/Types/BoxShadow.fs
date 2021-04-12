namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module BoxShadow =
        type BoxShadow =
            | Color of Length * Length * ColorType
            | BlurColor of Length * Length * Length * ColorType
            | BlurSpreadColor of Length * Length * Length * Length * ColorType
            | Inset of BoxShadow
