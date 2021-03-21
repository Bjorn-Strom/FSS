namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type MaskClip =
        | ContentBox
        | PaddingBox
        | BorderBox
        | MarginBox
        | FillBox
        | StrokeBox
        | ViewBox
        | NoClip
        | Border
        | Padding
        | Content
        | Text
        interface Types.IMaskClip

    type MaskComposite =
        | Add
        | Subtract
        | Intersect
        | Exclude
        interface Types.IMaskComposite

    type MaskMode =
        | Alpha
        | Luminance
        | MatchSource
        interface Types.IMaskMode

    type MaskOrigin =
        | ContentBox
        | PaddingBox
        | BorderBox
        | MarginBox
        | FillBox
        | StrokeBox
        | ViewBox
        | Content
        | Padding
        | Border
        interface Types.IMaskOrigin

    type MaskRepeat =
        | RepeatX
        | RepeatY
        | Repeat'
        | Space
        | Round
        | NoRepeat
        interface Types.IMaskRepeat

