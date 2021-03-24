namespace Fss

[<AutoOpen>]
module Background =

    let private backgroundClipToString (clip: FssTypes.IBackgroundClip) =
        match clip with
        | :? FssTypes.Background.Clip as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown background clip"

    let private backgroundOriginToString (clip: FssTypes.IBackgroundOrigin) =
        match clip with
        | :? FssTypes.Background.Origin as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown background origin"

    let private repeatToString (repeat: FssTypes.IBackgroundRepeat) =
        match repeat with
        | :? FssTypes.Background.Repeat as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown background repeat"

    let private sizeToString (size: FssTypes.IBackgroundSize) =
        match size with
        | :? FssTypes.Background.Size as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown background size"

    let private attachmentToString (attachment: FssTypes.IBackgroundAttachment) =
        match attachment with
        | :? FssTypes.Background.Attachment as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown background attachment"

    let private positionToString (position: FssTypes.IBackgroundPosition) =
        match position with
        | :? FssTypes.Background.Position as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown background position"

    let private blendModeToString (blendMode: FssTypes.IBackgroundBlendMode) =
        match blendMode with
        | :? FssTypes.Background.BlendMode as b ->
            match b with
            | FssTypes.Background.Color -> "color"
            | _ -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown background blend mode"

    let private isolationToString (isolation: FssTypes.IIsolation) =
        match isolation with
        | :? FssTypes.Background.Isolation as i -> "isolate"
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown isolation"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    let private clipValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundClip value
    let private clipValue' value =
        value
        |> backgroundClipToString
        |> clipValue

    type BackgroundClip =
        static member Value (clip: FssTypes.IBackgroundClip) = clip |> clipValue'
        static member BorderBox = FssTypes.Background.Clip.BorderBox |> clipValue'
        static member PaddingBox = FssTypes.Background.Clip.PaddingBox |> clipValue'
        static member ContentBox = FssTypes.Background.Clip.ContentBox |> clipValue'
        static member Text = FssTypes.Background.Clip.Text |> clipValue'

        static member Inherit = FssTypes.Inherit |> clipValue'
        static member Initial = FssTypes.Initial |> clipValue'
        static member Unset = FssTypes.Unset |> clipValue'

    /// <summary>Specifies how an element's background extends.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> BackgroundClip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundClip' (clip: FssTypes.IBackgroundClip) = BackgroundClip.Value(clip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    let private originValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundOrigin value
    let private originValue' value =
        value
        |> backgroundOriginToString
        |> originValue
    type BackgroundOrigin =
       static member Value (origin: FssTypes.IBackgroundOrigin) = origin |> originValue'
       static member BorderBox = FssTypes.Background.Origin.BorderBox |> originValue'
       static member PaddingBox = FssTypes.Background.Origin.PaddingBox |> originValue'
       static member ContentBox = FssTypes.Background.Origin.ContentBox |> originValue'

       static member Inherit = FssTypes.Inherit |> originValue'
       static member Initial = FssTypes.Initial |> originValue'
       static member Unset = FssTypes.Unset |> originValue'

    /// <summary>Sets background origin.</summary>
    /// <param name="origin">
    ///     can be:
    ///     - <c> BackgroundOrigin </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundOrigin' (origin: FssTypes.IBackgroundOrigin) = BackgroundOrigin.Value(origin)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    let private repeatValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundRepeat value
    let private repeatValue' value =
        value
        |> repeatToString
        |> repeatValue

    type BackgroundRepeat =
        static member Value (repeat: FssTypes.IBackgroundRepeat) = repeat |> repeatValue'
        static member Value (v1: FssTypes.IBackgroundRepeat, v2: FssTypes.IBackgroundRepeat) =
            sprintf "%s %s" (repeatToString v1) (repeatToString v2)
            |> repeatValue
        static member RepeatX = FssTypes.Background.RepeatX |> repeatValue'
        static member RepeatY = FssTypes.Background.RepeatY |> repeatValue'
        static member Repeat = FssTypes.Background.Repeat |> repeatValue'
        static member Space = FssTypes.Background.Space |> repeatValue'
        static member Round = FssTypes.Background.Round |> repeatValue'
        static member NoRepeat = FssTypes.Background.NoRepeat |> repeatValue'

        static member Inherit = FssTypes.Inherit |> repeatValue'
        static member Initial = FssTypes.Initial |> repeatValue'
        static member Unset = FssTypes.Unset |> repeatValue'

    /// <summary>Specifies how background is repeated.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> BackgroundRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundRepeat' (repeat: FssTypes.IBackgroundRepeat) = BackgroundRepeat.Value(repeat)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    let private sizeValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundSize value
    let private sizeValue' value =
        value
        |> sizeToString
        |> sizeValue
    type BackgroundSize =
        static member Value (size: FssTypes.IBackgroundSize) = size |> sizeValue'
        static member Value (s1: FssTypes.IBackgroundSize, s2: FssTypes.IBackgroundSize) =
            sprintf "%s %s" (sizeToString s1) (sizeToString s2)
                |> sizeValue

        static member Cover = FssTypes.Background.Size.Cover |> sizeValue'
        static member Contain = FssTypes.Background.Size.Contain |> sizeValue'

        static member Auto = FssTypes.Auto |> sizeValue'
        static member Inherit = FssTypes.Inherit |> sizeValue'
        static member Initial = FssTypes.Initial |> sizeValue'
        static member Unset = FssTypes.Unset |> sizeValue'

    /// <summary>Specifies size of background.</summary>
    /// <param name="size">
    ///     can be:
    ///     - <c> BackgroundSize </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundSize' (size: FssTypes.IBackgroundSize) = BackgroundSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    let private attachmentValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundAttachment value
    let private attachmentValue' value =
        value
        |> attachmentToString
        |> attachmentValue
    type BackgroundAttachment =
        static member Value (attachment: FssTypes.IBackgroundAttachment) = attachment |> attachmentValue'
        static member Scroll = FssTypes.Background.Attachment.Scroll |> attachmentValue'
        static member Fixed = FssTypes.Background.Attachment.Fixed |> attachmentValue'
        static member Local = FssTypes.Background.Attachment.Local |> attachmentValue'

        static member Inherit = FssTypes.Inherit |> attachmentValue'
        static member Initial = FssTypes.Initial |> attachmentValue'
        static member Unset = FssTypes.Unset |> attachmentValue'

    /// <summary>Specifies how background is fixed within viewport.</summary>
    /// <param name="attachment">
    ///     can be:
    ///     - <c> BackgroundAttachment </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundAttachment' (attachment: FssTypes.IBackgroundAttachment) = BackgroundAttachment.Value(attachment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-color
    let private backgroundValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundColor value
    let private backgroundValue' value =
        value
        |> FssTypes.colorHelpers.colorToString
        |> backgroundValue
    type BackgroundColor =
        static member Value (color: FssTypes.ColorTypeFoo) = color |> backgroundValue'
        static member black = FssTypes.Color.black |> backgroundValue'
        static member silver = FssTypes.Color.silver |> backgroundValue'
        static member gray = FssTypes.Color.gray |> backgroundValue'
        static member white = FssTypes.Color.white |> backgroundValue'
        static member maroon = FssTypes.Color.maroon |> backgroundValue'
        static member red = FssTypes.Color.red |> backgroundValue'
        static member purple = FssTypes.Color.purple |> backgroundValue'
        static member fuchsia = FssTypes.Color.fuchsia |> backgroundValue'
        static member green = FssTypes.Color.green |> backgroundValue'
        static member lime = FssTypes.Color.lime |> backgroundValue'
        static member olive = FssTypes.Color.olive |> backgroundValue'
        static member yellow = FssTypes.Color.yellow |> backgroundValue'
        static member navy = FssTypes.Color.navy |> backgroundValue'
        static member blue = FssTypes.Color.blue |> backgroundValue'
        static member teal = FssTypes.Color.teal |> backgroundValue'
        static member aqua = FssTypes.Color.aqua |> backgroundValue'
        static member orange = FssTypes.Color.orange |> backgroundValue'
        static member aliceBlue = FssTypes.Color.aliceBlue |> backgroundValue'
        static member antiqueWhite = FssTypes.Color.antiqueWhite |> backgroundValue'
        static member aquaMarine = FssTypes.Color.aquaMarine |> backgroundValue'
        static member azure = FssTypes.Color.azure |> backgroundValue'
        static member beige = FssTypes.Color.beige |> backgroundValue'
        static member bisque = FssTypes.Color.bisque |> backgroundValue'
        static member blanchedAlmond = FssTypes.Color.blanchedAlmond |> backgroundValue'
        static member blueViolet = FssTypes.Color.blueViolet |> backgroundValue'
        static member brown = FssTypes.Color.brown |> backgroundValue'
        static member burlywood = FssTypes.Color.burlywood |> backgroundValue'
        static member cadetBlue = FssTypes.Color.cadetBlue |> backgroundValue'
        static member chartreuse = FssTypes.Color.chartreuse |> backgroundValue'
        static member chocolate = FssTypes.Color.chocolate |> backgroundValue'
        static member coral = FssTypes.Color.coral |> backgroundValue'
        static member cornflowerBlue = FssTypes.Color.cornflowerBlue |> backgroundValue'
        static member cornsilk = FssTypes.Color.cornsilk |> backgroundValue'
        static member crimson = FssTypes.Color.crimson |> backgroundValue'
        static member cyan = FssTypes.Color.cyan |> backgroundValue'
        static member darkBlue = FssTypes.Color.darkBlue |> backgroundValue'
        static member darkCyan = FssTypes.Color.darkCyan |> backgroundValue'
        static member darkGoldenrod = FssTypes.Color.darkGoldenrod |> backgroundValue'
        static member darkGray = FssTypes.Color.darkGray |> backgroundValue'
        static member darkGreen = FssTypes.Color.darkGreen |> backgroundValue'
        static member darkKhaki = FssTypes.Color.darkKhaki |> backgroundValue'
        static member darkMagenta = FssTypes.Color.darkMagenta |> backgroundValue'
        static member darkOliveGreen = FssTypes.Color.darkOliveGreen |> backgroundValue'
        static member darkOrange = FssTypes.Color.darkOrange |> backgroundValue'
        static member darkOrchid = FssTypes.Color.darkOrchid |> backgroundValue'
        static member darkRed = FssTypes.Color.darkRed |> backgroundValue'
        static member darkSalmon = FssTypes.Color.darkSalmon |> backgroundValue'
        static member darkSeaGreen = FssTypes.Color.darkSeaGreen |> backgroundValue'
        static member darkSlateBlue = FssTypes.Color.darkSlateBlue |> backgroundValue'
        static member darkSlateGray = FssTypes.Color.darkSlateGray |> backgroundValue'
        static member darkTurquoise = FssTypes.Color.darkTurquoise |> backgroundValue'
        static member darkViolet = FssTypes.Color.darkViolet |> backgroundValue'
        static member deepPink = FssTypes.Color.deepPink |> backgroundValue'
        static member deepSkyBlue = FssTypes.Color.deepSkyBlue |> backgroundValue'
        static member dimGrey = FssTypes.Color.dimGrey |> backgroundValue'
        static member dodgerBlue = FssTypes.Color.dodgerBlue |> backgroundValue'
        static member fireBrick = FssTypes.Color.fireBrick |> backgroundValue'
        static member floralWhite = FssTypes.Color.floralWhite |> backgroundValue'
        static member forestGreen = FssTypes.Color.forestGreen |> backgroundValue'
        static member gainsboro = FssTypes.Color.gainsboro |> backgroundValue'
        static member ghostWhite = FssTypes.Color.ghostWhite |> backgroundValue'
        static member gold = FssTypes.Color.gold |> backgroundValue'
        static member goldenrod = FssTypes.Color.goldenrod |> backgroundValue'
        static member greenYellow = FssTypes.Color.greenYellow |> backgroundValue'
        static member grey = FssTypes.Color.grey |> backgroundValue'
        static member honeydew = FssTypes.Color.honeydew |> backgroundValue'
        static member hotPink = FssTypes.Color.hotPink |> backgroundValue'
        static member indianRed = FssTypes.Color.indianRed |> backgroundValue'
        static member indigo = FssTypes.Color.indigo |> backgroundValue'
        static member ivory = FssTypes.Color.ivory |> backgroundValue'
        static member khaki = FssTypes.Color.khaki |> backgroundValue'
        static member lavender = FssTypes.Color.lavender |> backgroundValue'
        static member lavenderBlush = FssTypes.Color.lavenderBlush |> backgroundValue'
        static member lawnGreen = FssTypes.Color.lawnGreen |> backgroundValue'
        static member lemonChiffon = FssTypes.Color.lemonChiffon |> backgroundValue'
        static member lightBlue = FssTypes.Color.lightBlue |> backgroundValue'
        static member lightCoral = FssTypes.Color.lightCoral |> backgroundValue'
        static member lightCyan = FssTypes.Color.lightCyan |> backgroundValue'
        static member lightGoldenrodYellow = FssTypes.Color.lightGoldenrodYellow |> backgroundValue'
        static member lightGray = FssTypes.Color.lightGray |> backgroundValue'
        static member lightGreen = FssTypes.Color.lightGreen |> backgroundValue'
        static member lightGrey = FssTypes.Color.lightGrey |> backgroundValue'
        static member lightPink = FssTypes.Color.lightPink |> backgroundValue'
        static member lightSalmon = FssTypes.Color.lightSalmon |> backgroundValue'
        static member lightSeaGreen = FssTypes.Color.lightSeaGreen |> backgroundValue'
        static member lightSkyBlue = FssTypes.Color.lightSkyBlue |> backgroundValue'
        static member lightSlateGrey = FssTypes.Color.lightSlateGrey |> backgroundValue'
        static member lightSteelBlue = FssTypes.Color.lightSteelBlue |> backgroundValue'
        static member lightYellow = FssTypes.Color.lightYellow |> backgroundValue'
        static member limeGreen = FssTypes.Color.limeGreen |> backgroundValue'
        static member linen = FssTypes.Color.linen |> backgroundValue'
        static member magenta = FssTypes.Color.magenta |> backgroundValue'
        static member mediumAquamarine = FssTypes.Color.mediumAquamarine |> backgroundValue'
        static member mediumBlue = FssTypes.Color.mediumBlue |> backgroundValue'
        static member mediumOrchid = FssTypes.Color.mediumOrchid |> backgroundValue'
        static member mediumPurple = FssTypes.Color.mediumPurple |> backgroundValue'
        static member mediumSeaGreen = FssTypes.Color.mediumSeaGreen |> backgroundValue'
        static member mediumSlateBlue = FssTypes.Color.mediumSlateBlue |> backgroundValue'
        static member mediumSpringGreen = FssTypes.Color.mediumSpringGreen |> backgroundValue'
        static member mediumTurquoise = FssTypes.Color.mediumTurquoise |> backgroundValue'
        static member mediumVioletRed = FssTypes.Color.mediumVioletRed |> backgroundValue'
        static member midnightBlue = FssTypes.Color.midnightBlue |> backgroundValue'
        static member mintCream = FssTypes.Color.mintCream |> backgroundValue'
        static member mistyRose = FssTypes.Color.mistyRose |> backgroundValue'
        static member moccasin = FssTypes.Color.moccasin |> backgroundValue'
        static member navajoWhite = FssTypes.Color.navajoWhite |> backgroundValue'
        static member oldLace = FssTypes.Color.oldLace |> backgroundValue'
        static member olivedrab = FssTypes.Color.olivedrab |> backgroundValue'
        static member orangeRed = FssTypes.Color.orangeRed |> backgroundValue'
        static member orchid = FssTypes.Color.orchid |> backgroundValue'
        static member paleGoldenrod = FssTypes.Color.paleGoldenrod |> backgroundValue'
        static member paleGreen = FssTypes.Color.paleGreen |> backgroundValue'
        static member paleTurquoise = FssTypes.Color.paleTurquoise |> backgroundValue'
        static member paleVioletred = FssTypes.Color.paleVioletred |> backgroundValue'
        static member papayaWhip = FssTypes.Color.papayaWhip |> backgroundValue'
        static member peachpuff = FssTypes.Color.peachpuff |> backgroundValue'
        static member peru = FssTypes.Color.peru |> backgroundValue'
        static member pink = FssTypes.Color.pink |> backgroundValue'
        static member plum = FssTypes.Color.plum |> backgroundValue'
        static member powderBlue = FssTypes.Color.powderBlue |> backgroundValue'
        static member rosyBrown = FssTypes.Color.rosyBrown |> backgroundValue'
        static member royalBlue = FssTypes.Color.royalBlue |> backgroundValue'
        static member saddleBrown = FssTypes.Color.saddleBrown |> backgroundValue'
        static member salmon = FssTypes.Color.salmon |> backgroundValue'
        static member sandyBrown = FssTypes.Color.sandyBrown |> backgroundValue'
        static member seaGreen = FssTypes.Color.seaGreen |> backgroundValue'
        static member seaShell = FssTypes.Color.seaShell |> backgroundValue'
        static member sienna = FssTypes.Color.sienna |> backgroundValue'
        static member skyBlue = FssTypes.Color.skyBlue |> backgroundValue'
        static member slateBlue = FssTypes.Color.slateBlue |> backgroundValue'
        static member slateGray = FssTypes.Color.slateGray |> backgroundValue'
        static member snow = FssTypes.Color.snow |> backgroundValue'
        static member springGreen = FssTypes.Color.springGreen |> backgroundValue'
        static member steelBlue = FssTypes.Color.steelBlue |> backgroundValue'
        static member tan = FssTypes.Color.tan |> backgroundValue'
        static member thistle = FssTypes.Color.thistle |> backgroundValue'
        static member tomato = FssTypes.Color.tomato |> backgroundValue'
        static member turquoise = FssTypes.Color.turquoise |> backgroundValue'
        static member violet = FssTypes.Color.violet |> backgroundValue'
        static member wheat = FssTypes.Color.wheat |> backgroundValue'
        static member whiteSmoke = FssTypes.Color.whiteSmoke |> backgroundValue'
        static member yellowGreen = FssTypes.Color.yellowGreen |> backgroundValue'
        static member rebeccaPurple = FssTypes.Color.rebeccaPurple |> backgroundValue'
        static member Rgb r g b = FssTypes.Color.Rgb(r, g, b) |> backgroundValue'
        static member Rgba r g b a = FssTypes.Color.Rgba(r, g, b, a) |> backgroundValue'
        static member Hex value = FssTypes.Color.Hex value |> backgroundValue'
        static member Hsl h s l = FssTypes.Color.Hsl(h, s, l) |> backgroundValue'
        static member Hsla h s l a  = FssTypes.Color.Hsla (h, s, l, a) |> backgroundValue'
        static member transparent = FssTypes.Color.transparent |> backgroundValue'
        static member currentColor = FssTypes.Color.currentColor |> backgroundValue'

    /// <summary>Specifies how background color.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> FssTypes.ColorTypeFoo</c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundColor' (color: FssTypes.ColorTypeFoo) = BackgroundColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    let private imageValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundImage value
    type BackgroundImage =
        static member Value (image: FssTypes.Image.Image) = image |> imageValue
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url

        static member LinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorTypeFoo * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorTypeFoo * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorTypeFoo * FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorTypeFoo * FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorTypeFoo * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorTypeFoo * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorTypeFoo * FssTypes.Size) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorTypeFoo * FssTypes.Percent) list)) list) =
            imageValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorTypeFoo * FssTypes.Percent) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorTypeFoo * FssTypes.Size) list) list) =
            imageValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Size) list) =
            imageValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)

        static member ConicGradient (angle: FssTypes.Angle, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Angle) list) =
            imageValue <| FssTypes.Image.Image.ConicGradient(angle, x, y, gradients)
        static member RepeatingConicGradient (angle: FssTypes.Angle, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Angle) list) =
            imageValue <| FssTypes.Image.Image.RepeatingConicGradient(angle, x, y, gradients)
        static member ConicGradient (angle: FssTypes.Angle, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.ConicGradient(angle, x, y, gradients)
        static member RepeatingConicGradient (angle: FssTypes.Angle, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorTypeFoo * FssTypes.Percent) list) =
            imageValue <| FssTypes.Image.Image.RepeatingConicGradient(angle, x, y, gradients)

    /// <summary>Draws background image on element.</summary>
    /// <param name="image">
    ///     can be:
    ///     - <c> Image </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundImage' (image: FssTypes.Image.Image) = BackgroundImage.Value(image)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
    let private positionCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundPosition value
    let private positionCssValue' value =
        value
        |> positionToString
        |> positionCssValue

    type BackgroundPosition =
        static member Top = FssTypes.Background.Position.Top |> positionCssValue'
        static member Bottom = FssTypes.Background.Position.Bottom |> positionCssValue'
        static member Left = FssTypes.Background.Position.Left |> positionCssValue'
        static member Right = FssTypes.Background.Position.Right |> positionCssValue'
        static member Center = FssTypes.Background.Position.Center |> positionCssValue'

        static member Value (value: FssTypes.IBackgroundPosition) = value |> positionCssValue'
        static member Values (v1: FssTypes.IBackgroundPosition, v2: FssTypes.IBackgroundPosition) =
            sprintf "%s %s" (positionToString v1) (positionToString v2) |> positionCssValue
        static member Values (v1: FssTypes.IBackgroundPosition, v2: FssTypes.IBackgroundPosition, v3: FssTypes.IBackgroundPosition) =
            sprintf "%s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) |> positionCssValue
        static member Values (v1: FssTypes.IBackgroundPosition, v2: FssTypes.IBackgroundPosition, v3: FssTypes.IBackgroundPosition, v4: FssTypes.IBackgroundPosition) =
            sprintf "%s %s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) (positionToString v4) |> positionCssValue

        static member Inherit = FssTypes.Inherit |> positionCssValue'
        static member Initial = FssTypes.Initial |> positionCssValue'
        static member Unset = FssTypes.Unset |> positionCssValue'

    /// <summary>Specifies the position of a background.</summary>
    /// <param name="position">
    ///     can be:
    ///     - <c> BackgroundPosition </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundPosition' (position: FssTypes.IBackgroundPosition) = BackgroundPosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-blend-mode
    let private blendModeCssValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundBlendMode value
    let private blendModeCssValue' value =
        value
        |> blendModeToString
        |> blendModeCssValue

    let private blendModeValues (values: FssTypes.Background.BlendMode list) =
        values
        |> Utilities.Helpers.combineComma blendModeToString
        |> blendModeCssValue

    type BackgroundBlendMode =
        static member Value(blendMode: FssTypes.IBackgroundBlendMode) = blendMode |> blendModeCssValue'
        static member Values(blendModes: FssTypes.Background.BlendMode list) = blendModeValues blendModes

        static member Multiply = FssTypes.Background.BlendMode.Multiply |> blendModeCssValue'
        static member Screen = FssTypes.Background.BlendMode.Screen |> blendModeCssValue'
        static member Overlay = FssTypes.Background.BlendMode.Overlay |> blendModeCssValue'
        static member Darken = FssTypes.Background.BlendMode.Darken |> blendModeCssValue'
        static member Lighten = FssTypes.Background.BlendMode.Lighten |> blendModeCssValue'
        static member ColorDodge = FssTypes.Background.BlendMode.ColorDodge |> blendModeCssValue'
        static member ColorBurn = FssTypes.Background.BlendMode.ColorBurn |> blendModeCssValue'
        static member HardLight = FssTypes.Background.BlendMode.HardLight |> blendModeCssValue'
        static member SoftLight = FssTypes.Background.BlendMode.SoftLight |> blendModeCssValue'
        static member Difference = FssTypes.Background.BlendMode.Difference |> blendModeCssValue'
        static member Exclusion = FssTypes.Background.BlendMode.Exclusion |> blendModeCssValue'
        static member Hue = FssTypes.Background.BlendMode.Hue |> blendModeCssValue'
        static member Saturation = FssTypes.Background.BlendMode.Saturation |> blendModeCssValue'
        static member Color = FssTypes.Background.BlendMode.Color |> blendModeCssValue'
        static member Luminosity = FssTypes.Background.BlendMode.Luminosity |> blendModeCssValue'

        static member Normal = FssTypes.Normal |> blendModeCssValue'
        static member Inherit = FssTypes.Inherit |> blendModeCssValue'
        static member Initial = FssTypes.Initial |> blendModeCssValue'
        static member Unset = FssTypes.Unset |> blendModeCssValue'

    /// <summary>Specifies how an elements background image should interact with its background color.</summary>
    /// <param name="backgroundBlendMode">
    ///     can be:
    ///     - <c> BackgroundBlendMode </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundBlendMode' (backgroundBlendMode: FssTypes.IBackgroundBlendMode) = backgroundBlendMode |> BackgroundBlendMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/isolation
    let private isolationValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Isolation value
    let private isolationValue' value =
        value
        |> isolationToString
        |> isolationValue

    type Isolation =
        static member Value(isolation: FssTypes.IIsolation) = isolation |> isolationValue'

        static member Isolate = FssTypes.Background.Isolate |> isolationValue'
        static member Auto = FssTypes.Auto |> isolationValue'
        static member Inherit = FssTypes.Inherit |> isolationValue'
        static member Initial = FssTypes.Initial |> isolationValue'
        static member Unset = FssTypes.Unset |> isolationValue'


    /// <summary>Specifies how an element is blended with backdrop.</summary>
    /// <param name="isolation">
    ///     can be:
    ///     - <c> Isolation </c>
    ///     - <c> Auto </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Isolation' (isolation: FssTypes.IIsolation) = isolation |> Isolation.Value

