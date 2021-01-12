namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
module AnimationType =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
    type AnimationDirection =
        | Reverse
        | Alternate
        | AlternateReverse
        interface IAnimationDirection
    type AnimationFillMode =
        | Forwards
        | Backwards
        | Both
        interface IAnimationFillMode

    type IterationCount =
        | Infinite
        interface IAnimationIterationCount

    type AnimationPlayState =
        | Running
        | Paused
        interface IAnimationPlayState

    let iterationCountToString (iterationCount: IAnimationIterationCount) =
        match iterationCount with
        | :? IterationCount as i -> "infinite"
        | :? Global.CssInt as i -> GlobalValue.int i
        | _ -> "Unknown animation iteration count"

[<AutoOpen>]
module Animation =
    open AnimationType

    let private animationDirectionToString (direction: IAnimationDirection) =
        match direction with
            | :? AnimationDirection as d -> Utilities.Helpers.duToKebab d
            | :? Global as g -> GlobalValue.global' g
            | :? Normal -> GlobalValue.normal
            | _ -> "Unknown animation direction"

    let private animationFillModeToString (fillMode: IAnimationFillMode) =
        match fillMode with
            | :? AnimationFillMode as a -> Utilities.Helpers.duToLowercase a
            | :? None -> GlobalValue.none
            | _ -> "Unknown fill mode"

    let private playStateTypeToString (playState: IAnimationPlayState) =
        match playState with
        | :? AnimationPlayState as a -> Utilities.Helpers.duToLowercase a
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown animation play state"

    let private nameToString (name: IAnimationName) =
        match name with
        | :? CssString as s -> GlobalValue.string s
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown animation name"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-delay
    type AnimationDelay =
        static member Value (delay: Units.Time.Time) = PropertyValue.cssValue Property.AnimationDelay (Units.Time.value delay)

    /// <summary>Specifies an amount of time to wait before starting the animation. </summary>
    /// <param name="delay"> Amount of time to wait.</param>
    /// <returns>Css property for fss.</returns>
    let AnimationDelay' (delay: Units.Time.Time) = AnimationDelay.Value(delay)

    let private directionCssValue value = PropertyValue.cssValue Property.AnimationDirection value
    let private directionCssValue' value =
        value
        |> animationDirectionToString
        |> directionCssValue
    type AnimationDirection =
        static member value (direction: IAnimationDirection) = direction |> directionCssValue'
        static member Reverse = Reverse |> directionCssValue'
        static member Alternate = Alternate |> directionCssValue'
        static member AlternateReverse = AlternateReverse |> directionCssValue'

        static member Normal = Normal |> directionCssValue'
        static member Inherit = Inherit |>  directionCssValue'
        static member Initial = Initial |> directionCssValue'
        static member Unset = Unset |> directionCssValue'

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
    let AnimationDirection' (direction: IAnimationDirection) = direction |> directionCssValue'

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-duration
    let private animationDurationCssValue value = PropertyValue.cssValue Property.AnimationDuration value
    type AnimationDuration =
        static member Value (duration: Units.Time.Time) = animationDurationCssValue (Units.Time.value duration)
        static member Values (durations: Units.Time.Time list) =
            durations
            |> Utilities.Helpers.combineComma Units.Time.value
            |> animationDurationCssValue

    /// <summary>Specifies an amount of time for one animation cycle to complete. </summary>
    /// <param name="duration"> Amount of time for one cycle to complete.</param>
    /// <returns>Css property for fss.</returns>
    let AnimationDuration' (duration: Units.Time.Time) = AnimationDuration.Value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-fill-mode
    let private fillModeCssValue value = PropertyValue.cssValue Property.AnimationFillMode value
    let private fillModeCssValue' value =
        value
        |> animationFillModeToString
        |> fillModeCssValue
    type AnimationFillMode =
        static member Value (fillMode: IAnimationFillMode) = fillMode |> fillModeCssValue'
        static member Forwards = Forwards |> fillModeCssValue'
        static member Backwards = Backwards |> fillModeCssValue'
        static member Both = Both |> fillModeCssValue'
        static member None = None |> fillModeCssValue'

    /// <summary>Specifies which styles to apply before and after the animation. </summary>
    /// <param name="fillMode">
    ///     can be:
    ///     - <c> AnimationFillMode </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationFillMode' (fillMode: IAnimationFillMode) = fillMode |> AnimationFillMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-iteration-count
    let private iterationCountCssValue value = PropertyValue.cssValue Property.AnimationIterationCount value
    let private iterationCountCssValue' value =
        value
        |> iterationCountToString
        |> iterationCountCssValue

    type AnimationIterationCount =
        static member Value (count: IAnimationIterationCount) = count |> iterationCountCssValue'
        static member Values (values: IAnimationIterationCount list) =
            values
            |> Utilities.Helpers.combineComma iterationCountToString
            |> iterationCountCssValue
        static member Infinite = Infinite |> iterationCountToString |> iterationCountCssValue

    /// <summary>How many times should an animation be played.</summary>
    /// <param name="iterationCount">
    ///     can be:
    ///     - <c> Infinite </c>
    ///     - <c> CssInt </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationIterationCount' (iterationCount: IAnimationIterationCount) = AnimationIterationCount.Value iterationCount

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-name
    let private nameValue value = PropertyValue.cssValue Property.AnimationName value
    let private nameValue' value =
        value
        |> nameToString
        |> nameValue

    type AnimationName =
        static member Name (name: IAnimationName) = name |> nameValue'
        static member Names (names: IAnimationName list) = Utilities.Helpers.combineComma nameToString names |> nameValue
        static member None = None |> nameValue'
        static member Inherit = Inherit |> nameValue'
        static member Initial = Initial |> nameValue'
        static member Unset = Unset |> nameValue'

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
    let AnimationName' (name: IAnimationName) = AnimationName.Name(name)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state
    let private playStateCssValue value = PropertyValue.cssValue Property.AnimationPlayState value
    let private playStateCssValue' value =
        value
        |> playStateTypeToString
        |> playStateCssValue
    type AnimationPlayState =
        static member Value (playState: IAnimationPlayState) = playState |> playStateCssValue'
        static member Running = Running |> playStateCssValue'
        static member Paused = Paused |> playStateCssValue'
        static member Inherit = Inherit |> playStateCssValue'
        static member Initial = Initial |> playStateCssValue'
        static member Unset = Unset |> playStateCssValue'

    /// <summary>Sets if the animation is running or paused.</summary>
    /// <param name="playState">
    ///     can be:
    ///     - <c> AnimationPlayState </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationPlayState' (playState: IAnimationPlayState) = playState |> AnimationPlayState.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-timing-function
    let private timingFunctionCssValue value = PropertyValue.cssValue Property.AnimationTimingFunction value
    let private timingFunctionCssValue' value =
        value
        |> TimingFunctionType.timingToString
        |> timingFunctionCssValue
    type AnimationTimingFunction =
        static member Value (timingFunction: TimingFunctionType.Timing) = timingFunction |> TimingFunctionType.timingToString
        static member Values (timings: TimingFunctionType.Timing list) = timingFunctionCssValue <| Utilities.Helpers.combineComma TimingFunctionType.timingToString timings
        static member Ease = TimingFunction.TimingFunction.Ease |> timingFunctionCssValue
        static member EaseIn = TimingFunction.TimingFunction.EaseIn |> timingFunctionCssValue
        static member EaseOut = TimingFunction.TimingFunction.EaseOut |> timingFunctionCssValue
        static member EaseInOut = TimingFunction.TimingFunction.EaseInOut |> timingFunctionCssValue
        static member Linear = TimingFunction.TimingFunction.Linear |> timingFunctionCssValue
        static member StepStart = TimingFunction.TimingFunction.StepStart |> timingFunctionCssValue
        static member StepEnd = TimingFunction.TimingFunction.StepEnd |> timingFunctionCssValue
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) =
            TimingFunction.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingFunctionCssValue
        static member Step (steps: int) = TimingFunction.TimingFunction.Step(steps) |> timingFunctionCssValue
        static member Step (steps: int, jumpTerm: TimingFunctionType.Step) =
            TimingFunction.TimingFunction.Step(steps, jumpTerm) |> timingFunctionCssValue
        static member Inherit = Inherit |> timingFunctionCssValue'
        static member Initial = Initial |> timingFunctionCssValue'
        static member Unset = Unset |> timingFunctionCssValue'

    /// <summary>Specifies how the animation should be played.</summary>
    /// <param name="timing">
    ///     can be:
    ///     - <c> AnimationTimingFunction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationTimingFunction' (timing: TimingFunctionType.Timing) = AnimationTimingFunction.Value(timing)
