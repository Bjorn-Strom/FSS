namespace Fss
namespace Fss.FssTypes

open Fss.FssTypes

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.Stringify() =
                match this with
                | CubicBezier (p1, p2, p3, p4) -> sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" p1 p2 p3 p4
                | Steps n -> sprintf "steps(%d)" n
                | StepsWithTerm (n, term) -> $"steps(%d{n}, %s{(term :> ICssValue).Stringify()})"
                | _ -> Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module TimingFunctionClasses =
        type TimingFunction(property) =
            inherit CssRule(property)
            member this.ease = (property, Ease) |> Rule

            member this.easeIn = (property, EaseIn) |> Rule

            member this.easeOut = (property, EaseOut) |> Rule

            member this.easeInOut = (property, EaseInOut) |> Rule

            member this.linear = (property, Linear) |> Rule

            member this.stepStart = (property, StepStart) |> Rule

            member this.stepEnd = (property, StepEnd) |> Rule

            member this.cubicBezier(p1: float, p2: float, p3: float, p4: float) =
                (property, CubicBezier(p1, p2, p3, p4)) |> Rule

            member this.step(steps: int) = (property, Steps(steps)) |> Rule

            member this.step(steps: int, jumpTerm: Step) =
                (property, StepsWithTerm(steps, jumpTerm)) |> Rule
