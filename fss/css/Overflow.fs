namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
[<AutoOpen>]
module Overflow =

    let private overflowToString (overflow: FssTypes.IOverflow) =
        match overflow with
        | :? FssTypes.Overflow.Overflow as o -> Utilities.Helpers.duToLowercase o
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown overflow"

    let private wrapToString (wrap: FssTypes.IOverflowWrap) =
        match wrap with
        | :? FssTypes.Overflow.Wrap as o -> Utilities.Helpers.duToKebab o
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown overflow wrap"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
    let private overflowValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Overflow
    let private overflowValue' = overflowToString >> overflowValue

    [<Erase>]
    /// Specifies overflow behavior.
    type Overflow =
        static member value (overflow: FssTypes.IOverflow) = overflow |> overflowValue'
        static member value (x: FssTypes.IOverflow, y: FssTypes.IOverflow) =
            sprintf "%s %s"
                (overflowToString x)
                (overflowToString y)
            |> overflowValue
        static member visible = FssTypes.Overflow.Visible |> overflowValue'
        static member hidden = FssTypes.Overflow.Hidden |> overflowValue'
        static member clip = FssTypes.Overflow.Clip |> overflowValue'
        static member scroll = FssTypes.Overflow.Scroll |> overflowValue'

        static member auto = FssTypes.Auto |> overflowValue'
        static member inherit' = FssTypes.Inherit |> overflowValue'
        static member initial = FssTypes.Initial |> overflowValue'
        static member unset = FssTypes.Unset |> overflowValue'

    /// Specifies overflow behavior.
    /// Valid parameters:
    /// - Overflow
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let Overflow' = Overflow.value

    let private overflowXValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowX
    let private overflowXValue' = overflowToString >> overflowXValue

    [<Erase>]
    /// Specifies overflow left and right edge behavior.
    type OverflowX =
        static member value (overflow: FssTypes.IOverflow) = overflow |> overflowXValue'
        static member visible = FssTypes.Overflow.Visible |> overflowXValue'
        static member hidden = FssTypes.Overflow.Hidden |> overflowXValue'
        static member clip = FssTypes.Overflow.Clip |> overflowXValue'
        static member scroll = FssTypes.Overflow.Scroll |> overflowXValue'

        static member auto = FssTypes.Auto |> overflowXValue'
        static member inherit' = FssTypes.Inherit |> overflowXValue'
        static member initial = FssTypes.Initial |> overflowXValue'
        static member unset = FssTypes.Unset |> overflowXValue'

    /// Specifies overflow left and right edge behavior.
    /// Valid parameters:
    /// - Overflow
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let OverflowX' = OverflowX.value

    let private overflowYValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowY
    let private overflowYValue' = overflowToString >> overflowYValue

    [<Erase>]
    /// Specifies overflow top and bottom edge behavior.
    type OverflowY =
        static member value (overflow: FssTypes.IOverflow) = overflow |> overflowYValue'
        static member visible = FssTypes.Overflow.Visible |> overflowYValue'
        static member hidden = FssTypes.Overflow.Hidden |> overflowYValue'
        static member clip = FssTypes.Overflow.Clip |> overflowYValue'
        static member scroll = FssTypes.Overflow.Scroll |> overflowYValue'

        static member auto = FssTypes.Auto |> overflowYValue'
        static member inherit' = FssTypes.Inherit |> overflowYValue'
        static member initial = FssTypes.Initial |> overflowYValue'
        static member unset = FssTypes.Unset |> overflowYValue'

    /// Specifies overflow top and bottom edge behavior.
    /// Valid parameters:
    /// - Overflow
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let OverflowY' = OverflowY.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    let private overflowWrapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowWrap
    let private overflowWrapValue' = wrapToString >> overflowWrapValue

    [<Erase>]
    /// Specifies how to insert line breaks on overflow.
    type OverflowWrap =
        static member value (overflowWrap: FssTypes.IOverflowWrap) = overflowWrap |> overflowWrapValue'
        static member breakWord = FssTypes.Overflow.Wrap.BreakWord |> overflowWrapValue'
        static member anywhere = FssTypes.Overflow.Wrap.Anywhere |> overflowWrapValue'

        static member normal = FssTypes.Normal |> overflowWrapValue'
        static member inherit' = FssTypes.Inherit |> overflowWrapValue'
        static member initial = FssTypes.Initial |> overflowWrapValue'
        static member unset = FssTypes.Unset |> overflowWrapValue'

    /// Specifies how to insert line breaks on overflow.
    /// Valid parameters:
    /// - Overflow
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Normal
    let OverflowWrap' = OverflowWrap.value