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
    let private caretColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.CaretColor
    let private caretColorValue' = caretColorToString >> caretColorValue

    /// Specifies caret color.
    let CaretColor = FssTypes.CaretColorClass(caretColorValue')

    /// Specifies caret color.
    /// Valid parameters:
    /// - Color
    /// - Auto
    let CaretColor' = CaretColor.value
