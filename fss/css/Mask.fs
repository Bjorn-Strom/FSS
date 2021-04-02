namespace Fss

open Fable.Core

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

    [<Erase>]
    type MaskClip =
        static member value (clip: FssTypes.IMaskClip) = clip |> maskClipValue'
        static member value (clips: FssTypes.Mask.Clip list) =
            clips
            |> Utilities.Helpers.combineComma stringifyClip
            |> maskClipValue
        static member contentBox = FssTypes.Mask.Clip.ContentBox |> maskClipValue'
        static member paddingBox = FssTypes.Mask.Clip.PaddingBox |> maskClipValue'
        static member borderBox = FssTypes.Mask.Clip.BorderBox |> maskClipValue'
        static member marginBox = FssTypes.Mask.Clip.MarginBox |> maskClipValue'
        static member fillBox = FssTypes.Mask.Clip.FillBox |> maskClipValue'
        static member strokeBox = FssTypes.Mask.Clip.StrokeBox |> maskClipValue'
        static member viewBox = FssTypes.Mask.Clip.ViewBox |> maskClipValue'
        static member noClip = FssTypes.Mask.Clip.NoClip |> maskClipValue'
        static member border = FssTypes.Mask.Clip.Border |> maskClipValue'
        static member padding = FssTypes.Mask.Clip.Padding |> maskClipValue'
        static member content = FssTypes.Mask.Clip.Content |> maskClipValue'
        static member text = FssTypes.Mask.Clip.Text |> maskClipValue'
        static member inherit' = FssTypes.Inherit |> maskClipValue'
        static member initial = FssTypes.Initial |> maskClipValue'
        static member unset = FssTypes.Unset |> maskClipValue'

    /// <summary>Specifies which area is affected by a mask.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskClip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskClip' (clip: FssTypes.IMaskClip) = clip |> MaskClip.value

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

    [<Erase>]
    type MaskComposite =
        static member value (clip: FssTypes.IMaskComposite) = clip |> maskCompositeValue'
        static member value (clips: FssTypes.Mask.Composite list) =
            clips
            |> Utilities.Helpers.combineComma stringifyComposite
            |> maskCompositeValue
        static member add = FssTypes.Mask.Composite.Add |> maskCompositeValue'
        static member subtract = FssTypes.Mask.Composite.Subtract |> maskCompositeValue'
        static member intersect = FssTypes.Mask.Composite.Intersect |> maskCompositeValue'
        static member exclude = FssTypes.Mask.Composite.Exclude |> maskCompositeValue'
        static member inherit' = FssTypes.Inherit |> maskCompositeValue'
        static member initial = FssTypes.Initial |> maskCompositeValue'
        static member unset = FssTypes.Unset |> maskCompositeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> MaskComposite </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskComposite' (clip: FssTypes.IMaskComposite) = clip |> MaskComposite.value

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

    [<Erase>]
    type MaskImage =
        static member value (source: FssTypes.IMaskImage) = source |> imageValue'
        static member url (url: string) = imageValue <| sprintf "url(%s)" url
        static member linearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member linearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member linearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member linearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member repeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member repeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member repeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)
        static member repeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType* FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)

        static member radialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member radialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member radialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType* FssTypes.Percent) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member radialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType* FssTypes.Size) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member repeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member repeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType* FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member none = FssTypes.None' |> imageValue'
        static member inherit' = FssTypes.Inherit |> imageValue'
        static member initial = FssTypes.Initial |> imageValue'
        static member unset = FssTypes.Unset |> imageValue'

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
    let MaskImage' (source: FssTypes.IMaskImage) = MaskImage.value(source)

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

    [<Erase>]
    type MaskMode =
        static member value (mode: FssTypes.IMaskMode) = mode |> maskModeValue'
        static member value (modes: FssTypes.Mask.Mode list) =
            modes
            |> Utilities.Helpers.combineComma stringifyMode
            |> maskModeValue
        static member alpha = FssTypes.Mask.Alpha |> maskModeValue'
        static member luminance = FssTypes.Mask.Luminance |> maskModeValue'
        static member matchSource = FssTypes.Mask.MatchSource |> maskModeValue'
        static member inherit' = FssTypes.Inherit |> maskModeValue'
        static member initial = FssTypes.Initial |> maskModeValue'
        static member unset = FssTypes.Unset |> maskModeValue'

    /// <summary>Allows composing of masks with masks under it.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskMode </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskMode' (mode: FssTypes.IMaskMode) = mode |> MaskMode.value

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

    [<Erase>]
    type MaskOrigin =
        static member value (origin: FssTypes.IMaskOrigin) = origin |> maskOriginValue'
        static member value (origins: FssTypes.Mask.Origin list) =
            origins
            |> Utilities.Helpers.combineComma stringifyOrigin
            |> maskOriginValue
        static member contentBox = FssTypes.Mask.Origin.ContentBox |> maskOriginValue'
        static member paddingBox = FssTypes.Mask.Origin.PaddingBox |> maskOriginValue'
        static member borderBox = FssTypes.Mask.Origin.BorderBox |> maskOriginValue'
        static member marginBox = FssTypes.Mask.Origin.MarginBox |> maskOriginValue'
        static member fillBox = FssTypes.Mask.Origin.FillBox |> maskOriginValue'
        static member strokeBox = FssTypes.Mask.Origin.StrokeBox |> maskOriginValue'
        static member viewBox = FssTypes.Mask.Origin.ViewBox |> maskOriginValue'
        static member content = FssTypes.Mask.Origin.Content |> maskOriginValue'
        static member padding = FssTypes.Mask.Origin.Padding |> maskOriginValue'
        static member border = FssTypes.Mask.Origin.Border |> maskOriginValue'

        static member inherit' = FssTypes.Inherit |> maskOriginValue'
        static member initial = FssTypes.Initial |> maskOriginValue'
        static member unset = FssTypes.Unset |> maskOriginValue'

    /// <summary>Specifies origin of masks.</summary>
    /// <param name="mode">
    ///     can be:
    ///     - <c> MaskOrigin </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskOrigin' (mode: FssTypes.IMaskOrigin) = mode |> MaskOrigin.value

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

    [<Erase>]
    type MaskPosition =
        static member value (x: FssTypes.Size, y: FssTypes.Size) =
            stringifyPixelPositions(x,y)
            |> maskPositionValue
        static member value (positions: (FssTypes.Size * FssTypes.Size) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPixelPositions
            |> maskPositionValue
        static member value (x: FssTypes.Percent, y: FssTypes.Percent) =
            stringifyPercentPositions(x,y)
            |> maskPositionValue
        static member value (positions: (FssTypes.Percent * FssTypes.Percent) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPercentPositions
            |> maskPositionValue
        static member inherit' = FssTypes.Inherit |> maskPositionValue'
        static member initial = FssTypes.Initial |> maskPositionValue'
        static member unset = FssTypes.Unset |> maskPositionValue'

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
    let MaskPosition' (x: FssTypes.Size) (y: FssTypes.Size) = MaskPosition.value(x,y)

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

    [<Erase>]
    type MaskRepeat =
        static member value (repeat: FssTypes.IMaskRepeat) =
            repeat
            |> maskRepeatValue'
        static member value (repeatX: FssTypes.IMaskRepeat, repeatY: FssTypes.IMaskRepeat) =
            $"{stringifyRepeat repeatX} {stringifyRepeat repeatY}"
            |> maskRepeatValue
        static member value(repeats: (FssTypes.Mask.Repeat * FssTypes.Mask.Repeat) list) =
            repeats
            |> Utilities.Helpers.combineComma repeatValue
            |> maskRepeatValue
        static member repeatX = FssTypes.Mask.RepeatX |> maskRepeatValue'
        static member repeatY = FssTypes.Mask.RepeatY |> maskRepeatValue'
        static member repeat = FssTypes.Mask.Repeat |> maskRepeatValue'
        static member space = FssTypes.Mask.Space |> maskRepeatValue'
        static member round = FssTypes.Mask.Round |> maskRepeatValue'
        static member noRepeat = FssTypes.Mask.NoRepeat |> maskRepeatValue'
        static member inherit' = FssTypes.Inherit |> maskRepeatValue'
        static member initial = FssTypes.Initial |> maskRepeatValue'
        static member unset = FssTypes.Unset |> maskRepeatValue'

    /// <summary>Specifies how masks are repeated.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> MaskRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MaskRepeat' (repeat: FssTypes.IMaskRepeat) = repeat |> MaskRepeat.value