namespace Fss

namespace Fss.Types
    type Content =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        interface IContent