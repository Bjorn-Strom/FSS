module App

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props

open Fss
open Fss
open Css
open Color
open Units.Size
open Fonts
open BorderStyle
open BorderWidth
open BorderColor
open Animation
open Keyframes
open Transform
open Transition

type Model = { Message : string}
type Msg = | NoMessage
let init() = { Message = "Hello" }

let update (msg: Msg) (model: Model): Model =
    match msg with
    | NoMessage -> model

let ColorExamples =
    fragment []
        [
            h1 [] [ str "Color" ]
            p [] [ str "Tons of different ways to style color" ]
            p [ ClassName (fss [Color deeppink]) ] [ str "Named colors like deeppink"]
            p [ ClassName (fss [Color (rgb 255 0 0)])] [ str "Or you can style it using an RGB function!"]
            p [ ClassName (fss [Color (rgba 0 0 0 0.5)])] [ str "We also support RGBA"]
            p [ ClassName (fss [Color (hex "00ff00")])] [ str "or you can use HEX"]
            p [ ClassName (fss [Color (hex "0000ff80")])] [ str "HEX can also be transparent"]
            p [ ClassName (fss [Color (hsl 120 0.5 0.5)])] [ str "Or just use HSL"]
            p [ ClassName (fss [Color (hsla 120 0.5 0.5 0.5)])] [ str "HSL can also be transparent"]
        ]

let FontExamples =
    fragment []
        [
            h1 [] [ str "fonts" ]
            h2 [] [ str "font-size"]
            p [ClassName (fss [FontSize XxSmall])] [ str "Fonts can be xx-Small" ]
            p [ClassName (fss [FontSize XSmall])] [ str "Fonts can be x-Small" ]
            p [ClassName (fss [FontSize Small])] [ str "Fonts can be small" ]
            p [ClassName (fss [FontSize Medium])] [ str "Fonts can be medium" ]
            p [ClassName (fss [FontSize Large])] [ str "Fonts can be large" ]
            p [ClassName (fss [FontSize XLarge])] [ str "Fonts can be x-large" ]
            p [ClassName (fss [FontSize XxLarge])] [ str "Fonts can be xx-large" ]
            p [ClassName (fss [FontSize XxxLarge])] [ str "Fonts can be xxx-large" ]
            p [ClassName (fss [FontSize Smaller])] [ str "Fonts can be smaller" ]
            p [ClassName (fss [FontSize Larger])] [ str "Fonts can be larger" ]

            p [ClassName (fss [FontSize (px 28)])] [ str "Fonts can be set with pixels" ]
            p [ClassName (fss [FontSize (pct 300)])] [ str "Fonts can be set with percent" ]
            p [ClassName (fss [FontSize (em 2.5)])] [ str "Fonts can be set with ems" ]
            p [ClassName (fss [FontSize (rem 3.0)])] [ str "Fonts can be set with rems" ]
            p [ClassName (fss [FontSize (cm 3.3)])] [ str "Fonts can be set with cm" ]
            p [ClassName (fss [FontSize (mm 33.3)])] [ str "Fonts can be set with mm" ]
            p [] [ str "and more!"]
        ]

