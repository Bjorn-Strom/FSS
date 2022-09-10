namespace Fss
namespace Fss.Types

[<RequireQualifiedAccess>]
module TimingFunction =
    type Step =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Start
        | End
        interface ICssValue with
            member this.StringifyCss() =
                match this with
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
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Ease -> "ease"
                | EaseIn -> "ease-in"
                | EaseOut -> "ease-out"
                | EaseInOut -> "ease-in-out"
                | Linear -> "linear"
                | StepStart -> "step-start"
                | StepEnd -> "step-end"
                | CubicBezier (p1, p2, p3, p4) -> sprintf "cubic-bezier(%.2f,%.2f,%.2f,%.2f)" p1 p2 p3 p4
                | Steps n -> sprintf "steps(%d)" n
                | StepsWithTerm (n, term) -> $"steps(%d{n},%s{stringifyICssValue term})"

[<RequireQualifiedAccess>]
module TimingFunctionClasses =
    type TimingFunction(property) =
        inherit CssRule(property)
        member this.ease = (property, TimingFunction.Ease) |> Rule

        member this.easeIn = (property, TimingFunction.EaseIn) |> Rule

        member this.easeOut = (property, TimingFunction.EaseOut) |> Rule

        member this.easeInOut = (property, TimingFunction.EaseInOut) |> Rule

        member this.linear = (property, TimingFunction.Linear) |> Rule

        member this.stepStart = (property, TimingFunction.StepStart) |> Rule

        member this.stepEnd = (property, TimingFunction.StepEnd) |> Rule

        member this.cubicBezier(p1: float, p2: float, p3: float, p4: float) =
            (property, TimingFunction.CubicBezier(p1, p2, p3, p4)) |> Rule

        member this.step(steps: int) = (property, TimingFunction.Steps(steps)) |> Rule

        member this.step(steps: int, jumpTerm: TimingFunction.Step) =
            (property, TimingFunction.StepsWithTerm(steps, jumpTerm)) |> Rule
