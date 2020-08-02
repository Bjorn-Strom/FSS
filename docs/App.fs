module App

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props

open Fss
open Fss
open Media

open Html
open Global
open Property
open Value
open Color
open Units.Size
open Units.Angle
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
open Fonts
open BackgroundImage
open LinearGradient
open RadialGradient
open BackgroundPosition
open BackgroundRepeat
open Selector

type Model = { 
    FlexDirection: FlexDirection
    FlexWrap: FlexWrap
    AlignContent: AlignContent
    BackgroundRepeat: BackgroundRepeat }
type Msg = 
    | SetFlexDirection of FlexDirection
    | SetFlexWrap of FlexWrap
    | SetAlignContent of AlignContent
    | SetBackgroundRepeat of BackgroundRepeat

let init() = { 
    FlexDirection = Row
    FlexWrap = NoWrap
    AlignContent = Stretch
    BackgroundRepeat = NoRepeat}

let update (msg: Msg) (model: Model): Model =
    match msg with
    | SetFlexDirection direction -> { model with FlexDirection = direction}
    | SetFlexWrap wrap -> { model with FlexWrap = wrap}
    | SetAlignContent content -> { model with AlignContent = content}
    | SetBackgroundRepeat repeat -> { model with BackgroundRepeat = repeat}
   (* 
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
            p [ ClassName (fss [Color (hsla 120 0.5 0.5 0.5)])] [ str "HSL can also be transparent"
            ]
            p [ ClassName (fss [Color Inherit]) ] [ str "Colors can be inherited"]
            p [ ClassName (fss [Color Initial]) ] [ str "Colors can be initialed"]
            p [ ClassName (fss [Color Revert]) ] [ str "Colors can be reverted"]
            p [ ClassName (fss [Color Unset]) ] [ str "Colors can be unset"]
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
            p [ClassName (fss [FontSize Inherit])] [ str "Fonts can inherited" ]
            p [ClassName (fss [FontSize Initial])] [ str "Fonts can initial" ]
            p [ClassName (fss [FontSize Revert])] [ str "Fonts can reverted" ]
            p [ClassName (fss [FontSize Unset])] [ str "Fonts can unset" ]
            p [] [ str "and more!"]
        ]
        
