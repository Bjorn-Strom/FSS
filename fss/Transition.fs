namespace Fss

open Types
open Global
open Property
open Animation
open Time

module Transition =
    type Transition = 
        | Transition1 of Property * Time 
        | Transition2 of Property * Time * Timing 
        | Transition3 of Property * Time * Timing * Time 
        interface ITransition

    let private transitionValue (v: Transition): string =
        match v with
            | Transition1 (property, time)                -> sprintf "%s %s" (Property.propertyToKebabCase property) (Animation.value time)
            | Transition2 (property, time, timing)        -> sprintf "%s %s %s" (Property.propertyToKebabCase property) (Animation.value time) (Animation.value timing)
            | Transition3 (property, time, timing, delay) -> sprintf "%s %s %s %s" (Property.propertyToKebabCase property) (Animation.value time) (Animation.value timing) (Animation.value delay)

    let value (v: ITransition): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Transition as t -> transitionValue t
            | _ -> "Unknown transition"
 

