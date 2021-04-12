namespace Fss

open Fable.Core

[<AutoOpen>]
module Perspective =
    let private perspectiveToString (perspective: FssTypes.IPerspective) =
        match perspective with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown perspective"

    let private perspectiveOriginToString (perspectiveOrigin: FssTypes.IPerspectiveOrigin) =
        match perspectiveOrigin with
        | :? FssTypes.Percent as s -> FssTypes.unitHelpers.percentToString s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown perspective origin"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/perspective
    let private perspectiveValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Perspective
    let private perspectiveValue' = perspectiveToString >> perspectiveValue

    [<Erase>]
    type Perspective =
        static member value (perspective: FssTypes.IPerspective) = perspective |> perspectiveValue'
        static member none = FssTypes.None' |> perspectiveValue'
        static member inherit' = FssTypes.Inherit |> perspectiveValue'
        static member initial = FssTypes.Initial |> perspectiveValue'
        static member unset = FssTypes.Unset |> perspectiveValue'

    /// <summary>Specifies distance in z plane.</summary>
    /// <param name="perspective">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Perspective' = Perspective.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/perspective-origin
    let private perspectiveOriginValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PerspectiveOrigin
    let private perspectiveOriginValue' = perspectiveOriginToString >> perspectiveOriginValue

    [<Erase>]
    type PerspectiveOrigin =
        static member value (origin: FssTypes.IPerspectiveOrigin) = origin |> perspectiveOriginValue'
        static member value (x: FssTypes.IPerspectiveOrigin, y: FssTypes.IPerspectiveOrigin) =
            $"{perspectiveOriginToString x} {perspectiveOriginToString y}"
            |> perspectiveOriginValue
        static member inherit' = FssTypes.Inherit |> perspectiveOriginValue'
        static member initial = FssTypes.Initial |> perspectiveOriginValue'
        static member unset = FssTypes.Unset |> perspectiveOriginValue'

    /// <summary>Specifies vanishing point for the perspective property.</summary>
    /// <param name="origin">
    ///     can be:
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PerspectiveOrigin' = PerspectiveOrigin.value

[<AutoOpen>]
module BackfaceVisibility =
    let private visibilityToString (visibility: FssTypes.IBackfaceVisibility) =
        match visibility with
        | :? FssTypes.Visibility.BackfaceVisibility as v -> Utilities.Helpers.duToLowercase v
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown backface visibility"

    let private backfaceVisibilityValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackfaceVisibility
    let private backfaceVisibilityValue' = visibilityToString >> backfaceVisibilityValue

    [<Erase>]
    type BackfaceVisibility =
        static member value (visibility: FssTypes.IBackfaceVisibility) = visibility |> backfaceVisibilityValue'
        static member hidden = FssTypes.Visibility.BackfaceVisibility.Hidden |> backfaceVisibilityValue'
        static member visible = FssTypes.Visibility.BackfaceVisibility.Visible |> backfaceVisibilityValue'
        static member inherit' = FssTypes.Inherit |> backfaceVisibilityValue'
        static member initial = FssTypes.Initial |> backfaceVisibilityValue'
        static member unset = FssTypes.Unset |> backfaceVisibilityValue'

    /// <summary>Specifies whether the backface of an element is visible.</summary>
    /// <param name="visibility">
    ///     can be:
    ///     - <c> BackfaceVisibility </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackfaceVisibility' = BackfaceVisibility.value
