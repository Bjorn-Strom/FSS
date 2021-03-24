namespace Fss

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
    let private overflowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Overflow value
    let private overflowValue' value =
        value
        |> overflowToString
        |> overflowValue

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

    /// <summary>Specifies overflow behavior.</summary>
    /// <param name="overflow">
    ///     can be:
    ///     - <c> Overflow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Overflow' (overflow: FssTypes.IOverflow) = Overflow.value(overflow)

    let private overflowXValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowX value
    let private overflowXValue' value =
        value
        |> overflowToString
        |> overflowXValue

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

    /// <summary>Specifies overflow left and right edge behavior.</summary>
    /// <param name="overflow">
    ///     can be:
    ///     - <c> Overflow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OverflowX' (overflow: FssTypes.IOverflow) = OverflowX.value(overflow)

    let private overflowYValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowY value
    let private overflowYValue' value =
        value
        |> overflowToString
        |> overflowYValue

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

    /// <summary>Specifies overflow top and bottom edge behavior.</summary>
    /// <param name="overflow">
    ///     can be:
    ///     - <c> Overflow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OverflowY' (overflow: FssTypes.IOverflow) = OverflowY.value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    let private overflowWrapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowWrap value
    let private overflowWrapValue' value =
        value
        |> wrapToString
        |> overflowWrapValue

    type OverflowWrap =
        static member value (overflowWrap: FssTypes.IOverflowWrap) = overflowWrap |> overflowWrapValue'
        static member breakWord = FssTypes.Overflow.Wrap.BreakWord |> overflowWrapValue'
        static member anywhere = FssTypes.Overflow.Wrap.Anywhere |> overflowWrapValue'

        static member normal = FssTypes.Normal |> overflowWrapValue'
        static member inherit' = FssTypes.Inherit |> overflowWrapValue'
        static member initial = FssTypes.Initial |> overflowWrapValue'
        static member unset = FssTypes.Unset |> overflowWrapValue'

    /// <summary>Specifies how to insert line breaks on overflow.</summary>
    /// <param name="overflowWrap">
    ///     can be:
    ///     - <c> Overflow </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let OverflowWrap' (overflowWrap: FssTypes.IOverflowWrap) = OverflowWrap.value(overflowWrap)