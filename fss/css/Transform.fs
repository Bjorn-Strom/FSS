namespace Fss
open FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/transform
[<AutoOpen>]
module Transform =
    let private transformToString (transform: ITransform) =
        let stringifyTransform = function
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
        | :? Transform as t -> stringifyTransform t
        | :? Global as g -> global' g
        | :? None' -> none
        | _ -> "Unknown transform value"

    let private originToString (origin: ITransformOrigin) =
        match origin with
        | :? TransformOrigin as t -> Utilities.Helpers.duToLowercase t
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> global' g
        | _ -> "Unknown transform origin"

    let private styleToString (origin: ITransformStyle) =
        match origin with
        | :? TransformStyle as t -> Utilities.Helpers.duToLowercase t
        | :? Global as g -> global' g
        | _ -> "Unknown transform style"

    let private transformValue value = PropertyValue.cssValue Property.Transform value
    let private transformValue' value =
        value
        |> transformToString
        |> transformValue

    type Transform =
        static member Matrix (n1: float, n2: float, n3: float, n4: float, n5: float, n6: float) =
            Transform.Matrix(n1,n2,n3,n4,n5,n6)
        static member Matrix3D
            (a1: int, b1: int, c1: int, d1: int,
             a2: int, b2: int, c2: int, d2: int,
             a3: int, b3: int, c3: int, d3: int,
             a4: float, b4: float, c4: float, d4: float) =
             Transform.Matrix3D(a1, b1, c1, d1,
                      a2, b2, c2, d2,
                      a3, b3, c3, d3,
                      a4, b4, c4, d4)
        static member Perspective (value: Units.Size.Size) =
            Transform.Perspective value
        static member Rotate (angle: Units.Angle.Angle) =
            Transform.Rotate angle
        static member Rotate3D (n1: float, n2: float, n3: float, angle: Units.Angle.Angle) =
            Transform.Rotate3D(n1,n2,n3,angle)
        static member RotateX (angle: Units.Angle.Angle) =
            Transform.RotateX angle
        static member RotateY (angle: Units.Angle.Angle) =
            Transform.RotateY angle
        static member RotateZ (angle: Units.Angle.Angle) =
            Transform.RotateZ angle
        static member Translate (value: ILengthPercentage) =
            Transform.Translate value
        static member Translate (x: ILengthPercentage, y: ILengthPercentage) =
            Translate2(x,y)
        static member Translate3D (x: ILengthPercentage, y: ILengthPercentage, z: ILengthPercentage) =
            Transform.Translate3D(x,y,z)
        static member TranslateX (x: ILengthPercentage) =
            Transform.TranslateX x
        static member TranslateY (y: ILengthPercentage) =
            Transform.TranslateY y
        static member TranslateZ (z: ILengthPercentage) =
            Transform.TranslateZ z
        static member Scale (value: float) =
            Transform.Scale value
        static member Scale (x: float, y: float) =
            Scale2(x,y)
        static member Scale3D (x: float, y: float, z: float) =
            Transform.Scale3D (x,y,z)
        static member ScaleX (x: float) =
            Transform.ScaleX x
        static member ScaleY (y: float) =
            Transform.ScaleY y
        static member ScaleZ (z: float) =
            Transform.ScaleZ z
        static member Skew (angle: Units.Angle.Angle) =
            Transform.Skew angle
        static member Skew (x: Units.Angle.Angle, y: Units.Angle.Angle) =
            Skew2(x,y)
        static member SkewX (x: Units.Angle.Angle) =
            Transform.SkewX x
        static member SkewY (y: Units.Angle.Angle) =
            Transform.SkewY y

        static member None = None' |> transformValue'
        static member Inherit = Inherit |> transformValue'
        static member Initial = Initial |> transformValue'
        static member Unset = Unset |> transformValue'


    /// Supply a list of transforms to be applied to the element.
    let Transforms (transforms: FssTypes.Transform list): CssProperty =
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

        static member Top = FssTypes.TransformOrigin.Top |> originValue'
        static member Left = FssTypes.TransformOrigin.Left |> originValue'
        static member Right = FssTypes.TransformOrigin.Right |> originValue'
        static member Bottom = FssTypes.TransformOrigin.Bottom |> originValue'
        static member Center = FssTypes.TransformOrigin.Center |> originValue'

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

        static member Flat = FssTypes.TransformStyle.Flat |> styleValue'
        static member Preserve3d = FssTypes.TransformStyle.Preserve3d |> styleValue'

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

