namespace Fss

module OverflowType =
    type Overflow =
        | Visible
        | Hidden
        | Clip
        | Scroll
        interface IOverflow

    type OverflowWrap =
        | BreakWord
        | Anywhere
        interface IOverflowWrap

// https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
[<AutoOpen>]
module Overflow =
    open OverflowType

    let private overflowToString (overflow: IOverflow) =
        let stringifyOverflow =
            function
                | Visible -> "visible"
                | Hidden -> "hidden"
                | Clip -> "clip"
                | Scroll -> "scroll"

        match overflow with
        | :? Overflow as o -> stringifyOverflow o
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown overflow"

    let private wrapToString (wrap: IOverflowWrap) =
        let stringifyWrap =
            function
                | BreakWord -> "break-word"
                | Anywhere -> "anywhere"

        match wrap with
        | :? OverflowWrap as o -> stringifyWrap o
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown overflow wrap"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
    let private overflowValue value = PropertyValue.cssValue Property.Overflow value
    let private overflowValue' value =
        value
        |> overflowToString
        |> overflowValue

    type Overflow =
        static member Value (overflow: IOverflow) = overflow |> overflowValue'
        static member Value (x: IOverflow, y: IOverflow) =
            sprintf "%s %s"
                (overflowToString x)
                (overflowToString y)
            |> overflowValue
        static member Visible = Visible |> overflowValue'
        static member Hidden = Hidden |> overflowValue'
        static member Clip = Clip |> overflowValue'
        static member Scroll = Scroll |> overflowValue'

        static member Auto = Auto |> overflowValue'
        static member Inherit = Inherit |> overflowValue'
        static member Initial = Initial |> overflowValue'
        static member Unset = Unset |> overflowValue'

    let Overflow' (overflow: IOverflow) = Overflow.Value(overflow)

    let private overflowXValue value = PropertyValue.cssValue Property.OverflowX value
    let private overflowXValue' value =
        value
        |> overflowToString
        |> overflowXValue

    type OverflowX =
        static member Value (overflow: IOverflow) = overflow |> overflowXValue'
        static member Visible = Visible |> overflowXValue'
        static member Hidden = Hidden |> overflowXValue'
        static member Clip = Clip |> overflowXValue'
        static member Scroll = Scroll |> overflowXValue'

        static member Auto = Auto |> overflowXValue'
        static member Inherit = Inherit |> overflowXValue'
        static member Initial = Initial |> overflowXValue'
        static member Unset = Unset |> overflowXValue'

    let OverflowX' (overflow: IOverflow) = OverflowX.Value(overflow)

    let private overflowYValue value = PropertyValue.cssValue Property.OverflowY value
    let private overflowYValue' value =
        value
        |> overflowToString
        |> overflowYValue

    type OverflowY =
        static member Value (overflow: IOverflow) = overflow |> overflowYValue'
        static member Visible = Visible |> overflowYValue'
        static member Hidden = Hidden |> overflowYValue'
        static member Clip = Clip |> overflowYValue'
        static member Scroll = Scroll |> overflowYValue'

        static member Auto = Auto |> overflowYValue'
        static member Inherit = Inherit |> overflowYValue'
        static member Initial = Initial |> overflowYValue'
        static member Unset = Unset |> overflowYValue'

    let OverflowY' (overflow: IOverflow) = OverflowY.Value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    let private overflowWrapValue value = PropertyValue.cssValue Property.OverflowWrap value
    let private overflowWrapValue' value =
        value
        |> wrapToString
        |> overflowWrapValue

    type OverflowWrap =
        static member Value (overflowWrap: IOverflowWrap) = overflowWrap |> overflowWrapValue'
        static member BreakWord = BreakWord |> overflowWrapValue'
        static member Anywhere = Anywhere |> overflowWrapValue'

        static member Normal = Normal |> overflowWrapValue'
        static member Inherit = Inherit |> overflowWrapValue'
        static member Initial = Initial |> overflowWrapValue'
        static member Unset = Unset |> overflowWrapValue'

    let OverflowWrap' (overflowWrap: IOverflowWrap) = OverflowWrap.Value(overflowWrap)