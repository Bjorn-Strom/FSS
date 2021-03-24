namespace Fss

[<AutoOpen>]
module Mask =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
    let private stringifyClip (clip: FssTypes.IMaskClip) =
        match clip with
        | :? FssTypes.Mask.Clip as m -> Utilities.Helpers.duToKebab m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask-clip"

    let private maskClipValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskClip value
    let private maskClipValue' value =
        value
        |> stringifyClip
        |> maskClipValue

    type MaskClip =
        static member Value (clip: FssTypes.IMaskClip) = clip |> maskClipValue'
        static member Value (clips: FssTypes.Mask.Clip list) =
            clips
            |> Utilities.Helpers.combineComma stringifyClip
            |> maskClipValue
        static member ContentBox = FssTypes.Mask.Clip.ContentBox |> maskClipValue'
        static member PaddingBox = FssTypes.Mask.Clip.PaddingBox |> maskClipValue'
        static member BorderBox = FssTypes.Mask.Clip.BorderBox |> maskClipValue'
        static member MarginBox = FssTypes.Mask.Clip.MarginBox |> maskClipValue'
        static member FillBox = FssTypes.Mask.Clip.FillBox |> maskClipValue'
        static member StrokeBox = FssTypes.Mask.Clip.StrokeBox |> maskClipValue'
        static member ViewBox = FssTypes.Mask.Clip.ViewBox |> maskClipValue'
        static member NoClip = FssTypes.Mask.Clip.NoClip |> maskClipValue'
        static member Border = FssTypes.Mask.Clip.Border |> maskClipValue'
        static member Padding = FssTypes.Mask.Clip.Padding |> maskClipValue'
        static member Content = FssTypes.Mask.Clip.Content |> maskClipValue'
        static member Text = FssTypes.Mask.Clip.Text |> maskClipValue'
        static member Inherit = FssTypes.Inherit |> maskClipValue'
        static member Initial = FssTypes.Initial |> maskClipValue'
        static member Unset = FssTypes.Unset |> maskClipValue'

    /// <summary>Specifies which area is affected by a mask.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskClip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskClip' (clip: FssTypes.IMaskClip) = clip |> MaskClip.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-composite
    let private stringifyComposite (composite: FssTypes.IMaskComposite) =
        match composite with
        | :? FssTypes.Mask.Composite as m -> Utilities.Helpers.duToLowercase m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask-composite"

    let private maskCompositeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskComposite value
    let private maskCompositeValue' value =
        value
        |> stringifyComposite
        |> maskCompositeValue

    type MaskComposite =
        static member Value (clip: FssTypes.IMaskComposite) = clip |> maskCompositeValue'
        static member Value (clips: FssTypes.Mask.Composite list) =
            clips
            |> Utilities.Helpers.combineComma stringifyComposite
            |> maskCompositeValue
        static member Add = FssTypes.Mask.Composite.Add |> maskCompositeValue'
        static member Subtract = FssTypes.Mask.Composite.Subtract |> maskCompositeValue'
        static member Intersect = FssTypes.Mask.Composite.Intersect |> maskCompositeValue'
        static member Exclude = FssTypes.Mask.Composite.Exclude |> maskCompositeValue'
        static member Inherit = FssTypes.Inherit |> maskCompositeValue'
        static member Initial = FssTypes.Initial |> maskCompositeValue'
        static member Unset = FssTypes.Unset |> maskCompositeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskComposite </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskComposite' (clip: FssTypes.IMaskComposite) = clip |> MaskComposite.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-image
    let private imageSourceToString (imageSource: FssTypes.IMaskImage) =
        match imageSource with
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask image"

    let private imageValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskImage value
    let private imageValue' value =
        value
        |> imageSourceToString
        |> imageValue

    type MaskImage =
        static member Value (source: FssTypes.IMaskImage) = source |> imageValue'
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        static member LinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType* FssTypes.Percent) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType* FssTypes.Size) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member None = FssTypes.None' |> imageValue'
        static member Inherit = FssTypes.Inherit |> imageValue'
        static member Initial = FssTypes.Initial |> imageValue'
        static member Unset = FssTypes.Unset |> imageValue'

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
    let MaskImage' (source: FssTypes.IMaskImage) = MaskImage.Value(source)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-mode
    let private stringifyMode (composite: FssTypes.IMaskMode) =
        match composite with
        | :? FssTypes.Mask.Mode as m -> Utilities.Helpers.duToKebab m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskModeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskMode value
    let private maskModeValue' value =
        value
        |> stringifyMode
        |> maskModeValue

    type MaskMode =
        static member Value (mode: FssTypes.IMaskMode) = mode |> maskModeValue'
        static member Value (modes: FssTypes.Mask.Mode list) =
            modes
            |> Utilities.Helpers.combineComma stringifyMode
            |> maskModeValue
        static member Alpha = FssTypes.Mask.Alpha |> maskModeValue'
        static member Luminance = FssTypes.Mask.Luminance |> maskModeValue'
        static member MatchSource = FssTypes.Mask.MatchSource |> maskModeValue'
        static member Inherit = FssTypes.Inherit |> maskModeValue'
        static member Initial = FssTypes.Initial |> maskModeValue'
        static member Unset = FssTypes.Unset |> maskModeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskMode' (mode: FssTypes.IMaskMode) = mode |> MaskMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-origin
    let private stringifyOrigin (composite: FssTypes.IMaskOrigin) =
        match composite with
        | :? FssTypes.Mask.Origin as m -> Utilities.Helpers.duToKebab m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskOriginValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskOrigin value
    let maskOriginValue' value =
        value
        |> stringifyOrigin
        |> maskOriginValue

    type MaskOrigin =
        static member Value (origin: FssTypes.IMaskOrigin) = origin |> maskOriginValue'
        static member Value (origins: FssTypes.Mask.Origin list) =
            origins
            |> Utilities.Helpers.combineComma stringifyOrigin
            |> maskOriginValue
        static member ContentBox = FssTypes.Mask.Origin.ContentBox |> maskOriginValue'
        static member PaddingBox = FssTypes.Mask.Origin.PaddingBox |> maskOriginValue'
        static member BorderBox = FssTypes.Mask.Origin.BorderBox |> maskOriginValue'
        static member MarginBox = FssTypes.Mask.Origin.MarginBox |> maskOriginValue'
        static member FillBox = FssTypes.Mask.Origin.FillBox |> maskOriginValue'
        static member StrokeBox = FssTypes.Mask.Origin.StrokeBox |> maskOriginValue'
        static member ViewBox = FssTypes.Mask.Origin.ViewBox |> maskOriginValue'
        static member Content = FssTypes.Mask.Origin.Content |> maskOriginValue'
        static member Padding = FssTypes.Mask.Origin.Padding |> maskOriginValue'
        static member Border = FssTypes.Mask.Origin.Border |> maskOriginValue'

        static member Inherit = FssTypes.Inherit |> maskOriginValue'
        static member Initial = FssTypes.Initial |> maskOriginValue'
        static member Unset = FssTypes.Unset |> maskOriginValue'

    /// <summary>Specifies origin of masks.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskOrigin </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskOrigin' (mode: FssTypes.IMaskOrigin) = mode |> MaskOrigin.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-position
    let private stringifyPosition (composite: FssTypes.IMaskPosition) =
        match composite with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask position"

    let private maskPositionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskPosition value
    let private maskPositionValue' value =
        value
        |> stringifyPosition
        |> maskPositionValue

    let private stringifyPixelPositions ps =
        let (x, y) = ps
        $"{FssTypes.unitHelpers.sizeToString x} {FssTypes.unitHelpers.sizeToString y}"

    let private stringifyPercentPositions ps =
        let (x, y) = ps
        $"{FssTypes.unitHelpers.percentToString x} {FssTypes.unitHelpers.percentToString y}"

    type MaskPosition =
        static member Value (x: FssTypes.Size, y: FssTypes.Size) =
            stringifyPixelPositions(x,y)
            |> maskPositionValue
        static member Value (positions: (FssTypes.Size * FssTypes.Size) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPixelPositions
            |> maskPositionValue
        static member Value (x: FssTypes.Percent, y: FssTypes.Percent) =
            stringifyPercentPositions(x,y)
            |> maskPositionValue
        static member Value (positions: (FssTypes.Percent * FssTypes.Percent) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPercentPositions
            |> maskPositionValue
        static member Inherit = FssTypes.Inherit |> maskPositionValue'
        static member Initial = FssTypes.Initial |> maskPositionValue'
        static member Unset = FssTypes.Unset |> maskPositionValue'

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
    let MaskPosition' (x: FssTypes.Size) (y: FssTypes.Size) = MaskPosition.Value(x,y)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-repeat
    let private stringifyRepeat (composite: FssTypes.IMaskRepeat) =
        match composite with
        | :? FssTypes.Mask.Repeat as r ->
            match r with
            | FssTypes.Mask.Repeat -> "repeat"
            | _ -> Utilities.Helpers.duToKebab r
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask repeat"

    let private maskRepeatValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskRepeat value
    let private maskRepeatValue' value =
        value
        |> stringifyRepeat
        |> maskRepeatValue

    let private repeatValue (x: FssTypes.Mask.Repeat, y: FssTypes.Mask.Repeat) =
        $"{stringifyRepeat x} {stringifyRepeat y}"

    type MaskRepeat =
        static member Value (repeat: FssTypes.IMaskRepeat) =
            repeat
            |> maskRepeatValue'
        static member Value (repeatX: FssTypes.IMaskRepeat, repeatY: FssTypes.IMaskRepeat) =
            $"{stringifyRepeat repeatX} {stringifyRepeat repeatY}"
            |> maskRepeatValue
        static member Value(repeats: (FssTypes.Mask.Repeat * FssTypes.Mask.Repeat) list) =
            repeats
            |> Utilities.Helpers.combineComma repeatValue
            |> maskRepeatValue
        static member RepeatX = FssTypes.Mask.RepeatX |> maskRepeatValue'
        static member RepeatY = FssTypes.Mask.RepeatY |> maskRepeatValue'
        static member Repeat = FssTypes.Mask.Repeat |> maskRepeatValue'
        static member Space = FssTypes.Mask.Space |> maskRepeatValue'
        static member Round = FssTypes.Mask.Round |> maskRepeatValue'
        static member NoRepeat = FssTypes.Mask.NoRepeat |> maskRepeatValue'
        static member Inherit = FssTypes.Inherit |> maskRepeatValue'
        static member Initial = FssTypes.Initial |> maskRepeatValue'
        static member Unset = FssTypes.Unset |> maskRepeatValue'

    /// <summary>Specifies how masks are repeated.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> MaskRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskRepeat' (repeat: FssTypes.IMaskRepeat) = repeat |> MaskRepeat.Value