namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Grid =
    let tests =
        testList "Grid"
            [
                testCase
                    "Grid area"
                    [ GridArea' "foo" ]
                    ["gridArea" ==> "foo"]
                testCase
                    "Grid area"
                    [ GridArea.value (GridPosition.ident "area1", GridPosition.ident "area2") ]
                    ["gridArea" ==> "area1 / area2"]
                testCase
                    "Grid area"
                    [ GridArea.value (GridPosition.span 3, GridPosition.ident "area2") ]
                    ["gridArea" ==> "span 3 / area2"]
                testCase
                    "Grid area"
                    [ GridArea.value (GridPosition.auto, GridPosition.auto) ]
                    ["gridArea" ==> "auto / auto"]
                testCase
                    "Grid area"
                    [ GridArea.value (GridPosition.auto, GridPosition.auto, GridPosition.auto) ]
                    ["gridArea" ==> "auto / auto / auto"]
                testCase
                    "Grid area"
                    [ GridArea.value (GridPosition.auto, GridPosition.auto, GridPosition.auto, GridPosition.auto) ]
                    ["gridArea" ==> "auto / auto / auto / auto"]
                testCase
                    "Grid area auto"
                    [ GridArea.auto ]
                    ["gridArea" ==> "auto"]
                testCase
                    "Grid area inherit"
                    [GridArea.inherit']
                    ["gridArea" ==> "inherit"]
                testCase
                    "Grid area initial"
                    [GridArea.initial]
                    ["gridArea" ==> "initial"]
                testCase
                    "Grid area unset"
                    [GridArea.unset]
                    ["gridArea" ==> "unset"]
                testCase
                    "Grid column ident and ident"
                    [ GridColumn.value(GridPosition.ident "someStart", GridPosition.ident "someEnd") ]
                    ["gridColumn" ==> "someStart / someEnd"]
                testCase
                    "Grid column ident and value"
                    [ GridColumn.value (GridPosition.ident "someStart", GridPosition.value 2) ]
                    ["gridColumn" ==> "someStart / 2"]
                testCase
                    "Grid column auto"
                    [GridColumn.auto]
                    ["gridColumn" ==> "auto"]
                testCase
                    "Grid column inherit"
                    [GridColumn.inherit']
                    ["gridColumn" ==> "inherit"]
                testCase
                    "Grid column initial"
                    [GridColumn.initial]
                    ["gridColumn" ==> "initial"]
                testCase
                    "Grid column unset"
                    [GridColumn.unset]
                    ["gridColumn" ==> "unset"]
                testCase
                    "Grid column start auto"
                    [GridColumnStart.auto]
                    ["gridColumnStart" ==> "auto"]
                testCase
                    "Grid column start value"
                    [GridColumnStart' 1]
                    ["gridColumnStart" ==> "1"]
                testCase
                    "Grid column start ident"
                    [GridColumnStart.ident "somegridarea"]
                    ["gridColumnStart" ==> "somegridarea"]
                testCase
                    "Grid column value ident and span"
                    [GridColumnStart.valueIdentSpan(1, "area") ]
                    ["gridColumnStart" ==> "1 area span"]
                testCase
                    "Grid column start span"
                    [GridColumnStart.span 2 ]
                    ["gridColumnStart" ==> "span 2"]
                testCase
                    "Grid column start inherit"
                    [GridColumnStart.inherit']
                    ["gridColumnStart" ==> "inherit"]
                testCase
                    "Grid column start initial"
                    [GridColumnStart.initial]
                    ["gridColumnStart" ==> "initial"]
                testCase
                    "Grid column start unset"
                    [GridColumnStart.unset]
                    ["gridColumnStart" ==> "unset"]
                testCase
                    "Grid column end auto"
                    [GridColumnEnd.auto]
                    ["gridColumnEnd" ==> "auto"]
                testCase
                    "Grid column end value"
                    [GridColumnEnd' 1]
                    ["gridColumnEnd" ==> "1"]
                testCase
                    "Grid column end ident"
                    [GridColumnEnd.ident "somegridarea"]
                    ["gridColumnEnd" ==> "somegridarea"]
                testCase
                    "Grid column value ident and span"
                    [GridColumnEnd.valueIdentSpan (1, "area") ]
                    ["gridColumnEnd" ==> "1 area span"]
                testCase
                    "Grid column end span"
                    [GridColumnEnd.span 2 ]
                    ["gridColumnEnd" ==> "span 2"]
                testCase
                    "Grid column end inherit"
                    [GridColumnEnd.inherit']
                    ["gridColumnEnd" ==> "inherit"]
                testCase
                    "Grid column end initial"
                    [GridColumnEnd.initial]
                    ["gridColumnEnd" ==> "initial"]
                testCase
                    "Grid column end unset"
                    [GridColumnEnd.unset]
                    ["gridColumnEnd" ==> "unset"]
                testCase
                    "Grid row ident and ident"
                    [ GridRow.value (GridPosition.ident "someStart", GridPosition.ident "someEnd") ]
                    ["gridRow" ==> "someStart / someEnd"]
                testCase
                    "Grid row ident and value"
                    [ GridRow.value (GridPosition.ident "someStart", GridPosition.value 2) ]
                    ["gridRow" ==> "someStart / 2"]
                testCase
                    "Grid row auto"
                    [GridRow.auto]
                    ["gridRow" ==> "auto"]
                testCase
                    "Grid row inherit"
                    [GridRow.inherit']
                    ["gridRow" ==> "inherit"]
                testCase
                    "Grid row initial"
                    [GridRow.initial]
                    ["gridRow" ==> "initial"]
                testCase
                    "Grid row unset"
                    [GridRow.unset]
                    ["gridRow" ==> "unset"]
                testCase
                    "Grid row start auto"
                    [GridRowStart.auto]
                    ["gridRowStart" ==> "auto"]
                testCase
                    "Grid row start value"
                    [GridRowStart' 1]
                    ["gridRowStart" ==> "1"]
                testCase
                    "Grid row start ident"
                    [GridRowStart.ident "somegridarea"]
                    ["gridRowStart" ==> "somegridarea"]
                testCase
                    "Grid row value ident and span"
                    [GridRowStart.valueIdentSpan (1, "area") ]
                    ["gridRowStart" ==> "1 area span"]
                testCase
                    "Grid row start span"
                    [GridRowStart.span 2]
                    ["gridRowStart" ==> "span 2"]
                testCase
                    "Grid row start inherit"
                    [GridRowStart.inherit']
                    ["gridRowStart" ==> "inherit"]
                testCase
                    "Grid row start initial"
                    [GridRowStart.initial]
                    ["gridRowStart" ==> "initial"]
                testCase
                    "Grid row start unset"
                    [GridRowStart.unset]
                    ["gridRowStart" ==> "unset"]
                testCase
                    "Grid row end auto"
                    [GridRowEnd.auto]
                    ["gridRowEnd" ==> "auto"]
                testCase
                    "Grid row end value"
                    [GridRowEnd' 1 ]
                    ["gridRowEnd" ==> "1"]
                testCase
                    "Grid row end ident"
                    [GridRowEnd.ident "somegridarea"]
                    ["gridRowEnd" ==> "somegridarea"]
                testCase
                    "Grid row value ident and span"
                    [GridRowEnd.valueIdentSpan (1, "area") ]
                    ["gridRowEnd" ==> "1 area span"]
                testCase
                    "Grid row end span"
                    [GridRowEnd.span 2 ]
                    ["gridRowEnd" ==> "span 2"]
                testCase
                    "Grid row end inherit"
                    [GridRowEnd.inherit']
                    ["gridRowEnd" ==> "inherit"]
                testCase
                    "Grid row end initial"
                    [GridRowEnd.initial]
                    ["gridRowEnd" ==> "initial"]
                testCase
                    "Grid row end unset"
                    [GridRowEnd.unset]
                    ["gridRowEnd" ==> "unset"]
                testCase
                    "Grid gap px"
                    [GridGap' (px 10)]
                    ["gridGap" ==> "10px"]
                testCase
                    "Grid gap em"
                    [GridGap' (em 1.)]
                    ["gridGap" ==> "1.0em"]
                testCase
                    "Grid gap percent"
                    [GridGap' (pct 16)]
                    ["gridGap" ==> "16%"]
                testCase
                    "Grid gap px and px"
                    [ GridGap.value (px 20, px 10) ]
                    ["gridGap" ==> "20px 10px"]
                testCase
                    "Grid gap em and em"
                    [GridGap.value (em 1., em 0.5) ]
                    ["gridGap" ==> "1.0em 0.5em"]
                testCase
                    "Grid gap vmin and vmax"
                    [GridGap.value (vmin 3., vmax 2.) ]
                    ["gridGap" ==> "3.0vmin 2.0vmax"]
                testCase
                    "Grid gap cm and mm"
                    [GridGap.value (cm 0.5, mm 2.) ]
                    ["gridGap" ==> "0.5cm 2.0mm"]
                testCase
                    "Grid gap percent and percent"
                    [GridGap.value (pct 16, pct 100) ]
                    ["gridGap" ==> "16% 100%"]
                testCase
                    "Grid gap px and percent"
                    [ GridGap.value (px 21, pct 82) ]
                    ["gridGap" ==> "21px 82%"]
                testCase
                    "Grid gap inherit"
                    [GridGap.inherit']
                    ["gridGap" ==> "inherit"]
                testCase
                    "Grid gap initial"
                    [GridGap.initial]
                    ["gridGap" ==> "initial"]
                testCase
                    "Grid gap unset"
                    [GridGap.unset]
                    ["gridGap" ==> "unset"]
                testCase
                    "Row gap normal"
                    [GridRowGap.normal]
                    ["gridRowGap" ==> "normal"]
                testCase
                    "Row gap px"
                    [GridRowGap' (px 3)]
                    ["gridRowGap" ==> "3px"]
                testCase
                    "Row gap em"
                    [GridRowGap' (em 2.5)]
                    ["gridRowGap" ==> "2.5em"]
                testCase
                    "Row gap percent"
                    [GridRowGap' (pct 3)]
                    ["gridRowGap" ==> "3%"]
                testCase
                    "Row gap inherit"
                    [GridRowGap.inherit']
                    ["gridRowGap" ==> "inherit"]
                testCase
                    "Row gap initial"
                    [GridRowGap.initial]
                    ["gridRowGap" ==> "initial"]
                testCase
                    "Row gap unset"
                    [GridRowGap.unset]
                    ["gridRowGap" ==> "unset"]
                testCase
                    "Column gap normal"
                    [GridColumnGap.normal]
                    ["gridColumnGap" ==> "normal"]
                testCase
                    "Column gap px"
                    [GridColumnGap' (px 3)]
                    ["gridColumnGap" ==> "3px"]
                testCase
                    "Column gap em"
                    [GridColumnGap' (em 2.5)]
                    ["gridColumnGap" ==> "2.5em"]
                testCase
                    "Column gap percent"
                    [GridColumnGap' (pct 3)]
                    ["gridColumnGap" ==> "3%"]
                testCase
                    "Column gap inherit"
                    [GridColumnGap.inherit']
                    ["gridColumnGap" ==> "inherit"]
                testCase
                    "Column gap initial"
                    [GridColumnGap.initial]
                    ["gridColumnGap" ==> "initial"]
                testCase
                    "Column gap unset"
                    [GridColumnGap.unset]
                    ["gridColumnGap" ==> "unset"]
                testCase
                    "Grid template row px"
                    [GridTemplateRows' (px 100)]
                    ["gridTemplateRows" ==> "100px"]
                testCase
                    "Grid template row minmax"
                    [GridTemplateRows.minMax (px 100, fr 1.) ]
                    ["gridTemplateRows" ==> "minmax(100px, 1.00fr)"]
                testCase
                    "Grid template row fit-content"
                    [GridTemplateRows.fitContent(px 100)]
                    ["gridTemplateRows" ==> "fit-content(100px)"]
                testCase
                    "Grid template row repeat"
                    [GridTemplateRows.repeat(3, px 200)]
                    ["gridTemplateRows" ==> "repeat(3, 200px)"]
                testCase
                    "Grid template row subgrid"
                    [GridTemplateRows.subgrid ]
                    ["gridTemplateRows" ==> "subgrid"]
                testCase
                    "Grid template row masonry"
                    [GridTemplateRows.masonry ]
                    ["gridTemplateRows" ==> "masonry"]
                testCase
                    "Grid template row none"
                    [GridTemplateRows.none]
                    ["gridTemplateRows" ==> "none"]
                testCase
                    "Grid template row px repeat px"
                    [GridTemplateRows.values [ px 200; FssTypes.Grid.Repeat.Repeat(FssTypes.Grid.AutoFill, px 100); px 300]]
                    ["gridTemplateRows" ==> "200px repeat(auto-fill, 100px) 300px"]
                testCase
                    "Grid template row minmax repeat percent"
                    [GridTemplateRows.values [
                        FssTypes.Grid.MinMax.MinMax(px 100, FssTypes.ContentSize.MaxContent)
                        FssTypes.Grid.Repeat.Repeat(FssTypes.Grid.AutoFill, px 200); pct 20
                    ]]
                    ["gridTemplateRows" ==> "minmax(100px, max-content) repeat(auto-fill, 200px) 20%"]
                testCase
                    "Grid template row auto"
                    [GridTemplateRows.auto]
                    ["gridTemplateRows" ==> "auto"]
                testCase
                    "Grid template row inherit"
                    [GridTemplateRows.inherit']
                    ["gridTemplateRows" ==> "inherit"]
                testCase
                    "Grid template row initial"
                    [GridTemplateRows.initial]
                    ["gridTemplateRows" ==> "initial"]
                testCase
                    "Grid template row unset"
                    [GridTemplateRows.unset]
                    ["gridTemplateRows" ==> "unset"]
                testCase
                    "Grid template column px"
                    [GridTemplateColumns' (px 100)]
                    ["gridTemplateColumns" ==> "100px"]
                testCase
                    "Grid template column minmax"
                    [GridTemplateColumns.minMax(px 100, fr 1.)]
                    ["gridTemplateColumns" ==> "minmax(100px, 1.00fr)"]
                testCase
                    "Grid template column fit-content"
                    [GridTemplateColumns.fitContent(px 100)]
                    ["gridTemplateColumns" ==> "fit-content(100px)"]
                testCase
                    "Grid template column repeat"
                    [GridTemplateColumns.repeat(3, px 200)]
                    ["gridTemplateColumns" ==> "repeat(3, 200px)"]
                testCase
                    "Grid template column subgrid"
                    [GridTemplateColumns.subgrid]
                    ["gridTemplateColumns" ==> "subgrid"]
                testCase
                    "Grid template column masonry"
                    [GridTemplateColumns.masonry]
                    ["gridTemplateColumns" ==> "masonry"]
                testCase
                    "Grid template column none"
                    [GridTemplateColumns.none]
                    ["gridTemplateColumns" ==> "none"]
                testCase
                    "Grid template column px repeat px"
                    [GridTemplateColumns.values [px 200; FssTypes.Grid.Repeat.Repeat(FssTypes.Grid.AutoFill, px 100); px 300]]
                    ["gridTemplateColumns" ==> "200px repeat(auto-fill, 100px) 300px"]
                testCase
                    "Grid template column minmax repeat percent"
                    [GridTemplateColumns.values [ FssTypes.Grid.MinMax.MinMax(px 100, FssTypes.ContentSize.MaxContent); FssTypes.Grid.Repeat.Repeat(FssTypes.Grid.AutoFill, px 200); pct 20 ]]
                    ["gridTemplateColumns" ==> "minmax(100px, max-content) repeat(auto-fill, 200px) 20%"]
                testCase
                    "Grid template column auto"
                    [GridTemplateColumns.auto]
                    ["gridTemplateColumns" ==> "auto"]
                testCase
                    "Grid template column inherit"
                    [GridTemplateColumns.inherit']
                    ["gridTemplateColumns" ==> "inherit"]
                testCase
                    "Grid template column initial"
                    [GridTemplateColumns.initial]
                    ["gridTemplateColumns" ==> "initial"]
                testCase
                    "Grid template column unset"
                    [GridTemplateColumns.unset]
                    ["gridTemplateColumns" ==> "unset"]
                testString
                    "Repeat value and percent"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, fr 1.))
                    "GridRepeat (repeat(4, 1.00fr))"
                testString
                    "Repeat value and percent"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, pct 60))
                    "GridRepeat (repeat(4, 60%))"
                testString
                    "Repeat value and pixels"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, px 250))
                    "GridRepeat (repeat(4, 250px))"
                testString
                    "Repeat value and min-content"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, FssTypes.ContentSize.MinContent))
                    "GridRepeat (repeat(4, min-content))"
                testString
                    "Repeat value and max-content"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, FssTypes.ContentSize.MaxContent))
                    "GridRepeat (repeat(4, max-content))"
                testString
                    "Repeat value and minmax"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, FssTypes.Grid.MinMax.MinMax(px 100, fr 1.)))
                    "GridRepeat (repeat(4, minmax(100px, 1.00fr)))"
                testString
                    "Repeat value and fit content"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, FssTypes.ContentSize.FitContent(px 100)))
                    "GridRepeat (repeat(4, fit-content(100px)))"
                testString
                    "Repeat value and min-content max-content"
                    (string <| FssTypes.Grid.Repeat.Repeat(4, [FssTypes.ContentSize.MinContent; FssTypes.ContentSize.MaxContent]))
                    "GridRepeat (repeat(4, min-content max-content))"
                testString
                    "Repeat auto-fill and px"
                    (string <| FssTypes.Grid.Repeat.Repeat(FssTypes.Grid.AutoFill, px 30))
                    "GridRepeat (repeat(auto-fill, 30px))"
                testString
                    "Repeat auto-fit and px"
                    (string <| FssTypes.Grid.Repeat.Repeat(FssTypes.Grid.AutoFit, px 30))
                    "GridRepeat (repeat(auto-fit, 30px))"
                testString
                    "MinMax px and fraction"
                    (string <| FssTypes.Grid.MinMax.MinMax(px 200, fr 1.5))
                    "MinMaxGrid (minmax(200px, 1.50fr))"
                testString
                    "MinMax px and percent"
                    (string <| FssTypes.Grid.MinMax.MinMax(px 400, pct 50))
                    "MinMaxGrid (minmax(400px, 50%))"
                testString
                    "MinMax percent and px"
                    (string <| FssTypes.Grid.MinMax.MinMax(pct 30, px 300))
                    "MinMaxGrid (minmax(30%, 300px))"
                testString
                    "MinMax px and max content"
                    (string <| FssTypes.Grid.MinMax.MinMax(px 100, FssTypes.ContentSize.MaxContent))
                    "MinMaxGrid (minmax(100px, max-content))"
                testString
                    "MinMax min content and px"
                    (string <| FssTypes.Grid.MinMax.MinMax(FssTypes.ContentSize.MinContent, px 400))
                    "MinMaxGrid (minmax(min-content, 400px))"
                testString
                    "MinMax px and fr"
                    (string <| FssTypes.Grid.MinMax.MinMax(px 200, fr 1.) )
                    "MinMaxGrid (minmax(200px, 1.00fr))"
                testString
                    "MinMax percent and min content"
                    (string <| FssTypes.Grid.MinMax.MinMax(pct 50, FssTypes.ContentSize.MinContent))
                    "MinMaxGrid (minmax(50%, min-content))"
                testString
                    "MinMax percent and max content"
                    (string <| FssTypes.Grid.MinMax.MinMax(px 300, FssTypes.ContentSize.MaxContent))
                    "MinMaxGrid (minmax(300px, max-content))"
                testString
                    "MinMax pct and px"
                    (string <| FssTypes.Grid.MinMax.MinMax(pct 30, px 300))
                    "MinMaxGrid (minmax(30%, 300px))"
                testString
                    "MinMax min content and px"
                    (string <| FssTypes.Grid.MinMax.MinMax(FssTypes.ContentSize.MinContent, px 200))
                    "MinMaxGrid (minmax(min-content, 200px))"
                testCase
                    "Grid auto columns min content"
                    [GridAutoColumns.minContent]
                    ["gridAutoColumns" ==> "min-content"]
                testCase
                    "Grid auto columns max content"
                    [GridAutoColumns.maxContent]
                    ["gridAutoColumns" ==> "max-content"]
                testCase
                    "Grid auto columns auto"
                    [GridAutoColumns.auto]
                    ["gridAutoColumns" ==> "auto"]
                testCase
                    "Grid auto columns px"
                    [GridAutoColumns' (px 100)]
                    ["gridAutoColumns" ==> "100px"]
                testCase
                    "Grid auto columns cm"
                    [GridAutoColumns' (cm 20.)]
                    ["gridAutoColumns" ==> "20.0cm"]
                testCase
                    "Grid auto columns vmax"
                    [GridAutoColumns' (vmax 50.)]
                    ["gridAutoColumns" ==> "50.0vmax"]
                testCase
                    "Grid auto columns percent"
                    [GridAutoColumns' (pct 10)]
                    ["gridAutoColumns" ==> "10%"]
                testCase
                    "Grid auto columns fr"
                    [GridAutoColumns' (fr 0.5)]
                    ["gridAutoColumns" ==> "0.50fr"]
                testCase
                    "Grid auto columns fit content"
                    [GridAutoColumns.fitContent(px 400) ]
                    ["gridAutoColumns" ==> "fit-content(400px)"]
                testCase
                    "Grid auto columns multiple with min-content max-content and auto"
                    [ GridAutoColumns.values [FssTypes.ContentSize.MinContent; FssTypes.ContentSize.MaxContent] ]
                    ["gridAutoColumns" ==> "min-content max-content"]
                testCase
                    "Grid auto columns multiple with pxs"
                    [ GridAutoColumns.values [px 100; px 150; px 390;] ]
                    ["gridAutoColumns" ==> "100px 150px 390px"]
                testCase
                    "Grid auto columns multiple with percents"
                    [ GridAutoColumns.values [pct 10; pct 33] ]
                    ["gridAutoColumns" ==> "10% 33%"]
                testCase
                    "Grid auto columns multiple with fractions"
                    [ GridAutoColumns.values [fr 0.5; fr 3.; fr 1.] ]
                    ["gridAutoColumns" ==> "0.50fr 3.00fr 1.00fr"]
                testCase
                    "Grid auto columns inherit"
                    [GridAutoColumns.inherit']
                    ["gridAutoColumns" ==> "inherit"]
                testCase
                    "Grid auto columns initial"
                    [GridAutoColumns.initial]
                    ["gridAutoColumns" ==> "initial"]
                testCase
                    "Grid auto columns unset"
                    [GridAutoColumns.unset]
                    ["gridAutoColumns" ==> "unset"]
                testCase
                    "Grid auto rows min content"
                    [GridAutoRows.minContent]
                    ["gridAutoRows" ==> "min-content"]
                testCase
                    "Grid auto rows max content"
                    [GridAutoRows.maxContent]
                    ["gridAutoRows" ==> "max-content"]
                testCase
                    "Grid auto rows auto"
                    [GridAutoRows.auto]
                    ["gridAutoRows" ==> "auto"]
                testCase
                    "Grid auto rows px"
                    [GridAutoRows' (px 100)]
                    ["gridAutoRows" ==> "100px"]
                testCase
                    "Grid auto rows cm"
                    [GridAutoRows' (cm 20.)]
                    ["gridAutoRows" ==> "20.0cm"]
                testCase
                    "Grid auto rows vmax"
                    [GridAutoRows' (vmax 50.)]
                    ["gridAutoRows" ==> "50.0vmax"]
                testCase
                    "Grid auto rows percent"
                    [GridAutoRows' (pct 10)]
                    ["gridAutoRows" ==> "10%"]
                testCase
                    "Grid auto rows fr"
                    [GridAutoRows' (fr 0.5)]
                    ["gridAutoRows" ==> "0.50fr"]
                testCase
                    "Grid auto rows fit content"
                    [GridAutoRows.fitContent(px 400) ]
                    ["gridAutoRows" ==> "fit-content(400px)"]
                testCase
                    "Grid auto rows multiple with min-content max-content and auto"
                    [ GridAutoRows.values [FssTypes.ContentSize.MinContent; FssTypes.ContentSize.MaxContent] ]
                    ["gridAutoRows" ==> "min-content max-content"]
                testCase
                    "Grid auto rows multiple with pxs"
                    [ GridAutoRows.values [px 100; px 150; px 390;] ]
                    ["gridAutoRows" ==> "100px 150px 390px"]
                testCase
                    "Grid auto rows multiple with percents"
                    [ GridAutoRows.values [pct 10; pct 33] ]
                    ["gridAutoRows" ==> "10% 33%"]
                testCase
                    "Grid auto rows multiple with fractions"
                    [ GridAutoRows.values [fr 0.5; fr 3.; fr 1.] ]
                    ["gridAutoRows" ==> "0.50fr 3.00fr 1.00fr"]
                testCase
                    "Grid auto rows inherit"
                    [GridAutoRows.inherit']
                    ["gridAutoRows" ==> "inherit"]
                testCase
                    "Grid auto rows initial"
                    [GridAutoRows.initial]
                    ["gridAutoRows" ==> "initial"]
                testCase
                    "Grid auto rows unset"
                    [GridAutoRows.unset]
                    ["gridAutoRows" ==> "unset"]
                testCase
                    "Grid auto flow rows"
                    [GridAutoFlow.row]
                    ["gridAutoFlow" ==> "row"]
                testCase
                    "Grid auto flow columns"
                    [GridAutoFlow.column]
                    ["gridAutoFlow" ==> "column"]
                testCase
                    "Grid auto flow dense"
                    [GridAutoFlow.dense]
                    ["gridAutoFlow" ==> "dense"]
                testCase
                    "Grid auto flow rows dense"
                    [GridAutoFlow.rowDense]
                    ["gridAutoFlow" ==> "row dense"]
                testCase
                    "Grid auto flow columns dense"
                    [GridAutoFlow.columnDense]
                    ["gridAutoFlow" ==> "column dense"]
                testCase
                    "Grid auto flow inherit"
                    [GridAutoFlow.inherit']
                    ["gridAutoFlow" ==> "inherit"]
                testCase
                    "Grid auto flow initial"
                    [GridAutoFlow.initial]
                    ["gridAutoFlow" ==> "initial"]
                testCase
                    "Grid auto flow unset"
                    [GridAutoFlow.unset]
                    ["gridAutoFlow" ==> "unset"]
                testCase
                    "Grid template areas None"
                    [GridTemplateAreas.none]
                    ["gridTemplateAreas" ==> "none"]
                testCase
                    "Grid template areas strings"
                    [GridTemplateAreas.value [ "a"; "b"  ] ]
                    ["gridTemplateAreas" ==> "\"a b\""]
                testCase
                    "Grid template areas multiple strings"
                    [GridTemplateAreas.value
                         [
                            [ "header";  "header";  "header";  "header" ]
                            [ "main";  "main";  ".";  "sidebar" ]
                            [ "footer";  "footer";  "footer";  "footer" ]
                        ]
                    ]
                    ["gridTemplateAreas" ==> "\"header header header header\" \"main main . sidebar\" \"footer footer footer footer\""]
                testCase
                    "Grid template areas inherit"
                    [GridTemplateAreas.inherit' ]
                    ["gridTemplateAreas" ==> "inherit"]
                testCase
                    "Grid template areas initial"
                    [GridTemplateAreas.initial]
                    ["gridTemplateAreas" ==> "initial"]
                testCase
                    "Grid template areas multiple unset"
                    [GridTemplateAreas.unset]
                    ["gridTemplateAreas" ==> "unset"]
            ]
