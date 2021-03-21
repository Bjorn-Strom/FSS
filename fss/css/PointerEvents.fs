namespace Fss
open FssTypes

[<AutoOpen>]
module PointerEvents =
    let private eventToString (event: IPointerEvents) =
        match event with
        | :? PointerEvents as p -> Utilities.Helpers.duToCamel p
        | :? Auto -> auto
        | :? None' -> none
        | :? Global as g -> global' g
        | _ -> "Unknown pointer event"

    let private pointerEventsValue value = PropertyValue.cssValue Property.PointerEvents value
    let private pointerEventsValue' value =
        value
        |> eventToString
        |> pointerEventsValue

    type PointerEvents =
        static member Value (pointerEvents: IPointerEvents) = pointerEvents |> pointerEventsValue

        static member VisiblePainted = FssTypes.PointerEvents.VisiblePainted |> pointerEventsValue'
        static member VisibleFill = FssTypes.PointerEvents.VisibleFill |> pointerEventsValue'
        static member VisibleStroke = FssTypes.PointerEvents.VisibleStroke |> pointerEventsValue'
        static member Visible = FssTypes.PointerEvents.Visible |> pointerEventsValue'
        static member Painted = FssTypes.PointerEvents.Painted |> pointerEventsValue'
        static member Stroke = FssTypes.PointerEvents.Stroke |> pointerEventsValue'
        static member All = FssTypes.PointerEvents.All |> pointerEventsValue'

        static member Auto = Auto |> pointerEventsValue'
        static member Inherit = Inherit |> pointerEventsValue'
        static member Initial = Initial |> pointerEventsValue'
        static member Unset = Unset |> pointerEventsValue'
        static member None = None' |> pointerEventsValue'

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
    let PointerEvents' (pointerEvents: IPointerEvents) = PointerEvents.Value(pointerEvents)