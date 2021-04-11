namespace Fss

open Fable.Core

[<AutoOpen>]
module Svg =
    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/alignment-baseline
    let private alignmentBaselineValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignmentBaseline
    let private alignmentBaselineValue' = Utilities.Helpers.duToKebab >> alignmentBaselineValue

    [<Erase>]
    type AlignmentBaseline =
        static member value (alignment: FssTypes.Svg.AlignmentBaseline) = alignment |> alignmentBaselineValue'
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

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/baseline-shift
    let private stringifyBaselineShift (baselineShift: FssTypes.IBaselineShift) =
        match baselineShift with
        | :? FssTypes.Svg.BaselineShift as bs -> Utilities.Helpers.duToLowercase bs
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | _ -> "Unknown baseline shift"

    let private baselineShiftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BaselineShift
    let private baselineShiftValue' = stringifyBaselineShift >> baselineShiftValue

    [<Erase>]
    type BaselineShift =
        static member value (baselineShift: FssTypes.IBaselineShift) = baselineShift |> baselineShiftValue'
        static member sub = FssTypes.Svg.Sub |> baselineShiftValue'
        static member super = FssTypes.Svg.Super |> baselineShiftValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> Baselineshift </c>
    ///     - <c> Size </c>
    ///     - <c> Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BaselineShift' = BaselineShift.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/dominant-baseline
    let private stringifyDominantBaseline (dominantBaseline: FssTypes.IDominantBaseline) =
        match dominantBaseline with
        | :? FssTypes.Svg.DominantBaseline as ds -> Utilities.Helpers.duToKebab ds
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown baseline shift"

    let private dominantBaselineValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.DominantBaseline
    let private dominantBaselineValue' = stringifyDominantBaseline >> dominantBaselineValue

    [<Erase>]
    type DominantBaseline =
        static member value (dominantBaseline: FssTypes.IDominantBaseline) = dominantBaseline |> dominantBaselineValue'
        static member ideographic = FssTypes.Svg.DominantBaseline.Ideographic |> dominantBaselineValue'
        static member alphabetic = FssTypes.Svg.DominantBaseline.Alphabetic |> dominantBaselineValue'
        static member hanging = FssTypes.Svg.DominantBaseline.Hanging |> dominantBaselineValue'
        static member mathematical = FssTypes.Svg.DominantBaseline.Mathematical |> dominantBaselineValue'
        static member central = FssTypes.Svg.DominantBaseline.Central |> dominantBaselineValue'
        static member middle = FssTypes.Svg.DominantBaseline.Middle |> dominantBaselineValue'
        static member textAfterEdge = FssTypes.Svg.DominantBaseline.TextAfterEdge |> dominantBaselineValue'
        static member textBeforeEdge = FssTypes.Svg.DominantBaseline.TextBeforeEdge |> dominantBaselineValue'
        static member textTop = FssTypes.Svg.DominantBaseline.TextTop |> dominantBaselineValue'
        static member auto = FssTypes.Auto |> dominantBaselineValue'

    /// <summary>Specifies the dominant baseline.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> DominantBaseline </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let DominantBaseline' = DominantBaseline.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/text-anchor
    let private textAnchorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.TextAnchor
    let private textAnchorValue' = Utilities.Helpers.duToKebab >> textAnchorValue

    [<Erase>]
    type TextAnchor=
        static member value (textAnchor: FssTypes.Svg.TextAnchor) = textAnchor |> textAnchorValue'
        static member start = FssTypes.Svg.TextAnchor.Start |> textAnchorValue'
        static member middle = FssTypes.Svg.TextAnchor.Middle |> textAnchorValue'
        static member end' = FssTypes.Svg.TextAnchor.End |> textAnchorValue'

    /// <summary>Align text.</summary>
    /// <param name="textAnchor">
    ///     can be:
    ///     - <c> TextAnchorline </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TextAnchor' = TextAnchor.value

    // https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/clip-rule
    let private clipRuleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ClipRule
    let private clipRuleValue' = Utilities.Helpers.duToLowercase >> clipRuleValue

    [<Erase>]
    type ClipRule=
        static member value (clipRule: FssTypes.Svg.ClipRule) = clipRule |> clipRuleValue'
        static member nonzero = FssTypes.Svg.ClipRule.Nonzero |> clipRuleValue'
        static member evenodd = FssTypes.Svg.ClipRule.Evenodd |> clipRuleValue'

    /// <summary>Align text.</summary>
    /// <param name="clipRule">
    ///     can be:
    ///     - <c> ClipRuleline </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ClipRule' = ClipRule.value