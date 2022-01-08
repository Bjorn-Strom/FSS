namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Clear =
    type Clear =
        | Left
        | Right
        | Both
        | InlineStart
        | InlineEnd
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module ClearClasses =
    type Clear(property) =
        inherit CssRuleWithNone(property)
        member this.left = (property, Clear.Left) |> Rule
        member this.right = (property, Clear.Right) |> Rule
        member this.both = (property, Clear.Both) |> Rule
        member this.inlineStart = (property, Clear.InlineStart) |> Rule
        member this.inlineEnd = (property, Clear.InlineEnd) |> Rule
