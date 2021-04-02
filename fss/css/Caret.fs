namespace Fss

open Fable.Core

[<AutoOpen>]
module Caret =
    let private caretColorToString (caretColor: FssTypes.ICaretColor) =
        match caretColor with
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown caret color"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/caret-color
    let private caretColorValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.CaretColor value
    let private caretColorValue' value =
        value
        |> caretColorToString
        |> caretColorValue


    let CaretColor = FssTypes.CaretColorClass(caretColorValue')

    /// <summary>Specifies caret color.</summary>
    /// <param name="caretColor">
    ///     can be:
    ///     - <c> FssTypes.ColorType</c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let CaretColor' (caretColor: FssTypes.ICaretColor) = CaretColor.value caretColor
