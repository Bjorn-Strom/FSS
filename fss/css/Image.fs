namespace Fss

open Fable.Core

[<AutoOpen>]
module Image =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/object-fit
    let private stringifyObjectFit (objectFit: FssTypes.IObjectFit) =
        match objectFit with
        | :? FssTypes.Image.ObjectFit as o -> Utilities.Helpers.duToKebab o
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown object-fit"

    let private objectFitValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ObjectFit
    let private objectFitValue' = stringifyObjectFit >> objectFitValue

    [<Erase>]
    type ObjectFit =
        static member value (all: FssTypes.IObjectFit) = all |> objectFitValue'
        static member fill = FssTypes.Image.Fill |> objectFitValue'
        static member contain = FssTypes.Image.Contain |> objectFitValue'
        static member cover = FssTypes.Image.Cover |> objectFitValue'
        static member scaleDown = FssTypes.Image.ScaleDown |> objectFitValue'

        static member none = FssTypes.None' |> objectFitValue'

    /// <summary>Sets how na image or video should be resized to fit its container.</summary>
    /// <param name="objectFit">
    ///     can be:
    ///     - <c> ObjectFit </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let ObjectFit' = ObjectFit.value

    let private stringifyObjectPosition (objectPosition: FssTypes.IObjectPosition) =
        match objectPosition with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown object-position"

    let private objectPositionValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.ObjectPosition
    let private objectPositionValue' = stringifyObjectPosition >> objectPositionValue

    [<Erase>]
    type ObjectPosition =
        static member value (x: FssTypes.ILengthPercentage, y: FssTypes.ILengthPercentage) =
            $"{FssTypes.unitHelpers.lengthPercentageToString x} {FssTypes.unitHelpers.lengthPercentageToString y}"
            |> objectPositionValue
        static member inherit' = FssTypes.Inherit |> objectPositionValue'
        static member initial = FssTypes.Initial |> objectPositionValue'
        static member unset = FssTypes.Unset |> objectPositionValue'

    /// <summary>Sets how na image or video should be resized to fit its container.</summary>
    /// <param name="x"> pixel or percent </param>
    /// <param name="y"> pixel or percent </param>
    /// <returns>Css property for fss.</returns>
    let ObjectPosition': (FssTypes.ILengthPercentage * FssTypes.ILengthPercentage -> FssTypes.CssProperty) = ObjectPosition.value