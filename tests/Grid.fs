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
                    [
                        GridArea (Ident "foo")
                    ]
                    ["grid-area" ==> "foo"]
                
                test
                    "Grid column ident and ident"
                    [
                        GridColumn
                            (Grid.Column (Ident "someStart", Ident "someEnd"))
                    ]
                    ["grid-column" ==> "someStart / someEnd"]
                    
                test
                    "Grid column ident and value"
                    [
                        GridColumn
                            (Grid.Column (Ident "someStart", Value 2))
                    ]
                    ["grid-column" ==> "someStart / 2"]

                test
                    "Grid column auto"
                    [GridColumn Auto]
                    ["grid-column" ==> "auto"]
                
                test
                    "Grid column inherit"
                    [GridColumn Inherit]
                    ["grid-column" ==> "inherit"]
                    
                test
                    "Grid column initial"
                    [GridColumn Initial]
                    ["grid-column" ==> "initial"]
                    
                test
                    "Grid column unset"
                    [GridColumn Unset]
                    ["grid-column" ==> "unset"]
                
                test
                    "Grid column start auto"
                    [GridColumnStart Auto]
                    ["grid-column-start" ==> "auto"]
                    
                test
                    "Grid column start value"
                    [GridColumnStart (Value 1)]
                    ["grid-column-start" ==> "1"]
                    
                test
                    "Grid column start ident"
                    [GridColumnStart (Ident "somegridarea")]
                    ["grid-column-start" ==> "somegridarea"]
                    
                test
                    "Grid column value ident and span"
                    [GridColumnStarts [Value 1; Ident "area"; Grid.Span 1] ]
                    ["grid-column-start" ==> "1 area span 1"]
                    
                test
                    "Grid column start span"
                    [GridColumnStart (Grid.Span 2)]
                    ["grid-column-start" ==> "span 2"]
                    
                test
                    "Grid column start inherit"
                    [GridColumnStart Inherit]
                    ["grid-column-start" ==> "inherit"]
                    
                test
                    "Grid column start initial"
                    [GridColumnStart Initial]
                    ["grid-column-start" ==> "initial"]
                    
                test
                    "Grid column start unset"
                    [GridColumnStart Unset]
                    ["grid-column-start" ==> "unset"]
                
                test
                    "Grid column end auto"
                    [GridColumnEnd Auto]
                    ["grid-column-end" ==> "auto"]
                    
                test
                    "Grid column end value"
                    [GridColumnEnd (Value 1)]
                    ["grid-column-end" ==> "1"]
                    
                test
                    "Grid column end ident"
                    [GridColumnEnd (Ident "somegridarea")]
                    ["grid-column-end" ==> "somegridarea"]
                    
                test
                    "Grid column value ident and span"
                    [GridColumnEnds [Value 1; Ident "area"; Grid.Span 1] ]
                    ["grid-column-end" ==> "1 area span 1"]
                    
                test
                    "Grid column end span"
                    [GridColumnEnd (Grid.Span 2)]
                    ["grid-column-end" ==> "span 2"]
                    
                test
                    "Grid column end inherit"
                    [GridColumnEnd Inherit]
                    ["grid-column-end" ==> "inherit"]
                    
                test
                    "Grid column end initial"
                    [GridColumnEnd Initial]
                    ["grid-column-end" ==> "initial"]
                    
                test
                    "Grid column end unset"
                    [GridColumnEnd Unset]
                    ["grid-column-end" ==> "unset"]
                
                test
                    "Grid row ident and ident"
                    [
                        GridRow
                            (Grid.Row (Ident "someStart", Ident "someEnd"))
                    ]
                    ["grid-row" ==> "someStart / someEnd"]
                    
                test
                    "Grid row ident and value"
                    [
                        GridRow
                            (Grid.Row (Ident "someStart", Value 2))
                    ]
                    ["grid-row" ==> "someStart / 2"]

                test
                    "Grid row auto"
                    [GridRow Auto]
                    ["grid-row" ==> "auto"]
                
                test
                    "Grid row inherit"
                    [GridRow Inherit]
                    ["grid-row" ==> "inherit"]
                    
                test
                    "Grid row initial"
                    [GridRow Initial]
                    ["grid-row" ==> "initial"]
                    
                test
                    "Grid row unset"
                    [GridRow Unset]
                    ["grid-row" ==> "unset"]
                
                test
                    "Grid row start auto"
                    [GridRowStart Auto]
                    ["grid-row-start" ==> "auto"]
                    
                test
                    "Grid row start value"
                    [GridRowStart (Value 1)]
                    ["grid-row-start" ==> "1"]
                    
                test
                    "Grid row start ident"
                    [GridRowStart (Ident "somegridarea")]
                    ["grid-row-start" ==> "somegridarea"]
                    
                test
                    "Grid row value ident and span"
                    [GridRowStarts [Value 1; Ident "area"; Grid.Span 1] ]
                    ["grid-row-start" ==> "1 area span 1"]
                    
                test
                    "Grid row start span"
                    [GridRowStart (Grid.Span 2)]
                    ["grid-row-start" ==> "span 2"]
                    
                test
                    "Grid row start inherit"
                    [GridRowStart Inherit]
                    ["grid-row-start" ==> "inherit"]
                    
                test
                    "Grid row start initial"
                    [GridRowStart Initial]
                    ["grid-row-start" ==> "initial"]
                    
                test
                    "Grid row start unset"
                    [GridRowStart Unset]
                    ["grid-row-start" ==> "unset"]
                
                test
                    "Grid row end auto"
                    [GridRowEnd Auto]
                    ["grid-row-end" ==> "auto"]
                    
                test
                    "Grid row end value"
                    [GridRowEnd (Value 1)]
                    ["grid-row-end" ==> "1"]
                    
                test
                    "Grid row end ident"
                    [GridRowEnd (Ident "somegridarea")]
                    ["grid-row-end" ==> "somegridarea"]
                    
                test
                    "Grid row value ident and span"
                    [GridRowEnds [Value 1; Ident "area"; Grid.Span 1] ]
                    ["grid-row-end" ==> "1 area span 1"]
                    
                test
                    "Grid row end span"
                    [GridRowEnd (Grid.Span 2)]
                    ["grid-row-end" ==> "span 2"]
                    
                test
                    "Grid row end inherit"
                    [GridRowEnd Inherit]
                    ["grid-row-end" ==> "inherit"]
                    
                test
                    "Grid row end initial"
                    [GridRowEnd Initial]
                    ["grid-row-end" ==> "initial"]
                    
                test
                    "Grid row end unset"
                    [GridRowEnd Unset]
                    ["grid-row-end" ==> "unset"]
                
                test
                    "Grid gap px"
                    [GridGap (px 10)]
                    ["grid-gap" ==> "10px"]
                    
                test
                    "Grid gap em"
                    [GridGap (em 1.)]
                    ["grid-gap" ==> "1.0em"]
                    
                test
                    "Grid gap percent"
                    [GridGap (pct 16)]
                    ["grid-gap" ==> "16%"]
                
                test
                    "Grid gap px and px"
                    [ GridGap (Grid.Gap(px 20, px 10)) ]
                    ["grid-gap" ==> "20px 10px"]
                    
                test
                    "Grid gap em and em"
                    [GridGap (Grid.Gap(em 1., em 0.5)) ]
                    ["grid-gap" ==> "1.0em 0.5em"]
                    
                test
                    "Grid gap vmin and vmax"
                    [GridGap (Grid.Gap(vmin 3., vmax 2.)) ]
                    ["grid-gap" ==> "3.0vmin 2.0vmax"]
                    
                test
                    "Grid gap cm and mm"
                    [GridGap (Grid.Gap(cm 0.5, mm 2.)) ]
                    ["grid-gap" ==> "0.5cm 2.0mm"]
                    
                test
                    "Grid gap percent and percent"
                    [GridGap (Grid.Gap(pct 16, pct 100)) ]
                    ["grid-gap" ==> "16% 100%"]
                    
                test
                    "Grid gap px and percent"
                    [ GridGap (Grid.Gap(px 21, pct 82)) ]
                    ["grid-gap" ==> "21px 82%"]

                test
                    "Grid gap inherit"
                    [GridGap Inherit]
                    ["grid-gap" ==> "inherit"]
                    
                test
                    "Grid gap initial"
                    [GridGap Initial]
                    ["grid-gap" ==> "initial"]
                    
                test
                    "Grid gap unset"
                    [GridGap Unset]
                    ["grid-gap" ==> "unset"]
                
                test
                    "Column gap normal"
                    [GridColumnGap Normal]
                    ["grid-column-gap" ==> "normal"]
                    
                test
                    "Column gap px"
                    [GridColumnGap (px 3)]
                    ["grid-column-gap" ==> "3px"]
                    
                test
                    "Column gap em"
                    [GridColumnGap (em 2.5)]
                    ["grid-column-gap" ==> "2.5em"]
                    
                test
                    "Column gap percent"
                    [GridColumnGap (pct 3)]
                    ["grid-column-gap" ==> "3%"]
                    
                test
                    "Column gap inherit"
                    [GridColumnGap Inherit]
                    ["grid-column-gap" ==> "inherit"]
                    
                test
                    "Column gap initial"
                    [GridColumnGap Initial]
                    ["grid-column-gap" ==> "initial"]
                    
                test
                    "Column gap unset"
                    [GridColumnGap Unset]
                    ["grid-column-gap" ==> "unset"]
                
                test
                    "Row gap normal"
                    [GridRowGap Normal]
                    ["grid-row-gap" ==> "normal"]
                    
                test
                    "Row gap px"
                    [GridRowGap (px 3)]
                    ["grid-row-gap" ==> "3px"]
                    
                test
                    "Row gap em"
                    [GridRowGap (em 2.5)]
                    ["grid-row-gap" ==> "2.5em"]
                    
                test
                    "Row gap percent"
                    [GridRowGap (pct 3)]
                    ["grid-row-gap" ==> "3%"]
                    
                test
                    "Row gap inherit"
                    [GridRowGap Inherit]
                    ["grid-row-gap" ==> "inherit"]
                    
                test
                    "Row gap initial"
                    [GridRowGap Initial]
                    ["grid-row-gap" ==> "initial"]
                    
                test
                    "Row gap unset"
                    [GridRowGap Unset]
                    ["grid-row-gap" ==> "unset"]
                
                test
                    "Grid template row px"
                    [GridTemplateRow (px 100)]
                    ["grid-template-rows" ==> "100px"]
                    
                test
                    "Grid template row minmax"
                    [GridTemplateRow (Grid.MinMax(px 100, fr 1.))]
                    ["grid-template-rows" ==> "minmax(100px, 1.00fr)"]
                    
                test
                    "Grid template row fit-content"
                    [GridTemplateRow (FitContent(px 100))]
                    ["grid-template-rows" ==> "fit-content(100px)"]
                
                test
                    "Grid template row repeat"
                    [GridTemplateRow (Grid.Repeat(Value 3, px 200))]
                    ["grid-template-rows" ==> "repeat(3, 200px)"]
                    
                test
                    "Grid template row subgrid"
                    [GridTemplateRow (Grid.Subgrid)]
                    ["grid-template-rows" ==> "subgrid"]
                
                test
                    "Grid template row none"
                    [GridTemplateRow None]
                    ["grid-template-rows" ==> "none"]
                    
                test
                    "Grid template row px repeat px"
                    [GridTemplateRows [px 200; Grid.Repeat(Grid.AutoFill, px 100); px 300]]
                    ["grid-template-rows" ==> "200px repeat(auto-fill, 100px) 300px"]
                    
                test
                    "Grid template row minmax repeat percent"
                    [GridTemplateRows [Grid.MinMax(px 100, MaxContent); Grid.Repeat(Grid.AutoFill, px 200); pct 20]]
                    ["grid-template-rows" ==> "minmax(100px, max-content) repeat(auto-fill, 200px) 20%"]
                    
                test
                    "Grid template row auto"
                    [GridTemplateRow Auto]
                    ["grid-template-rows" ==> "auto"]
                    
                test
                    "Grid template row inherit"
                    [GridTemplateRow Inherit]
                    ["grid-template-rows" ==> "inherit"]
                    
                test
                    "Grid template row initial"
                    [GridTemplateRow Initial]
                    ["grid-template-rows" ==> "initial"]
                    
                test
                    "Grid template row unset"
                    [GridTemplateRow Unset]
                    ["grid-template-rows" ==> "unset"]
                
                test
                    "Grid template column px"
                    [GridTemplateColumn (px 100)]
                    ["grid-template-columns" ==> "100px"]
                    
                test
                    "Grid template column minmax"
                    [GridTemplateColumn (Grid.MinMax(px 100, fr 1.))]
                    ["grid-template-columns" ==> "minmax(100px, 1.00fr)"]
                    
                test
                    "Grid template column fit-content"
                    [GridTemplateColumn (FitContent(px 100))]
                    ["grid-template-columns" ==> "fit-content(100px)"]
                
                test
                    "Grid template column repeat"
                    [GridTemplateColumn (Grid.Repeat(Value 3, px 200))]
                    ["grid-template-columns" ==> "repeat(3, 200px)"]
                    
                test
                    "Grid template column subgrid"
                    [GridTemplateColumn (Grid.Subgrid)]
                    ["grid-template-columns" ==> "subgrid"]
                
                test
                    "Grid template column none"
                    [GridTemplateColumn None]
                    ["grid-template-columns" ==> "none"]
                    
                test
                    "Grid template column px repeat px"
                    [GridTemplateColumns [px 200; Grid.Repeat(Grid.AutoFill, px 100); px 300]]
                    ["grid-template-columns" ==> "200px repeat(auto-fill, 100px) 300px"]
                    
                test
                    "Grid template column minmax repeat percent"
                    [GridTemplateColumns [Grid.MinMax(px 100, MaxContent); Grid.Repeat(Grid.AutoFill, px 200); pct 20]]
                    ["grid-template-columns" ==> "minmax(100px, max-content) repeat(auto-fill, 200px) 20%"]
                    
                test
                    "Grid template column auto"
                    [GridTemplateColumn Auto]
                    ["grid-template-columns" ==> "auto"]
                    
                test
                    "Grid template column inherit"
                    [GridTemplateColumn Inherit]
                    ["grid-template-columns" ==> "inherit"]
                    
                test
                    "Grid template column initial"
                    [GridTemplateColumn Initial]
                    ["grid-template-columns" ==> "initial"]
                    
                test
                    "Grid template column unset"
                    [GridTemplateColumn Unset]
                    ["grid-template-columns" ==> "unset"]
                
                testString
                    "Repat value and fr"
                    (GridValue.repeat <| Grid.Repeat(Value 4, fr 1.))
                    "repeat(4, 1.00fr)"
                    
                testString
                    "Repat value and percent"
                    (GridValue.repeat <| Grid.Repeat(Value 4, pct 60))
                    "repeat(4, 60%)"
                    
                testString
                    "Repat value and pixels"
                    (GridValue.repeat <| Grid.Repeat(Value 4, px 250))
                    "repeat(4, 250px)"
                            
                testString
                    "Repat value and min-content"
                    (GridValue.repeat <| Grid.Repeat(Value 4, MinContent))
                    "repeat(4, min-content)"
                
                testString
                    "Repat value and max-content"
                    (GridValue.repeat <| Grid.Repeat(Value 4, MaxContent))
                    "repeat(4, max-content)"
                    
                testString
                    "Repat value and auto"
                    (GridValue.repeat <| Grid.Repeat(Value 4, Auto))
                    "repeat(4, auto)"     
                
                testString
                    "Repat value and minmax"
                    (GridValue.repeat <| Grid.Repeat(Value 4, Grid.MinMax(px 100, fr 1.)))
                    "repeat(4, minmax(100px, 1.00fr))"
                    
                testString
                    "Repat value and fit content"
                    (GridValue.repeat <| Grid.Repeat(Value 4, FitContent(px 100)))
                    "repeat(4, fit-content(100px))" 

                testString
                    "Repat value and px pct and auto"
                    (GridValue.repeat <| Grid.RepeatMany(Value 4, [px 10; pct 30; Auto]))
                    "repeat(4, 10px 30% auto)"
                                    
                testString
                    "Repat value and min-content max-content"
                    (GridValue.repeat <| Grid.RepeatMany(Value 4, [MinContent; MaxContent]))
                    "repeat(4, min-content max-content)"
                    
                testString
                    "Repat auto-fill and px"
                    (GridValue.repeat <| Grid.Repeat(Grid.AutoFill, px 30))
                    "repeat(auto-fill, 30px)"

                testString
                    "Repat auto-fit and px"
                    (GridValue.repeat <| Grid.Repeat(Grid.AutoFit, px 30))
                    "repeat(auto-fit, 30px)"
                                    
                testString
                    "Repat value and auto-fit"
                    (GridValue.repeat <| Grid.RepeatMany(Value 4, [MinContent; MaxContent]))
                    "repeat(4, min-content max-content)" 
                 
                testString
                    "MinMax px and fraction"
                    (GridValue.minMax <| Grid.MinMax(px 200, fr 1.5))
                    "minmax(200px, 1.50fr)"

                testString
                    "MinMax px and percent"
                    (GridValue.minMax <| Grid.MinMax(px 400, pct 50))
                    "minmax(400px, 50%)"

                testString
                    "MinMax percent and px"
                    (GridValue.minMax <| Grid.MinMax(pct 30, px 300))
                    "minmax(30%, 300px)"

                testString
                    "MinMax px and max content"
                    (GridValue.minMax <| Grid.MinMax(px 100, MaxContent))
                    "minmax(100px, max-content)"

                testString
                    "MinMax min content and px"
                    (GridValue.minMax <| Grid.MinMax(MinContent, px 400))
                    "minmax(min-content, 400px)"

                testString
                    "MinMax Max content and auto"
                    (GridValue.minMax <| Grid.MinMax(MaxContent, Auto))
                    "minmax(max-content, auto)"

                testString
                    "MinMax min content and auto"
                    (GridValue.minMax <| Grid.MinMax(MinContent, Auto))
                    "minmax(min-content, auto)"

                testString
                    "MinMax px and fr"
                    (GridValue.minMax <| Grid.MinMax(px 200, fr 1.))
                    "minmax(200px, 1.00fr)"

                testString
                    "MinMax percent and min content"
                    (GridValue.minMax <| Grid.MinMax(pct 50, MinContent))
                    "minmax(50%, min-content)"

                testString
                    "MinMax percent and max content"
                    (GridValue.minMax <| Grid.MinMax(px 300, MaxContent))
                    "minmax(300px, max-content)"

                testString
                    "MinMax px and auto"
                    (GridValue.minMax <| Grid.MinMax(px 200, Auto))
                    "minmax(200px, auto)"

                testString
                    "MinMax pct and px"
                    (GridValue.minMax <| Grid.MinMax(pct 30, px 300))
                    "minmax(30%, 300px)"

                testString
                    "MinMax min content and px"
                    (GridValue.minMax <| Grid.MinMax(MinContent, px 200))
                    "minmax(min-content, 200px)"

                testString
                    "MinMax auto and px"
                    (GridValue.minMax <| Grid.MinMax(Auto, px 300))
                    "minmax(auto, 300px)"

                test
                    "Grid auto columns min content"
                    [GridAutoColumn MinContent]
                    ["grid-auto-columns" ==> "min-content"]
            
                test
                    "Grid auto columns max content"
                    [GridAutoColumn MaxContent]
                    ["grid-auto-columns" ==> "max-content"]
                    
                test
                    "Grid auto columns auto"
                    [GridAutoColumn Auto]
                    ["grid-auto-columns" ==> "auto"]
                    
                test
                    "Grid auto columns px"
                    [GridAutoColumn (px 100)]
                    ["grid-auto-columns" ==> "100px"]
            
                test
                    "Grid auto columns cm"
                    [GridAutoColumn (cm 20.)]
                    ["grid-auto-columns" ==> "20.0cm"]
                    
                test
                    "Grid auto columns vmax"
                    [GridAutoColumn (vmax 50.)]
                    ["grid-auto-columns" ==> "50.0vmax"]
                    
                test
                    "Grid auto columns percent"
                    [GridAutoColumn (pct 10)]
                    ["grid-auto-columns" ==> "10%"]
                    
                test
                    "Grid auto columns fr"
                    [GridAutoColumn (fr 0.5)]
                    ["grid-auto-columns" ==> "0.50fr"]
                
                test
                    "Grid auto columns fit content"
                    [GridAutoColumn (FitContent(px 400)) ]
                    ["grid-auto-columns" ==> "fit-content(400px)"]

                test
                    "Grid auto columns multiple with min-content max-content and auto"
                    [ GridAutoColumns [MinContent; MaxContent; Auto] ]
                    ["grid-auto-columns" ==> "min-content max-content auto"]
                    
                test
                    "Grid auto columns multiple with pxs"
                    [ GridAutoColumns [px 100; px 150; px 390;] ]
                    ["grid-auto-columns" ==> "100px 150px 390px"]
                    
                test
                    "Grid auto columns multiple with percents"
                    [ GridAutoColumns [pct 10; pct 33] ]
                    ["grid-auto-columns" ==> "10% 33%"]
                    
                test
                    "Grid auto columns multiple with fractions"
                    [ GridAutoColumns [fr 0.5; fr 3.; fr 1.] ]
                    ["grid-auto-columns" ==> "0.50fr 3.00fr 1.00fr"]
                    
                test
                    "Grid auto columns multiple with minmaxs"
                    [ GridAutoColumns [ Grid.MinMax(px 100, Auto); Grid.MinMax(MaxContent, fr 2.); Grid.MinMax(pct 20, vmax 80.) ] ]
                    ["grid-auto-columns" ==> "minmax(100px, auto) minmax(max-content, 2.00fr) minmax(20%, 80.0vmax)"]
                    
                test
                    "Grid auto columns multiple with a combination"
                    [ GridAutoColumns [px 100; Grid.MinMax(px 100, Auto); pct 10; fr 0.5; FitContent(px 400)] ]
                    ["grid-auto-columns" ==> "100px minmax(100px, auto) 10% 0.50fr fit-content(400px)"]
                    
                test
                    "Grid auto columns inherit"
                    [GridAutoColumn Inherit]
                    ["grid-auto-columns" ==> "inherit"]
                    
                test
                    "Grid auto columns initial"
                    [GridAutoColumn Initial]
                    ["grid-auto-columns" ==> "initial"]
                    
                test
                    "Grid auto columns unset"
                    [GridAutoColumn Unset]
                    ["grid-auto-columns" ==> "unset"] 
               
                test
                    "Grid auto rows min content"
                    [GridAutoRow MinContent]
                    ["grid-auto-rows" ==> "min-content"]
            
                test
                    "Grid auto rows max content"
                    [GridAutoRow MaxContent]
                    ["grid-auto-rows" ==> "max-content"]
                    
                test
                    "Grid auto rows auto"
                    [GridAutoRow Auto]
                    ["grid-auto-rows" ==> "auto"]
                    
                test
                    "Grid auto rows px"
                    [GridAutoRow (px 100)]
                    ["grid-auto-rows" ==> "100px"]
            
                test
                    "Grid auto rows cm"
                    [GridAutoRow (cm 20.)]
                    ["grid-auto-rows" ==> "20.0cm"]
                    
                test
                    "Grid auto rows vmax"
                    [GridAutoRow (vmax 50.)]
                    ["grid-auto-rows" ==> "50.0vmax"]
                    
                test
                    "Grid auto rows percent"
                    [GridAutoRow (pct 10)]
                    ["grid-auto-rows" ==> "10%"]
                    
                test
                    "Grid auto rows fr"
                    [GridAutoRow (fr 0.5)]
                    ["grid-auto-rows" ==> "0.50fr"]
                
                test
                    "Grid auto rows fit content"
                    [GridAutoRow (FitContent(px 400)) ]
                    ["grid-auto-rows" ==> "fit-content(400px)"]

                test
                    "Grid auto rows multiple with min-content max-content and auto"
                    [ GridAutoRows [MinContent; MaxContent; Auto] ]
                    ["grid-auto-rows" ==> "min-content max-content auto"]
                    
                test
                    "Grid auto rows multiple with pxs"
                    [ GridAutoRows [px 100; px 150; px 390;] ]
                    ["grid-auto-rows" ==> "100px 150px 390px"]
                    
                test
                    "Grid auto rows multiple with percents"
                    [ GridAutoRows [pct 10; pct 33] ]
                    ["grid-auto-rows" ==> "10% 33%"]
                    
                test
                    "Grid auto rows multiple with fractions"
                    [ GridAutoRows [fr 0.5; fr 3.; fr 1.] ]
                    ["grid-auto-rows" ==> "0.50fr 3.00fr 1.00fr"]
                    
                test
                    "Grid auto rows multiple with minmaxs"
                    [ GridAutoRows [ Grid.MinMax(px 100, Auto); Grid.MinMax(MaxContent, fr 2.); Grid.MinMax(pct 20, vmax 80.) ] ]
                    ["grid-auto-rows" ==> "minmax(100px, auto) minmax(max-content, 2.00fr) minmax(20%, 80.0vmax)"]
                    
                test
                    "Grid auto rows multiple with a combination"
                    [ GridAutoRows [px 100; Grid.MinMax(px 100, Auto); pct 10; fr 0.5; FitContent(px 400)] ]
                    ["grid-auto-rows" ==> "100px minmax(100px, auto) 10% 0.50fr fit-content(400px)"]
                    
                test
                    "Grid auto rows inherit"
                    [GridAutoRow Inherit]
                    ["grid-auto-rows" ==> "inherit"]
                    
                test
                    "Grid auto rows initial"
                    [GridAutoRow Initial]
                    ["grid-auto-rows" ==> "initial"]
                    
                test
                    "Grid auto rows unset"
                    [GridAutoRow Unset]
                    ["grid-auto-rows" ==> "unset"] 
                
                test
                    "Grid auto flow rosw"
                    [GridAutoFlow Grid.Rows]
                    ["grid-auto-flow" ==> "rows"]
                
                test
                    "Grid auto flow columns"
                    [GridAutoFlow Grid.Columns]
                    ["grid-auto-flow" ==> "columns"]
                
                test
                    "Grid auto flow dense"
                    [GridAutoFlow Grid.Dense]
                    ["grid-auto-flow" ==> "dense"]
                
                test
                    "Grid auto flow rows dense"
                    [GridAutoFlow2(Grid.Rows, Grid.Dense)]
                    ["grid-auto-flow" ==> "rows dense"]
                
                test
                    "Grid auto flow columns dense"
                    [GridAutoFlow2(Grid.Columns, Grid.Dense)]
                    ["grid-auto-flow" ==> "columns dense"]
                
                test
                    "Grid auto flow inherit"
                    [GridAutoFlow Inherit]
                    ["grid-auto-flow" ==> "inherit"]
                
                test
                    "Grid auto flow initial"
                    [GridAutoFlow Initial]
                    ["grid-auto-flow" ==> "initial"]
                
                test
                    "Grid auto flow unset"
                    [GridAutoFlow Unset]
                    ["grid-auto-flow" ==> "unset"]
                    
                test
                    "Grid template areas None"
                    [GridTemplateAreas None]
                    ["grid-template-areas" ==> "none"]
                    
                test
                    "Grid template areas strings"
                    [GridTemplateAreas (Grid.TemplateArea [[ Ident "a"; Ident "b"  ]]) ]
                    ["grid-template-areas" ==> "\" a b \""]
                    
                test
                    "Grid template areas multiple strings"
                    [GridTemplateAreas (Grid.TemplateArea [
                        [Ident "header"; Ident "header"; Ident "header"; Ident "header" ]
                        [Ident "main"; Ident "main"; Ident "."; Ident "sidebar" ]
                        [Ident "footer"; Ident "footer"; Ident "footer"; Ident "footer" ]
                    ]) ]
                    ["grid-template-areas" ==> "\" header header header header \" \" main main . sidebar \" \" footer footer footer footer \""]
                    
                test
                    "Grid template areas inherit"
                    [GridTemplateAreas Inherit ]
                    ["grid-template-areas" ==> "inherit"]
                    
                test
                    "Grid template areas initial"
                    [GridTemplateAreas Initial]
                    ["grid-template-areas" ==> "initial"]
                    
                test
                    "Grid template areas multiple unset"
                    [GridTemplateAreas Unset]
                    ["grid-template-areas" ==> "unset"]
            ]