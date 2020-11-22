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
                    [ FlexDirection.Row]
                    ["flexDirection" ==> "row"]
                test
                    "Flex direction row-reverse"
                    [ FlexDirection.RowReverse]
                    ["flexDirection" ==> "row-reverse"]
                test
                    "Flex direction column"
                    [ FlexDirection.Column]
                    ["flexDirection" ==> "column"]
                test
                    "Flex direction column-reverse"
                    [ FlexDirection.ColumnReverse]
                    ["flexDirection" ==> "column-reverse"]
                test
                    "Flex direction inherit"
                    [ FlexDirection.Inherit]
                    ["flexDirection" ==> "inherit"]
                test
                    "Flex direction initial"
                    [ FlexDirection.Initial]
                    ["flexDirection" ==> "initial"]
                test
                    "Flex direction unset"
                    [ FlexDirection.Unset]
                    ["flexDirection" ==> "unset"]
                test
                    "Flex wrap no-wrap"
                    [ FlexWrap.NoWrap]
                    ["flexWrap" ==> "no-wrap"]
                test
                    "Flex wrap wrap"
                    [ FlexWrap.Wrap]
                    ["flexWrap" ==> "wrap"]
                test
                    "Flex wrap wrap-reverse"
                    [ FlexWrap.WrapReverse]
                    ["flexWrap" ==> "wrap-reverse"]
                test
                    "Flex wrap inherit"
                    [ FlexWrap.Inherit]
                    ["flexWrap" ==> "inherit"]
                test
                    "Flex wrap initial"
                    [ FlexWrap.Initial]
                    ["flexWrap" ==> "initial"]
                test
                    "Flex wrap unset"
                    [ FlexWrap.Unset]
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
                    [ FlexBasis.Auto]
                    ["flexBasis" ==> "auto"]
                test
                    "Flex basis fill"
                    [ FlexBasis.Fill ]
                    ["flexBasis" ==> "fill"]
                test
                    "Flex basis max-content"
                    [ FlexBasis.MaxContent]
                    ["flexBasis" ==> "max-content"]
                test
                    "Flex basis min-content"
                    [ FlexBasis.MinContent]
                    ["flexBasis" ==> "min-content"]
                test
                    "Flex basis fit-content"
                    [ FlexBasis.FitContent ]
                    ["flexBasis" ==> "fit-content"]
                test
                    "Flex basis content"
                    [ FlexBasis.Content]
                    ["flexBasis" ==> "content"]
                test
                    "Justify content start"
                    [ JustifyContent.Start]
                    ["justifyContent" ==> "start"]
                test
                    "Justify content end"
                    [ JustifyContent.End]
                    ["justifyContent" ==> "end"]
                test
                    "Justify content flex start"
                    [ JustifyContent.FlexStart]
                    ["justifyContent" ==> "flex-start"]
                test
                    "Justify content flex end"
                    [ JustifyContent.FlexEnd]
                    ["justifyContent" ==> "flex-end"]
                test
                    "Justify content center"
                    [ JustifyContent.Center]
                    ["justifyContent" ==> "center"]
                test
                    "Justify content left"
                    [ JustifyContent.Left]
                    ["justifyContent" ==> "left"]
                test
                    "Justify content right"
                    [ JustifyContent.Right]
                    ["justifyContent" ==> "right"]
                test
                    "Justify content normal"
                    [ JustifyContent.Normal]
                    ["justifyContent" ==> "normal"]
                test
                    "Justify content baseline"
                    [ JustifyContent.Baseline]
                    ["justifyContent" ==> "baseline"]
                test
                    "Justify content space between"
                    [ JustifyContent.SpaceBetween]
                    ["justifyContent" ==> "space-between"]
                test
                    "Justify content space around"
                    [ JustifyContent.SpaceAround]
                    ["justifyContent" ==> "space-around"]
                test
                    "Justify content space evenly"
                    [ JustifyContent.SpaceEvenly]
                    ["justifyContent" ==> "space-evenly"]
                test
                    "Justify content right"
                    [ JustifyContent.Right]
                    ["justifyContent" ==> "right"]
                test
                    "Justify content safe"
                    [ JustifyContent.Safe]
                    ["justifyContent" ==> "safe"]
                test
                    "Justify content unsafe"
                    [ JustifyContent.Unsafe]
                    ["justifyContent" ==> "unsafe"]
                test
                    "Justify content inherit"
                    [ JustifyContent.Inherit]
                    ["justifyContent" ==> "inherit"]
                test
                    "Justify content initial"
                    [ JustifyContent.Initial]
                    ["justifyContent" ==> "initial"]
                test
                    "Justify content unset"
                    [ JustifyContent.Unset]
                    ["justifyContent" ==> "unset"]
                test
                    "Justify self normal"
                    [ JustifySelf.Normal ]
                    ["justifySelf" ==> "normal"]
                test
                    "Justify self flex start"
                    [ JustifySelf.SelfStart]
                    ["justifySelf" ==> "self-start"]
                test
                    "Justify self flex end"
                    [ JustifySelf.SelfEnd]
                    ["justifySelf" ==> "self-end"]
                test
                    "Justify self flex start"
                    [ JustifySelf.FlexStart]
                    ["justifySelf" ==> "flex-start"]
                test
                    "Justify self flex end"
                    [ JustifySelf.FlexEnd]
                    ["justifySelf" ==> "flex-end"]
                test
                    "Justify self center"
                    [ JustifySelf.Center]
                    ["justifySelf" ==> "center"]
                test
                    "Justify self baseline"
                    [ JustifySelf.Baseline]
                    ["justifySelf" ==> "baseline"]
                test
                    "Justify self stretch"
                    [ JustifySelf.Stretch]
                    ["justifySelf" ==> "stretch"]
                test
                    "Justify self safe"
                    [ JustifySelf.Safe]
                    ["justifySelf" ==> "safe"]
                test
                    "Justify self unsafe"
                    [ JustifySelf.Unsafe]
                    ["justifySelf" ==> "unsafe"]
                test
                    "Justify self inherit"
                    [ JustifySelf.Inherit]
                    ["justifySelf" ==> "inherit"]
                test
                    "Justify self initial"
                    [ JustifySelf.Initial]
                    ["justifySelf" ==> "initial"]
                test
                    "Justify self unset"
                    [ JustifySelf.Unset]
                    ["justifySelf" ==> "unset"]
                test
                    "Justify items start"
                    [ JustifyItems.Start]
                    ["justifyItems" ==> "start"]
                test
                    "Justify items end"
                    [ JustifyItems.End]
                    ["justifyItems" ==> "end"]
                test
                    "Justify items flex start"
                    [ JustifyItems.FlexStart]
                    ["justifyItems" ==> "flex-start"]
                test
                    "Justify items flex end"
                    [ JustifyItems.FlexEnd]
                    ["justifyItems" ==> "flex-end"]
                test
                    "Justify items center"
                    [ JustifyItems.Center]
                    ["justifyItems" ==> "center"]
                test
                    "Justify items normal"
                    [ JustifyItems.Normal]
                    ["justifyItems" ==> "normal"]
                test
                    "Justify items baseline"
                    [ JustifyItems.Baseline]
                    ["justifyItems" ==> "baseline"]
                test
                    "Justify items safe"
                    [ JustifyItems.Safe]
                    ["justifyItems" ==> "safe"]
                test
                    "Justify items unsafe"
                    [ JustifyItems.Unsafe]
                    ["justifyItems" ==> "unsafe"]
                test
                    "Justify items inherit"
                    [ JustifyItems.Inherit]
                    ["justifyItems" ==> "inherit"]
                test
                    "Justify items initial"
                    [ JustifyItems.Initial]
                    ["justifyItems" ==> "initial"]
                test
                    "Justify items unset"
                    [ JustifyItems.Unset]
                    ["justifyItems" ==> "unset"]
                test
                    "Justify items legacy"
                    [ JustifyItems.Legacy]
                    ["justifyItems" ==> "legacy"]
                test
                    "Align self normal"
                    [ AlignSelf.Normal]
                    ["alignSelf" ==> "normal"]
                test
                    "Align self flex start"
                    [ AlignSelf.SelfStart]
                    ["alignSelf" ==> "self-start"]
                test
                    "Align self flex end"
                    [ AlignSelf.SelfEnd]
                    ["alignSelf" ==> "self-end"]
                test
                    "Align self flex start"
                    [ AlignSelf.FlexStart]
                    ["alignSelf" ==> "flex-start"]
                test
                    "Align self flex end"
                    [ AlignSelf.FlexEnd]
                    ["alignSelf" ==> "flex-end"]
                test
                    "Align self center"
                    [ AlignSelf.Center]
                    ["alignSelf" ==> "center"]
                test
                    "Align self baseline"
                    [ AlignSelf.Baseline]
                    ["alignSelf" ==> "baseline"]
                test
                    "Align self stretch"
                    [ AlignSelf.Stretch]
                    ["alignSelf" ==> "stretch"]
                test
                    "Align self safe"
                    [ AlignSelf.Safe]
                    ["alignSelf" ==> "safe"]
                test
                    "Align self unsafe"
                    [ AlignSelf.Unsafe]
                    ["alignSelf" ==> "unsafe"]
                test
                    "Align self inherit"
                    [ AlignSelf.Inherit]
                    ["alignSelf" ==> "inherit"]
                test
                    "Align self initial"
                    [ AlignSelf.Initial]
                    ["alignSelf" ==> "initial"]
                test
                    "Align self unset"
                    [ AlignSelf.Unset]
                    ["alignSelf" ==> "unset"]
                test
                    "Align items start"
                    [ AlignItems.Start]
                    ["alignItems" ==> "start"]
                test
                    "Align items end"
                    [ AlignItems.End]
                    ["alignItems" ==> "end"]
                test
                    "Align items flex start"
                    [ AlignItems.FlexStart]
                    ["alignItems" ==> "flex-start"]
                test
                    "Align items flex end"
                    [ AlignItems.FlexEnd]
                    ["alignItems" ==> "flex-end"]
                test
                    "Align items center"
                    [ AlignItems.Center]
                    ["alignItems" ==> "center"]
                test
                    "Align items normal"
                    [ AlignItems.Normal]
                    ["alignItems" ==> "normal"]
                test
                    "Align items baseline"
                    [ AlignItems.Baseline]
                    ["alignItems" ==> "baseline"]
                test
                    "Align items safe"
                    [ AlignItems.Safe]
                    ["alignItems" ==> "safe"]
                test
                    "Align items unsafe"
                    [ AlignItems.Unsafe]
                    ["alignItems" ==> "unsafe"]
                test
                    "Align items inherit"
                    [ AlignItems.Inherit]
                    ["alignItems" ==> "inherit"]
                test
                    "Align items initial"
                    [ AlignItems.Initial]
                    ["alignItems" ==> "initial"]
                test
                    "Align items unset"
                    [ AlignItems.Unset]
                    ["alignItems" ==> "unset"]
                test
                    "Align content start"
                    [ AlignContent.Start]
                    ["alignContent" ==> "start"]
                test
                    "Align content end"
                    [ AlignContent.End]
                    ["alignContent" ==> "end"]
                test
                    "Align content flex start"
                    [ AlignContent.FlexStart]
                    ["alignContent" ==> "flex-start"]
                test
                    "Align content flex end"
                    [ AlignContent.FlexEnd]
                    ["alignContent" ==> "flex-end"]
                test
                    "Align content center"
                    [ AlignContent.Center]
                    ["alignContent" ==> "center"]
                test
                    "Align content normal"
                    [ AlignContent.Normal]
                    ["alignContent" ==> "normal"]
                test
                    "Align content baseline"
                    [ AlignContent.Baseline]
                    ["alignContent" ==> "baseline"]
                test
                    "Align content space between"
                    [ AlignContent.SpaceBetween]
                    ["alignContent" ==> "space-between"]
                test
                    "Align content space around"
                    [ AlignContent.SpaceAround]
                    ["alignContent" ==> "space-around"]
                test
                    "Align content space evenly"
                    [ AlignContent.SpaceEvenly]
                    ["alignContent" ==> "space-evenly"]
                test
                    "Align content safe"
                    [ AlignContent.Safe]
                    ["alignContent" ==> "safe"]
                test
                    "Align content unsafe"
                    [ AlignContent.Unsafe]
                    ["alignContent" ==> "unsafe"]
                test
                    "Align content inherit"
                    [ AlignContent.Inherit]
                    ["alignContent" ==> "inherit"]
                test
                    "Align content initial"
                    [ AlignContent.Initial]
                    ["alignContent" ==> "initial"]
                test
                    "Align content unset"
                    [ AlignContent.Unset]
                    ["alignContent" ==> "unset"]
                test
                    "Order value"
                    [ Order' (CssInt 1) ]
                    ["order" ==> "1"]
                test
                    "Order inherit"
                    [ Order.Inherit]
                    ["order" ==> "inherit"]
                test
                    "Order initial"
                    [ Order.Initial]
                    ["order" ==> "initial"]
                test
                    "Order unset"
                    [ Order.Unset]
                    ["order" ==> "unset"]
                test
                    "Flex grow value"
                    [ FlexGrow' (CssFloat 1.5) ]
                    ["flexGrow" ==> "1.5"]
                test
                    "FlexGrow inherit"
                    [ FlexGrow.Inherit]
                    ["flexGrow" ==> "inherit"]
                test
                    "FlexGrow initial"
                    [ FlexGrow.Initial]
                    ["flexGrow" ==> "initial"]
                test
                    "FlexGrow unset"
                    [ FlexGrow.Unset]
                    ["flexGrow" ==> "unset"]
                test
                    "FlexShrink value"
                    [ FlexShrink' (CssFloat 1.5) ]
                    ["flexShrink" ==> "1.5"]
                test
                    "FlexShrink inherit"
                    [ FlexShrink.Inherit]
                    ["flexShrink" ==> "inherit"]
                test
                    "FlexShrink initial"
                    [ FlexShrink.Initial]
                    ["flexShrink" ==> "initial"]
                test
                    "FlexShrink unset"
                    [ FlexShrink.Unset]
                    ["flexShrink" ==> "unset"]
            ]