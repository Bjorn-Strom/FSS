namespace Fss

[<AutoOpen>]
module Mask =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
    let private stringifyClip (clip: Types.IMaskClip) =
        match clip with
        | :? Types.MaskClip as m -> Utilities.Helpers.duToKebab m
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown mask-clip"

    let private maskClipValue value = Types.cssValue Types.Property.MaskClip value
    let private maskClipValue' value =
        value
        |> stringifyClip
        |> maskClipValue

    type MaskClip =
        static member Value (clip: Types.IMaskClip) = clip |> maskClipValue'
        static member Value (clips: Types.MaskClip list) =
            clips
            |> Utilities.Helpers.combineComma stringifyClip
            |> maskClipValue
        static member ContentBox = Types.MaskClip.ContentBox |> maskClipValue'
        static member PaddingBox = Types.MaskClip.PaddingBox |> maskClipValue'
        static member BorderBox = Types.MaskClip.BorderBox |> maskClipValue'
        static member MarginBox = Types.MaskClip.MarginBox |> maskClipValue'
        static member FillBox = Types.MaskClip.FillBox |> maskClipValue'
        static member StrokeBox = Types.MaskClip.StrokeBox |> maskClipValue'
        static member ViewBox = Types.MaskClip.ViewBox |> maskClipValue'
        static member NoClip = Types.MaskClip.NoClip |> maskClipValue'
        static member Border = Types.MaskClip.Border |> maskClipValue'
        static member Padding = Types.MaskClip.Padding |> maskClipValue'
        static member Content = Types.MaskClip.Content |> maskClipValue'
        static member Text = Types.MaskClip.Text |> maskClipValue'
        static member Inherit = Types.Inherit |> maskClipValue'
        static member Initial = Types.Initial |> maskClipValue'
        static member Unset = Types.Unset |> maskClipValue'

    /// <summary>Specifies which area is affected by a mask.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskClip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskClip' (clip: Types.IMaskClip) = clip |> MaskClip.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-composite
    let private stringifyComposite (composite: Types.IMaskComposite) =
        match composite with
        | :? Types.MaskComposite as m -> Utilities.Helpers.duToLowercase m
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown mask-composite"

    let private maskCompositeValue value = Types.cssValue Types.Property.MaskComposite value
    let private maskCompositeValue' value =
        value
        |> stringifyComposite
        |> maskCompositeValue

    type MaskComposite =
        static member Value (clip: Types.IMaskComposite) = clip |> maskCompositeValue'
        static member Value (clips: Types.MaskComposite list) =
            clips
            |> Utilities.Helpers.combineComma stringifyComposite
            |> maskCompositeValue
        static member Add = Types.MaskComposite.Add |> maskCompositeValue'
        static member Subtract = Types.MaskComposite.Subtract |> maskCompositeValue'
        static member Intersect = Types.MaskComposite.Intersect |> maskCompositeValue'
        static member Exclude = Types.MaskComposite.Exclude |> maskCompositeValue'
        static member Inherit = Types.Inherit |> maskCompositeValue'
        static member Initial = Types.Initial |> maskCompositeValue'
        static member Unset = Types.Unset |> maskCompositeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskComposite </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskComposite' (clip: Types.IMaskComposite) = clip |> MaskComposite.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-image
    let private imageSourceToString (imageSource: Types.IMaskImage) =
        match imageSource with
        | :? Types.None' -> Types.none
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown mask image"

    let private imageValue value = Types.cssValue Types.Property.MaskImage value
    let private imageValue' value =
        value
        |> imageSourceToString
        |> imageValue

    type MaskImage =
        static member Value (source: Types.IMaskImage) = source |> imageValue'
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        static member LinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            imageValue <| Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            imageValue <| Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            imageValue <| Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            imageValue <| Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Image.Shape, size: Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Image.Shape, size: Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Image.Shape * Image.Side * Types.Percent * Types.Percent * (Types.Color * Types.Percent) list) list) =
            imageValue <| Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Image.Shape * Image.Side * Types.Percent * Types.Percent * (Types.Color * Types.Size) list) list) =
            imageValue <| Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Image.Shape, size: Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Image.Shape, size: Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member None = Types.None' |> imageValue'
        static member Inherit = Types.Inherit |> imageValue'
        static member Initial = Types.Initial |> imageValue'
        static member Unset = Types.Unset |> imageValue'

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
    let MaskImage' (source: Types.IMaskImage) = MaskImage.Value(source)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-mode
    let private stringifyMode (composite: Types.IMaskMode) =
        match composite with
        | :? Types.MaskMode as m -> Utilities.Helpers.duToKebab m
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskModeValue value = Types.cssValue Types.Property.MaskMode value
    let private maskModeValue' value =
        value
        |> stringifyMode
        |> maskModeValue

    type MaskMode =
        static member Value (mode: Types.IMaskMode) = mode |> maskModeValue'
        static member Value (modes: Types.MaskMode list) =
            modes
            |> Utilities.Helpers.combineComma stringifyMode
            |> maskModeValue
        static member Alpha = Types.Alpha |> maskModeValue'
        static member Luminance = Types.Luminance |> maskModeValue'
        static member MatchSource = Types.MatchSource |> maskModeValue'
        static member Inherit = Types.Inherit |> maskModeValue'
        static member Initial = Types.Initial |> maskModeValue'
        static member Unset = Types.Unset |> maskModeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskMode' (mode: Types.IMaskMode) = mode |> MaskMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-origin
    let private stringifyOrigin (composite: Types.IMaskOrigin) =
        match composite with
        | :? Types.MaskOrigin as m -> Utilities.Helpers.duToKebab m
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskOriginValue value = Types.cssValue Types.Property.MaskOrigin value
    let maskOriginValue' value =
        value
        |> stringifyOrigin
        |> maskOriginValue

    type MaskOrigin =
        static member Value (origin: Types.IMaskOrigin) = origin |> maskOriginValue'
        static member Value (origins: Types.MaskOrigin list) =
            origins
            |> Utilities.Helpers.combineComma stringifyOrigin
            |> maskOriginValue
        static member ContentBox = Types.MaskOrigin.ContentBox |> maskOriginValue'
        static member PaddingBox = Types.MaskOrigin.PaddingBox |> maskOriginValue'
        static member BorderBox = Types.MaskOrigin.BorderBox |> maskOriginValue'
        static member MarginBox = Types.MaskOrigin.MarginBox |> maskOriginValue'
        static member FillBox = Types.MaskOrigin.FillBox |> maskOriginValue'
        static member StrokeBox = Types.MaskOrigin.StrokeBox |> maskOriginValue'
        static member ViewBox = Types.MaskOrigin.ViewBox |> maskOriginValue'
        static member Content = Types.MaskOrigin.Content |> maskOriginValue'
        static member Padding = Types.MaskOrigin.Padding |> maskOriginValue'
        static member Border = Types.MaskOrigin.Border |> maskOriginValue'

        static member Inherit = Types.Inherit |> maskOriginValue'
        static member Initial = Types.Initial |> maskOriginValue'
        static member Unset = Types.Unset |> maskOriginValue'

    /// <summary>Specifies origin of masks.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskOrigin </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskOrigin' (mode: Types.IMaskOrigin) = mode |> MaskOrigin.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-position
    let private stringifyPosition (composite: Types.IMaskPosition) =
        match composite with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown mask position"

    let private maskPositionValue value = Types.cssValue Types.Property.MaskPosition value
    let private maskPositionValue' value =
        value
        |> stringifyPosition
        |> maskPositionValue

    let private stringifyPixelPositions ps =
        let (x, y) = ps
        $"{Types.sizeToString x} {Types.sizeToString y}"

    let private stringifyPercentPositions ps =
        let (x, y) = ps
        $"{Types.percentToString x} {Types.percentToString y}"

    type MaskPosition =
        static member Value (x: Types.Size, y: Types.Size) =
            stringifyPixelPositions(x,y)
            |> maskPositionValue
        static member Value (positions: (Types.Size * Types.Size) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPixelPositions
            |> maskPositionValue
        static member Value (x: Types.Percent, y: Types.Percent) =
            stringifyPercentPositions(x,y)
            |> maskPositionValue
        static member Value (positions: (Types.Percent * Types.Percent) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPercentPositions
            |> maskPositionValue
        static member Inherit = Types.Inherit |> maskPositionValue'
        static member Initial = Types.Initial |> maskPositionValue'
        static member Unset = Types.Unset |> maskPositionValue'

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
    let MaskPosition' (x: Types.Size) (y: Types.Size) = MaskPosition.Value(x,y)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-repeat
    let private stringifyRepeat (composite: Types.IMaskRepeat) =
        match composite with
        | :? Types.MaskRepeat as r -> Utilities.Helpers.duToKebab r
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown mask repeat"

    let private maskRepeatValue value = Types.cssValue Types.Property.MaskRepeat value
    let private maskRepeatValue' value =
        value
        |> stringifyRepeat
        |> maskRepeatValue

    let private repeatValue (x: Types.MaskRepeat, y: Types.MaskRepeat) =
        $"{stringifyRepeat x} {stringifyRepeat y}"

    type MaskRepeat =
        static member Value (repeat: Types.IMaskRepeat) =
            repeat
            |> maskRepeatValue'
        static member Value (repeatX: Types.IMaskRepeat, repeatY: Types.IMaskRepeat) =
            $"{stringifyRepeat repeatX} {stringifyRepeat repeatY}"
            |> maskRepeatValue
        static member Value(repeats: (Types.MaskRepeat * Types.MaskRepeat) list) =
            repeats
            |> Utilities.Helpers.combineComma repeatValue
            |> maskRepeatValue
        static member RepeatX = Types.MaskRepeat.RepeatX |> maskRepeatValue'
        static member RepeatY = Types.MaskRepeat.RepeatY |> maskRepeatValue'
        static member Repeat = Types.MaskRepeat.Repeat' |> maskRepeatValue'
        static member Space = Types.MaskRepeat.Space |> maskRepeatValue'
        static member Round = Types.MaskRepeat.Round |> maskRepeatValue'
        static member NoRepeat = Types.MaskRepeat.NoRepeat |> maskRepeatValue'
        static member Inherit = Types.Inherit |> maskRepeatValue'
        static member Initial = Types.Initial |> maskRepeatValue'
        static member Unset = Types.Unset |> maskRepeatValue'

    /// <summary>Specifies how masks are repeated.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> MaskRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskRepeat' (repeat: Types.IMaskRepeat) = repeat |> MaskRepeat.Value