namespace Fss

module VisibilityType =
    type VisibilityType =
        | Visible
        | Hidden
        | Collapse
        interface IVisibility

    let visibilityToString (visibility: IVisibility) =
        let stringifyVisibility =
            function
                | Visible -> "visible"
                | Hidden -> "hidden"
                | Collapse -> "collapse"

        match visibility with
        | :? VisibilityType as v -> stringifyVisibility v
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown visibility"

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
[<AutoOpen>]
module Visibility =
    open VisibilityType

    let private visibilityValue value = PropertyValue.cssValue Property.Visibility value
    let private visibilityValue' value =
        value
        |> visibilityToString
        |> visibilityValue

    type Visibility =
        static member Value (visibility: IVisibility) = visibility |> visibilityValue'
        static member Visible = Visible |> visibilityValue'
        static member Hidden = Hidden |> visibilityValue'
        static member Collapse = Collapse |> visibilityValue'

        static member Inherit = Inherit |> visibilityValue'
        static member Initial = Initial |> visibilityValue'
        static member Unset = Unset |> visibilityValue'

    let Visibility' (visibility: IVisibility) = Visibility.Value(visibility)

// https://developer.mozilla.org/en-US/docs/Web/CSS/opacity
[<AutoOpen>]
module Opacity =
    type Opacity =
        static member Value value =
            PropertyValue.cssValue Property.Opacity
            <| string (Utilities.Helpers.clamp 0.0 1.0 value)

    let Opacity' (opacity: float) = Opacity.Value(opacity)

module OverflowType =
    type OverflowType =
        | Visible
        | Hidden
        | Clip
        | Scroll
        interface IOverflow

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
        | :? OverflowType as o -> stringifyOverflow o
        | :? Keywords as k -> GlobalValue.keywords k
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown overflow"

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
