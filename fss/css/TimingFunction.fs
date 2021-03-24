namespace Fss

[<AutoOpen>]
module TimingFunction =
    let private timingToString timing = Fss.FssTypes.timingFunctionHelpers.timingToString timing
    type TimingFunction =
        interface FssTypes.ITransitionTimingFunction
        static member ease = FssTypes.TimingFunction.Ease |> timingToString
        static member easeIn = FssTypes.TimingFunction.EaseIn |> timingToString
        static member easeOut = FssTypes.TimingFunction.EaseOut |> timingToString
        static member easeInOut = FssTypes.TimingFunction.EaseInOut |> timingToString
        static member linear = FssTypes.TimingFunction.Linear |> timingToString
        static member stepStart = FssTypes.TimingFunction.StepStart |> timingToString
        static member stepEnd = FssTypes.TimingFunction.StepEnd |> timingToString
        static member cubicBezier (p1: float, p2:float, p3:float, p4:float) = FssTypes.TimingFunction.CubicBezier(p1,p2,p3,p4) |> timingToString
        static member step (steps: int) = FssTypes.TimingFunction.Steps(steps) |> timingToString
        static member step (steps: int, jumpTerm: FssTypes.TimingFunction.Step) = FssTypes.TimingFunction.StepsWithTerm(steps, jumpTerm) |> timingToString
        static member inherit' = FssTypes.Inherit |> timingToString
        static member initial = FssTypes.Initial |> timingToString
        static member unset =  FssTypes.Unset |> timingToString