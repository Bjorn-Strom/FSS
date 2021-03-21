namespace Fss
open FssTypes

[<AutoOpen>]
module Resize =
    let private resizeToString (resize: IResize) =
        match resize with
        | :? Resize as r -> Utilities.Helpers.duToLowercase r
        | :? None' -> none
        | :? Global as g -> global' g
        | _ -> "Unknown resize value"

    let private resizeValue value = PropertyValue.cssValue Property.Resize value
    let private resizeValue' value =
        value
        |> resizeToString
        |> resizeValue

    type Resize =
        static member Value (resize: IResize) = resize |> resizeValue'
        static member Both = FssTypes.Resize.Both |> resizeValue'
        static member Horizontal = FssTypes.Resize.Horizontal |> resizeValue'
        static member Vertical = FssTypes.Resize.Vertical |> resizeValue'
        static member Block = FssTypes.Resize.Block |> resizeValue'
        static member Inline = FssTypes.Resize.Inline |> resizeValue'
        static member None = None' |> resizeValue'
        static member Initial = Initial |> resizeValue'
        static member Inherit = Inherit |> resizeValue'
        static member Unset = Unset |> resizeValue'

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
    let Resize' (resize: IResize) = Resize.Value resize