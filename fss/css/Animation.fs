namespace Fss

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
    type AnimationDelay =
        static member Value (delay: FssTypes.Time) = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationDelay (FssTypes.unitHelpers.timeToString delay)

    /// <summary>Specifies an amount of time to wait before starting the animation. </summary>
    /// <param name="delay"> Amount of time to wait.</param>
    /// <returns>Css property for fss.</returns>
    let AnimationDelay' (delay: FssTypes.Time) = AnimationDelay.Value(delay)

    let private directionCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationDirection value
    let private directionCssValue' value =
        value
        |> animationDirectionToString
        |> directionCssValue
    type AnimationDirection =
        static member value (direction: FssTypes.IAnimationDirection) = direction |> directionCssValue'
        static member Reverse = FssTypes.Animation.Direction.Reverse |> directionCssValue'
        static member Alternate = FssTypes.Animation.Direction.Alternate |> directionCssValue'
        static member AlternateReverse = FssTypes.Animation.Direction.AlternateReverse |> directionCssValue'

        static member Normal = FssTypes.Normal |> directionCssValue'
        static member Inherit = FssTypes.Inherit |>  directionCssValue'
        static member Initial = FssTypes.Initial |> directionCssValue'
        static member Unset = FssTypes.Unset |> directionCssValue'

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
    let AnimationDirection' (direction: FssTypes.IAnimationDirection) = direction |> directionCssValue'

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-duration
    let private animationDurationCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationDuration value
    type AnimationDuration =
        static member Value (duration: FssTypes.Time) = animationDurationCssValue (FssTypes.unitHelpers.timeToString duration)
        static member Values (durations: FssTypes.Time list) =
            durations
            |> Utilities.Helpers.combineComma FssTypes.unitHelpers.timeToString
            |> animationDurationCssValue

    /// <summary>Specifies an amount of time for one animation cycle to complete. </summary>
    /// <param name="duration"> Amount of time for one cycle to complete.</param>
    /// <returns>Css property for fss.</returns>
    let AnimationDuration' (duration: FssTypes.Time) = AnimationDuration.Value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-fill-mode
    let private fillModeCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationFillMode value
    let private fillModeCssValue' value =
        value
        |> animationFillModeToString
        |> fillModeCssValue
    type AnimationFillMode =
        static member Value (fillMode: FssTypes.IAnimationFillMode) = fillMode |> fillModeCssValue'
        static member Forwards = FssTypes.Animation.FillMode.Forwards |> fillModeCssValue'
        static member Backwards = FssTypes.Animation.FillMode.Backwards |> fillModeCssValue'
        static member Both = FssTypes.Animation.FillMode.Both |> fillModeCssValue'
        static member None = FssTypes.None' |> fillModeCssValue'

    /// <summary>Specifies which styles to apply before and after the animation. </summary>
    /// <param name="fillMode">
    ///     can be:
    ///     - <c> AnimationFillMode </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationFillMode' (fillMode: FssTypes.IAnimationFillMode) = fillMode |> AnimationFillMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-iteration-count
    let private iterationCountCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationIterationCount value
    let private iterationCountCssValue' value =
        value
        |> FssTypes.animationHelpers.iterationCountToString
        |> iterationCountCssValue

    type AnimationIterationCount =
        static member Value (count: FssTypes.IAnimationIterationCount) = count |> iterationCountCssValue'
        static member Values (values: FssTypes.IAnimationIterationCount list) =
            values
            |> Utilities.Helpers.combineComma FssTypes.animationHelpers.iterationCountToString
            |> iterationCountCssValue
        static member Infinite = FssTypes.Animation.IterationCount.Infinite |> FssTypes.animationHelpers.iterationCountToString |> iterationCountCssValue

    /// <summary>How many times should an animation be played.</summary>
    /// <param name="iterationCount">
    ///     can be:
    ///     - <c> Infinite </c>
    ///     - <c> CssInt </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationIterationCount' (iterationCount: FssTypes.IAnimationIterationCount) = AnimationIterationCount.Value iterationCount

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-name
    let private nameValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationName value
    let private nameValue' value =
        value
        |> nameToString
        |> nameValue

    type AnimationName =
        static member Name (name: FssTypes.IAnimationName) = name |> nameValue'
        static member Names (names: FssTypes.IAnimationName list) = Utilities.Helpers.combineComma nameToString names |> nameValue
        static member None = FssTypes.None' |> nameValue'
        static member Inherit = FssTypes.Inherit |> nameValue'
        static member Initial = FssTypes.Initial |> nameValue'
        static member Unset = FssTypes.Unset |> nameValue'

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
    let AnimationName' (name: FssTypes.IAnimationName) = AnimationName.Name(name)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state
    let private playStateCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationPlayState value
    let private playStateCssValue' value =
        value
        |> playStateTypeToString
        |> playStateCssValue
    type AnimationPlayState =
        static member Value (playState: FssTypes.IAnimationPlayState) = playState |> playStateCssValue'
        static member Running = FssTypes.Animation.PlayState.Running |> playStateCssValue'
        static member Paused = FssTypes.Animation.PlayState.Paused |> playStateCssValue'
        static member Inherit = FssTypes.Inherit |> playStateCssValue'
        static member Initial = FssTypes.Initial |> playStateCssValue'
        static member Unset = FssTypes.Unset |> playStateCssValue'

    /// <summary>Sets if the animation is running or paused.</summary>
    /// <param name="playState">
    ///     can be:
    ///     - <c> AnimationPlayState </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationPlayState' (playState: FssTypes.IAnimationPlayState) = playState |> AnimationPlayState.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-timing-function
    let private timingFunctionCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AnimationTimingFunction value
    let private timingFunctionCssValue' value =
        value
        |> FssTypes.timingFunctionHelpers.timingToString
        |> timingFunctionCssValue
    type AnimationTimingFunction =
        static member Value (timingFunction: FssTypes.TimingFunction.Timing) = timingFunction |> FssTypes.timingFunctionHelpers.timingToString
        static member Values (timings: FssTypes.TimingFunction.Timing list) = timingFunctionCssValue <| Utilities.Helpers.combineComma FssTypes.timingFunctionHelpers.timingToString timings
        static member Ease = FssTypes.TimingFunction.Ease |> timingFunctionCssValue'
        static member EaseIn = FssTypes.TimingFunction.EaseIn |> timingFunctionCssValue'
        static member EaseOut = FssTypes.TimingFunction.EaseOut |> timingFunctionCssValue'
        static member EaseInOut = FssTypes.TimingFunction.EaseInOut |> timingFunctionCssValue'
        static member Linear = FssTypes.TimingFunction.Linear |> timingFunctionCssValue'
        static member StepStart = FssTypes.TimingFunction.StepStart |> timingFunctionCssValue'
        static member StepEnd = FssTypes.TimingFunction.StepEnd |> timingFunctionCssValue'
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) =
            FssTypes.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingFunctionCssValue'
        static member Step (steps: int) = FssTypes.TimingFunction.Steps(steps) |> timingFunctionCssValue'
        static member Step (steps: int, jumpTerm: FssTypes.TimingFunction.Step) =
            FssTypes.TimingFunction.StepsWithTerm(steps, jumpTerm) |> timingFunctionCssValue'
        static member Inherit = FssTypes.Inherit |> timingFunctionCssValue'
        static member Initial = FssTypes.Initial |> timingFunctionCssValue'
        static member Unset = FssTypes.Unset |> timingFunctionCssValue'

    /// <summary>Specifies how the animation should be played.</summary>
    /// <param name="timing">
    ///     can be:
    ///     - <c> AnimationTimingFunction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationTimingFunction' (timing: FssTypes.TimingFunction.Timing) = AnimationTimingFunction.Value(timing)
