namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Flex =
     let tests =
        testList "Flex"
            [
                testCase
                    "Flex direction row"
                    [ FlexDirection.row]
                    ["flexDirection" ==> "row"]
                testCase
                    "Flex direction row-reverse"
                    [ FlexDirection.rowReverse]
                    ["flexDirection" ==> "row-reverse"]
                testCase
                    "Flex direction column"
                    [ FlexDirection.column]
                    ["flexDirection" ==> "column"]
                testCase
                    "Flex direction column-reverse"
                    [ FlexDirection.columnReverse]
                    ["flexDirection" ==> "column-reverse"]
                testCase
                    "Flex direction inherit"
                    [ FlexDirection.inherit']
                    ["flexDirection" ==> "inherit"]
                testCase
                    "Flex direction initial"
                    [ FlexDirection.initial]
                    ["flexDirection" ==> "initial"]
                testCase
                    "Flex direction unset"
                    [ FlexDirection.unset]
                    ["flexDirection" ==> "unset"]
                testCase
                    "Flex wrap no-wrap"
                    [ FlexWrap.noWrap]
                    ["flexWrap" ==> "no-wrap"]
                testCase
                    "Flex wrap wrap"
                    [ FlexWrap.wrap]
                    ["flexWrap" ==> "wrap"]
                testCase
                    "Flex wrap wrap-reverse"
                    [ FlexWrap.wrapReverse]
                    ["flexWrap" ==> "wrap-reverse"]
                testCase
                    "Flex wrap inherit"
                    [ FlexWrap.inherit']
                    ["flexWrap" ==> "inherit"]
                testCase
                    "Flex wrap initial"
                    [ FlexWrap.initial]
                    ["flexWrap" ==> "initial"]
                testCase
                    "Flex wrap unset"
                    [ FlexWrap.unset]
                    ["flexWrap" ==> "unset"]
                testCase
                    "Flex basis em"
                    [ FlexBasis' (em 10.0)]
                    ["flexBasis" ==> "10.0em"]
                testCase
                    "Flex basis px"
                    [ FlexBasis' (px 100)]
                    ["flexBasis" ==> "100px"]
                testCase
                    "Flex basis auto"
                    [ FlexBasis.auto]
                    ["flexBasis" ==> "auto"]
                testCase
                    "Flex basis fill"
                    [ FlexBasis.fill ]
                    ["flexBasis" ==> "fill"]
                testCase
                    "Flex basis max-content"
                    [ FlexBasis.maxContent]
                    ["flexBasis" ==> "max-content"]
                testCase
                    "Flex basis min-content"
                    [ FlexBasis.minContent]
                    ["flexBasis" ==> "min-content"]
                testCase
                    "Flex basis fit-content"
                    [ FlexBasis.fitContent ]
                    ["flexBasis" ==> "fit-content"]
                testCase
                    "Flex basis content"
                    [ FlexBasis.content]
                    ["flexBasis" ==> "content"]
                testCase
                    "Justify content start"
                    [ JustifyContent.start]
                    ["justifyContent" ==> "start"]
                testCase
                    "Justify content end"
                    [ JustifyContent.end']
                    ["justifyContent" ==> "end"]
                testCase
                    "Justify content flex start"
                    [ JustifyContent.flexStart]
                    ["justifyContent" ==> "flex-start"]
                testCase
                    "Justify content flex end"
                    [ JustifyContent.flexEnd]
                    ["justifyContent" ==> "flex-end"]
                testCase
                    "Justify content center"
                    [ JustifyContent.center]
                    ["justifyContent" ==> "center"]
                testCase
                    "Justify content left"
                    [ JustifyContent.left]
                    ["justifyContent" ==> "left"]
                testCase
                    "Justify content right"
                    [ JustifyContent.right]
                    ["justifyContent" ==> "right"]
                testCase
                    "Justify content normal"
                    [ JustifyContent.normal]
                    ["justifyContent" ==> "normal"]
                testCase
                    "Justify content baseline"
                    [ JustifyContent.baseline]
                    ["justifyContent" ==> "baseline"]
                testCase
                    "Justify content space between"
                    [ JustifyContent.spaceBetween]
                    ["justifyContent" ==> "space-between"]
                testCase
                    "Justify content space around"
                    [ JustifyContent.spaceAround]
                    ["justifyContent" ==> "space-around"]
                testCase
                    "Justify content space evenly"
                    [ JustifyContent.spaceEvenly]
                    ["justifyContent" ==> "space-evenly"]
                testCase
                    "Justify content right"
                    [ JustifyContent.right]
                    ["justifyContent" ==> "right"]
                testCase
                    "Justify content safe"
                    [ JustifyContent.safe]
                    ["justifyContent" ==> "safe"]
                testCase
                    "Justify content unsafe"
                    [ JustifyContent.unsafe]
                    ["justifyContent" ==> "unsafe"]
                testCase
                    "Justify content inherit"
                    [ JustifyContent.inherit']
                    ["justifyContent" ==> "inherit"]
                testCase
                    "Justify content initial"
                    [ JustifyContent.initial]
                    ["justifyContent" ==> "initial"]
                testCase
                    "Justify content unset"
                    [ JustifyContent.unset]
                    ["justifyContent" ==> "unset"]
                testCase
                    "Justify self normal"
                    [ JustifySelf.normal ]
                    ["justifySelf" ==> "normal"]
                testCase
                    "Justify self flex start"
                    [ JustifySelf.selfStart]
                    ["justifySelf" ==> "self-start"]
                testCase
                    "Justify self flex end"
                    [ JustifySelf.selfEnd]
                    ["justifySelf" ==> "self-end"]
                testCase
                    "Justify self flex start"
                    [ JustifySelf.flexStart]
                    ["justifySelf" ==> "flex-start"]
                testCase
                    "Justify self flex end"
                    [ JustifySelf.flexEnd]
                    ["justifySelf" ==> "flex-end"]
                testCase
                    "Justify self center"
                    [ JustifySelf.center]
                    ["justifySelf" ==> "center"]
                testCase
                    "Justify self baseline"
                    [ JustifySelf.baseline]
                    ["justifySelf" ==> "baseline"]
                testCase
                    "Justify self stretch"
                    [ JustifySelf.stretch]
                    ["justifySelf" ==> "stretch"]
                testCase
                    "Justify self safe"
                    [ JustifySelf.safe]
                    ["justifySelf" ==> "safe"]
                testCase
                    "Justify self unsafe"
                    [ JustifySelf.unsafe]
                    ["justifySelf" ==> "unsafe"]
                testCase
                    "Justify self inherit"
                    [ JustifySelf.inherit']
                    ["justifySelf" ==> "inherit"]
                testCase
                    "Justify self initial"
                    [ JustifySelf.initial]
                    ["justifySelf" ==> "initial"]
                testCase
                    "Justify self unset"
                    [ JustifySelf.unset]
                    ["justifySelf" ==> "unset"]
                testCase
                    "Justify items start"
                    [ JustifyItems.start]
                    ["justifyItems" ==> "start"]
                testCase
                    "Justify items end"
                    [ JustifyItems.end']
                    ["justifyItems" ==> "end"]
                testCase
                    "Justify items flex start"
                    [ JustifyItems.flexStart]
                    ["justifyItems" ==> "flex-start"]
                testCase
                    "Justify items flex end"
                    [ JustifyItems.flexEnd]
                    ["justifyItems" ==> "flex-end"]
                testCase
                    "Justify items center"
                    [ JustifyItems.center]
                    ["justifyItems" ==> "center"]
                testCase
                    "Justify items normal"
                    [ JustifyItems.normal]
                    ["justifyItems" ==> "normal"]
                testCase
                    "Justify items baseline"
                    [ JustifyItems.baseline]
                    ["justifyItems" ==> "baseline"]
                testCase
                    "Justify items safe"
                    [ JustifyItems.safe]
                    ["justifyItems" ==> "safe"]
                testCase
                    "Justify items unsafe"
                    [ JustifyItems.unsafe]
                    ["justifyItems" ==> "unsafe"]
                testCase
                    "Justify items inherit"
                    [ JustifyItems.inherit']
                    ["justifyItems" ==> "inherit"]
                testCase
                    "Justify items initial"
                    [ JustifyItems.initial]
                    ["justifyItems" ==> "initial"]
                testCase
                    "Justify items unset"
                    [ JustifyItems.unset]
                    ["justifyItems" ==> "unset"]
                testCase
                    "Justify items legacy"
                    [ JustifyItems.legacy]
                    ["justifyItems" ==> "legacy"]
                testCase
                    "Align self normal"
                    [ AlignSelf.normal]
                    ["alignSelf" ==> "normal"]
                testCase
                    "Align self flex start"
                    [ AlignSelf.selfStart]
                    ["alignSelf" ==> "self-start"]
                testCase
                    "Align self flex end"
                    [ AlignSelf.selfEnd]
                    ["alignSelf" ==> "self-end"]
                testCase
                    "Align self flex start"
                    [ AlignSelf.flexStart]
                    ["alignSelf" ==> "flex-start"]
                testCase
                    "Align self flex end"
                    [ AlignSelf.flexEnd]
                    ["alignSelf" ==> "flex-end"]
                testCase
                    "Align self center"
                    [ AlignSelf.center]
                    ["alignSelf" ==> "center"]
                testCase
                    "Align self baseline"
                    [ AlignSelf.baseline]
                    ["alignSelf" ==> "baseline"]
                testCase
                    "Align self stretch"
                    [ AlignSelf.stretch]
                    ["alignSelf" ==> "stretch"]
                testCase
                    "Align self safe"
                    [ AlignSelf.safe]
                    ["alignSelf" ==> "safe"]
                testCase
                    "Align self unsafe"
                    [ AlignSelf.unsafe]
                    ["alignSelf" ==> "unsafe"]
                testCase
                    "Align self inherit"
                    [ AlignSelf.inherit']
                    ["alignSelf" ==> "inherit"]
                testCase
                    "Align self initial"
                    [ AlignSelf.initial]
                    ["alignSelf" ==> "initial"]
                testCase
                    "Align self unset"
                    [ AlignSelf.unset]
                    ["alignSelf" ==> "unset"]
                testCase
                    "Align items start"
                    [ AlignItems.start]
                    ["alignItems" ==> "start"]
                testCase
                    "Align items end"
                    [ AlignItems.end']
                    ["alignItems" ==> "end"]
                testCase
                    "Align items flex start"
                    [ AlignItems.flexStart]
                    ["alignItems" ==> "flex-start"]
                testCase
                    "Align items flex end"
                    [ AlignItems.flexEnd]
                    ["alignItems" ==> "flex-end"]
                testCase
                    "Align items center"
                    [ AlignItems.center]
                    ["alignItems" ==> "center"]
                testCase
                    "Align items normal"
                    [ AlignItems.normal]
                    ["alignItems" ==> "normal"]
                testCase
                    "Align items baseline"
                    [ AlignItems.baseline]
                    ["alignItems" ==> "baseline"]
                testCase
                    "Align items safe"
                    [ AlignItems.safe]
                    ["alignItems" ==> "safe"]
                testCase
                    "Align items unsafe"
                    [ AlignItems.unsafe]
                    ["alignItems" ==> "unsafe"]
                testCase
                    "Align items inherit"
                    [ AlignItems.inherit']
                    ["alignItems" ==> "inherit"]
                testCase
                    "Align items initial"
                    [ AlignItems.initial]
                    ["alignItems" ==> "initial"]
                testCase
                    "Align items unset"
                    [ AlignItems.unset]
                    ["alignItems" ==> "unset"]
                testCase
                    "Align content start"
                    [ AlignContent.start']
                    ["alignContent" ==> "start"]
                testCase
                    "Align content end"
                    [ AlignContent.end']
                    ["alignContent" ==> "end"]
                testCase
                    "Align content flex start"
                    [ AlignContent.flexStart]
                    ["alignContent" ==> "flex-start"]
                testCase
                    "Align content flex end"
                    [ AlignContent.flexEnd]
                    ["alignContent" ==> "flex-end"]
                testCase
                    "Align content center"
                    [ AlignContent.center]
                    ["alignContent" ==> "center"]
                testCase
                    "Align content normal"
                    [ AlignContent.normal]
                    ["alignContent" ==> "normal"]
                testCase
                    "Align content baseline"
                    [ AlignContent.baseline]
                    ["alignContent" ==> "baseline"]
                testCase
                    "Align content space between"
                    [ AlignContent.spaceBetween]
                    ["alignContent" ==> "space-between"]
                testCase
                    "Align content space around"
                    [ AlignContent.spaceAround]
                    ["alignContent" ==> "space-around"]
                testCase
                    "Align content space evenly"
                    [ AlignContent.spaceEvenly]
                    ["alignContent" ==> "space-evenly"]
                testCase
                    "Align content safe"
                    [ AlignContent.safe]
                    ["alignContent" ==> "safe"]
                testCase
                    "Align content unsafe"
                    [ AlignContent.unsafe]
                    ["alignContent" ==> "unsafe"]
                testCase
                    "Align content inherit"
                    [ AlignContent.inherit']
                    ["alignContent" ==> "inherit"]
                testCase
                    "Align content initial"
                    [ AlignContent.initial]
                    ["alignContent" ==> "initial"]
                testCase
                    "Align content unset"
                    [ AlignContent.unset]
                    ["alignContent" ==> "unset"]
                testCase
                    "Order value"
                    [ Order' (FssTypes.CssInt 1) ]
                    ["order" ==> "1"]
                testCase
                    "Order inherit"
                    [ Order.inherit']
                    ["order" ==> "inherit"]
                testCase
                    "Order initial"
                    [ Order.initial]
                    ["order" ==> "initial"]
                testCase
                    "Order unset"
                    [ Order.unset]
                    ["order" ==> "unset"]
                testCase
                    "Flex grow value"
                    [ FlexGrow' (FssTypes.CssFloat 1.5) ]
                    ["flexGrow" ==> "1.5"]
                testCase
                    "FlexGrow inherit"
                    [ FlexGrow.inherit']
                    ["flexGrow" ==> "inherit"]
                testCase
                    "FlexGrow initial"
                    [ FlexGrow.initial]
                    ["flexGrow" ==> "initial"]
                testCase
                    "FlexGrow unset"
                    [ FlexGrow.unset]
                    ["flexGrow" ==> "unset"]
                testCase
                    "FlexShrink value"
                    [ FlexShrink' (FssTypes.CssFloat 1.5) ]
                    ["flexShrink" ==> "1.5"]
                testCase
                    "FlexShrink inherit"
                    [ FlexShrink.inherit']
                    ["flexShrink" ==> "inherit"]
                testCase
                    "FlexShrink initial"
                    [ FlexShrink.initial]
                    ["flexShrink" ==> "initial"]
                testCase
                    "FlexShrink unset"
                    [ FlexShrink.unset]
                    ["flexShrink" ==> "unset"]
            ]