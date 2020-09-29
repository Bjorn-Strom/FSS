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
        interface IAnimation

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
        interface IAnimation

    // Animation count
    type IterationCount =
        | Infinite
        | Value of int
        interface IAnimation

    // Animation Direction
    type Direction =
        | Normal
        | Reverse
        | Alternate
        | AlternateReverse
        interface IAnimation
        interface IAnimationDirection

    // Animation fill mode
    type FillMode =
        | Forwards
        | Backwards
        | Both
        | None
        interface IAnimation

    let private fillModeValue (v: FillMode): string = duToString v

    // Animation play state
    type PlayState =
        | Running
        | Paused
        interface IAnimation
        interface IAnimationPlayState

module AnimationValue =
    open Animation

    let private cubicBezier (a: float, b: float, c: float, d: float) =
        sprintf "cubic-bezier(%.1f, %.1f, %.1f, %.1f)" a b c d

    let timing (v: Timing): string =
        match v with
            | Ease -> "ease"
            | EaseIn -> "ease-in"
            | EaseOut -> "ease-out"
            | EaseInOut -> "ease-in-out"
            | Linear -> "linear"
            | StepStart -> "step-start"
            | StepEnd -> "step-end"
            | CubicBezier (a, b, c, d) -> cubicBezier(a, b, c, d)
            | Step n -> sprintf "steps(%d)" n
            | Steps (n, direction) -> sprintf "steps(%d, %s)" n (duToKebab direction)

    let iterationCount (v: IterationCount): string =
        match v with
            | Infinite -> "infinite"
            | Value v -> string v

    let direction (v: IAnimationDirection): string =
        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? Direction as d -> duToKebab d
            | _              -> "Unknown animation direction"

    let fillMode (v: FillMode): string = duToString v

    let playState (v: IAnimationPlayState): string =
        match v with
            | :? Global as g    -> GlobalValue.globalValue g
            | :? PlayState as p -> duToString p
            | _ -> "Unknown play state"

    let name (v: IAnimationName): string =
        match v with
            | :? Global as g  -> GlobalValue.globalValue g
            | _         as s -> string s
