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
                    [ AnimationName.names [animationSample; FssTypes.CssString "foo" ] ]
                    [ "animationName" ==> "animation-1oejj34, foo" ]
                test
                    "Animation name inherit"
                    [ AnimationName.inherit' ]
                    [ "animationName" ==> "inherit" ]
                test
                    "Animation name"
                    [ AnimationName.initial ]
                    [ "animationName" ==> "initial" ]
                test
                    "Animation name"
                    [ AnimationName.unset ]
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
                    [ AnimationTimingFunction.ease ]
                    ["animationTimingFunction" ==> "ease"]
                test
                    "Animation timing function ease in"
                    [ AnimationTimingFunction.easeIn ]
                    ["animationTimingFunction" ==> "ease-in"]
                test
                    "Animation timing function ease out"
                    [ AnimationTimingFunction.easeOut ]
                    ["animationTimingFunction" ==> "ease-out"]
                test
                    "Animation timing function ease in out"
                    [ AnimationTimingFunction.easeInOut ]
                    ["animationTimingFunction" ==> "ease-in-out"]
                test
                    "Animation timing function linear"
                    [ AnimationTimingFunction.linear ]
                    ["animationTimingFunction" ==> "linear"]
                test
                    "Animation timing function step start"
                    [ AnimationTimingFunction.stepStart ]
                    ["animationTimingFunction" ==> "step-start"]
                test
                    "Animation timing function step end"
                    [ AnimationTimingFunction.stepEnd ]
                    ["animationTimingFunction" ==> "step-end"]
                test
                    "Animation timing function cubic bezier"
                    [ AnimationTimingFunction.cubicBezier (0.0, 0.47, 0.32, 1.97) ]
                    ["animationTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                test
                    "Animation timing function  step"
                    [ AnimationTimingFunction.step 5 ]
                    ["animationTimingFunction" ==> "steps(5)"]
                test
                    "Animation timing function  step jump start"
                    [ AnimationTimingFunction.step(5, FssTypes.Animation.Step.JumpStart) ]
                    ["animationTimingFunction" ==> "steps(5, jump-start)"]
                test
                    "Animation timing function step jump end"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpEnd) ]
                    ["animationTimingFunction" ==> "steps(5, jump-end)"]
                test
                    "Animation timing function step jump none"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpNone) ]
                    ["animationTimingFunction" ==> "steps(5, jump-none)"]
                test
                    "Animation timing function step jump both"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpBoth) ]
                    ["animationTimingFunction" ==> "steps(5, jump-both)"]
                test
                    "Animation timing function step start"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.Start) ]
                    ["animationTimingFunction" ==> "steps(5, start)"]
                test
                    "Animation timing function step end"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.End) ]
                    ["animationTimingFunction" ==> "steps(5, end)"]
                test
                    "Animation timing function inherit"
                    [ AnimationTimingFunction.inherit' ]
                    ["animationTimingFunction" ==> "inherit"]
                test
                    "Animation timing function initial"
                    [ AnimationTimingFunction.initial ]
                    ["animationTimingFunction" ==> "initial"]
                test
                    "Animation timing function unset"
                    [ AnimationTimingFunction.unset ]
                    ["animationTimingFunction" ==> "unset"]
                test
                    "Animation delay sec"
                    [ AnimationDelay' (sec 10.0) ]
                    ["animationDelay" ==> "10.00s"]
                test
                    "Animation iteration count infininte"
                    [ AnimationIterationCount.infinite ]
                    ["animationIterationCount" ==> "infinite"]
                test
                    "Animation iteration count value"
                    [ AnimationIterationCount' (FssTypes.CssInt 5) ]
                    ["animationIterationCount" ==> "5"]
                test
                    "Animation direction normal"
                    [ AnimationDirection.normal ]
                    ["animationDirection" ==> "normal"]
                test
                    "Animation direction reverse"
                    [ AnimationDirection.reverse ]
                    ["animationDirection" ==> "reverse"]
                test
                    "Animation direction alternate"
                    [ AnimationDirection.alternate ]
                    ["animationDirection" ==> "alternate"]
                test
                    "Animation direction alternate reverse"
                    [ AnimationDirection.alternateReverse ]
                    ["animationDirection" ==> "alternate-reverse"]
                test
                    "Animation direction inherit"
                    [ AnimationDirection.inherit' ]
                    ["animationDirection" ==> "inherit"]
                test
                    "Animation direction initial"
                    [ AnimationDirection.initial ]
                    ["animationDirection" ==> "initial"]
                test
                    "Animation direction unset"
                    [ AnimationDirection.unset ]
                    ["animationDirection" ==> "unset"]
                test
                    "Animation fill mode forwards"
                    [ AnimationFillMode.forwards ]
                    ["animationFillMode" ==> "forwards"]
                test
                    "Animation fill mode backwards"
                    [ AnimationFillMode.backwards ]
                    ["animationFillMode" ==> "backwards"]
                test
                    "Animation fill mode both"
                    [ AnimationFillMode.both ]
                    ["animationFillMode" ==> "both"]
                test
                    "Animation fill mode none"
                    [ AnimationFillMode.none ]
                    ["animationFillMode" ==> "none"]
                test
                    "Animation play state running"
                    [ AnimationPlayState.running ]
                    ["animationPlayState" ==> "running"]
                test
                    "Animation play state paused"
                    [ AnimationPlayState.paused ]
                    ["animationPlayState"  ==> "paused"]
                test
                    "Animation play state inherit"
                    [ AnimationPlayState.inherit' ]
                    ["animationPlayState" ==> "inherit"]
                test
                    "Animation play state initial"
                    [ AnimationPlayState.initial ]
                    ["animationPlayState"  ==> "initial"]
                test
                    "Animation play state unset"
                    [ AnimationPlayState.unset ]
                    ["animationPlayState" ==> "unset"]
            ]