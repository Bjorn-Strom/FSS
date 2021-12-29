namespace Fss

namespace Fss.FssTypes

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
            member this.Stringify() =
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
            member this.Stringify() = this.ToString().ToLower()

    type Style =
        | Flat
        | Preserve3d
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    [<RequireQualifiedAccess>]
    module TransformClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/transform
        type TransformClass(property) =
            inherit CssRuleWithNone(property)

            member this.value(transforms: Transform list) =
                let transforms =
                    transforms
                    |> List.map stringifyICssValue
                    |> String.concat " "
                (property, String transforms) |> Rule

            member this.matrix(a: float, b: float, c: float, d: float, tx: float, ty: float) =
                Matrix(a, b, c, d, tx, ty)

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
                Matrix3D(a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4)

            member this.perspective(length: Length) = Perspective(length)
            member this.rotate(angle: Angle) = Rotate(angle)
            member this.rotate3D(x: float, y: float, z: float, a: Angle) = Rotate3D(x, y, z, a)
            member this.rotateX(angle: Angle) = RotateX(angle)
            member this.rotateY(angle: Angle) = RotateY(angle)
            member this.rotateZ(angle: Angle) = RotateZ(angle)
            member this.translate(length: ILengthPercentage) = Translate(length)
            member this.translate(a: ILengthPercentage, b: ILengthPercentage) = Translate2(a, b)

            member this.translate3D(a: ILengthPercentage, b: ILengthPercentage, c: ILengthPercentage) =
                Translate3D(a, b, c)

            member this.translateX(length: ILengthPercentage) = TranslateX(length)
            member this.translateY(length: ILengthPercentage) = TranslateY(length)
            member this.translateZ(length: ILengthPercentage) = TranslateZ(length)
            member this.scale(scale: float) = Scale(scale)
            member this.scale(a: float, b: float) = Scale2(a, b)
            member this.scale3D(a: float, b: float, c: float) = Scale3D(a, b, c)
            member this.scaleX(scale: float) = ScaleX(scale)
            member this.scaleY(scale: float) = ScaleY(scale)
            member this.scaleZ(scale: float) = ScaleZ(scale)
            member this.skew(angle: Angle) = Skew(angle)
            member this.skew(a: Angle, b: Angle) = Skew2(a, b)
            member this.skewX(angle: Angle) = SkewX(angle)
            member this.skewY(angle: Angle) = SkewY(angle)

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

            member this.top = (property, Top) |> Rule
            member this.left = (property, Left) |> Rule
            member this.right = (property, Right) |> Rule
            member this.bottom = (property, Bottom) |> Rule
            member this.center = (property, Center) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style
        type TransformStyle(property) =
            inherit CssRule(property)
            member this.flat = (property, Flat) |> Rule
            member this.preserve3d = (property, Preserve3d) |> Rule
