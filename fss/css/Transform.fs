namespace Fss

module TransformType =
    type TransformType =
        | Matrix of float * float * float * float * float * float
        | Matrix3D of int * int * int * int * int * int * int * int * int * int * int * int * float * float * float * float
        | Perspective of Units.Size.Size
        | Rotate of Units.Angle.Angle
        | Rotate3D of float * float * float * Units.Angle.Angle
        | RotateX of Units.Angle.Angle
        | RotateY of Units.Angle.Angle
        | RotateZ of Units.Angle.Angle
        | Translate of ILengthPercentage
        | Translate2 of ILengthPercentage * ILengthPercentage
        | Translate3D of ILengthPercentage * ILengthPercentage * ILengthPercentage
        | TranslateX of ILengthPercentage
        | TranslateY of ILengthPercentage
        | TranslateZ of ILengthPercentage
        | Scale of float
        | Scale2 of float * float
        | Scale3D of float * float * float
        | ScaleX of float
        | ScaleY of float
        | ScaleZ of float
        | Skew of Units.Angle.Angle
        | Skew2 of Units.Angle.Angle * Units.Angle.Angle
        | SkewX of Units.Angle.Angle
        | SkewY of Units.Angle.Angle
        interface ITransform

    type TransformOriginType =
        | Top
        | Left
        | Right
        | Bottom
        | Center
        interface ITransformOrigin

