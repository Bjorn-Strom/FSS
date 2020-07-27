namespace Fss

open Types
open Global
open Units.Size
open Units.Angle

// https://developer.mozilla.org/en-US/docs/Web/CSS/transform
module Transform =
    type Transform = 
        | Matrix of float * float * float * float * float * float 
        | Matrix3D of int * int * int * int * int * int * int * int * int * int * int * int * float * float * float * float
        | Perspective of Size
        | Rotate of Angle
        | Rotate3D of float * float * float * Angle
        | RotateX of Angle
        | RotateY of Angle
        | RotateZ of Angle
        | Translate of Size
        | Translate2 of Size * Size
        | Translate3D of Size * Size * Size
        | TranslateX of Size
        | TranslateY of Size
        | TranslateZ of Size
        | Scale of float
        | Scale2 of float * float
        | Scale3D of float * float * float
        | ScaleX of float
        | ScaleY of float
        | ScaleZ of float
        | Skew of Angle
        | Skew2 of Angle * Angle
        | SkewX of Angle
        | SkewY of Angle
        interface ITransform

    let private transformValue (v: Transform): string =
        match v with
            | Matrix (a, b, c, d, e, f) -> 
                sprintf "matrix(%.1f, %.1f,     %.1f, %.1f, %.1f, %.1f)" a b c d e f
            | Matrix3D (a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4) ->
                sprintf "matrix3d(
                        %d, %d, %d, %d, 
                        %d, %d, %d, %d, 
                        %d, %d, %d, %d, 
                        %.1f, %.1f, %.1f, %.1f)" a1 b1 c1 d1 a2 b2 c2 d2 a3 b3 c3 d3 a4 b4 c4 d4
            | Perspective size -> sprintf "perspective(%s)" <| Units.Size.value size
            | Rotate angle -> sprintf "rotate(%s)" <| Units.Angle.value angle
            | Rotate3D (a, b, c, angle) -> sprintf "rotate3d(%.1f, %.1f, %.1f, %s)" a b c (Units.Angle.value angle)
            | RotateX angle -> sprintf "rotateX(%s)" <| Units.Angle.value angle
            | RotateY angle -> sprintf "rotateY(%s)" <| Units.Angle.value angle
            | RotateZ angle -> sprintf "rotateZ(%s)" <| Units.Angle.value angle
            | Translate size -> sprintf "translate(%s)" (Units.Size.value size)
            | Translate2 (sx, sy) -> sprintf "translate(%s, %s)" (Units.Size.value sx) (Units.Size.value sy)
            | Translate3D (size1, size2, size3) -> sprintf "translate3d(%s, %s, %s)" (Units.Size.value size1) (Units.Size.value size2) (Units.Size.value size3)
            | TranslateX size -> sprintf "translateX(%s)" <| Units.Size.value size
            | TranslateY size -> sprintf "translateY(%s)" <| Units.Size.value size
            | TranslateZ size -> sprintf "translateZ(%s)" <| Units.Size.value size
            | Scale n -> sprintf "scale(%.2f)" n
            | Scale2 (sx, sy) -> sprintf "scale(%.2f, %.2f)" sx sy
            | Scale3D (n1, n2, n3) -> sprintf "scale(%.2f, %.2f, %.2f)" n1 n2 n3
            | ScaleX n -> sprintf "scaleX(%.2f)" n
            | ScaleY n -> sprintf "scaleY(%.2f)" n
            | ScaleZ n -> sprintf "scaleZ(%.2f)" n
            | Skew a -> sprintf "skew(%s)" (Units.Angle.value a)
            | Skew2 (ax, ay) -> sprintf "skew(%s, %s)" (Units.Angle.value ax) (Units.Angle.value ay)
            | SkewX a -> sprintf "skewX(%s)" <| Units.Angle.value a
            | SkewY a -> sprintf "skewY(%s)" <| Units.Angle.value a

    let value (v: ITransform): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Transform as m -> transformValue m
            | :? Angle as a -> Units.Angle.value a
            | _ -> "Unknown margin size"
 