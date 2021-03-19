namespace FssTypes

[<RequireQualifiedAccess>]
module BoxShadow =
    type BoxShadow =
        | Color of Units.Size.Size * Units.Size.Size * CssColor
        | BlurColor of Units.Size.Size * Units.Size.Size * Units.Size.Size * CssColor
        | BlurSpreadColor of Units.Size.Size * Units.Size.Size * Units.Size.Size * Units.Size.Size * CssColor
        | Inset of BoxShadow
