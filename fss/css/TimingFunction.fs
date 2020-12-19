namespace Fss

module TimingFunctionType =
    type Step =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Start
        | End

    let stepsValue (value: Step) =
        match value with
            | JumpStart -> "jump-start"
            | JumpEnd -> "jump-end"
            | JumpNone -> "jump-none"
            | JumpBoth -> "jump-both"
            | Start -> "start"
            | End -> "end"

    type Timing =
        | Ease
        | EaseIn
        | EaseOut
        | EaseInOut
        | Linear
        | StepStart
        | StepEnd
        | CubicBezier of float * float * float * float
        | Steps of int
        | StepsWithTerm of int * Step
        interface ITransitionTimingFunction

    let timingToString (timing: ITransitionTimingFunction) =
        let timingToString =
            function
                | Ease -> "ease"
                | EaseIn -> "ease-in"
                | EaseOut -> "ease-out"
                | EaseInOut -> "ease-in-out"
                | Linear -> "linear"
                | StepStart -> "step-start"
                | StepEnd -> "step-end"
                | CubicBezier (p1, p2, p3, p4) -> sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" p1 p2 p3 p4
                | Steps n -> sprintf "steps(%d)" n
                | StepsWithTerm (n, term) -> sprintf "steps(%d, %s)" n (stepsValue term)

        match timing with
        | :? Timing as t -> timingToString t
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown timing function"

[<AutoOpen>]
module TimingFunction =
    open TimingFunctionType

    type TimingFunction =
        interface ITransitionTimingFunction
        static member Ease = Ease |> timingToString
        static member EaseIn = EaseIn |> timingToString
        static member EaseOut = EaseOut |> timingToString
        static member EaseInOut = EaseInOut |> timingToString
        static member Linear = Linear |> timingToString
        static member StepStart = StepStart |> timingToString
        static member StepEnd = StepEnd |> timingToString
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = CubicBezier(p1,p2,p3,p4) |> timingToString
        static member Step (steps: int) = Steps(steps) |> timingToString
        static member Step (steps: int, jumpTerm: Step) = StepsWithTerm(steps, jumpTerm) |> timingToString
        static member Inherit = Inherit |> timingToString
        static member Initial = Initial |> timingToString
        static member Unset =  Unset |> timingToString