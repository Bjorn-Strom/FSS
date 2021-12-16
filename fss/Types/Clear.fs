namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Clear =
    type Clear =
        | Left
        | Right
        | Both
        | InlineStart
        | InlineEnd
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module ClearClasses =
        type Clear(property) =
            inherit CssRuleWithNone(property)
            member this.left = (property, Left) |> Rule
            member this.right = (property, Right) |> Rule
            member this.both = (property, Both) |> Rule
            member this.inlineStart = (property, InlineStart) |> Rule
            member this.inlineEnd = (property, InlineEnd) |> Rule
