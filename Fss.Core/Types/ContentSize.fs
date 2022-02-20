namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module ContentSize =
    type ContentSize =
        | MaxContent
        | MinContent
        | FitContent of ILengthPercentage
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | FitContent length -> $"fit-content({lengthPercentageString length})"
                | _ -> (Fss.Utilities.Helpers.toKebabCase this).ToLower()

[<RequireQualifiedAccess>]
module ContentSizeClasses =
    type ContentSize(property) =
        inherit CssRuleWithAutoLength(property)
        /// Width gets set to the maximum it can be without getting wrapped or overflowing
        member this.maxContent = (property, ContentSize.MaxContent) |> Rule
        /// Width gets set to the widest element within the box
        member this.minContent = (property, ContentSize.MinContent) |> Rule
        ///
        member this.fitContent(fit: ILengthPercentage) = (property, ContentSize.FitContent fit) |> Rule