let BorderExamples =
    fragment []
        [
            h1 [] [ str "borders"]
            h2 [] [ str "Set unique borders"]
            p [ ClassName (fss [BorderStyle Solid ])] [ str "I have a solid border" ]
            p [ ClassName (fss [BorderStyle Double ])] [ str "I have a double border"]
            p [ ClassName (fss [BorderStyle Groove])] [ str "I have a groove border"]
            p [ ClassName (fss [BorderStyle Inset])] [ str "I have an inset border"]
            p [ ClassName (fss [BorderStyle Ridge])] [ str "I have a ridge border"]
            p [ ClassName (fss [BorderStyle Dashed])] [ str "I have a dashed border"]
            p [ ClassName (fss [BorderStyle Dotted])] [ str "I have a dotted border"]
            p [ ClassName (fss [BorderStyle Outset])] [ str "I have an outset border"]
            p [ ClassName (fss [BorderStyle Hidden])] [ str "I have a hidden border"]
            p [ ClassName (fss [BorderStyle BorderStyle.None])] [ str "I don't have a border"]
            p [ ClassName (fss [BorderStyles [Groove; Dotted; Solid; Dashed]])] [ str "I have a mixed border"]
            p [] [ str "We can also apply only border width" ]
            p [ ClassName (fss 
                    [
                        BorderWidth Thin
                        BorderStyle Solid
                    ])] [ str "I have a thin border" ]
            p [ ClassName (fss 
                    [
                        BorderWidth (px 3)
                        BorderStyle Solid
                    ])] [ str "I have a 3px border" ]
            p [ ClassName (fss 
                    [
                        BorderWidths [px 3; px 4; px 5; px 6]
                        BorderStyle Solid
                    ])] [ str "I have a mixed width border" ]
            p [ ClassName (fss [
                    BorderStyle Double
                    BorderWidth Thick
                    BorderColor green
                ])] [ str "BorderStyles" ]
            p [ ClassName (fss 
                    [
                        BorderStyle Solid
                        BorderTopWidth (px 10)
                    ])] [ str "top width" ]
            p [ ClassName (fss 
                    [
                        BorderStyle Solid
                        BorderRightWidth (px 10)
                    ])] [ str "right width" ]
            p [ ClassName (fss 
                    [
                        BorderStyle Solid
                        BorderBottomWidth (px 10)
                    ])] [ str "bottom width" ]
            p [ ClassName (fss 
                    [
                        BorderStyle Solid
                        BorderLeftWidth (px 10)
                    ])] [ str "left width" ]
            p [ ClassName (fss
                    [
                        Color white
                        BackgroundColor purple
                        BorderRadiuses [px 10; px (100 / 120) ]
                    ])] [ str "Border radius!"]
            p [ ClassName (fss
                    [
                        Color yellowgreen
                        BackgroundColor purple
                        BorderTopLeftRadius (px 10)
                    ])] [ str "Top left Border radius!"]
            p [ ClassName (fss
                    [
                        BorderStyle Solid
                        BorderWidth (px 15)
                        BorderColors [red; rgba 170 50 220 0.6; green]                        
                    ]
            )] [ str "Now in color!"]
            
            p [ ClassName (fss
                    [
                        BorderStyle Dashed
                        BorderWidth (px 15)
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
                        Transform (Translate3D(px 0, px -30, px 0))
                        BackgroundColor blue
                    ]
                frame 70
                    [
                        Transform (Translate3D(px 0, px -15, px 0))
                        BackgroundColor green
                    ]
                frame 90
                    [
                        Transform (Translate3D(px 0, px -4, px 0))
                        BackgroundColor orange
                    ]
            ]

    let bounceAnimation = fss [ Animation [bounceFrames; sec 1.0; Ease; Infinite] ]


    let sizeFrames =
        keyframes
            [
                frame 0 [ FontSize (pct 50) ]
                frame 50 [ FontSize (pct 150) ]
                frame 100 [ FontSize (pct 50) ]
            ]

    let spinnyFrames =
        keyframes
            [
                frame 0 [ Transform (Rotate(deg 0.0))]
                frame 100 [ Transform (Rotate(deg 360.0))]
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

    let spinnyMation =
        fss 
            [
                Width (px 200)
                Height (px 200)
                BackgroundColor orangered
                Animation [ spinnyFrames; sec 5.0; Infinite; Linear ]
            ]

    let loader =
        keyframes
            [
                frame 0 [ Transforms [ RotateX(deg 0.0); RotateY(deg 0.0) ] ]
                frame 50 [ Transforms [ RotateX(deg 0.0); RotateY(deg 180.0) ] ]
                frame 100 [ Transforms [ RotateX(deg 180.0); RotateY(deg 180.0) ] ]
            ]

    let loaderParent =
        fss
            [
                Height (px 200)
                Width (px 200)
                Display Display.Flex
                JustifyContent JustifyContent.Center
                AlignItems AlignItems.Center
                BackgroundColor (hex "272727")
                Value.Perspective (px 200)
            ]

    let loaderContainer =
        fss
            [
                Width (px 100)
                Height (px 100)
                BorderRadius (px 12)
                BackgroundColor (hex "00dbde")
                Animation [loader; sec 2.0; Linear; Infinite]
            ]
            
    let frameAnimation =
        keyframes
            [
                //frame 0 [ BackgroundPosition; px 0; px 0]
                //frame 100 [ BackgroundPosition; px -500; px 0]
            ]


    fragment []
        [
            p [] [ str "Things can animate now!" ]
            p [ClassName bounceAnimation] [str "Bouncing text"]
            p [ClassName sizeAnimation] [str "Weeeeeeeeee"]
            p [ClassName combinedAnimations] [str "COMBINED"]
            div [ ClassName spinnyMation ] []
            div [ ClassName loaderParent]
                [
                    div [ ClassName loaderContainer ] []
                ]
        ]
        
let MarginExamples =
    fragment []
        [
            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color orangered
                                BackgroundColor rebeccapurple
                                MarginRight (px 50)
                                MarginLeft (px 50)
                                MarginTop (px 50)
                                MarginBottom (px 50)
                            ])
                ]
                [ str "I have margin everywhere!" ]

            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color orangered
                                BackgroundColor rebeccapurple
                                CSSProperty.Margins [px 100; px 50; px 200; px 150]
                            ])
                ]
                [ str "Me tooo!" ]
        ]

