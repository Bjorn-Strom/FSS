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
                    "Place items auto center"
                    [ PlaceItems <| Flex.PlaceItems Auto Center ]
                    ["" ==> ""]

                test
                    "Place items normal start"
                    [ PlaceItems <| Flex.PlaceItems Normal Flex.Start ]
                    ["" ==> ""]

                test
                    "Place items start auto"
                    [ PlaceItems <| Flex.PlaceItems Flex.Start Auto ]
                    ["" ==> ""]

                test
                    "Place items end normal"
                    [ PlaceItems <| Flex.PlaceItems Flex.End Normal ]
                    ["" ==> ""]

                test
                    "Place items self-start auto"
                    [ PlaceItems <| Flex.PlaceItems Flex.SelfStart Auto ]
                    ["" ==> ""]

                test
                    "Place items self-end normal"
                    [ PlaceItems <| Flex.PlaceItems Flex.SelfEnd Normal ]
                    ["" ==> ""]

                test
                    "Place items flex-start auto"
                    [ PlaceItems <| Flex.PlaceItems Flex.Start Auto ]
                    ["" ==> ""]

                test
                    "Place items flex-end normal"
                    [ PlaceItems <| Flex.PlaceItems Flex.End Normal ]
                    ["" ==> ""]

                test
                    "Place items left auto"
                    [ PlaceItems <| Flex.PlaceItems Flex.Left Auto ]
                    ["" ==> ""]

                test
                    "Place items right normal"
                    [ PlaceItems <| Flex.PlaceItems Flex.Right Normal ]
                    ["" ==> ""]

                test
                    "Place items baseline normal"
                    [ PlaceItems <| Flex.PlaceItems Flex.Baseline Normal]
                    ["" ==> ""]

                test
                    "Place items first baseline auto"
                    [ PlaceItems <| Flex.PlaceItems Flex.FirstBaseline Auto]
                    ["" ==> ""]

                test
                    "Place items last baseline normal"
                    [ PlaceItems <| Flex.PlaceItems Flex.LastBaseline Normal]
                    ["" ==> ""]

                test
                    "Place items stretch auto"
                    [ PlaceItems <| Flex.PlaceItems Flex.Stretch Auto ]
                    ["" ==> ""]

                test
                    "Place items inherit"
                    [ PlaceItems Inherit ]
                    ["" ==> ""]

                test
                    "Place items initial"
                    [ PlaceItems Initial ]
                    ["" ==> ""]

                test
                    "Place items unset"
                    [ PlaceItems Unset ]
                    ["" ==> ""]

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
                    [ JustifyContent Flex.Normal]
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
                    "Align self normal"
                    [ AlignSelf Flex.AlignSelf.Normal]
                    ["alignSelf" ==> "normal"]

                test
                    "Align self flex start"
                    [ AlignSelf Flex.AlignSelf.SelfStart]
                    ["alignSelf" ==> "self-start"]

                test
                    "Align self flex end"
                    [ AlignSelf Flex.AlignSelf.SelfEnd]
                    ["alignSelf" ==> "self-end"]

                test
                    "Align self flex start"
                    [ AlignSelf Flex.AlignSelf.FlexStart]
                    ["alignSelf" ==> "flex-start"]

                test
                    "Align self flex end"
                    [ AlignSelf Flex.AlignSelf.FlexEnd]
                    ["alignSelf" ==> "flex-end"]

                test
                    "Align self center"
                    [ AlignSelf Flex.AlignSelf.Center]
                    ["alignSelf" ==> "center"]

                test
                    "Align self baseline"
                    [ AlignSelf Flex.AlignSelf.Baseline]
                    ["alignSelf" ==> "baseline"]

                test
                    "Align self stretch"
                    [ AlignSelf Flex.AlignSelf.Stretch]
                    ["alignSelf" ==> "stretch"]

                test
                    "Align self safe"
                    [ AlignSelf Flex.AlignSelf.Safe]
                    ["alignSelf" ==> "safe"]

                test
                    "Align self unsafe"
                    [ AlignSelf Flex.AlignSelf.Unsafe]
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
                    "Align items left"
                    [ AlignItems Flex.Left]
                    ["alignItems" ==> "left"]

                test
                    "Align items right"
                    [ AlignItems Flex.Right]
                    ["alignItems" ==> "right"]

                test
                    "Align items normal"
                    [ AlignItems Flex.Normal]
                    ["alignItems" ==> "normal"]

                test
                    "Align items baseline"
                    [ AlignItems Flex.Baseline]
                    ["alignItems" ==> "baseline"]

                test
                    "Align items space between"
                    [ AlignItems Flex.SpaceBetween]
                    ["alignItems" ==> "space-between"]

                test
                    "Align items space around"
                    [ AlignItems Flex.SpaceAround]
                    ["alignItems" ==> "space-around"]

                test
                    "Align items space evenly"
                    [ AlignItems Flex.SpaceEvenly]
                    ["alignItems" ==> "space-evenly"]

                test
                    "Align items right"
                    [ AlignItems Flex.Right]
                    ["alignItems" ==> "right"]

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
                    "Align content left"
                    [ AlignContent Flex.Left]
                    ["alignContent" ==> "left"]

                test
                    "Align content right"
                    [ AlignContent Flex.Right]
                    ["alignContent" ==> "right"]

                test
                    "Align content normal"
                    [ AlignContent Flex.Normal]
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
                    "Align content right"
                    [ AlignContent Flex.Right]
                    ["alignContent" ==> "right"]

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