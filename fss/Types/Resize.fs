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
            member this.StringifyCss() = this.ToString().ToLower()

[<RequireQualifiedAccess>]
module ResizeClasses =
    type ResizeClass(property) =
        inherit CssRuleWithNone(property)
        member this.value (resize: Resize.Resize) =
            (property, resize) |> Rule
        member this.both = (property, Resize.Both) |> Rule
        member this.horizontal = (property, Resize.Horizontal) |> Rule
        member this.vertical = (property, Resize.Vertical) |> Rule
        member this.block = (property, Resize.Block) |> Rule
        member this.inline' = (property, Resize.Inline) |> Rule
