namespace Fss

open FssTypes

[<AutoOpen>]
module TimingFunction =
    let private timingToString timing = TimingFunction.timingToString timing
    type TimingFunction =
        interface ITransitionTimingFunction
        static member Ease = TimingFunction.Ease |> timingToString
        static member EaseIn = TimingFunction.EaseIn |> timingToString
        static member EaseOut = TimingFunction.EaseOut |> timingToString
        static member EaseInOut = TimingFunction.EaseInOut |> timingToString
        static member Linear = TimingFunction.Linear |> timingToString
        static member StepStart = TimingFunction.StepStart |> timingToString
        static member StepEnd = TimingFunction.StepEnd |> timingToString
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingToString
        static member Step (steps: int) = TimingFunction.Steps(steps) |> timingToString
        static member Step (steps: int, jumpTerm: TimingFunction.Step) = TimingFunction.StepsWithTerm(steps, jumpTerm) |> timingToString
        static member Inherit = Inherit |> timingToString
        static member Initial = Initial |> timingToString
        static member Unset =  Unset |> timingToString