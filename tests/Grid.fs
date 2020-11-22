namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Grid =
    let tests =
        testList "Grid"
            [
                test
                    "Grid area"
                    [ GridArea' (GridPosition.Ident "foo") ]
                    ["gridArea" ==> "foo"]
                test
                    "Grid area"
                    [ GridArea.Value (GridPosition.Ident "area1", GridPosition.Ident "area2") ]
                    ["gridArea" ==> "area1 / area2"]
                test
                    "Grid area"
                    [ GridArea.Value (GridPosition.Span 3, GridPosition.Ident "area2") ]
                    ["gridArea" ==> "span 3 / area2"]
                test
                    "Grid area"
                    [ GridArea.Value (GridPosition.Auto, GridPosition.Auto) ]
                    ["gridArea" ==> "auto / auto"]
                test
                    "Grid area"
                    [ GridArea.Value (GridPosition.Auto, GridPosition.Auto, GridPosition.Auto) ]
                    ["gridArea" ==> "auto / auto / auto"]
                test
                    "Grid area"
                    [ GridArea.Value (GridPosition.Auto, GridPosition.Auto, GridPosition.Auto, GridPosition.Auto) ]
                    ["gridArea" ==> "auto / auto / auto / auto"]
                test
                    "Grid area auto"
                    [ GridArea.Auto ]
                    ["gridArea" ==> "auto"]
                test
                    "Grid area inherit"
                    [GridArea.Inherit]
                    ["gridArea" ==> "inherit"]
                test
                    "Grid area initial"
                    [GridArea.Initial]
                    ["gridArea" ==> "initial"]
                test
                    "Grid area unset"
                    [GridArea.Unset]
                    ["gridArea" ==> "unset"]
                test
                    "Grid column ident and ident"
                    [ GridColumn.Value(GridPosition.Ident "someStart", GridPosition.Ident "someEnd") ]
                    ["gridColumn" ==> "someStart / someEnd"]
                test
                    "Grid column ident and value"
                    [ GridColumn.Value (GridPosition.Ident "someStart", GridPosition.Value 2) ]
                    ["gridColumn" ==> "someStart / 2"]
                test
                    "Grid column auto"
                    [GridColumn.Auto]
                    ["gridColumn" ==> "auto"]
                test
                    "Grid column inherit"
                    [GridColumn.Inherit]
                    ["gridColumn" ==> "inherit"]
                test
                    "Grid column initial"
                    [GridColumn.Initial]
                    ["gridColumn" ==> "initial"]
                test
                    "Grid column unset"
                    [GridColumn.Unset]
                    ["gridColumn" ==> "unset"]
                test
                    "Grid column start auto"
                    [GridColumnStart.Auto]
                    ["gridColumnStart" ==> "auto"]
                test
                    "Grid column start value"
                    [GridColumnStart' 1]
                    ["gridColumnStart" ==> "1"]
                test
                    "Grid column start ident"
                    [GridColumnStart.Ident "somegridarea"]
                    ["gridColumnStart" ==> "somegridarea"]
                test
                    "Grid column value ident and span"
                    [GridColumnStart.ValueIdentSpan(1, "area") ]
                    ["gridColumnStart" ==> "1 area span"]
                test
                    "Grid column start span"
                    [GridColumnStart.Span 2 ]
                    ["gridColumnStart" ==> "span 2"]
                test
                    "Grid column start inherit"
                    [GridColumnStart.Inherit]
                    ["gridColumnStart" ==> "inherit"]
                test
                    "Grid column start initial"
                    [GridColumnStart.Initial]
                    ["gridColumnStart" ==> "initial"]
                test
                    "Grid column start unset"
                    [GridColumnStart.Unset]
                    ["gridColumnStart" ==> "unset"]
                test
                    "Grid column end auto"
                    [GridColumnEnd.Auto]
                    ["gridColumnEnd" ==> "auto"]
                test
                    "Grid column end value"
                    [GridColumnEnd' 1]
                    ["gridColumnEnd" ==> "1"]
                test
                    "Grid column end ident"
                    [GridColumnEnd.Ident "somegridarea"]
                    ["gridColumnEnd" ==> "somegridarea"]
                test
                    "Grid column value ident and span"
                    [GridColumnEnd.ValueIdentSpan (1, "area") ]
                    ["gridColumnEnd" ==> "1 area span"]
                test
                    "Grid column end span"
                    [GridColumnEnd.Span 2 ]
                    ["gridColumnEnd" ==> "span 2"]
                test
                    "Grid column end inherit"
                    [GridColumnEnd.Inherit]
                    ["gridColumnEnd" ==> "inherit"]
                test
                    "Grid column end initial"
                    [GridColumnEnd.Initial]
                    ["gridColumnEnd" ==> "initial"]
                test
                    "Grid column end unset"
                    [GridColumnEnd.Unset]
                    ["gridColumnEnd" ==> "unset"]
                test
                    "Grid row ident and ident"
                    [ GridRow.Value (GridPosition.Ident "someStart", GridPosition.Ident "someEnd") ]
                    ["gridRow" ==> "someStart / someEnd"]
                test
                    "Grid row ident and value"
                    [ GridRow.Value (GridPosition.Ident "someStart", GridPosition.Value 2) ]
                    ["gridRow" ==> "someStart / 2"]
                test
                    "Grid row auto"
                    [GridRow.Auto]
                    ["gridRow" ==> "auto"]
                test
                    "Grid row inherit"
                    [GridRow.Inherit]
                    ["gridRow" ==> "inherit"]
                test
                    "Grid row initial"
                    [GridRow.Initial]
                    ["gridRow" ==> "initial"]
                test
                    "Grid row unset"
                    [GridRow.Unset]
                    ["gridRow" ==> "unset"]
                test
                    "Grid row start auto"
                    [GridRowStart.Auto]
                    ["gridRowStart" ==> "auto"]
                test
                    "Grid row start value"
                    [GridRowStart' 1]
                    ["gridRowStart" ==> "1"]
                test
                    "Grid row start ident"
                    [GridRowStart.Ident "somegridarea"]
                    ["gridRowStart" ==> "somegridarea"]
                test
                    "Grid row value ident and span"
                    [GridRowStart.ValueIdentSpan (1, "area") ]
                    ["gridRowStart" ==> "1 area span"]
                test
                    "Grid row start span"
                    [GridRowStart.Span 2]
                    ["gridRowStart" ==> "span 2"]
                test
                    "Grid row start inherit"
                    [GridRowStart.Inherit]
                    ["gridRowStart" ==> "inherit"]
                test
                    "Grid row start initial"
                    [GridRowStart.Initial]
                    ["gridRowStart" ==> "initial"]
                test
                    "Grid row start unset"
                    [GridRowStart.Unset]
                    ["gridRowStart" ==> "unset"]
                test
                    "Grid row end auto"
                    [GridRowEnd.Auto]
                    ["gridRowEnd" ==> "auto"]
                test
                    "Grid row end value"
                    [GridRowEnd' 1 ]
                    ["gridRowEnd" ==> "1"]
                test
                    "Grid row end ident"
                    [GridRowEnd.Ident "somegridarea"]
                    ["gridRowEnd" ==> "somegridarea"]
                test
                    "Grid row value ident and span"
                    [GridRowEnd.ValueIdentSpan (1, "area") ]
                    ["gridRowEnd" ==> "1 area span"]
                test
                    "Grid row end span"
                    [GridRowEnd.Span 2 ]
                    ["gridRowEnd" ==> "span 2"]
                test
                    "Grid row end inherit"
                    [GridRowEnd.Inherit]
                    ["gridRowEnd" ==> "inherit"]
                test
                    "Grid row end initial"
                    [GridRowEnd.Initial]
                    ["gridRowEnd" ==> "initial"]
                test
                    "Grid row end unset"
                    [GridRowEnd.Unset]
                    ["gridRowEnd" ==> "unset"]
                test
                    "Grid gap px"
                    [GridGap' (px 10)]
                    ["gridGap" ==> "10px"]
                test
                    "Grid gap em"
                    [GridGap' (em 1.)]
                    ["gridGap" ==> "1.0em"]
                test
                    "Grid gap percent"
                    [GridGap' (pct 16)]
                    ["gridGap" ==> "16%"]
                test
                    "Grid gap px and px"
                    [ GridGap.Value (px 20, px 10) ]
                    ["gridGap" ==> "20px 10px"]
                test
                    "Grid gap em and em"
                    [GridGap.Value (em 1., em 0.5) ]
                    ["gridGap" ==> "1.0em 0.5em"]
                test
                    "Grid gap vmin and vmax"
                    [GridGap.Value (vmin 3., vmax 2.) ]
                    ["gridGap" ==> "3.0vmin 2.0vmax"]
                test
                    "Grid gap cm and mm"
                    [GridGap.Value (cm 0.5, mm 2.) ]
                    ["gridGap" ==> "0.5cm 2.0mm"]
                test
                    "Grid gap percent and percent"
                    [GridGap.Value (pct 16, pct 100) ]
                    ["gridGap" ==> "16% 100%"]
                test
                    "Grid gap px and percent"
                    [ GridGap.Value (px 21, pct 82) ]
                    ["gridGap" ==> "21px 82%"]
                test
                    "Grid gap inherit"
                    [GridGap.Inherit]
                    ["gridGap" ==> "inherit"]
                test
                    "Grid gap initial"
                    [GridGap.Initial]
                    ["gridGap" ==> "initial"]
                test
                    "Grid gap unset"
                    [GridGap.Unset]
                    ["gridGap" ==> "unset"]
                test
                    "Column gap normal"
                    [GridColumnGap.Normal]
                    ["gridColumnGap" ==> "normal"]
                test
                    "Column gap px"
                    [GridColumnGap' (px 3)]
                    ["gridColumnGap" ==> "3px"]
                test
                    "Column gap em"
                    [GridColumnGap' (em 2.5)]
                    ["gridColumnGap" ==> "2.5em"]
                test
                    "Column gap percent"
                    [GridColumnGap' (pct 3)]
                    ["gridColumnGap" ==> "3%"]
                test
                    "Column gap inherit"
                    [GridColumnGap.Inherit]
                    ["gridColumnGap" ==> "inherit"]
                test
                    "Column gap initial"
                    [GridColumnGap.Initial]
                    ["gridColumnGap" ==> "initial"]
                test
                    "Column gap unset"
                    [GridColumnGap.Unset]
                    ["gridColumnGap" ==> "unset"]
                test
                    "Row gap normal"
                    [GridRowGap.Normal]
                    ["gridRowGap" ==> "normal"]
                test
                    "Row gap px"
                    [GridRowGap' (px 3)]
                    ["gridRowGap" ==> "3px"]
                test
                    "Row gap em"
                    [GridRowGap' (em 2.5)]
                    ["gridRowGap" ==> "2.5em"]
                test
                    "Row gap percent"
                    [GridRowGap' (pct 3)]
                    ["gridRowGap" ==> "3%"]
                test
                    "Row gap inherit"
                    [GridRowGap.Inherit]
                    ["gridRowGap" ==> "inherit"]
                test
                    "Row gap initial"
                    [GridRowGap.Initial]
                    ["gridRowGap" ==> "initial"]
                test
                    "Row gap unset"
                    [GridRowGap.Unset]
                    ["gridRowGap" ==> "unset"]
                test
                    "Grid template row px"
                    [GridTemplateRows' (px 100)]
                    ["gridTemplateRows" ==> "100px"]
                test
                    "Grid template row minmax"
                    [GridTemplateRows.MinMax (px 100, fr 1.) ]
                    ["gridTemplateRows" ==> "minmax(100px, 1.00fr)"]
                test
                    "Grid template row fit-content"
                    [GridTemplateRows.FitContent(px 100)]
                    ["gridTemplateRows" ==> "fit-content(100px)"]
                test
                    "Grid template row repeat"
                    [GridTemplateRows.Repeat(3, px 200)]
                    ["gridTemplateRows" ==> "repeat(3, 200px)"]
                test
                    "Grid template row subgrid"
                    [GridTemplateRows.Subgrid ]
                    ["gridTemplateRows" ==> "subgrid"]
                test
                    "Grid template row none"
                    [GridTemplateRows.None]
                    ["gridTemplateRows" ==> "none"]
                test
                    "Grid template row px repeat px"
                    [GridTemplateRows.Values [ px 200; Grid.Repeat.Repeat(RepeatType.AutoFill, px 100); px 300]]
                    ["gridTemplateRows" ==> "200px repeat(auto-fill, 100px) 300px"]
                test
                    "Grid template row minmax repeat percent"
                    [GridTemplateRows.Values [
                        MinMax.MinMax(px 100, ContentSize.MaxContent)
                        Repeat.Repeat(Grid.AutoFill, px 200); pct 20
                    ]]
                    ["gridTemplateRows" ==> "minmax(100px, max-content) repeat(auto-fill, 200px) 20%"]
                test
                    "Grid template row auto"
                    [GridTemplateRows.Auto]
                    ["gridTemplateRows" ==> "auto"]
                test
                    "Grid template row inherit"
                    [GridTemplateRows.Inherit]
                    ["gridTemplateRows" ==> "inherit"]
                test
                    "Grid template row initial"
                    [GridTemplateRows.Initial]
                    ["gridTemplateRows" ==> "initial"]
                test
                    "Grid template row unset"
                    [GridTemplateRows.Unset]
                    ["gridTemplateRows" ==> "unset"]
                test
                    "Grid template column px"
                    [GridTemplateColumns' (px 100)]
                    ["gridTemplateColumns" ==> "100px"]
                test
                    "Grid template column minmax"
                    [GridTemplateColumns.MinMax(px 100, fr 1.)]
                    ["gridTemplateColumns" ==> "minmax(100px, 1.00fr)"]
                test
                    "Grid template column fit-content"
                    [GridTemplateColumns.FitContent(px 100)]
                    ["gridTemplateColumns" ==> "fit-content(100px)"]
                test
                    "Grid template column repeat"
                    [GridTemplateColumns.Repeat(3, px 200)]
                    ["gridTemplateColumns" ==> "repeat(3, 200px)"]
                test
                    "Grid template column subgrid"
                    [GridTemplateColumns.Subgrid]
                    ["gridTemplateColumns" ==> "subgrid"]
                test
                    "Grid template column none"
                    [GridTemplateColumns.None]
                    ["gridTemplateColumns" ==> "none"]
                test
                    "Grid template column px repeat px"
                    [GridTemplateColumns.Values [px 200; Repeat.Repeat(Grid.AutoFill, px 100); px 300]]
                    ["gridTemplateColumns" ==> "200px repeat(auto-fill, 100px) 300px"]
                test
                    "Grid template column minmax repeat percent"
                    [GridTemplateColumns.Values [ MinMax.MinMax(px 100, ContentSizeType.MaxContent); Repeat.Repeat(Grid.AutoFill, px 200); pct 20 ]]
                    ["gridTemplateColumns" ==> "minmax(100px, max-content) repeat(auto-fill, 200px) 20%"]
                test
                    "Grid template column auto"
                    [GridTemplateColumns.Auto]
                    ["gridTemplateColumns" ==> "auto"]
                test
                    "Grid template column inherit"
                    [GridTemplateColumns.Inherit]
                    ["gridTemplateColumns" ==> "inherit"]
                test
                    "Grid template column initial"
                    [GridTemplateColumns.Initial]
                    ["gridTemplateColumns" ==> "initial"]
                test
                    "Grid template column unset"
                    [GridTemplateColumns.Unset]
                    ["gridTemplateColumns" ==> "unset"]
                testString
                    "Repeat value and fr"
                    (string <| Repeat.Repeat(4, fr 1.))
                    "GridRepeat repeat(4, 1.00fr)"
                testString
                    "Repeat value and percent"
                    (string <| Repeat.Repeat(4, pct 60))
                    "GridRepeat repeat(4, 60%)"
                testString
                    "Repeat value and pixels"
                    (string <| Repeat.Repeat(4, px 250))
                    "GridRepeat repeat(4, 250px)"
                testString
                    "Repeat value and min-content"
                    (string <| Repeat.Repeat(4, ContentSizeType.MinContent))
                    "GridRepeat repeat(4, min-content)"
                testString
                    "Repeat value and max-content"
                    (string <| Repeat.Repeat(4, ContentSizeType.MaxContent))
                    "GridRepeat repeat(4, max-content)"
                testString
                    "Repeat value and minmax"
                    (string <| Repeat.Repeat(4, MinMax.MinMax(px 100, fr 1.)))
                    "GridRepeat repeat(4, minmax(100px, 1.00fr))"
                testString
                    "Repeat value and fit content"
                    (string <| Repeat.Repeat(4, ContentSizeType.FitContent(px 100)))
                    "GridRepeat repeat(4, fit-content(100px))"
                testString
                    "Repeat value and px pct and auto"
                    (string <| Repeat.Repeat(4, [px 10 :> ILengthPercentage; pct 30 :> ILengthPercentage]) )
                    "GridRepeat repeat(4, 10px 30%)"
                testString
                    "Repeat value and min-content max-content"
                    (string <| Repeat.Repeat(4, [ContentSizeType.MinContent; ContentSizeType.MaxContent]))
                    "GridRepeat repeat(4, min-content max-content)"
                testString
                    "Repeat auto-fill and px"
                    (string <| Repeat.Repeat(AutoFill, px 30))
                    "GridRepeat repeat(auto-fill, 30px)"
                testString
                    "Repeat auto-fit and px"
                    (string <| Repeat.Repeat(AutoFit, px 30))
                    "GridRepeat repeat(auto-fit, 30px)"
                testString
                    "MinMax px and fraction"
                    (string <| MinMax.MinMax(px 200, fr 1.5))
                    "MinMaxGrid minmax(200px, 1.50fr)"
                testString
                    "MinMax px and percent"
                    (string <| MinMax.MinMax(px 400, pct 50))
                    "MinMaxGrid minmax(400px, 50%)"
                testString
                    "MinMax percent and px"
                    (string <| MinMax.MinMax(pct 30, px 300))
                    "MinMaxGrid minmax(30%, 300px)"
                testString
                    "MinMax px and max content"
                    (string <| MinMax.MinMax(px 100, ContentSizeType.MaxContent))
                    "MinMaxGrid minmax(100px, max-content)"
                testString
                    "MinMax min content and px"
                    (string <| MinMax.MinMax(ContentSizeType.MinContent, px 400))
                    "MinMaxGrid minmax(min-content, 400px)"
                testString
                    "MinMax px and fr"
                    (string <| MinMax.MinMax(px 200, fr 1.) )
                    "MinMaxGrid minmax(200px, 1.00fr)"
                testString
                    "MinMax percent and min content"
                    (string <| MinMax.MinMax(pct 50, ContentSizeType.MinContent))
                    "MinMaxGrid minmax(50%, min-content)"
                testString
                    "MinMax percent and max content"
                    (string <| MinMax.MinMax(px 300, ContentSizeType.MaxContent))
                    "MinMaxGrid minmax(300px, max-content)"
                testString
                    "MinMax pct and px"
                    (string <| MinMax.MinMax(pct 30, px 300))
                    "MinMaxGrid minmax(30%, 300px)"
                testString
                    "MinMax min content and px"
                    (string <| MinMax.MinMax(ContentSizeType.MinContent, px 200))
                    "MinMaxGrid minmax(min-content, 200px)"
                test
                    "Grid auto columns min content"
                    [GridAutoColumns.MinContent]
                    ["gridAutoColumns" ==> "min-content"]
                test
                    "Grid auto columns max content"
                    [GridAutoColumns.MaxContent]
                    ["gridAutoColumns" ==> "max-content"]
                test
                    "Grid auto columns auto"
                    [GridAutoColumns.Auto]
                    ["gridAutoColumns" ==> "auto"]
                test
                    "Grid auto columns px"
                    [GridAutoColumns' (px 100)]
                    ["gridAutoColumns" ==> "100px"]
                test
                    "Grid auto columns cm"
                    [GridAutoColumns' (cm 20.)]
                    ["gridAutoColumns" ==> "20.0cm"]
                test
                    "Grid auto columns vmax"
                    [GridAutoColumns' (vmax 50.)]
                    ["gridAutoColumns" ==> "50.0vmax"]
                test
                    "Grid auto columns percent"
                    [GridAutoColumns' (pct 10)]
                    ["gridAutoColumns" ==> "10%"]
                test
                    "Grid auto columns fr"
                    [GridAutoColumns' (fr 0.5)]
                    ["gridAutoColumns" ==> "0.50fr"]
                test
                    "Grid auto columns fit content"
                    [GridAutoColumns.FitContent(px 400) ]
                    ["gridAutoColumns" ==> "fit-content(400px)"]
                test
                    "Grid auto columns multiple with min-content max-content and auto"
                    [ GridAutoColumns.Values [ContentSizeType.MinContent; ContentSizeType.MaxContent] ]
                    ["gridAutoColumns" ==> "min-content max-content"]
                test
                    "Grid auto columns multiple with pxs"
                    [ GridAutoColumns.Values [px 100; px 150; px 390;] ]
                    ["gridAutoColumns" ==> "100px 150px 390px"]
                test
                    "Grid auto columns multiple with percents"
                    [ GridAutoColumns.Values [pct 10; pct 33] ]
                    ["gridAutoColumns" ==> "10% 33%"]
                test
                    "Grid auto columns multiple with fractions"
                    [ GridAutoColumns.Values [fr 0.5; fr 3.; fr 1.] ]
                    ["gridAutoColumns" ==> "0.50fr 3.00fr 1.00fr"]
                test
                    "Grid auto columns inherit"
                    [GridAutoColumns.Inherit]
                    ["gridAutoColumns" ==> "inherit"]
                test
                    "Grid auto columns initial"
                    [GridAutoColumns.Initial]
                    ["gridAutoColumns" ==> "initial"]
                test
                    "Grid auto columns unset"
                    [GridAutoColumns.Unset]
                    ["gridAutoColumns" ==> "unset"]
                test
                    "Grid auto rows min content"
                    [GridAutoRows.MinContent]
                    ["gridAutoRows" ==> "min-content"]
                test
                    "Grid auto rows max content"
                    [GridAutoRows.MaxContent]
                    ["gridAutoRows" ==> "max-content"]
                test
                    "Grid auto rows auto"
                    [GridAutoRows.Auto]
                    ["gridAutoRows" ==> "auto"]
                test
                    "Grid auto rows px"
                    [GridAutoRows' (px 100)]
                    ["gridAutoRows" ==> "100px"]
                test
                    "Grid auto rows cm"
                    [GridAutoRows' (cm 20.)]
                    ["gridAutoRows" ==> "20.0cm"]
                test
                    "Grid auto rows vmax"
                    [GridAutoRows' (vmax 50.)]
                    ["gridAutoRows" ==> "50.0vmax"]
                test
                    "Grid auto rows percent"
                    [GridAutoRows' (pct 10)]
                    ["gridAutoRows" ==> "10%"]
                test
                    "Grid auto rows fr"
                    [GridAutoRows' (fr 0.5)]
                    ["gridAutoRows" ==> "0.50fr"]
                test
                    "Grid auto rows fit content"
                    [GridAutoRows.FitContent(px 400) ]
                    ["gridAutoRows" ==> "fit-content(400px)"]
                test
                    "Grid auto rows multiple with min-content max-content and auto"
                    [ GridAutoRows.Values [ContentSizeType.MinContent; ContentSizeType.MaxContent] ]
                    ["gridAutoRows" ==> "min-content max-content"]
                test
                    "Grid auto rows multiple with pxs"
                    [ GridAutoRows.Values [px 100; px 150; px 390;] ]
                    ["gridAutoRows" ==> "100px 150px 390px"]
                test
                    "Grid auto rows multiple with percents"
                    [ GridAutoRows.Values [pct 10; pct 33] ]
                    ["gridAutoRows" ==> "10% 33%"]
                test
                    "Grid auto rows multiple with fractions"
                    [ GridAutoRows.Values [fr 0.5; fr 3.; fr 1.] ]
                    ["gridAutoRows" ==> "0.50fr 3.00fr 1.00fr"]
                test
                    "Grid auto rows inherit"
                    [GridAutoRows.Inherit]
                    ["gridAutoRows" ==> "inherit"]
                test
                    "Grid auto rows initial"
                    [GridAutoRows.Initial]
                    ["gridAutoRows" ==> "initial"]
                test
                    "Grid auto rows unset"
                    [GridAutoRows.Unset]
                    ["gridAutoRows" ==> "unset"]
                test
                    "Grid auto flow rows"
                    [GridAutoFlow.Row]
                    ["gridAutoFlow" ==> "row"]
                test
                    "Grid auto flow columns"
                    [GridAutoFlow.Column]
                    ["gridAutoFlow" ==> "column"]
                test
                    "Grid auto flow dense"
                    [GridAutoFlow.Dense]
                    ["gridAutoFlow" ==> "dense"]
                test
                    "Grid auto flow rows dense"
                    [GridAutoFlow.RowDense]
                    ["gridAutoFlow" ==> "row dense"]
                test
                    "Grid auto flow columns dense"
                    [GridAutoFlow.ColumnDense]
                    ["gridAutoFlow" ==> "column dense"]
                test
                    "Grid auto flow inherit"
                    [GridAutoFlow.Inherit]
                    ["gridAutoFlow" ==> "inherit"]
                test
                    "Grid auto flow initial"
                    [GridAutoFlow.Initial]
                    ["gridAutoFlow" ==> "initial"]
                test
                    "Grid auto flow unset"
                    [GridAutoFlow.Unset]
                    ["gridAutoFlow" ==> "unset"]
                test
                    "Grid template areas None"
                    [GridTemplateAreas.None]
                    ["gridTemplateAreas" ==> "none"]
                test
                    "Grid template areas strings"
                    [GridTemplateAreas.Value [ "a"; "b"  ] ]
                    ["gridTemplateAreas" ==> "\"a b\""]
                test
                    "Grid template areas multiple strings"
                    [GridTemplateAreas.Value
                         [
                            [ "header";  "header";  "header";  "header" ]
                            [ "main";  "main";  ".";  "sidebar" ]
                            [ "footer";  "footer";  "footer";  "footer" ]
                        ]
                    ]
                    ["gridTemplateAreas" ==> "\"header header header header\" \"main main . sidebar\" \"footer footer footer footer\""]
                test
                    "Grid template areas inherit"
                    [GridTemplateAreas.Inherit ]
                    ["gridTemplateAreas" ==> "inherit"]
                test
                    "Grid template areas initial"
                    [GridTemplateAreas.Initial]
                    ["gridTemplateAreas" ==> "initial"]
                test
                    "Grid template areas multiple unset"
                    [GridTemplateAreas.Unset]
                    ["gridTemplateAreas" ==> "unset"]
            ]