// https://developer.mozilla.org/en-US/docs/Web/CSS/transform
[<AutoOpen>]
module Transform =
    open TransformType

    let private transformToString (transform: ITransform) =
        let stringifyTransform =
            function
               | Matrix (a, b, c, d, e, f) ->
                   sprintf "matrix(%.1f, %.1f, %.1f, %.1f, %.1f, %.1f)" a b c d e f
               | Matrix3D (a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4) ->
                   sprintf "matrix3d(%d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %.1f, %.1f, %.1f, %.1f)" a1 b1 c1 d1 a2 b2 c2 d2 a3 b3 c3 d3 a4 b4 c4 d4
               | Perspective size -> sprintf "perspective(%s)" <| Units.Size.value size
               | Rotate angle -> sprintf "rotate(%s)" <| Units.Angle.value angle
               | Rotate3D (a, b, c, angle) -> sprintf "rotate3d(%.1f, %.1f, %.1f, %s)" a b c (Units.Angle.value angle)
               | RotateX angle -> sprintf "rotateX(%s)" <| Units.Angle.value angle
               | RotateY angle -> sprintf "rotateY(%s)" <| Units.Angle.value angle
               | RotateZ angle -> sprintf "rotateZ(%s)" <| Units.Angle.value angle
               | Translate size -> sprintf "translate(%s)" (Units.LengthPercentage.value size)
               | Translate2 (sx, sy) -> sprintf "translate(%s, %s)" (Units.LengthPercentage.value sx) (Units.LengthPercentage.value sy)
               | Translate3D (size1, size2, size3) -> sprintf "translate3d(%s, %s, %s)" (Units.LengthPercentage.value size1) (Units.LengthPercentage.value size2) (Units.LengthPercentage.value size3)
               | TranslateX size -> sprintf "translateX(%s)" <| Units.LengthPercentage.value size
               | TranslateY size -> sprintf "translateY(%s)" <| Units.LengthPercentage.value size
               | TranslateZ size -> sprintf "translateZ(%s)" <| Units.LengthPercentage.value size
               | Scale n -> sprintf "scale(%.2f)" n
               | Scale2 (sx, sy) -> sprintf "scale(%.2f, %.2f)" sx sy
               | Scale3D (n1, n2, n3) -> sprintf "scale3d(%.2f, %.2f, %.2f)" n1 n2 n3
               | ScaleX n -> sprintf "scaleX(%.2f)" n
               | ScaleY n -> sprintf "scaleY(%.2f)" n
               | ScaleZ n -> sprintf "scaleZ(%.2f)" n
               | Skew a -> sprintf "skew(%s)" (Units.Angle.value a)
               | Skew2 (ax, ay) -> sprintf "skew(%s, %s)" (Units.Angle.value ax) (Units.Angle.value ay)
               | SkewX a -> sprintf "skewX(%s)" <| Units.Angle.value a
               | SkewY a -> sprintf "skewY(%s)" <| Units.Angle.value a

        match transform with
        | :? TransformType as t -> stringifyTransform t
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown transform"

    let private originToString (origin: ITransformOrigin) =
        let stringifyOrigin =
            function
                | Top -> "top"
                | Left -> "left"
                | Right -> "right"
                | Bottom -> "bottom"
                | Center -> "center"

        match origin with
        | :? TransformOriginType as t -> stringifyOrigin t
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown transform origin"


    let private transformValue value = PropertyValue.cssValue Property.Transform value
    let private transformValue' value =
        value
        |> transformToString
        |> transformValue
    type Transform =
        static member Value (transform: ITransform) = transform |> transformValue'
        static member Value (transforms: ITransform list) =
            transforms
            |> List.map transformToString
            |> String.concat " "
            |> transformValue
        static member Matrix (n1: float, n2: float, n3: float, n4: float, n5: float, n6: float) =
            Matrix(n1,n2,n3,n4,n5,n6) |> transformValue'
        static member Matrix3D
            (a1: int, b1: int, c1: int, d1: int,
             a2: int, b2: int, c2: int, d2: int,
             a3: int, b3: int, c3: int, d3: int,
             a4: float, b4: float, c4: float, d4: float) =
             Matrix3D(a1, b1, c1, d1,
                      a2, b2, c2, d2,
                      a3, b3, c3, d3,
                      a4, b4, c4, d4)
            |> transformValue'
        static member Perspective (value: Units.Size.Size) = Perspective value |> transformValue'
        static member Rotate (angle: Units.Angle.Angle) = Rotate angle |> transformValue'
        static member Rotate3D (n1: float, n2: float, n3: float, angle: Units.Angle.Angle) =
            Rotate3D(n1,n2,n3,angle) |> transformValue'
        static member RotateX (angle: Units.Angle.Angle) =  RotateX angle |> transformValue'
        static member RotateY (angle: Units.Angle.Angle) = RotateY angle |> transformValue'
        static member RotateZ (angle: Units.Angle.Angle) =  RotateZ angle  |> transformValue'
        static member Translate (value: ILengthPercentage) = Translate value |> transformValue'
        static member Translate (x: ILengthPercentage, y: ILengthPercentage) = Translate2(x,y) |> transformValue'
        static member Translate3D (x: ILengthPercentage, y: ILengthPercentage, z: ILengthPercentage) = Translate3D(x,y,z) |> transformValue'
        static member TranslateX (x: ILengthPercentage) = TranslateX x |>  transformValue'
        static member TranslateY (y: ILengthPercentage) = TranslateY y  |> transformValue'
        static member TranslateZ (z: ILengthPercentage) = TranslateZ z |> transformValue'
        static member Scale (value: float) = Scale value |> transformValue'
        static member Scale (x: float, y: float) = Scale2(x,y) |> transformValue'
        static member Scale3D (x: float, y: float, z: float) = Scale3D (x,y,z) |> transformValue'
        static member ScaleX (x: float) = ScaleX x |> transformValue'
        static member ScaleY (y: float) = ScaleY y |> transformValue'
        static member ScaleZ (z: float) = ScaleZ z |> transformValue'
        static member Skew (angle: Units.Angle.Angle) = Skew  angle |>  transformValue'
        static member Skew (x: Units.Angle.Angle, y: Units.Angle.Angle) = Skew2(x,y) |> transformValue'
        static member SkewX (x: Units.Angle.Angle) = SkewX x |> transformValue'
        static member SkewY (y: Units.Angle.Angle) = SkewY y |> transformValue'

        static member None = None |> transformValue'
        static member Inherit = Inherit |> transformValue'
        static member Initial = Initial |> transformValue'
        static member Unset = Unset |> transformValue'

    let Transform' (transform: ITransform) = Transform.Value(transform)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-origin
    let private originValue value = PropertyValue.cssValue Property.TransformOrigin value
    let private originValue' value =
        value
        |> originToString
        |> originValue
    type TransformOrigin =
        static member Value (value: ITransformOrigin) = value |> originValue'
        static member Value (xOffset: ITransformOrigin, yOffset: ITransformOrigin) =
            sprintf "%s %s"
                (originToString xOffset)
                (originToString yOffset)
            |> originValue
        static member Value (xOffset: ITransformOrigin, yOffset: ITransformOrigin, zOffset: ITransformOrigin) =
            sprintf "%s %s %s"
                (originToString xOffset)
                (originToString yOffset)
                (originToString zOffset)
            |> originValue

        static member Top = Top |> originValue'
        static member Left = Left |> originValue'
        static member Right = Right |> originValue'
        static member Bottom = Bottom |> originValue'
        static member Center = Center |> originValue'

        static member Inherit = Inherit |> originValue'
        static member Initial = Initial |> originValue'
        static member Unset = Unset |> originValue'

    let TransformOrigin' (origin: ITransformOrigin) = TransformOrigin.Value(origin)
