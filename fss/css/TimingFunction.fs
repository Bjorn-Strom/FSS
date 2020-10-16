namespace Fss

open Fss
open Fss.Types

module TimingFunction =
    // Animation timing
    type Steps =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Start
        | End

    type TimingFunction =
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
        interface ITimingFunction

module TimingFunctionValue =
    open TimingFunction
    open Utilities.Helpers
    open Global

    let private cubicBezier (a: float, b: float, c: float, d: float) =
        sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" a b c d

    let timingFunction (v: ITimingFunction): string =
        let stringifyTiming (timing: TimingFunction): string =
            match timing with
                | CubicBezier (a, b, c, d) -> cubicBezier(a, b, c, d)
                | Step n -> sprintf "steps(%d)" n
                | Steps (n, direction) -> sprintf "steps(%d, %s)" n (duToKebab direction)
                | _ -> duToKebab timing

        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? TimingFunction as t -> stringifyTiming t
            | _ -> "Unknown animation timing function"
