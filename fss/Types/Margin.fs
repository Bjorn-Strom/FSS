namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Margin =
    [<RequireQualifiedAccess>]
    module MarginClasses =
        type MarginDirection(property) =
            inherit CssRuleWithAutoLength(property)

        type Margin(property) =
            inherit DirectionalLength(property)
            member this.auto = (property, Auto) |> Rule
