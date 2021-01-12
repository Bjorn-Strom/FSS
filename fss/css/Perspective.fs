namespace Fss

[<AutoOpen>]
module Perspective =
    let private perspectiveToString (perspective: IPerspective) =
        match perspective with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown perspective"

    let private perspectiveValue value = PropertyValue.cssValue Property.Perspective value
    let private perspectiveValue' value =
        value
        |> perspectiveToString
        |> perspectiveValue

    type Perspective =
        static member Value (perspective: IPerspective) = perspective |> perspectiveValue'
        static member None = None |> perspectiveValue'
        static member Inherit = Inherit |> perspectiveValue'
        static member Initial = Initial |> perspectiveValue'
        static member Unset = Unset |> perspectiveValue'

    /// <summary>Specifies distance in z plane.</summary>
    /// <param name="perspective">
    ///     can be:
    ///     - <c> Units.Size </c> 
    ///     - <c> None </c> 
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c> 
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Perspective' (perspective: IPerspective) = Perspective.Value(perspective)