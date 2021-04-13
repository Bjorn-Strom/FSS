namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Transform =
       let tests =
        testList "Transform"
            [
                testCase
                    "Transform none"
                    [ Transform.none ]
                    [ "transform" ==> "none" ]
                testCase
                    "Transform inherit"
                    [ Transform.inherit' ]
                    [ "transform" ==> "inherit" ]
                testCase
                    "Transform initial"
                    [ Transform.initial ]
                    [ "transform" ==> "initial" ]
                testCase
                    "Transform unset"
                    [ Transform.unset ]
                    [ "transform" ==> "unset" ]
                testCase
                    "Transform matrix"
                    [ Transforms [ Transform.matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0) ] ]
                    [ "transform" ==> "matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)" ]
                testCase
                    "Transform matrix3d"
                    [ Transforms [ Transform.matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0., 0., 0., 1.) ] ]
                    [ "transform" ==> "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0.0, 0.0, 0.0, 1.0)" ]
                testCase
                    "Transform perspective"
                    [ Transforms [ Transform.perspective(px 17) ] ]
                    [ "transform" ==> "perspective(17px)" ]
                testCase
                    "Transform rotate"
                    [ Transforms [ Transform.rotate(turn 0.5) ] ]
                    [ "transform" ==> "rotate(0.50turn)" ]
                testCase
                    "Transform rotate3d"
                    [ Transforms [ Transform.rotate3D(1.0, 2.0, 3.0, (deg 10.0)) ] ]
                    [ "transform" ==> "rotate3d(1.0, 2.0, 3.0, 10.00deg)" ]
                testCase
                    "Transform rotate x"
                    [ Transforms [ Transform.rotateX(deg 10.0) ] ]
                    [ "transform" ==> "rotateX(10.00deg)" ]
                testCase
                    "Transform rotate y"
                    [ Transforms [ Transform.rotateY(grad 360.0) ] ]
                    [ "transform" ==> "rotateY(360.00grad)" ]
                testCase
                    "Transform rotate y"
                    [ Transforms [ Transform.rotateZ(rad 1.5) ] ]
                    [ "transform" ==> "rotateZ(1.5000rad)" ]
                testCase
                    "Transform translate"
                    [ Transforms [ Transform.translate(px 12) ] ]
                    [ "transform" ==> "translate(12px)" ]
                testCase
                    "Transform translate2"
                    [ Transforms [ Transform.translate(px 12, pct 50) ] ]
                    [ "transform" ==> "translate(12px, 50%)" ]
                testCase
                    "Transform translate3d"
                    [ Transforms [ Transform.translate3D(px 12, pct 50, em 3.0) ] ]
                    [ "transform" ==> "translate3d(12px, 50%, 3.0em)" ]
                testCase
                    "Transform translate x"
                    [ Transforms [ Transform.translateX (px 10) ] ]
                    [ "transform" ==> "translateX(10px)" ]
                testCase
                    "Transform translate y"
                    [ Transforms [ Transform.translateY(em 3.0) ] ]
                    [ "transform" ==> "translateY(3.0em)" ]
                testCase
                    "Transform translate z"
                    [ Transforms [ Transform.translateZ(rem 3.0) ] ]
                    [ "transform" ==> "translateZ(3.0rem)" ]
                testCase
                    "Transform scale"
                    [ Transforms [ Transform.scale(0.5) ] ]
                    [ "transform" ==> "scale(0.50)" ]
                testCase
                    "Transform scale2"
                    [ Transforms [ Transform.scale(0.5, 0.5) ] ]
                    [ "transform" ==> "scale(0.50, 0.50)" ]
                testCase
                    "Transform translate3d"
                    [ Transforms [ Transform.scale3D(0.1, 0.2, 0.3) ] ]
                    [ "transform" ==> "scale3d(0.10, 0.20, 0.30)" ]
                testCase
                    "Transform scale x"
                    [ Transforms [ Transform.scaleX(0.9) ] ]
                    [ "transform" ==> "scaleX(0.90)" ]
                testCase
                    "Transform scale y"
                    [ Transforms [ Transform.scaleY(2.3) ] ]
                    [ "transform" ==> "scaleY(2.30)" ]
                testCase
                    "Transform scale z"
                    [ Transforms [ Transform.scaleZ(3.4) ] ]
                    [ "transform" ==> "scaleZ(3.40)" ]
                testCase
                    "Transform skew"
                    [ Transforms [ Transform.skew(deg 270.) ] ]
                    [ "transform" ==> "skew(270.00deg)" ]
                testCase
                    "Transform scale2"
                    [ Transforms [ Transform.skew(turn 0.5, deg 10.0) ] ]
                    [ "transform" ==> "skew(0.50turn, 10.00deg)" ]
                testCase
                    "Transform skew x"
                    [ Transforms [ Transform.skewX(rad 9.) ] ]
                    [ "transform" ==> "skewX(9.0000rad)" ]
                testCase
                    "Transform skew y"
                    [ Transforms [ Transform.skewY(deg 50.0) ] ]
                    [ "transform" ==> "skewY(50.00deg)" ]
                testCase
                    "Transform multiple"
                    [ Transforms [ Transform.translate3D(px 30, px 30, px 0); Transform.rotateZ(deg -179.) ] ]
                    ["transform" ==> "translate3d(30px, 30px, 0px) rotateZ(-179.00deg)"]
                testCase
                    "Transform origin px"
                    [ TransformOrigin' (px 2) ]
                    [ "transformOrigin" ==> "2px" ]
                testCase
                    "Transform origin position"
                    [ TransformOrigin.bottom ]
                    [ "transformOrigin" ==> "bottom" ]
                testCase
                    "Transform origin inherit"
                    [ TransformOrigin.inherit' ]
                    [ "transformOrigin" ==> "inherit" ]
                testCase
                    "Transform origin initial"
                    [ TransformOrigin.initial ]
                    [ "transformOrigin" ==> "initial" ]
                testCase
                    "Transform origin unset"
                    [ TransformOrigin.unset ]
                    [ "transformOrigin" ==> "unset" ]
                testCase
                    "Transform style flat"
                    [ TransformStyle.flat ]
                    [ "transformStyle" ==> "flat" ]
                testCase
                    "Transform style preserve 3d"
                    [ TransformStyle.preserve3d ]
                    [ "transformStyle" ==> "preserve3d" ]
                testCase
                    "Transform style inherit"
                    [ TransformStyle.inherit' ]
                    [ "transformStyle" ==> "inherit" ]
                testCase
                    "Transform style initial"
                    [ TransformStyle.initial ]
                    [ "transformStyle" ==> "initial" ]
                testCase
                    "Transform style unset"
                    [ TransformStyle.unset ]
                    [ "transformStyle" ==> "unset" ]
            ]
