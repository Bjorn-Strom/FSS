namespace Fss

open Types
open Global
open Property
open Animation
open Units.Time

module Transition =
    type Transition = 
        | Transition1 of Property * Time 
        | Transition2 of Property * Time * Timing 
        | Transition3 of Property * Time * Timing * Time 
        interface ITransition

module TransitionValue =
    open Transition

    let private transitionValue (v: Transition): string =
        match v with
            | Transition1 (property, time)                -> sprintf "%s %s" (Property.propertyToKebabCase property) (Units.Time.value time)
            | Transition2 (property, time, timing)        -> sprintf "%s %s %s" (Property.propertyToKebabCase property) (Units.Time.value time) (AnimationValue.timing timing)
            | Transition3 (property, time, timing, delay) -> sprintf "%s %s %s %s" (Property.propertyToKebabCase property) (Units.Time.value time) (AnimationValue.timing timing) (Units.Time.value delay)

    let value (v: ITransition): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Transition as t -> transitionValue t
            | _ -> "Unknown transition"
 

