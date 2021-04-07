namespace Fss

open Fable.Core

[<AutoOpen>]
module Resize =
    let private resizeToString (resize: FssTypes.IResize) =
        match resize with
        | :? FssTypes.Resize.Resize as r -> Utilities.Helpers.duToLowercase r
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown resize value"

    let private resizeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Resize
    let private resizeValue' = resizeToString >> resizeValue

    [<Erase>]
    type Resize =
        static member value (resize: FssTypes.IResize) = resize |> resizeValue'
        static member both = FssTypes.Resize.Both |> resizeValue'
        static member horizontal = FssTypes.Resize.Horizontal |> resizeValue'
        static member vertical = FssTypes.Resize.Vertical |> resizeValue'
        static member block = FssTypes.Resize.Block |> resizeValue'
        static member inline' = FssTypes.Resize.Inline |> resizeValue'
        static member none = FssTypes.None' |> resizeValue'
        static member initial = FssTypes.Initial |> resizeValue'
        static member inherit' = FssTypes.Inherit |> resizeValue'
        static member unset = FssTypes.Unset |> resizeValue'

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
    let Resize' = Resize.value