namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Transform =
       let tests =
        testList "Transform"
            [
                (*
                test
                    "Transform none"
                    [ Transform.None ]
                    [ "transform" ==> "none" ]
                    *)
                test
                    "Transform matrix"
                    [ Transforms [ Transform.Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0) ] ]
                    [ "transform" ==> "matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)" ]
                test
                    "Transform matrix3d"
                    [ Transforms [ Transform.Matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0., 0., 0., 1.) ] ]
                    [ "transform" ==> "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0.0, 0.0, 0.0, 1.0)" ]
                test
                    "Transform perspective"
                    [ Transforms [ Transform.Perspective(px 17) ] ]
                    [ "transform" ==> "perspective(17px)" ]
                test
                    "Transform rotate"
                    [ Transforms [ Transform.Rotate(turn 0.5) ] ]
                    [ "transform" ==> "rotate(0.50turn)" ]
                test
                    "Transform rotate3d"
                    [ Transforms [ Transform.Rotate3D(1.0, 2.0, 3.0, (deg 10.0)) ] ]
                    [ "transform" ==> "rotate3d(1.0, 2.0, 3.0, 10.00deg)" ]
                test
                    "Transform rotate x"
                    [ Transforms [ Transform.RotateX(deg 10.0) ] ]
                    [ "transform" ==> "rotateX(10.00deg)" ]
                test
                    "Transform rotate y"
                    [ Transforms [ Transform.RotateY(grad 360.0) ] ]
                    [ "transform" ==> "rotateY(360.00grad)" ]
                test
                    "Transform rotate y"
                    [ Transforms [ Transform.RotateZ(rad 1.5) ] ]
                    [ "transform" ==> "rotateZ(1.5000rad)" ]
                test
                    "Transform translate"
                    [ Transforms [ Transform.Translate(px 12) ] ]
                    [ "transform" ==> "translate(12px)" ]
                test
                    "Transform translate2"
                    [ Transforms [ Transform.Translate(px 12, pct 50) ] ]
                    [ "transform" ==> "translate(12px, 50%)" ]
                test
                    "Transform translate3d"
                    [ Transforms [ Transform.Translate3D(px 12, pct 50, em 3.0) ] ]
                    [ "transform" ==> "translate3d(12px, 50%, 3.0em)" ]
                test
                    "Transform translate x"
                    [ Transforms [ Transform.TranslateX (px 10) ] ]
                    [ "transform" ==> "translateX(10px)" ]
                test
                    "Transform translate y"
                    [ Transforms [ Transform.TranslateY(em 3.0) ] ]
                    [ "transform" ==> "translateY(3.0em)" ]
                test
                    "Transform translate z"
                    [ Transforms [ Transform.TranslateZ(rem 3.0) ] ]
                    [ "transform" ==> "translateZ(3.0rem)" ]
                test
                    "Transform scale"
                    [ Transforms [ Transform.Scale(0.5) ] ]
                    [ "transform" ==> "scale(0.50)" ]
                test
                    "Transform scale2"
                    [ Transforms [ Transform.Scale(0.5, 0.5) ] ]
                    [ "transform" ==> "scale(0.50, 0.50)" ]
                test
                    "Transform translate3d"
                    [ Transforms [ Transform.Scale3D(0.1, 0.2, 0.3) ] ]
                    [ "transform" ==> "scale3d(0.10, 0.20, 0.30)" ]
                test
                    "Transform scale x"
                    [ Transforms [ Transform.ScaleX(0.9) ] ]
                    [ "transform" ==> "scaleX(0.90)" ]
                test
                    "Transform scale y"
                    [ Transforms [ Transform.ScaleY(2.3) ] ]
                    [ "transform" ==> "scaleY(2.30)" ]
                test
                    "Transform scale z"
                    [ Transforms [ Transform.ScaleZ(3.4) ] ]
                    [ "transform" ==> "scaleZ(3.40)" ]
                test
                    "Transform skew"
                    [ Transforms [ Transform.Skew(deg 270.) ] ]
                    [ "transform" ==> "skew(270.00deg)" ]
                test
                    "Transform scale2"
                    [ Transforms [ Transform.Skew(turn 0.5, deg 10.0) ] ]
                    [ "transform" ==> "skew(0.50turn, 10.00deg)" ]
                test
                    "Transform skew x"
                    [ Transforms [ Transform.SkewX(rad 9.) ] ]
                    [ "transform" ==> "skewX(9.0000rad)" ]
                test
                    "Transform skew y"
                    [ Transforms [ Transform.SkewY(deg 50.0) ] ]
                    [ "transform" ==> "skewY(50.00deg)" ]
                test
                    "Transform multiple"
                    [ Transforms [ Transform.Translate3D(px 30, px 30, px 0); Transform.RotateZ(deg -179.) ] ]
                    ["transform" ==> "translate3d(30px, 30px, 0px) rotateZ(-179.00deg)"]
                test
                    "Transform origin px"
                    [ TransformOrigin' (px 2) ]
                    [ "transformOrigin" ==> "2px" ]
                test
                    "Transform origin position"
                    [ TransformOrigin.Bottom ]
                    [ "transformOrigin" ==> "bottom" ]
                test
                    "Transform origin inherit"
                    [ TransformOrigin.Inherit ]
                    [ "transformOrigin" ==> "inherit" ]
                test
                    "Transform origin initial"
                    [ TransformOrigin.Initial ]
                    [ "transformOrigin" ==> "initial" ]
                test
                    "Transform origin unset"
                    [ TransformOrigin.Unset ]
                    [ "transformOrigin" ==> "unset" ]
            ]
