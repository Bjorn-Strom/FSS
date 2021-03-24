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
                    [Transition.Inherit]
                    ["transition" ==> "inherit"]
                test
                    "Transition initial"
                    [ Transition.Initial ]
                    ["transition" ==> "initial" ]
                test
                    "Transition unset"
                    [Transition.Unset]
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
                    [TransitionDuration.Inherit]
                    ["transitionDuration" ==> "inherit"]
                test
                    "Transition duration initial"
                    [ TransitionDuration.Initial ]
                    ["transitionDuration" ==> "initial" ]
                test
                    "Transition duration unset"
                    [TransitionDuration.Unset]
                    ["transitionDuration" ==> "unset"]
                test
                    "Transition duration multiple"
                    [TransitionDuration.Value transitionDurations ]
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
                    [TransitionDelay.Inherit]
                    ["transitionDelay" ==> "inherit"]
                test
                    "Transition delay initial"
                    [ TransitionDelay.Initial ]
                    ["transitionDelay" ==> "initial" ]
                test
                    "Transition delay unset"
                    [ TransitionDelay.Unset]
                    ["transitionDelay" ==> "unset"]
                test
                    "Transition delay multiple"
                    [TransitionDelay.Value transitionDelays ]
                    ["transitionDelay" ==> "10.00s, 100.00ms, initial, unset"]
                test
                    "Transition property"
                    [TransitionProperty.BackgroundColor]
                    ["transitionProperty" ==> "background-color"]
                test
                    "Transition property"
                    [TransitionProperty.All]
                    ["transitionProperty" ==> "all"]
                test
                    "Transition property inherit"
                    [TransitionProperty.Inherit]
                    ["transitionProperty" ==> "inherit"]
                test
                    "Transition property initial"
                    [ TransitionProperty.Initial ]
                    ["transitionProperty" ==> "initial" ]
                test
                    "Transition property unset"
                    [ TransitionProperty.Unset]
                    ["transitionProperty" ==> "unset"]
                test
                    "Transition properties"
                    [TransitionProperty.Values [Types.Property.BackgroundColor; FssTypes.Property.Color ] ]
                    ["transitionProperty" ==> "background-color, color"]
                test
                    "Transition timing function ease"
                    [ TransitionTimingFunction.Ease ]
                    ["transitionTimingFunction" ==> "ease"]
                test
                    "Transition timing function ease in"
                    [ TransitionTimingFunction.EaseIn ]
                    ["transitionTimingFunction" ==> "ease-in"]
                test
                    "Transition timinunction ease out"
                    [ TransitionTimingFunction.EaseOut ]
                    ["transitionTimingFunction" ==> "ease-out"]
                test
                    "Transition timing function ease in out"
                    [ TransitionTimingFunction.EaseInOut ]
                    ["transitionTimingFunction" ==> "ease-in-out"]
                test
                    "Transition timing function linear"
                    [ TransitionTimingFunction.Linear ]
                    ["transitionTimingFunction" ==> "linear"]
                test
                    "Transition timing function step start"
                    [ TransitionTimingFunction.StepStart ]
                    ["transitionTimingFunction" ==> "step-start"]
                test
                    "Transition timing function step end"
                    [ TransitionTimingFunction.StepEnd ]
                    ["transitionTimingFunction" ==> "step-end"]
                test
                    "Transition timing function cubic bezier"
                    [ TransitionTimingFunction.CubicBezier(0.0, 0.47, 0.32, 1.97) ]
                    ["transitionTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                test
                    "Transition timing function  step"
                    [ TransitionTimingFunction.Step 5 ]
                    ["transitionTimingFunction" ==> "steps(5)"]
                test
                    "Transition timing function  step jump start"
                    [ TransitionTimingFunction.Step(5, FssTypes.TimingFunction.JumpStart) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-start)"]
                test
                    "Transition timing function step jump end"
                    [ TransitionTimingFunction.Step(5, FssTypes.TimingFunction.JumpEnd) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-end)"]
                test
                    "Transition timing function step jump none"
                    [ TransitionTimingFunction.Step(5, FssTypes.TimingFunction.JumpNone) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-none)"]
                test
                    "Transition timing function step jump both"
                    [ TransitionTimingFunction.Step(5, FssTypes.TimingFunction.JumpBoth) ]
                    ["transitionTimingFunction" ==> "steps(5, jump-both)"]
                test
                    "Transition timing function step start"
                    [ TransitionTimingFunction.Step(5, FssTypes.TimingFunction.Step.Start) ]
                    ["transitionTimingFunction" ==> "steps(5, start)"]
                test
                    "Transition timing function step end"
                    [ TransitionTimingFunction.Step(5, FssTypes.TimingFunction.Step.End) ]
                    ["transitionTimingFunction" ==> "steps(5, end)"]
                test
                    "Transition timing function inherit"
                    [ TransitionTimingFunction.Inherit ]
                    ["transitionTimingFunction" ==> "inherit"]
                test
                    "Transition timing function initial"
                    [ TransitionTimingFunction.Initial ]
                    ["transitionTimingFunction" ==> "initial"]
                test
                    "Transition timing function unset"
                    [ TransitionTimingFunction.Unset ]
                    ["transitionTimingFunction" ==> "unset"]
            ]