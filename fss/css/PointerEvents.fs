namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module PointerEvents =
    /// Specifies when an element can be the target of pointer events.
    let PointerEvents = PointerEventClasses.PointerEvent(Property.PointerEvents)