let PaddingExamples =
    fragment []
        [
            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color orangered
                                BackgroundColor rebeccapurple
                                PaddingRight (px 50)
                                PaddingLeft (px 50)
                                PaddingTop (px 50)
                                PaddingBottom (px 50)
                            ])
                ]
                [ str "I have padding everywhere!" ]
        
            div [
                    ClassName
                        (fss
                            [
                                Width (px 100)
                                Height (px 100)
                                Color orangered
                                BackgroundColor rebeccapurple
                                Paddings [px 100; px 50; px 200; px 150]
                            ])
                ]
                [ str "Me tooo!" ]
        ]

let TransformExamples =
    fragment []
        [
            h3 [] [ str "Transforms" ]
            div [
                ClassName
                    (fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor red
                            Transform (Skew2(deg 30.0, deg 20.0))
                        ])
            ] []

            div [
                ClassName
                    (fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor orange
                            Transform (Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0))
                        ])
            ] []

            div [
                ClassName
                    (fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor blue
                            Transform Inherit
                        ])
            ] []
        ]

let TransitionExamples =   
    let box =
        fss
            [
                Display Display.InlineBlock
                BackgroundColor pink
                Width (px 200)
                Height (px 200)
                Transition (Transition2(transform, (mSec 300.0), CubicBezier(0.0, 0.47, 0.32, 1.97)))
            ]

    let trigger =
        fss
            [
                Width (px 200)
                Height (px 200)
                BorderWidth (px 20)
                BorderStyle Solid
                BorderColor (hex "ddd")
                Hover 
                    [
                        Selector (Descendant Div, 
                            [
                                Transforms
                                   [
                                       Translate2((px 200), (px 150))
                                       Rotate(deg 20.0)
                                   ]
                            ])
                    ]
            ]

    fragment []
        [
            div [ ClassName trigger ]
                [
                    div [ ClassName box ] []
                ]

            p [ClassName (fss [
                BackgroundColor red
                Transition (Transition3(backgroundColor, (sec 2.5), Ease, (sec 2.5)))
                Hover 
                    [
                        BackgroundColor green
                    ]                 
            ])] [ str "I have a transition! Hover me!" ]
        ]

