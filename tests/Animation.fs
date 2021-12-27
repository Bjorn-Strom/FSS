namespace FSSTests

open Fet
open Utils
open Fss

module Animation =
    let tests =
        let name, _ =
            keyframes
                [
                    frame 0 [ MarginLeft.value (pct 0) ]
                    frame 50 [ MarginLeft.value (pct 50) ]
                    frames [ 80; 90 ] [ MarginLeft.value (pct 100) ]
                ]

        testList "Animation"
            [
                testCase
                    "Animation name"
                    [ AnimationName.value name ]
                    "animation-name: animation-1894110078;"
                testCase
                    "Animation names"
                    [ AnimationName.value [name; "foo" ] ]
                    "animation-name: animation-1894110078, foo;"
                testCase
                    "Animation name inherit"
                    [ AnimationName.inherit' ]
                    "animation-name: inherit;"
                testCase
                    "Animation name"
                    [ AnimationName.initial ]
                    "animation-name: initial;"
                testCase
                    "Animation name"
                    [ AnimationName.unset ]
                    "animation-name: unset;"
                testCase
                    "Animation duration sec"
                    [ AnimationDuration.value (sec 10) ]
                    "animation-duration: 10s;"
                testCase
                    "Animation duration m-sec"
                    [ AnimationDuration.value (ms 2000) ]
                    "animation-duration: 2000ms;"
                testCase
                    "Animation duration multiple"
                    [ AnimationDuration.value [sec 2.1; ms 480] ]
                    "animation-duration: 2.1s, 480ms;"
                testCase
                    "Animation duration inherit"
                    [ AnimationDuration.inherit' ]
                    "animation-duration: inherit;"
                testCase
                    "Animation duration initial"
                    [ AnimationDuration.initial ]
                    "animation-duration: initial;"
                testCase
                    "Animation duration unset"
                    [ AnimationDuration.unset ]
                    "animation-duration: unset;" 
                testCase
                    "Animation duration revert"
                    [ AnimationDuration.revert ]
                    "animation-duration: revert;" 
                testCase
                    "Animation timing function ease"
                    [ AnimationTimingFunction.ease ]
                    "animation-timing-function: ease;"
                testCase
                    "Animation timing function ease in"
                    [ AnimationTimingFunction.easeIn ]
                    "animation-timing-function: ease-in;"
                testCase
                    "Animation timing function ease out"
                    [ AnimationTimingFunction.easeOut ]
                    "animation-timing-function: ease-out;"
                testCase
                    "Animation timing function ease in out"
                    [ AnimationTimingFunction.easeInOut ]
                    "animation-timing-function: ease-in-out;"
                testCase
                    "Animation timing function linear"
                    [ AnimationTimingFunction.linear ]
                    "animation-timing-function: linear;"
                testCase
                    "Animation timing function step start"
                    [ AnimationTimingFunction.stepStart ]
                    "animation-timing-function: step-start;"
                testCase
                    "Animation timing function step end"
                    [ AnimationTimingFunction.stepEnd ]
                    "animation-timing-function: step-end;"
                testCase
                    "Animation timing function cubic bezier"
                    [ AnimationTimingFunction.cubicBezier (0.0, 0.47, 0.32, 1.97) ]
                    "animation-timing-function: cubic-bezier(0.00, 0.47, 0.32, 1.97);"
                testCase
                    "Animation timing function  step"
                    [ AnimationTimingFunction.step 5 ]
                    "animation-timing-function: steps(5);"
                testCase
                    "Animation timing function  step jump start"
                    [ AnimationTimingFunction.step(5, FssTypes.Animation.Step.JumpStart) ]
                    "animation-timing-function: steps(5, jump-start);"
                testCase
                    "Animation timing function step jump end"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpEnd) ]
                    "animation-timing-function: steps(5, jump-end);"
                testCase
                    "Animation timing function step jump none"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpNone) ]
                    "animation-timing-function: steps(5, jump-none);"
                testCase
                    "Animation timing function step jump both"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.JumpBoth) ]
                    "animation-timing-function: steps(5, jump-both);"
                testCase
                    "Animation timing function step start"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.Start) ]
                    "animation-timing-function: steps(5, start);"
                testCase
                    "Animation timing function step end"
                    [ AnimationTimingFunction.step (5, FssTypes.Animation.Step.End) ]
                    "animation-timing-function: steps(5, end);"
                testCase
                    "Animation timing function inherit"
                    [ AnimationTimingFunction.inherit' ]
                    "animation-timing-function: inherit;"
                testCase
                    "Animation timing function initial"
                    [ AnimationTimingFunction.initial ]
                    "animation-timing-function: initial;"
                testCase
                    "Animation timing function unset"
                    [ AnimationTimingFunction.unset ]
                    "animation-timing-function: unset;"
                testCase
                    "Animation delay sec"
                    [ AnimationDelay.value (sec 10) ]
                    "animation-delay: 10s;"
                testCase
                    "Animation delay m-sec"
                    [ AnimationDelay.value (ms 2000) ]
                    "animation-delay: 2000ms;"
                testCase
                    "Animation delay multiple"
                    [ AnimationDelay.value [sec 2.1; ms 480] ]
                    "animation-delay: 2.1s, 480ms;"
                testCase
                    "Animation delay inherit"
                    [ AnimationDelay.inherit' ]
                    "animation-delay: inherit;"
                testCase
                    "Animation delay initial"
                    [ AnimationDelay.initial ]
                    "animation-delay: initial;"
                testCase
                    "Animation delay unset"
                    [ AnimationDelay.unset ]
                    "animation-delay: unset;" 
                testCase
                    "Animation delay revert"
                    [ AnimationDelay.revert ]
                    "animation-delay: revert;" 
                testCase
                    "Animation iteration count infinite"
                    [ AnimationIterationCount.infinite ]
                    "animation-iteration-count: infinite;"
                testCase
                    "Animation iteration count value"
                    [ AnimationIterationCount.value 5 ]
                    "animation-iteration-count: 5;"
                testCase
                    "Animation iteration-count inherit"
                    [ AnimationIterationCount.inherit' ]
                    "animation-iteration-count: inherit;"
                testCase
                    "Animation iteration-count initial"
                    [ AnimationIterationCount.initial ]
                    "animation-iteration-count: initial;"
                testCase
                    "Animation iteration-count unset"
                    [ AnimationIterationCount.unset ]
                    "animation-iteration-count: unset;" 
                testCase
                    "Animation iteration-count revert"
                    [ AnimationIterationCount.revert ]
                    "animation-iteration-count: revert;" 
                testCase
                    "Animation direction normal"
                    [ AnimationDirection.normal ]
                    "animation-direction: normal;"
                testCase
                    "Animation direction reverse"
                    [ AnimationDirection.reverse ]
                    "animation-direction: reverse;"
                testCase
                    "Animation direction alternate"
                    [ AnimationDirection.alternate ]
                    "animation-direction: alternate;"
                testCase
                    "Animation direction alternate reverse"
                    [ AnimationDirection.alternateReverse ]
                    "animation-direction: alternate-reverse;"
                testCase
                    "Animation direction inherit"
                    [ AnimationDirection.inherit' ]
                    "animation-direction: inherit;"
                testCase
                    "Animation direction initial"
                    [ AnimationDirection.initial ]
                    "animation-direction: initial;"
                testCase
                    "Animation direction unset"
                    [ AnimationDirection.unset ]
                    "animation-direction: unset;"
                testCase
                    "Animation direction revert"
                    [ AnimationDirection.revert ]
                    "animation-direction: revert;"
                testCase
                    "Animation fill mode forwards"
                    [ AnimationFillMode.forwards ]
                    "animation-fill-mode: forwards;"
                testCase
                    "Animation fill mode backwards"
                    [ AnimationFillMode.backwards ]
                    "animation-fill-mode: backwards;"
                testCase
                    "Animation fill mode both"
                    [ AnimationFillMode.both ]
                    "animation-fill-mode: both;"
                testCase
                    "Animation fill mode none"
                    [ AnimationFillMode.none ]
                    "animation-fill-mode: none;"
                testCase
                    "Animation fill-mode inherit"
                    [ AnimationFillMode.inherit' ]
                    "animation-fill-mode: inherit;"
                testCase
                    "Animation fill-mode initial"
                    [ AnimationFillMode.initial ]
                    "animation-fill-mode: initial;"
                testCase
                    "Animation fill-mode unset"
                    [ AnimationFillMode.unset ]
                    "animation-fill-mode: unset;"
                testCase
                    "Animation fill-mode revert"
                    [ AnimationFillMode.revert ]
                    "animation-fill-mode: revert;"
                testCase
                    "Animation play state running"
                    [ AnimationPlayState.running ]
                    "animation-play-state: running;"
                testCase
                    "Animation play state paused"
                    [ AnimationPlayState.paused ]
                    "animation-play-state: paused;"
                testCase
                    "Animation play state inherit"
                    [ AnimationPlayState.inherit' ]
                    "animation-play-state: inherit;"
                testCase
                    "Animation play state initial"
                    [ AnimationPlayState.initial ]
                    "animation-play-state: initial;"
                testCase
                    "Animation play state unset"
                    [ AnimationPlayState.unset ]
                    "animation-play-state: unset;"
                testCase
                    "Animation play state revert"
                    [ AnimationPlayState.revert ]
                    "animation-play-state: revert;"
            ]