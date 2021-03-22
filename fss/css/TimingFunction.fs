namespace Fss

[<AutoOpen>]
module TimingFunction =
    let private timingToString timing = Fss.Types.timingFunctionHelpers.timingToString timing
    type TimingFunction =
        interface Types.ITransitionTimingFunction
        static member Ease = Types.TimingFunction.Ease |> timingToString
        static member EaseIn = Types.TimingFunction.EaseIn |> timingToString
        static member EaseOut = Types.TimingFunction.EaseOut |> timingToString
        static member EaseInOut = Types.TimingFunction.EaseInOut |> timingToString
        static member Linear = Types.TimingFunction.Linear |> timingToString
        static member StepStart = Types.TimingFunction.StepStart |> timingToString
        static member StepEnd = Types.TimingFunction.StepEnd |> timingToString
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = Types.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingToString
        static member Step (steps: int) = Types.TimingFunction.Steps(steps) |> timingToString
        static member Step (steps: int, jumpTerm: Types.TimingFunction.Step) = Types.TimingFunction.StepsWithTerm(steps, jumpTerm) |> timingToString
        static member Inherit = Types.Inherit |> timingToString
        static member Initial = Types.Initial |> timingToString
        static member Unset =  Types.Unset |> timingToString