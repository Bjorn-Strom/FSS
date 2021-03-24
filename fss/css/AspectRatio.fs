namespace Fss

[<AutoOpen>]
module AspectRatio =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/aspect-ratio
    let private stringifyAspectRatio (all: FssTypes.IAll) =
        match all with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private aspectRatioValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AspectRatio value
    let private aspectRatioValue' value =
        value
        |> stringifyAspectRatio
        |> aspectRatioValue

    type AspectRatio =
        static member Value (width: int, height: int) =
            $"{width} / {height}"
            |> aspectRatioValue
        static member Inherit = FssTypes.Inherit |> aspectRatioValue'
        static member Initial = FssTypes.Initial |> aspectRatioValue'
        static member Unset = FssTypes.Unset |> aspectRatioValue'

    let AspectRatio' width height = aspectRatioValue(width, height)
