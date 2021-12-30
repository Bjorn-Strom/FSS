namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Margin =
    /// Sets the margin of the top of an element
    let MarginTop = MarginClasses.MarginDirection(Property.MarginTop)
    /// Sets the margin of the right side of an element
    let MarginRight = MarginClasses.MarginDirection(Property.MarginRight)
    /// Sets the margin of the bottom side of an element
    let MarginBottom = MarginClasses.MarginDirection(Property.MarginBottom)
    /// Sets the margin of the left side of an element
    let MarginLeft = MarginClasses.MarginDirection(Property.MarginLeft)
    /// Specifies the inline start margin of an element
    let MarginInlineStart = MarginClasses.MarginDirection(Property.MarginInlineStart)
    /// Specifies the inline end margin of an element
    let MarginInlineEnd = MarginClasses.MarginDirection(Property.MarginInlineEnd)
    /// Specifies the block start margin of an element
    let MarginBlockStart = MarginClasses.MarginDirection(Property.MarginBlockStart)
    /// Specifies the block end margin of an element
    let MarginBlockEnd = MarginClasses.MarginDirection(Property.MarginBlockEnd)
    /// Sets the margin area of all sides of an element
    let Margin = MarginClasses.Margin(Property.Margin)
