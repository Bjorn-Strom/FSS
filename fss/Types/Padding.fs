namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Padding =
        type PaddingSide (paddingValue': IPadding -> CssProperty) =
            member this.value (padding: IPadding) = padding |> paddingValue'
            member this.auto = Auto |> paddingValue'
            member this.inherit' = Inherit |> paddingValue'
            member this.initial = Initial |> paddingValue'
            member this.unset = Unset |> paddingValue'

        type Padding (paddingToString: IPadding -> string, paddingValue: string -> CssProperty, paddingValue': IPadding -> CssProperty) =
            inherit PaddingSide(paddingValue')
            member this.value (vertical: IPadding, horizontal: IPadding) =
                sprintf "%s %s"
                    (paddingToString vertical)
                    (paddingToString horizontal)
                |> paddingValue
            member this.value (top: IPadding, auto: IPadding, bottom: IPadding) =
                sprintf "%s %s %s"
                    (paddingToString top)
                    (paddingToString auto)
                    (paddingToString bottom)
                |> paddingValue
            member this.value (top: IPadding, right: IPadding, bottom: IPadding, left: IPadding) =
                sprintf "%s %s %s %s"
                    (paddingToString top)
                    (paddingToString right)
                    (paddingToString bottom)
                    (paddingToString left)
                |> paddingValue