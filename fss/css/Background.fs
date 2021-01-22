namespace Fss

open Fss.CssColor
open Fss.Image

module BackgroundType =
    type BackgroundClip =
        | BorderBox
        | PaddingBox
        | ContentBox
        | Text
        interface IBackgroundClip

    type BackgroundOrigin =
        | BorderBox
        | PaddingBox
        | ContentBox
        interface IBackgroundOrigin

    type BackgroundRepeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface IBackgroundRepeat

    type BackgroundSize =
        | Cover
        | Contain
        interface IBackgroundSize

    type BackgroundAttachment =
        | Scroll
        | Fixed
        | Local
        interface IBackgroundAttachment

    type BackgroundPosition =
        | Top
        | Bottom
        | Left
        | Right
        | Center
        interface IBackgroundPosition

    type BackgroundBlendMode =
        | Multiply
        | Screen
        | Overlay
        | Darken
        | Lighten
        | ColorDodge
        | HardLight
        | SoftLight
        | Difference
        | Exclusion
        | Hue
        | Saturation
        | Color
        | Luminosity
        interface IBackgroundBlendMode

[<AutoOpen>]
module Background =
    open BackgroundType

    let private backgroundClipToString (clip: IBackgroundClip) =
        match clip with
        | :? BackgroundClip as b -> Utilities.Helpers.duToKebab b
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown background clip"

    let private backgroundOriginToString (clip: IBackgroundOrigin) =
        match clip with
        | :? BackgroundOrigin as b -> Utilities.Helpers.duToKebab b
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown background origin"

    let private repeatToString (repeat: IBackgroundRepeat) =
        match repeat with
        | :? BackgroundRepeat as b -> Utilities.Helpers.duToKebab b
        | :? Global as g -> GlobalValue.global' g
        | _ -> "unknown background repeat"

    let private sizeToString (size: IBackgroundSize) =
        match size with
        | :? BackgroundSize as b -> Utilities.Helpers.duToLowercase b
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown background size"

    let private attachmentToString (attachment: IBackgroundAttachment) =
        match attachment with
        | :? BackgroundAttachment as b -> Utilities.Helpers.duToLowercase b
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown background attachment"

    let private positionToString (position: IBackgroundPosition) =
        match position with
        | :? BackgroundPosition as b -> Utilities.Helpers.duToLowercase b
        | :? Global as g -> GlobalValue.global' g
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown background position"

    let private blendModeToString (blendMode: IBackgroundBlendMode) =
        match blendMode with
        | :? BackgroundBlendMode as b -> Utilities.Helpers.duToKebab b
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown background blend mode"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    let private clipValue value = PropertyValue.cssValue Property.BackgroundClip value
    let private clipValue' value =
        value
        |> backgroundClipToString
        |> clipValue

    type BackgroundClip =
        static member Value (clip: IBackgroundClip) = clip |> clipValue'
        static member BorderBox = BackgroundType.BorderBox |> clipValue'
        static member PaddingBox = BackgroundType.PaddingBox |> clipValue'
        static member ContentBox = BackgroundType.ContentBox |> clipValue'
        static member Text = Text |> clipValue'

        static member Inherit = Inherit |> clipValue'
        static member Initial = Initial |> clipValue'
        static member Unset = Unset |> clipValue'

    /// <summary>Specifies how an element's background extends.</summary>
    /// <param name="clip">
    ///     can be:
    ///     - <c> BackgroundClip </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundClip' (clip: IBackgroundClip) = BackgroundClip.Value(clip)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    let private originValue value = PropertyValue.cssValue Property.BackgroundOrigin value
    let private originValue' value =
        value
        |> backgroundOriginToString
        |> originValue
    type BackgroundOrigin =
       static member Value (origin: IBackgroundOrigin) = origin |> originValue'
       static member BorderBox = BorderBox |> originValue'
       static member PaddingBox = PaddingBox |> originValue'
       static member ContentBox = ContentBox |> originValue'

       static member Inherit = Inherit |> originValue'
       static member Initial = Initial |> originValue'
       static member Unset = Unset |> originValue'

    /// <summary>Sets background origin.</summary>
    /// <param name="origin">
    ///     can be:
    ///     - <c> BackgroundOrigin </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundOrigin' (origin: IBackgroundOrigin) = BackgroundOrigin.Value(origin)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    let private repeatValue value = PropertyValue.cssValue Property.BackgroundRepeat value
    let private repeatValue' value =
        value
        |> repeatToString
        |> repeatValue

    type BackgroundRepeat =
        static member Value (repeat: IBackgroundRepeat) = repeat |> repeatValue'
        static member Value (v1: IBackgroundRepeat, v2: IBackgroundRepeat) =
            sprintf "%s %s" (repeatToString v1) (repeatToString v2)
            |> repeatValue
        static member RepeatX = RepeatX |> repeatValue'
        static member RepeatY = RepeatY |> repeatValue'
        static member Repeat = Repeat |> repeatValue'
        static member Space = Space |> repeatValue'
        static member Round = Round |> repeatValue'
        static member NoRepeat = NoRepeat |> repeatValue'

        static member Inherit = Inherit |> repeatValue'
        static member Initial = Initial |> repeatValue'
        static member Unset = Unset |> repeatValue'

    /// <summary>Specifies how background is repeated.</summary>
    /// <param name="repeat">
    ///     can be:
    ///     - <c> BackgroundRepeat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundRepeat' (repeat: IBackgroundRepeat) = BackgroundRepeat.Value(repeat)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    let private sizeValue value = PropertyValue.cssValue Property.BackgroundSize value
    let private sizeValue' value =
        value
        |> sizeToString
        |> sizeValue
    type BackgroundSize =
        static member Value (size: IBackgroundSize) = size |> sizeValue'
        static member Value (s1: IBackgroundSize, s2: IBackgroundSize) =
            sprintf "%s %s" (sizeToString s1) (sizeToString s2)
                |> sizeValue

        static member Cover = Cover |> sizeValue'
        static member Contain = Contain |> sizeValue'

        static member Auto = Auto |> sizeValue'
        static member Inherit = Inherit |> sizeValue'
        static member Initial = Initial |> sizeValue'
        static member Unset = Unset |> sizeValue'

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
    let BackgroundSize' (size: IBackgroundSize) = BackgroundSize.Value(size)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    let private attachmentValue value = PropertyValue.cssValue Property.BackgroundAttachment value
    let private attachmentValue' value =
        value
        |> attachmentToString
        |> attachmentValue
    type BackgroundAttachment =
        static member Value (attachment: IBackgroundAttachment) = attachment |> attachmentValue'
        static member Scroll = Scroll |> attachmentValue'
        static member Fixed = Fixed |> attachmentValue'
        static member Local = Local |> attachmentValue'

        static member Inherit = Inherit |> attachmentValue'
        static member Initial = Initial |> attachmentValue'
        static member Unset = Unset |> attachmentValue'

    /// <summary>Specifies how background is fixed within viewport.</summary>
    /// <param name="attachment">
    ///     can be:
    ///     - <c> BackgroundAttachment </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundAttachment' (attachment: IBackgroundAttachment) = BackgroundAttachment.Value(attachment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-color
    let private backgroundValue value = PropertyValue.cssValue Property.BackgroundColor value
    let private backgroundValue' value =
        value
        |> CssColorValue.color
        |> backgroundValue
    type BackgroundColor =
        static member Value (color: CssColor) = color |> backgroundValue'
        static member black = CssColor.black |> backgroundValue'
        static member silver = CssColor.silver |> backgroundValue'
        static member gray = CssColor.gray |> backgroundValue'
        static member white = CssColor.white |> backgroundValue'
        static member maroon = CssColor.maroon |> backgroundValue'
        static member red = CssColor.red |> backgroundValue'
        static member purple = CssColor.purple |> backgroundValue'
        static member fuchsia = CssColor.fuchsia |> backgroundValue'
        static member green = CssColor.green |> backgroundValue'
        static member lime = CssColor.lime |> backgroundValue'
        static member olive = CssColor.olive |> backgroundValue'
        static member yellow = CssColor.yellow |> backgroundValue'
        static member navy = CssColor.navy |> backgroundValue'
        static member blue = CssColor.blue |> backgroundValue'
        static member teal = CssColor.teal |> backgroundValue'
        static member aqua = CssColor.aqua |> backgroundValue'
        static member orange = CssColor.orange |> backgroundValue'
        static member aliceBlue = CssColor.aliceBlue |> backgroundValue'
        static member antiqueWhite = CssColor.antiqueWhite |> backgroundValue'
        static member aquaMarine = CssColor.aquaMarine |> backgroundValue'
        static member azure = CssColor.azure |> backgroundValue'
        static member beige = CssColor.beige |> backgroundValue'
        static member bisque = CssColor.bisque |> backgroundValue'
        static member blanchedAlmond = CssColor.blanchedAlmond |> backgroundValue'
        static member blueViolet = CssColor.blueViolet |> backgroundValue'
        static member brown = CssColor.brown |> backgroundValue'
        static member burlywood = CssColor.burlywood |> backgroundValue'
        static member cadetBlue = CssColor.cadetBlue |> backgroundValue'
        static member chartreuse = CssColor.chartreuse |> backgroundValue'
        static member chocolate = CssColor.chocolate |> backgroundValue'
        static member coral = CssColor.coral |> backgroundValue'
        static member cornflowerBlue = CssColor.cornflowerBlue |> backgroundValue'
        static member cornsilk = CssColor.cornsilk |> backgroundValue'
        static member crimson = CssColor.crimson |> backgroundValue'
        static member cyan = CssColor.cyan |> backgroundValue'
        static member darkBlue = CssColor.darkBlue |> backgroundValue'
        static member darkCyan = CssColor.darkCyan |> backgroundValue'
        static member darkGoldenrod = CssColor.darkGoldenrod |> backgroundValue'
        static member darkGray = CssColor.darkGray |> backgroundValue'
        static member darkGreen = CssColor.darkGreen |> backgroundValue'
        static member darkKhaki = CssColor.darkKhaki |> backgroundValue'
        static member darkMagenta = CssColor.darkMagenta |> backgroundValue'
        static member darkOliveGreen = CssColor.darkOliveGreen |> backgroundValue'
        static member darkOrange = CssColor.darkOrange |> backgroundValue'
        static member darkOrchid = CssColor.darkOrchid |> backgroundValue'
        static member darkRed = CssColor.darkRed |> backgroundValue'
        static member darkSalmon = CssColor.darkSalmon |> backgroundValue'
        static member darkSeaGreen = CssColor.darkSeaGreen |> backgroundValue'
        static member darkSlateBlue = CssColor.darkSlateBlue |> backgroundValue'
        static member darkSlateGray = CssColor.darkSlateGray |> backgroundValue'
        static member darkTurquoise = CssColor.darkTurquoise |> backgroundValue'
        static member darkViolet = CssColor.darkViolet |> backgroundValue'
        static member deepPink = CssColor.deepPink |> backgroundValue'
        static member deepSkyBlue = CssColor.deepSkyBlue |> backgroundValue'
        static member dimGrey = CssColor.dimGrey |> backgroundValue'
        static member dodgerBlue = CssColor.dodgerBlue |> backgroundValue'
        static member fireBrick = CssColor.fireBrick |> backgroundValue'
        static member floralWhite = CssColor.floralWhite |> backgroundValue'
        static member forestGreen = CssColor.forestGreen |> backgroundValue'
        static member gainsboro = CssColor.gainsboro |> backgroundValue'
        static member ghostWhite = CssColor.ghostWhite |> backgroundValue'
        static member gold = CssColor.gold |> backgroundValue'
        static member goldenrod = CssColor.goldenrod |> backgroundValue'
        static member greenYellow = CssColor.greenYellow |> backgroundValue'
        static member grey = CssColor.grey |> backgroundValue'
        static member honeydew = CssColor.honeydew |> backgroundValue'
        static member hotPink = CssColor.hotPink |> backgroundValue'
        static member indianRed = CssColor.indianRed |> backgroundValue'
        static member indigo = CssColor.indigo |> backgroundValue'
        static member ivory = CssColor.ivory |> backgroundValue'
        static member khaki = CssColor.khaki |> backgroundValue'
        static member lavender = CssColor.lavender |> backgroundValue'
        static member lavenderBlush = CssColor.lavenderBlush |> backgroundValue'
        static member lawnGreen = CssColor.lawnGreen |> backgroundValue'
        static member lemonChiffon = CssColor.lemonChiffon |> backgroundValue'
        static member lightBlue = CssColor.lightBlue |> backgroundValue'
        static member lightCoral = CssColor.lightCoral |> backgroundValue'
        static member lightCyan = CssColor.lightCyan |> backgroundValue'
        static member lightGoldenrodYellow = CssColor.lightGoldenrodYellow |> backgroundValue'
        static member lightGray = CssColor.lightGray |> backgroundValue'
        static member lightGreen = CssColor.lightGreen |> backgroundValue'
        static member lightGrey = CssColor.lightGrey |> backgroundValue'
        static member lightPink = CssColor.lightPink |> backgroundValue'
        static member lightSalmon = CssColor.lightSalmon |> backgroundValue'
        static member lightSeaGreen = CssColor.lightSeaGreen |> backgroundValue'
        static member lightSkyBlue = CssColor.lightSkyBlue |> backgroundValue'
        static member lightSlateGrey = CssColor.lightSlateGrey |> backgroundValue'
        static member lightSteelBlue = CssColor.lightSteelBlue |> backgroundValue'
        static member lightYellow = CssColor.lightYellow |> backgroundValue'
        static member limeGreen = CssColor.limeGreen |> backgroundValue'
        static member linen = CssColor.linen |> backgroundValue'
        static member magenta = CssColor.magenta |> backgroundValue'
        static member mediumAquamarine = CssColor.mediumAquamarine |> backgroundValue'
        static member mediumBlue = CssColor.mediumBlue |> backgroundValue'
        static member mediumOrchid = CssColor.mediumOrchid |> backgroundValue'
        static member mediumPurple = CssColor.mediumPurple |> backgroundValue'
        static member mediumSeaGreen = CssColor.mediumSeaGreen |> backgroundValue'
        static member mediumSlateBlue = CssColor.mediumSlateBlue |> backgroundValue'
        static member mediumSpringGreen = CssColor.mediumSpringGreen |> backgroundValue'
        static member mediumTurquoise = CssColor.mediumTurquoise |> backgroundValue'
        static member mediumVioletRed = CssColor.mediumVioletRed |> backgroundValue'
        static member midnightBlue = CssColor.midnightBlue |> backgroundValue'
        static member mintCream = CssColor.mintCream |> backgroundValue'
        static member mistyRose = CssColor.mistyRose |> backgroundValue'
        static member moccasin = CssColor.moccasin |> backgroundValue'
        static member navajoWhite = CssColor.navajoWhite |> backgroundValue'
        static member oldLace = CssColor.oldLace |> backgroundValue'
        static member olivedrab = CssColor.olivedrab |> backgroundValue'
        static member orangeRed = CssColor.orangeRed |> backgroundValue'
        static member orchid = CssColor.orchid |> backgroundValue'
        static member paleGoldenrod = CssColor.paleGoldenrod |> backgroundValue'
        static member paleGreen = CssColor.paleGreen |> backgroundValue'
        static member paleTurquoise = CssColor.paleTurquoise |> backgroundValue'
        static member paleVioletred = CssColor.paleVioletred |> backgroundValue'
        static member papayaWhip = CssColor.papayaWhip |> backgroundValue'
        static member peachpuff = CssColor.peachpuff |> backgroundValue'
        static member peru = CssColor.peru |> backgroundValue'
        static member pink = CssColor.pink |> backgroundValue'
        static member plum = CssColor.plum |> backgroundValue'
        static member powderBlue = CssColor.powderBlue |> backgroundValue'
        static member rosyBrown = CssColor.rosyBrown |> backgroundValue'
        static member royalBlue = CssColor.royalBlue |> backgroundValue'
        static member saddleBrown = CssColor.saddleBrown |> backgroundValue'
        static member salmon = CssColor.salmon |> backgroundValue'
        static member sandyBrown = CssColor.sandyBrown |> backgroundValue'
        static member seaGreen = CssColor.seaGreen |> backgroundValue'
        static member seaShell = CssColor.seaShell |> backgroundValue'
        static member sienna = CssColor.sienna |> backgroundValue'
        static member skyBlue = CssColor.skyBlue |> backgroundValue'
        static member slateBlue = CssColor.slateBlue |> backgroundValue'
        static member slateGray = CssColor.slateGray |> backgroundValue'
        static member snow = CssColor.snow |> backgroundValue'
        static member springGreen = CssColor.springGreen |> backgroundValue'
        static member steelBlue = CssColor.steelBlue |> backgroundValue'
        static member tan = CssColor.tan |> backgroundValue'
        static member thistle = CssColor.thistle |> backgroundValue'
        static member tomato = CssColor.tomato |> backgroundValue'
        static member turquoise = CssColor.turquoise |> backgroundValue'
        static member violet = CssColor.violet |> backgroundValue'
        static member wheat = CssColor.wheat |> backgroundValue'
        static member whiteSmoke = CssColor.whiteSmoke |> backgroundValue'
        static member yellowGreen = CssColor.yellowGreen |> backgroundValue'
        static member rebeccaPurple = CssColor.rebeccaPurple |> backgroundValue'
        static member Rgb r g b = CssColor.Rgb(r, g, b) |> backgroundValue'
        static member Rgba r g b a = CssColor.Rgba(r, g, b, a) |> backgroundValue'
        static member Hex value = CssColor.Hex value |> backgroundValue'
        static member Hsl h s l = CssColor.Hsl(h, s, l) |> backgroundValue'
        static member Hsla h s l a  = CssColor.Hsla (h, s, l, a) |> backgroundValue'
        static member transparent = CssColor.transparent |> backgroundValue'
        static member currentColor = CssColor.currentColor |> backgroundValue'

    /// <summary>Specifies how background color.</summary>
    /// <param name="color">
    ///     can be:
    ///     - <c> CssColor </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundColor' (color: CssColor) = BackgroundColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    let private imageValue value = PropertyValue.cssValue Property.BackgroundImage value
    type BackgroundImage =
        static member Value (image: Image) = image |> imageValue
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url

        static member LinearGradient (start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.LinearGradient(start, last)
        static member LinearGradient (angle: Units.Angle.Angle, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member LinearGradient (colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.LinearGradient(colors)
        static member LinearGradient (colors: IColorStop list) =
            imageValue <| Image.Image.LinearGradient(colors)
        static member LinearGradient (angle: Units.Angle.Angle, colors: IColorStop list) =
            imageValue <| Image.Image.LinearGradient(angle, colors)
        static member LinearGradient (angle: Units.Angle.Angle, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.LinearGradient(angle, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: IColorStop list) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)

        static member RepeatingLinearGradient (start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RepeatingLinearGradient(start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (colors: IColorStop list) =
            imageValue <| Image.Image.RepeatingLinearGradient(colors)
        static member RepeatingLinearGradient (colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RepeatingLinearGradient(colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: IColorStop list) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: IColorStop list) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)

        static member RadialGradient (start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RadialGradient(start, last)
        static member RadialGradient (colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RadialGradient(colors)
        static member RadialGradient (colors: IColorStop list) =
            imageValue <| Image.Image.RadialGradient(colors)
        static member RadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RadialGradient(shape, start, last)
        static member RadialGradient (side: Side, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RadialGradient(side, start, last)
        static member RadialGradient (side: Side, colors: IColorStop list) =
            imageValue <| Image.Image.RadialGradient(side, colors)
        static member RadialGradient (side: Side, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RadialGradient(side, colors)
        static member RadialGradient (shape: Shape, colors: IColorStop list) =
            imageValue <| Image.Image.RadialGradient(shape, colors)
        static member RadialGradient (shape: Shape, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RadialGradient(shape, colors)
        static member RadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RadialGradient(shape, side, start, last)
        static member RadialGradient (shape: Shape, side: Side, colors: IColorStop list) =
            imageValue <| Image.Image.RadialGradient(shape, side, colors)
        static member RadialGradient (shape: Shape, side: Side, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RadialGradient(shape, side, colors)

        static member RepeatingRadialGradient (start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RepeatingRadialGradient(start, last)
        static member RepeatingRadialGradient (colors: IColorStop list) =
            imageValue <| Image.Image.RepeatingRadialGradient(colors)
        static member RepeatingRadialGradient (colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RepeatingRadialGradient(colors)
        static member RepeatingRadialGradient (side: Side, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RadialGradient(side, start, last)
        static member RepeatingRadialGradient (side: Side, colors: IColorStop list) =
            imageValue <| Image.Image.RadialGradient(side, colors)
        static member RepeatingRadialGradient (side: Side, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RadialGradient(side, colors)
        static member RepeatingRadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, start, last)
        static member RepeatingRadialGradient (shape: Shape, colors: IColorStop list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, colors)
        static member RepeatingRadialGradient (shape: Shape, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RepeatingRadialGradient(shape, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: IColorStop list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: IColorStop, last: IColorStop) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: IColorStop list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: CssColor list) =
            let colors = colors |> List.map (fun x -> x :> IColorStop)
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, colors)

    /// <summary>Draws background image on element.</summary>
    /// <param name="image">
    ///     can be:
    ///     - <c> Image </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BackgroundImage' (image: Image) = BackgroundImage.Value(image)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
    let private positionCssValue value = PropertyValue.cssValue Property.BackgroundPosition value
    let private positionCssValue' value =
        value
        |> positionToString
        |> positionCssValue

    type BackgroundPosition =
        static member Top = Top |> positionCssValue'
        static member Bottom = Bottom |> positionCssValue'
        static member Left = Left |> positionCssValue'
        static member Right = Right |> positionCssValue'
        static member Center = Center |> positionCssValue'

        static member Value (value: IBackgroundPosition) = value |> positionCssValue'
        static member Values (v1: IBackgroundPosition, v2: IBackgroundPosition) =
            sprintf "%s %s" (positionToString v1) (positionToString v2) |> positionCssValue
        static member Values (v1: IBackgroundPosition, v2: IBackgroundPosition, v3: IBackgroundPosition) =
            sprintf "%s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) |> positionCssValue
        static member Values (v1: IBackgroundPosition, v2: IBackgroundPosition, v3: IBackgroundPosition, v4: IBackgroundPosition) =
            sprintf "%s %s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) (positionToString v4) |> positionCssValue

        static member Inherit = Inherit |> positionCssValue'
        static member Initial = Initial |> positionCssValue'
        static member Unset = Unset |> positionCssValue'

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
    let BackgroundPosition' (position: IBackgroundPosition) = BackgroundPosition.Value(position)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-blend-mode
    let private blendModeCssValue value = PropertyValue.cssValue Property.BackgroundBlendMode value
    let private blendModeCssValue' value =
        value
        |> blendModeToString
        |> blendModeCssValue

    let private blendModeValues (values: BackgroundBlendMode list) =
        values
        |> Utilities.Helpers.combineComma blendModeToString
        |> blendModeCssValue

    type BackgroundBlendMode =
        static member Value(blendMode: IBackgroundBlendMode) = blendMode |> blendModeCssValue'
        static member Values(blendModes: BackgroundType.BackgroundBlendMode list) = blendModeValues blendModes

        static member Multiply = Multiply |> blendModeCssValue'
        static member Screen = Screen |> blendModeCssValue'
        static member Overlay = Overlay |> blendModeCssValue'
        static member Darken = Darken |> blendModeCssValue'
        static member Lighten = Lighten |> blendModeCssValue'
        static member ColorDodge = ColorDodge |> blendModeCssValue'
        static member HardLight = HardLight |> blendModeCssValue'
        static member SoftLight = SoftLight |> blendModeCssValue'
        static member Difference = Difference |> blendModeCssValue'
        static member Exclusion = Exclusion |> blendModeCssValue'
        static member Hue = Hue |> blendModeCssValue'
        static member Saturation = Saturation |> blendModeCssValue'
        static member Color = Color |> blendModeCssValue'
        static member Luminosity = Luminosity |> blendModeCssValue'

        static member Normal = Normal |> blendModeCssValue'
        static member Inherit = Inherit |> blendModeCssValue'
        static member Initial = Initial |> blendModeCssValue'
        static member Unset = Unset |> blendModeCssValue'


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
    let BackgroundBlendMode' (backgroundBlendMode: IBackgroundBlendMode) = backgroundBlendMode |> BackgroundBlendMode.Value