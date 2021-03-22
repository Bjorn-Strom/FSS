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

    [<AutoOpen>]
    module timingFunctionHelpers =
        let internal stepsValue (value: TimingFunction.Step) = Fss.Utilities.Helpers.duToKebab value
        let timingToString (timing: ITransitionTimingFunction) =
            let timingToString timing =
                match timing with
                    | TimingFunction.CubicBezier (p1, p2, p3, p4) -> sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" p1 p2 p3 p4
                    | TimingFunction.Steps n -> sprintf "steps(%d)" n
                    | TimingFunction.StepsWithTerm (n, term) -> sprintf "steps(%d, %s)" n (stepsValue term)
                    | _ -> Fss.Utilities.Helpers.duToKebab timing

            match timing with
            | :? TimingFunction.Timing as t -> timingToString t
            | :? Keywords as k -> keywordsToString k
            | _ -> "Unknown timing function"
