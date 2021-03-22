namespace Fss

[<AutoOpen>]
module Clear =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clear
    let private stringifyClear (clear: Types.IClear) =
        match clear with
        | :? Types.Clear.Clear as c -> Utilities.Helpers.duToKebab c
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown clear"

    let private clearValue value = Types.propertyHelpers.cssValue Types.Property.Clear value
    let private clearValue' value =
        value
        |> stringifyClear
        |> clearValue

    type Clear =
        static member Value (clear: Types.IClear) = clear |> clearValue'
        static member None = Types.None' |> clearValue'
        static member Inherit = Types.Inherit |> clearValue'
        static member Initial = Types.Initial |> clearValue'
        static member Unset = Types.Unset |> clearValue'

    /// <summary>Specifies how if an element is to be moved downwards by floating elements.</summary>
    /// <param name="clear">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Clear' (clear: Types.IClear) = clear |> Clear.Value
