namespace Fss

[<AutoOpen>]
module PointerEvents =
    let private eventToString (event: Types.IPointerEvents) =
        match event with
        | :? Types.PointerEvents as p -> Utilities.Helpers.duToCamel p
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown pointer event"

    let private pointerEventsValue value = Types.propertyHelpers.cssValue Types.Property.PointerEvents value
    let private pointerEventsValue' value =
        value
        |> eventToString
        |> pointerEventsValue

    type PointerEvents =
        static member Value (pointerEvents: Types.IPointerEvents) = pointerEvents |> pointerEventsValue

        static member VisiblePainted = Types.PointerEvents.VisiblePainted |> pointerEventsValue'
        static member VisibleFill = Types.PointerEvents.VisibleFill |> pointerEventsValue'
        static member VisibleStroke = Types.PointerEvents.VisibleStroke |> pointerEventsValue'
        static member Visible = Types.PointerEvents.Visible |> pointerEventsValue'
        static member Painted = Types.PointerEvents.Painted |> pointerEventsValue'
        static member Stroke = Types.PointerEvents.Stroke |> pointerEventsValue'
        static member All = Types.PointerEvents.All |> pointerEventsValue'

        static member Auto = Types.Auto |> pointerEventsValue'
        static member Inherit = Types.Inherit |> pointerEventsValue'
        static member Initial = Types.Initial |> pointerEventsValue'
        static member Unset = Types.Unset |> pointerEventsValue'
        static member None = Types.None' |> pointerEventsValue'

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
    let PointerEvents' (pointerEvents: Types.IPointerEvents) = PointerEvents.Value(pointerEvents)