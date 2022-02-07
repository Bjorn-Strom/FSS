namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module MarginClasses =
    type MarginDirection(property) =
        inherit CssRuleWithAutoLength(property)

    type Margin(property) =
        inherit DirectionalLength(property)
        member this.auto = (property, Auto) |> Rule
