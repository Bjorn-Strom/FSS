namespace Fss

[<AutoOpen>]
module All =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/all
    let private stringifyAll (all: FssTypes.IAll) =
        match all with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown all"

    let private allValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.All value
    let private allValue' value =
        value
        |> stringifyAll
        |> allValue

    type All =
        static member value (all: FssTypes.IAll) = all |> allValue'
        static member inherit' = FssTypes.Inherit |> allValue'

        static member initial = FssTypes.Initial |> allValue'
        static member unset = FssTypes.Unset |> allValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let All' (all: FssTypes.IAll) = all |> All.value
