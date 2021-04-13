namespace Fss

open Fable.Core

[<AutoOpen>]
module All =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/all
    let private stringifyAll (all: FssTypes.IAll) =
        match all with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private allValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.All
    let private allValue' = stringifyAll >> allValue

    [<Erase>]
    /// Resets all of an elements properties.
    type All =
        static member value (all: FssTypes.IAll) = all |> allValue'
        static member inherit' = FssTypes.Inherit |> allValue'
        static member initial = FssTypes.Initial |> allValue'
        static member unset = FssTypes.Unset |> allValue'

    /// Resets all of an elements properties.
    /// - Inherit
    /// - Initial
    /// - Unset
    let All' = All.value
