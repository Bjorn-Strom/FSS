namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
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
            interface ITransform

        type Origin =
            | Top
            | Left
            | Right
            | Bottom
            | Center
            interface ITransformOrigin

        type Style =
            | Flat
            | Preserve3d
            interface ITransformStyle

