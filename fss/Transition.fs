namespace Fss

open Utilities.Types
open Property
open Animation

module Transition =
    type Transition = 
        | Transition1 of Property * Time 
        | Transition2 of Property * Time * Timing 
        | Transition3 of Property * Time * Timing * Time 
        interface ICSSProperty

    let value (v: Transition): string =
        match v with
            | Transition1 (property, time)                -> sprintf "%s %s" (Property.pascalToKebabCase property) (Animation.value time)
            | Transition2 (property, time, timing)        -> sprintf "%s %s %s" (Property.pascalToKebabCase property) (Animation.value time) (Animation.value timing)
            | Transition3 (property, time, timing, delay) -> sprintf "%s %s %s %s" (Property.pascalToKebabCase property) (Animation.value time) (Animation.value timing) (Animation.value delay)