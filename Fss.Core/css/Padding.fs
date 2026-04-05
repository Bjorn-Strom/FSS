namespace Fss

open Fss.Types

[<AutoOpen>]
module Padding =
    /// Sets the margin of the top of an element
    let PaddingTop = PaddingClasses.PaddingDirection(Property.PaddingTop)
    /// Sets the margin of the right side of an element
    let PaddingRight = PaddingClasses.PaddingDirection(Property.PaddingRight)
    /// Sets the margin of the bottom side of an element
    let PaddingBottom = PaddingClasses.PaddingDirection(Property.PaddingBottom)
    /// Sets the margin of the left side of an element
    let PaddingLeft = PaddingClasses.PaddingDirection(Property.PaddingLeft)
    /// Specifies the inline start margin of an element
    let PaddingInlineStart = PaddingClasses.PaddingDirection(Property.PaddingInlineStart)
    /// Specifies the inline end margin of an element
    let PaddingInlineEnd = PaddingClasses.PaddingDirection(Property.PaddingInlineEnd)
    /// Specifies the block start margin of an element
    let PaddingBlockStart = PaddingClasses.PaddingDirection(Property.PaddingBlockStart)
    /// Specifies the block end margin of an element
    let PaddingBlockEnd = PaddingClasses.PaddingDirection(Property.PaddingBlockEnd)
    /// Sets the padding area of all sides of an element
    let Padding = PaddingClasses.Padding(Property.Padding)
    /// Sets the inline start and end paddings of an element
    let PaddingInline = PaddingClasses.PaddingLogical(Property.PaddingInline)
    /// Sets the block start and end paddings of an element
    let PaddingBlock = PaddingClasses.PaddingLogical(Property.PaddingBlock)
