namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Transition =
    let transitionDurations: FssTypes.ITransitionDuration list = [sec 10.0; ms 100.0; FssTypes.Initial; FssTypes.Inherit]
    let transitionDelays: FssTypes.ITransitionDelay list = [sec 10.0; ms 100.0; FssTypes.Initial; FssTypes.Unset]

    let tests =
        testList "Transition"
            [
                test
                    "Transition inherit"
                    [Transition.inherit']
                    ["transition" ==> "inherit"]
                test
                    "Transition initial"
                    [ Transition.initial ]
                    ["transition" ==> "initial" ]
                test
                    "Transition unset"
                    [Transition.unset]
                    ["transition" ==> "unset"]
                test
                    "Transition duration sec"
                    [TransitionDuration' (sec 6.0) ]
                    ["transitionDuration" ==> "6.00s"]
                test
                    "Transition duration ms"
                    [ TransitionDuration' (ms 120.0) ]
                    [ "transitionDuration" ==> "120.00ms" ]
                test
                    "Transition duration value unset"
                    [TransitionDuration' FssTypes.Unset ]
                    ["transitionDuration" ==> "unset"]
                test
                    "Transition duration inherit"
                    [TransitionDuration.inherit']
                    ["transitionDuration" ==> "inherit"]
                test
                    "Transition duration initial"
                    [ TransitionDuration.initial ]
                    ["transitionDuration" ==> "initial" ]
                test
                    "Transition duration unset"
                    [TransitionDuration.unset]
                    ["transitionDuration" ==> "unset"]
                test
                    "Transition duration multiple"
                    [TransitionDuration.value transitionDurations ]
                    ["transitionDuration" ==> "10.00s, 100.00ms, initial, inherit"]
                test
                    "Transition delay sec"
                    [TransitionDelay' (sec 6.0) ]
                    ["transitionDelay" ==> "6.00s"]
                test
                    "Transition delay ms"
                    [ TransitionDelay' (ms 120.0) ]
                    [ "transitionDelay" ==> "120.00ms" ]
                test
                    "Transition delay inherit"
                    [TransitionDelay.inherit']
                    ["transitionDelay" ==> "inherit"]
                test
                    "Transition delay initial"
                    [ TransitionDelay.initial ]
                    ["transitionDelay" ==> "initial" ]
                test
                    "Transition delay unset"
                    [ TransitionDelay.unset]
                    ["transitionDelay" ==> "unset"]
                test
                    "Transition delay multiple"
                    [TransitionDelay.value transitionDelays ]
                    ["transitionDelay" ==> "10.00s, 100.00ms, initial, unset"]
                test
                    "Transition property"
                    [TransitionProperty.backgroundColor]
                    ["transitionProperty" ==> "background-color"]
                test
                    "Transition property"
                    [TransitionProperty.all]
                    ["transitionProperty" ==> "all"]
                test
                    "Transition property inherit"
                    [TransitionProperty.inherit']
                    ["transitionProperty" ==> "inherit"]
                test
                    "Transition property initial"
                    [ TransitionProperty.initial ]
                    ["transitionProperty" ==> "initial" ]
                test
                    "Transition property unset"
                    [ TransitionProperty.unset]
                    ["transitionProperty" ==> "unset"]
                test
                    "Transition properties"
                    [TransitionProperty.values [FssTypes.Property.BackgroundColor; FssTypes.Property.Color ] ]
                    ["transitionProperty" ==> "background-color, color"]
                test
                    "Transition timing function ease"
                    [ TransitionTimingFunction.ease ]
                    ["transitionTimingFunction" ==> "ease"]
                test
                    "Transition timing function ease in"
                    [ TransitionTimingFunction.easeIn ]
                    ["transitionTimingFunction" ==> "ease-in"]
                test
                    "Transition timinunction ease out"
                    [ TransitionTimingFunction.easeOut ]
                    ["transitionTimingFunction" ==> "ease-out"]
                test
                    "Transition timing function ease in out"
                    [ TransitionTimingFunction.easeInOut ]
                    ["transitionTimingFunction" ==> "ease-in-out"]
                test
                    "Transition timing function linear"
                    [ TransitionTimingFunction.linear ]
                    ["transitionTimingFunction" ==> "linear"]
                test
                    "Transition timing function step start"
                    [ TransitionTimingFunction.stepStart ]
                    ["transitionTimingFunction" ==> "step-start"]
                test
                    "Transition timing function step end"
                    [ TransitionTimingFunction.stepEnd ]
                    ["transitionTimingFunction" ==> "step-end"]
                test
                    "Transition timing function cubic bezier"
                    [ TransitionTimingFunction.cubicBezier(0.0, 0.47, 0.32, 1.97) ]
                    ["transitionTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                test
                    "Transition timing function  step"
                    [ TransitionTimingFunction.step 5 ]
                    ["transitionTimingFunction" ==> "steps(5)"]
                test
                    "Transition timing function  step jump start"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpStart) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-start)"]
                test
                    "Transition timing function step jump end"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpEnd) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-end)"]
                test
                    "Transition timing function step jump none"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpNone) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-none)"]
                test
                    "Transition timing function step jump both"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.JumpBoth) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-both)"]
                test
                    "Transition timing function step start"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.Step.Start) ]
                    ["transitionTimingFunction" ==> "steps(5, start)"]
                test
                    "Transition timing function step end"
                    [ TransitionTimingFunction.step(5, FssTypes.TimingFunction.Step.End) ]
                    ["transitionTimingFunction" ==> "steps(5, end)"]
                test
                    "Transition timing function inherit"
                    [ TransitionTimingFunction.inherit' ]
                    ["transitionTimingFunction" ==> "inherit"]
                test
                    "Transition timing function initial"
                    [ TransitionTimingFunction.initial ]
                    ["transitionTimingFunction" ==> "initial"]
                test
                    "Transition timing function unset"
                    [ TransitionTimingFunction.unset ]
                    ["transitionTimingFunction" ==> "unset"]
            ]