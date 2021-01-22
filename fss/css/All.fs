namespace Fss

[<AutoOpen>]
module All =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/all
    let private stringifyAll (all: IAll) =
        match all with
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown all"

    let private allValue value = PropertyValue.cssValue Property.All value
    let private allValue' value =
        value
        |> stringifyAll
        |> allValue

    type All =
        static member Value (all: IAll) = all |> allValue'
        static member Inherit = Inherit |> allValue'

        static member Initial = Initial |> allValue'
        static member Unset = Unset |> allValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private All' (all: IAll) = all |> All.Value
