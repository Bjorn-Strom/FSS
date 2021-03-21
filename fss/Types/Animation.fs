namespace Fss

[<RequireQualifiedAccess>]
module Types =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
    type AnimationDirection =
        | Reverse
        | Alternate
        | AlternateReverse
        interface Types.IAnimationDirection
    type AnimationFillMode =
        | Forwards
        | Backwards
        | Both
        interface Types.IAnimationFillMode

    type IterationCount =
        | Infinite
        interface Types.IAnimationIterationCount

    type AnimationPlayState =
        | Running
        | Paused
        interface Types.IAnimationPlayState

    let internal iterationCountToString (iterationCount: Types.IAnimationIterationCount) =
        match iterationCount with
        | :? IterationCount as i -> "infinite"
        | :? Types.Int as i -> Types.IntToString i
        | _ -> "Unknown animation iteration count"