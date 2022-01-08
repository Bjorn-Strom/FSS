namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Transform =
    type Transform =
        | Matrix of float * float * float * float * float * float
        | Matrix3D of
            int *
            int *
            int *
            int *
            int *
            int *
            int *
            int *
            int *
            int *
            int *
            int *
            float *
            float *
            float *
            float
        | Perspective of Length
        | Rotate of Angle
        | Rotate3D of float * float * float * Angle
        | RotateX of Angle
        | RotateY of Angle
        | RotateZ of Angle
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
        | Skew of Angle
        | Skew2 of Angle * Angle
        | SkewX of Angle
        | SkewY of Angle
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Matrix (a, b, c, d, e, f) -> $"matrix({a}, {b}, {c}, {d}, {e}, {f})"
                | Matrix3D (a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4) ->
                    $"matrix3d({a1}, {b1}, {c1}, {d1}, {a2}, {b2}, {c2}, {d2}, {a3}, {b3}, {c3}, {d3}, {a4}, {b4}, {c4}, {d4})"
                | Perspective size -> $"perspective({stringifyICssValue size})"
                | Rotate angle -> $"rotate({stringifyICssValue angle})"
                | Rotate3D (a, b, c, angle) -> $"rotate3d({a}, {b}, {c}, {stringifyICssValue angle})"
                | RotateX angle -> $"rotateX({stringifyICssValue angle})"
                | RotateY angle -> $"rotateY({stringifyICssValue angle})"
                | RotateZ angle -> $"rotateZ({stringifyICssValue angle})"
                | Translate size -> $"translate({lengthPercentageString size})"
                | Translate2 (sx, sy) -> $"translate({lengthPercentageString sx}, {lengthPercentageString sy})"
                | Translate3D (size1, size2, size3) ->
                    $"translate3d({lengthPercentageString size1}, {lengthPercentageString size2}, {lengthPercentageString size3})"
                | TranslateX size -> $"translateX({lengthPercentageString size})"
                | TranslateY size -> $"translateY({lengthPercentageString size})"
                | TranslateZ size -> $"translateZ({lengthPercentageString size})"
                | Scale n -> $"scale({n})"
                | Scale2 (sx, sy) -> $"scale({sx}, {sy})"
                | Scale3D (n1, n2, n3) -> $"scale3d({n1}, {n2}, {n3})"
                | ScaleX n -> $"scaleX({n})"
                | ScaleY n -> $"scaleY({n})"
                | ScaleZ n -> $"scaleZ({n})"
                | Skew a -> $"skew({stringifyICssValue a})"
                | Skew2 (ax, ay) -> $"skew({stringifyICssValue ax}, {stringifyICssValue ay})"
                | SkewX a -> $"skewX({stringifyICssValue a})"
                | SkewY a -> $"skewY({stringifyICssValue a})"

    type Origin =
        | Top
        | Left
        | Right
        | Bottom
        | Center
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Style =
        | Flat
        | Preserve3d
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

[<RequireQualifiedAccess>]
module TransformClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform
    type TransformClass(property) =
        inherit CssRuleWithNone(property)

        member this.value(transforms: Transform.Transform list) =
            let transforms =
                transforms
                |> List.map stringifyICssValue
                |> String.concat " "
            (property, String transforms) |> Rule

        member this.matrix(a: float, b: float, c: float, d: float, tx: float, ty: float) =
            Transform.Matrix(a, b, c, d, tx, ty)

        member this.matrix3D
            (
                a1: int,
                b1: int,
                c1: int,
                d1: int,
                a2: int,
                b2: int,
                c2: int,
                d2: int,
                a3: int,
                b3: int,
                c3: int,
                d3: int,
                a4: float,
                b4: float,
                c4: float,
                d4: float
            ) =
            Transform.Matrix3D(a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4)

        member this.perspective(length: Length) = Transform.Perspective(length)
        member this.rotate(angle: Angle) = Transform.Rotate(angle)
        member this.rotate3D(x: float, y: float, z: float, a: Angle) = Transform.Rotate3D(x, y, z, a)
        member this.rotateX(angle: Angle) = Transform.RotateX(angle)
        member this.rotateY(angle: Angle) = Transform.RotateY(angle)
        member this.rotateZ(angle: Angle) = Transform.RotateZ(angle)
        member this.translate(length: ILengthPercentage) = Transform.Translate(length)
        member this.translate(a: ILengthPercentage, b: ILengthPercentage) = Transform.Translate2(a, b)

        member this.translate3D(a: ILengthPercentage, b: ILengthPercentage, c: ILengthPercentage) =
            Transform.Translate3D(a, b, c)

        member this.translateX(length: ILengthPercentage) = Transform.TranslateX(length)
        member this.translateY(length: ILengthPercentage) = Transform.TranslateY(length)
        member this.translateZ(length: ILengthPercentage) = Transform.TranslateZ(length)
        member this.scale(scale: float) = Transform.Scale(scale)
        member this.scale(a: float, b: float) = Transform.Scale2(a, b)
        member this.scale3D(a: float, b: float, c: float) = Transform.Scale3D(a, b, c)
        member this.scaleX(scale: float) = Transform.ScaleX(scale)
        member this.scaleY(scale: float) = Transform.ScaleY(scale)
        member this.scaleZ(scale: float) = Transform.ScaleZ(scale)
        member this.skew(angle: Angle) = Transform.Skew(angle)
        member this.skew(a: Angle, b: Angle) = Transform.Skew2(a, b)
        member this.skewX(angle: Angle) = Transform.SkewX(angle)
        member this.skewY(angle: Angle) = Transform.SkewY(angle)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-origin
    type TransformOrigin(property) =
        inherit CssRuleWithLength(property)

        member this.value(x: ILengthPercentage, y: ILengthPercentage) =
            let value =
                $"{lengthPercentageString x} {lengthPercentageString y}"
                |> String

            (property, value) |> Rule

        member this.value(x: ILengthPercentage, y: ILengthPercentage, z: ILengthPercentage) =
            let value =
                $"{lengthPercentageString x} {lengthPercentageString y} {lengthPercentageString z}"
                |> String

            (property, value) |> Rule

        member this.top = (property, Transform.Top) |> Rule
        member this.left = (property, Transform.Left) |> Rule
        member this.right = (property, Transform.Right) |> Rule
        member this.bottom = (property, Transform.Bottom) |> Rule
        member this.center = (property, Transform.Center) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style
    type TransformStyle(property) =
        inherit CssRule(property)
        member this.flat = (property, Transform.Flat) |> Rule
        member this.preserve3d = (property, Transform.Preserve3d) |> Rule
