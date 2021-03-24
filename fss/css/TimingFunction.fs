namespace Fss

[<AutoOpen>]
module TimingFunction =
    let private timingToString timing = Fss.FssTypes.timingFunctionHelpers.timingToString timing
    type TimingFunction =
        interface FssTypes.ITransitionTimingFunction
        static member Ease = FssTypes.TimingFunction.Ease |> timingToString
        static member EaseIn = FssTypes.TimingFunction.EaseIn |> timingToString
        static member EaseOut = FssTypes.TimingFunction.EaseOut |> timingToString
        static member EaseInOut = FssTypes.TimingFunction.EaseInOut |> timingToString
        static member Linear = FssTypes.TimingFunction.Linear |> timingToString
        static member StepStart = FssTypes.TimingFunction.StepStart |> timingToString
        static member StepEnd = FssTypes.TimingFunction.StepEnd |> timingToString
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = FssTypes.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingToString
        static member Step (steps: int) = FssTypes.TimingFunction.Steps(steps) |> timingToString
        static member Step (steps: int, jumpTerm: FssTypes.TimingFunction.Step) = FssTypes.TimingFunction.StepsWithTerm(steps, jumpTerm) |> timingToString
        static member Inherit = FssTypes.Inherit |> timingToString
        static member Initial = FssTypes.Initial |> timingToString
        static member Unset =  FssTypes.Unset |> timingToString