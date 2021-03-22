namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Content =
        type Content =
            | OpenQuote
            | CloseQuote
            | NoOpenQuote
            | NoCloseQuote
            interface IContent