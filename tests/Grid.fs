namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Grid =
    let tests =
        testList "Grid"
            [
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
                
                
            
            ]