let FlexBoxExamples model dispatch =
    // Test alignment
    let parent = 
        fss
            [
                Display Display.Flex
                Height (px 300)
                BackgroundColor grey
            ]

    let child =
        fss
            [
                Width (px 100)
                Height (px 100)
                CSSProperty.Margin Auto
                BackgroundColor lightcoral
            ]

    let alignment = 
        div [ ClassName parent]
             [
                div [ ClassName child] []
             ]

    // Test Flex flow property
    let parent = 
        fss
            [
                Display Display.Flex
                FlexDirection Row
                FlexWrap Wrap
                JustifyContent JustifyContent.SpaceAround
            ]

    let child =
        fss
            [
                BackgroundColor tomato
                Width (px 200)
                Height (px 150)
                MarginTop (px 10)
            ]

    let flow =
        div [ ClassName parent]
             [
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
             ]

    // Flex Direction row 
    let parent = 
        fss
            [
                Display Display.Flex
                FlexDirection Row
            ]

    let child =
        fss
            [
                BackgroundColor tomato
                Width (px 50)
                Height (px 50)
                MarginLeft (px 10)
            ]

            
    let rows =
        div [ ClassName parent]
                [
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                ]

    // Flex Direction column
    let parent = 
        fss
            [
                Display Display.Flex
                FlexDirection Column
            ]

    let child =
        fss
            [
                BackgroundColor tomato
                Width (px 50)
                Height (px 50)
                MarginTop (px 10)
            ]
                        
    let columns =
        div [ ClassName parent]
                [
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                ]

    // Flex no wrap 
    let parent = 
        fss
            [
                Display Display.Flex
                Width (em 40.0)
                FlexWrap NoWrap
            ]

    let child =
        fss
            [
                BackgroundColor (hex "#cee")
                Width (em 15.0)
                CSSProperty.Margin (px 10)
            ]
                                    
    let noWrap =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex no wrap 
    let parent = 
        fss
            [
                Display Display.Flex
                Width (em 40.0)
                FlexWrap Wrap
            ]

    let child =
        fss
            [
                BackgroundColor (hex "#cee")
                Width (em 15.0)
                CSSProperty.Margin (px 10)
            ]
                                                
    let wrap =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex no wrap 
    let parent = 
        fss
            [
                Display Display.Flex
                Width (em 40.0)
                FlexWrap WrapReverse
            ]

    let child =
        fss
            [
                BackgroundColor (hex "#cee")
                Width (em 15.0)
                CSSProperty.Margin (px 10)
            ]
                                                            
    let wrapReverse =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex flow
    let parent = 
        fss
            [
                BackgroundColor pink
                CSSProperty.Margins [px 48; Auto; px 0]
                Width (px 600)
                Display Display.Flex
                FlexDirection model.FlexDirection
                FlexWrap model.FlexWrap
            ]

    let child =
        fss
            [
                BackgroundColor black
                Color white
                CSSProperty.Margin (px 6)
                Width (px 120)
            ]
                                                            
    let flexFlow =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                    div [ ClassName child] [ str "5" ]
                    div [ ClassName child] [ str "6" ]
                    div [ ClassName child] [ str "7" ]
                ]

    // AlignContent
    let parent = 
        fss
            [
                BackgroundColor (hex "ccc")
                Display Display.Flex
                FlexWrap Wrap
                Width (pct 100)
                Height (em 20.0)
                AlignContent model.AlignContent
            ]

    let child =
        fss
            [
                BackgroundColor (hex "cee")
                CSSProperty.Margin (px 2)
                Width (pct 18)
            ]

    let alignContent =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                    div [ ClassName child] [ str "5" ]
                    div [ ClassName child] [ str "6" ]
                    div [ ClassName child] [ str "7" ]
                ]

    // Flex-basis & flex grow
    let parent = 
        fss 
            [
                BackgroundColor (hex "ccc")
                Height (px 100)
                Display Display.Flex
                FlexDirection Row
                AlignItems AlignItems.Center
            ]

    let child =
        fss
            [
                CSSProperty.Margins [px 0; px 10]
                BackgroundColor white
                CSSProperty.FlexBasis (px 120)
                CSSProperty.FlexGrow (Grow 1)
                Height (px 75)
                
            ]

    let child3 =
        fss
            [
                CSSProperty.Margins [px 0; px 10]
                BackgroundColor white
                CSSProperty.FlexBasis (px 120)
                CSSProperty.FlexGrow (Grow 2)
                Height (px 75)
            ]

    let flexBasisGrow =
        div [ ClassName parent]
            [
                div [ ClassName child ] []
                div [ ClassName child ] []
                div [ ClassName child3 ] []
            ]

    // Flex-basis & flex shrink
    let parent = 
        fss 
            [
                BackgroundColor (hex "ccc")
                Height (px 100)
                Display Display.Flex
                FlexDirection Row
                AlignItems AlignItems.Center
            ]

    let child =
        fss
            [
                CSSProperty.Margins [px 0; px 10]
                BackgroundColor white
                CSSProperty.FlexBasis (px 120)
                CSSProperty.FlexGrow (Grow 1)
                Height (px 75)
                        
            ]

    let child3 =
        fss
            [
                CSSProperty.Margins [px 0; px 10]
                BackgroundColor white
                CSSProperty.FlexBasis (px 120)
                CSSProperty.FlexShrink (Shrink 2)
                Height (px 75)
            ]

    let flexBasisShrink =
        div [ ClassName parent]
            [
                div [ ClassName child ] []
                div [ ClassName child ] []
                div [ ClassName child3 ] []
            ]


    let formStyle =
        fss
            [
                BorderStyle Solid
                BorderWidth (px 1)
                BorderColor orangered
                CSSProperty.Margin (px 20)
            ]

    fragment []
        [
            p [] [ str "I am aligend with flexbox" ]
            alignment
            p [] [ str "We are evenly distributed! Just try resizing" ]
            flow
            p [] [ str "Flex direction is row!" ]
            rows
            p [] [ str "Flex direction is columns!" ]
            columns
            p [] [ str "Flex wrap is no wrap!" ]
            noWrap
            p [] [ str "Flex wrap is wrap!" ]
            wrap
            p [] [ str "Flex wrap is wrapreverse!" ]
            wrapReverse
            p [] [ str "Flex flow" ]
            div [ ClassName (fss [ Display Display.Flex ]) ]
                [
                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Flex direction" ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection Row)) ]
                                    str "row" 
                                ]

                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection RowReverse)) ]
                                    str "row-reverse" 
                                ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection Column)) ]
                                    str "column" 
                                ]

                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection ColumnReverse)) ]
                                    str "column-reverse" 
                                ]
                        ]
                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Flex wrap" ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap NoWrap)) ]
                                    str "nowrap" 
                                ]

                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap Wrap)) ]
                                    str "wrap" 
                                ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap WrapReverse)) ]
                                    str "wrap-reverse" 
                                ]
                        ]
                ]
            flexFlow
            p [] [ str "Align content" ]
            form [ ClassName formStyle ]
                [
                    h3 [] [str "Align content" ]
                    div [] 
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexStart)) ]
                            str "FlexStart" 
                        ]

                    div [] 
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexEnd)) ]
                            str "FlexEnd" 
                        ]
                    div [] 
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent AlignContent.Center)) ]
                            str "Center" 
                        ]
                    div [] 
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent Stretch)) ]
                            str "Stretch(default)" 
                        ]
                    div [] 
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent SpaceBetween)) ]
                            str "SpaceBetween" 
                        ]
                    div [] 
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent SpaceAround)) ]
                            str "SpaceAround" 
                        ]
                ]
            alignContent
            p [] [str "Flex basis & grow" ]
            flexBasisGrow
            p [] [str "Flex basis & shrink" ]
            flexBasisShrink
        ]

