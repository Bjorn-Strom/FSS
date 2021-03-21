namespace FssTypes

type Content =
    | OpenQuote
    | CloseQuote
    | NoOpenQuote
    | NoCloseQuote
    interface IContent