namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Position =
    /// Specifies vertical position of element.
    let Top =
        Position.PositionClasses.TopRightBottomLeft(Property.Top)
    /// Specifies horizontal position of element.
    let Right =
        Position.PositionClasses.TopRightBottomLeft(Property.Right)
    /// Specifies vertical alignment of element.
    let Bottom =
        Position.PositionClasses.TopRightBottomLeft(Property.Bottom)
    /// Specifies vertical alignment.
    let Left =
        Position.PositionClasses.TopRightBottomLeft(Property.Left)
    /// Specifies vertical alignment.
    let VerticalAlign =
        Position.PositionClasses.VerticalAlign(Property.VerticalAlign)
    /// Specifies element float.
    let Float =
        Position.PositionClasses.Float(Property.Float)
    /// Specifies how the total width and height of an element is calculated
    let BoxSizing =
        Position.PositionClasses.BoxSizing(Property.BoxSizing)
    /// Specifies element float.
    let Direction =
        Position.PositionClasses.Direction(Property.Direction)
    /// Specifies direction elements are written.
    let WritingMode =
        WritingMode.WritingModeClasses.WritingMode(Property.WritingMode)
    /// Specifies how elements behave after a generated box.
    let BreakAfter =
        Position.PositionClasses.Break(Property.BreakAfter)
    /// Specifies how elements behave before a generated box.
    let BreakBefore =
        Position.PositionClasses.Break(Property.BreakBefore)
    /// Specifies how elements behave inside a generated box.
    let BreakInside =
        Position.PositionClasses.BreakInside(Property.BreakInside)
    /// <summary>Specifies how an element is to be positioned.</summary>
    let Position =
        Position.PositionClasses.Position(Property.Position)
