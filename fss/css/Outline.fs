namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Outline =
    /// Sets color of outline.
    let OutlineColor =
        Outline.OutlineClasses.OutlineColor(Property.OutlineColor)
    /// Sets width of outline.
    let OutlineWidth =
        Outline.OutlineClasses.OutlineWidth(Property.OutlineWidth)
    /// Sets style of outline.
    let OutlineStyle =
        Outline.OutlineClasses.OutlineStyle(Property.OutlineStyle)
    /// Sets offset of outline.
    let OutlineOffset =
        Outline.OutlineClasses.OutlineOffset(Property.OutlineOffset)
    /// Resets outline
    let Outline =
        Outline.OutlineClasses.Outline(Property.Outline)
