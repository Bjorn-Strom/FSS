namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/transform
[<AutoOpen>]
module Transform =
    let private transformToString (transform: FssTypes.ITransform) =
        let stringifyTransform = function
           | FssTypes.Transform.Matrix (a, b, c, d, e, f) ->
               sprintf "matrix(%.1f, %.1f, %.1f, %.1f, %.1f, %.1f)" a b c d e f
           | FssTypes.Transform.Matrix3D (a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4) ->
               sprintf "matrix3d(%d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %d, %.1f, %.1f, %.1f, %.1f)" a1 b1 c1 d1 a2 b2 c2 d2 a3 b3 c3 d3 a4 b4 c4 d4
           | FssTypes.Transform.Perspective size -> sprintf "perspective(%s)" <| FssTypes.unitHelpers.sizeToString size
           | FssTypes.Transform.Rotate angle -> sprintf "rotate(%s)" <| FssTypes.unitHelpers.angleToString angle
           | FssTypes.Transform.Rotate3D (a, b, c, angle) -> sprintf "rotate3d(%.1f, %.1f, %.1f, %s)" a b c (FssTypes.unitHelpers.angleToString angle)
           | FssTypes.Transform.RotateX angle -> sprintf "rotateX(%s)" <| FssTypes.unitHelpers.angleToString angle
           | FssTypes.Transform.RotateY angle -> sprintf "rotateY(%s)" <| FssTypes.unitHelpers.angleToString angle
           | FssTypes.Transform.RotateZ angle -> sprintf "rotateZ(%s)" <| FssTypes.unitHelpers.angleToString angle
           | FssTypes.Transform.Translate size -> sprintf "translate(%s)" (FssTypes.unitHelpers.lengthPercentageToString size)
           | FssTypes.Transform.Translate2 (sx, sy) -> sprintf "translate(%s, %s)" (FssTypes.unitHelpers.lengthPercentageToString sx) (FssTypes.unitHelpers.lengthPercentageToString sy)
           | FssTypes.Transform.Translate3D (size1, size2, size3) -> sprintf "translate3d(%s, %s, %s)" (FssTypes.unitHelpers.lengthPercentageToString size1) (FssTypes.unitHelpers.lengthPercentageToString size2) (FssTypes.unitHelpers.lengthPercentageToString size3)
           | FssTypes.Transform.TranslateX size -> sprintf "translateX(%s)" <| FssTypes.unitHelpers.lengthPercentageToString size
           | FssTypes.Transform.TranslateY size -> sprintf "translateY(%s)" <| FssTypes.unitHelpers.lengthPercentageToString size
           | FssTypes.Transform.TranslateZ size -> sprintf "translateZ(%s)" <| FssTypes.unitHelpers.lengthPercentageToString size
           | FssTypes.Transform.Scale n -> sprintf "scale(%.2f)" n
           | FssTypes.Transform.Scale2 (sx, sy) -> sprintf "scale(%.2f, %.2f)" sx sy
           | FssTypes.Transform.Scale3D (n1, n2, n3) -> sprintf "scale3d(%.2f, %.2f, %.2f)" n1 n2 n3
           | FssTypes.Transform.ScaleX n -> sprintf "scaleX(%.2f)" n
           | FssTypes.Transform.ScaleY n -> sprintf "scaleY(%.2f)" n
           | FssTypes.Transform.ScaleZ n -> sprintf "scaleZ(%.2f)" n
           | FssTypes.Transform.Skew a -> sprintf "skew(%s)" (FssTypes.unitHelpers.angleToString a)
           | FssTypes.Transform.Skew2 (ax, ay) -> sprintf "skew(%s, %s)" (FssTypes.unitHelpers.angleToString ax) (FssTypes.unitHelpers.angleToString ay)
           | FssTypes.Transform.SkewX a -> sprintf "skewX(%s)" <| FssTypes.unitHelpers.angleToString a
           | FssTypes.Transform.SkewY a -> sprintf "skewY(%s)" <| FssTypes.unitHelpers.angleToString a

        match transform with
        | :? FssTypes.Transform.Transform as t -> stringifyTransform t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown transform value"

    let private originToString (origin: FssTypes.ITransformOrigin) =
        match origin with
        | :? FssTypes.Transform.Origin as t -> Utilities.Helpers.duToLowercase t
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown transform origin"

    let private styleToString (origin: FssTypes.ITransformStyle) =
        match origin with
        | :? FssTypes.Transform.Style as t -> Utilities.Helpers.duToLowercase t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown transform style"

    let private transformValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Transform value
    let private transformValue' value =
        value
        |> transformToString
        |> transformValue

    type Transform =
        static member Matrix (n1: float, n2: float, n3: float, n4: float, n5: float, n6: float) =
            FssTypes.Transform.Matrix(n1,n2,n3,n4,n5,n6)
        static member Matrix3D
            (a1: int, b1: int, c1: int, d1: int,
             a2: int, b2: int, c2: int, d2: int,
             a3: int, b3: int, c3: int, d3: int,
             a4: float, b4: float, c4: float, d4: float) =
             FssTypes.Transform.Matrix3D(a1, b1, c1, d1,
                      a2, b2, c2, d2,
                      a3, b3, c3, d3,
                      a4, b4, c4, d4)
        static member Perspective (value: FssTypes.Size) =
            FssTypes.Transform.Perspective value
        static member Rotate (angle: FssTypes.Angle) =
            FssTypes.Transform.Rotate angle
        static member Rotate3D (n1: float, n2: float, n3: float, angle: FssTypes.Angle) =
            FssTypes.Transform.Rotate3D(n1,n2,n3,angle)
        static member RotateX (angle: FssTypes.Angle) =
            FssTypes.Transform.RotateX angle
        static member RotateY (angle: FssTypes.Angle) =
            FssTypes.Transform.RotateY angle
        static member RotateZ (angle: FssTypes.Angle) =
            FssTypes.Transform.RotateZ angle
        static member Translate (value: FssTypes.ILengthPercentage) =
            FssTypes.Transform.Translate value
        static member Translate (x: FssTypes.ILengthPercentage, y: FssTypes.ILengthPercentage) =
            FssTypes.Transform.Translate2(x,y)
        static member Translate3D (x: FssTypes.ILengthPercentage, y: FssTypes.ILengthPercentage, z: FssTypes.ILengthPercentage) =
            FssTypes.Transform.Translate3D(x,y,z)
        static member TranslateX (x: FssTypes.ILengthPercentage) =
            FssTypes.Transform.TranslateX x
        static member TranslateY (y: FssTypes.ILengthPercentage) =
            FssTypes.Transform.TranslateY y
        static member TranslateZ (z: FssTypes.ILengthPercentage) =
            FssTypes.Transform.TranslateZ z
        static member Scale (value: float) =
            FssTypes.Transform.Scale value
        static member Scale (x: float, y: float) =
            FssTypes.Transform.Scale2(x,y)
        static member Scale3D (x: float, y: float, z: float) =
            FssTypes.Transform.Scale3D (x,y,z)
        static member ScaleX (x: float) =
            FssTypes.Transform.ScaleX x
        static member ScaleY (y: float) =
            FssTypes.Transform.ScaleY y
        static member ScaleZ (z: float) =
            FssTypes.Transform.ScaleZ z
        static member Skew (angle: FssTypes.Angle) =
            FssTypes.Transform.Skew angle
        static member Skew (x: FssTypes.Angle, y: FssTypes.Angle) =
            FssTypes.Transform.Skew2(x,y)
        static member SkewX (x: FssTypes.Angle) =
            FssTypes.Transform.SkewX x
        static member SkewY (y: FssTypes.Angle) =
            FssTypes.Transform.SkewY y

        static member None = FssTypes.None' |> transformValue'
        static member Inherit = FssTypes.Inherit |> transformValue'
        static member Initial = FssTypes.Initial |> transformValue'
        static member Unset = FssTypes.Unset |> transformValue'


    /// Supply a list of transforms to be applied to the element.
    let Transforms (transforms: FssTypes.Transform.Transform list): FssTypes.CssProperty =
        transforms
        |> Utilities.Helpers.combineWs transformToString
        |> transformValue

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-origin
    let private originValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransformOrigin value
    let private originValue' value =
        value
        |> originToString
        |> originValue
    type TransformOrigin =
        static member Value (value: FssTypes.ITransformOrigin) = value |> originValue'
        static member Value (xOffset: FssTypes.ITransformOrigin, yOffset: FssTypes.ITransformOrigin) =
            sprintf "%s %s"
                (originToString xOffset)
                (originToString yOffset)
            |> originValue
        static member Value (xOffset: FssTypes.ITransformOrigin, yOffset: FssTypes.ITransformOrigin, zOffset: FssTypes.ITransformOrigin) =
            sprintf "%s %s %s"
                (originToString xOffset)
                (originToString yOffset)
                (originToString zOffset)
            |> originValue

        static member Top = FssTypes.Transform.Origin.Top |> originValue'
        static member Left = FssTypes.Transform.Origin.Left |> originValue'
        static member Right = FssTypes.Transform.Origin.Right |> originValue'
        static member Bottom = FssTypes.Transform.Origin.Bottom |> originValue'
        static member Center = FssTypes.Transform.Origin.Center |> originValue'

        static member Inherit = FssTypes.Inherit |> originValue'
        static member Initial = FssTypes.Initial |> originValue'
        static member Unset = FssTypes.Unset |> originValue'

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
    let TransformOrigin' (origin: FssTypes.ITransformOrigin) = TransformOrigin.Value(origin)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style
    let private styleValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransformStyle value
    let private styleValue' value =
        value
        |> styleToString
        |> styleValue
    type TransformStyle =
        static member Value (value: FssTypes.ITransformStyle) = value |> styleValue'

        static member Flat = FssTypes.Transform.Style.Flat |> styleValue'
        static member Preserve3d = FssTypes.Transform.Style.Preserve3d |> styleValue'

        static member Inherit = FssTypes.Inherit |> styleValue'
        static member Initial = FssTypes.Initial |> styleValue'
        static member Unset = FssTypes.Unset |> styleValue'

    /// <summary>Specifies the whether children of an element are positioned flat or in 3d.</summary>
    /// <param name="style">
    ///     can be:
    ///     - <c> TransformStyle </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransformStyle' (style: FssTypes.ITransformStyle) = TransformStyle.Value(style)

