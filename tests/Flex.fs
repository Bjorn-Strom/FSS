namespace FSSTests

open Fet
open Utils
open Fss

module Flex =
     let tests =
        testList "Flex"
            [
                testCase
                    "Flex direction row"
                    [ FlexDirection.row]
                    "flex-direction: row;"
                testCase
                    "Flex direction row-reverse"
                    [ FlexDirection.rowReverse]
                    "flex-direction: row-reverse;"
                testCase
                    "Flex direction column"
                    [ FlexDirection.column]
                    "flex-direction: column;"
                testCase
                    "Flex direction column-reverse"
                    [ FlexDirection.columnReverse]
                    "flex-direction: column-reverse;"
                testCase
                    "Flex direction inherit"
                    [ FlexDirection.inherit']
                    "flex-direction: inherit;"
                testCase
                    "Flex direction initial"
                    [ FlexDirection.initial]
                    "flex-direction: initial;"
                testCase
                    "Flex direction unset"
                    [ FlexDirection.unset]
                    "flex-direction: unset;"
                testCase
                    "Flex direction revert"
                    [ FlexDirection.revert]
                    "flex-direction: revert;"
                testCase
                    "Flex wrap no-wrap"
                    [ FlexWrap.noWrap]
                    "flex-wrap: no-wrap;"
                testCase
                    "Flex wrap wrap"
                    [ FlexWrap.wrap]
                    "flex-wrap: wrap;"
                testCase
                    "Flex wrap wrap-reverse"
                    [ FlexWrap.wrapReverse]
                    "flex-wrap: wrap-reverse;"
                testCase
                    "Flex wrap inherit"
                    [ FlexWrap.inherit']
                    "flex-wrap: inherit;"
                testCase
                    "Flex wrap initial"
                    [ FlexWrap.initial]
                    "flex-wrap: initial;"
                testCase
                    "Flex wrap unset"
                    [ FlexWrap.unset]
                    "flex-wrap: unset;"
                testCase
                    "Flex wrap revert"
                    [ FlexWrap.revert]
                    "flex-wrap: revert;"
                testCase
                    "Flex basis em"
                    [ FlexBasis.value (em 10.0)]
                    "flex-basis: 10em;"
                testCase
                    "Flex basis px"
                    [ FlexBasis.value (px 100)]
                    "flex-basis: 100px;"
                testCase
                    "Flex basis auto"
                    [ FlexBasis.auto]
                    "flex-basis: auto;"
                testCase
                    "Flex basis fill"
                    [ FlexBasis.fill ]
                    "flex-basis: fill;"
                testCase
                    "Flex basis max-content"
                    [ FlexBasis.maxContent]
                    "flex-basis: max-content;"
                testCase
                    "Flex basis min-content"
                    [ FlexBasis.minContent]
                    "flex-basis: min-content;"
                testCase
                    "Flex basis fit-content"
                    [ FlexBasis.fitContent ]
                    "flex-basis: fit-content;"
                testCase
                    "Flex basis content"
                    [ FlexBasis.content]
                    "flex-basis: content;"
                testCase
                    "Flex basis inherit"
                    [ FlexBasis.inherit']
                    "flex-basis: inherit;"
                testCase
                    "Flex basis initial"
                    [ FlexBasis.initial]
                    "flex-basis: initial;"
                testCase
                    "Flex basis unset"
                    [ FlexBasis.unset]
                    "flex-basis: unset;"
                testCase
                    "Flex basis revert"
                    [ FlexBasis.revert]
                    "flex-basis: revert;"
                testCase
                    "Justify content start"
                    [ JustifyContent.start]
                    "justify-content: start;"
                testCase
                    "Justify content end"
                    [ JustifyContent.end']
                    "justify-content: end;"
                testCase
                    "Justify content flex start"
                    [ JustifyContent.flexStart]
                    "justify-content: flex-start;"
                testCase
                    "Justify content flex end"
                    [ JustifyContent.flexEnd]
                    "justify-content: flex-end;"
                testCase
                    "Justify content center"
                    [ JustifyContent.center]
                    "justify-content: center;"
                testCase
                    "Justify content left"
                    [ JustifyContent.left]
                    "justify-content: left;"
                testCase
                    "Justify content right"
                    [ JustifyContent.right]
                    "justify-content: right;"
                testCase
                    "Justify content normal"
                    [ JustifyContent.normal]
                    "justify-content: normal;"
                testCase
                    "Justify content baseline"
                    [ JustifyContent.baseline]
                    "justify-content: baseline;"
                testCase
                    "Justify content space between"
                    [ JustifyContent.spaceBetween]
                    "justify-content: space-between;"
                testCase
                    "Justify content space around"
                    [ JustifyContent.spaceAround]
                    "justify-content: space-around;"
                testCase
                    "Justify content space evenly"
                    [ JustifyContent.spaceEvenly]
                    "justify-content: space-evenly;"
                testCase
                    "Justify content right"
                    [ JustifyContent.right]
                    "justify-content: right;"
                testCase
                    "Justify content safe"
                    [ JustifyContent.safe]
                    "justify-content: safe;"
                testCase
                    "Justify content unsafe"
                    [ JustifyContent.unsafe]
                    "justify-content: unsafe;"
                testCase
                    "Justify content inherit"
                    [ JustifyContent.inherit']
                    "justify-content: inherit;"
                testCase
                    "Justify content initial"
                    [ JustifyContent.initial]
                    "justify-content: initial;"
                testCase
                    "Justify content unset"
                    [ JustifyContent.unset]
                    "justify-content: unset;"
                testCase
                    "Justify content revert"
                    [ JustifyContent.revert]
                    "justify-content: revert;"
                testCase
                    "Justify self normal"
                    [ JustifySelf.normal ]
                    "justify-self: normal;"
                testCase
                    "Justify self flex start"
                    [ JustifySelf.selfStart]
                    "justify-self: self-start;"
                testCase
                    "Justify self flex end"
                    [ JustifySelf.selfEnd]
                    "justify-self: self-end;"
                testCase
                    "Justify self flex start"
                    [ JustifySelf.flexStart]
                    "justify-self: flex-start;"
                testCase
                    "Justify self flex end"
                    [ JustifySelf.flexEnd]
                    "justify-self: flex-end;"
                testCase
                    "Justify self center"
                    [ JustifySelf.center]
                    "justify-self: center;"
                testCase
                    "Justify self baseline"
                    [ JustifySelf.baseline]
                    "justify-self: baseline;"
                testCase
                    "Justify self stretch"
                    [ JustifySelf.stretch]
                    "justify-self: stretch;"
                testCase
                    "Justify self safe"
                    [ JustifySelf.safe]
                    "justify-self: safe;"
                testCase
                    "Justify self unsafe"
                    [ JustifySelf.unsafe]
                    "justify-self: unsafe;"
                testCase
                    "Justify self inherit"
                    [ JustifySelf.inherit']
                    "justify-self: inherit;"
                testCase
                    "Justify self initial"
                    [ JustifySelf.initial]
                    "justify-self: initial;"
                testCase
                    "Justify self unset"
                    [ JustifySelf.unset]
                    "justify-self: unset;"
                testCase
                    "Justify items start"
                    [ JustifyItems.start]
                    "justify-items: start;"
                testCase
                    "Justify items end"
                    [ JustifyItems.end']
                    "justify-items: end;"
                testCase
                    "Justify items flex start"
                    [ JustifyItems.flexStart]
                    "justify-items: flex-start;"
                testCase
                    "Justify items flex end"
                    [ JustifyItems.flexEnd]
                    "justify-items: flex-end;"
                testCase
                    "Justify items center"
                    [ JustifyItems.center]
                    "justify-items: center;"
                testCase
                    "Justify items normal"
                    [ JustifyItems.normal]
                    "justify-items: normal;"
                testCase
                    "Justify items baseline"
                    [ JustifyItems.baseline]
                    "justify-items: baseline;"
                testCase
                    "Justify items safe"
                    [ JustifyItems.safe]
                    "justify-items: safe;"
                testCase
                    "Justify items unsafe"
                    [ JustifyItems.unsafe]
                    "justify-items: unsafe;"
                testCase
                    "Justify items inherit"
                    [ JustifyItems.inherit']
                    "justify-items: inherit;"
                testCase
                    "Justify items initial"
                    [ JustifyItems.initial]
                    "justify-items: initial;"
                testCase
                    "Justify items unset"
                    [ JustifyItems.unset]
                    "justify-items: unset;"
                testCase
                    "Justify items revert"
                    [ JustifyItems.revert]
                    "justify-items: revert;"
                testCase
                    "Justify items legacy"
                    [ JustifyItems.legacy]
                    "justify-items: legacy;"
                testCase
                    "Align self normal"
                    [ AlignSelf.normal]
                    "align-self: normal;"
                testCase
                    "Align self flex start"
                    [ AlignSelf.selfStart]
                    "align-self: self-start;"
                testCase
                    "Align self flex end"
                    [ AlignSelf.selfEnd]
                    "align-self: self-end;"
                testCase
                    "Align self flex start"
                    [ AlignSelf.flexStart]
                    "align-self: flex-start;"
                testCase
                    "Align self flex end"
                    [ AlignSelf.flexEnd]
                    "align-self: flex-end;"
                testCase
                    "Align self center"
                    [ AlignSelf.center]
                    "align-self: center;"
                testCase
                    "Align self baseline"
                    [ AlignSelf.baseline]
                    "align-self: baseline;"
                testCase
                    "Align self stretch"
                    [ AlignSelf.stretch]
                    "align-self: stretch;"
                testCase
                    "Align self safe"
                    [ AlignSelf.safe]
                    "align-self: safe;"
                testCase
                    "Align self unsafe"
                    [ AlignSelf.unsafe]
                    "align-self: unsafe;"
                testCase
                    "Align self inherit"
                    [ AlignSelf.inherit']
                    "align-self: inherit;"
                testCase
                    "Align self initial"
                    [ AlignSelf.initial]
                    "align-self: initial;"
                testCase
                    "Align self unset"
                    [ AlignSelf.unset]
                    "align-self: unset;"
                testCase
                    "Align self revert"
                    [ AlignSelf.revert]
                    "align-self: revert;"
                testCase
                    "Align items start"
                    [ AlignItems.start]
                    "align-items: start;"
                testCase
                    "Align items end"
                    [ AlignItems.end']
                    "align-items: end;"
                testCase
                    "Align items flex start"
                    [ AlignItems.flexStart]
                    "align-items: flex-start;"
                testCase
                    "Align items flex end"
                    [ AlignItems.flexEnd]
                    "align-items: flex-end;"
                testCase
                    "Align items center"
                    [ AlignItems.center]
                    "align-items: center;"
                testCase
                    "Align items normal"
                    [ AlignItems.normal]
                    "align-items: normal;"
                testCase
                    "Align items baseline"
                    [ AlignItems.baseline]
                    "align-items: baseline;"
                testCase
                    "Align items safe"
                    [ AlignItems.safe]
                    "align-items: safe;"
                testCase
                    "Align items unsafe"
                    [ AlignItems.unsafe]
                    "align-items: unsafe;"
                testCase
                    "Align items inherit"
                    [ AlignItems.inherit']
                    "align-items: inherit;"
                testCase
                    "Align items initial"
                    [ AlignItems.initial]
                    "align-items: initial;"
                testCase
                    "Align items unset"
                    [ AlignItems.unset]
                    "align-items: unset;"
                testCase
                    "Align items revert"
                    [ AlignItems.revert]
                    "align-items: revert;"
                testCase
                    "Align content start"
                    [ AlignContent.start]
                    "align-content: start;"
                testCase
                    "Align content end"
                    [ AlignContent.end']
                    "align-content: end;"
                testCase
                    "Align content flex start"
                    [ AlignContent.flexStart]
                    "align-content: flex-start;"
                testCase
                    "Align content flex end"
                    [ AlignContent.flexEnd]
                    "align-content: flex-end;"
                testCase
                    "Align content center"
                    [ AlignContent.center]
                    "align-content: center;"
                testCase
                    "Align content normal"
                    [ AlignContent.normal]
                    "align-content: normal;"
                testCase
                    "Align content baseline"
                    [ AlignContent.baseline]
                    "align-content: baseline;"
                testCase
                    "Align content space between"
                    [ AlignContent.spaceBetween]
                    "align-content: space-between;"
                testCase
                    "Align content space around"
                    [ AlignContent.spaceAround]
                    "align-content: space-around;"
                testCase
                    "Align content space evenly"
                    [ AlignContent.spaceEvenly]
                    "align-content: space-evenly;"
                testCase
                    "Align content safe"
                    [ AlignContent.safe]
                    "align-content: safe;"
                testCase
                    "Align content unsafe"
                    [ AlignContent.unsafe]
                    "align-content: unsafe;"
                testCase
                    "Align content inherit"
                    [ AlignContent.inherit']
                    "align-content: inherit;"
                testCase
                    "Align content initial"
                    [ AlignContent.initial]
                    "align-content: initial;"
                testCase
                    "Align content unset"
                    [ AlignContent.unset]
                    "align-content: unset;"
                testCase
                    "Order value"
                    [ Order.value 1 ]
                    "order: 1;"
                testCase
                    "Order inherit"
                    [ Order.inherit']
                    "order: inherit;"
                testCase
                    "Order initial"
                    [ Order.initial]
                    "order: initial;"
                testCase
                    "Order unset"
                    [ Order.unset]
                    "order: unset;"
                testCase
                    "Order revert"
                    [ Order.revert]
                    "order: revert;"
                testCase
                    "Flex grow value"
                    [ FlexGrow.value 1.5 ]
                    "flex-grow: 1.5;"
                testCase
                    "FlexGrow inherit"
                    [ FlexGrow.inherit']
                    "flex-grow: inherit;"
                testCase
                    "FlexGrow initial"
                    [ FlexGrow.initial]
                    "flex-grow: initial;"
                testCase
                    "FlexGrow unset"
                    [ FlexGrow.unset]
                    "flex-grow: unset;"
                testCase
                    "FlexShrink value"
                    [ FlexShrink.value 1.5 ]
                    "flex-shrink: 1.5;"
                testCase
                    "FlexShrink inherit"
                    [ FlexShrink.inherit']
                    "flex-shrink: inherit;"
                testCase
                    "FlexShrink initial"
                    [ FlexShrink.initial]
                    "flex-shrink: initial;"
                testCase
                    "FlexShrink unset"
                    [ FlexShrink.unset]
                    "flex-shrink: unset;"
            ]