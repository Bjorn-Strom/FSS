namespace Fss

[<AutoOpen>]
module Resize =
    let private resizeToString (resize: FssTypes.IResize) =
        match resize with
        | :? FssTypes.Resize.Resize as r -> Utilities.Helpers.duToLowercase r
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown resize value"

    let private resizeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Resize value
    let private resizeValue' value =
        value
        |> resizeToString
        |> resizeValue

    type Resize =
        static member Value (resize: FssTypes.IResize) = resize |> resizeValue'
        static member Both = FssTypes.Resize.Both |> resizeValue'
        static member Horizontal = FssTypes.Resize.Horizontal |> resizeValue'
        static member Vertical = FssTypes.Resize.Vertical |> resizeValue'
        static member Block = FssTypes.Resize.Block |> resizeValue'
        static member Inline = FssTypes.Resize.Inline |> resizeValue'
        static member None = FssTypes.None' |> resizeValue'
        static member Initial = FssTypes.Initial |> resizeValue'
        static member Inherit = FssTypes.Inherit |> resizeValue'
        static member Unset = FssTypes.Unset |> resizeValue'

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
    let Resize' (resize: FssTypes.IResize) = Resize.Value resize