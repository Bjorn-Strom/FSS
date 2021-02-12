namespace Fss

[<RequireQualifiedAccess>]
module ClearType =
    type Clear =
        | Left
        | Right
        | Both
        | InlineStart
        | InlineEnd
        interface IClear

[<AutoOpen>]
module Clear =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clear
    let private stringifyClear (clear: IClear) =
        match clear with
        | :? ClearType.Clear as c -> Utilities.Helpers.duToKebab c
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown clear"

    let private clearValue value = PropertyValue.cssValue Property.Clear value
    let private clearValue' value =
        value
        |> stringifyClear
        |> clearValue

    type Clear =
        static member Value (clear: IClear) = clear |> clearValue'
        static member None = None |> clearValue'
        static member Inherit = Inherit |> clearValue'
        static member Initial = Initial |> clearValue'
        static member Unset = Unset |> clearValue'

    /// <summary>Specifies how if an element is to be moved downwards by floating elements.</summary>
    /// <param name="clear">
    ///     can be:
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private Clear' (clear: IClear) = clear |> Clear.Value
