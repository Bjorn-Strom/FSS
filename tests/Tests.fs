module Tests

open Fable.Core
open Fable.Mocha
open Fable.React
open Fable.React.Props
open Fable.ReactTestingLibrary
open Browser

open Fss
open Fss
open Css
open Color
open Units.Size
open Fonts
open BorderStyle
open BorderWidth
open Animation
open Keyframes
open Transform

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

        testCase' "Borders" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "short"; ClassName (fss [ Border [Thick; Dotted; aliceblue ]]) ]
                            []

                        div 
                            [ Id "style"; ClassName (fss [ BorderStyle [Dashed; Groove; BorderStyle.None; Dotted] ]) ]
                            []
                        div
                            [ Id "radius"; ClassName (fss [ BorderRadius [(px 10)]])] []
                    ]
            ) |> ignore
            
            let shortHand = getComputedCssById("short")
            let style = getComputedCssById("style")
            let radius = getComputedCssById("radius")

            Expect.equal (getValue shortHand "border-left-style") "dotted" "border shorthand"
            Expect.equal (getValue shortHand "border-left-color") "rgb(240, 248, 255)" "border shorthand"
            Expect.equal (getValue style "border-top-style") "dashed" "mixed border style"
            Expect.equal (getValue style "border-right-style") "groove" "mixed border style"
            Expect.equal (getValue style "border-bottom-style") "none" "mixed border style"
            Expect.equal (getValue style "border-left-style") "dotted" "mixed border style"
            Expect.equal (getValue radius "border-top-left-radius") "10px" "border radius"

        testCase' "Animations" <| fun _ ->

            let testFrames = keyframes [ frame 0 [ BackgroundColor red]; frame 100 [ BackgroundColor blue] ]
            let shortHand = fss [ Animation [testFrames; sec 10.0; Ease; sec 200.0; Infinite; Both; AlternateReverse; Running] ]
            let longNotation = 
                fss 
                    [
                        AnimationName testFrames
                        AnimationDuration (sec 10.0)
                        AnimationTimingFunction Ease
                        AnimationDelay (sec 200.0)
                        AnimationIterationCount Infinite
                        AnimationFillMode Both
                        AnimationDirection AlternateReverse
                        AnimationPlayState Running
                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "anim"; ClassName shortHand ] []    
                        div [ Id "anim2"; ClassName longNotation ] []    
                    ]
            ) |> ignore
            
            let anim = getComputedCssById("anim")
            let anim2 = getComputedCssById("anim2")

            Expect.equal (getValue anim "animation-name") (string testFrames) "Sets animation name from shorthand"
            Expect.equal (getValue anim "animation-duration") "10s" "Sets animation duration from shorthand"
            Expect.equal (getValue anim "animation-timing-function") "ease" "Sets animation timing function from shorthand"
            Expect.equal (getValue anim "animation-delay") "200s" "Sets animation delay from shorthand"
            Expect.equal (getValue anim "animation-iteration-count") "infinite" "Sets animation iteration count from shorthand"
            Expect.equal (getValue anim "animation-fill-mode") "both" "Sets animation fillmode from shorthand"
            Expect.equal (getValue anim "animation-direction") "alternate-reverse" "Sets animation direction count from shorthand"
            Expect.equal (getValue anim "animation-play-state") "running" "Sets animation playstate from shorthand"

            Expect.equal (getValue anim2 "animation-name") (string testFrames) "Sets animation name"
            Expect.equal (getValue anim2 "animation-duration") "10s" "Sets animation duration"
            Expect.equal (getValue anim2 "animation-timing-function") "ease" "Sets animation timing function "
            Expect.equal (getValue anim2 "animation-delay") "200s" "Sets animation delay"
            Expect.equal (getValue anim2 "animation-iteration-count") "infinite" "Sets animation iteration count"
            Expect.equal (getValue anim2 "animation-fill-mode") "both" "Sets animation fillmode"
            Expect.equal (getValue anim2 "animation-direction") "alternate-reverse" "Sets animation direction count"
            Expect.equal (getValue anim2 "animation-play-state") "running" "Sets animation playstate"



    ]

Mocha.runTests CssTests |> ignore