namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Step =
        | JumpStart
        | JumpEnd
        | JumpNone
        | JumpBoth
        | Stat
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
        interface Types.ITransitionTimingFunction

    let stepsValue (value: Step) = Fss.Utilities.Helpers.duToKebab value
    let timingToString (timing: Types.ITransitionTimingFunction) =
        let timingToString timing =
            match timing with
                | CubicBezier (p1, p2, p3, p4) -> sprintf "cubic-bezier(%.2f, %.2f, %.2f, %.2f)" p1 p2 p3 p4
                | Steps n -> sprintf "steps(%d)" n
                | StepsWithTerm (n, term) -> sprintf "steps(%d, %s)" n (stepsValue term)
                | _ -> Fss.Utilities.Helpers.duToKebab timing

        match timing with
        | :? Timing as t -> timingToString t
        | :? Types.Keywords as g -> Types.keywordsToString g
        | _ -> "Unknown timing function"
