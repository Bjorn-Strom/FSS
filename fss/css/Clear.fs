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
    /// Specifies how if an element is to be moved downwards by floating elements.
    type Clear =
        static member value (clear: FssTypes.IClear) = clear |> clearValue'
        static member none = FssTypes.None' |> clearValue'
        static member inherit' = FssTypes.Inherit |> clearValue'
        static member initial = FssTypes.Initial |> clearValue'
        static member unset = FssTypes.Unset |> clearValue'

    /// Specifies how if an element is to be moved downwards by floating elements.
    /// Valid parameters:
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let Clear' = Clear.value
