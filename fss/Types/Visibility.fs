namespace Fss

namespace Fss.Types
    type Visibility =
        | Visible
        | Hidden
        | Collapse
        interface IVisibility

    type PaintOrder =
        | Stroke
        | Markers
        | Fill
        interface IPaintOrder

    type BackfaceVisibility =
        | Visible
        | Hidden
        interface IBackfaceVisibility

    [<AutoOpen>]
    module visibilityHelpers =
        let internal visibilityToString (visibility: IVisibility) =
            match visibility with
            | :? Visibility as v -> Fss.Utilities.Helpers.duToLowercase v
            | :? Keywords as k -> keywordsToString k
            | _ -> "Unknown visibility"
