namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Geometry =
        | MarginBox
        | BorderBox
        | PaddingBox
        | ContentBox
        | FillBox
        | StrokeBox
        | ViewBox
        interface Types.IClipPath

    type Inset =
        | All of Types.ILengthPercentage
        | HorizontalVertical of Types.ILengthPercentage * Types.ILengthPercentage
        | TopHorizontalBottom of Types.ILengthPercentage * Types.ILengthPercentage * Types.ILengthPercentage
        | TopRightBottomLeft of Types.ILengthPercentage * Types.ILengthPercentage * Types.ILengthPercentage * Types.ILengthPercentage
        interface Types.IClipPath
    type Round =
        | Round of Inset * Types.ILengthPercentage list
        interface Types.IClipPath

    type Point = Types.Percent * Types.Percent
    type Polygon =
        | Polygon of Point list
        interface Types.IClipPath

    type Url = Url of string
    type Path = Path of string
