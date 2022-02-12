namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module AspectRatioClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/aspect-ratio
    type AspectRatio(property) =
        inherit CssRule(property)
        member this.value(aspectRatio: int) = (property, Int aspectRatio) |> Rule

        member this.value(width: int, height: int) =
            (property, DividerMaster(string width, string height))
            |> Rule
