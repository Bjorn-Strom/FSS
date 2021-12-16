namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Resize =
    type Resize =
        | Both
        | Horizontal
        | Vertical
        | Block
        | Inline
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    [<RequireQualifiedAccess>]
    module ResizeClasses =
        type ResizeClass(property) =
            inherit CssRuleWithNone(property)
            member this.value (resize: Resize) =
                (property, resize) |> Rule
            member this.both = (property, Both) |> Rule
            member this.horizontal = (property, Horizontal) |> Rule
            member this.vertical = (property, Vertical) |> Rule
            member this.block = (property, Block) |> Rule
            member this.inline' = (property, Inline) |> Rule
