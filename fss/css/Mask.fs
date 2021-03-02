namespace Fss

[<RequireQualifiedAccess>]
module MaskTypes =
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

[<AutoOpen>]
module Mask =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
    let private stringifyClip (clip: IMaskClip) =
        match clip with
        | :? MaskTypes.MaskClip as m -> Utilities.Helpers.duToKebab m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask-clip"

    let private maskClipValue value = PropertyValue.cssValue Property.MaskClip value
    let private maskClipValue' value =
        value
        |> stringifyClip
        |> maskClipValue

    type MaskClip =
        static member Value (clip: IMaskClip) = clip |> maskClipValue'
        static member Value (clips: MaskTypes.MaskClip list) =
            clips
            |> Utilities.Helpers.combineComma stringifyClip
            |> maskClipValue
        static member ContentBox = MaskTypes.ContentBox |> maskClipValue'
        static member PaddingBox = MaskTypes.PaddingBox |> maskClipValue'
        static member BorderBox = MaskTypes.BorderBox |> maskClipValue'
        static member MarginBox = MaskTypes.MarginBox |> maskClipValue'
        static member FillBox = MaskTypes.FillBox |> maskClipValue'
        static member StrokeBox = MaskTypes.StrokeBox |> maskClipValue'
        static member ViewBox = MaskTypes.ViewBox |> maskClipValue'
        static member NoClip = MaskTypes.NoClip |> maskClipValue'
        static member Border = MaskTypes.Border |> maskClipValue'
        static member Padding = MaskTypes.Padding |> maskClipValue'
        static member Content = MaskTypes.Content |> maskClipValue'
        static member Text = MaskTypes.Text |> maskClipValue'
        static member Inherit = Inherit |> maskClipValue'
        static member Initial = Initial |> maskClipValue'
        static member Unset = Unset |> maskClipValue'

    /// <summary>Specifies which area is affected by a mask.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskClip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private MaskClip' (clip: IMaskClip) = clip |> MaskClip.Value
