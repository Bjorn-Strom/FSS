namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Margin =
    [<RequireQualifiedAccess>]
    module MarginClasses =
        type MarginDirection(property) =
            inherit CssRule(property)

            member this.value(length: ILengthPercentage) =
                (property, lengthPercentageToType length) |> Rule

            member this.auto = (property, Auto) |> Rule

        type Margin(property) =
            inherit DirectionalLength(property)
            member this.auto = (property, Auto) |> Rule
