namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Flex =
     let tests =
        testList "Flex"
            [
                test
                    "Flex direction row"
                    [ FlexDirection.row]
                    ["flexDirection" ==> "row"]
                test
                    "Flex direction row-reverse"
                    [ FlexDirection.rowReverse]
                    ["flexDirection" ==> "row-reverse"]
                test
                    "Flex direction column"
                    [ FlexDirection.column]
                    ["flexDirection" ==> "column"]
                test
                    "Flex direction column-reverse"
                    [ FlexDirection.columnReverse]
                    ["flexDirection" ==> "column-reverse"]
                test
                    "Flex direction inherit"
                    [ FlexDirection.inherit']
                    ["flexDirection" ==> "inherit"]
                test
                    "Flex direction initial"
                    [ FlexDirection.initial]
                    ["flexDirection" ==> "initial"]
                test
                    "Flex direction unset"
                    [ FlexDirection.unset]
                    ["flexDirection" ==> "unset"]
                test
                    "Flex wrap no-wrap"
                    [ FlexWrap.noWrap]
                    ["flexWrap" ==> "no-wrap"]
                test
                    "Flex wrap wrap"
                    [ FlexWrap.wrap]
                    ["flexWrap" ==> "wrap"]
                test
                    "Flex wrap wrap-reverse"
                    [ FlexWrap.wrapReverse]
                    ["flexWrap" ==> "wrap-reverse"]
                test
                    "Flex wrap inherit"
                    [ FlexWrap.inherit']
                    ["flexWrap" ==> "inherit"]
                test
                    "Flex wrap initial"
                    [ FlexWrap.initial]
                    ["flexWrap" ==> "initial"]
                test
                    "Flex wrap unset"
                    [ FlexWrap.unset]
                    ["flexWrap" ==> "unset"]
                test
                    "Flex basis em"
                    [ FlexBasis' (em 10.0)]
                    ["flexBasis" ==> "10.0em"]
                test
                    "Flex basis px"
                    [ FlexBasis' (px 100)]
                    ["flexBasis" ==> "100px"]
                test
                    "Flex basis auto"
                    [ FlexBasis.auto]
                    ["flexBasis" ==> "auto"]
                test
                    "Flex basis fill"
                    [ FlexBasis.fill ]
                    ["flexBasis" ==> "fill"]
                test
                    "Flex basis max-content"
                    [ FlexBasis.maxContent]
                    ["flexBasis" ==> "max-content"]
                test
                    "Flex basis min-content"
                    [ FlexBasis.minContent]
                    ["flexBasis" ==> "min-content"]
                test
                    "Flex basis fit-content"
                    [ FlexBasis.fitContent ]
                    ["flexBasis" ==> "fit-content"]
                test
                    "Flex basis content"
                    [ FlexBasis.content]
                    ["flexBasis" ==> "content"]
                test
                    "Justify content start"
                    [ JustifyContent.start]
                    ["justifyContent" ==> "start"]
                test
                    "Justify content end"
                    [ JustifyContent.end']
                    ["justifyContent" ==> "end"]
                test
                    "Justify content flex start"
                    [ JustifyContent.flexStart]
                    ["justifyContent" ==> "flex-start"]
                test
                    "Justify content flex end"
                    [ JustifyContent.flexEnd]
                    ["justifyContent" ==> "flex-end"]
                test
                    "Justify content center"
                    [ JustifyContent.center]
                    ["justifyContent" ==> "center"]
                test
                    "Justify content left"
                    [ JustifyContent.left]
                    ["justifyContent" ==> "left"]
                test
                    "Justify content right"
                    [ JustifyContent.right]
                    ["justifyContent" ==> "right"]
                test
                    "Justify content normal"
                    [ JustifyContent.normal]
                    ["justifyContent" ==> "normal"]
                test
                    "Justify content baseline"
                    [ JustifyContent.baseline]
                    ["justifyContent" ==> "baseline"]
                test
                    "Justify content space between"
                    [ JustifyContent.spaceBetween]
                    ["justifyContent" ==> "space-between"]
                test
                    "Justify content space around"
                    [ JustifyContent.spaceAround]
                    ["justifyContent" ==> "space-around"]
                test
                    "Justify content space evenly"
                    [ JustifyContent.spaceEvenly]
                    ["justifyContent" ==> "space-evenly"]
                test
                    "Justify content right"
                    [ JustifyContent.right]
                    ["justifyContent" ==> "right"]
                test
                    "Justify content safe"
                    [ JustifyContent.safe]
                    ["justifyContent" ==> "safe"]
                test
                    "Justify content unsafe"
                    [ JustifyContent.unsafe]
                    ["justifyContent" ==> "unsafe"]
                test
                    "Justify content inherit"
                    [ JustifyContent.inherit']
                    ["justifyContent" ==> "inherit"]
                test
                    "Justify content initial"
                    [ JustifyContent.initial]
                    ["justifyContent" ==> "initial"]
                test
                    "Justify content unset"
                    [ JustifyContent.unset]
                    ["justifyContent" ==> "unset"]
                test
                    "Justify self normal"
                    [ JustifySelf.normal ]
                    ["justifySelf" ==> "normal"]
                test
                    "Justify self flex start"
                    [ JustifySelf.selfStart]
                    ["justifySelf" ==> "self-start"]
                test
                    "Justify self flex end"
                    [ JustifySelf.selfEnd]
                    ["justifySelf" ==> "self-end"]
                test
                    "Justify self flex start"
                    [ JustifySelf.flexStart]
                    ["justifySelf" ==> "flex-start"]
                test
                    "Justify self flex end"
                    [ JustifySelf.flexEnd]
                    ["justifySelf" ==> "flex-end"]
                test
                    "Justify self center"
                    [ JustifySelf.center]
                    ["justifySelf" ==> "center"]
                test
                    "Justify self baseline"
                    [ JustifySelf.baseline]
                    ["justifySelf" ==> "baseline"]
                test
                    "Justify self stretch"
                    [ JustifySelf.stretch]
                    ["justifySelf" ==> "stretch"]
                test
                    "Justify self safe"
                    [ JustifySelf.safe]
                    ["justifySelf" ==> "safe"]
                test
                    "Justify self unsafe"
                    [ JustifySelf.unsafe]
                    ["justifySelf" ==> "unsafe"]
                test
                    "Justify self inherit"
                    [ JustifySelf.inherit']
                    ["justifySelf" ==> "inherit"]
                test
                    "Justify self initial"
                    [ JustifySelf.initial]
                    ["justifySelf" ==> "initial"]
                test
                    "Justify self unset"
                    [ JustifySelf.unset]
                    ["justifySelf" ==> "unset"]
                test
                    "Justify items start"
                    [ JustifyItems.start]
                    ["justifyItems" ==> "start"]
                test
                    "Justify items end"
                    [ JustifyItems.end']
                    ["justifyItems" ==> "end"]
                test
                    "Justify items flex start"
                    [ JustifyItems.flexStart]
                    ["justifyItems" ==> "flex-start"]
                test
                    "Justify items flex end"
                    [ JustifyItems.flexEnd]
                    ["justifyItems" ==> "flex-end"]
                test
                    "Justify items center"
                    [ JustifyItems.center]
                    ["justifyItems" ==> "center"]
                test
                    "Justify items normal"
                    [ JustifyItems.normal]
                    ["justifyItems" ==> "normal"]
                test
                    "Justify items baseline"
                    [ JustifyItems.baseline]
                    ["justifyItems" ==> "baseline"]
                test
                    "Justify items safe"
                    [ JustifyItems.safe]
                    ["justifyItems" ==> "safe"]
                test
                    "Justify items unsafe"
                    [ JustifyItems.unsafe]
                    ["justifyItems" ==> "unsafe"]
                test
                    "Justify items inherit"
                    [ JustifyItems.inherit']
                    ["justifyItems" ==> "inherit"]
                test
                    "Justify items initial"
                    [ JustifyItems.initial]
                    ["justifyItems" ==> "initial"]
                test
                    "Justify items unset"
                    [ JustifyItems.unset]
                    ["justifyItems" ==> "unset"]
                test
                    "Justify items legacy"
                    [ JustifyItems.legacy]
                    ["justifyItems" ==> "legacy"]
                test
                    "Align self normal"
                    [ AlignSelf.normal]
                    ["alignSelf" ==> "normal"]
                test
                    "Align self flex start"
                    [ AlignSelf.selfStart]
                    ["alignSelf" ==> "self-start"]
                test
                    "Align self flex end"
                    [ AlignSelf.selfEnd]
                    ["alignSelf" ==> "self-end"]
                test
                    "Align self flex start"
                    [ AlignSelf.flexStart]
                    ["alignSelf" ==> "flex-start"]
                test
                    "Align self flex end"
                    [ AlignSelf.flexEnd]
                    ["alignSelf" ==> "flex-end"]
                test
                    "Align self center"
                    [ AlignSelf.center]
                    ["alignSelf" ==> "center"]
                test
                    "Align self baseline"
                    [ AlignSelf.baseline]
                    ["alignSelf" ==> "baseline"]
                test
                    "Align self stretch"
                    [ AlignSelf.stretch]
                    ["alignSelf" ==> "stretch"]
                test
                    "Align self safe"
                    [ AlignSelf.safe]
                    ["alignSelf" ==> "safe"]
                test
                    "Align self unsafe"
                    [ AlignSelf.unsafe]
                    ["alignSelf" ==> "unsafe"]
                test
                    "Align self inherit"
                    [ AlignSelf.inherit']
                    ["alignSelf" ==> "inherit"]
                test
                    "Align self initial"
                    [ AlignSelf.initial]
                    ["alignSelf" ==> "initial"]
                test
                    "Align self unset"
                    [ AlignSelf.unset]
                    ["alignSelf" ==> "unset"]
                test
                    "Align items start"
                    [ AlignItems.start]
                    ["alignItems" ==> "start"]
                test
                    "Align items end"
                    [ AlignItems.end']
                    ["alignItems" ==> "end"]
                test
                    "Align items flex start"
                    [ AlignItems.flexStart]
                    ["alignItems" ==> "flex-start"]
                test
                    "Align items flex end"
                    [ AlignItems.flexEnd]
                    ["alignItems" ==> "flex-end"]
                test
                    "Align items center"
                    [ AlignItems.center]
                    ["alignItems" ==> "center"]
                test
                    "Align items normal"
                    [ AlignItems.normal]
                    ["alignItems" ==> "normal"]
                test
                    "Align items baseline"
                    [ AlignItems.baseline]
                    ["alignItems" ==> "baseline"]
                test
                    "Align items safe"
                    [ AlignItems.safe]
                    ["alignItems" ==> "safe"]
                test
                    "Align items unsafe"
                    [ AlignItems.unsafe]
                    ["alignItems" ==> "unsafe"]
                test
                    "Align items inherit"
                    [ AlignItems.inherit']
                    ["alignItems" ==> "inherit"]
                test
                    "Align items initial"
                    [ AlignItems.initial]
                    ["alignItems" ==> "initial"]
                test
                    "Align items unset"
                    [ AlignItems.unset]
                    ["alignItems" ==> "unset"]
                test
                    "Align content start"
                    [ AlignContent.start']
                    ["alignContent" ==> "start"]
                test
                    "Align content end"
                    [ AlignContent.end']
                    ["alignContent" ==> "end"]
                test
                    "Align content flex start"
                    [ AlignContent.flexStart]
                    ["alignContent" ==> "flex-start"]
                test
                    "Align content flex end"
                    [ AlignContent.flexEnd]
                    ["alignContent" ==> "flex-end"]
                test
                    "Align content center"
                    [ AlignContent.center]
                    ["alignContent" ==> "center"]
                test
                    "Align content normal"
                    [ AlignContent.normal]
                    ["alignContent" ==> "normal"]
                test
                    "Align content baseline"
                    [ AlignContent.baseline]
                    ["alignContent" ==> "baseline"]
                test
                    "Align content space between"
                    [ AlignContent.spaceBetween]
                    ["alignContent" ==> "space-between"]
                test
                    "Align content space around"
                    [ AlignContent.spaceAround]
                    ["alignContent" ==> "space-around"]
                test
                    "Align content space evenly"
                    [ AlignContent.spaceEvenly]
                    ["alignContent" ==> "space-evenly"]
                test
                    "Align content safe"
                    [ AlignContent.safe]
                    ["alignContent" ==> "safe"]
                test
                    "Align content unsafe"
                    [ AlignContent.unsafe]
                    ["alignContent" ==> "unsafe"]
                test
                    "Align content inherit"
                    [ AlignContent.inherit']
                    ["alignContent" ==> "inherit"]
                test
                    "Align content initial"
                    [ AlignContent.initial]
                    ["alignContent" ==> "initial"]
                test
                    "Align content unset"
                    [ AlignContent.unset]
                    ["alignContent" ==> "unset"]
                test
                    "Order value"
                    [ Order' (FssTypes.CssInt 1) ]
                    ["order" ==> "1"]
                test
                    "Order inherit"
                    [ Order.inherit']
                    ["order" ==> "inherit"]
                test
                    "Order initial"
                    [ Order.initial]
                    ["order" ==> "initial"]
                test
                    "Order unset"
                    [ Order.unset]
                    ["order" ==> "unset"]
                test
                    "Flex grow value"
                    [ FlexGrow' (FssTypes.CssFloat 1.5) ]
                    ["flexGrow" ==> "1.5"]
                test
                    "FlexGrow inherit"
                    [ FlexGrow.inherit']
                    ["flexGrow" ==> "inherit"]
                test
                    "FlexGrow initial"
                    [ FlexGrow.initial]
                    ["flexGrow" ==> "initial"]
                test
                    "FlexGrow unset"
                    [ FlexGrow.unset]
                    ["flexGrow" ==> "unset"]
                test
                    "FlexShrink value"
                    [ FlexShrink' (FssTypes.CssFloat 1.5) ]
                    ["flexShrink" ==> "1.5"]
                test
                    "FlexShrink inherit"
                    [ FlexShrink.inherit']
                    ["flexShrink" ==> "inherit"]
                test
                    "FlexShrink initial"
                    [ FlexShrink.initial]
                    ["flexShrink" ==> "initial"]
                test
                    "FlexShrink unset"
                    [ FlexShrink.unset]
                    ["flexShrink" ==> "unset"]
            ]