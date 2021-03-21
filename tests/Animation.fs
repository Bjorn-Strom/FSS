namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Animation =
    let tests =
        let animationSample =
            keyframes
                [
                    frame 0 [ BackgroundColor.red ]
                    frame 100 [ BackgroundColor.blue]
                ]

        testList "Animation"
            [
                test
                    "Animation name"
                    [ AnimationName' animationSample ]
                    [ "animationName" ==> "animation-1oejj34" ]
                test
                    "Animation names"
                    [ AnimationName.Names [animationSample; Types.CssString "foo" ] ]
                    [ "animationName" ==> "animation-1oejj34, foo" ]
                test
                    "Animation name inherit"
                    [ AnimationName.Inherit ]
                    [ "animationName" ==> "inherit" ]
                test
                    "Animation name"
                    [ AnimationName.Initial ]
                    [ "animationName" ==> "initial" ]
                test
                    "Animation name"
                    [ AnimationName.Unset ]
                    [ "animationName" ==> "unset" ]
                test
                    "Animation duration"
                    [ AnimationDuration' (sec 10.0) ]
                    [ "animationDuration" ==> "10.00s" ]
                test
                    "Animation duration seconds"
                    [ AnimationDuration' (sec 10.0) ]
                    [ "animationDuration" ==> "10.00s" ]
                test
                    "Animation duration milliseconds"
                    [ AnimationDuration' (ms 10.0) ]
                    [ "animationDuration" ==> "10.00ms" ]
                test
                    "Animation timing function ease"
                    [ AnimationTimingFunction.Ease ]
                    ["animationTimingFunction" ==> "ease"]
                test
                    "Animation timing function ease in"
                    [ AnimationTimingFunction.EaseIn ]
                    ["animationTimingFunction" ==> "ease-in"]
                test
                    "Animation timing function ease out"
                    [ AnimationTimingFunction.EaseOut ]
                    ["animationTimingFunction" ==> "ease-out"]
                test
                    "Animation timing function ease in out"
                    [ AnimationTimingFunction.EaseInOut ]
                    ["animationTimingFunction" ==> "ease-in-out"]
                test
                    "Animation timing function linear"
                    [ AnimationTimingFunction.Linear ]
                    ["animationTimingFunction" ==> "linear"]
                test
                    "Animation timing function step start"
                    [ AnimationTimingFunction.StepStart ]
                    ["animationTimingFunction" ==> "step-start"]
                test
                    "Animation timing function step end"
                    [ AnimationTimingFunction.StepEnd ]
                    ["animationTimingFunction" ==> "step-end"]
                test
                    "Animation timing function cubic bezier"
                    [ AnimationTimingFunction.CubicBezier (0.0, 0.47, 0.32, 1.97) ]
                    ["animationTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                test
                    "Animation timing function  step"
                    [ AnimationTimingFunction.Step 5 ]
                    ["animationTimingFunction" ==> "steps(5)"]
                test
                    "Animation timing function  step jump start"
                    [ AnimationTimingFunction.Step(5, Types.JumpStart) ]
                    ["animationTimingFunction" ==> "steps(5, jump-start)"]
                test
                    "Animation timing function step jump end"
                    [ AnimationTimingFunction.Step (5, Types.JumpEnd) ]
                    ["animationTimingFunction" ==> "steps(5, jump-end)"]
                test
                    "Animation timing function step jump none"
                    [ AnimationTimingFunction.Step (5, Types.JumpNone) ]
                    ["animationTimingFunction" ==> "steps(5, jump-none)"]
                test
                    "Animation timing function step jump both"
                    [ AnimationTimingFunction.Step (5, Types.JumpBoth) ]
                    ["animationTimingFunction" ==> "steps(5, jump-both)"]
                test
                    "Animation timing function step start"
                    [ AnimationTimingFunction.Step (5, Types.Step.Start) ]
                    ["animationTimingFunction" ==> "steps(5, start)"]
                test
                    "Animation timing function step end"
                    [ AnimationTimingFunction.Step (5, Types.Step.End) ]
                    ["animationTimingFunction" ==> "steps(5, end)"]
                test
                    "Animation timing function inherit"
                    [ AnimationTimingFunction.Inherit ]
                    ["animationTimingFunction" ==> "inherit"]
                test
                    "Animation timing function initial"
                    [ AnimationTimingFunction.Initial ]
                    ["animationTimingFunction" ==> "initial"]
                test
                    "Animation timing function unset"
                    [ AnimationTimingFunction.Unset ]
                    ["animationTimingFunction" ==> "unset"]
                test
                    "Animation delay sec"
                    [ AnimationDelay' (sec 10.0) ]
                    ["animationDelay" ==> "10.00s"]
                test
                    "Animation iteration count infininte"
                    [ AnimationIterationCount.Infinite ]
                    ["animationIterationCount" ==> "infinite"]
                test
                    "Animation iteration count value"
                    [ AnimationIterationCount' (Types.CssInt 5) ]
                    ["animationIterationCount" ==> "5"]
                test
                    "Animation direction normal"
                    [ AnimationDirection.Normal ]
                    ["animationDirection" ==> "normal"]
                test
                    "Animation direction reverse"
                    [ AnimationDirection.Reverse ]
                    ["animationDirection" ==> "reverse"]
                test
                    "Animation direction alternate"
                    [ AnimationDirection.Alternate ]
                    ["animationDirection" ==> "alternate"]
                test
                    "Animation direction alternate reverse"
                    [ AnimationDirection.AlternateReverse ]
                    ["animationDirection" ==> "alternate-reverse"]
                test
                    "Animation direction inherit"
                    [ AnimationDirection.Inherit ]
                    ["animationDirection" ==> "inherit"]
                test
                    "Animation direction initial"
                    [ AnimationDirection.Initial ]
                    ["animationDirection" ==> "initial"]
                test
                    "Animation direction unset"
                    [ AnimationDirection.Unset ]
                    ["animationDirection" ==> "unset"]
                test
                    "Animation fill mode forwards"
                    [ AnimationFillMode.Forwards ]
                    ["animationFillMode" ==> "forwards"]
                test
                    "Animation fill mode backwards"
                    [ AnimationFillMode.Backwards ]
                    ["animationFillMode" ==> "backwards"]
                test
                    "Animation fill mode both"
                    [ AnimationFillMode.Both ]
                    ["animationFillMode" ==> "both"]
                test
                    "Animation fill mode none"
                    [ AnimationFillMode.None ]
                    ["animationFillMode" ==> "none"]
                test
                    "Animation play state running"
                    [ AnimationPlayState.Running ]
                    ["animationPlayState" ==> "running"]
                test
                    "Animation play state paused"
                    [ AnimationPlayState.Paused ]
                    ["animationPlayState"  ==> "paused"]
                test
                    "Animation play state inherit"
                    [ AnimationPlayState.Inherit ]
                    ["animationPlayState" ==> "inherit"]
                test
                    "Animation play state initial"
                    [ AnimationPlayState.Initial ]
                    ["animationPlayState"  ==> "initial"]
                test
                    "Animation play state unset"
                    [ AnimationPlayState.Unset ]
                    ["animationPlayState" ==> "unset"]
            ]