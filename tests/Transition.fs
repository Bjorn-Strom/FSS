namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Transition =
    let tests =
        testList "Transition"
            [
                test
                    "Transition duration sec"
                    [TransitionDuration (sec 6.0) ]
                    ["transitionDuration" ==> "6.00s"]

                test
                    "Transition duration ms"
                    [ TransitionDuration (ms 120.0) ]
                    [ "transitionDuration" ==> "120.00ms" ]

                test
                    "Transition duration inherit"
                    [TransitionDuration Inherit]
                    ["transitionDuration" ==> "inherit"]

                test
                    "Transition duration initial"
                    [ TransitionDuration Initial ]
                    ["transitionDuration" ==> "initial" ]

                test
                    "Transition duration unset"
                    [TransitionDuration Unset]
                    ["transitionDuration" ==> "unset"]

                test
                    "Transition duration multiple"
                    [TransitionDurations [ sec 10.0; ms 100.0; Unset; Inherit] ]
                    ["transitionDuration" ==> "10.00s, 100.00ms, unset, inherit"]

                test
                    "Transition delay sec"
                    [TransitionDelay (sec 6.0) ]
                    ["transitionDelay" ==> "6.00s"]

                test
                    "Transition delay ms"
                    [ TransitionDelay (ms 120.0) ]
                    [ "transitionDelay" ==> "120.00ms" ]

                test
                    "Transition delay inherit"
                    [TransitionDelay Inherit]
                    ["transitionDelay" ==> "inherit"]

                test
                    "Transition delay initial"
                    [ TransitionDelay Initial ]
                    ["transitionDelay" ==> "initial" ]

                test
                    "Transition delay unset"
                    [ TransitionDelay Unset]
                    ["transitionDelay" ==> "unset"]

                test
                    "Transition delay multiple"
                    [TransitionDelays [ sec 10.0; ms 100.0; Unset; Inherit] ]
                    ["transitionDelay" ==> "10.00s, 100.00ms, unset, inherit"]

                test
                    "Transition property"
                    [TransitionProperty Property.BackgroundColor]
                    ["transitionProperty" ==> "background-color"]

                test
                    "Transition property"
                    [TransitionProperty Property.All]
                    ["transitionProperty" ==> "all"]

                test
                    "Transition property inherit"
                    [TransitionProperty Inherit]
                    ["transitionProperty" ==> "inherit"]

                test
                    "Transition property initial"
                    [ TransitionProperty Initial ]
                    ["transitionProperty" ==> "initial" ]

                test
                    "Transition property unset"
                    [ TransitionProperty Unset]
                    ["transitionProperty" ==> "unset"]

                test
                    "Transition properties"
                    [TransitionProperties [Inherit; Unset; Property.BackgroundColor; Property.Color]]
                    ["transitionProperty" ==> "inherit, unset, background-color, color"]

                test
                    "Transition timing function ease"
                    [ TransitionTimingFunction TimingFunction.Ease ]
                    ["transitionTimingFunction" ==> "ease"]

                test
                    "Transition timing function ease in"
                    [ TransitionTimingFunction TimingFunction.EaseIn ]
                    ["transitionTimingFunction" ==> "ease-in"]

                test
                    "Transition timinunction ease out"
                    [ TransitionTimingFunction TimingFunction.EaseOut ]
                    ["transitionTimingFunction" ==> "ease-out"]

                test
                    "Transition timing function ease in out"
                    [ TransitionTimingFunction TimingFunction.EaseInOut ]
                    ["transitionTimingFunction" ==> "ease-in-out"]

                test
                    "Transition timing function linear"
                    [ TransitionTimingFunction TimingFunction.Linear ]
                    ["transitionTimingFunction" ==> "linear"]

                test
                    "Transition timing function step start"
                    [ TransitionTimingFunction TimingFunction.StepStart ]
                    ["transitionTimingFunction" ==> "step-start"]

                test
                    "Transition timing function step end"
                    [ TransitionTimingFunction TimingFunction.StepEnd ]
                    ["transitionTimingFunction" ==> "step-end"]

                test
                    "Transition timing function cubic bezier"
                    [ TransitionTimingFunction (TimingFunction.CubicBezier(0.0, 0.47, 0.32, 1.97)) ]
                    ["transitionTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]

                test
                    "Transition timing function  step"
                    [ TransitionTimingFunction (TimingFunction.Step 5) ]
                    ["transitionTimingFunction" ==> "steps(5)"]

                test
                    "Transition timing function  step jump start"
                    [ TransitionTimingFunction (TimingFunction.Steps(5, TimingFunction.JumpStart)) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-start)"]

                test
                    "Transition timing function step jump end"
                    [ TransitionTimingFunction (TimingFunction.Steps(5, TimingFunction.JumpEnd)) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-end)"]

                test
                    "Transition timing function step jump none"
                    [ TransitionTimingFunction (TimingFunction.Steps(5, TimingFunction.JumpNone)) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-none)"]

                test
                    "Transition timing function step jump both"
                    [ TransitionTimingFunction (TimingFunction.Steps(5, TimingFunction.JumpBoth)) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-both)"]

                test
                    "Transition timing function step start"
                    [ TransitionTimingFunction (TimingFunction.Steps(5, TimingFunction.Start)) ]
                    ["transitionTimingFunction" ==> "steps(5, start)"]

                test
                    "Transition timing function step end"
                    [ TransitionTimingFunction (TimingFunction.Steps(5, TimingFunction.End)) ]
                    ["transitionTimingFunction" ==> "steps(5, end)"]

                test
                    "Transition timing function inherit"
                    [ TransitionTimingFunction Inherit ]
                    ["transitionTimingFunction" ==> "inherit"]

                test
                    "Transition timing function initial"
                    [ TransitionTimingFunction Initial ]
                    ["transitionTimingFunction" ==> "initial"]

                test
                    "Transition timing function unset"
                    [ TransitionTimingFunction Unset ]
                    ["transitionTimingFunction" ==> "unset"]
            ]