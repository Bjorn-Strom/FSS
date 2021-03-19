namespace FssTypes

[<RequireQualifiedAccess>]
module Transform =
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

