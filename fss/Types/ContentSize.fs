namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module ContentSize =
    type ContentSize =
        | MaxContent
        | MinContent
        | FitContent of ILengthPercentage
        interface ICssValue with
            member this.Stringify() =
                match this with
                | FitContent length -> $"fit-content({lengthPercentageString length})"
                | _ -> (Fss.Utilities.Helpers.toKebabCase this).ToLower()

    [<RequireQualifiedAccess>]
    module ContentClasses =
        type ContentSize(property) =
            inherit CssRule(property)

            member this.value(length: ILengthPercentage) =
                (property, lengthPercentageToType length) |> Rule

            member this.maxContent =
                (property, ContentSize.MaxContent) |> Rule

            member this.minContent =
                (property, ContentSize.MinContent) |> Rule

            member this.fitContent(fit: ILengthPercentage) =
                (property, ContentSize.FitContent fit) |> Rule

            member this.auto = (property, Auto) |> Rule
