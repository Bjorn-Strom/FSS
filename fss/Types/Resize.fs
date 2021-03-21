namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Resize =
        | Both
        | Horizontal
        | Vertical
        | Block
        | Inline
        interface Types.IResize

