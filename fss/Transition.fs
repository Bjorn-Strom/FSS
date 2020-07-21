namespace Fss

open Utilities.Types
open Animation

open Browser

module Transition =
    type Transition = 
        | TransitionType of string * Time option * Timing option * Time option
        interface ICSSProperty

    let private unwrap = function | TransitionType(a,b,c,d)->(a,b,c,d)

    let value (t: Transition): string =
        let (css, time, timing, delay) = unwrap t
        match (time, timing, delay) with
            | Some time, Some timing, Some delay -> sprintf "%s %s %s %s" css (Animation.value time) (Animation.value timing) (Animation.value delay)
            | Some time, Some timing, _          -> sprintf "%s %s %s" css (Animation.value time) (Animation.value timing)
            | Some time, _, _                    -> sprintf "%s %s" css (Animation.value time)
            | _, _, _                            -> css
                
    let backgroundColorCurried (time: Time option) (timing: Timing option) (delay: Time option): Transition = ("background-color", time, timing, delay) |> TransitionType
    
    let backgroundColorTupled (time: Time option, timing: Timing option) (delay: Time option): Transition = ("background-color", time, timing, delay) |> TransitionType

    let backgroundColor1 (time: Time) = ("background-color", Some time, Option.None, Option.None) |> TransitionType
    let backgroundColor2 (time: Time) (timing: Timing) = ("background-color", Some time, Some timing, Option.None) |> TransitionType
    let backgroundColor3 (time: Time) (timing: Timing) (delay: Time) = ("background-color", Some time, Some timing, Some delay) |> TransitionType