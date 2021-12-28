namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Padding =
    [<RequireQualifiedAccess>]
    module PaddingClasses =
        type PaddingDirection(property) =
            inherit CssRuleWithAutoLength(property)

        type Padding(property) =
            inherit DirectionalLength(property)
            member this.auto = (property, Auto) |> Rule
