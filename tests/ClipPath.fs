namespace FSSTests

open Fet
open Fss.Types
open Utils
open Fss

module ClipPathTests =
     let tests =
        testList "ClipPath"
            [
                testCase
                    "Clip path MarginBox"
                    [ClipPath.marginBox]
                    "{ clip-path: margin-box; }"
                testCase
                    "Clip path BorderBox"
                    [ClipPath.borderBox]
                    "{ clip-path: border-box; }"
                testCase
                    "Clip path PaddingBox"
                    [ClipPath.paddingBox]
                    "{ clip-path: padding-box; }"
                testCase
                    "Clip path ContentBox"
                    [ClipPath.contentBox]
                    "{ clip-path: content-box; }"
                testCase
                    "Clip path FillBox"
                    [ClipPath.fillBox]
                    "{ clip-path: fill-box; }"
                testCase
                    "Clip path StrokeBox"
                    [ClipPath.strokeBox]
                    "{ clip-path: stroke-box; }"
                testCase
                    "Clip path ViewBox"
                    [ClipPath.viewBox]
                    "{ clip-path: view-box; }"
                testCase
                    "Clip path url"
                    [ClipPath.url "resources.svg#c1"]
                    "{ clip-path: url(resources.svg#c1); }"
                testCase
                    "Clip path path"
                    [ClipPath.path "M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z"]
                    "{ clip-path: path('M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z'); }"
                testCase
                    "ClipPath all sides pct"
                    [ ClipPath.inset(pct 40)]
                     "{ clip-path: inset(40%); }" 
                testCase
                    "ClipPath all sides px"
                    [ ClipPath.inset(px 40)]
                     "{ clip-path: inset(40px); }" 
                testCase
                    "ClipPath horizontal-vertical"
                    [ ClipPath.inset(pct 40, px 50)]
                     "{ clip-path: inset(40% 50px); }" 
                testCase
                    "ClipPath top-horizontal-bottom"
                    [ ClipPath.inset(pct 40, px 50, vh 3.)]
                     "{ clip-path: inset(40% 50px 3vh); }" 
                testCase
                    "ClipPath top-right-bottom-left"
                    [ ClipPath.inset(pct 40, px 50, vh 3., rem 2.)]
                     "{ clip-path: inset(40% 50px 3vh 2rem); }" 
                testCase
                    "ClipPath all sides pct with round"
                    [ ClipPath.inset(pct 40, [ pct 50 :> ILengthPercentage ])]
                     "{ clip-path: inset(40% round 50%); }" 
                testCase
                    "ClipPath all sides px"
                    [ ClipPath.inset(px 40, [ px 50 :> ILengthPercentage ])]
                     "{ clip-path: inset(40px round 50px); }" 
                testCase
                    "ClipPath horizontal-vertical"
                    [ ClipPath.inset(pct 40, px 50, [ px 50 :> ILengthPercentage ])]
                     "{ clip-path: inset(40% 50px round 50px); }" 
                testCase
                    "ClipPath top-horizontal-bottom"
                    [ ClipPath.inset(pct 40, px 50, vh 3., [ px 50 :> ILengthPercentage ])]
                     "{ clip-path: inset(40% 50px 3vh round 50px); }" 
                testCase
                    "ClipPath top-right-bottom-left"
                    [ ClipPath.inset(pct 40, px 50, vh 3., rem 2., [ px 50; pct 50 ])]
                     "{ clip-path: inset(40% 50px 3vh 2rem round 50px 50%); }" 
                testCase
                    "ClipPath circle pct"
                    [ ClipPath.circle(pct 50)]
                     "{ clip-path: circle(50%); }" 
                testCase
                    "ClipPath circle px"
                    [ ClipPath.circle(px 25)]
                     "{ clip-path: circle(25px); }" 
                testCase
                    "ClipPath circle at pct"
                    [ ClipPath.circleAt(pct 50, pct 25, pct 25)]
                     "{ clip-path: circle(50% at 25% 25%); }" 
                testCase
                    "ClipPath circle at px"
                    [ ClipPath.circleAt(px 25, px 10, px 10)]
                     "{ clip-path: circle(25px at 10px 10px); }" 
                testCase
                    "ClipPath ellipse pct"
                    [ ClipPath.ellipse(pct 50)]
                     "{ clip-path: ellipse(50%); }" 
                testCase
                    "ClipPath ellipse px"
                    [ ClipPath.ellipse(px 25)]
                     "{ clip-path: ellipse(25px); }" 
                testCase
                    "ClipPath ellipse at pct"
                    [ ClipPath.ellipseAt(pct 50, pct 25, pct 25)]
                     "{ clip-path: ellipse(50% at 25% 25%); }" 
                testCase
                    "ClipPath ellipse at px"
                    [ ClipPath.ellipseAt(px 25, px 10, px 10)]
                     "{ clip-path: ellipse(25px at 10px 10px); }" 
                testCase
                    "ClipPath Polygon"
                    [ ClipPath.polygon
                                [
                                    pct 43, pct 0
                                    pct 62, pct 0
                                    pct 52, pct 26
                                    pct 69, pct 20
                                    pct 32, pct 100
                                    pct 42, pct 40
                                    pct 26, pct 46
                                ]]
                     "{ clip-path: polygon(43% 0%, 62% 0%, 52% 26%, 69% 20%, 32% 100%, 42% 40%, 26% 46%); }" 

                testCase
                    "ClipPath none"
                    [ ClipPath.none]
                     "{ clip-path: none; }" 
                testCase
                    "ClipPath inherit"
                    [ ClipPath.inherit']
                     "{ clip-path: inherit; }" 
                testCase
                    "ClipPath initial"
                    [ ClipPath.initial]
                     "{ clip-path: initial; }" 
                testCase
                    "ClipPath unset"
                    [ ClipPath.unset ]
                     "{ clip-path: unset; }" 
                testCase
                    "ClipPath revert"
                    [ ClipPath.revert ]
                     "{ clip-path: revert; }" 
            ]