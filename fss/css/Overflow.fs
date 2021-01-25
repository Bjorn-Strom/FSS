namespace Fss

[<RequireQualifiedAccess>]
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

    let private overflowToString (overflow: IOverflow) =
        match overflow with
        | :? OverflowType.Overflow as o -> Utilities.Helpers.duToLowercase o
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown overflow"

    let private wrapToString (wrap: IOverflowWrap) =
        match wrap with
        | :? OverflowType.OverflowWrap as o -> Utilities.Helpers.duToKebab o
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
        static member Visible = OverflowType.Visible |> overflowValue'
        static member Hidden = OverflowType.Hidden |> overflowValue'
        static member Clip = OverflowType.Clip |> overflowValue'
        static member Scroll = OverflowType.Scroll |> overflowValue'

        static member Auto = Auto |> overflowValue'
        static member Inherit = Inherit |> overflowValue'
        static member Initial = Initial |> overflowValue'
        static member Unset = Unset |> overflowValue'

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
    let Overflow' (overflow: IOverflow) = Overflow.Value(overflow)

    let private overflowXValue value = PropertyValue.cssValue Property.OverflowX value
    let private overflowXValue' value =
        value
        |> overflowToString
        |> overflowXValue

    type OverflowX =
        static member Value (overflow: IOverflow) = overflow |> overflowXValue'
        static member Visible = OverflowType.Visible |> overflowXValue'
        static member Hidden = OverflowType.Hidden |> overflowXValue'
        static member Clip = OverflowType.Clip |> overflowXValue'
        static member Scroll = OverflowType.Scroll |> overflowXValue'

        static member Auto = Auto |> overflowXValue'
        static member Inherit = Inherit |> overflowXValue'
        static member Initial = Initial |> overflowXValue'
        static member Unset = Unset |> overflowXValue'

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
    let OverflowX' (overflow: IOverflow) = OverflowX.Value(overflow)

    let private overflowYValue value = PropertyValue.cssValue Property.OverflowY value
    let private overflowYValue' value =
        value
        |> overflowToString
        |> overflowYValue

    type OverflowY =
        static member Value (overflow: IOverflow) = overflow |> overflowYValue'
        static member Visible = OverflowType.Visible |> overflowYValue'
        static member Hidden = OverflowType.Hidden |> overflowYValue'
        static member Clip = OverflowType.Clip |> overflowYValue'
        static member Scroll = OverflowType.Scroll |> overflowYValue'

        static member Auto = Auto |> overflowYValue'
        static member Inherit = Inherit |> overflowYValue'
        static member Initial = Initial |> overflowYValue'
        static member Unset = Unset |> overflowYValue'

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
    let OverflowY' (overflow: IOverflow) = OverflowY.Value(overflow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/overflow-wrap
    let private overflowWrapValue value = PropertyValue.cssValue Property.OverflowWrap value
    let private overflowWrapValue' value =
        value
        |> wrapToString
        |> overflowWrapValue

    type OverflowWrap =
        static member Value (overflowWrap: IOverflowWrap) = overflowWrap |> overflowWrapValue'
        static member BreakWord = OverflowType.BreakWord |> overflowWrapValue'
        static member Anywhere = OverflowType.Anywhere |> overflowWrapValue'

        static member Normal = Normal |> overflowWrapValue'
        static member Inherit = Inherit |> overflowWrapValue'
        static member Initial = Initial |> overflowWrapValue'
        static member Unset = Unset |> overflowWrapValue'

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
    let OverflowWrap' (overflowWrap: IOverflowWrap) = OverflowWrap.Value(overflowWrap)