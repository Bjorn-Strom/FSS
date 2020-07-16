module Tests

open Fable.Core
open Fable.Mocha
open Fable.React
open Fable.React.Props
open Fable.ReactTestingLibrary

open Fss.Main
open Fss.Color

let testCase' name case = 
    testCase name <| fun _ -> 
        use dispose = { new System.IDisposable with member this.Dispose() = RTL.cleanup() }
        case()

[<Emit("window.getComputedStyle(document.getElementById('$0'));")>]
let getComputedCssById (id : string) : obj  = jsNative

[<Emit("$0[$1];")>]
let getValue (object: obj) (key: string) : string = jsNative

let glamorHowToTests =
    testList "Css tests" [
        testCase' "Style color with color" <| fun _ ->
            let color =
                fss 
                    [
                        Color red
                    ]
            RTL.render(
                div 
                    [ Id "color";  ClassName color ]
                    []
            ) |> ignore
            
            let computedCss = getComputedCssById("color")
            Expect.equal (getValue computedCss "color") "rgb(255, 0, 0)" "color color style applied"

        testCase' "Style color with RGB" <| fun _ ->
            let color =
                fss 
                    [
                        Color (rgb 255 0 0)
                    ]
            RTL.render(
                div 
                    [ Id "color";  ClassName color ]
                    []
            ) |> ignore
            
            let computedCss = getComputedCssById("color")
            Expect.equal (getValue computedCss "color") "rgb(255, 0, 0)" "color rgb style applied"

        testCase' "Style color with HEX" <| fun _ ->
            let color =
                fss 
                    [
                        Color (hex "ff0000")
                    ]
            RTL.render(
                div 
                    [ Id "color";  ClassName color ]
                    []
            ) |> ignore
            
            let computedCss = getComputedCssById("color")
            Expect.equal (getValue computedCss "color") "rgb(255, 0, 0)" "color hex style applied"
    ]

Mocha.runTests glamorHowToTests |> ignore