let BorderExamples =
    fragment []
        [
            h1 [] [ str "borders"]
            h2 [] [ str "Set unique borders"]
            p [ ClassName (fss [BorderStyle [Solid]])] [ str "I have a solid border" ]
            p [ ClassName (fss [BorderStyle [Double]])] [ str "I have a double border"]
            p [ ClassName (fss [BorderStyle [Groove]])] [ str "I have a groove border"]
            p [ ClassName (fss [BorderStyle [Inset]])] [ str "I have an inset border"]
            p [ ClassName (fss [BorderStyle [Ridge]])] [ str "I have a ridge border"]
            p [ ClassName (fss [BorderStyle [Dashed]])] [ str "I have a dashed border"]
            p [ ClassName (fss [BorderStyle [Dotted]])] [ str "I have a dotted border"]
            p [ ClassName (fss [BorderStyle [Outset]])] [ str "I have an outset border"]
            p [ ClassName (fss [BorderStyle [Hidden]])] [ str "I have a hidden border"]
            p [ ClassName (fss [BorderStyle [BorderStyle.None]])] [ str "I don't have a border"]
            p [ ClassName (fss [BorderStyle [Groove; Dotted; Solid; Dashed]])] [ str "I have a mixed border"]
            p [] [ str "We can also apply only border width" ]
            p [ ClassName (fss 
                    [
                        BorderWidth [Thin]
                        BorderStyle [Solid]
                    ])] [ str "I have a thin border" ]
            p [ ClassName (fss 
                    [
                        BorderWidth [px 3]
                        BorderStyle [Solid]
                    ])] [ str "I have a 3px border" ]
            p [ ClassName (fss 
                    [
                        BorderWidth [px 3; px 4; px 5; px 6]
                        BorderStyle [Solid]
                    ])] [ str "I have a mixed width border" ]
            p [ ClassName (fss [Border [Thick; Double; green]])] [ str "Border shorthand also works" ]
            p [ ClassName (fss 
                    [
                        BorderStyle [Solid]
                        BorderTopWidth (px 10)
                    ])] [ str "top width" ]
            p [ ClassName (fss 
                    [
                        BorderStyle [Solid]
                        BorderRightWidth (px 10)
                    ])] [ str "right width" ]
            p [ ClassName (fss 
                    [
                        BorderStyle [Solid]
                        BorderBottomWidth (px 10)
                    ])] [ str "bottom width" ]
            p [ ClassName (fss 
                    [
                        BorderStyle [Solid]
                        BorderLeftWidth (px 10)
                    ])] [ str "left width" ]
            p [ ClassName (fss
                    [
                        Color white
                        BackgroundColor purple
                        BorderRadius [px 10; px (100 / 120) ]
                    ])] [ str "Border radius!"]
            p [ ClassName (fss
                    [
                        Color yellowgreen
                        BackgroundColor purple
                        BorderTopLeftRadius [px 10]
                    ])] [ str "Top left Border radius!"]
            p [ ClassName (fss
                    [
                        BorderStyle [Solid]
                        BorderWidth [px 15]
                        BorderColor [red; rgba 170 50 220 0.6; green]                        
                    ]
            )] [ str "Now in color!"]
            
            p [ ClassName (fss
                    [
                        Border [Dashed; px 15]
                        BorderTopWidth (px 20)
                        BorderTopColor deeppink
                        BorderBottomWidth (px 1)
                        BorderLeftWidth (px 10)
                        BorderRightWidth (px 10)
                        BorderLeftColor gold
                        BorderRightColor rosybrown
                    ]
            )] [ str "Now in color!"]

        ]

let AnimationExamples =

    let bounceFrames = 
        keyframes
            [
                frames [ 0; 20; 53; 80; 100 ]
                    [
                        Transform (Translate3D(px 0, px 0, px 0))
                        BackgroundColor red
                    ]
                frames [40; 43]
                    [
                        Transform <| Translate3D(px 0, px -30, px 0)
                        BackgroundColor blue
                    ]
                frame 70
                    [
                        Transform <| Translate3D(px 0, px -15, px 0)
                        BackgroundColor green
                    ]
                frame 90
                    [
                        Transform <| Translate3D(px 0, px -4, px 0)
                        BackgroundColor orange
                    ]
            ] 

    let sizeFrames =
        keyframes
            [
                frame 0 [ FontSize (pct 50) ]
                frame 50 [ FontSize (pct 150) ]
                frame 100 [ FontSize (pct 50) ]
            ]

    let bounceAnimation = fss [ Animation [bounceFrames; sec 1.0; Ease; Infinite] ]

    let sizeAnimation =
        fss 
            [
                AnimationName sizeFrames
                AnimationDuration (sec 3.0)
                AnimationTimingFunction EaseInOut
                AnimationIterationCount (IterationCount.Value 3)
            ]

    let combinedAnimations =
        fss
            [
                Animations 
                    [
                        [ bounceFrames; sec 1.0; Ease; Infinite]
                        [ sizeFrames; sec 3.0; EaseInOut; IterationCount.Value 3 ]
                    ]
            ]

    fragment []
        [
            p [] [ str "Things can animate now!" ]
            p [ClassName bounceAnimation] [str "Bouncing text"]
            p [ClassName sizeAnimation] [str "Weeeeeeeeee"]
            p [ClassName combinedAnimations] [str "COMBINED"]
            p [ClassName (fss [
                BackgroundColor red
                Transition (backgroundColor3 (sec 2.5) Ease (sec 2.5))
                Hover 
                    [
                        BackgroundColor green
                    ]
                    
            ])] [ str "I have a transition! Hover me!" ]
        ]

let render (model: Model) (dispatch: Msg -> unit) =
    div [] 
        [
            //ColorExamples
            //FontExamples
            //BorderExamples
            AnimationExamples
        ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