let BackgroundExamples model dispatch =
    fragment []
        [
            h3 [] [ str "And gradients!" ]
    
            div [ ClassName (fss [Display Flex]) ]
                [
                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (LinearGradient [ red; blue ] )
                            ])
                    ] []
                    
                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (LinearGradient [Right; red; blue ] )
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (RadialGradient [ red; blue ] )
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (RepeatingRadialGradient [ red; red; px 10; blue; px 10; blue; px 20 ] )
                            ])
                    ] []
                ]

            div [ ClassName (fss [Display Flex]) ]
                [

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (RepeatingRadialGradient [ hex "#e66465"; hex "9198e5"; pct 20 ] )
                            ])
                    ] []

                    div [
                           ClassName (fss
                               [
                                   Width (px 200)
                                   Height (px 200)
                                   BackgroundImage (LinearGradient [Bottom; red; hex "f06d06" ] )
                               ])
                       ] [ ]

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (LinearGradient [deg 72.0; red; hex "f06d06" ] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (LinearGradient [Right; red; hex "f06d06"; rgb 255 255 0; green ] )
                                ])
                        ] []
                ]

            div [ ClassName (fss [Display Flex]) ]
                [

                    div [
                        ClassName (fss
                            [
                                Width (px 200)
                                Height (px 200)
                                BackgroundImage (LinearGradient [ Right; red; yellow; pct 10 ] )
                            ])
                    ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (LinearGradient [Right; hex "fffdc2"; hex "fffdc2"; pct 15; hex "d7f0a2"; pct 15; hex "d7f0a2"; pct 85; hex "fffdc2"; pct 85 ] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (RadialGradient [ CircleAt [Top; Right]; yellow; hex "f06d06"] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width (px 200)
                                    Height (px 200)
                                    BackgroundImage (RadialGradient [ CircleAt [pct 100]; hex "333"; hex "333"; pct 50; hex "eee"; pct 75; hex "333"; pct 75] )
                                ])
                        ] []
                ]

            h3 [] [ str "And images!" ]
            div [
                ClassName (fss
                    [
                        Width (px 200)
                        Height (px 200)
                        BackgroundImage (Url "https://unsplash.it/200/200")
                    ])
            ] []

            let frameAnimation =
                keyframes
                    [
                        frame 0   [ BackgroundPositions [px 0; px 0] ]
                        frame 100 [ BackgroundPositions [px -500; px 0]]
                    ]

            let frame =
                fss
                    [
                        Width (px 50)
                        Height (px 72)
                        BackgroundImage (Url "https://s.cdpn.io/79/sprite-steps.png")
                        Animation [ frameAnimation; sec 1.0; Step(10); Infinite ]
                    ]

            h3 [] [ str "Background images can be... fun?" ]
            div [ ClassName frame ] []

            let formStyle =
                fss
                    [
                        BorderStyle Solid
                        BorderWidth (px 1)
                        BorderColor orangered
                        CSSProperty.Margin (px 20)
                    ]

            div [ ClassName (fss [ Display Flex])]
                [

                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Background repeat" ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat RepeatX)) ]
                                    str "Repeat-X" 
                                ]

                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat RepeatY)) ]
                                    str "Repeat-Y" 
                                ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Repeat)) ]
                                    str "Repeat" 
                                ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Space)) ]
                                    str "Space" 
                                ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat Round)) ]
                                    str "Round" 
                                ]
                            div [] 
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat NoRepeat)) ]
                                    str "NoRepeat" 
                                ]
                        ]
                    ]
            div [ ClassName (fss 
                    [
                        Width (px 1025)
                        Height (px 1025)
                        BackgroundImage <| Url "https://interactive-examples.mdn.mozilla.net/media/examples/moon.jpg"
                        BackgroundRepeat model.BackgroundRepeat
                    ])] []

                ]

