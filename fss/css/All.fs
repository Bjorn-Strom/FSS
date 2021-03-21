namespace Fss

[<AutoOpen>]
module All =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/all
    let private stringifyAll (all: Types.IAll) =
        match all with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown all"

    let private allValue value = Types.cssValue Types.Property.All value
    let private allValue' value =
        value
        |> stringifyAll
        |> allValue

    type All =
        static member Value (all: Types.IAll) = all |> allValue'
        static member Inherit = Types.Inherit |> allValue'

        static member Initial = Types.Initial |> allValue'
        static member Unset = Types.Unset |> allValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let All' (all: Types.IAll) = all |> All.Value
