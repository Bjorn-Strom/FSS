namespace Fss

open Fable.Core

[<AutoOpen>]
module Clear =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clear
    let private stringifyClear (clear: FssTypes.IClear) =
        match clear with
        | :? FssTypes.Clear.Clear as c -> Utilities.Helpers.duToKebab c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown clear"

    let private clearValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Clear
    let private clearValue' = stringifyClear >> clearValue

    [<Erase>]
    type Clear =
        static member value (clear: FssTypes.IClear) = clear |> clearValue'
        static member none = FssTypes.None' |> clearValue'
        static member inherit' = FssTypes.Inherit |> clearValue'
        static member initial = FssTypes.Initial |> clearValue'
        static member unset = FssTypes.Unset |> clearValue'

    /// <summary>Specifies how if an element is to be moved downwards by floating elements.</summary>
    /// <param name="clear">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Clear' = Clear.value
