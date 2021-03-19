namespace FssTypes

[<RequireQualifiedAccess>]
module ClipPath =
    type Geometry =
        | MarginBox
        | BorderBox
        | PaddingBox
        | ContentBox
        | FillBox
        | StrokeBox
        | ViewBox
        interface IClipPath

    type Inset =
        | All of ILengthPercentage
        | HorizontalVertical of ILengthPercentage * ILengthPercentage
        | TopHorizontalBottom of ILengthPercentage * ILengthPercentage * ILengthPercentage
        | TopRightBottomLeft of ILengthPercentage * ILengthPercentage * ILengthPercentage * ILengthPercentage
        interface IClipPath
    type Round =
        | Round of Inset * ILengthPercentage list
        interface IClipPath

    type Point = Units.Percent.Percent * Units.Percent.Percent
    type Polygon =
        | Polygon of Point list
        interface IClipPath

    type Url = Url of string
    type Path = Path of string
