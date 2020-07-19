namespace Fss

module Time =
    // Animation duration
    type Time =
        | S of string
        | Ms of string
    
    let value (v: Time) =
        match v with 
            | S s -> s
            | Ms ms -> ms

    let s (v: float): Time = sprintf "%.2fs" v |> S
    let ms (v: float): Time = sprintf "%.2fms" v |> S

// https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations/Using_CSS_animations
module Animation =
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

    // Animation count
    type Infinite = | Infinite

    // Animation Direction
    type Direction =
        | Normal
        | Reverse
        | Alternate
        | AlternateReverse

    // Animation fill mode
    type FillMode =
        | Forwards
        | Backwards
        | Both
        | None

    // Animation play state
    type PlayState =
        | Running
        | Paused

    type AnimationValue =
        | Timing of Timing
        | Infinite
        | Direction of Direction
        | FillMode of FillMode
        | PlayState of PlayState

    let value (v: AnimationValue): string =
        match v with
            | Timing (Ease) -> "ease"
            | Timing (EaseIn) -> "ease-in"
            | Timing (EaseOut) -> "ease-out"
            | Timing (EaseInOut) -> "ease-in-out"
            | Timing (Linear) -> "linear"
            | Timing (StepStart) -> "step-start"
            | Timing (StepEnd) -> "step-end"
            | Timing (CubicBezier (a, b, c, d)) -> cubicBezier(a, b, c, d)
            
            | Timing (Steps (JumpStart)) -> "jump-start"
            | Timing (Steps (JumpEnd)) -> "jump-end"
            | Timing (Steps (JumpNone)) -> "jump-none"
            | Timing (Steps (JumpBoth)) -> "jump-both"
            | Timing (Steps (Start)) -> "start"
            | Timing (Steps (End)) -> "end"

            | Infinite -> "infinite"

            | Direction (Normal) -> "normal"
            | Direction (Reverse) -> "reverse"
            | Direction (Alternate) -> "alternate"
            | Direction (AlternateReverse) -> "alternate-reverse"

            | FillMode (Forwards) -> "forwards"
            | FillMode (Backwards) -> "backwards"
            | FillMode (Both) -> "both"
            | FillMode (None) -> "none"

            | PlayState (Running) -> "running"
            | PlayState (Paused) -> "paused"

    let animation = "animation"
    let animationName = "animation-name"
    let animationDuration = "animation-duration"
    let animationTimingFunction = "animation-timing-function"
    let animationDelay = "animation-delay"
    let animationIterationCount = "animation-iteration-count"
    let animationDirection = "animation-direction"
    let animationFillMode = "animation-fill-mode"
    let animationPlayState = "animation-play-state"