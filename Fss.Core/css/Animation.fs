namespace Fss

open Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
[<AutoOpen>]
module Animation =
    /// Specifies the delay before the animation starts
    let AnimationDelay = AnimationClasses.AnimationTime(Property.AnimationDelay)
    /// Specifies the direction of an animation
    let AnimationDirection = AnimationClasses.AnimationDirection(Property.AnimationDirection)
    /// Specifies how long an animation takes to complete a cycle.
    let AnimationDuration = AnimationClasses.AnimationTime(Property.AnimationDuration)
    // Specifies how a CSS animation is applied to its target
    let AnimationFillMode = AnimationClasses.AnimationFillMode(Property.AnimationFillMode)
    /// Specifies how many times an animation should be played before stopping.
    let AnimationIterationCount = AnimationClasses.AnimationIterationCount(Property.AnimationIterationCount)
    /// Specifies which animation to play
    let AnimationName = AnimationClasses.AnimationName(Property.AnimationName)
    /// Specifies if the animation is running or paused.
    let AnimationPlayState = AnimationClasses.AnimationPlayState(Property.AnimationPlayState)
    /// Specifies how the animation should be played.
    let AnimationTimingFunction = AnimationClasses.AnimationTimingFunction(Property.AnimationTimingFunction)
