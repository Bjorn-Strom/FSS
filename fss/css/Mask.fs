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

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-composite
    let private stringifyComposite (composite: IMaskComposite) =
        match composite with
        | :? MaskTypes.MaskComposite as m -> Utilities.Helpers.duToLowercase m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask-composite"

    let private maskCompositeValue value = PropertyValue.cssValue Property.MaskComposite value
    let private maskCompositeValue' value =
        value
        |> stringifyComposite
        |> maskCompositeValue

    type MaskComposite =
        static member Value (clip: IMaskComposite) = clip |> maskCompositeValue'
        static member Value (clips: MaskTypes.MaskComposite list) =
            clips
            |> Utilities.Helpers.combineComma stringifyComposite
            |> maskCompositeValue
        static member Add = MaskTypes.Add |> maskCompositeValue'
        static member Subtract = MaskTypes.Subtract |> maskCompositeValue'
        static member Intersect = MaskTypes.Intersect |> maskCompositeValue'
        static member Exclude = MaskTypes.Exclude |> maskCompositeValue'
        static member Inherit = Inherit |> maskCompositeValue'
        static member Initial = Initial |> maskCompositeValue'
        static member Unset = Unset |> maskCompositeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskComposite </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private MaskComposite' (clip: IMaskComposite) = clip |> MaskComposite.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-image
    let private imageSourceToString (imageSource: IMaskImage) =
        match imageSource with
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask image"

    let private imageValue value = PropertyValue.cssValue Property.MaskImage value
    let private imageValue' value =
        value
        |> imageSourceToString
        |> imageValue

    type MaskImage =
        static member Value (source: IMaskImage) = source |> imageValue'
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        static member LinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            imageValue <| Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            imageValue <| Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            imageValue <| Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            imageValue <| Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Shape, size: Side, xPosition: Units.Percent.Percent, yPosition: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Shape, size: Side, xPosition: Units.Percent.Percent, yPosition: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) list) =
            imageValue <| Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) list) =
            imageValue <| Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member None = None' |> imageValue'
        static member Inherit = Inherit |> imageValue'
        static member Initial = Initial |> imageValue'
        static member Unset = Unset |> imageValue'

    /// <summary>Specifies width of border image.</summary>
    /// <param name="source">
    ///     can be:
    ///     - <c> Image </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskImage' (source: IMaskImage) = MaskImage.Value(source)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-mode
    let private stringifyMode (composite: IMaskMode) =
        match composite with
        | :? MaskTypes.MaskMode as m -> Utilities.Helpers.duToKebab m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask mode"

    let private maskModeValue value = PropertyValue.cssValue Property.MaskMode value
    let private maskModeValue' value =
        value
        |> stringifyMode
        |> maskModeValue

    type MaskMode =
        static member Value (mode: IMaskMode) = mode |> maskModeValue'
        static member Value (modes: MaskTypes.MaskMode list) =
            modes
            |> Utilities.Helpers.combineComma stringifyMode
            |> maskModeValue
        static member Alpha = MaskTypes.Alpha |> maskModeValue'
        static member Luminance = MaskTypes.Luminance |> maskModeValue'
        static member MatchSource = MaskTypes.MatchSource |> maskModeValue'
        static member Inherit = Inherit |> maskModeValue'
        static member Initial = Initial |> maskModeValue'
        static member Unset = Unset |> maskModeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private MaskMode' (mode: IMaskMode) = mode |> MaskMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-origin
    let private stringifyOrigin (composite: IMaskOrigin) =
        match composite with
        | :? MaskTypes.MaskOrigin as m -> Utilities.Helpers.duToKebab m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask mode"

    let private maskOriginValue value = PropertyValue.cssValue Property.MaskOrigin value
    let private maskOriginValue' value =
        value
        |> stringifyOrigin
        |> maskOriginValue

    type MaskOrigin =
        static member Value (origin: IMaskOrigin) = origin |> maskOriginValue'
        static member Value (origins: MaskTypes.MaskOrigin list) =
            origins
            |> Utilities.Helpers.combineComma stringifyOrigin
            |> maskOriginValue
        static member ContentBox = MaskTypes.MaskOrigin.ContentBox |> maskOriginValue'
        static member PaddingBox = MaskTypes.MaskOrigin.PaddingBox |> maskOriginValue'
        static member BorderBox = MaskTypes.MaskOrigin.BorderBox |> maskOriginValue'
        static member MarginBox = MaskTypes.MaskOrigin.MarginBox |> maskOriginValue'
        static member FillBox = MaskTypes.MaskOrigin.FillBox |> maskOriginValue'
        static member StrokeBox = MaskTypes.MaskOrigin.StrokeBox |> maskOriginValue'
        static member ViewBox = MaskTypes.MaskOrigin.ViewBox |> maskOriginValue'
        static member Content = MaskTypes.MaskOrigin.Content |> maskOriginValue'
        static member Padding = MaskTypes.MaskOrigin.Padding |> maskOriginValue'
        static member Border = MaskTypes.MaskOrigin.Border |> maskOriginValue'

        static member Inherit = Inherit |> maskOriginValue'
        static member Initial = Initial |> maskOriginValue'
        static member Unset = Unset |> maskOriginValue'

    /// <summary>Specifies origin of masks.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskOrigin </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let private MaskOrigin' (mode: IMaskOrigin) = mode |> MaskOrigin.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-position
    let private stringifyPosition (composite: IMaskPosition) =
        match composite with
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask position"

    let private maskPositionValue value = PropertyValue.cssValue Property.MaskPosition value
    let private maskPositionValue' value =
        value
        |> stringifyPosition
        |> maskPositionValue

    let private stringifyPixelPositions ps =
        let (x, y) = ps
        $"{Units.Size.value x} {Units.Size.value y}"

    let private stringifyPercentPositions ps =
        let (x, y) = ps
        $"{Units.Percent.value x} {Units.Percent.value y}"

    type MaskPosition =
        static member Value (x: Units.Size.Size, y: Units.Size.Size) =
            stringifyPixelPositions(x,y)
            |> maskPositionValue
        static member Value (positions: (Units.Size.Size * Units.Size.Size) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPixelPositions
            |> maskPositionValue
        static member Value (x: Units.Percent.Percent, y: Units.Percent.Percent) =
            stringifyPercentPositions(x,y)
            |> maskPositionValue
        static member Value (positions: (Units.Percent.Percent * Units.Percent.Percent) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPercentPositions
            |> maskPositionValue
        static member Inherit = Inherit |> maskPositionValue'
        static member Initial = Initial |> maskPositionValue'
        static member Unset = Unset |> maskPositionValue'