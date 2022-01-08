namespace Fss

open Fss.Types

[<AutoOpen>]
module Transition =
    /// Specifies the duration to wait before a transition starts.
    let TransitionDelay = TransitionClasses.TransitionDelay(Property.TransitionDelay)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duraion
    let TransitionDuration = TransitionClasses.TransitionDuration(Property.TransitionDuration)
    /// Specifies how the intermediate values are calculated.
    let TransitionTimingFunction = TransitionClasses.TransitionTimingFunction(Property.TransitionTimingFunction)
    /// Specifies which property is being transitioned
    let TransitionProperty = TransitionClasses.TransitionProperty(Property.TransitionProperty)
    /// Resets transition.
    let Transition = TransitionClasses.TransitionClass(Property.Transition)
