namespace Fss

open Fable.Core

[<AutoOpen>]
module PointerEvents =
    let private eventToString (event: FssTypes.IPointerEvents) =
        match event with
        | :? FssTypes.PointerEvents.PointerEvents as p -> Utilities.Helpers.duToCamel p
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown pointer event"

    let private pointerEventsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.PointerEvents
    let private pointerEventsValue': (FssTypes.IPointerEvents -> FssTypes.CssProperty) = eventToString >> pointerEventsValue

    [<Erase>]
    /// Specifies when an element can be the target of pointer events.
    type PointerEvents =
        static member value (pointerEvents: FssTypes.IPointerEvents) = pointerEvents |> pointerEventsValue'

        static member visiblePainted = FssTypes.PointerEvents.VisiblePainted |> pointerEventsValue'
        static member visibleFill = FssTypes.PointerEvents.VisibleFill |> pointerEventsValue'
        static member visibleStroke = FssTypes.PointerEvents.VisibleStroke |> pointerEventsValue'
        static member visible = FssTypes.PointerEvents.Visible |> pointerEventsValue'
        static member painted = FssTypes.PointerEvents.Painted |> pointerEventsValue'
        static member stroke = FssTypes.PointerEvents.Stroke |> pointerEventsValue'
        static member all = FssTypes.PointerEvents.All |> pointerEventsValue'

        static member auto = FssTypes.Auto |> pointerEventsValue'
        static member inherit' = FssTypes.Inherit |> pointerEventsValue'
        static member initial = FssTypes.Initial |> pointerEventsValue'
        static member unset = FssTypes.Unset |> pointerEventsValue'
        static member none = FssTypes.None' |> pointerEventsValue'

    /// Specifies when an element can be the target of pointer events.
    /// Valid parameters:
    /// - PointerEvents
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    /// - None
    let PointerEvents' = PointerEvents.value