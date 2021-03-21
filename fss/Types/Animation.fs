namespace Fss

namespace Fss.Types
    // https://developer.mozilla.org/en-US/docs/Web/CSS/animation-direction
    type AnimationDirection =
        | Reverse
        | Alternate
        | AlternateReverse
        interface IAnimationDirection
    type AnimationFillMode =
        | Forwards
        | Backwards
        | Both
        interface IAnimationFillMode

    type IterationCount =
        | Infinite
        interface IAnimationIterationCount

    type AnimationPlayState =
        | Running
        | Paused
        interface IAnimationPlayState

    [<AutoOpen>]
    module animationHelpers =
        let internal iterationCountToString (iterationCount: IAnimationIterationCount) =
            match iterationCount with
            | :? IterationCount as i -> "infinite"
            | :? CssInt as i -> IntToString i
            | _ -> "Unknown animation iteration count"