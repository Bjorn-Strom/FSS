module Tests

open Fable.Core
open Fable.Mocha
open Fable.React
open Fable.React.Props
open Fable.ReactTestingLibrary

open Fss
open Html
open Global
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
open BackgroundImage
open LinearGradient
open RadialGradient
open BackgroundPosition
open BackgroundRepeat
open BackgroundOrigin
open BackgroundClip
open BackgroundAttachment
open ContentSize

[<Emit("window.getComputedStyle(document.getElementById('$0'));")>]
let getComputedCssById (id : string) : obj  = jsNative

[<Emit("$0[$1];")>]
let getValue (object: obj) (key: string) : string = jsNative

let test (testName: string) (stylePropertiesAndResults: (string * (string * string) list) list) =
    testCase testName <| fun _ ->
        
        List.iter (fun (style, propertyResultList) ->         
            RTL.render(
                fragment []
                    [
                        div [ Id "id"; ClassName style] []
                    ]) |> ignore

            let computed = getComputedCssById("id")
            List.iter(fun (property, result) -> 
                Expect.equal (getValue computed property) result testName
            ) propertyResultList
            RTL.cleanup()
        ) stylePropertiesAndResults

        (*
        
                testCase' "Background" <| fun _ ->
                    let linear1 = fss [ BackgroundImage (LinearGradient [ red; blue ] ) ]
                    let linear2 = fss [ BackgroundImage (LinearGradient [ Right; red; blue ] ) ]
                    let linear3 = fss [ BackgroundImage (LinearGradient [ Bottom; red; blue ] ) ]
                    let linear4 = fss [ BackgroundImage (LinearGradient [ deg 72.0; red; blue ] ) ]
                    let radial1 = fss [ BackgroundImage (RadialGradient [ CircleAt [pct 100]; hex "333"; hex "333"; pct 50; hex "eee"; pct 75; hex "333"; pct 75] ) ]
                    let backgroundPosition = fss [ BackgroundPosition (px 10)]
                    let backgroundPositions = fss [ BackgroundPositions [px 10; Bottom]]
                    let backgroundRepeat = fss [ BackgroundRepeat RepeatX ]
                    let backgroundRepeats = fss [ BackgroundRepeats [Repeat; Space] ]
                    let backgroundOrigin = fss [ BackgroundOrigin BorderBox]
                    let backgroundClip = fss [ BackgroundClip BorderBox]
                    let backgroundAttachment = fss [ BackgroundAttachment Scroll]
        
                    RTL.render(
                        div [ ]
                            [
                                div [ Id "1"; ClassName linear1 ] [ ]
                                div [ Id "2"; ClassName linear2 ] [ ]
                                div [ Id "3"; ClassName linear3 ] [ ]
                                div [ Id "4"; ClassName linear4 ] [ ]
                                div [ Id "5"; ClassName radial1 ] [ ]
                                div [ Id "6"; ClassName backgroundPosition ] [ ]
                                div [ Id "7"; ClassName backgroundPositions ] [ ]
                                div [ Id "8"; ClassName backgroundRepeat ] [ ]
                                div [ Id "9"; ClassName backgroundRepeats ] [ ]
                                div [ Id "10"; ClassName backgroundOrigin ] [ ]
                                div [ Id "11"; ClassName backgroundClip ] [ ]
                                div [ Id "12"; ClassName backgroundAttachment ] [ ]
                            ]
                    ) |> ignore
                            
                    let one = getComputedCssById("1")
                    let two = getComputedCssById("2")
                    let three = getComputedCssById("3")
                    let four = getComputedCssById("4")
                    let five = getComputedCssById("5")
                    let six = getComputedCssById("6")
                    let seven = getComputedCssById("7")
                    let eight = getComputedCssById("8")
                    let nine = getComputedCssById("9")
                    let ten = getComputedCssById("10")
                    let eleven = getComputedCssById("11")
                    let twelve = getComputedCssById("12")
        
                    Expect.equal (getValue one "background-image") "linear-gradient(rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with two colors"
                    Expect.equal (getValue two "background-image") "linear-gradient(to right, rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with two colors with direction"
                    Expect.equal (getValue three "background-image") "linear-gradient(rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with two rgb"
                    Expect.equal (getValue four "background-image") "linear-gradient(72deg, rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with degrees"
                    Expect.equal (getValue five "background-image") "radial-gradient(circle at 100% 50%, rgb(51, 51, 51), rgb(51, 51, 51) 50%, rgb(238, 238, 238) 75%, rgb(51, 51, 51) 75%)" "Radial gradient with shape and side"
        
                    Expect.equal (getValue six "background-position") "10px 50%" "Set one background position"
                    Expect.equal (getValue seven "background-position") "10px 100%" "Set several background positions"
        
                    Expect.equal (getValue eight "background-repeat") "repeat-x" "Set one background repeat"
                    Expect.equal (getValue nine "background-repeat") "repeat space" "Set several background repeats"
        
                    Expect.equal (getValue ten "background-origin") "border-box" "Set background origin"
        
                    Expect.equal (getValue eleven "background-clip") "border-box" "Set background clip"
        
                    Expect.equal (getValue twelve "background-attachment") "scroll" "Set background attachment"
                    *)


