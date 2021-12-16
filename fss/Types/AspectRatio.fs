namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module AspectRatio =
    [<RequireQualifiedAccess>]
    module AspectRatioClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/aspect-ratio
        type AspectRatio(property) =
            inherit CssRule(property)
            member this.value(aspectRatio: int) = (property, Int aspectRatio) |> Rule

            member this.value(width: int, height: int) =
                (property, Divider(string width, string height))
                |> Rule
