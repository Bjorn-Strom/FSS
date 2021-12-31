namespace FSSTests

open Fet
open Utils
open Fss

module Transform =
       let tests =
        testList "Transform"
            [
                testCase
                    "Transform none"
                    [ Transform.none ]
                    "{ transform: none; }"
                testCase
                    "Transform inherit"
                    [ Transform.inherit' ]
                    "{ transform: inherit; }"
                testCase
                    "Transform initial"
                    [ Transform.initial ]
                    "{ transform: initial; }"
                testCase
                    "Transform unset"
                    [ Transform.unset ]
                    "{ transform: unset; }"
                testCase
                    "Transform matrix"
                    [ Transform.value [ Transform.matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0) ] ]
                    "{ transform: matrix(1, 2, 3, 4, 5, 6); }"
                testCase
                    "Transform matrix3d"
                    [ Transform.value [ Transform.matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0., 0., 0., 1.) ] ]
                    "{ transform: matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1); }"
                testCase
                    "Transform perspective"
                    [ Transform.value [ Transform.perspective(px 17) ] ]
                    "{ transform: perspective(17px); }"
                testCase
                    "Transform rotate"
                    [ Transform.value [ Transform.rotate(turn 0.5) ] ]
                    "{ transform: rotate(0.5turn); }"
                testCase
                    "Transform rotate3d"
                    [ Transform.value [ Transform.rotate3D(1.0, 2.0, 3.0, (deg 10.0)) ] ]
                    "{ transform: rotate3d(1, 2, 3, 10deg); }"
                testCase
                    "Transform rotate x"
                    [ Transform.value [ Transform.rotateX(deg 10.0) ] ]
                    "{ transform: rotateX(10deg); }"
                testCase
                    "Transform rotate y"
                    [ Transform.value [ Transform.rotateY(grad 360.0) ] ]
                    "{ transform: rotateY(360grad); }"
                testCase
                    "Transform rotate y"
                    [ Transform.value [ Transform.rotateZ(rad 1.5) ] ]
                    "{ transform: rotateZ(1.5rad); }"
                testCase
                    "Transform translate"
                    [ Transform.value [ Transform.translate(px 12) ] ]
                    "{ transform: translate(12px); }"
                testCase
                    "Transform translate2"
                    [ Transform.value [ Transform.translate(px 12, pct 50) ] ]
                    "{ transform: translate(12px, 50%); }"
                testCase
                    "Transform translate3d"
                    [ Transform.value [ Transform.translate3D(px 12, pct 50, em 3.0) ] ]
                    "{ transform: translate3d(12px, 50%, 3em); }"
                testCase
                    "Transform translate x"
                    [ Transform.value [ Transform.translateX (px 10) ] ]
                    "{ transform: translateX(10px); }"
                testCase
                    "Transform translate y"
                    [ Transform.value [ Transform.translateY(em 3.0) ] ]
                    "{ transform: translateY(3em); }"
                testCase
                    "Transform translate z"
                    [ Transform.value [ Transform.translateZ(rem 3.0) ] ]
                    "{ transform: translateZ(3rem); }"
                testCase
                    "Transform scale"
                    [ Transform.value [ Transform.scale(0.5) ] ]
                    "{ transform: scale(0.5); }"
                testCase
                    "Transform scale2"
                    [ Transform.value [ Transform.scale(0.5, 0.5) ] ]
                    "{ transform: scale(0.5, 0.5); }"
                testCase
                    "Transform translate3d"
                    [ Transform.value [ Transform.scale3D(0.1, 0.2, 0.3) ] ]
                    "{ transform: scale3d(0.1, 0.2, 0.3); }"
                testCase
                    "Transform scale x"
                    [ Transform.value [ Transform.scaleX(0.9) ] ]
                    "{ transform: scaleX(0.9); }"
                testCase
                    "Transform scale y"
                    [ Transform.value [ Transform.scaleY(2.3) ] ]
                    "{ transform: scaleY(2.3); }"
                testCase
                    "Transform scale z"
                    [ Transform.value [ Transform.scaleZ(3.4) ] ]
                    "{ transform: scaleZ(3.4); }"
                testCase
                    "Transform skew"
                    [ Transform.value [ Transform.skew(deg 270.) ] ]
                    "{ transform: skew(270deg); }"
                testCase
                    "Transform scale2"
                    [ Transform.value [ Transform.skew(turn 0.5, deg 10.0) ] ]
                    "{ transform: skew(0.5turn, 10deg); }"
                testCase
                    "Transform skew x"
                    [ Transform.value [ Transform.skewX(rad 9.) ] ]
                    "{ transform: skewX(9rad); }"
                testCase
                    "Transform skew y"
                    [ Transform.value [ Transform.skewY(deg 50.0) ] ]
                    "{ transform: skewY(50deg); }"
                testCase
                    "Transform multiple"
                    [ Transform.value [ Transform.translate3D(px 30, px 30, px 0); Transform.rotateZ(deg -179.) ] ]
                    "{ transform: translate3d(30px, 30px, 0px) rotateZ(-179deg); }"
                testCase
                    "Transform origin px"
                    [ TransformOrigin.value (px 2) ]
                    "{ transform-origin: 2px; }"
                testCase
                    "Transform origin position top"
                    [ TransformOrigin.top ]
                    "{ transform-origin: top; }"
                testCase
                    "Transform origin position right"
                    [ TransformOrigin.right ]
                    "{ transform-origin: right; }"
                testCase
                    "Transform origin position bottom"
                    [ TransformOrigin.bottom ]
                    "{ transform-origin: bottom; }"
                testCase
                    "Transform origin position left"
                    [ TransformOrigin.left ]
                    "{ transform-origin: left; }"
                testCase
                    "Transform origin inherit"
                    [ TransformOrigin.inherit' ]
                    "{ transform-origin: inherit; }"
                testCase
                    "Transform origin initial"
                    [ TransformOrigin.initial ]
                    "{ transform-origin: initial; }"
                testCase
                    "Transform origin unset"
                    [ TransformOrigin.unset ]
                    "{ transform-origin: unset; }"
                testCase
                    "Transform origin revert"
                    [ TransformOrigin.revert ]
                    "{ transform-origin: revert; }"
                testCase
                    "Transform style flat"
                    [ TransformStyle.flat ]
                    "{ transform-style: flat; }"
                testCase
                    "Transform style preserve 3d"
                    [ TransformStyle.preserve3d ]
                    "{ transform-style: preserve3d; }"
                testCase
                    "Transform style inherit"
                    [ TransformStyle.inherit' ]
                    "{ transform-style: inherit; }"
                testCase
                    "Transform style initial"
                    [ TransformStyle.initial ]
                    "{ transform-style: initial; }"
                testCase
                    "Transform style unset"
                    [ TransformStyle.unset ]
                    "{ transform-style: unset; }"
                testCase
                    "Transform style revert"
                    [ TransformStyle.revert ]
                    "{ transform-style: revert; }"
                    
                testCase
                    "Multiple transforms"
                    [
                        Transform.value [
                            Transform.rotate (deg 90.)
                            Transform.translate (px 20, px 0)
                        ]
                    ]
                    "{ transform: rotate(90deg) translate(20px, 0px); }"
            ]
