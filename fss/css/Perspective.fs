namespace Fss

[<AutoOpen>]
module Perspective =
    let private perspectiveToString (perspective: Types.IPerspective) =
        match perspective with
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown perspective"

    let private perspectiveOriginToString (perspectiveOrigin: Types.IPerspectiveOrigin) =
        match perspectiveOrigin with
        | :? Types.Percent as s -> Types.unitHelpers.percentToString s
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown perspective origin"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/perspective
    let private perspectiveValue value = Types.propertyHelpers.cssValue Types.Property.Perspective value
    let private perspectiveValue' value =
        value
        |> perspectiveToString
        |> perspectiveValue

    type Perspective =
        static member Value (perspective: Types.IPerspective) = perspective |> perspectiveValue'
        static member None = Types.None' |> perspectiveValue'
        static member Inherit = Types.Inherit |> perspectiveValue'
        static member Initial = Types.Initial |> perspectiveValue'
        static member Unset = Types.Unset |> perspectiveValue'

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
    let Perspective' (perspective: Types.IPerspective) = Perspective.Value(perspective)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/perspective-origin
    let private perspectiveOriginValue value = Types.propertyHelpers.cssValue Types.Property.PerspectiveOrigin value
    let private perspectiveOriginValue' value =
        value
        |> perspectiveOriginToString
        |> perspectiveOriginValue

    type PerspectiveOrigin =
        static member Value (origin: Types.IPerspectiveOrigin) = origin |> perspectiveOriginValue'
        static member Value (x: Types.IPerspectiveOrigin, y: Types.IPerspectiveOrigin) =
            $"{perspectiveOriginToString x} {perspectiveOriginToString y}"
            |> perspectiveOriginValue
        static member Inherit = Types.Inherit |> perspectiveOriginValue'
        static member Initial = Types.Initial |> perspectiveOriginValue'
        static member Unset = Types.Unset |> perspectiveOriginValue'

    /// <summary>Specifies vanishing point for the perspective property.</summary>
    /// <param name="origin">
    ///     can be:
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PerspectiveOrigin' (origin: Types.IPerspectiveOrigin) = PerspectiveOrigin.Value(origin)


[<AutoOpen>]
module BackfaceVisibility =
    let private visibilityToString (visibility: Types.IBackfaceVisibility) =
        match visibility with
        | :? Types.Visibility.BackfaceVisibility as v -> Utilities.Helpers.duToLowercase v
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown backface visibility"

    let private backfaceVisibilityValue value = Types.propertyHelpers.cssValue Types.Property.BackfaceVisibility value
    let private backfaceVisibilityValue' value =
        value
        |> visibilityToString
        |> backfaceVisibilityValue

    type BackfaceVisibility =
        static member Value (visibility: Types.IBackfaceVisibility) = visibility |> backfaceVisibilityValue'
        static member Hidden = Types.Visibility.BackfaceVisibility.Hidden |> backfaceVisibilityValue'
        static member Visible = Types.Visibility.BackfaceVisibility.Visible |> backfaceVisibilityValue'
        static member Inherit = Types.Inherit |> backfaceVisibilityValue'
        static member Initial = Types.Initial |> backfaceVisibilityValue'
        static member Unset = Types.Unset |> backfaceVisibilityValue'

    /// <summary>Specifies whether the backface of an element is visible.</summary>
    /// <param name="visibility">
    ///     can be:
    ///     - <c> BackfaceVisibility </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackfaceVisibility' (visibility: Types.IBackfaceVisibility) = BackfaceVisibility.Value(visibility)
