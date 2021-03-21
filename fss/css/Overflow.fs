namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
[<AutoOpen>]
module Overflow =

    let private overflowToString (overflow: Types.IOverflow) =
        match overflow with
        | :? Types.Overflow as o -> Utilities.Helpers.duToLowercase o
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | _ -> "Unknown overflow"

    let private wrapToString (wrap: Types.IOverflowWrap) =
        match wrap with
        | :? Types.OverflowWrap as o -> Utilities.Helpers.duToKebab o
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown overflow wrap"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow
    let private overflowValue value = Types.propertyHelpers.cssValue Types.Property.Overflow value
    let private overflowValue' value =
        value
        |> overflowToString
        |> overflowValue

    type Overflow =
        static member Value (overflow: Types.IOverflow) = overflow |> overflowValue'
        static member Value (x: Types.IOverflow, y: Types.IOverflow) =
            sprintf "%s %s"
                (overflowToString x)
                (overflowToString y)
            |> overflowValue
        static member Visible = Types.Overflow.Visible |> overflowValue'
        static member Hidden = Types.Overflow.Hidden |> overflowValue'
        static member Clip = Types.Overflow.Clip |> overflowValue'
        static member Scroll = Types.Overflow.Scroll |> overflowValue'

        static member Auto = Types.Auto |> overflowValue'
        static member Inherit = Types.Inherit |> overflowValue'
        static member Initial = Types.Initial |> overflowValue'
        static member Unset = Types.Unset |> overflowValue'

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
    let Overflow' (overflow: Types.IOverflow) = Overflow.Value(overflow)

    let private overflowXValue value = Types.propertyHelpers.cssValue Types.Property.OverflowX value
    let private overflowXValue' value =
        value
        |> overflowToString
        |> overflowXValue

    type OverflowX =
        static member Value (overflow: Types.IOverflow) = overflow |> overflowXValue'
        static member Visible = Types.Overflow.Visible |> overflowXValue'
        static member Hidden = Types.Overflow.Hidden |> overflowXValue'
        static member Clip = Types.Overflow.Clip |> overflowXValue'
        static member Scroll = Types.Overflow.Scroll |> overflowXValue'

        static member Auto = Types.Auto |> overflowXValue'
        static member Inherit = Types.Inherit |> overflowXValue'
        static member Initial = Types.Initial |> overflowXValue'
        static member Unset = Types.Unset |> overflowXValue'

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
    let OverflowX' (overflow: Types.IOverflow) = OverflowX.Value(overflow)

    let private overflowYValue value = Types.propertyHelpers.cssValue Types.Property.OverflowY value
    let private overflowYValue' value =
        value
        |> overflowToString
        |> overflowYValue

    type OverflowY =
        static member Value (overflow: Types.IOverflow) = overflow |> overflowYValue'
        static member Visible = Types.Overflow.Visible |> overflowYValue'
        static member Hidden = Types.Overflow.Hidden |> overflowYValue'
        static member Clip = Types.Overflow.Clip |> overflowYValue'
        static member Scroll = Types.Overflow.Scroll |> overflowYValue'

        static member Auto = Types.Auto |> overflowYValue'
        static member Inherit = Types.Inherit |> overflowYValue'
        static member Initial = Types.Initial |> overflowYValue'
        static member Unset = Types.Unset |> overflowYValue'

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
    let OverflowY' (overflow: Types.IOverflow) = OverflowY.Value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    let private overflowWrapValue value = Types.propertyHelpers.cssValue Types.Property.OverflowWrap value
    let private overflowWrapValue' value =
        value
        |> wrapToString
        |> overflowWrapValue

    type OverflowWrap =
        static member Value (overflowWrap: Types.IOverflowWrap) = overflowWrap |> overflowWrapValue'
        static member BreakWord = Types.OverflowWrap.BreakWord |> overflowWrapValue'
        static member Anywhere = Types.OverflowWrap.Anywhere |> overflowWrapValue'

        static member Normal = Types.Normal |> overflowWrapValue'
        static member Inherit = Types.Inherit |> overflowWrapValue'
        static member Initial = Types.Initial |> overflowWrapValue'
        static member Unset = Types.Unset |> overflowWrapValue'

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
    let OverflowWrap' (overflowWrap: Types.IOverflowWrap) = OverflowWrap.Value(overflowWrap)