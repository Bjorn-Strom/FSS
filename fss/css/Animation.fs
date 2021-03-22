namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
[<AutoOpen>]
module Animation =

    let private animationDirectionToString (direction: Types.IAnimationDirection) =
        match direction with
            | :? Types.Animation.Direction as d -> Utilities.Helpers.duToKebab d
            | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
            | :? Types.Normal -> Types.masterTypeHelpers.normal
            | _ -> "Unknown animation direction"

    let private animationFillModeToString (fillMode: Types.IAnimationFillMode) =
        match fillMode with
            | :? Types.Animation.FillMode as a -> Utilities.Helpers.duToLowercase a
            | :? Types.None' -> Types.masterTypeHelpers.none
            | _ -> "Unknown fill mode"

    let private playStateTypeToString (playState: Types.IAnimationPlayState) =
        match playState with
        | :? Types.Animation.PlayState as a -> Utilities.Helpers.duToLowercase a
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown animation play state"

    let private nameToString (name: Types.IAnimationName) =
        match name with
        | :? Types.CssString as s -> Types.masterTypeHelpers.StringToString s
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown animation name"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-delay
    type AnimationDelay =
        static member Value (delay: Types.Time) = Types.propertyHelpers.cssValue Types.Property.AnimationDelay (Types.unitHelpers.timeToString delay)

    /// <summary>Specifies an amount of time to wait before starting the animation. </summary>
    /// <param name="delay"> Amount of time to wait.</param>
    /// <returns>Css property for fss.</returns>
    let AnimationDelay' (delay: Types.Time) = AnimationDelay.Value(delay)

    let private directionCssValue value = Types.propertyHelpers.cssValue Types.Property.AnimationDirection value
    let private directionCssValue' value =
        value
        |> animationDirectionToString
        |> directionCssValue
    type AnimationDirection =
        static member value (direction: Types.IAnimationDirection) = direction |> directionCssValue'
        static member Reverse = Types.Animation.Direction.Reverse |> directionCssValue'
        static member Alternate = Types.Animation.Direction.Alternate |> directionCssValue'
        static member AlternateReverse = Types.Animation.Direction.AlternateReverse |> directionCssValue'

        static member Normal = Types.Normal |> directionCssValue'
        static member Inherit = Types.Inherit |>  directionCssValue'
        static member Initial = Types.Initial |> directionCssValue'
        static member Unset = Types.Unset |> directionCssValue'

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
    let AnimationDirection' (direction: Types.IAnimationDirection) = direction |> directionCssValue'

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-duration
    let private animationDurationCssValue value = Types.propertyHelpers.cssValue Types.Property.AnimationDuration value
    type AnimationDuration =
        static member Value (duration: Types.Time) = animationDurationCssValue (Types.unitHelpers.timeToString duration)
        static member Values (durations: Types.Time list) =
            durations
            |> Utilities.Helpers.combineComma Types.unitHelpers.timeToString
            |> animationDurationCssValue

    /// <summary>Specifies an amount of time for one animation cycle to complete. </summary>
    /// <param name="duration"> Amount of time for one cycle to complete.</param>
    /// <returns>Css property for fss.</returns>
    let AnimationDuration' (duration: Types.Time) = AnimationDuration.Value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-fill-mode
    let private fillModeCssValue value = Types.propertyHelpers.cssValue Types.Property.AnimationFillMode value
    let private fillModeCssValue' value =
        value
        |> animationFillModeToString
        |> fillModeCssValue
    type AnimationFillMode =
        static member Value (fillMode: Types.IAnimationFillMode) = fillMode |> fillModeCssValue'
        static member Forwards = Types.Animation.FillMode.Forwards |> fillModeCssValue'
        static member Backwards = Types.Animation.FillMode.Backwards |> fillModeCssValue'
        static member Both = Types.Animation.FillMode.Both |> fillModeCssValue'
        static member None = Types.None' |> fillModeCssValue'

    /// <summary>Specifies which styles to apply before and after the animation. </summary>
    /// <param name="fillMode">
    ///     can be:
    ///     - <c> AnimationFillMode </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationFillMode' (fillMode: Types.IAnimationFillMode) = fillMode |> AnimationFillMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-iteration-count
    let private iterationCountCssValue value = Types.propertyHelpers.cssValue Types.Property.AnimationIterationCount value
    let private iterationCountCssValue' value =
        value
        |> Types.animationHelpers.iterationCountToString
        |> iterationCountCssValue

    type AnimationIterationCount =
        static member Value (count: Types.IAnimationIterationCount) = count |> iterationCountCssValue'
        static member Values (values: Types.IAnimationIterationCount list) =
            values
            |> Utilities.Helpers.combineComma Types.animationHelpers.iterationCountToString
            |> iterationCountCssValue
        static member Infinite = Types.Animation.IterationCount.Infinite |> Types.animationHelpers.iterationCountToString |> iterationCountCssValue

    /// <summary>How many times should an animation be played.</summary>
    /// <param name="iterationCount">
    ///     can be:
    ///     - <c> Infinite </c>
    ///     - <c> CssInt </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationIterationCount' (iterationCount: Types.IAnimationIterationCount) = AnimationIterationCount.Value iterationCount

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-name
    let private nameValue value = Types.propertyHelpers.cssValue Types.Property.AnimationName value
    let private nameValue' value =
        value
        |> nameToString
        |> nameValue

    type AnimationName =
        static member Name (name: Types.IAnimationName) = name |> nameValue'
        static member Names (names: Types.IAnimationName list) = Utilities.Helpers.combineComma nameToString names |> nameValue
        static member None = Types.None' |> nameValue'
        static member Inherit = Types.Inherit |> nameValue'
        static member Initial = Types.Initial |> nameValue'
        static member Unset = Types.Unset |> nameValue'

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
    let AnimationName' (name: Types.IAnimationName) = AnimationName.Name(name)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state
    let private playStateCssValue value = Types.propertyHelpers.cssValue Types.Property.AnimationPlayState value
    let private playStateCssValue' value =
        value
        |> playStateTypeToString
        |> playStateCssValue
    type AnimationPlayState =
        static member Value (playState: Types.IAnimationPlayState) = playState |> playStateCssValue'
        static member Running = Types.Animation.PlayState.Running |> playStateCssValue'
        static member Paused = Types.Animation.PlayState.Paused |> playStateCssValue'
        static member Inherit = Types.Inherit |> playStateCssValue'
        static member Initial = Types.Initial |> playStateCssValue'
        static member Unset = Types.Unset |> playStateCssValue'

    /// <summary>Sets if the animation is running or paused.</summary>
    /// <param name="playState">
    ///     can be:
    ///     - <c> AnimationPlayState </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationPlayState' (playState: Types.IAnimationPlayState) = playState |> AnimationPlayState.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-timing-function
    let private timingFunctionCssValue value = Types.propertyHelpers.cssValue Types.Property.AnimationTimingFunction value
    let private timingFunctionCssValue' value =
        value
        |> Types.timingFunctionHelpers.timingToString
        |> timingFunctionCssValue
    type AnimationTimingFunction =
        static member Value (timingFunction: Types.TimingFunction.Timing) = timingFunction |> Types.timingFunctionHelpers.timingToString
        static member Values (timings: Types.TimingFunction.Timing list) = timingFunctionCssValue <| Utilities.Helpers.combineComma Types.timingFunctionHelpers.timingToString timings
        static member Ease = Types.TimingFunction.Ease |> timingFunctionCssValue'
        static member EaseIn = Types.TimingFunction.EaseIn |> timingFunctionCssValue'
        static member EaseOut = Types.TimingFunction.EaseOut |> timingFunctionCssValue'
        static member EaseInOut = Types.TimingFunction.EaseInOut |> timingFunctionCssValue'
        static member Linear = Types.TimingFunction.Linear |> timingFunctionCssValue'
        static member StepStart = Types.TimingFunction.StepStart |> timingFunctionCssValue'
        static member StepEnd = Types.TimingFunction.StepEnd |> timingFunctionCssValue'
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) =
            Types.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingFunctionCssValue'
        static member Step (steps: int) = Types.TimingFunction.Steps(steps) |> timingFunctionCssValue
        static member Step (steps: int, jumpTerm: Types.TimingFunction.Step) =
            Types.TimingFunction.StepsWithTerm(steps, jumpTerm) |> timingFunctionCssValue
        static member Inherit = Types.Inherit |> timingFunctionCssValue'
        static member Initial = Types.Initial |> timingFunctionCssValue'
        static member Unset = Types.Unset |> timingFunctionCssValue'

    /// <summary>Specifies how the animation should be played.</summary>
    /// <param name="timing">
    ///     can be:
    ///     - <c> AnimationTimingFunction </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AnimationTimingFunction' (timing: Types.TimingFunction.Timing) = AnimationTimingFunction.Value(timing)
