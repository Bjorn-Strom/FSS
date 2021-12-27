namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
[<RequireQualifiedAccess>]
module Animation =
    type Direction =
        | Normal
        | Reverse
        | Alternate
        | AlternateReverse
        interface ICssValue with
            member this.Stringify() =
                Fss.Utilities.Helpers.toKebabCase this

    type Step = TimingFunction.Step

    type FillMode =
        | Forwards
        | Backwards
        | Both
        interface ICssValue with
            member this.Stringify() =
                this.ToString().ToLower()
        
    type IterationCount =
        | Infinite
        interface ICssValue with
            member this.Stringify() = "infinite"
        
    type PlayState =
        | Running
        | Paused
        interface ICssValue with
            member this.Stringify() =
                this.ToString().ToLower()
            
    [<RequireQualifiedAccess>]
    module AnimationClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-delay
        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-duration
        type internal TimeHelper =
            | Time of Time
            | Times of Time list
            interface ICssValue with
                member this.Stringify() =
                    match this with
                    | Time t -> stringifyICssValue t
                    | Times ts ->
                        List.map stringifyICssValue ts
                        |> String.concat ", "

        type AnimationTime(property) =
            inherit CssRule(property)
            member this.value(delay: Time) = (property, delay |> Time) |> Rule
            member this.value(delays: Time list) = (property, delays |> Times) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
        type internal DirectionHelper =
            | Direction of Direction
            | Directions of Direction list
            interface ICssValue with
                member this.Stringify() =
                    this.ToString().ToLower()

        type AnimationDirection(property) =
            inherit CssRule(property)

            member this.value(direction: Direction) =
                (property, direction |> Direction) |> Rule

            member this.value(direction: Direction list) =
                (property, direction |> Directions) |> Rule

            member this.normal = (property, Normal) |> Rule
            member this.reverse = (property, Reverse) |> Rule
            member this.alternate = (property, Alternate) |> Rule
            member this.alternateReverse = (property, AlternateReverse) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-fill-mode
        type internal FillModeHelper =
            | FillMode of FillMode
            | FillModes of FillMode list
            interface ICssValue with
                member this.Stringify() =
                    this.ToString().ToLower()

        type AnimationFillMode(property) =
            inherit CssRuleWithNone(property)

            member this.value(fillMode: FillMode) =
                (property, fillMode |> FillMode) |> Rule

            member this.value(fillMode: FillMode list) =
                (property, fillMode |> FillModes) |> Rule

            member this.forwards = (property, Forwards) |> Rule
            member this.backwards = (property, Backwards) |> Rule
            member this.both = (property, Both) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-iteration-count
        type AnimationIterationCount(property) =
            inherit CssRule(property)

            member this.value(iterationCount: float) =
                (property, iterationCount |> Float) |> Rule

            member this.infinite = (property, Infinite) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-name
        type internal NameHelper =
            | Name of string
            | Names of string list
            interface ICssValue with
                member this.Stringify() =
                    match this with
                    | Name n -> n
                    | Names ns -> String.concat ", " ns

        type AnimationName(property) =
            inherit CssRule(property)
            member this.value(name: string) = (property, name |> Name) |> Rule
            member this.value(names: string list) = (property, names |> Names) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state
        type internal PlayStateHelper =
            | State of PlayState
            | States of PlayState list
            interface ICssValue with
                member this.Stringify() =
                    this.ToString().ToLower()

        type AnimationPlayState(property) =
            inherit CssRule(property)
            member this.value(playState: PlayState) = (property, playState |> State) |> Rule
            member this.value(playState: PlayState list) = (property, playState |> States) |> Rule
            member this.running = (property, Running) |> Rule
            member this.paused = (property, Paused) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-timing-function
        type internal TimingFunctionHelper =
            | Timing of TimingFunction.Timing
            | Timings of TimingFunction.Timing list
            interface ICssValue with
                member this.Stringify() =
                    this.ToString().ToLower()

        type AnimationTimingFunction(property) =
            inherit CssRule(property)

            member this.value(timingFunction: TimingFunction.Timing) =
                (property, timingFunction |> Timing) |> Rule

            member this.value(timingFunction: TimingFunction.Timing list) =
                (property, timingFunction |> Timings) |> Rule

            member this.ease = (property, TimingFunction.Ease) |> Rule

            member this.easeIn =
                (property, TimingFunction.EaseIn) |> Rule

            member this.easeOut =
                (property, TimingFunction.EaseOut) |> Rule

            member this.easeInOut =
                (property, TimingFunction.EaseInOut) |> Rule

            member this.linear =
                (property, TimingFunction.Linear) |> Rule

            member this.stepStart =
                (property, TimingFunction.StepStart) |> Rule

            member this.stepEnd =
                (property, TimingFunction.StepEnd) |> Rule

            member this.cubicBezier(a: float, b: float, c: float, d: float) =
                (property, TimingFunction.CubicBezier(a, b, c, d))
                |> Rule

            member this.step(steps: int) =
                (property, TimingFunction.Steps steps) |> Rule

            member this.step(steps: int, stepType: TimingFunction.Step) =
                (property, TimingFunction.StepsWithTerm(steps, stepType))
                |> Rule
