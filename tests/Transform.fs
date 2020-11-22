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
                    [ Transform.None ]
                    [ "transform" ==> "none" ]
                test
                    "Transform matrix"
                    [ Transform.Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0) ]
                    [ "transform" ==> "matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)" ]
                test
                    "Transform matrix3d"
                    [ Transform.Matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0., 0., 0., 1.) ]
                    [ "transform" ==> "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0.0, 0.0, 0.0, 1.0)" ]
                test
                    "Transform perspective"
                    [ Transform.Perspective(px 17) ]
                    [ "transform" ==> "perspective(17px)" ]
                test
                    "Transform rotate"
                    [ Transform.Rotate(turn 0.5) ]
                    [ "transform" ==> "rotate(0.50turn)" ]
                test
                    "Transform rotate3d"
                    [ Transform.Rotate3D(1.0, 2.0, 3.0, (deg 10.0)) ]
                    [ "transform" ==> "rotate3d(1.0, 2.0, 3.0, 10.00deg)" ]
                test
                    "Transform rotate x"
                    [ Transform.RotateX(deg 10.0) ]
                    [ "transform" ==> "rotateX(10.00deg)" ]
                test
                    "Transform rotate y"
                    [ Transform.RotateY(grad 360.0) ]
                    [ "transform" ==> "rotateY(360.00grad)" ]
                test
                    "Transform rotate y"
                    [ Transform.RotateZ(rad 1.5) ]
                    [ "transform" ==> "rotateZ(1.5000rad)" ]
                test
                    "Transform translate"
                    [ Transform.Translate(px 12) ]
                    [ "transform" ==> "translate(12px)" ]
                test
                    "Transform translate2"
                    [ Transform.Translate(px 12, pct 50) ]
                    [ "transform" ==> "translate(12px, 50%)" ]
                test
                    "Transform translate3d"
                    [ Transform.Translate3D(px 12, pct 50, em 3.0) ]
                    [ "transform" ==> "translate3d(12px, 50%, 3.0em)" ]
                test
                    "Transform translate x"
                    [ Transform.TranslateX (px 10) ]
                    [ "transform" ==> "translateX(10px)" ]
                test
                    "Transform translate y"
                    [ Transform.TranslateY(em 3.0) ]
                    [ "transform" ==> "translateY(3.0em)" ]
                test
                    "Transform translate z"
                    [ Transform.TranslateZ(rem 3.0) ]
                    [ "transform" ==> "translateZ(3.0rem)" ]
                test
                    "Transform scale"
                    [ Transform.Scale(0.5) ]
                    [ "transform" ==> "scale(0.50)" ]
                test
                    "Transform scale2"
                    [ Transform.Scale(0.5, 0.5) ]
                    [ "transform" ==> "scale(0.50, 0.50)" ]
                test
                    "Transform translate3d"
                    [ Transform.Scale3D(0.1, 0.2, 0.3) ]
                    [ "transform" ==> "scale3d(0.10, 0.20, 0.30)" ]
                test
                    "Transform scale x"
                    [ Transform.ScaleX(0.9) ]
                    [ "transform" ==> "scaleX(0.90)" ]
                test
                    "Transform scale y"
                    [ Transform.ScaleY(2.3) ]
                    [ "transform" ==> "scaleY(2.30)" ]
                test
                    "Transform scale z"
                    [ Transform.ScaleZ(3.4) ]
                    [ "transform" ==> "scaleZ(3.40)" ]
                test
                    "Transform skew"
                    [ Transform.Skew(deg 270.) ]
                    [ "transform" ==> "skew(270.00deg)" ]
                test
                    "Transform scale2"
                    [ Transform.Skew(turn 0.5, deg 10.0) ]
                    [ "transform" ==> "skew(0.50turn, 10.00deg)" ]
                test
                    "Transform skew x"
                    [ Transform.SkewX(rad 9.) ]
                    [ "transform" ==> "skewX(9.0000rad)" ]
                test
                    "Transform skew y"
                    [ Transform.SkewY(deg 50.0) ]
                    [ "transform" ==> "skewY(50.00deg)" ]
                test
                    "Transform inherit"
                    [ Transform.Inherit ]
                    [ "transform" ==> "inherit" ]
                test
                    "Transform initial"
                    [ Transform.Initial ]
                    [ "transform" ==> "initial" ]
                test
                    "Transform unset"
                    [ Transform.Unset ]
                    [ "transform" ==> "unset" ]
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