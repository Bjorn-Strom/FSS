namespace Fss

open FssTypes

[<AutoOpen>]
module AspectRatio =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/aspect-ratio
    let private stringifyAspectRatio (all: IAll) =
        match all with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown all"

    let private aspectRatioValue value = Types.cssValue Types.Property.AspectRatio value
    let private aspectRatioValue' value =
        value
        |> stringifyAspectRatio
        |> aspectRatioValue

    type AspectRatio =
        static member Value (width: int, height: int) =
            $"{width} / {height}"
            |> aspectRatioValue
        static member Inherit = Types.Inherit |> aspectRatioValue'
        static member Initial = Types.Initial |> aspectRatioValue'
        static member Unset = Types.Unset |> aspectRatioValue'

    let AspectRatio' width height = aspectRatioValue(width, height)
