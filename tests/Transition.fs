namespace FSSTests

open Fet
open Utils
open Fss

module TransitionTests =
    let tests =
        testList "Transition"
            [
                testCase
                    "Transition inherit"
                    [Transition.inherit']
                    "{transition:inherit;}"
                testCase
                    "Transition initial"
                    [ Transition.initial ]
                    "{transition:initial;}";
                testCase
                    "Transition unset"
                    [Transition.unset]
                    "{transition:unset;}"
                testCase
                    "Transition revert"
                    [Transition.revert]
                    "{transition:revert;}"
                testCase
                    "Transition duration sec"
                    [TransitionDuration.value (sec 6.0) ]
                    "{transition-duration:6s;}"
                testCase
                    "Transition duration ms"
                    [ TransitionDuration.value (ms 120.0) ]
                     "{transition-duration:120ms;}";
                testCase
                    "Transition duration value unset"
                    [TransitionDuration.value Fss.Types.Unset ]
                    "{transition-duration:unset;}"
                testCase
                    "Transition duration inherit"
                    [TransitionDuration.inherit']
                    "{transition-duration:inherit;}"
                testCase
                    "Transition duration initial"
                    [ TransitionDuration.initial ]
                    "{transition-duration:initial;}";
                testCase
                    "Transition duration unset"
                    [TransitionDuration.unset]
                    "{transition-duration:unset;}"
                testCase
                    "Transition duration revert"
                    [TransitionDuration.revert]
                    "{transition-duration:revert;}"
                testCase
                    "Transition delay sec"
                    [TransitionDelay.value (sec 6.0) ]
                    "{transition-delay:6s;}"
                testCase
                    "Transition delay ms"
                    [ TransitionDelay.value (ms 120.0) ]
                     "{transition-delay:120ms;}";
                testCase
                    "Transition delay inherit"
                    [TransitionDelay.inherit']
                    "{transition-delay:inherit;}"
                testCase
                    "Transition delay initial"
                    [ TransitionDelay.initial ]
                    "{transition-delay:initial;}";
                testCase
                    "Transition delay unset"
                    [ TransitionDelay.unset]
                    "{transition-delay:unset;}"
                testCase
                    "Transition delay revert"
                    [ TransitionDelay.revert]
                    "{transition-delay:revert;}"
                testCase
                    "Transition property"
                    [TransitionProperty.backgroundColor]
                    "{transition-property:background-color;}"
                testCase
                    "Transition property"
                    [TransitionProperty.all]
                    "{transition-property:all;}"
                testCase
                    "Transition property inherit"
                    [TransitionProperty.inherit']
                    "{transition-property:inherit;}"
                testCase
                    "Transition property initial"
                    [ TransitionProperty.initial ]
                    "{transition-property:initial;}";
                testCase
                    "Transition property unset"
                    [ TransitionProperty.unset]
                    "{transition-property:unset;}"
                testCase
                    "Transition property revert"
                    [ TransitionProperty.revert]
                    "{transition-property:revert;}"
                testCase
                    "Transition timing function ease"
                    [ TransitionTimingFunction.ease ]
                    "{transition-timing-function:ease;}"
                testCase
                    "Transition timing function ease in"
                    [ TransitionTimingFunction.easeIn ]
                    "{transition-timing-function:ease-in;}"
                testCase
                    "Transition timinunction ease out"
                    [ TransitionTimingFunction.easeOut ]
                    "{transition-timing-function:ease-out;}"
                testCase
                    "Transition timing function ease in out"
                    [ TransitionTimingFunction.easeInOut ]
                    "{transition-timing-function:ease-in-out;}"
                testCase
                    "Transition timing function linear"
                    [ TransitionTimingFunction.linear ]
                    "{transition-timing-function:linear;}"
                testCase
                    "Transition timing function step start"
                    [ TransitionTimingFunction.stepStart ]
                    "{transition-timing-function:step-start;}"
                testCase
                    "Transition timing function step end"
                    [ TransitionTimingFunction.stepEnd ]
                    "{transition-timing-function:step-end;}"
                testCase
                    "Transition timing function cubic bezier"
                    [ TransitionTimingFunction.cubicBezier(0.0, 0.47, 0.32, 1.97) ]
                    "{transition-timing-function:cubic-bezier(0.00,0.47,0.32,1.97);}"
                testCase
                    "Transition timing function  step"
                    [ TransitionTimingFunction.step 5 ]
                    "{transition-timing-function:steps(5);}"
                testCase
                    "Transition timing function  step jump start"
                    [ TransitionTimingFunction.step(5, Fss.Types.TimingFunction.JumpStart) ]
                    "{transition-timing-function:steps(5,jump-start);}"
                testCase
                    "Transition timing function step jump end"
                    [ TransitionTimingFunction.step(5, Fss.Types.TimingFunction.JumpEnd) ]
                    "{transition-timing-function:steps(5,jump-end);}"
                testCase
                    "Transition timing function step jump none"
                    [ TransitionTimingFunction.step(5, Fss.Types.TimingFunction.JumpNone) ]
                    "{transition-timing-function:steps(5,jump-none);}"
                testCase
                    "Transition timing function step jump both"
                    [ TransitionTimingFunction.step(5, Fss.Types.TimingFunction.JumpBoth) ]
                    "{transition-timing-function:steps(5,jump-both);}"
                testCase
                    "Transition timing function step start"
                    [ TransitionTimingFunction.step(5, Fss.Types.TimingFunction.Step.Start) ]
                    "{transition-timing-function:steps(5,start);}"
                testCase
                    "Transition timing function step end"
                    [ TransitionTimingFunction.step(5, Fss.Types.TimingFunction.Step.End) ]
                    "{transition-timing-function:steps(5,end);}"
                testCase
                    "Transition timing function inherit"
                    [ TransitionTimingFunction.inherit' ]
                    "{transition-timing-function:inherit;}"
                testCase
                    "Transition timing function initial"
                    [ TransitionTimingFunction.initial ]
                    "{transition-timing-function:initial;}"
                testCase
                    "Transition timing function unset"
                    [ TransitionTimingFunction.unset ]
                    "{transition-timing-function:unset;}"
                testCase
                    "Transition timing function revert"
                    [ TransitionTimingFunction.revert ]
                    "{transition-timing-function:revert;}"
            ]