let CssTests =
    testList "Css tests" [
        
        test "Background" 
            [ 
                (fss [ BackgroundColor red; Color blue]), ["background-color", "rgb(255, 0, 0)"]
            
                (fss [ BackgroundImage (Url "image.png") ]), ["background-image", "url(\"http://localhost:8085/image.png\")"]
                (fss [ BackgroundImage (LinearGradient [ red; blue; deg 45.0; px 10 ] ) ]), ["background-image", "linear-gradient(45deg, rgb(255, 0, 0), rgb(0, 0, 255) 10px)"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; Circle ] ) ]), ["background-image", "radial-gradient(circle, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; Ellipse ] ) ]), ["background-image", "radial-gradient(rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleSide ClosestCorner ] ) ]), ["background-image", "radial-gradient(circle closest-corner, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleSide ClosestSide ] ) ]), ["background-image", "radial-gradient(circle closest-side, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleSide FarthestCorner ] ) ]), ["background-image", "radial-gradient(circle, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleSide FarthestSide ] ) ]), ["background-image", "radial-gradient(circle farthest-side, rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseSide ClosestCorner ] ) ]), ["background-image", "radial-gradient(closest-corner, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseSide ClosestSide ] ) ]), ["background-image", "radial-gradient(closest-side, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseSide FarthestCorner ] ) ]), ["background-image", "radial-gradient(rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseSide FarthestSide ] ) ]), ["background-image", "radial-gradient(farthest-side, rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Top] ] ) ]), ["background-image", "radial-gradient(circle at 50% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Top; Right] ] ) ]), ["background-image", "radial-gradient(circle at 100% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Top; Left] ] ) ]), ["background-image", "radial-gradient(circle at 0% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Top; Center] ] ) ]), ["background-image", "radial-gradient(circle at 50% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Bottom] ] ) ]), ["background-image", "radial-gradient(circle at 50% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Bottom; Right] ] ) ]), ["background-image", "radial-gradient(circle at 100% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Bottom; Left] ] ) ]), ["background-image", "radial-gradient(circle at 0% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Bottom; Center] ] ) ]), ["background-image", "radial-gradient(circle at 50% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Center] ] ) ]), ["background-image", "radial-gradient(circle, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Center; Right] ] ) ]), ["background-image", "radial-gradient(circle at 100% 50%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Center; Left] ] ) ]), ["background-image", "radial-gradient(circle at 0% 50%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; CircleAt [Center; Bottom] ] ) ]), ["background-image", "radial-gradient(circle at 50% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Top] ] ) ]), ["background-image", "radial-gradient(at 50% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Top; Right] ] ) ]), ["background-image", "radial-gradient(at 100% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Top; Left] ] ) ]), ["background-image", "radial-gradient(at 0% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Top; Center] ] ) ]), ["background-image", "radial-gradient(at 50% 0%, rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Bottom] ] ) ]), ["background-image", "radial-gradient(at 50% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Bottom; Right] ] ) ]), ["background-image", "radial-gradient(at 100% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Bottom; Left] ] ) ]), ["background-image", "radial-gradient(at 0% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Bottom; Center] ] ) ]), ["background-image", "radial-gradient(at 50% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]

                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Center] ] ) ]), ["background-image", "radial-gradient(rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Center; Right] ] ) ]), ["background-image", "radial-gradient(at 100% 50%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Center; Left] ] ) ]), ["background-image", "radial-gradient(at 0% 50%, rgb(255, 255, 0), rgb(240, 109, 6))"]
                (fss [ BackgroundImage (RadialGradient [ yellow; hex "f06d06"; EllipseAt [Center; Bottom] ] ) ]), ["background-image", "radial-gradient(at 50% 100%, rgb(255, 255, 0), rgb(240, 109, 6))"]

            ]

        test "Color" 
            [ 
                (fss [ Color aliceblue ] ), ["color", "rgb(240, 248, 255)"]
                (fss [ Color (rgb 255 0 0) ]), ["color", "rgb(255, 0, 0)"]
                (fss [ Color (rgba 255 0 0  0.5) ]), ["color", "rgba(255, 0, 0, 0.5)"]
                (fss [ Color (hex "ff0000") ]), ["color", "rgb(255, 0, 0)"]
                (fss [ Color (hex "#ff0000") ]), ["color", "rgb(255, 0, 0)"]
                (fss [ Color (hex "ff000080") ]), ["color", "rgba(255, 0, 0, 0.5)"]
                (fss [ Color (hsl 120 1.0 0.5) ]), ["color", "rgb(0, 255, 0)"]
                (fss [ Color (hsla 120 1.0 0.5 0.5) ]), ["color", "rgba(0, 255, 0, 0.5)"]
            ]
                
        test "Font" 
            [
                (fss [ FontSize XSmall ]), ["font-size", "10px"]
                (fss [ FontSize Large ]), ["font-size", "18px"]
                (fss [ FontSize (px 100) ]), ["font-size", "100px"]
                (fss [ FontSize (px 100) ]), ["font-size", "100px"]
                (fss [ FontSize (pct 200) ]), ["font-size", "32px"]

            ]

        test "Border" 
            [
                (fss [ BorderStyle Hidden ]), 
                    [
                        "border-bottom-style", "hidden"
                        "border-left-style", "hidden"
                        "border-right-style", "hidden"
                        "border-top-style", "hidden"
                    ]

                (fss [ BorderStyle Dotted ]),
                    [
                        "border-bottom-style", "dotted"
                        "border-left-style", "dotted"
                        "border-right-style", "dotted"
                        "border-top-style", "dotted"
                    ]

                (fss [ BorderStyle Dashed ]), 
                    [ 
                        "border-bottom-style", "dashed"
                        "border-left-style", "dashed"
                        "border-right-style", "dashed"
                        "border-top-style", "dashed"
                    ]

                (fss [ BorderStyle Solid ]), 
                    [
                        "border-bottom-style", "solid"
                        "border-left-style", "solid"
                        "border-right-style", "solid"
                        "border-top-style", "solid"
                    ]

                (fss [ BorderStyle Double ]),
                    [
                        "border-bottom-style", "double"
                        "border-left-style", "double"
                        "border-right-style", "double"
                        "border-top-style", "double"
                    ]

                (fss [ BorderStyle Groove ]), 
                    [
                        "border-bottom-style", "groove"
                        "border-left-style", "groove"
                        "border-right-style", "groove"
                        "border-top-style", "groove"
                    ]

                (fss [ BorderStyle Ridge ]), 
                    [
                        "border-bottom-style", "ridge"
                        "border-left-style", "ridge"
                        "border-right-style", "ridge"
                        "border-top-style", "ridge"
                    ]

                (fss [ BorderStyle Inset ]), 
                    [
                        "border-bottom-style", "inset"
                        "border-left-style", "inset"
                        "border-right-style", "inset"
                        "border-top-style", "inset"
                    ]

                (fss [ BorderStyle Outset ]),
                    [
                        "border-bottom-style", "outset"
                        "border-left-style", "outset"
                        "border-right-style", "outset"
                        "border-top-style", "outset"
                    ]

                (fss [ BorderStyles [Inset; Outset; Ridge; Groove] ]), 
                    [
                        "border-bottom-style", "ridge"
                        "border-left-style", "groove"
                        "border-right-style", "outset"
                        "border-top-style", "inset"
                    ]

                (fss [ BorderStyle BorderStyle.None ]), 
                    [
                        "border-bottom-style", "none"
                        "border-left-style", "none"
                        "border-right-style", "none"
                        "border-top-style", "none"
                    ]

                (fss [ BorderRadius (px 10)]), 
                     [
                         "border-top-left-radius", "10px"
                         "border-top-right-radius", "10px"
                         "border-bottom-left-radius", "10px"
                         "border-bottom-right-radius", "10px"
                     ]

                (fss [ BorderTopLeftRadius (px 10)]), ["border-top-left-radius", "10px"]
                (fss [ BorderTopRightRadius (px 10)]), ["border-top-right-radius", "10px"]
                (fss [ BorderBottomLeftRadius (px 10)]), ["border-bottom-left-radius", "10px"]
                (fss [ BorderBottomRightRadius (px 10)]), ["border-bottom-right-radius", "10px"]

                (fss [ BorderRadiuses [px 10; px 20; px 30; px 40] ]), 
                    [
                        "border-bottom-left-radius", "40px"
                        "border-bottom-right-radius", "30px"
                        "border-top-left-radius", "10px"
                        "border-top-right-radius", "20px"
                    ]

                (fss [ BorderStyle Solid; BorderWidth (px 40) ]), 
                    [
                        "border-top-width", "40px"
                        "border-right-width", "40px"
                        "border-bottom-width", "40px"
                        "border-left-width", "40px"
                    ]

                (fss [ BorderStyle Solid; BorderWidths [px 10; px 20; px 30; px 40 ]]), 
                    [
                        "border-top-width", "10px"
                        "border-right-width", "20px"
                        "border-bottom-width", "30px"
                        "border-left-width", "40px"
                    ]

                (fss [ BorderStyle Solid; BorderTopWidth Thin ]), ["border-top-width", "1px"]
                (fss [ BorderStyle Solid; BorderRightWidth Thick ]), ["border-right-width", "5px"]
                (fss [ BorderStyle Solid; BorderBottomWidth Medium ]), ["border-bottom-width", "3px"]
                (fss [ BorderStyle Solid; BorderLeftWidth (px 40) ]), ["border-left-width", "40px"]

                (fss [ BorderStyle Solid; BorderColor red ]),
                    [
                        "border-top-color", "rgb(255, 0, 0)"
                        "border-right-color", "rgb(255, 0, 0)"
                        "border-bottom-color", "rgb(255, 0, 0)"
                        "border-left-color", "rgb(255, 0, 0)"
                    ]

                (fss [ BorderStyle Solid; BorderColors [red; green; blue; white] ]), 
                    [
                        "border-top-color", "rgb(255, 0, 0)"
                        "border-right-color", "rgb(0, 128, 0)"
                        "border-bottom-color", "rgb(0, 0, 255)"
                        "border-left-color", "rgb(255, 255, 255)"
                    ]

                (fss [ BorderStyle Solid; BorderTopColor red ]), ["border-top-color", "rgb(255, 0, 0)"]
                (fss [ BorderStyle Solid; BorderRightColor green ]), ["border-right-color", "rgb(0, 128, 0)"]
                (fss [ BorderStyle Solid; BorderBottomColor blue ]), ["border-bottom-color", "rgb(0, 0, 255)"]
                (fss [ BorderStyle Solid; BorderLeftColor white ]), ["border-left-color", "rgb(255, 255, 255)"]
            ]

        test "Width" 
            [
                (fss [ Width (px 100) ]), ["width", "100px"]
                (fss [ Width MaxContent ]), ["width", "0px"]
                (fss [ Width MinContent ]), ["width", "0px"]
                (fss [ Width (FitContent(px 100)) ]), ["width", "1063px"]
                (fss [ MinWidth (px 50) ]), ["min-width", "50px"]
                (fss [ MaxWidth (px 75) ]), ["max-width", "75px"]

                (fss [ Height (px 100) ]), ["height", "100px"]
                (fss [ Height MaxContent ]), ["height", "0px"]
                (fss [ Height MinContent ]), ["height", "0px"]
                (fss [ MinHeight (px 50) ]), ["min-height", "50px"]
                (fss [ MaxHeight (px 75) ]), ["max-height", "75px"]
            ]

        test "Perspective" 
            [
                (fss [ CSSProperty.Perspective (px 100) ]), ["perspective", "100px"]
                //(fss [ CSSProperty.Perspective Inherit]), "perspective", "inherit"
                //(fss [ CSSProperty.Perspective Initial]), "perspective", "initial"
                //(fss [ CSSProperty.Perspective Unset]), "perspective", "unset"
            ]

        test "Flexbox"
            [
                (fss [ Display Flex]), ["display", "flex"]

                (fss [ FlexDirection Row]), ["flex-direction", "row"]
                (fss [ FlexDirection Column]), ["flex-direction", "column"]

                (fss [ FlexWrap NoWrap]), ["flex-wrap", "nowrap"]
                (fss [ FlexWrap Wrap]), ["flex-wrap", "wrap"]
                (fss [ FlexWrap WrapReverse]), ["flex-wrap", "wrap-reverse"]

                (fss [ CSSProperty.FlexBasis (px 120)]), ["flex-basis", "120px"]

                (fss [ JustifyContent JustifyContent.FlexStart]), ["justify-content", "flex-start"]
                (fss [ JustifyContent JustifyContent.FlexEnd]), ["justify-content", "flex-end"]
                (fss [ JustifyContent JustifyContent.Center]), ["justify-content", "center"]
                (fss [ JustifyContent JustifyContent.SpaceBetween]), ["justify-content", "space-between"]
                (fss [ JustifyContent JustifyContent.SpaceAround]), ["justify-content", "space-around"]
                (fss [ JustifyContent JustifyContent.SpaceEvenly]), ["justify-content", "space-evenly"]

                (fss [ AlignSelf AlignSelf.Auto]), ["align-self", "auto"]
                (fss [ AlignSelf AlignSelf.FlexStart]), ["align-self", "flex-start"]
                (fss [ AlignSelf AlignSelf.FlexEnd]), ["align-self", "flex-end"]
                (fss [ AlignSelf AlignSelf.Center]), ["align-self", "center"]
                (fss [ AlignSelf AlignSelf.Baseline]), ["align-self", "baseline"]
                (fss [ AlignSelf AlignSelf.Stretch]), ["align-self", "stretch"]

                (fss [ AlignItems AlignItems.FlexStart]), ["align-items", "flex-start"]
                (fss [ AlignItems AlignItems.FlexEnd]), ["align-items", "flex-end"]
                (fss [ AlignItems AlignItems.Center]), ["align-items", "center"]
                (fss [ AlignItems AlignItems.Baseline]), ["align-items", "baseline"]
                (fss [ AlignItems AlignItems.Stretch]), ["align-items", "stretch"]
                
                (fss [ AlignContent FlexStart]), ["align-content", "flex-start"]
                (fss [ AlignContent FlexEnd]), ["align-content", "flex-end"]
                (fss [ AlignContent AlignContent.Center]), ["align-content", "center"]
                (fss [ AlignContent SpaceBetween]), ["align-content", "space-between"]
                (fss [ AlignContent SpaceAround]), ["align-content", "space-around"]
                (fss [ AlignContent Stretch]), ["align-content", "stretch"]

                (fss [ CSSProperty.Order (Order 1) ]), ["order", "1"]

                (fss [ FlexGrow (Grow 1) ]), ["flex-grow", "1"]

                (fss [ FlexShrink (Shrink 1) ]), ["flex-shrink", "1"]

            ]

        test "Margin"
            [
                (fss [ MarginTop (px 10)]), ["margin-top", "10px"]
                (fss [ MarginRight (px 10)]), ["margin-right", "10px"]
                (fss [ MarginBottom (px 10)]), ["margin-bottom", "10px"]
                (fss [ MarginLeft (px 10)]), ["margin-left", "10px"]

                (fss [ CSSProperty.Margin (px 10)]), 
                    [
                        "margin-top", "10px"
                        "margin-right", "10px"
                        "margin-bottom", "10px"
                        "margin-left", "10px"
                    ]

                (fss [ CSSProperty.Margins [ px 10; px 20; px 30; px 40 ] ]), 
                    [
                        "margin-top", "10px"
                        "margin-right", "20px"
                        "margin-bottom", "30px"
                        "margin-left", "40px"
                    ]
            ]

        test "Padding"
            [
                (fss [ PaddingTop (px 10)]), ["padding-top", "10px"]
                (fss [ PaddingRight (px 10)]), ["padding-right", "10px"]
                (fss [ PaddingBottom (px 10)]), ["padding-bottom", "10px"]
                (fss [ PaddingLeft (px 10)]), ["padding-left", "10px"]

                (fss [ Padding (px 10)]), 
                    [
                        "padding-top", "10px"
                        "padding-right", "10px"
                        "padding-bottom", "10px"
                        "padding-left", "10px"
                    ]

                (fss [ Paddings [ px 10; px 20; px 30; px 40 ] ]), 
                    [
                        "padding-top", "10px"
                        "padding-right", "20px"
                        "padding-bottom", "30px"
                        "padding-left", "40px"
                    ]
            ]

        test "Animation"
            [
                let animationSample = keyframes [ frame 0 [ BackgroundColor red]; frame 100 [ BackgroundColor blue] ]

                (fss [ AnimationName animationSample ]), ["animation-name", animationSample |> string]

                (fss [ AnimationDuration (sec 10.0) ]), ["animation-duration", "10s"]

                (fss [ AnimationTimingFunction Ease ]), ["animation-timing-function", "ease"]
                (fss [ AnimationTimingFunction EaseIn ]), ["animation-timing-function", "ease-in"]
                (fss [ AnimationTimingFunction EaseOut ]), ["animation-timing-function", "ease-out"]
                (fss [ AnimationTimingFunction EaseInOut ]), ["animation-timing-function", "ease-in-out"]
                (fss [ AnimationTimingFunction Linear ]), ["animation-timing-function", "linear"]
                (fss [ AnimationTimingFunction StepStart ]), ["animation-timing-function", "steps(1, start)"]
                (fss [ AnimationTimingFunction StepEnd ]), ["animation-timing-function", "steps(1)"]
                (fss [ AnimationTimingFunction <| CubicBezier(0.0, 0.47, 0.32, 1.97) ]), ["animation-timing-function", "cubic-bezier(0, 0.5, 0.3, 2)"]
                (fss [ AnimationTimingFunction (Step 5) ]), ["animation-timing-function", "steps(5)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpStart) ]), ["animation-timing-function", "steps(5, jump-start)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpEnd) ]), ["animation-timing-function", "steps(5)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpNone) ]), ["animation-timing-function", "steps(5, jump-none)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpBoth) ]), ["animation-timing-function", "steps(5, jump-both)"]
                (fss [ AnimationTimingFunction <| Steps(5, Start) ]), ["animation-timing-function", "steps(5, start)"]
                (fss [ AnimationTimingFunction <| Steps(5, End) ]), ["animation-timing-function", "steps(5)"]

                (fss [ AnimationDelay (sec 10.0) ]), ["animation-delay", "10s"]
                (fss [ AnimationDelays [sec 10.0; mSec 500.0] ]), ["animation-delay", "10s, 0.5s"]

                (fss [ AnimationIterationCount Infinite ]), ["animation-iteration-count", "infinite"]
                (fss [ AnimationIterationCount (Value 5) ]), ["animation-iteration-count", "5"]
                (fss [ AnimationIterationCounts [Infinite; Value 5] ]), ["animation-iteration-count", "infinite, 5"]

                (fss [ AnimationDirection Normal ]), ["animation-direction", "normal"]
                (fss [ AnimationDirection Reverse ]), ["animation-direction", "reverse"]
                (fss [ AnimationDirection Alternate ]), ["animation-direction", "alternate"]
                (fss [ AnimationDirection AlternateReverse ]), ["animation-direction", "alternate-reverse"]

                (fss [ AnimationFillMode Forwards ]), ["animation-fill-mode", "forwards"]
                (fss [ AnimationFillMode Backwards ]), ["animation-fill-mode", "backwards"]
                (fss [ AnimationFillMode Both ]), ["animation-fill-mode", "both"]
                (fss [ AnimationFillMode FillMode.None ]), ["animation-fill-mode", "none"]

                (fss [ AnimationPlayState Running ]), ["animation-play-state", "running"]
                (fss [ AnimationPlayState Paused ]), ["animation-play-state", "paused"]
                (fss [ AnimationPlayStates [ Running; Paused] ]), ["animation-play-state", "running, paused"]

                (fss [ 
                    Animations 
                        [
                            [animationSample; sec 10.0; Ease; mSec 0.5; Infinite; Both; Alternate; Running]
                            [animationSample; sec 1.0; Linear; sec 10.0; IterationCount.Value 3; Both; Reverse; Paused] 
                        ]
                ]), 
                    [
                        "animation-name", (sprintf "%A, %A" animationSample animationSample)
                        "animation-duration", "10s, 1s"
                        "animation-timing-function", "ease, linear"
                        "animation-delay", "0.0005s, 10s"
                        "animation-delay", "0.0005s, 10s"
                        "animation-iteration-count", "infinite, 3"
                        "animation-fill-mode", "both, both"
                        "animation-direction", "alternate, reverse"
                        "animation-play-state", "running, paused"
                    ]

            ]

        test "Transform" 
            [
                (fss [Transform (Matrix(0.1, 0.2, 0.3,0.4, 0.5, 0.6)) ]), ["transform", "matrix(0.1, 0.2, 0.3, 0.4, 0.5, 0.6)"]

                (fss [Transform (
                        Matrix3D(1, 0, 0, 0,
                                 0, 1, 0, 0,
                                 0, 0, 1, 0,
                                 -50.0, -100.0, 0.0, 1.1)
                    ) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, -50, -100, 0, 1.1)"]

                (fss [Transform (Perspective(px 300)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, -0.00333333, 0, 0, 0, 1)"]

                (fss [Transform (Rotate(deg 45.0)) ]), ["transform", "matrix(0.707107, 0.707107, -0.707107, 0.707107, 0, 0)"]
                (fss [Transform (Rotate3D(0.5, 1.5, 2.5, deg 45.0)) ]), ["transform", "matrix3d(0.715475, 0.622719, -0.316727, 0, -0.572509, 0.782422, 0.245049, 0, 0.40041, 0.0060028, 0.916316, 0, 0, 0, 0, 1)"]
                (fss [Transform (RotateX(deg 45.0)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 0.707107, 0.707107, 0, 0, -0.707107, 0.707107, 0, 0, 0, 0, 1)"]
                (fss [Transform (RotateY(deg 45.0)) ]), ["transform", "matrix3d(0.707107, 0, -0.707107, 0, 0, 1, 0, 0, 0.707107, 0, 0.707107, 0, 0, 0, 0, 1)"]
                (fss [Transform (RotateZ(deg 45.0)) ]), ["transform", "matrix(0.707107, 0.707107, -0.707107, 0.707107, 0, 0)"]

                (fss [Transform (Translate(px 45)) ]), ["transform", "matrix(1, 0, 0, 1, 45, 0)"]
                (fss [Transform (Translate2(px 50, px 50)) ]), ["transform", "matrix(1, 0, 0, 1, 50, 50)"]
                (fss [Transform (Translate3D(px 50, px 50, px 50)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 50, 50, 50, 1)"]
                (fss [Transform (TranslateX(px 10)) ]), ["transform", "matrix(1, 0, 0, 1, 10, 0)"]
                (fss [Transform (TranslateY(px 20)) ]), ["transform", "matrix(1, 0, 0, 1, 0, 20)"]
                (fss [Transform (TranslateZ(px 20)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 20, 1)"]

                (fss [Transform (Scale 2.5) ]), ["transform", "matrix(2.5, 0, 0, 2.5, 0, 0)"]
                (fss [Transform (Scale2(2.5, 2.5)) ]), ["transform", "matrix(2.5, 0, 0, 2.5, 0, 0)"]
                (fss [Transform (Scale3D(2.5, 2.5, 2.5)) ]), ["transform", "matrix3d(2.5, 0, 0, 0, 0, 2.5, 0, 0, 0, 0, 2.5, 0, 0, 0, 0, 1)"]
                (fss [Transform (ScaleX(3.5)) ]), ["transform", "matrix(3.5, 0, 0, 1, 0, 0)"]
                (fss [Transform (ScaleY(4.5)) ]), ["transform", "matrix(1, 0, 0, 4.5, 0, 0)"]
                (fss [Transform (ScaleZ(5.5)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 5.5, 0, 0, 0, 0, 1)"]

                (fss [Transform (Skew (deg 45.0)) ]), ["transform", "matrix(1, 0, 1, 1, 0, 0)"]
                (fss [Transform (Skew2 (deg 45.0, deg 20.0)) ]), ["transform", "matrix(1, 0.36397, 1, 1, 0, 0)"]
                (fss [Transform (SkewX (deg 22.5)) ]), ["transform", "matrix(1, 0, 0.414214, 1, 0, 0)"]
                (fss [Transform (SkewY (deg 3.5)) ]), ["transform", "matrix(1, 0.0611626, 0, 1, 0, 0)"]
            ]

        test "Transition"
            [
                (fss [ Transition (Transition1(backgroundColor, (sec 10.0))) ]), 
                    [
                        "transition-property", "background-color"
                        "transition-duration", "10s"
                    ]

                (fss [ Transition (Transition2(backgroundColor, (sec 10.0), Ease)) ]), 
                    [
                        "transition-property", "background-color"
                        "transition-duration", "10s"
                        "transition-timing-function", "ease"
                    ]

                (fss [ Transition (Transition3(backgroundColor, (sec 10.0), Ease, sec 2.0)) ]), 
                    [
                        "transition-property", "background-color"
                        "transition-duration", "10s"
                        "transition-timing-function", "ease"
                        "transition-delay", "2s"
                    ]

                (fss
                    [
                        Transitions 
                            [
                                Transition1(backgroundColor, (sec 10.0))
                                Transition2(color, (sec 20.0), EaseInOut)
                                Transition3(width, (sec 30.0), EaseOut, (sec 20.0))
                            ]
                    ]),
                    [
                        "transition-property", "background-color, color, width"
                        "transition-duration", "10s, 20s, 30s"
                        "transition-timing-function", "ease, ease-in-out, ease-out"
                        "transition-delay", "0s, 0s, 20s"
                    ]

                (fss [ TransitionDelay (sec 5.0)]), ["transition-delay", "5s"]

                (fss [ TransitionDuration (sec 5.0)]), ["transition-duration", "5s"]

                (fss [ TransitionProperty Property.Width]), ["transition-property", "width"]

                (fss [ TransitionTimingFunction EaseInOut]), ["transition-timing-function", "ease-in-out"]
            ]
    ]

Mocha.runTests CssTests |> ignore





