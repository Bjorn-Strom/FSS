namespace Fss

open Types
open Global
open Fss.Utilities.Helpers

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
module Animation =
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
            TimingFunction : ITimingFunction
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

    let timingFunction (timingFunction: ITimingFunction) animation =
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
                (TimingFunctionValue.timingFunction a.TimingFunction)
                (Units.Time.value a.Delay)
                (iterationCount a.IterationCount)
                (direction a.Direction)
                (fillMode a.FillMode)
                (playState a.PlayState)
                (name a.Name)

        match v with
            | :? Animation as a -> stringifyAnimation a
            | _ -> "Unknown animation value"