namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type BoxShadow =
        | Color' of Types.Size * Types.Size * Types.Color
        | BlurColor of Types.Size * Types.Size * Types.Size * Types.Color
        | BlurSpreadColor of Types.Size * Types.Size * Types.Size * Types.Size * Types.Color
        | Inset of BoxShadow
