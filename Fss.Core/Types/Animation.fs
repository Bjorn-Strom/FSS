namespace Fss

namespace Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
[<RequireQualifiedAccess>]
module Animation =
    type Direction =
        | Normal
        | Reverse
        | Alternate
        | AlternateReverse
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Normal -> "normal"
                | Reverse -> "reverse"
                | Alternate -> "alternate"
                | AlternateReverse -> "alternate-reverse"

    type Step = TimingFunction.Step

    type FillMode =
        | Forwards
        | Backwards
        | Both
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Forwards -> "forwards"
                | Backwards -> "backwards"
                | Both -> "both"

    type IterationCount =
        | Infinite
        | Value of int
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Infinite -> "infinite"
                | Value v -> string v

    type PlayState =
        | Running
        | Paused
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Running -> "running"
                | Paused -> "paused"

    type Shorthand =
        { duration: Time option
          easingFunction: TimingFunction.Timing option
          delay: Time option
          iterationCount: int option
          direction: Direction option
          fillMode: FillMode option
          playState: PlayState option
          name: string }
        interface ICssValue with
            member this.StringifyCss() =
                let values =
                     [stringifyOptionToCssString this.duration
                      stringifyOptionToCssString this.easingFunction
                      stringifyOptionToCssString this.delay
                      if this.iterationCount.IsSome then string this.iterationCount.Value else ""
                      stringifyOptionToCssString this.direction
                      stringifyOptionToCssString this.fillMode
                      stringifyOptionToCssString this.playState ]
                     |> List.filter (fun s -> s <> "")
                     |> String.concat " "

                if values <> "" then
                    $"{values} {this.name}"
                else
                    this.name

[<RequireQualifiedAccess>]
module AnimationClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation
    type Animation(property) =
        inherit CssRule(property)

        member this.value(name: string,
                          ?duration: Time,
                          ?easingFunction: TimingFunction.Timing,
                          ?delay: Time,
                          ?iterationCount: int,
                          ?direction: Animation.Direction,
                          ?fillMode: Animation.FillMode,
                          ?playState: Animation.PlayState) =
            let shorthand: Animation.Shorthand = {
                    duration = duration
                    easingFunction = easingFunction
                    delay = delay
                    iterationCount = iterationCount
                    direction = direction
                    fillMode = fillMode
                    playState = playState
                    name = name
            }
            (property, shorthand) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-delay
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-duration
    type AnimationTime(property) =
        inherit CssRuleWithValueFunctions<Time>(property, ",")

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
    type AnimationDirection(property) =
        inherit CssRuleWithValueFunctions<Animation.Direction>(property, ",")

        /// Animation plays forwards and resets to the beginning over and over.
        member this.normal = (property, Normal) |> Rule
        /// Animation plays backwards and resets to the end over and over.
        member this.reverse = (property, Animation.Reverse) |> Rule
        /// Animation alternates between going forward and backward. The first iteration is forwards.
        member this.alternate = (property, Animation.Alternate) |> Rule
        /// Animation alternates between going backward and forward. The first iteration is backwards.
        member this.alternateReverse = (property, Animation.AlternateReverse) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-fill-mode
    type AnimationFillMode(property) =
        inherit CssRuleWithValueFunctions<Animation.FillMode>(property, ",")
        /// No styles will be applied when the animation is not running.
        member this.none = (property, None') |> Rule
        /// After the animation the target will keep the values from the final frame of the animation.
        member this.forwards = (property, Animation.Forwards) |> Rule
        /// After the animation the target will keep the values from the first frame of the animation.
        member this.backwards = (property, Animation.Backwards) |> Rule
        /// A combination of forwards and backwards. The element has the styles of the first frame before the animation begins
        /// and the last frame when it ends.
        member this.both = (property, Animation.Both) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-iteration-count
    type AnimationIterationCount(property) =
        inherit CssRule(property)

        /// The number of times the animation will play
        member this.value(iterationCount: float) =
            (property, iterationCount |> Float) |> Rule

        member this.value(iterationCounts: Animation.IterationCount list) =
            let iterationCounts =
                iterationCounts
                |> List.map stringifyICssValue
                |> String.concat ","
            (property, iterationCounts |> String) |> Rule

        /// The animation will repeat forever
        member this.infinite = (property, Animation.Infinite) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-name
    type AnimationName(property) =
        inherit CssRule(property)
        /// The name of the animation to use
        member this.value(name: string) =
            (property, name |> String) |> Rule
        /// List of animations to use
        member this.value(names: string list) =
            let names =
                String.concat "," names
            (property, names |> String) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state
    type AnimationPlayState(property) =
        inherit CssRuleWithValueFunctions<Animation.PlayState>(property, ",")
        /// Sets the animation to running
        member this.running = (property, Animation.Running) |> Rule
        /// Sets the animation to paused
        member this.paused = (property, Animation.Paused) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-timing-function
    type AnimationTimingFunction(property) =
        inherit CssRuleWithValueFunctions<TimingFunction.Timing>(property, ",")
        /// Increases animation velocity toward the middle and slowing back down at the end
        member this.ease = (property, TimingFunction.Ease) |> Rule
        /// The animation starts slow with the speed increasing toward the end
        member this.easeIn = (property, TimingFunction.EaseIn) |> Rule
        /// The animation starts fast with the speed decreasing toward the end
        member this.easeOut = (property, TimingFunction.EaseOut) |> Rule
        /// The animation starts slow getting faster toward the middle and again slowing down toward the end
        member this.easeInOut = (property, TimingFunction.EaseInOut) |> Rule
        /// Animates at an even speed
        member this.linear = (property, TimingFunction.Linear) |> Rule
        /// The animation will jump to the end state and stay there until the end
        member this.stepStart = (property, TimingFunction.StepStart) |> Rule
        /// The animation will stay in its initial state until the end, then it jumps to its final position
        member this.stepEnd = (property, TimingFunction.StepEnd) |> Rule
        /// Define a specific Bézier curve for the animation timing
        member this.cubicBezier(a: float, b: float, c: float, d: float) =
            (property, TimingFunction.CubicBezier(a, b, c, d))
            |> Rule
        /// Define a specific step animation timing
        member this.step(steps: int) = (property, TimingFunction.Steps steps) |> Rule
        /// Define a specific step animation timing
        member this.step(steps: int, stepType: TimingFunction.Step) =
            (property, TimingFunction.StepsWithTerm(steps, stepType))
            |> Rule
