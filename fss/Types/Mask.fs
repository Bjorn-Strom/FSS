namespace FssTypes

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
    interface IMaskClip

type MaskComposite =
    | Add
    | Subtract
    | Intersect
    | Exclude
    interface IMaskComposite

type MaskMode =
    | Alpha
    | Luminance
    | MatchSource
    interface IMaskMode

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
    interface IMaskOrigin

type MaskRepeat =
    | RepeatX
    | RepeatY
    | Repeat
    | Space
    | Round
    | NoRepeat
    interface IMaskRepeat

