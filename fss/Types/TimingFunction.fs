namespace Fss
namespace Fss.Types
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
        let internal stepsValue (value: Step) = Fss.Utilities.Helpers.duToKebab value
        let internal timingToString (timing: ITransitionTimingFunction) =
            let timingToString timing =
                match timing with
                    | CubicBezier (p1, p2, p3, p4) -> sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" p1 p2 p3 p4
                    | Steps n -> sprintf "steps(%d)" n
                    | StepsWithTerm (n, term) -> sprintf "steps(%d, %s)" n (stepsValue term)
                    | _ -> Fss.Utilities.Helpers.duToKebab timing

            match timing with
            | :? Timing as t -> timingToString t
            | :? Keywords as g -> keywordsToString g
            | _ -> "Unknown timing function"
