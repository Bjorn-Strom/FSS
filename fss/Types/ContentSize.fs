namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module ContentSize =
        type ContentSize =
            | MaxContent
            | MinContent
            | FitContent of ILengthPercentage
            interface IContentSize
            interface IGridAutoRows
            interface IGridAutoColumns

    [<AutoOpen>]
    module contentSizeHelpers =
        let internal contentSizeToString (contentSize: IContentSize) =
            let stringifyContent content =
                match content with
                    | ContentSize.FitContent f -> sprintf "fit-content(%s)" (lengthPercentageToString f)
                    | _ -> Fss.Utilities.Helpers.duToKebab content

            match contentSize with
            | :? ContentSize.ContentSize as c -> stringifyContent c
            | :? Auto -> auto
            | :? Keywords as k -> keywordsToString k
            | _ -> "Unknown content size"
