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
                    [ FlexDirection Flex.Row]
                    ["flexDirection" ==> "row"]

                test
                    "Flex direction row-reverse"
                    [ FlexDirection Flex.RowReverse]
                    ["flexDirection" ==> "row-reverse"]

                test
                    "Flex direction column"
                    [ FlexDirection Flex.Column]
                    ["flexDirection" ==> "column"]

                test
                    "Flex direction column-reverse"
                    [ FlexDirection Flex.ColumnReverse]
                    ["flexDirection" ==> "column-reverse"]

                test
                    "Flex direction inherit"
                    [ FlexDirection Inherit]
                    ["flexDirection" ==> "inherit"]

                test
                    "Flex direction initial"
                    [ FlexDirection Initial]
                    ["flexDirection" ==> "initial"]

                test
                    "Flex direction unset"
                    [ FlexDirection Unset]
                    ["flexDirection" ==> "unset"]


                test
                    "Flex wrap no-wrap"
                    [ FlexWrap Flex.NoWrap]
                    ["flexWrap" ==> "no-wrap"]

                test
                    "Flex wrap wrap"
                    [ FlexWrap Flex.Wrap]
                    ["flexWrap" ==> "wrap"]

                test
                    "Flex wrap wrap-reverse"
                    [ FlexWrap Flex.WrapReverse]
                    ["flexWrap" ==> "wrap-reverse"]

                test
                    "Flex wrap inherit"
                    [ FlexWrap Inherit]
                    ["flexWrap" ==> "inherit"]

                test
                    "Flex wrap initial"
                    [ FlexWrap Initial]
                    ["flexWrap" ==> "initial"]

                test
                    "Flex wrap unset"
                    [ FlexWrap Unset]
                    ["flexWrap" ==> "unset"]

                test
                    "Flex basis em"
                    [ FlexBasis (em 10.0)]
                    ["flexBasis" ==> "10.0em"]

                test
                    "Flex basis px"
                    [ FlexBasis (px 100)]
                    ["flexBasis" ==> "100px"]

                test
                    "Flex basis auto"
                    [ FlexBasis Auto]
                    ["flexBasis" ==> "auto"]

                test
                    "Flex basis fill"
                    [ FlexBasis Flex.Fill ]
                    ["flexBasis" ==> "fill"]

                test
                    "Flex basis max-content"
                    [ FlexBasis Flex.MaxContent]
                    ["flexBasis" ==> "max-content"]

                test
                    "Flex basis min-content"
                    [ FlexBasis Flex.MinContent]
                    ["flexBasis" ==> "min-content"]

                test
                    "Flex basis fit-content"
                    [ FlexBasis Flex.FitContent]
                    ["flexBasis" ==> "fit-content"]

                test
                    "Flex basis content"
                    [ FlexBasis Flex.Content]
                    ["flexBasis" ==> "content"]

                test
                    "Justify content start"
                    [ JustifyContent Flex.Start]
                    ["justifyContent" ==> "start"]

                test
                    "Justify content end"
                    [ JustifyContent Flex.End]
                    ["justifyContent" ==> "end"]

                test
                    "Justify content flex start"
                    [ JustifyContent Flex.FlexStart]
                    ["justifyContent" ==> "flex-start"]

                test
                    "Justify content flex end"
                    [ JustifyContent Flex.FlexEnd]
                    ["justifyContent" ==> "flex-end"]

                test
                    "Justify content center"
                    [ JustifyContent Flex.Center]
                    ["justifyContent" ==> "center"]

                test
                    "Justify content left"
                    [ JustifyContent Flex.Left]
                    ["justifyContent" ==> "left"]

                test
                    "Justify content right"
                    [ JustifyContent Flex.Right]
                    ["justifyContent" ==> "right"]

                test
                    "Justify content normal"
                    [ JustifyContent Normal]
                    ["justifyContent" ==> "normal"]

                test
                    "Justify content baseline"
                    [ JustifyContent Flex.Baseline]
                    ["justifyContent" ==> "baseline"]

                test
                    "Justify content space between"
                    [ JustifyContent Flex.SpaceBetween]
                    ["justifyContent" ==> "space-between"]

                test
                    "Justify content space around"
                    [ JustifyContent Flex.SpaceAround]
                    ["justifyContent" ==> "space-around"]

                test
                    "Justify content space evenly"
                    [ JustifyContent Flex.SpaceEvenly]
                    ["justifyContent" ==> "space-evenly"]

                test
                    "Justify content right"
                    [ JustifyContent Flex.Right]
                    ["justifyContent" ==> "right"]

                test
                    "Justify content safe"
                    [ JustifyContent Flex.Safe]
                    ["justifyContent" ==> "safe"]

                test
                    "Justify content unsafe"
                    [ JustifyContent Flex.Unsafe]
                    ["justifyContent" ==> "unsafe"]

                test
                    "Justify content inherit"
                    [ JustifyContent Inherit]
                    ["justifyContent" ==> "inherit"]

                test
                    "Justify content initial"
                    [ JustifyContent Initial]
                    ["justifyContent" ==> "initial"]

                test
                    "Justify content unset"
                    [ JustifyContent Unset]
                    ["justifyContent" ==> "unset"]

                test
                    "Justify self normal"
                    [ JustifySelf Normal ]
                    ["justifySelf" ==> "normal"]

                test
                    "Justify self flex start"
                    [ JustifySelf Flex.SelfStart]
                    ["justifySelf" ==> "self-start"]

                test
                    "Justify self flex end"
                    [ JustifySelf Flex.SelfEnd]
                    ["justifySelf" ==> "self-end"]

                test
                    "Justify self flex start"
                    [ JustifySelf Flex.FlexStart]
                    ["justifySelf" ==> "flex-start"]

                test
                    "Justify self flex end"
                    [ JustifySelf Flex.FlexEnd]
                    ["justifySelf" ==> "flex-end"]

                test
                    "Justify self center"
                    [ JustifySelf Flex.Center]
                    ["justifySelf" ==> "center"]

                test
                    "Justify self baseline"
                    [ JustifySelf Flex.Baseline]
                    ["justifySelf" ==> "baseline"]

                test
                    "Justify self stretch"
                    [ JustifySelf Flex.Stretch]
                    ["justifySelf" ==> "stretch"]

                test
                    "Justify self safe"
                    [ JustifySelf Flex.Safe]
                    ["justifySelf" ==> "safe"]

                test
                    "Justify self unsafe"
                    [ JustifySelf Flex.Unsafe]
                    ["justifySelf" ==> "unsafe"]

                test
                    "Justify self inherit"
                    [ JustifySelf Inherit]
                    ["justifySelf" ==> "inherit"]

                test
                    "Justify self initial"
                    [ JustifySelf Initial]
                    ["justifySelf" ==> "initial"]

                test
                    "Justify self unset"
                    [ JustifySelf Unset]
                    ["justifySelf" ==> "unset"]

                test
                    "Justify items start"
                    [ JustifyItems Flex.Start]
                    ["justifyItems" ==> "start"]

                test
                    "Justify items end"
                    [ JustifyItems Flex.End]
                    ["justifyItems" ==> "end"]

                test
                    "Justify items flex start"
                    [ JustifyItems Flex.FlexStart]
                    ["justifyItems" ==> "flex-start"]

                test
                    "Justify items flex end"
                    [ JustifyItems Flex.FlexEnd]
                    ["justifyItems" ==> "flex-end"]

                test
                    "Justify items center"
                    [ JustifyItems Flex.Center]
                    ["justifyItems" ==> "center"]

                test
                    "Justify items normal"
                    [ JustifyItems Normal]
                    ["justifyItems" ==> "normal"]

                test
                    "Justify items baseline"
                    [ JustifyItems Flex.Baseline]
                    ["justifyItems" ==> "baseline"]

                test
                    "Justify items safe"
                    [ JustifyItems Flex.Safe]
                    ["justifyItems" ==> "safe"]

                test
                    "Justify items unsafe"
                    [ JustifyItems Flex.Unsafe]
                    ["justifyItems" ==> "unsafe"]

                test
                    "Justify items inherit"
                    [ JustifyItems Inherit]
                    ["justifyItems" ==> "inherit"]

                test
                    "Justify items initial"
                    [ JustifyItems Initial]
                    ["justifyItems" ==> "initial"]

                test
                    "Justify items unset"
                    [ JustifyItems Unset]
                    ["justifyItems" ==> "unset"]

                test
                    "Justify items legacy"
                    [ JustifyItems Flex.Legacy]
                    ["justifyItems" ==> "legacy"]

                test
                    "Align self normal"
                    [ AlignSelf Normal]
                    ["alignSelf" ==> "normal"]

                test
                    "Align self flex start"
                    [ AlignSelf Flex.SelfStart]
                    ["alignSelf" ==> "self-start"]

                test
                    "Align self flex end"
                    [ AlignSelf Flex.SelfEnd]
                    ["alignSelf" ==> "self-end"]

                test
                    "Align self flex start"
                    [ AlignSelf Flex.FlexStart]
                    ["alignSelf" ==> "flex-start"]

                test
                    "Align self flex end"
                    [ AlignSelf Flex.FlexEnd]
                    ["alignSelf" ==> "flex-end"]

                test
                    "Align self center"
                    [ AlignSelf Flex.Center]
                    ["alignSelf" ==> "center"]

                test
                    "Align self baseline"
                    [ AlignSelf Flex.Baseline]
                    ["alignSelf" ==> "baseline"]

                test
                    "Align self stretch"
                    [ AlignSelf Flex.Stretch]
                    ["alignSelf" ==> "stretch"]

                test
                    "Align self safe"
                    [ AlignSelf Flex.Safe]
                    ["alignSelf" ==> "safe"]

                test
                    "Align self unsafe"
                    [ AlignSelf Flex.Unsafe]
                    ["alignSelf" ==> "unsafe"]

                test
                    "Align self inherit"
                    [ AlignSelf Inherit]
                    ["alignSelf" ==> "inherit"]

                test
                    "Align self initial"
                    [ AlignSelf Initial]
                    ["alignSelf" ==> "initial"]

                test
                    "Align self unset"
                    [ AlignSelf Unset]
                    ["alignSelf" ==> "unset"]

                test
                    "Align items start"
                    [ AlignItems Flex.Start]
                    ["alignItems" ==> "start"]

                test
                    "Align items end"
                    [ AlignItems Flex.End]
                    ["alignItems" ==> "end"]

                test
                    "Align items flex start"
                    [ AlignItems Flex.FlexStart]
                    ["alignItems" ==> "flex-start"]

                test
                    "Align items flex end"
                    [ AlignItems Flex.FlexEnd]
                    ["alignItems" ==> "flex-end"]

                test
                    "Align items center"
                    [ AlignItems Flex.Center]
                    ["alignItems" ==> "center"]

                test
                    "Align items normal"
                    [ AlignItems Normal]
                    ["alignItems" ==> "normal"]

                test
                    "Align items baseline"
                    [ AlignItems Flex.Baseline]
                    ["alignItems" ==> "baseline"]

                test
                    "Align items safe"
                    [ AlignItems Flex.Safe]
                    ["alignItems" ==> "safe"]

                test
                    "Align items unsafe"
                    [ AlignItems Flex.Unsafe]
                    ["alignItems" ==> "unsafe"]

                test
                    "Align items inherit"
                    [ AlignItems Inherit]
                    ["alignItems" ==> "inherit"]

                test
                    "Align items initial"
                    [ AlignItems Initial]
                    ["alignItems" ==> "initial"]

                test
                    "Align items unset"
                    [ AlignItems Unset]
                    ["alignItems" ==> "unset"]

                test
                    "Align content start"
                    [ AlignContent Flex.Start]
                    ["alignContent" ==> "start"]

                test
                    "Align content end"
                    [ AlignContent Flex.End]
                    ["alignContent" ==> "end"]

                test
                    "Align content flex start"
                    [ AlignContent Flex.FlexStart]
                    ["alignContent" ==> "flex-start"]

                test
                    "Align content flex end"
                    [ AlignContent Flex.FlexEnd]
                    ["alignContent" ==> "flex-end"]

                test
                    "Align content center"
                    [ AlignContent Flex.Center]
                    ["alignContent" ==> "center"]

                test
                    "Align content normal"
                    [ AlignContent Normal]
                    ["alignContent" ==> "normal"]

                test
                    "Align content baseline"
                    [ AlignContent Flex.Baseline]
                    ["alignContent" ==> "baseline"]

                test
                    "Align content space between"
                    [ AlignContent Flex.SpaceBetween]
                    ["alignContent" ==> "space-between"]

                test
                    "Align content space around"
                    [ AlignContent Flex.SpaceAround]
                    ["alignContent" ==> "space-around"]

                test
                    "Align content space evenly"
                    [ AlignContent Flex.SpaceEvenly]
                    ["alignContent" ==> "space-evenly"]

                test
                    "Align content safe"
                    [ AlignContent Flex.Safe]
                    ["alignContent" ==> "safe"]

                test
                    "Align content unsafe"
                    [ AlignContent Flex.Unsafe]
                    ["alignContent" ==> "unsafe"]

                test
                    "Align content inherit"
                    [ AlignContent Inherit]
                    ["alignContent" ==> "inherit"]

                test
                    "Align content initial"
                    [ AlignContent Initial]
                    ["alignContent" ==> "initial"]

                test
                    "Align content unset"
                    [ AlignContent Unset]
                    ["alignContent" ==> "unset"]

                test
                    "Order value"
                    [ Order (Flex.Order 1) ]
                    ["order" ==> "1"]

                test
                    "Order inherit"
                    [ Order Inherit]
                    ["order" ==> "inherit"]

                test
                    "Order initial"
                    [ Order Initial]
                    ["order" ==> "initial"]

                test
                    "Order unset"
                    [ Order Unset]
                    ["order" ==> "unset"]

                test
                    "Flex grow value"
                    [ FlexGrow (Flex.Grow 1.5) ]
                    ["flexGrow" ==> "1.5"]

                test
                    "FlexGrow inherit"
                    [ FlexGrow Inherit]
                    ["flexGrow" ==> "inherit"]

                test
                    "FlexGrow initial"
                    [ FlexGrow Initial]
                    ["flexGrow" ==> "initial"]

                test
                    "FlexGrow unset"
                    [ FlexGrow Unset]
                    ["flexGrow" ==> "unset"]

                test
                    "FlexShrink value"
                    [ FlexShrink (Flex.Shrink 1.5) ]
                    ["flexShrink" ==> "1.5"]

                test
                    "FlexShrink inherit"
                    [ FlexShrink Inherit]
                    ["flexShrink" ==> "inherit"]

                test
                    "FlexShrink initial"
                    [ FlexShrink Initial]
                    ["flexShrink" ==> "initial"]

                test
                    "FlexShrink unset"
                    [ FlexShrink Unset]
                    ["flexShrink" ==> "unset"]
            ]