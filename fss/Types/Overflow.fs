namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Overflow =
        type Overflow =
            | Visible
            | Hidden
            | Clip
            | Scroll
            interface IOverflow

        type Wrap =
            | BreakWord
            | Anywhere
            interface IOverflowWrap

        type OverflowClass (overflowToString: IOverflow -> string, overflowValue: string -> CssProperty, overflowValue': IOverflow -> CssProperty) =
            member this.value (overflow: IOverflow) = overflow |> overflowValue'
            member this.value (x: IOverflow, y: IOverflow) =
                sprintf "%s %s"
                    (overflowToString x)
                    (overflowToString y)
                |> overflowValue
            member this.visible = Visible |> overflowValue'
            member this.hidden = Hidden |> overflowValue'
            member this.clip = Clip |> overflowValue'
            member this.scroll = Scroll |> overflowValue'

            member this.auto = Auto |> overflowValue'
            member this.inherit' = Inherit |> overflowValue'
            member this.initial = Initial |> overflowValue'
            member this.unset = Unset |> overflowValue'