namespace Fss
open FssTypes

[<AutoOpen>]
module Resize =
    let private resizeToString (resize: IResize) =
        match resize with
        | :? Resize.Resize as r -> Utilities.Helpers.duToLowercase r
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown resize value"

    let private resizeValue value = PropertyValue.cssValue Property.Resize value
    let private resizeValue' value =
        value
        |> resizeToString
        |> resizeValue

    type Resize =
        static member Value (resize: IResize) = resize |> resizeValue'
        static member Both = Resize.Both |> resizeValue'
        static member Horizontal = Resize.Horizontal |> resizeValue'
        static member Vertical = Resize.Vertical |> resizeValue'
        static member Block = Resize.Block |> resizeValue'
        static member Inline = Resize.Inline |> resizeValue'
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