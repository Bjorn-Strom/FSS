namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module ContentSize =
        type ContentSize =
            | MaxContent
            | MinContent
            | FitContent of ILengthPercentage
            interface IContentSize
            interface IGridAutoRows
            interface IGridAutoColumns

        type ContentSizeClass (contentValue: string -> CssProperty, contentValue': IContentSize -> CssProperty) =
            member this.fitContent (contentSize: ILengthPercentage) =
                sprintf "fit-content(%s)" (lengthPercentageToString contentSize)
                |> contentValue
            member this.value (size: ILengthPercentage) = lengthPercentageToString size |> contentValue
            member this.value (contentSize: IContentSize) = contentSize |> contentValue'
            member this.maxContent = MaxContent |> contentValue'
            member this.minContent = MinContent |> contentValue'

            member this.auto = Auto |> contentValue'
            member this.inherit' = Inherit |> contentValue'
            member this.initial = Initial |> contentValue'
            member this.unset = Unset |> contentValue'

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
