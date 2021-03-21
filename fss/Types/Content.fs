namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Content =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        interface Types.IContent