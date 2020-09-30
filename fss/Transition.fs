namespace Fss

open Types
open Global
open Property
open Animation
open Units.Time

module Transition =
    type Transition =
        | Transition1 of Property * ITransitionDuration
        | Transition2 of Property * ITransitionDuration * Timing
        | Transition3 of Property * ITransitionDuration * Timing * Time
        interface ITransition

    type TransitionDuration =
        | Value of Time
        interface ITransitionDuration

module TransitionValue =
    open Transition

    let private transitionValue (v: Transition): string =
        match v with
            | Transition1 (property, time)                -> sprintf "%s %s" (Property.propertyToKebabCase property) (Units.Time.value time)
            | Transition2 (property, time, timing)        -> sprintf "%s %s %s" (Property.propertyToKebabCase property) (Units.Time.value time) (AnimationValue.timingFunction timing)
            | Transition3 (property, time, timing, delay) -> sprintf "%s %s %s %s" (Property.propertyToKebabCase property) (Units.Time.value time) (AnimationValue.timingFunction timing) (Units.Time.value delay)

    let transition (v: ITransition): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Transition as t -> transitionValue t
            | _ -> "Unknown transition"

    let duration (v: ITransitionDuration): string =
        let stringifyDuration (d: TransitionDuration) =
            match d with
                | Value t -> Units.Time.value t
                | _ -> "Unknown transition duration"

        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? TransitionDuration as t -> stringifyDuration t
            | _ -> "Unknown transition duration"




