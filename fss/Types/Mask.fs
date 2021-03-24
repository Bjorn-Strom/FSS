namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Mask =
        type Clip =
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

        type Composite =
            | Add
            | Subtract
            | Intersect
            | Exclude
            interface IMaskComposite

        type Mode =
            | Alpha
            | Luminance
            | MatchSource
            interface IMaskMode

        type Origin =
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

        type Repeat =
            | RepeatX
            | RepeatY
            | Repeat
            | Space
            | Round
            | NoRepeat
            interface IMaskRepeat

