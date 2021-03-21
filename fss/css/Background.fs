namespace Fss

[<AutoOpen>]
module Background =

    let private backgroundClipToString (clip: Types.IBackgroundClip) =
        match clip with
        | :? Types.BackgroundClip as b -> Utilities.Helpers.duToKebab b
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown background clip"

    let private backgroundOriginToString (clip: Types.IBackgroundOrigin) =
        match clip with
        | :? Types.BackgroundOrigin as b -> Utilities.Helpers.duToKebab b
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "unknown background origin"

    let private repeatToString (repeat: Types.IBackgroundRepeat) =
        match repeat with
        | :? Types.BackgroundRepeat as b -> Utilities.Helpers.duToKebab b
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "unknown background repeat"

    let private sizeToString (size: Types.IBackgroundSize) =
        match size with
        | :? Types.BackgroundSize as b -> Utilities.Helpers.duToLowercase b
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Auto -> Types.auto
        | _ -> "Unknown background size"

    let private attachmentToString (attachment: Types.IBackgroundAttachment) =
        match attachment with
        | :? Types.BackgroundAttachment as b -> Utilities.Helpers.duToLowercase b
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown background attachment"

    let private positionToString (position: Types.IBackgroundPosition) =
        match position with
        | :? Types.BackgroundPosition as b -> Utilities.Helpers.duToLowercase b
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Size as s -> Types.sizeToString s
        | :? Types.Percent as p -> Types.percentToString p
        | _ -> "Unknown background position"

    let private blendModeToString (blendMode: Types.IBackgroundBlendMode) =
        match blendMode with
        | :? Types.BackgroundBlendMode as b -> Utilities.Helpers.duToKebab b
        | :? Types.Normal -> Types.normal
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown background blend mode"

    let private isolationToString (isolation: Types.IIsolation) =
        match isolation with
        | :? Types.Isolation as i -> "isolate"
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.Auto -> Types.auto
        | _ -> "Unknown isolation"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    let private clipValue value = Types.cssValue Types.Property.BackgroundClip value
    let private clipValue' value =
        value
        |> backgroundClipToString
        |> clipValue

    type BackgroundClip =
        static member Value (clip: Types.IBackgroundClip) = clip |> clipValue'
        static member BorderBox = Types.BackgroundClip.BorderBox |> clipValue'
        static member PaddingBox = Types.BackgroundClip.PaddingBox |> clipValue'
        static member ContentBox = Types.BackgroundClip.ContentBox |> clipValue'
        static member Text = Types.BackgroundClip.Text |> clipValue'

        static member Inherit = Types.Inherit |> clipValue'
        static member Initial = Types.Initial |> clipValue'
        static member Unset = Types.Unset |> clipValue'

    /// <summary>Specifies how an element's background extends.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> BackgroundClip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundClip' (clip: Types.IBackgroundClip) = BackgroundClip.Value(clip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    let private originValue value = Types.cssValue Types.Property.BackgroundOrigin value
    let private originValue' value =
        value
        |> backgroundOriginToString
        |> originValue
    type BackgroundOrigin =
       static member Value (origin: Types.IBackgroundOrigin) = origin |> originValue'
       static member BorderBox = Types.BackgroundOrigin.BorderBox |> originValue'
       static member PaddingBox = Types.BackgroundOrigin.PaddingBox |> originValue'
       static member ContentBox = Types.BackgroundOrigin.ContentBox |> originValue'

       static member Inherit = Types.Inherit |> originValue'
       static member Initial = Types.Initial |> originValue'
       static member Unset = Types.Unset |> originValue'

    /// <summary>Sets background origin.</summary>
    /// <param name="origin">
    ///     can be:
    ///     - <c> BackgroundOrigin </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundOrigin' (origin: Types.IBackgroundOrigin) = BackgroundOrigin.Value(origin)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    let private repeatValue value = Types.cssValue Types.Property.BackgroundRepeat value
    let private repeatValue' value =
        value
        |> repeatToString
        |> repeatValue

    type BackgroundRepeat =
        static member Value (repeat: Types.IBackgroundRepeat) = repeat |> repeatValue'
        static member Value (v1: Types.IBackgroundRepeat, v2: Types.IBackgroundRepeat) =
            sprintf "%s %s" (repeatToString v1) (repeatToString v2)
            |> repeatValue
        static member RepeatX = Types.BackgroundRepeat.RepeatX |> repeatValue'
        static member RepeatY = Types.BackgroundRepeat.RepeatY |> repeatValue'
        static member Repeat = Types.BackgroundRepeat.Repeat |> repeatValue'
        static member Space = Types.BackgroundRepeat.Space |> repeatValue'
        static member Round = Types.BackgroundRepeat.Round |> repeatValue'
        static member NoRepeat = Types.BackgroundRepeat.NoRepeat |> repeatValue'

        static member Inherit = Types.Inherit |> repeatValue'
        static member Initial = Types.Initial |> repeatValue'
        static member Unset = Types.Unset |> repeatValue'

    /// <summary>Specifies how background is repeated.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> BackgroundRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundRepeat' (repeat: Types.IBackgroundRepeat) = BackgroundRepeat.Value(repeat)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    let private sizeValue value = Types.cssValue Types.Property.BackgroundSize value
    let private sizeValue' value =
        value
        |> sizeToString
        |> sizeValue
    type BackgroundSize =
        static member Value (size: Types.IBackgroundSize) = size |> sizeValue'
        static member Value (s1: Types.IBackgroundSize, s2: Types.IBackgroundSize) =
            sprintf "%s %s" (sizeToString s1) (sizeToString s2)
                |> sizeValue

        static member Cover = Types.BackgroundSize.Cover |> sizeValue'
        static member Contain = Types.BackgroundSize.Contain |> sizeValue'

        static member Auto = Types.Auto |> sizeValue'
        static member Inherit = Types.Inherit |> sizeValue'
        static member Initial = Types.Initial |> sizeValue'
        static member Unset = Types.Unset |> sizeValue'

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
    let BackgroundSize' (size: Types.IBackgroundSize) = BackgroundSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    let private attachmentValue value = Types.cssValue Types.Property.BackgroundAttachment value
    let private attachmentValue' value =
        value
        |> attachmentToString
        |> attachmentValue
    type BackgroundAttachment =
        static member Value (attachment: Types.IBackgroundAttachment) = attachment |> attachmentValue'
        static member Scroll = Types.BackgroundAttachment.Scroll |> attachmentValue'
        static member Fixed = Types.BackgroundAttachment.Fixed |> attachmentValue'
        static member Local = Types.BackgroundAttachment.Local |> attachmentValue'

        static member Inherit = Types.Inherit |> attachmentValue'
        static member Initial = Types.Initial |> attachmentValue'
        static member Unset = Types.Unset |> attachmentValue'

    /// <summary>Specifies how background is fixed within viewport.</summary>
    /// <param name="attachment">
    ///     can be:
    ///     - <c> BackgroundAttachment </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundAttachment' (attachment: Types.IBackgroundAttachment) = BackgroundAttachment.Value(attachment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-color
    let private backgroundValue value = Types.cssValue Types.Property.BackgroundColor value
    let private backgroundValue' value =
        value
        |> Types.colorToString
        |> backgroundValue
    type BackgroundColor =
        static member Value (color: Types.Color) = color |> backgroundValue'
        static member black = Types.Color.black |> backgroundValue'
        static member silver = Types.Color.silver |> backgroundValue'
        static member gray = Types.Color.gray |> backgroundValue'
        static member white = Types.Color.white |> backgroundValue'
        static member maroon = Types.Color.maroon |> backgroundValue'
        static member red = Types.Color.red |> backgroundValue'
        static member purple = Types.Color.purple |> backgroundValue'
        static member fuchsia = Types.Color.fuchsia |> backgroundValue'
        static member green = Types.Color.green |> backgroundValue'
        static member lime = Types.Color.lime |> backgroundValue'
        static member olive = Types.Color.olive |> backgroundValue'
        static member yellow = Types.Color.yellow |> backgroundValue'
        static member navy = Types.Color.navy |> backgroundValue'
        static member blue = Types.Color.blue |> backgroundValue'
        static member teal = Types.Color.teal |> backgroundValue'
        static member aqua = Types.Color.aqua |> backgroundValue'
        static member orange = Types.Color.orange |> backgroundValue'
        static member aliceBlue = Types.Color.aliceBlue |> backgroundValue'
        static member antiqueWhite = Types.Color.antiqueWhite |> backgroundValue'
        static member aquaMarine = Types.Color.aquaMarine |> backgroundValue'
        static member azure = Types.Color.azure |> backgroundValue'
        static member beige = Types.Color.beige |> backgroundValue'
        static member bisque = Types.Color.bisque |> backgroundValue'
        static member blanchedAlmond = Types.Color.blanchedAlmond |> backgroundValue'
        static member blueViolet = Types.Color.blueViolet |> backgroundValue'
        static member brown = Types.Color.brown |> backgroundValue'
        static member burlywood = Types.Color.burlywood |> backgroundValue'
        static member cadetBlue = Types.Color.cadetBlue |> backgroundValue'
        static member chartreuse = Types.Color.chartreuse |> backgroundValue'
        static member chocolate = Types.Color.chocolate |> backgroundValue'
        static member coral = Types.Color.coral |> backgroundValue'
        static member cornflowerBlue = Types.Color.cornflowerBlue |> backgroundValue'
        static member cornsilk = Types.Color.cornsilk |> backgroundValue'
        static member crimson = Types.Color.crimson |> backgroundValue'
        static member cyan = Types.Color.cyan |> backgroundValue'
        static member darkBlue = Types.Color.darkBlue |> backgroundValue'
        static member darkCyan = Types.Color.darkCyan |> backgroundValue'
        static member darkGoldenrod = Types.Color.darkGoldenrod |> backgroundValue'
        static member darkGray = Types.Color.darkGray |> backgroundValue'
        static member darkGreen = Types.Color.darkGreen |> backgroundValue'
        static member darkKhaki = Types.Color.darkKhaki |> backgroundValue'
        static member darkMagenta = Types.Color.darkMagenta |> backgroundValue'
        static member darkOliveGreen = Types.Color.darkOliveGreen |> backgroundValue'
        static member darkOrange = Types.Color.darkOrange |> backgroundValue'
        static member darkOrchid = Types.Color.darkOrchid |> backgroundValue'
        static member darkRed = Types.Color.darkRed |> backgroundValue'
        static member darkSalmon = Types.Color.darkSalmon |> backgroundValue'
        static member darkSeaGreen = Types.Color.darkSeaGreen |> backgroundValue'
        static member darkSlateBlue = Types.Color.darkSlateBlue |> backgroundValue'
        static member darkSlateGray = Types.Color.darkSlateGray |> backgroundValue'
        static member darkTurquoise = Types.Color.darkTurquoise |> backgroundValue'
        static member darkViolet = Types.Color.darkViolet |> backgroundValue'
        static member deepPink = Types.Color.deepPink |> backgroundValue'
        static member deepSkyBlue = Types.Color.deepSkyBlue |> backgroundValue'
        static member dimGrey = Types.Color.dimGrey |> backgroundValue'
        static member dodgerBlue = Types.Color.dodgerBlue |> backgroundValue'
        static member fireBrick = Types.Color.fireBrick |> backgroundValue'
        static member floralWhite = Types.Color.floralWhite |> backgroundValue'
        static member forestGreen = Types.Color.forestGreen |> backgroundValue'
        static member gainsboro = Types.Color.gainsboro |> backgroundValue'
        static member ghostWhite = Types.Color.ghostWhite |> backgroundValue'
        static member gold = Types.Color.gold |> backgroundValue'
        static member goldenrod = Types.Color.goldenrod |> backgroundValue'
        static member greenYellow = Types.Color.greenYellow |> backgroundValue'
        static member grey = Types.Color.grey |> backgroundValue'
        static member honeydew = Types.Color.honeydew |> backgroundValue'
        static member hotPink = Types.Color.hotPink |> backgroundValue'
        static member indianRed = Types.Color.indianRed |> backgroundValue'
        static member indigo = Types.Color.indigo |> backgroundValue'
        static member ivory = Types.Color.ivory |> backgroundValue'
        static member khaki = Types.Color.khaki |> backgroundValue'
        static member lavender = Types.Color.lavender |> backgroundValue'
        static member lavenderBlush = Types.Color.lavenderBlush |> backgroundValue'
        static member lawnGreen = Types.Color.lawnGreen |> backgroundValue'
        static member lemonChiffon = Types.Color.lemonChiffon |> backgroundValue'
        static member lightBlue = Types.Color.lightBlue |> backgroundValue'
        static member lightCoral = Types.Color.lightCoral |> backgroundValue'
        static member lightCyan = Types.Color.lightCyan |> backgroundValue'
        static member lightGoldenrodYellow = Types.Color.lightGoldenrodYellow |> backgroundValue'
        static member lightGray = Types.Color.lightGray |> backgroundValue'
        static member lightGreen = Types.Color.lightGreen |> backgroundValue'
        static member lightGrey = Types.Color.lightGrey |> backgroundValue'
        static member lightPink = Types.Color.lightPink |> backgroundValue'
        static member lightSalmon = Types.Color.lightSalmon |> backgroundValue'
        static member lightSeaGreen = Types.Color.lightSeaGreen |> backgroundValue'
        static member lightSkyBlue = Types.Color.lightSkyBlue |> backgroundValue'
        static member lightSlateGrey = Types.Color.lightSlateGrey |> backgroundValue'
        static member lightSteelBlue = Types.Color.lightSteelBlue |> backgroundValue'
        static member lightYellow = Types.Color.lightYellow |> backgroundValue'
        static member limeGreen = Types.Color.limeGreen |> backgroundValue'
        static member linen = Types.Color.linen |> backgroundValue'
        static member magenta = Types.Color.magenta |> backgroundValue'
        static member mediumAquamarine = Types.Color.mediumAquamarine |> backgroundValue'
        static member mediumBlue = Types.Color.mediumBlue |> backgroundValue'
        static member mediumOrchid = Types.Color.mediumOrchid |> backgroundValue'
        static member mediumPurple = Types.Color.mediumPurple |> backgroundValue'
        static member mediumSeaGreen = Types.Color.mediumSeaGreen |> backgroundValue'
        static member mediumSlateBlue = Types.Color.mediumSlateBlue |> backgroundValue'
        static member mediumSpringGreen = Types.Color.mediumSpringGreen |> backgroundValue'
        static member mediumTurquoise = Types.Color.mediumTurquoise |> backgroundValue'
        static member mediumVioletRed = Types.Color.mediumVioletRed |> backgroundValue'
        static member midnightBlue = Types.Color.midnightBlue |> backgroundValue'
        static member mintCream = Types.Color.mintCream |> backgroundValue'
        static member mistyRose = Types.Color.mistyRose |> backgroundValue'
        static member moccasin = Types.Color.moccasin |> backgroundValue'
        static member navajoWhite = Types.Color.navajoWhite |> backgroundValue'
        static member oldLace = Types.Color.oldLace |> backgroundValue'
        static member olivedrab = Types.Color.olivedrab |> backgroundValue'
        static member orangeRed = Types.Color.orangeRed |> backgroundValue'
        static member orchid = Types.Color.orchid |> backgroundValue'
        static member paleGoldenrod = Types.Color.paleGoldenrod |> backgroundValue'
        static member paleGreen = Types.Color.paleGreen |> backgroundValue'
        static member paleTurquoise = Types.Color.paleTurquoise |> backgroundValue'
        static member paleVioletred = Types.Color.paleVioletred |> backgroundValue'
        static member papayaWhip = Types.Color.papayaWhip |> backgroundValue'
        static member peachpuff = Types.Color.peachpuff |> backgroundValue'
        static member peru = Types.Color.peru |> backgroundValue'
        static member pink = Types.Color.pink |> backgroundValue'
        static member plum = Types.Color.plum |> backgroundValue'
        static member powderBlue = Types.Color.powderBlue |> backgroundValue'
        static member rosyBrown = Types.Color.rosyBrown |> backgroundValue'
        static member royalBlue = Types.Color.royalBlue |> backgroundValue'
        static member saddleBrown = Types.Color.saddleBrown |> backgroundValue'
        static member salmon = Types.Color.salmon |> backgroundValue'
        static member sandyBrown = Types.Color.sandyBrown |> backgroundValue'
        static member seaGreen = Types.Color.seaGreen |> backgroundValue'
        static member seaShell = Types.Color.seaShell |> backgroundValue'
        static member sienna = Types.Color.sienna |> backgroundValue'
        static member skyBlue = Types.Color.skyBlue |> backgroundValue'
        static member slateBlue = Types.Color.slateBlue |> backgroundValue'
        static member slateGray = Types.Color.slateGray |> backgroundValue'
        static member snow = Types.Color.snow |> backgroundValue'
        static member springGreen = Types.Color.springGreen |> backgroundValue'
        static member steelBlue = Types.Color.steelBlue |> backgroundValue'
        static member tan = Types.Color.tan |> backgroundValue'
        static member thistle = Types.Color.thistle |> backgroundValue'
        static member tomato = Types.Color.tomato |> backgroundValue'
        static member turquoise = Types.Color.turquoise |> backgroundValue'
        static member violet = Types.Color.violet |> backgroundValue'
        static member wheat = Types.Color.wheat |> backgroundValue'
        static member whiteSmoke = Types.Color.whiteSmoke |> backgroundValue'
        static member yellowGreen = Types.Color.yellowGreen |> backgroundValue'
        static member rebeccaPurple = Types.Color.rebeccaPurple |> backgroundValue'
        static member Rgb r g b = Types.Color.Rgb(r, g, b) |> backgroundValue'
        static member Rgba r g b a = Types.Color.Rgba(r, g, b, a) |> backgroundValue'
        static member Hex value = Types.Color.Hex value |> backgroundValue'
        static member Hsl h s l = Types.Color.Hsl(h, s, l) |> backgroundValue'
        static member Hsla h s l a  = Types.Color.Hsla (h, s, l, a) |> backgroundValue'
        static member transparent = Types.Color.transparent |> backgroundValue'
        static member currentColor = Types.Color.currentColor |> backgroundValue'

    /// <summary>Specifies how background color.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> Types.Color </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundColor' (color: Types.Color) = BackgroundColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    let private imageValue value = Types.cssValue Types.Property.BackgroundImage value
    type BackgroundImage =
        static member Value (image: Image.Image) = image |> imageValue
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

        static member ConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Angle) list) =
            imageValue <| Image.Image.ConicGradient(angle, x, y, gradients)
        static member RepeatingConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Angle) list) =
            imageValue <| Image.Image.RepeatingConicGradient(angle, x, y, gradients)
        static member ConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Image.Image.ConicGradient(angle, x, y, gradients)
        static member RepeatingConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            imageValue <| Image.Image.RepeatingConicGradient(angle, x, y, gradients)

    /// <summary>Draws background image on element.</summary>
    /// <param name="image">
    ///     can be:
    ///     - <c> Image </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundImage' (image: Image.Image) = BackgroundImage.Value(image)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
    let private positionCssValue value = Types.cssValue Types.Property.BackgroundPosition value
    let private positionCssValue' value =
        value
        |> positionToString
        |> positionCssValue

    type BackgroundPosition =
        static member Top = Types.BackgroundPosition.Top |> positionCssValue'
        static member Bottom = Types.BackgroundPosition.Bottom |> positionCssValue'
        static member Left = Types.BackgroundPosition.Left |> positionCssValue'
        static member Right = Types.BackgroundPosition.Right |> positionCssValue'
        static member Center = Types.BackgroundPosition.Center |> positionCssValue'

        static member Value (value: Types.IBackgroundPosition) = value |> positionCssValue'
        static member Values (v1: Types.IBackgroundPosition, v2: Types.IBackgroundPosition) =
            sprintf "%s %s" (positionToString v1) (positionToString v2) |> positionCssValue
        static member Values (v1: Types.IBackgroundPosition, v2: Types.IBackgroundPosition, v3: Types.IBackgroundPosition) =
            sprintf "%s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) |> positionCssValue
        static member Values (v1: Types.IBackgroundPosition, v2: Types.IBackgroundPosition, v3: Types.IBackgroundPosition, v4: Types.IBackgroundPosition) =
            sprintf "%s %s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) (positionToString v4) |> positionCssValue

        static member Inherit = Types.Inherit |> positionCssValue'
        static member Initial = Types.Initial |> positionCssValue'
        static member Unset = Types.Unset |> positionCssValue'

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
    let BackgroundPosition' (position: Types.IBackgroundPosition) = BackgroundPosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-blend-mode
    let private blendModeCssValue value = Types.cssValue Types.Property.BackgroundBlendMode value
    let private blendModeCssValue' value =
        value
        |> blendModeToString
        |> blendModeCssValue

    let private blendModeValues (values: Types.BackgroundBlendMode list) =
        values
        |> Utilities.Helpers.combineComma blendModeToString
        |> blendModeCssValue

    type BackgroundBlendMode =
        static member Value(blendMode: Types.IBackgroundBlendMode) = blendMode |> blendModeCssValue'
        static member Values(blendModes: Types.BackgroundBlendMode list) = blendModeValues blendModes

        static member Multiply = Types.BackgroundBlendMode.Multiply |> blendModeCssValue'
        static member Screen = Types.BackgroundBlendMode.Screen |> blendModeCssValue'
        static member Overlay = Types.BackgroundBlendMode.Overlay |> blendModeCssValue'
        static member Darken = Types.BackgroundBlendMode.Darken |> blendModeCssValue'
        static member Lighten = Types.BackgroundBlendMode.Lighten |> blendModeCssValue'
        static member ColorDodge = Types.BackgroundBlendMode.ColorDodge |> blendModeCssValue'
        static member ColorBurn = Types.BackgroundBlendMode.ColorBurn |> blendModeCssValue'
        static member HardLight = Types.BackgroundBlendMode.HardLight |> blendModeCssValue'
        static member SoftLight = Types.BackgroundBlendMode.SoftLight |> blendModeCssValue'
        static member Difference = Types.BackgroundBlendMode.Difference |> blendModeCssValue'
        static member Exclusion = Types.BackgroundBlendMode.Exclusion |> blendModeCssValue'
        static member Hue = Types.BackgroundBlendMode.Hue |> blendModeCssValue'
        static member Saturation = Types.BackgroundBlendMode.Saturation |> blendModeCssValue'
        static member Color = Types.BackgroundBlendMode.Color' |> blendModeCssValue'
        static member Luminosity = Types.BackgroundBlendMode.Luminosity |> blendModeCssValue'

        static member Normal = Types.Normal |> blendModeCssValue'
        static member Inherit = Types.Inherit |> blendModeCssValue'
        static member Initial = Types.Initial |> blendModeCssValue'
        static member Unset = Types.Unset |> blendModeCssValue'

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
    let BackgroundBlendMode' (backgroundBlendMode: Types.IBackgroundBlendMode) = backgroundBlendMode |> BackgroundBlendMode.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/isolation
    let private isolationValue value = Types.cssValue Types.Property.Isolation value
    let private isolationValue' value =
        value
        |> isolationToString
        |> isolationValue

    type Isolation =
        static member Value(isolation: Types.IIsolation) = isolation |> isolationValue'

        static member Isolate = Types.Isolate |> isolationValue'
        static member Auto = Types.Auto |> isolationValue'
        static member Inherit = Types.Inherit |> isolationValue'
        static member Initial = Types.Initial |> isolationValue'
        static member Unset = Types.Unset |> isolationValue'


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
    let Isolation' (isolation: Types.IIsolation) = isolation |> Isolation.Value

[<AutoOpen>]
module BoxDecorationBreak =
    let private boxDecorationBreakToString (boxDecoration: Types.IBoxDecorationBreak) =
        match boxDecoration with
        | :? Types.BoxDecorationBreak as b -> Utilities.Helpers.duToLowercase b
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown box decoration break"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-decoration-break
    let private boxDecorationBreakValue value = Types.cssValue Types.Property.BoxDecorationBreak value
    let private boxDecorationBreakValue' value =
        value
        |> boxDecorationBreakToString
        |> boxDecorationBreakValue

    type BoxDecorationBreak =
        static member Value(boxDecorationBreak: Types.IBoxDecorationBreak) = boxDecorationBreak |> boxDecorationBreakValue'

        static member Slice = Types.Slice |> boxDecorationBreakValue'
        static member Clone = Types.Clone |> boxDecorationBreakValue'
        static member Inherit = Types.Inherit |> boxDecorationBreakValue'
        static member Initial = Types.Initial |> boxDecorationBreakValue'
        static member Unset = Types.Unset |> boxDecorationBreakValue'


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
    let BoxDecorationBreak' (boxDecorationBreak: Types.IBoxDecorationBreak) = boxDecorationBreak |> BoxDecorationBreak.Value


