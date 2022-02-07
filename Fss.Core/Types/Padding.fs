namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module PaddingClasses =
    type PaddingDirection(property) =
        inherit CssRuleWithAutoLength(property)

    type Padding(property) =
        inherit DirectionalLength(property)
        member this.auto = (property, Auto) |> Rule
