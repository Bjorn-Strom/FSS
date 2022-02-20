namespace Fss

namespace Fss.Types

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
        /// Element can be resized both vertically and horizontally
        member this.both = (property, Resize.Both) |> Rule
        /// Element can be resized horizontally
        member this.horizontal = (property, Resize.Horizontal) |> Rule
        /// Element can be resized vertically
        member this.vertical = (property, Resize.Vertical) |> Rule
        /// Element can be resized in the block direction depending on the writing-mode and direction value
        member this.block = (property, Resize.Block) |> Rule
        /// Element can be resized in the inline direction depending on the writing-mode and direction value
        member this.inline' = (property, Resize.Inline) |> Rule
