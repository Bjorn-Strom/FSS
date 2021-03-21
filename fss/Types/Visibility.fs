namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Visibility =
        | Visible
        | Hidden
        | Collapse
        interface Types.IVisibility

    let internal visibilityToString (visibility: Types.IVisibility) =
        match visibility with
        | :? Visibility as v -> Fss.Utilities.Helpers.duToLowercase v
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown visibility"

    type PaintOrder =
        | Stroke
        | Markers
        | Fill
        interface Types.IPaintOrder

    type BackfaceVisibility =
        | Visible
        | Hidden
        interface Types.IBackfaceVisibility
