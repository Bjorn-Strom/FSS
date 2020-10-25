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
                    [GridTemplateRow (Grid.Repeat(Grid.Value 3, px 200))]
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
                    [GridTemplateColumn (Grid.Repeat(Grid.Value 3, px 200))]
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
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, fr 1.))
                    "repeat(4, 1.00fr)"
                    
                testString
                    "Repat value and percent"
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, pct 60))
                    "repeat(4, 60%)"
                    
                testString
                    "Repat value and pixels"
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, px 250))
                    "repeat(4, 250px)"
                            
                testString
                    "Repat value and min-content"
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, MinContent))
                    "repeat(4, min-content)"
                
                testString
                    "Repat value and max-content"
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, MaxContent))
                    "repeat(4, max-content)"
                    
                testString
                    "Repat value and auto"
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, Auto))
                    "repeat(4, auto)"     
                
                testString
                    "Repat value and minmax"
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, Grid.MinMax(px 100, fr 1.)))
                    "repeat(4, minmax(100px, 1.00fr))"
                    
                testString
                    "Repat value and fit content"
                    (GridValue.repeat <| Grid.Repeat(Grid.Value 4, FitContent(px 100)))
                    "repeat(4, fit-content(100px))" 

                testString
                    "Repat value and px pct and auto"
                    (GridValue.repeat <| Grid.RepeatMany(Grid.Value 4, [px 10; pct 30; Auto]))
                    "repeat(4, 10px 30% auto)"
                                    
                testString
                    "Repat value and min-content max-content"
                    (GridValue.repeat <| Grid.RepeatMany(Grid.Value 4, [MinContent; MaxContent]))
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
                    (GridValue.repeat <| Grid.RepeatMany(Grid.Value 4, [MinContent; MaxContent]))
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
                    "Grid auto flow row"
                    [GridAutoFlow Grid.Row]
                    ["grid-auto-flow" ==> "row"]
                
                test
                    "Grid auto flow column"
                    [GridAutoFlow Grid.Column]
                    ["grid-auto-flow" ==> "column"]
                
                test
                    "Grid auto flow dense"
                    [GridAutoFlow Grid.Dense]
                    ["grid-auto-flow" ==> "dense"]
                
                test
                    "Grid auto flow row dense"
                    [GridAutoFlow2(Grid.Row, Grid.Dense)]
                    ["grid-auto-flow" ==> "row dense"]
                
                test
                    "Grid auto flow column dense"
                    [GridAutoFlow2(Grid.Column, Grid.Dense)]
                    ["grid-auto-flow" ==> "column dense"]
                
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
                    [GridTemplateAreas (Grid.TemplateArea [[ "a"; "b"  ]]) ]
                    ["grid-template-areas" ==> "\" a b \""]
                    
                test
                    "Grid template areas multiple strings"
                    [GridTemplateAreas (Grid.TemplateArea [
                        ["header"; "header"; "header"; "header" ]
                        ["main"; "main"; "."; "sidebar" ]
                        ["footer"; "footer"; "footer"; "footer" ]
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