[<AutoOpen>]
module BoxDecorationBreak =
    let private boxDecorationBreakToString (boxDecoration: FssTypes.IBoxDecorationBreak) =
        match boxDecoration with
        | :? FssTypes.Background.BoxDecorationBreak as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown box decoration break"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-decoration-break
    let private boxDecorationBreakValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BoxDecorationBreak value
    let private boxDecorationBreakValue' value =
        value
        |> boxDecorationBreakToString
        |> boxDecorationBreakValue

    type BoxDecorationBreak =
        static member Value(boxDecorationBreak: FssTypes.IBoxDecorationBreak) = boxDecorationBreak |> boxDecorationBreakValue'

        static member Slice = FssTypes.Background.Slice |> boxDecorationBreakValue'
        static member Clone = FssTypes.Background.Clone |> boxDecorationBreakValue'
        static member Inherit = FssTypes.Inherit |> boxDecorationBreakValue'
        static member Initial = FssTypes.Initial |> boxDecorationBreakValue'
        static member Unset = FssTypes.Unset |> boxDecorationBreakValue'


    /// <summary>Specifies how an element is blended with backdrop.</summary>
    /// <param name="boxDecorationBreak">
    ///     can be:
    ///     - <c> BoxDecorationBreak </c>
    ///     - <c> Auto </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BoxDecorationBreak' (boxDecorationBreak: FssTypes.IBoxDecorationBreak) = boxDecorationBreak |> BoxDecorationBreak.Value


