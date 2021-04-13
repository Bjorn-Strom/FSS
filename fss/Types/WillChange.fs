namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module WillChange =
        type WillChange =
            | ScrollPosition
            | Contents
            | Ident of string
            interface IWillChange
