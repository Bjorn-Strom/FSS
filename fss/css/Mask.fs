namespace Fss

[<AutoOpen>]
module Mask =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
    let private stringifyClip (clip: Types.IMaskClip) =
        match clip with
        | :? Types.Mask.Clip as m -> Utilities.Helpers.duToKebab m
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask-clip"

    let private maskClipValue value = Types.propertyHelpers.cssValue Types.Property.MaskClip value
    let private maskClipValue' value =
        value
        |> stringifyClip
        |> maskClipValue

    type MaskClip =
        static member Value (clip: Types.IMaskClip) = clip |> maskClipValue'
        static member Value (clips: Types.Mask.Clip list) =
            clips
            |> Utilities.Helpers.combineComma stringifyClip
            |> maskClipValue
        static member ContentBox = Types.Mask.Clip.ContentBox |> maskClipValue'
        static member PaddingBox = Types.Mask.Clip.PaddingBox |> maskClipValue'
        static member BorderBox = Types.Mask.Clip.BorderBox |> maskClipValue'
        static member MarginBox = Types.Mask.Clip.MarginBox |> maskClipValue'
        static member FillBox = Types.Mask.Clip.FillBox |> maskClipValue'
        static member StrokeBox = Types.Mask.Clip.StrokeBox |> maskClipValue'
        static member ViewBox = Types.Mask.Clip.ViewBox |> maskClipValue'
        static member NoClip = Types.Mask.Clip.NoClip |> maskClipValue'
        static member Border = Types.Mask.Clip.Border |> maskClipValue'
        static member Padding = Types.Mask.Clip.Padding |> maskClipValue'
        static member Content = Types.Mask.Clip.Content |> maskClipValue'
        static member Text = Types.Mask.Clip.Text |> maskClipValue'
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
        | :? Types.Mask.Composite as m -> Utilities.Helpers.duToLowercase m
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask-composite"

    let private maskCompositeValue value = Types.propertyHelpers.cssValue Types.Property.MaskComposite value
    let private maskCompositeValue' value =
        value
        |> stringifyComposite
        |> maskCompositeValue

    type MaskComposite =
        static member Value (clip: Types.IMaskComposite) = clip |> maskCompositeValue'
        static member Value (clips: Types.Mask.Composite list) =
            clips
            |> Utilities.Helpers.combineComma stringifyComposite
            |> maskCompositeValue
        static member Add = Types.Mask.Composite.Add |> maskCompositeValue'
        static member Subtract = Types.Mask.Composite.Subtract |> maskCompositeValue'
        static member Intersect = Types.Mask.Composite.Intersect |> maskCompositeValue'
        static member Exclude = Types.Mask.Composite.Exclude |> maskCompositeValue'
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
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask image"

    let private imageValue value = Types.propertyHelpers.cssValue Types.Property.MaskImage value
    let private imageValue' value =
        value
        |> imageSourceToString
        |> imageValue

    type MaskImage =
        static member Value (source: Types.IMaskImage) = source |> imageValue'
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        static member LinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo* Types.Percent) list) =
            imageValue <| Types.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo* Types.Size) list) =
            imageValue <| Types.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo* Types.Percent) list)) list) =
            imageValue <| Types.Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo* Types.Size) list)) list) =
            imageValue <| Types.Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo* Types.Size) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo* Types.Percent) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo* Types.Size) list)) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo* Types.Percent) list)) list) =
            imageValue <| Types.Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.ColorTypeFoo* Types.Percent) list) =
            imageValue <| Types.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.ColorTypeFoo* Types.Size) list) =
            imageValue <| Types.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Types.Image.Shape * Types.Image.Side * Types.Percent * Types.Percent * (Types.ColorTypeFoo* Types.Percent) list) list) =
            imageValue <| Types.Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Types.Image.Shape * Types.Image.Side * Types.Percent * Types.Percent * (Types.ColorTypeFoo* Types.Size) list) list) =
            imageValue <| Types.Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.ColorTypeFoo* Types.Percent) list) =
            imageValue <| Types.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.ColorTypeFoo* Types.Size) list) =
            imageValue <| Types.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
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
        | :? Types.Mask.Mode as m -> Utilities.Helpers.duToKebab m
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskModeValue value = Types.propertyHelpers.cssValue Types.Property.MaskMode value
    let private maskModeValue' value =
        value
        |> stringifyMode
        |> maskModeValue

    type MaskMode =
        static member Value (mode: Types.IMaskMode) = mode |> maskModeValue'
        static member Value (modes: Types.Mask.Mode list) =
            modes
            |> Utilities.Helpers.combineComma stringifyMode
            |> maskModeValue
        static member Alpha = Types.Mask.Alpha |> maskModeValue'
        static member Luminance = Types.Mask.Luminance |> maskModeValue'
        static member MatchSource = Types.Mask.MatchSource |> maskModeValue'
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
        | :? Types.Mask.Origin as m -> Utilities.Helpers.duToKebab m
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskOriginValue value = Types.propertyHelpers.cssValue Types.Property.MaskOrigin value
    let maskOriginValue' value =
        value
        |> stringifyOrigin
        |> maskOriginValue

    type MaskOrigin =
        static member Value (origin: Types.IMaskOrigin) = origin |> maskOriginValue'
        static member Value (origins: Types.Mask.Origin list) =
            origins
            |> Utilities.Helpers.combineComma stringifyOrigin
            |> maskOriginValue
        static member ContentBox = Types.Mask.Origin.ContentBox |> maskOriginValue'
        static member PaddingBox = Types.Mask.Origin.PaddingBox |> maskOriginValue'
        static member BorderBox = Types.Mask.Origin.BorderBox |> maskOriginValue'
        static member MarginBox = Types.Mask.Origin.MarginBox |> maskOriginValue'
        static member FillBox = Types.Mask.Origin.FillBox |> maskOriginValue'
        static member StrokeBox = Types.Mask.Origin.StrokeBox |> maskOriginValue'
        static member ViewBox = Types.Mask.Origin.ViewBox |> maskOriginValue'
        static member Content = Types.Mask.Origin.Content |> maskOriginValue'
        static member Padding = Types.Mask.Origin.Padding |> maskOriginValue'
        static member Border = Types.Mask.Origin.Border |> maskOriginValue'

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
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask position"

    let private maskPositionValue value = Types.propertyHelpers.cssValue Types.Property.MaskPosition value
    let private maskPositionValue' value =
        value
        |> stringifyPosition
        |> maskPositionValue

    let private stringifyPixelPositions ps =
        let (x, y) = ps
        $"{Types.unitHelpers.sizeToString x} {Types.unitHelpers.sizeToString y}"

    let private stringifyPercentPositions ps =
        let (x, y) = ps
        $"{Types.unitHelpers.percentToString x} {Types.unitHelpers.percentToString y}"

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
        | :? Types.Mask.Repeat as r ->
            match r with
            | Types.Mask.Repeat -> "repeat"
            | _ -> Utilities.Helpers.duToKebab r
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask repeat"

    let private maskRepeatValue value = Types.propertyHelpers.cssValue Types.Property.MaskRepeat value
    let private maskRepeatValue' value =
        value
        |> stringifyRepeat
        |> maskRepeatValue

    let private repeatValue (x: Types.Mask.Repeat, y: Types.Mask.Repeat) =
        $"{stringifyRepeat x} {stringifyRepeat y}"

    type MaskRepeat =
        static member Value (repeat: Types.IMaskRepeat) =
            repeat
            |> maskRepeatValue'
        static member Value (repeatX: Types.IMaskRepeat, repeatY: Types.IMaskRepeat) =
            $"{stringifyRepeat repeatX} {stringifyRepeat repeatY}"
            |> maskRepeatValue
        static member Value(repeats: (Types.Mask.Repeat * Types.Mask.Repeat) list) =
            repeats
            |> Utilities.Helpers.combineComma repeatValue
            |> maskRepeatValue
        static member RepeatX = Types.Mask.RepeatX |> maskRepeatValue'
        static member RepeatY = Types.Mask.RepeatY |> maskRepeatValue'
        static member Repeat = Types.Mask.Repeat |> maskRepeatValue'
        static member Space = Types.Mask.Space |> maskRepeatValue'
        static member Round = Types.Mask.Round |> maskRepeatValue'
        static member NoRepeat = Types.Mask.NoRepeat |> maskRepeatValue'
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