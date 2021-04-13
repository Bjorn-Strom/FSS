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

        type Size =
            | Contain
            | Cover
            interface IMaskSize

        type MaskImage (imageValue: string -> CssProperty, imageValue': IMaskImage -> CssProperty) =
            inherit Image.Image(imageValue)
            member this.value (source: IMaskImage) = source |> imageValue'
            member this.none = None' |> imageValue'
            member this.inherit' = Inherit |> imageValue'
            member this.initial = Initial |> imageValue'
            member this.unset = Unset |> imageValue'