let MediaQueryExamples =
   let style =
        fss
            [
                Width (px 200)
                Height (px 200)
                BackgroundColor blue
                Media 
                    [ MediaFeature.MaxWidth (px 500); MediaFeature.MinWidth (px 200) ]
                    [ BackgroundColor Color.red ]
                Media
                    [ MediaFeature.MinHeight (px 700)]
                    [ BackgroundColor pink]
                MediaFor Print
                    []
                    [ 
                        Transform (Rotate(deg 45.0))
                        BackgroundColor black
                    ]
                Media
                    [ Orientation Landscape]
                    [ Color green; FontSize (px 28)]
                
            ]
   div [ ClassName style] [ str "foosball"]
*)

let SelectorExamples =
    fragment []
        [
            h2 [] [ str "Selectors" ]
            let descendant =
                fss
                    [
                        ! P
                            [
                                BackgroundColor red
                            ]
                    ]
            h3 [] [ str "Descendant" ] 
            div [ ClassName descendant] [
                p [] [ str "Apple"]
                div [] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let child =
                fss
                    [
                        !> P
                            [
                                BackgroundColor green
                            ]
                    ]
            h3 [] [ str "Child" ] 
            div [ ClassName child] [
                p [] [ str "Apple"]
                div [] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]
           
            let adjacentSibling =
                fss
                    [
                        !+ P  
                            [
                                BackgroundColor yellow
                            ]
                    ]
            h3 [] [ str "Adjacent Sibling" ]
            div [] [
                p [] [ str "Apple"]
                div [ ClassName adjacentSibling ] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]
            let generalSibling =
                fss
                    [
                        !~ P
                            [
                                BackgroundColor orangered
                            ]
                    ]
            h3 [] [ str "General Sibling" ] 
            div [] [
                p [] [ str "Apple"]
                div [ ClassName generalSibling ] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let composed =
                fss
                    [
                        ! Div
                            [
                                !> Div 
                                    [
                                        !> P
                                            [
                                                !+ P
                                                    [
                                                        Color purple
                                                        FontSize (px 25)
                                                    ]
                                            ]
                                    ]
                                
                            ]
                    ]

            h3 [] [ str "Composed" ]
            div [ ClassName composed ]
                [
                    div []
                        [
                            div []
                                [
                                    p [] [ str "Hi" ]
                                    // Skal bli lilla og 25 px
                                    p [] [ str "Hi" ]
                                ]
                        ]
                ]
        ]

let render (model: Model) (dispatch: Msg -> unit) =
    div [] 
        [         
           //ColorExamples
           //FontExamples
           //BorderExamples
           //AnimationExamples
           //MarginExamples
           //PaddingExamples
           //TransformExamples
           //TransitionExamples
           //FlexBoxExamples model dispatch
           //BackgroundExamples model dispatch
           //MediaQueryExamples
           SelectorExamples           
        ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
