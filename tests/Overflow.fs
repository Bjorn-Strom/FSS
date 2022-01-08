namespace FSSTests

open Fet
open Utils
open Fss

module OverflowTests =
    let tests =
        testList "Overflow"
            [
                testCase
                    "Overflow-X visible"
                    [OverflowX.visible]
                    "overflow-x: visible;"
                testCase
                    "Overflow-X hidden"
                    [OverflowX.hidden]
                    "overflow-x: hidden;"
                testCase
                    "Overflow-X Clip"
                    [OverflowX.clip]
                    "overflow-x: clip;"
                testCase
                    "Overflow-X Scroll"
                    [OverflowX.scroll]
                    "overflow-x: scroll;"
                testCase
                    "Overflow-X Auto"
                    [OverflowX.auto]
                    "overflow-x: auto;"
                testCase
                    "Overflow-X inherit"
                    [OverflowX.inherit']
                    "overflow-x: inherit;"
                testCase
                    "Overflow-X initial"
                    [OverflowX.initial]
                    "overflow-x: initial;"
                testCase
                    "Overflow-X unset"
                    [OverflowX.unset]
                    "overflow-x: unset;"
                testCase
                    "Overflow-X revert"
                    [OverflowX.revert]
                    "overflow-x: revert;"
                testCase
                    "OverflowY visible"
                    [OverflowY.visible]
                    "overflow-y: visible;"
                testCase
                    "OverflowY hidden"
                    [OverflowY.hidden]
                    "overflow-y: hidden;"
                testCase
                    "OverflowY Clip"
                    [OverflowY.clip]
                    "overflow-y: clip;"
                testCase
                    "OverflowY Scroll"
                    [OverflowY.scroll]
                    "overflow-y: scroll;"
                testCase
                    "OverflowY Auto"
                    [OverflowY.auto]
                    "overflow-y: auto;"
                testCase
                    "OverflowY inherit"
                    [OverflowY.inherit']
                    "overflow-y: inherit;"
                testCase
                    "OverflowY initial"
                    [OverflowY.initial]
                    "overflow-y: initial;"
                testCase
                    "OverflowY unset"
                    [OverflowY.unset]
                    "overflow-y: unset;"
                testCase
                    "OverflowY revert"
                    [OverflowY.revert]
                    "overflow-y: revert;"
                testCase
                    "Overflow visible visible"
                    [Overflow.value (Fss.Types.Overflow.Visible, Fss.Types.Overflow.Visible)]
                    "overflow: visible visible;"
                testCase
                    "OverflowXY hidden hidden"
                    [Overflow.value (Fss.Types.Overflow.Hidden, Fss.Types.Overflow.Hidden)]
                    "overflow: hidden hidden;"
                testCase
                    "Overflow Clip clip"
                    [Overflow.value (Fss.Types.Overflow.Clip, Fss.Types.Overflow.Clip)]
                    "overflow: clip clip;"
                testCase
                    "Overflow scroll Scroll"
                    [Overflow.value (Fss.Types.Overflow.Scroll, Fss.Types.Overflow.Scroll)]
                    "overflow: scroll scroll;"
                testCase
                    "OverflowWrap break-word"
                    [OverflowWrap.breakWord]
                    "overflow-wrap: break-word;"
                testCase
                    "OverflowWrap anywhere"
                    [OverflowWrap.anywhere]
                    "overflow-wrap: anywhere;"
                testCase
                    "OverflowWrap normal"
                    [OverflowWrap.normal]
                    "overflow-wrap: normal;"
                testCase
                    "OverflowWrap inherit"
                    [OverflowWrap.inherit']
                    "overflow-wrap: inherit;"
                testCase
                    "OverflowWrap initial"
                    [OverflowWrap.initial]
                    "overflow-wrap: initial;"
                testCase
                    "OverflowWrap unset"
                    [OverflowWrap.unset]
                    "overflow-wrap: unset;"
                testCase
                    "OverflowWrap revert"
                    [OverflowWrap.revert]
                    "overflow-wrap: revert;"
            ]