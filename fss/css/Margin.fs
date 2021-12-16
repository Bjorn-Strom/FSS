namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Margin =
    /// Sets the margin of the top of an element
    let MarginTop =
        Margin.MarginClasses.MarginDirection(Property.MarginTop)
    /// Sets the margin of the right side of an element
    let MarginRight =
        Margin.MarginClasses.MarginDirection(Property.MarginRight)
    /// Sets the margin of the bottom side of an element
    let MarginBottom =
        Margin.MarginClasses.MarginDirection(Property.MarginBottom)
    /// Sets the margin of the left side of an element
    let MarginLeft =
        Margin.MarginClasses.MarginDirection(Property.MarginLeft)
    /// Specifies the inline start margin of an element
    let MarginInlineStart =
        Margin.MarginClasses.MarginDirection(Property.MarginInlineStart)
    /// Specifies the inline end margin of an element
    let MarginInlineEnd =
        Margin.MarginClasses.MarginDirection(Property.MarginInlineEnd)
    /// Specifies the block start margin of an element
    let MarginBlockStart =
        Margin.MarginClasses.MarginDirection(Property.MarginBlockStart)
    /// Specifies the block end margin of an element
    let MarginBlockEnd =
        Margin.MarginClasses.MarginDirection(Property.MarginBlockEnd)
    /// Sets the margin area of all sides of an element
    let Margin =
        Margin.MarginClasses.Margin(Property.Margin)
