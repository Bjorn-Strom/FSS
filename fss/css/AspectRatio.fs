namespace Fss

open Fable.Core

[<AutoOpen>]
module AspectRatio =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/aspect-ratio
    let private stringifyAspectRatio (all: FssTypes.IAll) =
        match all with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private aspectRatioValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AspectRatio
    let private aspectRatioValue' = stringifyAspectRatio >> aspectRatioValue

    [<Erase>]
    /// Sets the preferred aspect ratio of the element
    type AspectRatio =
        static member value (width: int, height: int) =
            $"{width} / {height}"
            |> aspectRatioValue
        static member inherit' = FssTypes.Inherit |> aspectRatioValue'
        static member initial = FssTypes.Initial |> aspectRatioValue'
        static member unset = FssTypes.Unset |> aspectRatioValue'

    /// Sets the preferred aspect ratio of the element
    /// Valid parameters:
    /// int int
    let AspectRatio' = aspectRatioValue
