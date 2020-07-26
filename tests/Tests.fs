module Tests

open Fable.Core
open Fable.Mocha
open Fable.React
open Fable.React.Props
open Fable.ReactTestingLibrary

open Fss
open Html
open Fss.Utilities.Global
open Property
open Fss
open Value
open Color
open Units.Size
open Units.Angle
open Fonts
open BorderStyle
open BorderWidth
open Animation
open Keyframes
open Transform
open Transition
open Display
open JustifyContent
open AlignItems
open FlexDirection
open FlexWrap
open JustifyContent
open AlignSelf
open AlignContent
open Order
open FlexGrow
open FlexShrink
open FlexBasis
open Margin
open Selector

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
                            [ Id "short"; ClassName (fss 
                                [
                                    BorderWidth Thick
                                    BorderStyle Dotted
                                    BorderColor aliceblue
                                ])]
                            []

                        div 
                            [ Id "style"; ClassName (fss [ BorderStyles [Dashed; Groove; BorderStyle.None; Dotted] ]) ]
                            []
                        div
                            [ Id "radius"; ClassName (fss [ BorderRadius (px 10)])] []
                    ]
            ) |> ignore
            
            let shortHand = getComputedCssById("short")
            let style = getComputedCssById("style")
            let radius = getComputedCssById("radius")

            Expect.equal (getValue shortHand "border-left-style") "dotted" "border style set"
            Expect.equal (getValue shortHand "border-left-color") "rgb(240, 248, 255)" "border color set"
            Expect.equal (getValue style "border-top-style") "dashed" "mixed border style"
            Expect.equal (getValue style "border-right-style") "groove" "mixed border style"
            Expect.equal (getValue style "border-bottom-style") "none" "mixed border style"
            Expect.equal (getValue style "border-left-style") "dotted" "mixed border style"
            Expect.equal (getValue radius "border-top-left-radius") "10px" "border radius"
            
        testCase' "Animations" <| fun _ ->

            let testFrames = keyframes [ frame 0 [ BackgroundColor red]; frame 100 [ BackgroundColor blue] ]
            let testFrames2 = keyframes [ frame 0 [ BackgroundColor green]; frame 100 [ BackgroundColor orangered] ]
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
            let combinedAnimations = 
                fss 
                    [ 
                        Animations 
                            [ 
                                [testFrames; sec 10.0; Ease; mSec 0.5; Infinite; Both; Alternate; Running]
                                [testFrames2; sec 1.0; Linear; sec 10.0; IterationCount.Value 3; Both; Reverse; Paused] 
                            ] 
                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "anim"; ClassName shortHand ] []    
                        div [ Id "anim2"; ClassName longNotation ] []    
                        div [ Id "anim3"; ClassName combinedAnimations ] []    
                    ]
            ) |> ignore
            
            let anim = getComputedCssById("anim")
            let anim2 = getComputedCssById("anim2")
            let anim3 = getComputedCssById("anim3")

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

            Expect.equal (getValue anim3 "animation-name") (sprintf "%A, %A" testFrames testFrames2) "Sets animation names"
            Expect.equal (getValue anim3 "animation-duration") "10s, 1s" "Sets animation durations"
            Expect.equal (getValue anim3 "animation-timing-function") "ease, linear" "Sets animation timing functions"
            Expect.equal (getValue anim3 "animation-delay") "0.0005s, 10s" "Sets animation delays"
            Expect.equal (getValue anim3 "animation-iteration-count") "infinite, 3" "Sets animation iteration counts"
            Expect.equal (getValue anim3 "animation-fill-mode") "both, both" "Sets animation fillmodes"
            Expect.equal (getValue anim3 "animation-direction") "alternate, reverse" "Sets animation direction counts"
            Expect.equal (getValue anim3 "animation-play-state") "running, paused" "Sets animation playstates"

        testCase' "Style width and height" <| fun _ ->         
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "size"; ClassName (fss [ Width (px 100); Height (px 50) ]) ]
                            []
                    ]
            ) |> ignore
                
            let color = getComputedCssById("size")
            Expect.equal (getValue color "width") "100px" "width gets set"
            Expect.equal (getValue color "height") "50px" "height gets set"

        testCase' "Set global values" <| fun _ ->
            let style = 
                fss
                    [
                        Color Inherit
                        BackgroundColor Initial
                    ]

            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "globals"; ClassName style ]
                            []
                    ]
            ) |> ignore
                
            let globals = getComputedCssById("globals")
            Expect.equal (getValue globals "color") "rgb(0, 0, 0)" "Inherit set"
            Expect.equal (getValue globals "background-color") "rgba(0, 0, 0, 0)" "Initial set"

        testCase' "Set margin" <| fun _ ->
            let shortShortHand = 
                fss
                    [
                        CSSProperty.Margin (px 10)
                    ]

            let shortHand =
                fss
                    [
                        Margins [px 10; px 20; px 30; px 40]
                    ]

            let margin =
                fss
                    [
                        MarginTop (px 30)
                        MarginRight (px 20)
                        MarginBottom (px 40)
                        MarginLeft (px 10)
                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "shortShortHand"; ClassName shortShortHand ] []
                        div [ Id "shortHand"; ClassName shortHand ] []
                        div [ Id "margins"; ClassName margin ] []
                    ]
            ) |> ignore
                
            let shortShortHand = getComputedCssById("shortShortHand")
            Expect.equal (getValue shortShortHand "margin-top") "10px" "Margin top gets set"
            Expect.equal (getValue shortShortHand "margin-right") "10px" "Margin top gets set"
            Expect.equal (getValue shortShortHand "margin-bottom") "10px" "Margin top gets set"
            Expect.equal (getValue shortShortHand "margin-left") "10px" "Margin top gets set"

            let shortHand = getComputedCssById("shortHand")
            Expect.equal (getValue shortHand "margin-top") "10px" "Margin top gets set shorthand"
            Expect.equal (getValue shortHand "margin-right") "20px" "Margin top gets set shorthand"
            Expect.equal (getValue shortHand "margin-bottom") "30px" "Margin top gets set shorthand"
            Expect.equal (getValue shortHand "margin-left") "40px" "Margin top gets set shorthand"

            let margin = getComputedCssById("margins")
            Expect.equal (getValue margin "margin-top") "30px" "Margin top gets set margins"
            Expect.equal (getValue margin "margin-right") "20px" "Margin top gets set margins"
            Expect.equal (getValue margin "margin-bottom") "40px" "Margin top gets set margins"
            Expect.equal (getValue margin "margin-left") "10px" "Margin top gets set margins"
            (*
        testCase' "Flexbox tests" <| fun _ ->
            let flex =
                fss
                    [
                        Display Display.Flex
                        FlexDirection Column
                        FlexWrap FlexWrap.Wrap
                        FlexGrow (Grow 1)
                        FlexShrink (Shrink 1)
                        CSSProperty.FlexBasis (px 120)
                        JustifyContent JustifyContent.SpaceAround
                        AlignContent AlignContent.Center
                        AlignItems AlignItems.Center

                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "flex"; ClassName flex ] []
                    ]
            ) |> ignore
                    
            let flex = getComputedCssById("flex")
            Expect.equal (getValue flex "display") "flex" "Display gets set"
            Expect.equal (getValue flex "flex-direction") "column" "flex direction gets set"
            Expect.equal (getValue flex "flex-wrap") "wrap" "flex wrap gets set"
            Expect.equal (getValue flex "flex-grow") "1" "flex grow gets set"
            Expect.equal (getValue flex "flex-shrink") "1" "flex shrink gets set"
            Expect.equal (getValue flex "flex-basis") "120px" "flex basis gets set"
            Expect.equal (getValue flex "justify-content") "space-around" "justify content gets set"
            Expect.equal (getValue flex "align-content") "center" "align content gets set"
            Expect.equal (getValue flex "align-items") "center" "align items gets set"

        testCase' "Style descendant" <| fun _ ->
            let style =
                fss
                    [
                       Selector ((Descendant Div), [ BackgroundColor red ])
                    ]
            
            RTL.render(
                div [ ClassName style ]
                    [
                        div [ Id "foo" ] [ str "foo" ]
                    ]
            ) |> ignore
                    
            let style = getComputedCssById("foo")
            Expect.equal (getValue style "background-color") "rgb(255, 0, 0)" "Descendant gets background color"

        testCase' "Transitions" <| fun _ ->
            let oneTransition =
                fss
                    [
                       Transition (Transition1(backgroundColor, (sec 10.0)))
                    ]

            let manyTransitions =
                fss
                    [
                       Transitions 
                        [
                            Transition1(backgroundColor, (sec 10.0))
                            Transition2(color, (sec 20.0), EaseInOut)
                            Transition3(width, (sec 30.0), EaseOut, (sec 20.0))
                        ]
                    ]
            
            RTL.render(
                fragment []
                    [
                        div [ Id "one"; ClassName oneTransition ] []
                        div [ Id "two"; ClassName manyTransitions ] []
                    ]
            ) |> ignore
                    
            let one = getComputedCssById("one")
            let two = getComputedCssById("two")

            Expect.equal (getValue one "transition-property") "background-color" "Background color is the transition property"
            Expect.equal (getValue one "transition-duration") "10s" "transition duration is 10 sec"

            Expect.equal (getValue two "transition-property") "background-color, color, width" "transition properties for multiple transitions set"
            Expect.equal (getValue two "transition-duration") "10s, 20s, 30s" "transition duration for multiple transitions set"
            Expect.equal (getValue two "transition-timing-function") "ease, ease-in-out, ease-out" "transition timing function set"
            Expect.equal (getValue two "transition-delay") "0s, 0s, 20s" "transition delay set"
            *)
    ]

Mocha.runTests CssTests |> ignore





