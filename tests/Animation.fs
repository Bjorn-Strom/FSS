namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Animation =
    let tests =
        let animationSample = keyframes [ frame 0 [ BackgroundColor Color.red ]; frame 100 [ BackgroundColor Color.blue ] ]

        testList "Animation"
            [
                test
                    "Animation name"
                    [ AnimationName animationSample ]
                    [ "animationName" ==> animationSample ]

                test
                    "Animation name inherit"
                    [ AnimationName Inherit ]
                    [ "animationName" ==> "inherit" ]

                test
                    "Animation name"
                    [ AnimationName Initial ]
                    [ "animationName" ==> "initial" ]

                test
                    "Animation name"
                    [ AnimationName Unset ]
                    [ "animationName" ==> "unset" ]

                test
                    "Animation duration"
                    [ AnimationDuration (sec 10.0) ]
                    [ "animationDuration" ==> "10.00s" ]

                test
                    "Animation duration seconds"
                    [ AnimationDuration (sec 10.0) ]
                    [ "animationDuration" ==> "10.00s" ]

                test
                    "Animation duration milliseconds"
                    [ AnimationDuration (ms 10.0) ]
                    [ "animationDuration" ==> "10.00ms" ]

                test
                    "Animation duration multiple"
                    [ AnimationDurations [ sec 10.0; ms 500.0 ] ]
                    [ "animationDuration" ==> "10.00s, 500.00ms" ]

                test
                    "Animation timing function ease"
                    [ AnimationTimingFunction Animation.Ease ]
                    ["animationTimingFunction" ==> "ease"]

                test
                    "Animation timing function ease in"
                    [ AnimationTimingFunction Animation.EaseIn ]
                    ["animationTimingFunction" ==> "ease-in"]

                test
                    "Animation timing function ease out"
                    [ AnimationTimingFunction Animation.EaseOut ]
                    ["animationTimingFunction" ==> "ease-out"]

                test
                    "Animation timing function ease in out"
                    [ AnimationTimingFunction Animation.EaseInOut ]
                    ["animationTimingFunction" ==> "ease-in-out"]

                test
                    "Animation timing function linear"
                    [ AnimationTimingFunction Animation.Linear ]
                    ["animationTimingFunction" ==> "linear"]

                test
                    "Animation timing function step start"
                    [ AnimationTimingFunction Animation.StepStart ]
                    ["animationTimingFunction" ==> "step-start"]

                test
                    "Animation timing function step end"
                    [ AnimationTimingFunction Animation.StepEnd ]
                    ["animationTimingFunction" ==> "step-end"]

                test
                    "Animation timing function cubic bezier"
                    [ AnimationTimingFunction (Animation.CubicBezier(0.0, 0.47, 0.32, 1.97)) ]
                    ["animationTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]

                test
                    "Animation timing function  step"
                    [ AnimationTimingFunction (Animation.Step 5) ]
                    ["animationTimingFunction" ==> "steps(5)"]

                test
                    "Animation timing function  step jump start"
                    [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpStart)) ]
                    ["animationTimingFunction" ==> "steps(5, jump-start)"]

                test
                    "Animation timing function step jump end"
                    [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpEnd)) ]
                    ["animationTimingFunction" ==> "steps(5, jump-end)"]

                test
                    "Animation timing function step jump none"
                    [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpNone)) ]
                    ["animationTimingFunction" ==> "steps(5, jump-none)"]

                test
                    "Animation timing function step jump both"
                    [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpBoth)) ]
                    ["animationTimingFunction" ==> "steps(5, jump-both)"]

                test
                    "Animation timing function step start"
                    [ AnimationTimingFunction (Animation.Steps(5, Animation.Start)) ]
                    ["animationTimingFunction" ==> "steps(5, start)"]

                test
                    "Animation timing function step end"
                    [ AnimationTimingFunction (Animation.Steps(5, Animation.End)) ]
                    ["animationTimingFunction" ==> "steps(5, end)"]

                test
                    "Animation timing function inherit"
                    [ AnimationTimingFunction Inherit ]
                    ["animationTimingFunction" ==> "inherit"]

                test
                    "Animation timing function initial"
                    [ AnimationTimingFunction Initial ]
                    ["animationTimingFunction" ==> "initial"]

                test
                    "Animation timing function unset"
                    [ AnimationTimingFunction Unset ]
                    ["animationTimingFunction" ==> "unset"]

                test
                    "Animation delay sec"
                    [ AnimationDelay (sec 10.0) ]
                    ["animationDelay" ==> "10.00s"]
                test
                    "Animation delay multiple"
                    [ AnimationDelays [sec 10.0; ms 500.0] ]
                    ["animationDelay" ==> "10.00s, 500.00ms"]

                test
                    "Animation iteration count infininte"
                    [ AnimationIterationCount Animation.Infinite ]
                    ["animationIterationCount" ==> "infinite"]

                test
                    "Animation iteration count value"
                    [ AnimationIterationCount (Animation.Value 5) ]
                    ["animationIterationCount" ==> "5"]

                test
                    "Animation iteration count multiple"
                    [ AnimationIterationCounts [Animation.Infinite; Animation.Value 5] ]
                    ["animationIterationCount" ==> "infinite, 5"]

                test
                    "Animation direction normal"
                    [ AnimationDirection Animation.Normal ]
                    ["animationDirection" ==> "normal"]

                test
                    "Animation direction reverse"
                    [ AnimationDirection Animation.Reverse ]
                    ["animationDirection" ==> "reverse"]

                test
                    "Animation direction alternate"
                    [ AnimationDirection Animation.Alternate ]
                    ["animationDirection" ==> "alternate"]

                test
                    "Animation direction alternate reverse"
                    [ AnimationDirection Animation.AlternateReverse ]
                    ["animationDirection" ==> "alternate-reverse"]

                test
                    "Animation direction inherit"
                    [ AnimationDirection Inherit ]
                    ["animationDirection" ==> "inherit"]

                test
                    "Animation direction initial"
                    [ AnimationDirection Initial ]
                    ["animationDirection" ==> "initial"]

                test
                    "Animation direction unset"
                    [ AnimationDirection Unset ]
                    ["animationDirection" ==> "unset"]

                test
                    "Animation fill mode forwards"
                    [ AnimationFillMode Animation.Forwards ]
                    ["animationFillMode" ==> "forwards"]

                test
                    "Animation fill mode backwards"
                    [ AnimationFillMode Animation.Backwards ]
                    ["animationFillMode" ==> "backwards"]

                test
                    "Animation fill mode both"
                    [ AnimationFillMode Animation.Both ]
                    ["animationFillMode" ==> "both"]

                test
                    "Animation fill mode none"
                    [ AnimationFillMode None ]
                    ["animationFillMode" ==> "none"]

                test
                    "Animation fill mode multiple"
                    [ AnimationFillModes [ Animation.Forwards; Animation.Backwards ]]
                    ["animationFillMode" ==> "forwards, backwards"]

                test
                    "Animation play state running"
                    [ AnimationPlayState Animation.Running ]
                    ["animationPlayState" ==> "running"]

                test
                    "Animation play state paused"
                    [ AnimationPlayState Animation.Paused ]
                    ["animationPlayState"  ==> "paused"]

                test
                    "Animation play state"
                    [ AnimationPlayStates [ Animation.Running; Animation.Paused] ]
                    ["animationPlayState"==> "running, paused"]

                test
                    "Animation play state inherit"
                    [ AnimationPlayState Inherit ]
                    ["animationPlayState" ==> "inherit"]

                test
                    "Animation play state initial"
                    [ AnimationPlayState Initial ]
                    ["animationPlayState"  ==> "initial"]

                test
                    "Animation play state unset"
                    [ AnimationPlayState Unset ]
                    ["animationPlayState" ==> "unset"]

            ]