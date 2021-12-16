namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Padding =
    /// Sets the margin of the top of an element
    let PaddingTop =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingTop)
    /// Sets the margin of the right side of an element
    let PaddingRight =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingRight)
    /// Sets the margin of the bottom side of an element
    let PaddingBottom =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingBottom)
    /// Sets the margin of the left side of an element
    let PaddingLeft =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingLeft)
    /// Specifies the inline start margin of an element
    let PaddingInlineStart =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingInlineStart)
    /// Specifies the inline end margin of an element
    let PaddingInlineEnd =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingInlineEnd)
    /// Specifies the block start margin of an element
    let PaddingBlockStart =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingBlockStart)
    /// Specifies the block end margin of an element
    let PaddingBlockEnd =
        Padding.PaddingClasses.PaddingDirection(Property.PaddingBlockEnd)
    /// Sets the margin area of all sides of an element
    let Padding =
        Padding.PaddingClasses.Padding(Property.Padding)
