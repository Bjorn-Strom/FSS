namespace Fss

open Fss.Types

[<AutoOpen>]
module TransitionCss =
    /// Specifies the duration to wait before a transition starts.
    let TransitionDelay = TransitionClasses.TransitionDelay(Property.TransitionDelay)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duraion
    let TransitionDuration = TransitionClasses.TransitionDuration(Property.TransitionDuration)
    /// Specifies how the intermediate values are calculated.
    let TransitionTimingFunction = TransitionClasses.TransitionTimingFunction(Property.TransitionTimingFunction)
    /// Specifies which property is being transitioned
    let TransitionProperty = TransitionClasses.TransitionProperty(Property.TransitionProperty)
    /// Specifies the transition behavior
    let TransitionBehavior = TransitionClasses.TransitionBehavior(Property.TransitionBehavior)
    /// Resets transition.
    let Transition = TransitionClasses.TransitionClass(Property.Transition)
