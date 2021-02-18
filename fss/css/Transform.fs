namespace Fss

[<RequireQualifiedAccess>]
module TransformType =
    type Transform =
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

    type TransformOrigin =
        | Top
        | Left
        | Right
        | Bottom
        | Center
        interface ITransformOrigin

    type TransformStyle =
        | Flat
        | Preserve3d
        interface ITransformStyle

// https://developer.mozilla.org/en-US/docs/Web/CSS/transform
[<AutoOpen>]
module Transform =
    let private transformToString (transform: ITransform) =
        let stringifyTransform = function
           | TransformType.Matrix (a, b, c, d, e, f) ->
               sprintf "matrix(%.1f, %.1f, %.1f, %.1f, %.1f, %.1f)" a b c d e f
           | TransformType.Matrix3D (a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4) ->
               sprintf "matrix3d(%d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %.1f, %.1f, %.1f, %.1f)" a1 b1 c1 d1 a2 b2 c2 d2 a3 b3 c3 d3 a4 b4 c4 d4
           | TransformType.Perspective size -> sprintf "perspective(%s)" <| Units.Size.value size
           | TransformType.Rotate angle -> sprintf "rotate(%s)" <| Units.Angle.value angle
           | TransformType.Rotate3D (a, b, c, angle) -> sprintf "rotate3d(%.1f, %.1f, %.1f, %s)" a b c (Units.Angle.value angle)
           | TransformType.RotateX angle -> sprintf "rotateX(%s)" <| Units.Angle.value angle
           | TransformType.RotateY angle -> sprintf "rotateY(%s)" <| Units.Angle.value angle
           | TransformType.RotateZ angle -> sprintf "rotateZ(%s)" <| Units.Angle.value angle
           | TransformType.Translate size -> sprintf "translate(%s)" (Units.LengthPercentage.value size)
           | TransformType.Translate2 (sx, sy) -> sprintf "translate(%s, %s)" (Units.LengthPercentage.value sx) (Units.LengthPercentage.value sy)
           | TransformType.Translate3D (size1, size2, size3) -> sprintf "translate3d(%s, %s, %s)" (Units.LengthPercentage.value size1) (Units.LengthPercentage.value size2) (Units.LengthPercentage.value size3)
           | TransformType.TranslateX size -> sprintf "translateX(%s)" <| Units.LengthPercentage.value size
           | TransformType.TranslateY size -> sprintf "translateY(%s)" <| Units.LengthPercentage.value size
           | TransformType.TranslateZ size -> sprintf "translateZ(%s)" <| Units.LengthPercentage.value size
           | TransformType.Scale n -> sprintf "scale(%.2f)" n
           | TransformType.Scale2 (sx, sy) -> sprintf "scale(%.2f, %.2f)" sx sy
           | TransformType.Scale3D (n1, n2, n3) -> sprintf "scale3d(%.2f, %.2f, %.2f)" n1 n2 n3
           | TransformType.ScaleX n -> sprintf "scaleX(%.2f)" n
           | TransformType.ScaleY n -> sprintf "scaleY(%.2f)" n
           | TransformType.ScaleZ n -> sprintf "scaleZ(%.2f)" n
           | TransformType.Skew a -> sprintf "skew(%s)" (Units.Angle.value a)
           | TransformType.Skew2 (ax, ay) -> sprintf "skew(%s, %s)" (Units.Angle.value ax) (Units.Angle.value ay)
           | TransformType.SkewX a -> sprintf "skewX(%s)" <| Units.Angle.value a
           | TransformType.SkewY a -> sprintf "skewY(%s)" <| Units.Angle.value a

        match transform with
        | :? TransformType.Transform as t -> stringifyTransform t
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown transform value"

    let private originToString (origin: ITransformOrigin) =
        match origin with
        | :? TransformType.TransformOrigin as t -> Utilities.Helpers.duToLowercase t
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown transform origin"

    let private styleToString (origin: ITransformStyle) =
        match origin with
        | :? TransformType.TransformStyle as t -> Utilities.Helpers.duToLowercase t
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown transform style"

    let private transformValue value = PropertyValue.cssValue Property.Transform value
    let private transformValue' value =
        value
        |> transformToString
        |> transformValue

    type Transform =
        static member Matrix (n1: float, n2: float, n3: float, n4: float, n5: float, n6: float) =
            TransformType.Matrix(n1,n2,n3,n4,n5,n6)
        static member Matrix3D
            (a1: int, b1: int, c1: int, d1: int,
             a2: int, b2: int, c2: int, d2: int,
             a3: int, b3: int, c3: int, d3: int,
             a4: float, b4: float, c4: float, d4: float) =
             TransformType.Matrix3D(a1, b1, c1, d1,
                      a2, b2, c2, d2,
                      a3, b3, c3, d3,
                      a4, b4, c4, d4)
        static member Perspective (value: Units.Size.Size) =
            TransformType.Perspective value
        static member Rotate (angle: Units.Angle.Angle) =
            TransformType.Rotate angle
        static member Rotate3D (n1: float, n2: float, n3: float, angle: Units.Angle.Angle) =
            TransformType.Rotate3D(n1,n2,n3,angle)
        static member RotateX (angle: Units.Angle.Angle) =
            TransformType.RotateX angle
        static member RotateY (angle: Units.Angle.Angle) =
            TransformType.RotateY angle
        static member RotateZ (angle: Units.Angle.Angle) =
            TransformType.RotateZ angle
        static member Translate (value: ILengthPercentage) =
            TransformType.Translate value
        static member Translate (x: ILengthPercentage, y: ILengthPercentage) =
            TransformType.Translate2(x,y)
        static member Translate3D (x: ILengthPercentage, y: ILengthPercentage, z: ILengthPercentage) =
            TransformType.Translate3D(x,y,z)
        static member TranslateX (x: ILengthPercentage) =
            TransformType.TranslateX x
        static member TranslateY (y: ILengthPercentage) =
            TransformType.TranslateY y
        static member TranslateZ (z: ILengthPercentage) =
            TransformType.TranslateZ z
        static member Scale (value: float) =
            TransformType.Scale value
        static member Scale (x: float, y: float) =
            TransformType.Scale2(x,y)
        static member Scale3D (x: float, y: float, z: float) =
            TransformType.Scale3D (x,y,z)
        static member ScaleX (x: float) =
            TransformType.ScaleX x
        static member ScaleY (y: float) =
            TransformType.ScaleY y
        static member ScaleZ (z: float) =
            TransformType.ScaleZ z
        static member Skew (angle: Units.Angle.Angle) =
            TransformType.Skew angle
        static member Skew (x: Units.Angle.Angle, y: Units.Angle.Angle) =
            TransformType.Skew2(x,y)
        static member SkewX (x: Units.Angle.Angle) =
            TransformType.SkewX x
        static member SkewY (y: Units.Angle.Angle) =
            TransformType.SkewY y

        static member None = None' |> transformValue'
        static member Inherit = Inherit |> transformValue'
        static member Initial = Initial |> transformValue'
        static member Unset = Unset |> transformValue'


    /// Supply a list of transforms to be applied to the element.
    let Transforms (transforms: TransformType.Transform list): CSSProperty =
        transforms
        |> Utilities.Helpers.combineWs transformToString
        |> transformValue

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

        static member Top = TransformType.Top |> originValue'
        static member Left = TransformType.Left |> originValue'
        static member Right = TransformType.Right |> originValue'
        static member Bottom = TransformType.Bottom |> originValue'
        static member Center = TransformType.Center |> originValue'

        static member Inherit = Inherit |> originValue'
        static member Initial = Initial |> originValue'
        static member Unset = Unset |> originValue'

    /// <summary>Specifies the origin of an elements transformation.</summary>
    /// <param name="origin">
    ///     can be:
    ///     - <c> TransformOrigin </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransformOrigin' (origin: ITransformOrigin) = TransformOrigin.Value(origin)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style
    let private styleValue value = PropertyValue.cssValue Property.TransformStyle value
    let private styleValue' value =
        value
        |> styleToString
        |> styleValue
    type TransformStyle =
        static member Value (value: ITransformStyle) = value |> styleValue'

        static member Flat = TransformType.Flat |> styleValue'
        static member Preserve3d = TransformType.Preserve3d |> styleValue'

        static member Inherit = Inherit |> styleValue'
        static member Initial = Initial |> styleValue'
        static member Unset = Unset |> styleValue'

    /// <summary>Specifies the whether children of an element are positioned flat or in 3d.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> TransformStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransformStyle' (style: ITransformStyle) = TransformStyle.Value(style)

