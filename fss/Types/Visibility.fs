namespace FssTypes

[<RequireQualifiedAccess>]
module Visibility =
    type Visibility =
        | Visible
        | Hidden
        | Collapse
        interface IVisibility

    let visibilityToString (visibility: IVisibility) =
        match visibility with
        | :? Visibility as v -> Fss.Utilities.Helpers.duToLowercase v
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown visibility"

