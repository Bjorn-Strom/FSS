namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Outline =
        type Width =
            | Thin
            | Medium
            | Thick
            interface IOutlineWidth

        type Style =
            | Hidden
            | Dotted
            | Dashed
            | Solid
            | Double
            | Groove
            | Ridge
            | Inset
            | Outset
            interface IOutlineStyle

    type OutlineColorClass (valueFunction: IOutlineColor -> CssProperty) =
        inherit ColorBase(valueFunction)
        member this.value color = color |> valueFunction
        member this.inherit' = Inherit |> valueFunction
        member this.initial = Initial |> valueFunction
        member this.unset = Unset |> valueFunction
