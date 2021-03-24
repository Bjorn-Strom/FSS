namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module FontFace =
        type Format =
            | Truetype
            | Opentype
            | EmpbeddedOpentype
            | Woff
            | Woff2
            | Svg

        type Source =
            | Url of string
            | UrlFormat of string * Format
            | Local of string

