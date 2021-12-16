namespace Fss

open Fss.FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
[<AutoOpen>]
module Animation =
    /// Specifies the delay before the animation starts
    let AnimationDelay =
        Animation.AnimationClasses.AnimationTime(Property.AnimationDelay)
    /// Specifies the direction of an animation
    let AnimationDirection =
        Animation.AnimationClasses.AnimationDirection(Property.AnimationDirection)
    /// Specifies how long an animation takes to complete a cycle.
    let AnimationDuration =
        Animation.AnimationClasses.AnimationTime(Property.AnimationDuration)
    // Specifies how a CSS animation is applied to its target
    let AnimationFillMode =
        Animation.AnimationClasses.AnimationFillMode(Property.AnimationFillMode)
    /// Specifies how many times an animation should be played before stopping.
    let AnimationIterationCount =
        Animation.AnimationClasses.AnimationIterationCount(Property.AnimationIterationCount)
    /// Specifies which animation to play
    let AnimationName =
        Animation.AnimationClasses.AnimationName(Property.AnimationName)
    /// Specifies if the animation is running or paused.
    let AnimationPlayState =
        Animation.AnimationClasses.AnimationPlayState(Property.AnimationPlayState)
    /// Specifies how the animation should be played.
    let AnimationTimingFunction =
        Animation.AnimationClasses.AnimationTimingFunction(Property.AnimationTimingFunction)
