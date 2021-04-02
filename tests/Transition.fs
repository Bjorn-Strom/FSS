namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Transition =
    let transitionDurations: FssTypes.ITransitionDuration list = [sec 10.0; ms 100.0; FssTypes.Initial; FssTypes.Inherit]
    let transitionDelays: FssTypes.ITransitionDelay list = [sec 10.0; ms 100.0; FssTypes.Initial; FssTypes.Unset]

    let tests =
        testList "Transition"
            [
                testCase
                    "Transition inherit"
                    [Transition.inherit']
                    ["transition" ==> "inherit"]
                testCase
                    "Transition initial"
                    [ Transition.initial ]
                    ["transition" ==> "initial" ]
                testCase
                    "Transition unset"
                    [Transition.unset]
                    ["transition" ==> "unset"]
                testCase
                    "Transition duration sec"
                    [TransitionDuration' (sec 6.0) ]
                    ["transitionDuration" ==> "6.00s"]
                testCase
                    "Transition duration ms"
                    [ TransitionDuration' (ms 120.0) ]
                    [ "transitionDuration" ==> "120.00ms" ]
                testCase
                    "Transition duration value unset"
                    [TransitionDuration' FssTypes.Unset ]
                    ["transitionDuration" ==> "unset"]
                testCase
                    "Transition duration inherit"
                    [TransitionDuration.inherit']
                    ["transitionDuration" ==> "inherit"]
                testCase
                    "Transition duration initial"
                    [ TransitionDuration.initial ]
                    ["transitionDuration" ==> "initial" ]
                testCase
                    "Transition duration unset"
                    [TransitionDuration.unset]
                    ["transitionDuration" ==> "unset"]
                testCase
                    "Transition duration multiple"
                    [TransitionDuration.value transitionDurations ]
                    ["transitionDuration" ==> "10.00s, 100.00ms, initial, inherit"]
                testCase
                    "Transition delay sec"
                    [TransitionDelay' (sec 6.0) ]
                    ["transitionDelay" ==> "6.00s"]
                testCase
                    "Transition delay ms"
                    [ TransitionDelay' (ms 120.0) ]
                    [ "transitionDelay" ==> "120.00ms" ]
                testCase
                    "Transition delay inherit"
                    [TransitionDelay.inherit']
                    ["transitionDelay" ==> "inherit"]
                testCase
                    "Transition delay initial"
                    [ TransitionDelay.initial ]
                    ["transitionDelay" ==> "initial" ]
                testCase
                    "Transition delay unset"
                    [ TransitionDelay.unset]
                    ["transitionDelay" ==> "unset"]
                testCase
                    "Transition delay multiple"
                    [TransitionDelay.value transitionDelays ]
                    ["transitionDelay" ==> "10.00s, 100.00ms, initial, unset"]
                testCase
                    "Transition property"
                    [TransitionProperty.backgroundColor]
                    ["transitionProperty" ==> "background-color"]
                testCase
                    "Transition property"
                    [TransitionProperty.all]
                    ["transitionProperty" ==> "all"]
                testCase
                    "Transition property inherit"
                    [TransitionProperty.inherit']
                    ["transitionProperty" ==> "inherit"]
                testCase
                    "Transition property initial"
                    [ TransitionProperty.initial ]
                    ["transitionProperty" ==> "initial" ]
                testCase
                    "Transition property unset"
                    [ TransitionProperty.unset]
                    ["transitionProperty" ==> "unset"]
                testCase
                    "Transition properties"
                    [TransitionProperty.values [FssTypes.Property.BackgroundColor; FssTypes.Property.Color ] ]
                    ["transitionProperty" ==> "background-color, color"]
                testCase
                    "Transition timing function ease"
                    [ TransitionTimingFunction.ease ]
                    ["transitionTimingFunction" ==> "ease"]
                testCase
                    "Transition timing function ease in"
                    [ TransitionTimingFunction.easeIn ]
                    ["transitionTimingFunction" ==> "ease-in"]
                testCase
                    "Transition timinunction ease out"
                    [ TransitionTimingFunction.easeOut ]
                    ["transitionTimingFunction" ==> "ease-out"]
                testCase
                    "Transition timing function ease in out"
                    [ TransitionTimingFunction.easeInOut ]
                    ["transitionTimingFunction" ==> "ease-in-out"]
                testCase
                    "Transition timing function linear"
                    [ TransitionTimingFunction.linear ]
                    ["transitionTimingFunction" ==> "linear"]
                testCase
                    "Transition timing function step start"
                    [ TransitionTimingFunction.stepStart ]
                    ["transitionTimingFunction" ==> "step-start"]
                testCase
                    "Transition timing function step end"
                    [ TransitionTimingFunction.stepEnd ]
                    ["transitionTimingFunction" ==> "step-end"]
                testCase
                    "Transition timing function cubic bezier"
                    [ TransitionTimingFunction.cubicBezier(0.0, 0.47, 0.32, 1.97) ]
                    ["transitionTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                testCase
                    "Transition timing function  step"
                    [ TransitionTimingFunction.step 5 ]
                    ["transitionTimingFunction" ==> "steps(5)"]
                testCase
                    "Transition timing function  step jump start"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpStart) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-start)"]
                testCase
                    "Transition timing function step jump end"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpEnd) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-end)"]
                testCase
                    "Transition timing function step jump none"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpNone) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-none)"]
                testCase
                    "Transition timing function step jump both"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpBoth) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-both)"]
                testCase
                    "Transition timing function step start"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.Step.Start) ]
                    ["transitionTimingFunction" ==> "steps(5, start)"]
                testCase
                    "Transition timing function step end"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.Step.End) ]
                    ["transitionTimingFunction" ==> "steps(5, end)"]
                testCase
                    "Transition timing function inherit"
                    [ TransitionTimingFunction.inherit' ]
                    ["transitionTimingFunction" ==> "inherit"]
                testCase
                    "Transition timing function initial"
                    [ TransitionTimingFunction.initial ]
                    ["transitionTimingFunction" ==> "initial"]
                testCase
                    "Transition timing function unset"
                    [ TransitionTimingFunction.unset ]
                    ["transitionTimingFunction" ==> "unset"]
            ]