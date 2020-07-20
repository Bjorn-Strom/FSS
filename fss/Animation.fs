namespace Fss

open Utilities.Types

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
    let mSec (v: float): Time = sprintf "%.2fms" v |> Sec

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

    type Timing =
        | Ease
        | EaseIn
        | EaseOut
        | EaseInOut
        | Linear
        | StepStart
        | StepEnd
        | CubicBezier of (float * float * float * float)
        | Steps of Steps
        interface IAnimation
        interface ICSSProperty


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
            | _ -> "Unknown timing"

    // Animation count
    type IterationCount =
        | Infinite
        | Value of int
        interface IAnimation

    let count v = v |> Value

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

    let directionValue =
        function
            | Normal -> "normal"
            | Reverse -> "reverse"
            | Alternate -> "alternate"
            | AlternateReverse -> "alternate-reverse"

    // Animation fill mode
    type FillMode =
        | Forwards
        | Backwards
        | Both
        | None
        interface IAnimation

    let fillModeValue =
        function
            | Forwards -> "forwards"
            | Backwards -> "backwards"
            | Both -> "both"
            | None -> "none"


    // Animation play state
    type PlayState =
        | Running
        | Paused
        interface IAnimation

    let playStateValue =
        function
            | Running -> "running"
            | Paused -> "paused"

    let value (v: IAnimation): string =
        match v with
            | :? Time as t -> timeValue t
            | :? Timing as t -> timingValue t
            | :? IterationCount as i -> iterationCountValue i
            | :? Direction as d -> directionValue d
            | :? FillMode as f -> fillModeValue f
            | :? PlayState as p -> playStateValue p
            | _ as s -> string s

    let animation = "animation"
    let animationName = "animation-name"
    let animationDuration = "animation-duration"
    let animationTimingFunction = "animation-timing-function"
    let animationDelay = "animation-delay"
    let animationIterationCount = "animation-iteration-count"
    let animationDirection = "animation-direction"
    let animationFillMode = "animation-fill-mode"
    let animationPlayState = "animation-play-state"