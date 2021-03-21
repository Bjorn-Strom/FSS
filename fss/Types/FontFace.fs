namespace Fss

namespace Fss.Types
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

