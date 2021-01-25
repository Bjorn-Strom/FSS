namespace Fss

[<RequireQualifiedAccess>]
module TimingFunctionType =
    type Step =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Start
        | End

    let stepsValue (value: Step) = Utilities.Helpers.duToKebab value

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
        let timingToString timing =
            match timing with
                | CubicBezier (p1, p2, p3, p4) -> sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" p1 p2 p3 p4
                | Steps n -> sprintf "steps(%d)" n
                | StepsWithTerm (n, term) -> sprintf "steps(%d, %s)" n (stepsValue term)
                | _ -> Utilities.Helpers.duToKebab timing

        match timing with
        | :? Timing as t -> timingToString t
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown timing function"

[<AutoOpen>]
module TimingFunction =
    let private timingToString timing = TimingFunctionType.timingToString timing
    type TimingFunction =
        interface ITransitionTimingFunction
        static member Ease = TimingFunctionType.Ease |> timingToString
        static member EaseIn = TimingFunctionType.EaseIn |> timingToString
        static member EaseOut = TimingFunctionType.EaseOut |> timingToString
        static member EaseInOut = TimingFunctionType.EaseInOut |> timingToString
        static member Linear = TimingFunctionType.Linear |> timingToString
        static member StepStart = TimingFunctionType.StepStart |> timingToString
        static member StepEnd = TimingFunctionType.StepEnd |> timingToString
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = TimingFunctionType.CubicBezier(p1,p2,p3,p4) |> timingToString
        static member Step (steps: int) = TimingFunctionType.Steps(steps) |> timingToString
        static member Step (steps: int, jumpTerm: TimingFunctionType.Step) = TimingFunctionType.StepsWithTerm(steps, jumpTerm) |> timingToString
        static member Inherit = Inherit |> timingToString
        static member Initial = Initial |> timingToString
        static member Unset =  Unset |> timingToString