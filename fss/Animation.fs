namespace Fss

open Types
open Fss.Utilities.Helpers

module Time =
    type Time =
        | Sec of string
        | Ms of string
        interface IAnimation

    let value (v: Time) =
        match v with 
            | Sec s -> s
            | Ms ms -> ms

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
module Animation =
    // Animation timing
    let private cubicBezier (a: float, b: float, c: float, d: float) = 
        sprintf "cubic-bezier(%.1f, %.1f, %.1f, %.1f)" a b c d

    type Steps =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Start
        | End
        interface IAnimation

    let private stepValue (v: Steps) = duToKebab v

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

    let private timingValue =
        function 
            | Ease -> "ease"
            | EaseIn -> "ease-in"
            | EaseOut -> "ease-out"
            | EaseInOut -> "ease-in-out"
            | Linear -> "linear"
            | StepStart -> "step-start"
            | StepEnd -> "step-end"
            | CubicBezier (a, b, c, d) -> cubicBezier(a, b, c, d)
            | Step n -> sprintf "steps(%d)" n
            | Steps (n, direction) -> sprintf "steps(%d, %s)" n (stepValue direction)

    // Animation count
    type IterationCount =
        | Infinite
        | Value of int
        interface IAnimation

    let private iterationCountValue =
        function
            | Infinite -> "infinite"
            | Value v -> string v

    // Animation Direction
    type Direction =
        | Normal
        | Reverse
        | Alternate
        | AlternateReverse
        interface IAnimation

    let private directionValue (v: Direction): string = duToKebab v

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

    let private playStateValue (v: PlayState): string = duToString v

    let value (v: IAnimation): string =
        match v with
            | :? Time.Time as t -> Time.value t
            | :? Timing as t -> timingValue t
            | :? IterationCount as i -> iterationCountValue i
            | :? Direction as d -> directionValue d
            | :? FillMode as f -> fillModeValue f
            | :? PlayState as p -> playStateValue p
            | _ as s -> string s