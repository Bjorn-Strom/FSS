namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module TypographyClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/orphans
    // https://developer.mozilla.org/en-US/docs/Web/CSS/widows
    type Typography(property) =
        inherit CssRule(property)
        member this.value(value: int) = (property, Int value) |> Rule
