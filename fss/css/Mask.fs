namespace Fss

open FssTypes

[<AutoOpen>]
module Mask =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
    let private stringifyClip (clip: IMaskClip) =
        match clip with
        | :? Mask.MaskClip as m -> Utilities.Helpers.duToKebab m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask-clip"

    let private maskClipValue value = PropertyValue.cssValue Property.MaskClip value
    let private maskClipValue' value =
        value
        |> stringifyClip
        |> maskClipValue

    type MaskClip =
        static member Value (clip: IMaskClip) = clip |> maskClipValue'
        static member Value (clips: Mask.MaskClip list) =
            clips
            |> Utilities.Helpers.combineComma stringifyClip
            |> maskClipValue
        static member ContentBox = Mask.ContentBox |> maskClipValue'
        static member PaddingBox = Mask.PaddingBox |> maskClipValue'
        static member BorderBox = Mask.BorderBox |> maskClipValue'
        static member MarginBox = Mask.MarginBox |> maskClipValue'
        static member FillBox = Mask.FillBox |> maskClipValue'
        static member StrokeBox = Mask.StrokeBox |> maskClipValue'
        static member ViewBox = Mask.ViewBox |> maskClipValue'
        static member NoClip = Mask.NoClip |> maskClipValue'
        static member Border = Mask.Border |> maskClipValue'
        static member Padding = Mask.Padding |> maskClipValue'
        static member Content = Mask.Content |> maskClipValue'
        static member Text = Mask.Text |> maskClipValue'
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
    let MaskClip' (clip: IMaskClip) = clip |> MaskClip.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-composite
    let private stringifyComposite (composite: IMaskComposite) =
        match composite with
        | :? Mask.MaskComposite as m -> Utilities.Helpers.duToLowercase m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask-composite"

    let private maskCompositeValue value = PropertyValue.cssValue Property.MaskComposite value
    let private maskCompositeValue' value =
        value
        |> stringifyComposite
        |> maskCompositeValue

    type MaskComposite =
        static member Value (clip: IMaskComposite) = clip |> maskCompositeValue'
        static member Value (clips: Mask.MaskComposite list) =
            clips
            |> Utilities.Helpers.combineComma stringifyComposite
            |> maskCompositeValue
        static member Add = Mask.Add |> maskCompositeValue'
        static member Subtract = Mask.Subtract |> maskCompositeValue'
        static member Intersect = Mask.Intersect |> maskCompositeValue'
        static member Exclude = Mask.Exclude |> maskCompositeValue'
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
    let MaskComposite' (clip: IMaskComposite) = clip |> MaskComposite.Value

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
        | :? Mask.MaskMode as m -> Utilities.Helpers.duToKebab m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask mode"

    let private maskModeValue value = PropertyValue.cssValue Property.MaskMode value
    let private maskModeValue' value =
        value
        |> stringifyMode
        |> maskModeValue

    type MaskMode =
        static member Value (mode: IMaskMode) = mode |> maskModeValue'
        static member Value (modes: Mask.MaskMode list) =
            modes
            |> Utilities.Helpers.combineComma stringifyMode
            |> maskModeValue
        static member Alpha = Mask.Alpha |> maskModeValue'
        static member Luminance = Mask.Luminance |> maskModeValue'
        static member MatchSource = Mask.MatchSource |> maskModeValue'
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
    let MaskMode' (mode: IMaskMode) = mode |> MaskMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-origin
    let private stringifyOrigin (composite: IMaskOrigin) =
        match composite with
        | :? Mask.MaskOrigin as m -> Utilities.Helpers.duToKebab m
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask mode"

    let private maskOriginValue value = PropertyValue.cssValue Property.MaskOrigin value
    let maskOriginValue' value =
        value
        |> stringifyOrigin
        |> maskOriginValue

    type MaskOrigin =
        static member Value (origin: IMaskOrigin) = origin |> maskOriginValue'
        static member Value (origins: Mask.MaskOrigin list) =
            origins
            |> Utilities.Helpers.combineComma stringifyOrigin
            |> maskOriginValue
        static member ContentBox = Mask.MaskOrigin.ContentBox |> maskOriginValue'
        static member PaddingBox = Mask.MaskOrigin.PaddingBox |> maskOriginValue'
        static member BorderBox = Mask.MaskOrigin.BorderBox |> maskOriginValue'
        static member MarginBox = Mask.MaskOrigin.MarginBox |> maskOriginValue'
        static member FillBox = Mask.MaskOrigin.FillBox |> maskOriginValue'
        static member StrokeBox = Mask.MaskOrigin.StrokeBox |> maskOriginValue'
        static member ViewBox = Mask.MaskOrigin.ViewBox |> maskOriginValue'
        static member Content = Mask.MaskOrigin.Content |> maskOriginValue'
        static member Padding = Mask.MaskOrigin.Padding |> maskOriginValue'
        static member Border = Mask.MaskOrigin.Border |> maskOriginValue'

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
    let MaskOrigin' (mode: IMaskOrigin) = mode |> MaskOrigin.Value

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

    /// <summary>Specifies position of masks.</summary>
    /// <param name="x">
    ///     can be:
    ///     - <c> x: Size  </c>
    /// </param>
    /// <param name="y">
    ///     can be:
    ///     - <c> x: Size  </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskPosition' (x: Units.Size.Size) (y: Units.Size.Size) = MaskPosition.Value(x,y)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-repeat
    let private stringifyRepeat (composite: IMaskRepeat) =
        match composite with
        | :? Mask.MaskRepeat as r -> Utilities.Helpers.duToKebab r
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown mask repeat"

    let private maskRepeatValue value = PropertyValue.cssValue Property.MaskRepeat value
    let private maskRepeatValue' value =
        value
        |> stringifyRepeat
        |> maskRepeatValue

    let private repeatValue (x: Mask.MaskRepeat, y: Mask.MaskRepeat) =
        $"{stringifyRepeat x} {stringifyRepeat y}"

    type MaskRepeat =
        static member Value (repeat: IMaskRepeat) =
            repeat
            |> maskRepeatValue'
        static member Value (repeatX: IMaskRepeat, repeatY: IMaskRepeat) =
            $"{stringifyRepeat repeatX} {stringifyRepeat repeatY}"
            |> maskRepeatValue
        static member Value(repeats: (Mask.MaskRepeat * Mask.MaskRepeat) list) =
            repeats
            |> Utilities.Helpers.combineComma repeatValue
            |> maskRepeatValue
        static member RepeatX = Mask.RepeatX |> maskRepeatValue'
        static member RepeatY = Mask.RepeatY |> maskRepeatValue'
        static member Repeat = Mask.Repeat |> maskRepeatValue'
        static member Space = Mask.Space |> maskRepeatValue'
        static member Round = Mask.Round |> maskRepeatValue'
        static member NoRepeat = Mask.NoRepeat |> maskRepeatValue'
        static member Inherit = Inherit |> maskRepeatValue'
        static member Initial = Initial |> maskRepeatValue'
        static member Unset = Unset |> maskRepeatValue'

    /// <summary>Specifies how masks are repeated.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> MaskRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskRepeat' (repeat: IMaskRepeat) = repeat |> MaskRepeat.Value