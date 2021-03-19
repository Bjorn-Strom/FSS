namespace Fss

open FssTypes

[<AutoOpen>]
module AspectRatio =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/aspect-ratio
    let private stringifyAspectRatio (all: IAll) =
        match all with
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown all"

    let private aspectRatioValue value = PropertyValue.cssValue Property.AspectRatio value
    let private aspectRatioValue' value =
        value
        |> stringifyAspectRatio
        |> aspectRatioValue

    type AspectRatio =
        static member Value (width: int, height: int) =
            $"{width} / {height}"
            |> aspectRatioValue
        static member Inherit = Inherit |> aspectRatioValue'
        static member Initial = Initial |> aspectRatioValue'
        static member Unset = Unset |> aspectRatioValue'

    let AspectRatio' width height = aspectRatioValue(width, height)
