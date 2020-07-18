module Tests

open Fable.Core
open Fable.Mocha
open Fable.React
open Fable.React.Props
open Fable.ReactTestingLibrary

open Fss.Main
open Fss.Fonts
open Fss.Color
open Fss.Units

let testCase' name case = 
    testCase name <| fun _ -> 
        use dispose = { new System.IDisposable with member this.Dispose() = RTL.cleanup() }
        case()

[<Emit("window.getComputedStyle(document.getElementById('$0'));")>]
let getComputedCssById (id : string) : obj  = jsNative

[<Emit("$0[$1];")>]
let getValue (object: obj) (key: string) : string = jsNative

let CssTests =
    testList "Css tests" [
        testCase' "Style color with named color" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color aliceblue]) ]
                            []

                        div 
                            [ Id "colorPink"; ClassName (fss [ BackgroundColor deeppink]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorPink")
            Expect.equal (getValue color "color") "rgb(240, 248, 255)" "named color"
            Expect.equal (getValue colorAlpha "background-color") "rgb(255, 20, 147)" "named background color"

        testCase' "Style color with RGB" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color (rgb 255 0 0)]) ]
                            []

                        div 
                            [ Id "colorAlpha"; ClassName (fss [ Color (rgba 255 255 255 0.5)]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorAlpha")
            Expect.equal (getValue color "color") "rgb(255, 0, 0)" "color rgb style applied"
            Expect.equal (getValue colorAlpha "color") "rgba(255, 255, 255, 0.5)" "color rgba style applied"

        testCase' "Style color with HEX" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color (hex "ff0000")]) ]
                            []

                        div 
                            [ Id "colorAlpha"; ClassName (fss [ Color (hex "ff000080")]) ]
                            []

                        div 
                            [ Id "colorHash"; ClassName (fss [ Color (hex "#00FF00")]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorAlpha")
            let colorHash = getComputedCssById("colorHash")
            Expect.equal (getValue color "color") "rgb(255, 0, 0)" "color hex style applied"
            Expect.equal (getValue colorAlpha "color") "rgba(255, 0, 0, 0.5)" "color hex style applied with alpha"
            Expect.equal (getValue colorHash "color") "rgb(0, 255, 0)" "color hex style applied with hash"

        testCase' "Style color with hsl" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color (hsl 120 1.0 0.5)]) ]
                            []

                        div 
                            [ Id "colorAlpha"; ClassName (fss [ Color (hsla 120 1.0 0.5 0.5)]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorAlpha")
            Expect.equal (getValue color "color") "rgb(0, 255, 0)" "color hsl style applied"
            Expect.equal (getValue colorAlpha "color") "rgba(0, 255, 0, 0.5)" "color hsla style applied"

        testCase' "Font-size" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "small"; ClassName (fss [ FontSize Small ]) ]
                            []

                        div 
                            [ Id "large"; ClassName (fss [ FontSize Large ]) ]
                            []


                        div 
                            [ Id "px"; ClassName (fss [ FontSize (px 100) ]) ]
                            []

                        div 
                            [ Id "pct"; ClassName (fss [ FontSize (pct 200) ]) ]
                            []
                    ]
            ) |> ignore
            
            let small = getComputedCssById("small")
            let large = getComputedCssById("large")
            let px = getComputedCssById("px")
            let pct = getComputedCssById("pct")
            Expect.equal (getValue small "font-size") "13px" "font size set to small"
            Expect.equal (getValue large "font-size") "18px" "font size set to large"
            Expect.equal (getValue px "font-size") "100px" "font size set with pixels"
            Expect.equal (getValue pct "font-size") "32px" "font size set with percent"
    ]

Mocha.runTests CssTests |> ignore