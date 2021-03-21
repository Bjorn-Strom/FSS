namespace FssTypes

type Visibility =
    | Visible
    | Hidden
    | Collapse
    interface IVisibility

module Visibility =
    let value (visibility: IVisibility) =
        match visibility with
        | :? Visibility as v -> Fss.Utilities.Helpers.duToLowercase v
        | :? Global as g -> global' g
        | _ -> "Unknown visibility"

type PaintOrder =
    | Stroke
    | Markers
    | Fill
    interface IPaintOrder
