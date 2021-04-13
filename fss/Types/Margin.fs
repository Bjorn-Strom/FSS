namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Margin =
        type MarginSide (marginValue': IMargin -> CssProperty) =
            member this.value (margin: IMargin) = margin |> marginValue'
            member this.auto = Auto |> marginValue'
            member this.inherit' = Inherit |> marginValue'
            member this.initial = Initial |> marginValue'
            member this.unset = Unset |> marginValue'

        type Margin (marginToString: IMargin -> string, marginValue: string -> CssProperty, marginValue': IMargin -> CssProperty) =
            inherit MarginSide(marginValue')
            member this.value (vertical: IMargin, horizontal: IMargin) =
                sprintf "%s %s"
                    (marginToString vertical)
                    (marginToString horizontal)
                |> marginValue
            member this.value (top: IMargin, auto: IMargin, bottom: IMargin) =
                sprintf "%s %s %s"
                    (marginToString top)
                    (marginToString auto)
                    (marginToString bottom)
                |> marginValue
            member this.value (top: IMargin, right: IMargin, bottom: IMargin, left: IMargin) =
                sprintf "%s %s %s %s"
                    (marginToString top)
                    (marginToString right)
                    (marginToString bottom)
                    (marginToString left)
                |> marginValue