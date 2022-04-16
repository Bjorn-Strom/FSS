namespace Fss

open Fss.Types

[<AutoOpen>]
module Outline =
    /// Sets color of outline.
    let OutlineColor = OutlineClasses.OutlineColor(Property.OutlineColor)
    /// Sets width of outline.
    let OutlineWidth = OutlineClasses.OutlineWidth(Property.OutlineWidth)
    /// Sets style of outline.
    let OutlineStyle = OutlineClasses.OutlineStyle(Property.OutlineStyle)
    /// Sets offset of outline.
    let OutlineOffset = OutlineClasses.OutlineOffset(Property.OutlineOffset)
    /// Resets outline
    let Outline = OutlineClasses.Outline(Property.Outline)
