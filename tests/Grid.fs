namespace FSSTests

open Fet
open Utils
open Fss

module GridTests =
    let tests =
        testList "Grid"
            [
                testCase
                    "Grid area"
                    [ GridArea.value "foo" ]
                    "{grid-area:foo;}"
                testCase
                    "Grid area"
                    [ GridArea.value "area1 / area2" ]
                    "{grid-area:area1 / area2;}"
                testCase
                    "Grid area"
                    [ GridArea.value "span 3 / area2" ]
                    "{grid-area:span 3 / area2;}"
                testCase
                    "Grid area auto"
                    [ GridArea.auto ]
                    "{grid-area:auto;}"
                testCase
                    "Grid area inherit"
                    [GridArea.inherit']
                    "{grid-area:inherit;}"
                testCase
                    "Grid area initial"
                    [GridArea.initial]
                    "{grid-area:initial;}"
                testCase
                    "Grid area unset"
                    [GridArea.unset]
                    "{grid-area:unset;}"
                testCase
                    "Grid area revert"
                    [GridArea.revert]
                    "{grid-area:revert;}"
                testCase
                    "Grid column ident and ident"
                    [ GridColumn.value "someStart / someEnd" ]
                    "{grid-column:someStart / someEnd;}"
                testCase
                    "Grid column ident and value"
                    [ GridColumn.value "someStart / 2" ]
                    "{grid-column:someStart / 2;}"
                testCase
                    "Grid column auto"
                    [GridColumn.auto]
                    "{grid-column:auto;}"
                testCase
                    "Grid column inherit"
                    [GridColumn.inherit']
                    "{grid-column:inherit;}"
                testCase
                    "Grid column initial"
                    [GridColumn.initial]
                    "{grid-column:initial;}"
                testCase
                    "Grid column unset"
                    [GridColumn.unset]
                    "{grid-column:unset;}"
                testCase
                    "Grid column revert"
                    [GridColumn.revert]
                    "{grid-column:revert;}"
                testCase
                    "Grid column start auto"
                    [GridColumnStart.auto]
                    "{grid-column-start:auto;}"
                testCase
                    "Grid column start value"
                    [GridColumnStart.value 1]
                    "{grid-column-start:1;}"
                testCase
                    "Grid column start ident"
                    [GridColumnStart.value "somegridarea"]
                    "{grid-column-start:somegridarea;}"
                testCase
                    "Grid column value ident"
                    [GridColumnStart.value (1, "area") ]
                    "{grid-column-start:1 area;}"
                testCase
                    "Grid column start span"
                    [GridColumnStart.span 2 ]
                    "{grid-column-start:span 2;}"
                testCase
                    "Grid column start inherit"
                    [GridColumnStart.inherit']
                    "{grid-column-start:inherit;}"
                testCase
                    "Grid column start initial"
                    [GridColumnStart.initial]
                    "{grid-column-start:initial;}"
                testCase
                    "Grid column start unset"
                    [GridColumnStart.unset]
                    "{grid-column-start:unset;}"
                testCase
                    "Grid column start revert"
                    [GridColumnStart.revert]
                    "{grid-column-start:revert;}"
                testCase
                    "Grid column end auto"
                    [GridColumnEnd.auto]
                    "{grid-column-end:auto;}"
                testCase
                    "Grid column end value"
                    [GridColumnEnd.value 1]
                    "{grid-column-end:1;}"
                testCase
                    "Grid column end ident"
                    [GridColumnEnd.value "somegridarea"]
                    "{grid-column-end:somegridarea;}"
                testCase
                    "Grid column value ident"
                    [GridColumnEnd.value (1, "area") ]
                    "{grid-column-end:1 area;}"
                testCase
                    "Grid column end span"
                    [GridColumnEnd.span 2 ]
                    "{grid-column-end:span 2;}"
                testCase
                    "Grid column end inherit"
                    [GridColumnEnd.inherit']
                    "{grid-column-end:inherit;}"
                testCase
                    "Grid column end initial"
                    [GridColumnEnd.initial]
                    "{grid-column-end:initial;}"
                testCase
                    "Grid column end unset"
                    [GridColumnEnd.unset]
                    "{grid-column-end:unset;}"
                testCase
                    "Grid column end revert"
                    [GridColumnEnd.revert]
                    "{grid-column-end:revert;}"
                testCase
                    "Grid row ident and ident"
                    [ GridRow.value "someStart/someEnd" ]
                    "{grid-row:someStart/someEnd;}"
                testCase
                    "Grid row ident and value"
                    [ GridRow.value ("someStart", 2) ]
                    "{grid-row:someStart/2;}"
                testCase
                    "Grid row auto"
                    [GridRow.auto]
                    "{grid-row:auto;}"
                testCase
                    "Grid row inherit"
                    [GridRow.inherit']
                    "{grid-row:inherit;}"
                testCase
                    "Grid row initial"
                    [GridRow.initial]
                    "{grid-row:initial;}"
                testCase
                    "Grid row unset"
                    [GridRow.unset]
                    "{grid-row:unset;}"
                testCase
                    "Grid row revert"
                    [GridRow.revert]
                    "{grid-row:revert;}"
                testCase
                    "Grid row start auto"
                    [GridRowStart.auto]
                    "{grid-row-start:auto;}"
                testCase
                    "Grid row start value"
                    [GridRowStart.value 1]
                    "{grid-row-start:1;}"
                testCase
                    "Grid row start ident"
                    [GridRowStart.value "somegridarea"]
                    "{grid-row-start:somegridarea;}"
                testCase
                    "Grid row value ident and span"
                    [GridRowStart.value (1, "area") ]
                    "{grid-row-start:1 area;}"
                testCase
                    "Grid row start span"
                    [GridRowStart.span 2]
                    "{grid-row-start:span 2;}"
                testCase
                    "Grid row start inherit"
                    [GridRowStart.inherit']
                    "{grid-row-start:inherit;}"
                testCase
                    "Grid row start initial"
                    [GridRowStart.initial]
                    "{grid-row-start:initial;}"
                testCase
                    "Grid row start unset"
                    [GridRowStart.unset]
                    "{grid-row-start:unset;}"
                testCase
                    "Grid row start revert"
                    [GridRowStart.revert]
                    "{grid-row-start:revert;}"
                testCase
                    "Grid row end auto"
                    [GridRowEnd.auto]
                    "{grid-row-end:auto;}"
                testCase
                    "Grid row end value"
                    [GridRowEnd.value 1 ]
                    "{grid-row-end:1;}"
                testCase
                    "Grid row end ident"
                    [GridRowEnd.value "somegridarea"]
                    "{grid-row-end:somegridarea;}"
                testCase
                    "Grid row value ident and span"
                    [GridRowEnd.value (1, "area") ]
                    "{grid-row-end:1 area;}"
                testCase
                    "Grid row end span"
                    [GridRowEnd.span 2 ]
                    "{grid-row-end:span 2;}"
                testCase
                    "Grid row end inherit"
                    [GridRowEnd.inherit']
                    "{grid-row-end:inherit;}"
                testCase
                    "Grid row end initial"
                    [GridRowEnd.initial]
                    "{grid-row-end:initial;}"
                testCase
                    "Grid row end unset"
                    [GridRowEnd.unset]
                    "{grid-row-end:unset;}"
                testCase
                    "Grid row end revert"
                    [GridRowEnd.revert]
                    "{grid-row-end:revert;}"
                testCase
                    "Grid gap px"
                    [GridGap.value (px 10)]
                    "{grid-gap:10px;}"
                testCase
                    "Grid gap em"
                    [GridGap.value (em 1.)]
                    "{grid-gap:1em;}"
                testCase
                    "Grid gap percent"
                    [GridGap.value (pct 16)]
                    "{grid-gap:16%;}"
                testCase
                    "Grid gap px and px"
                    [ GridGap.value (px 20, px 10) ]
                    "{grid-gap:20px 10px;}"
                testCase
                    "Grid gap em and em"
                    [GridGap.value (em 1, em 0.5) ]
                    "{grid-gap:1em 0.5em;}"
                testCase
                    "Grid gap vmin and vmax"
                    [GridGap.value (vmin 3., vmax 2.) ]
                    "{grid-gap:3vmin 2vmax;}"
                testCase
                    "Grid gap cm and mm"
                    [GridGap.value (cm 0.5, mm 2.) ]
                    "{grid-gap:0.5cm 2mm;}"
                testCase
                    "Grid gap percent and percent"
                    [GridGap.value (pct 16, pct 100) ]
                    "{grid-gap:16% 100%;}"
                testCase
                    "Grid gap px and percent"
                    [ GridGap.value (px 21, pct 82) ]
                    "{grid-gap:21px 82%;}"
                testCase
                    "Grid gap inherit"
                    [GridGap.inherit']
                    "{grid-gap:inherit;}"
                testCase
                    "Grid gap initial"
                    [GridGap.initial]
                    "{grid-gap:initial;}"
                testCase
                    "Grid gap unset"
                    [GridGap.unset]
                    "{grid-gap:unset;}"
                testCase
                    "Grid gap revert"
                    [GridGap.revert]
                    "{grid-gap:revert;}"
                testCase
                    "Row gap normal"
                    [GridRowGap.normal]
                    "{grid-row-gap:normal;}"
                testCase
                    "Row gap px"
                    [GridRowGap.value (px 3)]
                    "{grid-row-gap:3px;}"
                testCase
                    "Row gap em"
                    [GridRowGap.value (em 2.5)]
                    "{grid-row-gap:2.5em;}"
                testCase
                    "Row gap percent"
                    [GridRowGap.value (pct 3)]
                    "{grid-row-gap:3%;}"
                testCase
                    "Row gap inherit"
                    [GridRowGap.inherit']
                    "{grid-row-gap:inherit;}"
                testCase
                    "Row gap initial"
                    [GridRowGap.initial]
                    "{grid-row-gap:initial;}"
                testCase
                    "Row gap unset"
                    [GridRowGap.unset]
                    "{grid-row-gap:unset;}"
                testCase
                    "Row gap revert"
                    [GridRowGap.revert]
                    "{grid-row-gap:revert;}"
                testCase
                    "Column gap normal"
                    [GridColumnGap.normal]
                    "{grid-column-gap:normal;}"
                testCase
                    "Column gap px"
                    [GridColumnGap.value (px 3)]
                    "{grid-column-gap:3px;}"
                testCase
                    "Column gap em"
                    [GridColumnGap.value (em 2.5)]
                    "{grid-column-gap:2.5em;}"
                testCase
                    "Column gap percent"
                    [GridColumnGap.value (pct 3)]
                    "{grid-column-gap:3%;}"
                testCase
                    "Column gap inherit"
                    [GridColumnGap.inherit']
                    "{grid-column-gap:inherit;}"
                testCase
                    "Column gap initial"
                    [GridColumnGap.initial]
                    "{grid-column-gap:initial;}"
                testCase
                    "Column gap unset"
                    [GridColumnGap.unset]
                    "{grid-column-gap:unset;}"
                testCase
                    "Column gap revert"
                    [GridColumnGap.revert]
                    "{grid-column-gap:revert;}"
                testCase
                    "Grid template row px"
                    [GridTemplateRows.value (px 100)]
                    "{grid-template-rows:100px;}"
                testCase
                    "Grid template row minmax"
                    [GridTemplateRows.minMax (px 100, fr 1.) ]
                    "{grid-template-rows:minmax(100px,1fr);}"
                testCase
                    "min max px and fraction"
                    [ GridTemplateRows.minMax(px 200, fr 1.5) ]
                    "{grid-template-rows:minmax(200px,1.5fr);}"
                testCase
                    "MinMax px and percent"
                    [ GridTemplateRows.minMax(px 400, pct 50) ]
                    "{grid-template-rows:minmax(400px,50%);}"
                testCase
                    "MinMax percent and px"
                    [ GridTemplateRows.minMax(pct 30, px 300) ]
                    "{grid-template-rows:minmax(30%,300px);}"
                testCase
                    "MinMax px and max content"
                    [ GridTemplateRows.minMax(px 100, Fss.Types.ContentSize.MaxContent) ]
                    "{grid-template-rows:minmax(100px,max-content);}"
                testCase
                    "MinMax min content and px"
                    [ GridTemplateRows.minMax(Fss.Types.ContentSize.MinContent, px 400) ]
                    "{grid-template-rows:minmax(min-content,400px);}"
                testCase
                    "MinMax px and fr"
                    [ GridTemplateRows.minMax(px 200, fr 1.) ]
                    "{grid-template-rows:minmax(200px,1fr);}"
                testCase
                    "MinMax percent and min content"
                    [ GridTemplateRows.minMax(pct 50, Fss.Types.ContentSize.MinContent) ]
                    "{grid-template-rows:minmax(50%,min-content);}"
                testCase
                    "MinMax percent and max content"
                    [ GridTemplateRows.minMax(px 300, Fss.Types.ContentSize.MaxContent) ]
                    "{grid-template-rows:minmax(300px,max-content);}"
                testCase
                    "MinMax pct and px"
                    [ GridTemplateRows.minMax(pct 30, px 300) ]
                    "{grid-template-rows:minmax(30%,300px);}"
                testCase
                    "MinMax min content and px"
                    [ GridTemplateRows.minMax(Fss.Types.ContentSize.MinContent, px 200) ]
                    "{grid-template-rows:minmax(min-content,200px);}"
                testCase
                    "Repeat value and percent"
                    [ GridTemplateRows.repeat(4, fr 1.) ]
                    "{grid-template-rows:repeat(4,1fr);}"
                testCase
                    "Repeat value and percent"
                    [ GridTemplateRows.repeat(4, pct 60) ]
                    "{grid-template-rows:repeat(4,60%);}"
                testCase
                    "Repeat value and pixels"
                    [ GridTemplateRows.repeat(4, px 250) ]
                    "{grid-template-rows:repeat(4,250px);}"
                testCase
                    "Repeat value and min-content"
                    [ GridTemplateRows.repeat(4, Fss.Types.ContentSize.MinContent) ]
                    "{grid-template-rows:repeat(4,min-content);}"
                testCase
                    "Repeat value and max-content"
                    [ GridTemplateRows.repeat(4, Fss.Types.ContentSize.MaxContent) ]
                    "{grid-template-rows:repeat(4,max-content);}"
                testCase
                    "Repeat value and minmax"
                    [ GridTemplateRows.repeat(4, Fss.Types.Grid.MinMax.MinMax(px 100, fr 1.)) ]
                    "{grid-template-rows:repeat(4,minmax(100px,1fr));}"
                testCase
                    "Repeat value and fit content"
                    [ GridTemplateRows.repeat(4, Fss.Types.ContentSize.FitContent(px 100)) ]
                    "{grid-template-rows:repeat(4,fit-content(100px));}"
                testCase
                    "Repeat value and min-content max-content"
                    [ GridTemplateRows.repeat(4, [Fss.Types.ContentSize.MinContent; Fss.Types.ContentSize.MaxContent]) ]
                    "{grid-template-rows:repeat(4,min-content max-content);}"
                testCase
                    "Repeat auto-fill and px"
                    [ GridTemplateRows.repeat(Fss.Types.Grid.AutoFill, px 30) ]
                    "{grid-template-rows:repeat(auto-fill,30px);}"
                testCase
                    "Repeat auto-fit and px"
                    [ GridTemplateRows.repeat(Fss.Types.Grid.AutoFit, px 30) ]
                    "{grid-template-rows:repeat(auto-fit,30px);}"
                testCase
                    "Grid template row fit-content"
                    [GridTemplateRows.fitContent(px 100)]
                    "{grid-template-rows:fit-content(100px);}"
                testCase
                    "Grid template row repeat"
                    [GridTemplateRows.repeat(3, px 200)]
                    "{grid-template-rows:repeat(3,200px);}"
                testCase
                    "Grid template row subgrid"
                    [GridTemplateRows.subgrid ]
                    "{grid-template-rows:subgrid;}"
                testCase
                    "Grid template row masonry"
                    [GridTemplateRows.masonry ]
                    "{grid-template-rows:masonry;}"
                testCase
                    "Grid template row none"
                    [GridTemplateRows.none]
                    "{grid-template-rows:none;}"
                testCase
                    "Grid template row auto"
                    [GridTemplateRows.auto]
                    "{grid-template-rows:auto;}"
                testCase
                    "Grid template row inherit"
                    [GridTemplateRows.inherit']
                    "{grid-template-rows:inherit;}"
                testCase
                    "Grid template row initial"
                    [GridTemplateRows.initial]
                    "{grid-template-rows:initial;}"
                testCase
                    "Grid template row unset"
                    [GridTemplateRows.unset]
                    "{grid-template-rows:unset;}"
                testCase
                    "Grid template row revert"
                    [GridTemplateRows.revert]
                    "{grid-template-rows:revert;}"
                testCase
                    "Grid template row px"
                    [GridTemplateColumns.value (px 100)]
                    "{grid-template-columns:100px;}"
                testCase
                    "Grid template row minmax"
                    [GridTemplateColumns.minMax (px 100, fr 1.) ]
                    "{grid-template-columns:minmax(100px,1fr);}"
                testCase
                    "min max px and fraction"
                    [ GridTemplateColumns.minMax(px 200, fr 1.5) ]
                    "{grid-template-columns:minmax(200px,1.5fr);}"
                testCase
                    "MinMax px and percent"
                    [ GridTemplateColumns.minMax(px 400, pct 50) ]
                    "{grid-template-columns:minmax(400px,50%);}"
                testCase
                    "MinMax percent and px"
                    [ GridTemplateColumns.minMax(pct 30, px 300) ]
                    "{grid-template-columns:minmax(30%,300px);}"
                testCase
                    "MinMax px and max content"
                    [ GridTemplateColumns.minMax(px 100, Fss.Types.ContentSize.MaxContent) ]
                    "{grid-template-columns:minmax(100px,max-content);}"
                testCase
                    "MinMax min content and px"
                    [ GridTemplateColumns.minMax(Fss.Types.ContentSize.MinContent, px 400) ]
                    "{grid-template-columns:minmax(min-content,400px);}"
                testCase
                    "MinMax px and fr"
                    [ GridTemplateColumns.minMax(px 200, fr 1.) ]
                    "{grid-template-columns:minmax(200px,1fr);}"
                testCase
                    "MinMax percent and min content"
                    [ GridTemplateColumns.minMax(pct 50, Fss.Types.ContentSize.MinContent) ]
                    "{grid-template-columns:minmax(50%,min-content);}"
                testCase
                    "MinMax percent and max content"
                    [ GridTemplateColumns.minMax(px 300, Fss.Types.ContentSize.MaxContent) ]
                    "{grid-template-columns:minmax(300px,max-content);}"
                testCase
                    "MinMax pct and px"
                    [ GridTemplateColumns.minMax(pct 30, px 300) ]
                    "{grid-template-columns:minmax(30%,300px);}"
                testCase
                    "MinMax min content and px"
                    [ GridTemplateColumns.minMax(Fss.Types.ContentSize.MinContent, px 200) ]
                    "{grid-template-columns:minmax(min-content,200px);}"
                testCase
                    "Repeat value and percent"
                    [ GridTemplateColumns.repeat(4, fr 1.) ]
                    "{grid-template-columns:repeat(4,1fr);}"
                testCase
                    "Repeat value and percent"
                    [ GridTemplateColumns.repeat(4, pct 60) ]
                    "{grid-template-columns:repeat(4,60%);}"
                testCase
                    "Repeat value and pixels"
                    [ GridTemplateColumns.repeat(4, px 250) ]
                    "{grid-template-columns:repeat(4,250px);}"
                testCase
                    "Repeat value and min-content"
                    [ GridTemplateColumns.repeat(4, Fss.Types.ContentSize.MinContent) ]
                    "{grid-template-columns:repeat(4,min-content);}"
                testCase
                    "Repeat value and max-content"
                    [ GridTemplateColumns.repeat(4, Fss.Types.ContentSize.MaxContent) ]
                    "{grid-template-columns:repeat(4,max-content);}"
                testCase
                    "Repeat value and minmax"
                    [ GridTemplateColumns.repeat(4, Fss.Types.Grid.MinMax.MinMax(px 100, fr 1.)) ]
                    "{grid-template-columns:repeat(4,minmax(100px,1fr));}"
                testCase
                    "Repeat value and fit content"
                    [ GridTemplateColumns.repeat(4, Fss.Types.ContentSize.FitContent(px 100)) ]
                    "{grid-template-columns:repeat(4,fit-content(100px));}"
                testCase
                    "Repeat value and min-content max-content"
                    [ GridTemplateColumns.repeat(4, [Fss.Types.ContentSize.MinContent; Fss.Types.ContentSize.MaxContent]) ]
                    "{grid-template-columns:repeat(4,min-content max-content);}"
                testCase
                    "Repeat auto-fill and px"
                    [ GridTemplateColumns.repeat(Fss.Types.Grid.AutoFill, px 30) ]
                    "{grid-template-columns:repeat(auto-fill,30px);}"
                testCase
                    "Repeat auto-fit and px"
                    [ GridTemplateColumns.repeat(Fss.Types.Grid.AutoFit, px 30) ]
                    "{grid-template-columns:repeat(auto-fit,30px);}"
                testCase
                    "Grid template row fit-content"
                    [GridTemplateColumns.fitContent(px 100)]
                    "{grid-template-columns:fit-content(100px);}"
                testCase
                    "Grid template row repeat"
                    [GridTemplateColumns.repeat(3, px 200)]
                    "{grid-template-columns:repeat(3,200px);}"
                testCase
                    "Grid template row subgrid"
                    [GridTemplateColumns.subgrid ]
                    "{grid-template-columns:subgrid;}"
                testCase
                    "Grid template row masonry"
                    [GridTemplateColumns.masonry ]
                    "{grid-template-columns:masonry;}"
                testCase
                    "Grid template row none"
                    [GridTemplateColumns.none]
                    "{grid-template-columns:none;}"
                testCase
                    "Grid template row auto"
                    [GridTemplateColumns.auto]
                    "{grid-template-columns:auto;}"
                testCase
                    "Grid template row inherit"
                    [GridTemplateColumns.inherit']
                    "{grid-template-columns:inherit;}"
                testCase
                    "Grid template row initial"
                    [GridTemplateColumns.initial]
                    "{grid-template-columns:initial;}"
                testCase
                    "Grid template row unset"
                    [GridTemplateColumns.unset]
                    "{grid-template-columns:unset;}"
                testCase
                    "Grid template row revert"
                    [GridTemplateColumns.revert]
                    "{grid-template-columns:revert;}"
                testCase
                    "Grid auto columns min content"
                    [GridAutoColumns.minContent]
                    "{grid-auto-columns:min-content;}"
                testCase
                    "Grid auto columns max content"
                    [GridAutoColumns.maxContent]
                    "{grid-auto-columns:max-content;}"
                testCase
                    "Grid auto columns auto"
                    [GridAutoColumns.auto]
                    "{grid-auto-columns:auto;}"
                testCase
                    "Grid auto columns px"
                    [GridAutoColumns.value (px 100)]
                    "{grid-auto-columns:100px;}"
                testCase
                    "Grid auto columns cm"
                    [GridAutoColumns.value (cm 20.)]
                    "{grid-auto-columns:20cm;}"
                testCase
                    "Grid auto columns vmax"
                    [GridAutoColumns.value (vmax 50.)]
                    "{grid-auto-columns:50vmax;}"
                testCase
                    "Grid auto columns percent"
                    [GridAutoColumns.value (pct 10)]
                    "{grid-auto-columns:10%;}"
                testCase
                    "Grid auto columns fr"
                    [GridAutoColumns.value (fr 0.5)]
                    "{grid-auto-columns:0.5fr;}"
                testCase
                    "Grid auto columns fit content"
                    [GridAutoColumns.fitContent(px 400) ]
                    "{grid-auto-columns:fit-content(400px);}"
                testCase
                    "Grid auto columns multiple with min-content max-content and auto"
                    [ GridAutoColumns.value [Fss.Types.ContentSize.MinContent; Fss.Types.ContentSize.MaxContent] ]
                    "{grid-auto-columns:min-content max-content;}"
                testCase
                    "Grid auto columns multiple with pxs"
                    [ GridAutoColumns.value [px 100; px 150; px 390;] ]
                    "{grid-auto-columns:100px 150px 390px;}"
                testCase
                    "Grid auto columns multiple with percents"
                    [ GridAutoColumns.value [pct 10; pct 33] ]
                    "{grid-auto-columns:10% 33%;}"
                testCase
                    "Grid auto columns multiple with fractions"
                    [ GridAutoColumns.value [fr 0.5; fr 3.; fr 1.] ]
                    "{grid-auto-columns:0.5fr 3fr 1fr;}"
                testCase
                    "Grid auto columns inherit"
                    [GridAutoColumns.inherit']
                    "{grid-auto-columns:inherit;}"
                testCase
                    "Grid auto columns initial"
                    [GridAutoColumns.initial]
                    "{grid-auto-columns:initial;}"
                testCase
                    "Grid auto columns unset"
                    [GridAutoColumns.unset]
                    "{grid-auto-columns:unset;}"
                testCase
                    "Grid auto rows min content"
                    [GridAutoRows.minContent]
                    "{grid-auto-rows:min-content;}"
                testCase
                    "Grid auto rows max content"
                    [GridAutoRows.maxContent]
                    "{grid-auto-rows:max-content;}"
                testCase
                    "Grid auto rows auto"
                    [GridAutoRows.auto]
                    "{grid-auto-rows:auto;}"
                testCase
                    "Grid auto rows px"
                    [GridAutoRows.value (px 100)]
                    "{grid-auto-rows:100px;}"
                testCase
                    "Grid auto rows cm"
                    [GridAutoRows.value (cm 20.)]
                    "{grid-auto-rows:20cm;}"
                testCase
                    "Grid auto rows vmax"
                    [GridAutoRows.value (vmax 50.)]
                    "{grid-auto-rows:50vmax;}"
                testCase
                    "Grid auto rows percent"
                    [GridAutoRows.value (pct 10)]
                    "{grid-auto-rows:10%;}"
                testCase
                    "Grid auto rows fr"
                    [GridAutoRows.value (fr 0.5)]
                    "{grid-auto-rows:0.5fr;}"
                testCase
                    "Grid auto rows fit content"
                    [GridAutoRows.fitContent(px 400) ]
                    "{grid-auto-rows:fit-content(400px);}"
                testCase
                    "Grid auto rows multiple with min-content max-content and auto"
                    [ GridAutoRows.value [Fss.Types.ContentSize.MinContent; Fss.Types.ContentSize.MaxContent] ]
                    "{grid-auto-rows:min-content max-content;}"
                testCase
                    "Grid auto rows multiple with pxs"
                    [ GridAutoRows.value [px 100; px 150; px 390;] ]
                    "{grid-auto-rows:100px 150px 390px;}"
                testCase
                    "Grid auto rows multiple with percents"
                    [ GridAutoRows.value [pct 10; pct 33] ]
                    "{grid-auto-rows:10% 33%;}"
                testCase
                    "Grid auto rows multiple with fractions"
                    [ GridAutoRows.value [fr 0.5; fr 3.; fr 1.] ]
                    "{grid-auto-rows:0.5fr 3fr 1fr;}"
                testCase
                    "Grid auto rows inherit"
                    [GridAutoRows.inherit']
                    "{grid-auto-rows:inherit;}"
                testCase
                    "Grid auto rows initial"
                    [GridAutoRows.initial]
                    "{grid-auto-rows:initial;}"
                testCase
                    "Grid auto rows unset"
                    [GridAutoRows.unset]
                    "{grid-auto-rows:unset;}"
                testCase
                    "Grid auto flow rows"
                    [GridAutoFlow.row]
                    "{grid-auto-flow:row;}"
                testCase
                    "Grid auto flow columns"
                    [GridAutoFlow.column]
                    "{grid-auto-flow:column;}"
                testCase
                    "Grid auto flow dense"
                    [GridAutoFlow.dense]
                    "{grid-auto-flow:dense;}"
                testCase
                    "Grid auto flow rows dense"
                    [GridAutoFlow.rowDense]
                    "{grid-auto-flow:row dense;}"
                testCase
                    "Grid auto flow columns dense"
                    [GridAutoFlow.columnDense]
                    "{grid-auto-flow:column dense;}"
                testCase
                    "Grid auto flow inherit"
                    [GridAutoFlow.inherit']
                    "{grid-auto-flow:inherit;}"
                testCase
                    "Grid auto flow initial"
                    [GridAutoFlow.initial]
                    "{grid-auto-flow:initial;}"
                testCase
                    "Grid auto flow unset"
                    [GridAutoFlow.unset]
                    "{grid-auto-flow:unset;}"
                testCase
                    "Grid template areas None"
                    [GridTemplateAreas.none]
                    "{grid-template-areas:none;}"
                testCase
                    "Grid template areas strings"
                    [GridTemplateAreas.value [ "a"; "b"  ] ]
                    "{grid-template-areas:\"a b\";}"
                testCase
                    "Grid template areas multiple strings"
                    [GridTemplateAreas.value
                         [
                            [ "header";  "header";  "header";  "header" ]
                            [ "main";  "main";  ".";  "sidebar" ]
                            [ "footer";  "footer";  "footer";  "footer" ]
                        ]
                    ]
                    "{grid-template-areas: \"header header header header\" \"main main . sidebar\" \"footer footer footer footer\";}"
                testCase
                    "Grid template areas inherit"
                    [GridTemplateAreas.inherit' ]
                    "{grid-template-areas:inherit;}"
                testCase
                    "Grid template areas initial"
                    [GridTemplateAreas.initial]
                    "{grid-template-areas:initial;}"
                testCase
                    "Grid template areas unset"
                    [GridTemplateAreas.unset]
                    "{grid-template-areas:unset;}"
                testCase
                    "Grid template areas revert"
                    [GridTemplateAreas.revert]
                    "{grid-template-areas:revert;}"
            ]
