namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Transform =
        | Matrix of float * float * float * float * float * float
        | Matrix3D of int * int * int * int * int * int * int * int * int * int * int * int * float * float * float * float
        | Perspective of Types.Size
        | Rotate of Types.Angle
        | Rotate3D of float * float * float * Types.Angle
        | RotateX of Types.Angle
        | RotateY of Types.Angle
        | RotateZ of Types.Angle
        | Translate of Types.ILengthPercentage
        | Translate2 of Types.ILengthPercentage * Types.ILengthPercentage
        | Translate3D of Types.ILengthPercentage * Types.ILengthPercentage * Types.ILengthPercentage
        | TranslateX of Types.ILengthPercentage
        | TranslateY of Types.ILengthPercentage
        | TranslateZ of Types.ILengthPercentage
        | Scale of float
        | Scale2 of float * float
        | Scale3D of float * float * float
        | ScaleX of float
        | ScaleY of float
        | ScaleZ of float
        | Skew of Types.Angle
        | Skew2 of Types.Angle * Types.Angle
        | SkewX of Types.Angle
        | SkewY of Types.Angle
        interface Types.ITransform

    type TransformOrigin =
        | Top
        | Left
        | Right
        | Bottom
        | Center
        interface Types.ITransformOrigin

    type TransformStyle =
        | Flat
        | Preserve3d
        interface Types.ITransformStyle

