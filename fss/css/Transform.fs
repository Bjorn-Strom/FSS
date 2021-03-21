namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/transform
[<AutoOpen>]
module Transform =
    let private transformToString (transform: Types.ITransform) =
        let stringifyTransform = function
           | Types.Matrix (a, b, c, d, e, f) ->
               sprintf "matrix(%.1f, %.1f, %.1f, %.1f, %.1f, %.1f)" a b c d e f
           | Types.Matrix3D (a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4) ->
               sprintf "matrix3d(%d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %.1f, %.1f, %.1f, %.1f)" a1 b1 c1 d1 a2 b2 c2 d2 a3 b3 c3 d3 a4 b4 c4 d4
           | Types.Perspective size -> sprintf "perspective(%s)" <| Types.sizeToString size
           | Types.Rotate angle -> sprintf "rotate(%s)" <| Types.angleToString angle
           | Types.Rotate3D (a, b, c, angle) -> sprintf "rotate3d(%.1f, %.1f, %.1f, %s)" a b c (Types.angleToString angle)
           | Types.RotateX angle -> sprintf "rotateX(%s)" <| Types.angleToString angle
           | Types.RotateY angle -> sprintf "rotateY(%s)" <| Types.angleToString angle
           | Types.RotateZ angle -> sprintf "rotateZ(%s)" <| Types.angleToString angle
           | Types.Translate size -> sprintf "translate(%s)" (Types.lengthPercentageToString size)
           | Types.Translate2 (sx, sy) -> sprintf "translate(%s, %s)" (Types.lengthPercentageToString sx) (Types.lengthPercentageToString sy)
           | Types.Translate3D (size1, size2, size3) -> sprintf "translate3d(%s, %s, %s)" (Types.lengthPercentageToString size1) (Types.lengthPercentageToString size2) (Types.lengthPercentageToString size3)
           | Types.TranslateX size -> sprintf "translateX(%s)" <| Types.lengthPercentageToString size
           | Types.TranslateY size -> sprintf "translateY(%s)" <| Types.lengthPercentageToString size
           | Types.TranslateZ size -> sprintf "translateZ(%s)" <| Types.lengthPercentageToString size
           | Types.Scale n -> sprintf "scale(%.2f)" n
           | Types.Scale2 (sx, sy) -> sprintf "scale(%.2f, %.2f)" sx sy
           | Types.Scale3D (n1, n2, n3) -> sprintf "scale3d(%.2f, %.2f, %.2f)" n1 n2 n3
           | Types.ScaleX n -> sprintf "scaleX(%.2f)" n
           | Types.ScaleY n -> sprintf "scaleY(%.2f)" n
           | Types.ScaleZ n -> sprintf "scaleZ(%.2f)" n
           | Types.Skew a -> sprintf "skew(%s)" (Types.angleToString a)
           | Types.Skew2 (ax, ay) -> sprintf "skew(%s, %s)" (Types.angleToString ax) (Types.angleToString ay)
           | Types.SkewX a -> sprintf "skewX(%s)" <| Types.angleToString a
           | Types.SkewY a -> sprintf "skewY(%s)" <| Types.angleToString a

        match transform with
        | :? Types.Transform as t -> stringifyTransform t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown transform value"

    let private originToString (origin: Types.ITransformOrigin) =
        match origin with
        | :? Types.TransformOrigin as t -> Utilities.Helpers.duToLowercase t
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown transform origin"

    let private styleToString (origin: Types.ITransformStyle) =
        match origin with
        | :? Types.TransformStyle as t -> Utilities.Helpers.duToLowercase t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown transform style"

    let private transformValue value = Types.cssValue Types.Property.Transform value
    let private transformValue' value =
        value
        |> transformToString
        |> transformValue

    type Transform =
        static member Matrix (n1: float, n2: float, n3: float, n4: float, n5: float, n6: float) =
            Types.Matrix(n1,n2,n3,n4,n5,n6)
        static member Matrix3D
            (a1: int, b1: int, c1: int, d1: int,
             a2: int, b2: int, c2: int, d2: int,
             a3: int, b3: int, c3: int, d3: int,
             a4: float, b4: float, c4: float, d4: float) =
             Types.Matrix3D(a1, b1, c1, d1,
                      a2, b2, c2, d2,
                      a3, b3, c3, d3,
                      a4, b4, c4, d4)
        static member Perspective (value: Types.Size) =
            Types.Perspective value
        static member Rotate (angle: Types.Angle) =
            Types.Rotate angle
        static member Rotate3D (n1: float, n2: float, n3: float, angle: Types.Angle) =
            Types.Rotate3D(n1,n2,n3,angle)
        static member RotateX (angle: Types.Angle) =
            Types.RotateX angle
        static member RotateY (angle: Types.Angle) =
            Types.RotateY angle
        static member RotateZ (angle: Types.Angle) =
            Types.RotateZ angle
        static member Translate (value: Types.ILengthPercentage) =
            Types.Translate value
        static member Translate (x: Types.ILengthPercentage, y: Types.ILengthPercentage) =
            Types.Translate2(x,y)
        static member Translate3D (x: Types.ILengthPercentage, y: Types.ILengthPercentage, z: Types.ILengthPercentage) =
            Types.Translate3D(x,y,z)
        static member TranslateX (x: Types.ILengthPercentage) =
            Types.TranslateX x
        static member TranslateY (y: Types.ILengthPercentage) =
            Types.TranslateY y
        static member TranslateZ (z: Types.ILengthPercentage) =
            Types.TranslateZ z
        static member Scale (value: float) =
            Types.Scale value
        static member Scale (x: float, y: float) =
            Types.Scale2(x,y)
        static member Scale3D (x: float, y: float, z: float) =
            Types.Scale3D (x,y,z)
        static member ScaleX (x: float) =
            Types.ScaleX x
        static member ScaleY (y: float) =
            Types.ScaleY y
        static member ScaleZ (z: float) =
            Types.ScaleZ z
        static member Skew (angle: Types.Angle) =
            Types.Skew angle
        static member Skew (x: Types.Angle, y: Types.Angle) =
            Types.Skew2(x,y)
        static member SkewX (x: Types.Angle) =
            Types.SkewX x
        static member SkewY (y: Types.Angle) =
            Types.SkewY y

        static member None = Types.None' |> transformValue'
        static member Inherit = Types.Inherit |> transformValue'
        static member Initial = Types.Initial |> transformValue'
        static member Unset = Types.Unset |> transformValue'


    /// Supply a list of transforms to be applied to the element.
    let Transforms (transforms: Types.Transform list): Types.CssProperty =
        transforms
        |> Utilities.Helpers.combineWs transformToString
        |> transformValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-origin
    let private originValue value = Types.cssValue Types.Property.TransformOrigin value
    let private originValue' value =
        value
        |> originToString
        |> originValue
    type TransformOrigin =
        static member Value (value: Types.ITransformOrigin) = value |> originValue'
        static member Value (xOffset: Types.ITransformOrigin, yOffset: Types.ITransformOrigin) =
            sprintf "%s %s"
                (originToString xOffset)
                (originToString yOffset)
            |> originValue
        static member Value (xOffset: Types.ITransformOrigin, yOffset: Types.ITransformOrigin, zOffset: Types.ITransformOrigin) =
            sprintf "%s %s %s"
                (originToString xOffset)
                (originToString yOffset)
                (originToString zOffset)
            |> originValue

        static member Top = Types.TransformOrigin.Top |> originValue'
        static member Left = Types.TransformOrigin.Left |> originValue'
        static member Right = Types.TransformOrigin.Right |> originValue'
        static member Bottom = Types.TransformOrigin.Bottom |> originValue'
        static member Center = Types.TransformOrigin.Center |> originValue'

        static member Inherit = Types.Inherit |> originValue'
        static member Initial = Types.Initial |> originValue'
        static member Unset = Types.Unset |> originValue'

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
    let TransformOrigin' (origin: Types.ITransformOrigin) = TransformOrigin.Value(origin)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style
    let private styleValue value = Types.cssValue Types.Property.TransformStyle value
    let private styleValue' value =
        value
        |> styleToString
        |> styleValue
    type TransformStyle =
        static member Value (value: Types.ITransformStyle) = value |> styleValue'

        static member Flat = Types.TransformStyle.Flat |> styleValue'
        static member Preserve3d = Types.TransformStyle.Preserve3d |> styleValue'

        static member Inherit = Types.Inherit |> styleValue'
        static member Initial = Types.Initial |> styleValue'
        static member Unset = Types.Unset |> styleValue'

    /// <summary>Specifies the whether children of an element are positioned flat or in 3d.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> TransformStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransformStyle' (style: Types.ITransformStyle) = TransformStyle.Value(style)

