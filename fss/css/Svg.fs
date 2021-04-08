namespace Fss

open Fable.Core

[<AutoOpen>]
module Svg =

    let private alignmentBaselineValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignmentBaseline
    let private alignmentBaselineValue' = Utilities.Helpers.duToKebab >> alignmentBaselineValue

    [<Erase>]
    type AlignmentBaseline =
        static member value (all: FssTypes.Svg.AlignmentBaseline) = all |> alignmentBaselineValue'
        static member baseline = FssTypes.Svg.Baseline |> alignmentBaselineValue'
        static member textBottom = FssTypes.Svg.TextBottom |> alignmentBaselineValue'
        static member textBeforeEdge = FssTypes.Svg.TextBeforeEdge |> alignmentBaselineValue'
        static member middle = FssTypes.Svg.Middle |> alignmentBaselineValue'
        static member central = FssTypes.Svg.Central |> alignmentBaselineValue'
        static member textTop = FssTypes.Svg.TextTop |> alignmentBaselineValue'
        static member textAfterEdge = FssTypes.Svg.TextAfterEdge |> alignmentBaselineValue'
        static member ideographic = FssTypes.Svg.Ideographic |> alignmentBaselineValue'
        static member alphabetic = FssTypes.Svg.Alphabetic |> alignmentBaselineValue'
        static member hanging = FssTypes.Svg.Hanging |> alignmentBaselineValue'
        static member mathematical = FssTypes.Svg.Mathematical |> alignmentBaselineValue'
        static member top = FssTypes.Svg.Top |> alignmentBaselineValue'
        static member center = FssTypes.Svg.Center |> alignmentBaselineValue'
        static member bottom = FssTypes.Svg.Bottom |> alignmentBaselineValue'

    /// <summary>Specifies how an object is align to its parent.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> AlignmentBaseline </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AlignmentBaseline' = AlignmentBaseline.value
