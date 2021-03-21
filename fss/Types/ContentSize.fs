namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type ContentSize =
        | MaxContent
        | MinContent
        | FitContent of Types.ILengthPercentage
        interface Types.IContentSize
        interface Types.IGridAutoRows
        interface Types.IGridAutoColumns

    let internal contentSizeToString (contentSize: Types.IContentSize) =
        let stringifyContent content =
            match content with
                | FitContent f -> sprintf "fit-content(%s)" (Types.lengthPercentageToString f)
                | _ -> Utilities.Helpers.duToKebab content

        match contentSize with
        | :? ContentSize as c -> stringifyContent c
        | :? Types.Auto -> Types.auto
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown content size"
