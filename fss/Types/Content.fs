namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Content =
        type Content =
            | OpenQuote
            | CloseQuote
            | NoOpenQuote
            | NoCloseQuote
            interface IContent