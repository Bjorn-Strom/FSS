namespace Fss

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

    type PointerEvents =
        static member Value (pointerEvents: FssTypes.IPointerEvents) = pointerEvents |> pointerEventsValue

        static member VisiblePainted = FssTypes.PointerEvents.VisiblePainted |> pointerEventsValue'
        static member VisibleFill = FssTypes.PointerEvents.VisibleFill |> pointerEventsValue'
        static member VisibleStroke = FssTypes.PointerEvents.VisibleStroke |> pointerEventsValue'
        static member Visible = FssTypes.PointerEvents.Visible |> pointerEventsValue'
        static member Painted = FssTypes.PointerEvents.Painted |> pointerEventsValue'
        static member Stroke = FssTypes.PointerEvents.Stroke |> pointerEventsValue'
        static member All = FssTypes.PointerEvents.All |> pointerEventsValue'

        static member Auto = FssTypes.Auto |> pointerEventsValue'
        static member Inherit = FssTypes.Inherit |> pointerEventsValue'
        static member Initial = FssTypes.Initial |> pointerEventsValue'
        static member Unset = FssTypes.Unset |> pointerEventsValue'
        static member None = FssTypes.None' |> pointerEventsValue'

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
    let PointerEvents' (pointerEvents: FssTypes.IPointerEvents) = PointerEvents.Value(pointerEvents)