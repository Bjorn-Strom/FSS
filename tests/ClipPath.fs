namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module ClipPath =
     let tests =
        testList "ClipPath"
            [
                test
                    "Clip path MarginBox"
                    [ClipPath.MarginBox]
                    ["clipPath" ==> "margin-box"]
                test
                    "Clip path BorderBox"
                    [ClipPath.BorderBox]
                    ["clipPath" ==> "border-box"]
                test
                    "Clip path PaddingBox"
                    [ClipPath.PaddingBox]
                    ["clipPath" ==> "padding-box"]
                test
                    "Clip path ContentBox"
                    [ClipPath.ContentBox]
                    ["clipPath" ==> "content-box"]
                test
                    "Clip path FillBox"
                    [ClipPath.FillBox]
                    ["clipPath" ==> "fill-box"]
                test
                    "Clip path StrokeBox"
                    [ClipPath.StrokeBox]
                    ["clipPath" ==> "stroke-box"]
                test
                    "Clip path ViewBox"
                    [ClipPath.ViewBox]
                    ["clipPath" ==> "view-box"]
                test
                    "Clip path url"
                    [ClipPath.Url "resources.svg#c1"]
                    ["clipPath" ==> "url(resources.svg#c1)"]
                test
                    "Clip path path"
                    [ClipPath.Path "M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z"]
                    ["clipPath" ==> "path('M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z')"]
                test
                    "ClipPath all sides pct"
                    [ ClipPath.Inset(pct 40)]
                    [ "clipPath" ==> "inset(40%)" ]
                test
                    "ClipPath all sides px"
                    [ ClipPath.Inset(px 40)]
                    [ "clipPath" ==> "inset(40px)" ]
                test
                    "ClipPath horizontal-vertical"
                    [ ClipPath.Inset(pct 40, px 50)]
                    [ "clipPath" ==> "inset(40% 50px)" ]
                test
                    "ClipPath top-horizontal-bottom"
                    [ ClipPath.Inset(pct 40, px 50, vh 3.)]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh)" ]
                test
                    "ClipPath top-right-bottom-left"
                    [ ClipPath.Inset(pct 40, px 50, vh 3., rem 2.)]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh 2.0rem)" ]
                test
                    "ClipPath all sides pct with round"
                    [ ClipPath.Inset(pct 40, [ pct 50 :> Types.ILengthPercentage ])]
                    [ "clipPath" ==> "inset(40% round 50%)" ]
                test
                    "ClipPath all sides px"
                    [ ClipPath.Inset(px 40, [ px 50 :> Types.ILengthPercentage  ])]
                    [ "clipPath" ==> "inset(40px round 50px)" ]
                test
                    "ClipPath horizontal-vertical"
                    [ ClipPath.Inset(pct 40, px 50, [ px 50 :> Types.ILengthPercentage  ])]
                    [ "clipPath" ==> "inset(40% 50px round 50px)" ]
                test
                    "ClipPath top-horizontal-bottom"
                    [ ClipPath.Inset(pct 40, px 50, vh 3., [ px 50 :> Types.ILengthPercentage  ])]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh round 50px)" ]
                test
                    "ClipPath top-right-bottom-left"
                    [ ClipPath.Inset(pct 40, px 50, vh 3., rem 2., [ px 50 :> Types.ILengthPercentage ; pct 50 :> Types.ILengthPercentage  ])]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh 2.0rem round 50px 50%)" ]
                test
                    "ClipPath circle pct"
                    [ ClipPath.Circle(pct 50)]
                    [ "clipPath" ==> "circle(50%)" ]
                test
                    "ClipPath circle px"
                    [ ClipPath.Circle(px 25)]
                    [ "clipPath" ==> "circle(25px)" ]
                test
                    "ClipPath circle at pct"
                    [ ClipPath.CircleAt(pct 50, pct 25, pct 25)]
                    [ "clipPath" ==> "circle(50% at 25% 25%)" ]
                test
                    "ClipPath circle at px"
                    [ ClipPath.CircleAt(px 25, px 10, px 10)]
                    [ "clipPath" ==> "circle(25px at 10px 10px)" ]
                test
                    "ClipPath ellipse pct"
                    [ ClipPath.Ellipse(pct 50)]
                    [ "clipPath" ==> "ellipse(50%)" ]
                test
                    "ClipPath ellipse px"
                    [ ClipPath.Ellipse(px 25)]
                    [ "clipPath" ==> "ellipse(25px)" ]
                test
                    "ClipPath ellipse at pct"
                    [ ClipPath.EllipseAt(pct 50, pct 25, pct 25)]
                    [ "clipPath" ==> "ellipse(50% at 25% 25%)" ]
                test
                    "ClipPath ellipse at px"
                    [ ClipPath.EllipseAt(px 25, px 10, px 10)]
                    [ "clipPath" ==> "ellipse(25px at 10px 10px)" ]
                test
                    "ClipPath Polygon"
                    [ ClipPath.Polygon
                                [
                                    pct 43, pct 0
                                    pct 62, pct 0
                                    pct 52, pct 26
                                    pct 69, pct 20
                                    pct 32, pct 100
                                    pct 42, pct 40
                                    pct 26, pct 46
                                ]]
                    [ "clipPath" ==> "polygon(43% 0%, 62% 0%, 52% 26%, 69% 20%, 32% 100%, 42% 40%, 26% 46%)" ]

                test
                    "ClipPath none"
                    [ ClipPath.None]
                    [ "clipPath" ==> "none" ]
                test
                    "ClipPath inherit"
                    [ ClipPath.Inherit]
                    [ "clipPath" ==> "inherit" ]
                test
                    "ClipPath initial"
                    [ ClipPath.Initial]
                    [ "clipPath" ==> "initial" ]
                test
                    "ClipPath unset"
                    [ ClipPath.Unset ]
                    [ "clipPath" ==> "unset" ]
            ]

