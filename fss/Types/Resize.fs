namespace FssTypes

[<RequireQualifiedAccess>]
module Resize =
    type Resize =
        | Both
        | Horizontal
        | Vertical
        | Block
        | Inline
        interface IResize

