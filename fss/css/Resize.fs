namespace Fss

[<AutoOpen>]
module Resize =
    let private resizeToString (resize: Types.IResize) =
        match resize with
        | :? Types.Resize as r -> Utilities.Helpers.duToLowercase r
        | :? Types.None' -> Types.none
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown resize value"

    let private resizeValue value = Types.cssValue Types.Property.Resize value
    let private resizeValue' value =
        value
        |> resizeToString
        |> resizeValue

    type Resize =
        static member Value (resize: Types.IResize) = resize |> resizeValue'
        static member Both = Types.Resize.Both |> resizeValue'
        static member Horizontal = Types.Resize.Horizontal |> resizeValue'
        static member Vertical = Types.Resize.Vertical |> resizeValue'
        static member Block = Types.Resize.Block |> resizeValue'
        static member Inline = Types.Resize.Inline |> resizeValue'
        static member None = Types.None' |> resizeValue'
        static member Initial = Types.Initial |> resizeValue'
        static member Inherit = Types.Inherit |> resizeValue'
        static member Unset = Types.Unset |> resizeValue'

    /// <summary>Specifies how elemnts are resizable.</summary>
    /// <param name="resize">
    ///     can be:
    ///     - <c> Resize </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Resize' (resize: Types.IResize) = Resize.Value resize