namespace Fss

open FssTypes

[<AutoOpen>]
module TimingFunction =
    let private timingToString timing = TimingFunction.timingToString timing
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