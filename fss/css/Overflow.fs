namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Overflow =
    /// Specifies overflow left and right edge behavior.
    let OverflowX =
        Overflow.OverflowClasses.OverflowClass(Property.OverflowX)
    /// Specifies overflow top and bottom edge behavior.
    let OverflowY =
        Overflow.OverflowClasses.OverflowClass(Property.OverflowY)
    /// Specifies if the browser should insert line breaks to prevent text from overflowing
    let OverflowWrap =
        Overflow.OverflowClasses.OverflowWrap(Property.OverflowWrap)
    /// Specifies overflow behavior.
    let Overflow =
        Overflow.OverflowClasses.OverflowClass(Property.Overflow)
