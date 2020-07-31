namespace Fss

open Types
open Fss.Utilities.Helpers

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
module Animation =
    // Animation duration
    type Time =
        | Sec of string
        | Msec of string
        interface IAnimation
    
    let timeValue (v: Time) =
        match v with 
            | Sec s -> s
            | Msec ms -> ms

    let sec (v: float): Time = sprintf "%.2fs" v |> Sec
    let mSec (v: float): Time = sprintf "%.2fms" v |> Msec

    // Animation timing
    let cubicBezier (a: float, b: float, c: float, d: float) = 
        sprintf "cubic-bezier(%.1f, %.1f, %.1f, %.1f)" a b c d

    type Steps =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Start
        | End
        interface IAnimation

    let stepValue (v: Steps) = duToKebab v

    type Timing =
        | Ease
        | EaseIn
        | EaseOut
        | EaseInOut
        | Linear
        | StepStart
        | StepEnd
        | CubicBezier of (float * float * float * float)
        | Steps of int
        | Steps2 of int * Steps
        interface IAnimation

    let timingValue =
        function 
            | Ease -> "ease"
            | EaseIn -> "ease-in"
            | EaseOut -> "ease-out"
            | EaseInOut -> "ease-in-out"
            | Linear -> "linear"
            | StepStart -> "step-start"
            | StepEnd -> "step-end"
            | CubicBezier (a, b, c, d) -> cubicBezier(a, b, c, d)
            | Steps n -> sprintf "steps(%d)" n
            | Steps2 (n, direction) -> sprintf "steps(%d, %s)" n (stepValue direction)

    // Animation count
    type IterationCount =
        | Infinite
        | Value of int
        interface IAnimation

    let iterationCountValue =
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

    let directionValue (v: Direction): string = duToKebab v

    // Animation fill mode
    type FillMode =
        | Forwards
        | Backwards
        | Both
        | None
        interface IAnimation

    let fillModeValue (v: FillMode): string = duToString v

    // Animation play state
    type PlayState =
        | Running
        | Paused
        interface IAnimation

    let playStateValue (v: PlayState): string = duToString v

    let value (v: IAnimation): string =
        match v with
            | :? Time as t -> timeValue t
            | :? Timing as t -> timingValue t
            | :? IterationCount as i -> iterationCountValue i
            | :? Direction as d -> directionValue d
            | :? FillMode as f -> fillModeValue f
            | :? PlayState as p -> playStateValue p
            | _ as s -> string s