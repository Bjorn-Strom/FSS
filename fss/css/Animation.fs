namespace Fss

open Types
open Global
open Fss.Utilities.Helpers

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
module Animation =
    // Animation timing
    type Steps =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Start
        | End

    type Timing =
        | Ease
        | EaseIn
        | EaseOut
        | EaseInOut
        | Linear
        | StepStart
        | StepEnd
        | CubicBezier of (float * float * float * float)
        | Step of int
        | Steps of int * Steps
        interface IAnimationTimingFunction
        interface ITimingFunction

    // Animation count
    type IterationCount =
        | Infinite
        | Value of int

    // Animation Direction
    type Direction =
        | Reverse
        | Alternate
        | AlternateReverse
        interface IAnimationDirection

    // Animation fill mode
    type FillMode =
        | Forwards
        | Backwards
        | Both
        | None
        interface IAnimationFillMode

    // Animation play state
    type PlayState =
        | Running
        | Paused
        interface IAnimationPlayState

    type Animation =
        {
            Duration       : ITime
            TimingFunction : IAnimationTimingFunction
            Delay          : ITime
            IterationCount : IterationCount
            Direction      : IAnimationDirection
            FillMode       : IAnimationFillMode
            PlayState      : IAnimationPlayState
            Name           : IAnimationName
        }
        with interface IAnimation

    let duration (duration: ITime) animation =
        { animation with Duration = duration }

    let timingFunction (timingFunction: IAnimationTimingFunction) animation =
        { animation with TimingFunction = timingFunction }

    let delay (delay: ITime) animation =
        { animation with Delay = delay }

    let iterationCount (count: IterationCount) animation =
        { animation with IterationCount = count }

    let direction (direction: IAnimationDirection) animation =
        { animation with Direction = direction }

    let fillMode (fillMode: IAnimationFillMode) animation =
        { animation with FillMode = fillMode }

    let playState (playState: IAnimationPlayState) animation =
        { animation with PlayState = playState }

    let name (name: IAnimationName) animation =
        { animation with Name = name }

module AnimationValue =
    open Animation

    let private cubicBezier (a: float, b: float, c: float, d: float) =
        sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" a b c d

    let timingFunction (v: IAnimationTimingFunction): string =
        let stringifyTiming (timing: Timing): string =
            match timing with
                | CubicBezier (a, b, c, d) -> cubicBezier(a, b, c, d)
                | Step n -> sprintf "steps(%d)" n
                | Steps (n, direction) -> sprintf "steps(%d, %s)" n (duToKebab direction)
                | _ -> duToKebab timing

        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Timing as t -> stringifyTiming t
            | _              -> "Unknown animation timing function"

    let iterationCount (v: IterationCount): string =
        match v with
            | Infinite -> "infinite"
            | Value v -> string v

    let direction (v: IAnimationDirection): string =
        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? Normal  as n -> GlobalValue.normal n
            | :? Direction as d -> duToKebab d
            | _              -> "Unknown animation direction"

    let fillMode (v: IAnimationFillMode): string =
        match v with
            | :? None     as n -> GlobalValue.none n
            | :? FillMode as f -> duToLowercase f
            | _ -> "Unknown animation fill mode"

    let playState (v: IAnimationPlayState): string =
        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? PlayState as p -> duToLowercase p
            | _ -> "Unknown play state"

    let name (v: IAnimationName): string =
        match v with
            | :? Global as g  -> GlobalValue.globalValue g
            | :? None   as n  -> GlobalValue.none n
            | _         as s -> string s

    let animation (v: IAnimation): string =
        let stringifyAnimation (a: Animation): string =
            sprintf "%s %s %s %s %s %s %s %s"
                (Units.Time.value a.Duration)
                (timingFunction a.TimingFunction)
                (Units.Time.value a.Delay)
                (iterationCount a.IterationCount)
                (direction a.Direction)
                (fillMode a.FillMode)
                (playState a.PlayState)
                (name a.Name)

        match v with
            | :? Animation as a -> stringifyAnimation a
            | _ -> "Unknown animation value"