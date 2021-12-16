namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Padding =
    [<RequireQualifiedAccess>]
    module PaddingClasses =
        type PaddingDirection(property) =
            inherit CssRule(property)

            member this.value(length: ILengthPercentage) =
                (property, lengthPercentageToType length) |> Rule

            member this.auto = (property, Auto) |> Rule

        type Padding(property) =
            inherit DirectionalLength(property)
            member this.auto = (property, Auto) |> Rule
