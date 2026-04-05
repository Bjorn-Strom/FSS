namespace Fss

open Fss.Types

[<AutoOpen>]
module Position =
    /// Specifies vertical position of element.
    let Top = PositionClasses.TopRightBottomLeft(Property.Top)
    /// Specifies horizontal position of element.
    let Right = PositionClasses.TopRightBottomLeft(Property.Right)
    /// Specifies vertical alignment of element.
    let Bottom = PositionClasses.TopRightBottomLeft(Property.Bottom)
    /// Specifies vertical alignment.
    let Left = PositionClasses.TopRightBottomLeft(Property.Left)
    /// Specifies vertical alignment.
    let VerticalAlign = PositionClasses.VerticalAlign(Property.VerticalAlign)
    /// Specifies element float.
    let Float = PositionClasses.Float(Property.Float)
    /// Specifies how the total width and height of an element is calculated
    let BoxSizing = PositionClasses.BoxSizing(Property.BoxSizing)
    /// Specifies element float.
    let Direction = PositionClasses.Direction(Property.Direction)
    /// Specifies direction elements are written.
    let WritingMode = WritingModeClasses.WritingMode(Property.WritingMode)
    /// Specifies how elements behave after a generated box.
    let BreakAfter = PositionClasses.Break(Property.BreakAfter)
    /// Specifies how elements behave before a generated box.
    let BreakBefore = PositionClasses.Break(Property.BreakBefore)
    /// Specifies how elements behave inside a generated box.
    let BreakInside = PositionClasses.BreakInside(Property.BreakInside)
    /// Shorthand for top, right, bottom, and left.
    let Inset = PositionClasses.Inset(Property.Inset)
    /// Shorthand for inset-block-start and inset-block-end.
    let InsetBlock = PositionClasses.InsetLogical(Property.InsetBlock)
    /// Specifies the block-end offset of an element.
    let InsetBlockEnd = PositionClasses.TopRightBottomLeft(Property.InsetBlockEnd)
    /// Specifies the block-start offset of an element.
    let InsetBlockStart = PositionClasses.TopRightBottomLeft(Property.InsetBlockStart)
    /// Shorthand for inset-inline-start and inset-inline-end.
    let InsetInline = PositionClasses.InsetLogical(Property.InsetInline)
    /// Specifies the inline-end offset of an element.
    let InsetInlineEnd = PositionClasses.TopRightBottomLeft(Property.InsetInlineEnd)
    /// Specifies the inline-start offset of an element.
    let InsetInlineStart = PositionClasses.TopRightBottomLeft(Property.InsetInlineStart)
    /// <summary>Specifies how an element is to be positioned.</summary>
    let Position = PositionClasses.Position(Property.Position)
