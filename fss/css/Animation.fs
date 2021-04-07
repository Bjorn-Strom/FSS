namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
[<AutoOpen>]
module Animation =
    let private animationDirectionToString (direction: FssTypes.IAnimationDirection) =
        match direction with
            | :? FssTypes.Animation.Direction as d -> Utilities.Helpers.duToKebab d
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
            | _ -> "Unknown animation direction"

    let private animationFillModeToString (fillMode: FssTypes.IAnimationFillMode) =
        match fillMode with
            | :? FssTypes.Animation.FillMode as a -> Utilities.Helpers.duToLowercase a
            | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
            | _ -> "Unknown fill mode"

    let private playStateTypeToString (playState: FssTypes.IAnimationPlayState) =
        match playState with
        | :? FssTypes.Animation.PlayState as a -> Utilities.Helpers.duToLowercase a
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown animation play state"

    let private nameToString (name: FssTypes.IAnimationName) =
        match name with
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown animation name"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-delay
    [<Erase>]
    type AnimationDelay =
        static member Value (delay: FssTypes.Time) = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationDelay (FssTypes.unitHelpers.timeToString delay)

    let AnimationDelay' = AnimationDelay.Value

    let private directionCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationDirection
    let private directionCssValue' = animationDirectionToString >> directionCssValue

    [<Erase>]
    type AnimationDirection =
        static member value (direction: FssTypes.IAnimationDirection) = direction |> directionCssValue'
        static member reverse = FssTypes.Animation.Direction.Reverse |> directionCssValue'
        static member alternate = FssTypes.Animation.Direction.Alternate |> directionCssValue'
        static member alternateReverse = FssTypes.Animation.Direction.AlternateReverse |> directionCssValue'

        static member normal = FssTypes.Normal |> directionCssValue'
        static member inherit' = FssTypes.Inherit |>  directionCssValue'
        static member initial = FssTypes.Initial |> directionCssValue'
        static member unset = FssTypes.Unset |> directionCssValue'

    /// <summary>Sets which direction an animation should play. </summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> AnimationDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Normal </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationDirection' = directionCssValue'

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-duration
    let private animationDurationCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationDuration

    [<Erase>]
    type AnimationDuration =
        static member value (duration: FssTypes.Time) = animationDurationCssValue (FssTypes.unitHelpers.timeToString duration)
        static member values = Utilities.Helpers.combineComma FssTypes.unitHelpers.timeToString >> animationDurationCssValue

    let AnimationDuration' = AnimationDuration.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-fill-mode
    let private fillModeCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationFillMode
    let private fillModeCssValue' = animationFillModeToString >> fillModeCssValue

    [<Erase>]
    type AnimationFillMode =
        static member value (fillMode: FssTypes.IAnimationFillMode) = fillMode |> fillModeCssValue'
        static member forwards = FssTypes.Animation.FillMode.Forwards |> fillModeCssValue'
        static member backwards = FssTypes.Animation.FillMode.Backwards |> fillModeCssValue'
        static member both = FssTypes.Animation.FillMode.Both |> fillModeCssValue'
        static member none = FssTypes.None' |> fillModeCssValue'

    let AnimationFillMode' = AnimationFillMode.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-iteration-count
    let private iterationCountCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationIterationCount
    let private iterationCountCssValue' = FssTypes.animationHelpers.iterationCountToString >> iterationCountCssValue

    [<Erase>]
    type AnimationIterationCount =
        static member value (count: FssTypes.IAnimationIterationCount) = count |> iterationCountCssValue'
        static member values (values: FssTypes.IAnimationIterationCount list) =
            values
            |> Utilities.Helpers.combineComma FssTypes.animationHelpers.iterationCountToString
            |> iterationCountCssValue
        static member infinite = FssTypes.Animation.IterationCount.Infinite |> FssTypes.animationHelpers.iterationCountToString |> iterationCountCssValue

    /// <summary>How many times should an animation be played.</summary>
    /// <param name="iterationCount">
    ///     can be:
    ///     - <c> Infinite </c>
    ///     - <c> CssInt </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationIterationCount' = AnimationIterationCount.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-name
    let private nameValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationName
    let private nameValue' = nameToString >> nameValue

    [<Erase>]
    type AnimationName =
        static member name (name: FssTypes.IAnimationName) = name |> nameValue'
        static member names (names: FssTypes.IAnimationName list) = Utilities.Helpers.combineComma nameToString names |> nameValue
        static member none = FssTypes.None' |> nameValue'
        static member inherit' = FssTypes.Inherit |> nameValue'
        static member initial = FssTypes.Initial |> nameValue'
        static member unset = FssTypes.Unset |> nameValue'

    /// <summary>Specifies which animation to play.</summary>
    /// <param name="name">
    ///     can be:
    ///     - <c> The result of a keyframe function </c>
    ///     - <c> CssString </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationName' = AnimationName.name

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state
    let private playStateCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationPlayState
    let private playStateCssValue' = playStateTypeToString >> playStateCssValue

    [<Erase>]
    type AnimationPlayState =
        static member value (playState: FssTypes.IAnimationPlayState) = playState |> playStateCssValue'
        static member running = FssTypes.Animation.PlayState.Running |> playStateCssValue'
        static member paused = FssTypes.Animation.PlayState.Paused |> playStateCssValue'
        static member inherit' = FssTypes.Inherit |> playStateCssValue'
        static member initial = FssTypes.Initial |> playStateCssValue'
        static member unset = FssTypes.Unset |> playStateCssValue'

    /// <summary>Sets if the animation is running or paused.</summary>
    /// <param name="playState">
    ///     can be:
    ///     - <c> AnimationPlayState </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationPlayState' = AnimationPlayState.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-timing-function
    let private timingFunctionCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationTimingFunction
    let private timingFunctionCssValue': (FssTypes.ITransitionTimingFunction -> FssTypes.CssProperty) = FssTypes.timingFunctionHelpers.timingToString >> timingFunctionCssValue

    [<Erase>]
    type AnimationTimingFunction =
        static member value (timingFunction: FssTypes.TimingFunction.Timing) = timingFunction |> FssTypes.timingFunctionHelpers.timingToString
        static member values (timings: FssTypes.TimingFunction.Timing list) = timingFunctionCssValue <| Utilities.Helpers.combineComma FssTypes.timingFunctionHelpers.timingToString timings
        static member ease = FssTypes.TimingFunction.Ease |> timingFunctionCssValue'
        static member easeIn = FssTypes.TimingFunction.EaseIn |> timingFunctionCssValue'
        static member easeOut = FssTypes.TimingFunction.EaseOut |> timingFunctionCssValue'
        static member easeInOut = FssTypes.TimingFunction.EaseInOut |> timingFunctionCssValue'
        static member linear = FssTypes.TimingFunction.Linear |> timingFunctionCssValue'
        static member stepStart = FssTypes.TimingFunction.StepStart |> timingFunctionCssValue'
        static member stepEnd = FssTypes.TimingFunction.StepEnd |> timingFunctionCssValue'
        static member cubicBezier (p1: float, p2:float, p3:float, p4:float) =
            FssTypes.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingFunctionCssValue'
        static member step (steps: int) = FssTypes.TimingFunction.Steps(steps) |> timingFunctionCssValue'
        static member step (steps: int, jumpTerm: FssTypes.TimingFunction.Step) =
            FssTypes.TimingFunction.StepsWithTerm(steps, jumpTerm) |> timingFunctionCssValue'
        static member inherit' = FssTypes.Inherit |> timingFunctionCssValue'
        static member initial = FssTypes.Initial |> timingFunctionCssValue'
        static member unset = FssTypes.Unset |> timingFunctionCssValue'

    /// <summary>Specifies how the animation should be played.</summary>
    /// <param name="timing">
    ///     can be:
    ///     - <c> AnimationTimingFunction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationTimingFunction' = AnimationTimingFunction.value
