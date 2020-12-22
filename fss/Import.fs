namespace Fss

[<AutoOpen>]
module Import =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@import
    let importValue value = sprintf "@import %s" value

    type Import =
        static member Url (url: string) = importValue (sprintf "url(%s)" url) |> css'
        static member Custom (import: string) = importValue import |> css'