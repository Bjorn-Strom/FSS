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

    let private pointerEventsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.PointerEvents value
    let private pointerEventsValue' value =
        value
        |> eventToString
        |> pointerEventsValue

    [<Erase>]
    type PointerEvents =
        static member value (pointerEvents: FssTypes.IPointerEvents) = pointerEvents |> pointerEventsValue

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

    /// <summary>Specifies when an element can be the target of pointer events.</summary>
    /// <param name="pointerEvents">
    ///     can be:
    ///     - <c> PointerEvents </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let PointerEvents' (pointerEvents: FssTypes.IPointerEvents) = PointerEvents.value(pointerEvents)