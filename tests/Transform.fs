namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Transform =
       let tests =
        testList "Transform"
            [
                test
                    "Transform none"
                    [ Transform.none ]
                    [ "transform" ==> "none" ]
                test
                    "Transform inherit"
                    [ Transform.inherit' ]
                    [ "transform" ==> "inherit" ]
                test
                    "Transform initial"
                    [ Transform.initial ]
                    [ "transform" ==> "initial" ]
                test
                    "Transform unset"
                    [ Transform.unset ]
                    [ "transform" ==> "unset" ]
                test
                    "Transform matrix"
                    [ Transforms [ Transform.matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0) ] ]
                    [ "transform" ==> "matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)" ]
                test
                    "Transform matrix3d"
                    [ Transforms [ Transform.matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0., 0., 0., 1.) ] ]
                    [ "transform" ==> "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0.0, 0.0, 0.0, 1.0)" ]
                test
                    "Transform perspective"
                    [ Transforms [ Transform.perspective(px 17) ] ]
                    [ "transform" ==> "perspective(17px)" ]
                test
                    "Transform rotate"
                    [ Transforms [ Transform.rotate(turn 0.5) ] ]
                    [ "transform" ==> "rotate(0.50turn)" ]
                test
                    "Transform rotate3d"
                    [ Transforms [ Transform.rotate3D(1.0, 2.0, 3.0, (deg 10.0)) ] ]
                    [ "transform" ==> "rotate3d(1.0, 2.0, 3.0, 10.00deg)" ]
                test
                    "Transform rotate x"
                    [ Transforms [ Transform.rotateX(deg 10.0) ] ]
                    [ "transform" ==> "rotateX(10.00deg)" ]
                test
                    "Transform rotate y"
                    [ Transforms [ Transform.rotateY(grad 360.0) ] ]
                    [ "transform" ==> "rotateY(360.00grad)" ]
                test
                    "Transform rotate y"
                    [ Transforms [ Transform.rotateZ(rad 1.5) ] ]
                    [ "transform" ==> "rotateZ(1.5000rad)" ]
                test
                    "Transform translate"
                    [ Transforms [ Transform.translate(px 12) ] ]
                    [ "transform" ==> "translate(12px)" ]
                test
                    "Transform translate2"
                    [ Transforms [ Transform.translate(px 12, pct 50) ] ]
                    [ "transform" ==> "translate(12px, 50%)" ]
                test
                    "Transform translate3d"
                    [ Transforms [ Transform.translate3D(px 12, pct 50, em 3.0) ] ]
                    [ "transform" ==> "translate3d(12px, 50%, 3.0em)" ]
                test
                    "Transform translate x"
                    [ Transforms [ Transform.translateX (px 10) ] ]
                    [ "transform" ==> "translateX(10px)" ]
                test
                    "Transform translate y"
                    [ Transforms [ Transform.translateY(em 3.0) ] ]
                    [ "transform" ==> "translateY(3.0em)" ]
                test
                    "Transform translate z"
                    [ Transforms [ Transform.translateZ(rem 3.0) ] ]
                    [ "transform" ==> "translateZ(3.0rem)" ]
                test
                    "Transform scale"
                    [ Transforms [ Transform.scale(0.5) ] ]
                    [ "transform" ==> "scale(0.50)" ]
                test
                    "Transform scale2"
                    [ Transforms [ Transform.scale(0.5, 0.5) ] ]
                    [ "transform" ==> "scale(0.50, 0.50)" ]
                test
                    "Transform translate3d"
                    [ Transforms [ Transform.scale3D(0.1, 0.2, 0.3) ] ]
                    [ "transform" ==> "scale3d(0.10, 0.20, 0.30)" ]
                test
                    "Transform scale x"
                    [ Transforms [ Transform.scaleX(0.9) ] ]
                    [ "transform" ==> "scaleX(0.90)" ]
                test
                    "Transform scale y"
                    [ Transforms [ Transform.scaleY(2.3) ] ]
                    [ "transform" ==> "scaleY(2.30)" ]
                test
                    "Transform scale z"
                    [ Transforms [ Transform.scaleZ(3.4) ] ]
                    [ "transform" ==> "scaleZ(3.40)" ]
                test
                    "Transform skew"
                    [ Transforms [ Transform.skew(deg 270.) ] ]
                    [ "transform" ==> "skew(270.00deg)" ]
                test
                    "Transform scale2"
                    [ Transforms [ Transform.skew(turn 0.5, deg 10.0) ] ]
                    [ "transform" ==> "skew(0.50turn, 10.00deg)" ]
                test
                    "Transform skew x"
                    [ Transforms [ Transform.skewX(rad 9.) ] ]
                    [ "transform" ==> "skewX(9.0000rad)" ]
                test
                    "Transform skew y"
                    [ Transforms [ Transform.skewY(deg 50.0) ] ]
                    [ "transform" ==> "skewY(50.00deg)" ]
                test
                    "Transform multiple"
                    [ Transforms [ Transform.translate3D(px 30, px 30, px 0); Transform.rotateZ(deg -179.) ] ]
                    ["transform" ==> "translate3d(30px, 30px, 0px) rotateZ(-179.00deg)"]
                test
                    "Transform origin px"
                    [ TransformOrigin' (px 2) ]
                    [ "transformOrigin" ==> "2px" ]
                test
                    "Transform origin position"
                    [ TransformOrigin.bottom ]
                    [ "transformOrigin" ==> "bottom" ]
                test
                    "Transform origin inherit"
                    [ TransformOrigin.inherit' ]
                    [ "transformOrigin" ==> "inherit" ]
                test
                    "Transform origin initial"
                    [ TransformOrigin.initial ]
                    [ "transformOrigin" ==> "initial" ]
                test
                    "Transform origin unset"
                    [ TransformOrigin.unset ]
                    [ "transformOrigin" ==> "unset" ]
                test
                    "Transform style flat"
                    [ TransformStyle.flat ]
                    [ "transformStyle" ==> "flat" ]
                test
                    "Transform style preserve 3d"
                    [ TransformStyle.preserve3d ]
                    [ "transformStyle" ==> "preserve3d" ]
                test
                    "Transform style inherit"
                    [ TransformStyle.inherit' ]
                    [ "transformStyle" ==> "inherit" ]
                test
                    "Transform style initial"
                    [ TransformStyle.initial ]
                    [ "transformStyle" ==> "initial" ]
                test
                    "Transform style unset"
                    [ TransformStyle.unset ]
                    [ "transformStyle" ==> "unset" ]
            ]
