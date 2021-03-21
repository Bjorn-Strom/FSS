namespace Fss

[<AutoOpen>]
module TimingFunction =
    let private timingToString timing = Fss.Types.timingFunctionHelpers.timingToString timing
    type TimingFunction =
        interface Types.ITransitionTimingFunction
        static member Ease = Types.Ease |> timingToString
        static member EaseIn = Types.EaseIn |> timingToString
        static member EaseOut = Types.EaseOut |> timingToString
        static member EaseInOut = Types.EaseInOut |> timingToString
        static member Linear = Types.Linear |> timingToString
        static member StepStart = Types.StepStart |> timingToString
        static member StepEnd = Types.StepEnd |> timingToString
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = Types.CubicBezier(p1,p2,p3,p4) |> timingToString
        static member Step (steps: int) = Types.Steps(steps) |> timingToString
        static member Step (steps: int, jumpTerm: Types.Step) = Types.StepsWithTerm(steps, jumpTerm) |> timingToString
        static member Inherit = Types.Inherit |> timingToString
        static member Initial = Types.Initial |> timingToString
        static member Unset =  Types.Unset |> timingToString