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
        static member Value (overflow: FssTypes.IOverflow) = overflow |> overflowValue'
        static member Value (x: FssTypes.IOverflow, y: FssTypes.IOverflow) =
            sprintf "%s %s"
                (overflowToString x)
                (overflowToString y)
            |> overflowValue
        static member Visible = FssTypes.Overflow.Visible |> overflowValue'
        static member Hidden = FssTypes.Overflow.Hidden |> overflowValue'
        static member Clip = FssTypes.Overflow.Clip |> overflowValue'
        static member Scroll = FssTypes.Overflow.Scroll |> overflowValue'

        static member Auto = FssTypes.Auto |> overflowValue'
        static member Inherit = FssTypes.Inherit |> overflowValue'
        static member Initial = FssTypes.Initial |> overflowValue'
        static member Unset = FssTypes.Unset |> overflowValue'

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
    let Overflow' (overflow: FssTypes.IOverflow) = Overflow.Value(overflow)

    let private overflowXValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowX value
    let private overflowXValue' value =
        value
        |> overflowToString
        |> overflowXValue

    type OverflowX =
        static member Value (overflow: FssTypes.IOverflow) = overflow |> overflowXValue'
        static member Visible = FssTypes.Overflow.Visible |> overflowXValue'
        static member Hidden = FssTypes.Overflow.Hidden |> overflowXValue'
        static member Clip = FssTypes.Overflow.Clip |> overflowXValue'
        static member Scroll = FssTypes.Overflow.Scroll |> overflowXValue'

        static member Auto = FssTypes.Auto |> overflowXValue'
        static member Inherit = FssTypes.Inherit |> overflowXValue'
        static member Initial = FssTypes.Initial |> overflowXValue'
        static member Unset = FssTypes.Unset |> overflowXValue'

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
    let OverflowX' (overflow: FssTypes.IOverflow) = OverflowX.Value(overflow)

    let private overflowYValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowY value
    let private overflowYValue' value =
        value
        |> overflowToString
        |> overflowYValue

    type OverflowY =
        static member Value (overflow: FssTypes.IOverflow) = overflow |> overflowYValue'
        static member Visible = FssTypes.Overflow.Visible |> overflowYValue'
        static member Hidden = FssTypes.Overflow.Hidden |> overflowYValue'
        static member Clip = FssTypes.Overflow.Clip |> overflowYValue'
        static member Scroll = FssTypes.Overflow.Scroll |> overflowYValue'

        static member Auto = FssTypes.Auto |> overflowYValue'
        static member Inherit = FssTypes.Inherit |> overflowYValue'
        static member Initial = FssTypes.Initial |> overflowYValue'
        static member Unset = FssTypes.Unset |> overflowYValue'

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
    let OverflowY' (overflow: FssTypes.IOverflow) = OverflowY.Value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    let private overflowWrapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.OverflowWrap value
    let private overflowWrapValue' value =
        value
        |> wrapToString
        |> overflowWrapValue

    type OverflowWrap =
        static member Value (overflowWrap: FssTypes.IOverflowWrap) = overflowWrap |> overflowWrapValue'
        static member BreakWord = FssTypes.Overflow.Wrap.BreakWord |> overflowWrapValue'
        static member Anywhere = FssTypes.Overflow.Wrap.Anywhere |> overflowWrapValue'

        static member Normal = FssTypes.Normal |> overflowWrapValue'
        static member Inherit = FssTypes.Inherit |> overflowWrapValue'
        static member Initial = FssTypes.Initial |> overflowWrapValue'
        static member Unset = FssTypes.Unset |> overflowWrapValue'

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
    let OverflowWrap' (overflowWrap: FssTypes.IOverflowWrap) = OverflowWrap.Value(overflowWrap)