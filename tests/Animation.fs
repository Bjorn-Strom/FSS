namespace FSSTests

open Fet
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
                testCase
                    "Animation name"
                    [ AnimationName' animationSample ]
                    [ "animationName" ==> "animation-1oejj34" ]
                testCase
                    "Animation names"
                    [ AnimationName.names [animationSample; FssTypes.CssString "foo" ] ]
                    [ "animationName" ==> "animation-1oejj34, foo" ]
                testCase
                    "Animation name inherit"
                    [ AnimationName.inherit' ]
                    [ "animationName" ==> "inherit" ]
                testCase
                    "Animation name"
                    [ AnimationName.initial ]
                    [ "animationName" ==> "initial" ]
                testCase
                    "Animation name"
                    [ AnimationName.unset ]
                    [ "animationName" ==> "unset" ]
                testCase
                    "Animation duration"
                    [ AnimationDuration' (sec 10.0) ]
                    [ "animationDuration" ==> "10.00s" ]
                testCase
                    "Animation duration seconds"
                    [ AnimationDuration' (sec 10.0) ]
                    [ "animationDuration" ==> "10.00s" ]
                testCase
                    "Animation duration milliseconds"
                    [ AnimationDuration' (ms 10.0) ]
                    [ "animationDuration" ==> "10.00ms" ]
                testCase
                    "Animation timing function ease"
                    [ AnimationTimingFunction.ease ]
                    ["animationTimingFunction" ==> "ease"]
                testCase
                    "Animation timing function ease in"
                    [ AnimationTimingFunction.easeIn ]
                    ["animationTimingFunction" ==> "ease-in"]
                testCase
                    "Animation timing function ease out"
                    [ AnimationTimingFunction.easeOut ]
                    ["animationTimingFunction" ==> "ease-out"]
                testCase
                    "Animation timing function ease in out"
                    [ AnimationTimingFunction.easeInOut ]
                    ["animationTimingFunction" ==> "ease-in-out"]
                testCase
                    "Animation timing function linear"
                    [ AnimationTimingFunction.linear ]
                    ["animationTimingFunction" ==> "linear"]
                testCase
                    "Animation timing function step start"
                    [ AnimationTimingFunction.stepStart ]
                    ["animationTimingFunction" ==> "step-start"]
                testCase
                    "Animation timing function step end"
                    [ AnimationTimingFunction.stepEnd ]
                    ["animationTimingFunction" ==> "step-end"]
                testCase
                    "Animation timing function cubic bezier"
                    [ AnimationTimingFunction.cubicBezier (0.0, 0.47, 0.32, 1.97) ]
                    ["animationTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                testCase
                    "Animation timing function  step"
                    [ AnimationTimingFunction.step 5 ]
                    ["animationTimingFunction" ==> "steps(5)"]
                testCase
                    "Animation timing function  step jump start"
                    [ AnimationTimingFunction.step(5, FssTypes.Animation.Step.JumpStart) ]
                    ["animationTimingFunction" ==> "steps(5, jump-start)"]
                testCase
                    "Animation timing function step jump end"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpEnd) ]
                    ["animationTimingFunction" ==> "steps(5, jump-end)"]
                testCase
                    "Animation timing function step jump none"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpNone) ]
                    ["animationTimingFunction" ==> "steps(5, jump-none)"]
                testCase
                    "Animation timing function step jump both"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpBoth) ]
                    ["animationTimingFunction" ==> "steps(5, jump-both)"]
                testCase
                    "Animation timing function step start"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.Start) ]
                    ["animationTimingFunction" ==> "steps(5, start)"]
                testCase
                    "Animation timing function step end"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.End) ]
                    ["animationTimingFunction" ==> "steps(5, end)"]
                testCase
                    "Animation timing function inherit"
                    [ AnimationTimingFunction.inherit' ]
                    ["animationTimingFunction" ==> "inherit"]
                testCase
                    "Animation timing function initial"
                    [ AnimationTimingFunction.initial ]
                    ["animationTimingFunction" ==> "initial"]
                testCase
                    "Animation timing function unset"
                    [ AnimationTimingFunction.unset ]
                    ["animationTimingFunction" ==> "unset"]
                testCase
                    "Animation delay sec"
                    [ AnimationDelay' (sec 10.0) ]
                    ["animationDelay" ==> "10.00s"]
                testCase
                    "Animation iteration count infininte"
                    [ AnimationIterationCount.infinite ]
                    ["animationIterationCount" ==> "infinite"]
                testCase
                    "Animation iteration count value"
                    [ AnimationIterationCount' (FssTypes.CssInt 5) ]
                    ["animationIterationCount" ==> "5"]
                testCase
                    "Animation direction normal"
                    [ AnimationDirection.normal ]
                    ["animationDirection" ==> "normal"]
                testCase
                    "Animation direction reverse"
                    [ AnimationDirection.reverse ]
                    ["animationDirection" ==> "reverse"]
                testCase
                    "Animation direction alternate"
                    [ AnimationDirection.alternate ]
                    ["animationDirection" ==> "alternate"]
                testCase
                    "Animation direction alternate reverse"
                    [ AnimationDirection.alternateReverse ]
                    ["animationDirection" ==> "alternate-reverse"]
                testCase
                    "Animation direction inherit"
                    [ AnimationDirection.inherit' ]
                    ["animationDirection" ==> "inherit"]
                testCase
                    "Animation direction initial"
                    [ AnimationDirection.initial ]
                    ["animationDirection" ==> "initial"]
                testCase
                    "Animation direction unset"
                    [ AnimationDirection.unset ]
                    ["animationDirection" ==> "unset"]
                testCase
                    "Animation fill mode forwards"
                    [ AnimationFillMode.forwards ]
                    ["animationFillMode" ==> "forwards"]
                testCase
                    "Animation fill mode backwards"
                    [ AnimationFillMode.backwards ]
                    ["animationFillMode" ==> "backwards"]
                testCase
                    "Animation fill mode both"
                    [ AnimationFillMode.both ]
                    ["animationFillMode" ==> "both"]
                testCase
                    "Animation fill mode none"
                    [ AnimationFillMode.none ]
                    ["animationFillMode" ==> "none"]
                testCase
                    "Animation play state running"
                    [ AnimationPlayState.running ]
                    ["animationPlayState" ==> "running"]
                testCase
                    "Animation play state paused"
                    [ AnimationPlayState.paused ]
                    ["animationPlayState"  ==> "paused"]
                testCase
                    "Animation play state inherit"
                    [ AnimationPlayState.inherit' ]
                    ["animationPlayState" ==> "inherit"]
                testCase
                    "Animation play state initial"
                    [ AnimationPlayState.initial ]
                    ["animationPlayState"  ==> "initial"]
                testCase
                    "Animation play state unset"
                    [ AnimationPlayState.unset ]
                    ["animationPlayState" ==> "unset"]
            ]