namespace Fss

open Utilities.Types
open Property
open Animation

module Transition =
    type Transition = 
        | TransitionType of Property * Time option * Timing option * Time option
        interface ICSSProperty

    let private unwrap = function | TransitionType(a,b,c,d)->(a,b,c,d)

    let value (t: Transition): string =
        let (property, time, timing, delay) = unwrap t
        match (time, timing, delay) with
            | Some time, Some timing, Some delay -> sprintf "%s %s %s %s" (Property.value property) (Animation.value time) (Animation.value timing) (Animation.value delay)
            | Some time, Some timing, _          -> sprintf "%s %s %s" (Property.value property) (Animation.value time) (Animation.value timing)
            | Some time, _, _                    -> sprintf "%s %s" (Property.value property) (Animation.value time)
            | _, _, _                            -> Property.value property
                
    let backgroundColorCurried (time: Time option) (timing: Timing option) (delay: Time option): Transition = (BackgroundColor, time, timing, delay) |> TransitionType
    
    let backgroundColorTupled (time: Time option, timing: Timing option) (delay: Time option): Transition = (BackgroundColor, time, timing, delay) |> TransitionType

    let backgroundColor1 (time: Time) = (BackgroundColor, Some time, Option.None, Option.None) |> TransitionType
    let backgroundColor2 (time: Time) (timing: Timing) = (BackgroundColor, Some time, Some timing, Option.None) |> TransitionType
    let backgroundColor3 (time: Time) (timing: Timing) (delay: Time) = (BackgroundColor, Some time, Some timing, Some delay) |> TransitionType

    let transitionez (time: Time) (timing: Timing) (delay: Time) = (Transition, Some time, Some timing, Some delay) |> TransitionType