namespace Fss

open Fss.CSSColor
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

[<AutoOpen>]
module Background =
    open BackgroundType

    let private backgroundClipToString (clip: IBackgroundClip) =
        let stringifyClip =
            function
                | BackgroundClip.BorderBox -> "border-box"
                | BackgroundClip.PaddingBox -> "padding-box"
                | BackgroundClip.ContentBox -> "content-box"
                | BackgroundClip.Text -> "text"

        match clip with
        | :? BackgroundClip as b -> stringifyClip b
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown background clip"

    let private backgroundOriginToString (clip: IBackgroundOrigin) =
        let stringifyOrigin =
            function
                | BorderBox -> "border-box"
                | PaddingBox -> "padding-box"
                | ContentBox -> "content-box"

        match clip with
        | :? BackgroundOrigin as b -> stringifyOrigin b
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "unknown background origin"

    let private repeatToString (repeat: IBackgroundRepeat) =
        let stringifyRepeat =
            function
                | RepeatX -> "repeat-x"
                | RepeatY -> "repeat-y"
                | Repeat -> "repeat"
                | Space -> "space"
                | Round -> "round"
                | NoRepeat -> "no-repeat"

        match repeat with
        | :? BackgroundRepeat as b -> stringifyRepeat b
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "unknown background repeat"

    let private sizeToString (size: IBackgroundSize) =
        let stringifySize =
            function
                | Cover -> "cover"
                | Contain -> "contain"

        match size with
        | :? BackgroundSize as b -> stringifySize b
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Keywords as k -> GlobalValue.keywords k
        | :? Auto -> GlobalValue.auto
        | _ -> "unknown background size"

    let private attachmentToString (attachment: IBackgroundAttachment) =
        let stringifyAttachment =
            function
                | Scroll -> "scroll"
                | Fixed -> "fixed"
                | Local -> "local"

        match attachment with
        | :? BackgroundAttachment as b -> stringifyAttachment b
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown background attachment"

    let private positionToString (position: IBackgroundPosition) =
        let stringifyPosition =
            function
                | Top -> "top"
                | Bottom -> "bottom"
                | Left -> "left"
                | Right -> "right"
                | Center -> "center"

        match position with
        | :? BackgroundPosition as b -> stringifyPosition b
        | :? Keywords as k -> GlobalValue.keywords k
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "unknown background position"

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

    let BackgroundAttachment' (attachment: IBackgroundAttachment) = BackgroundAttachment.Value(attachment)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-color
    let private backgroundValue value = PropertyValue.cssValue Property.BackgroundColor value
    let private backgroundValue' value =
        value
        |> CSSColorValue.color
        |> backgroundValue
    type BackgroundColor =
        static member Value (color: CSSColor) = color |> backgroundValue'
        static member black = CSSColor.black |> backgroundValue'
        static member silver = CSSColor.silver |> backgroundValue'
        static member gray = CSSColor.gray |> backgroundValue'
        static member white = CSSColor.white |> backgroundValue'
        static member maroon = CSSColor.maroon |> backgroundValue'
        static member red = CSSColor.red |> backgroundValue'
        static member purple = CSSColor.purple |> backgroundValue'
        static member fuchsia = CSSColor.fuchsia |> backgroundValue'
        static member green = CSSColor.green |> backgroundValue'
        static member lime = CSSColor.lime |> backgroundValue'
        static member olive = CSSColor.olive |> backgroundValue'
        static member yellow = CSSColor.yellow |> backgroundValue'
        static member navy = CSSColor.navy |> backgroundValue'
        static member blue = CSSColor.blue |> backgroundValue'
        static member teal = CSSColor.teal |> backgroundValue'
        static member aqua = CSSColor.aqua |> backgroundValue'
        static member orange = CSSColor.orange |> backgroundValue'
        static member aliceBlue = CSSColor.aliceBlue |> backgroundValue'
        static member antiqueWhite = CSSColor.antiqueWhite |> backgroundValue'
        static member aquaMarine = CSSColor.aquaMarine |> backgroundValue'
        static member azure = CSSColor.azure |> backgroundValue'
        static member beige = CSSColor.beige |> backgroundValue'
        static member bisque = CSSColor.bisque |> backgroundValue'
        static member blanchedAlmond = CSSColor.blanchedAlmond |> backgroundValue'
        static member blueViolet = CSSColor.blueViolet |> backgroundValue'
        static member brown = CSSColor.brown |> backgroundValue'
        static member burlywood = CSSColor.burlywood |> backgroundValue'
        static member cadetBlue = CSSColor.cadetBlue |> backgroundValue'
        static member chartreuse = CSSColor.chartreuse |> backgroundValue'
        static member chocolate = CSSColor.chocolate |> backgroundValue'
        static member coral = CSSColor.coral |> backgroundValue'
        static member cornflowerBlue = CSSColor.cornflowerBlue |> backgroundValue'
        static member cornsilk = CSSColor.cornsilk |> backgroundValue'
        static member crimson = CSSColor.crimson |> backgroundValue'
        static member cyan = CSSColor.cyan |> backgroundValue'
        static member darkBlue = CSSColor.darkBlue |> backgroundValue'
        static member darkCyan = CSSColor.darkCyan |> backgroundValue'
        static member darkGoldenrod = CSSColor.darkGoldenrod |> backgroundValue'
        static member darkGray = CSSColor.darkGray |> backgroundValue'
        static member darkGreen = CSSColor.darkGreen |> backgroundValue'
        static member darkKhaki = CSSColor.darkKhaki |> backgroundValue'
        static member darkMagenta = CSSColor.darkMagenta |> backgroundValue'
        static member darkOliveGreen = CSSColor.darkOliveGreen |> backgroundValue'
        static member darkOrange = CSSColor.darkOrange |> backgroundValue'
        static member darkOrchid = CSSColor.darkOrchid |> backgroundValue'
        static member darkRed = CSSColor.darkRed |> backgroundValue'
        static member darkSalmon = CSSColor.darkSalmon |> backgroundValue'
        static member darkSeaGreen = CSSColor.darkSeaGreen |> backgroundValue'
        static member darkSlateBlue = CSSColor.darkSlateBlue |> backgroundValue'
        static member darkSlateGray = CSSColor.darkSlateGray |> backgroundValue'
        static member darkTurquoise = CSSColor.darkTurquoise |> backgroundValue'
        static member darkViolet = CSSColor.darkViolet |> backgroundValue'
        static member deepPink = CSSColor.deepPink |> backgroundValue'
        static member deepSkyBlue = CSSColor.deepSkyBlue |> backgroundValue'
        static member dimGrey = CSSColor.dimGrey |> backgroundValue'
        static member dodgerBlue = CSSColor.dodgerBlue |> backgroundValue'
        static member fireBrick = CSSColor.fireBrick |> backgroundValue'
        static member floralWhite = CSSColor.floralWhite |> backgroundValue'
        static member forestGreen = CSSColor.forestGreen |> backgroundValue'
        static member gainsboro = CSSColor.gainsboro |> backgroundValue'
        static member ghostWhite = CSSColor.ghostWhite |> backgroundValue'
        static member gold = CSSColor.gold |> backgroundValue'
        static member goldenrod = CSSColor.goldenrod |> backgroundValue'
        static member greenYellow = CSSColor.greenYellow |> backgroundValue'
        static member grey = CSSColor.grey |> backgroundValue'
        static member honeydew = CSSColor.honeydew |> backgroundValue'
        static member hotPink = CSSColor.hotPink |> backgroundValue'
        static member indianRed = CSSColor.indianRed |> backgroundValue'
        static member indigo = CSSColor.indigo |> backgroundValue'
        static member ivory = CSSColor.ivory |> backgroundValue'
        static member khaki = CSSColor.khaki |> backgroundValue'
        static member lavender = CSSColor.lavender |> backgroundValue'
        static member lavenderBlush = CSSColor.lavenderBlush |> backgroundValue'
        static member lawnGreen = CSSColor.lawnGreen |> backgroundValue'
        static member lemonChiffon = CSSColor.lemonChiffon |> backgroundValue'
        static member lightBlue = CSSColor.lightBlue |> backgroundValue'
        static member lightCoral = CSSColor.lightCoral |> backgroundValue'
        static member lightCyan = CSSColor.lightCyan |> backgroundValue'
        static member lightGoldenrodYellow = CSSColor.lightGoldenrodYellow |> backgroundValue'
        static member lightGray = CSSColor.lightGray |> backgroundValue'
        static member lightGreen = CSSColor.lightGreen |> backgroundValue'
        static member lightGrey = CSSColor.lightGrey |> backgroundValue'
        static member lightPink = CSSColor.lightPink |> backgroundValue'
        static member lightSalmon = CSSColor.lightSalmon |> backgroundValue'
        static member lightSeaGreen = CSSColor.lightSeaGreen |> backgroundValue'
        static member lightSkyBlue = CSSColor.lightSkyBlue |> backgroundValue'
        static member lightSlateGrey = CSSColor.lightSlateGrey |> backgroundValue'
        static member lightSteelBlue = CSSColor.lightSteelBlue |> backgroundValue'
        static member lightYellow = CSSColor.lightYellow |> backgroundValue'
        static member limeGreen = CSSColor.limeGreen |> backgroundValue'
        static member linen = CSSColor.linen |> backgroundValue'
        static member magenta = CSSColor.magenta |> backgroundValue'
        static member mediumAquamarine = CSSColor.mediumAquamarine |> backgroundValue'
        static member mediumBlue = CSSColor.mediumBlue |> backgroundValue'
        static member mediumOrchid = CSSColor.mediumOrchid |> backgroundValue'
        static member mediumPurple = CSSColor.mediumPurple |> backgroundValue'
        static member mediumSeaGreen = CSSColor.mediumSeaGreen |> backgroundValue'
        static member mediumSlateBlue = CSSColor.mediumSlateBlue |> backgroundValue'
        static member mediumSpringGreen = CSSColor.mediumSpringGreen |> backgroundValue'
        static member mediumTurquoise = CSSColor.mediumTurquoise |> backgroundValue'
        static member mediumVioletRed = CSSColor.mediumVioletRed |> backgroundValue'
        static member midnightBlue = CSSColor.midnightBlue |> backgroundValue'
        static member mintCream = CSSColor.mintCream |> backgroundValue'
        static member mistyRose = CSSColor.mistyRose |> backgroundValue'
        static member moccasin = CSSColor.moccasin |> backgroundValue'
        static member navajoWhite = CSSColor.navajoWhite |> backgroundValue'
        static member oldLace = CSSColor.oldLace |> backgroundValue'
        static member olivedrab = CSSColor.olivedrab |> backgroundValue'
        static member orangeRed = CSSColor.orangeRed |> backgroundValue'
        static member orchid = CSSColor.orchid |> backgroundValue'
        static member paleGoldenrod = CSSColor.paleGoldenrod |> backgroundValue'
        static member paleGreen = CSSColor.paleGreen |> backgroundValue'
        static member paleTurquoise = CSSColor.paleTurquoise |> backgroundValue'
        static member paleVioletred = CSSColor.paleVioletred |> backgroundValue'
        static member papayaWhip = CSSColor.papayaWhip |> backgroundValue'
        static member peachpuff = CSSColor.peachpuff |> backgroundValue'
        static member peru = CSSColor.peru |> backgroundValue'
        static member pink = CSSColor.pink |> backgroundValue'
        static member plum = CSSColor.plum |> backgroundValue'
        static member powderBlue = CSSColor.powderBlue |> backgroundValue'
        static member rosyBrown = CSSColor.rosyBrown |> backgroundValue'
        static member royalBlue = CSSColor.royalBlue |> backgroundValue'
        static member saddleBrown = CSSColor.saddleBrown |> backgroundValue'
        static member salmon = CSSColor.salmon |> backgroundValue'
        static member sandyBrown = CSSColor.sandyBrown |> backgroundValue'
        static member seaGreen = CSSColor.seaGreen |> backgroundValue'
        static member seaShell = CSSColor.seaShell |> backgroundValue'
        static member sienna = CSSColor.sienna |> backgroundValue'
        static member skyBlue = CSSColor.skyBlue |> backgroundValue'
        static member slateBlue = CSSColor.slateBlue |> backgroundValue'
        static member slateGray = CSSColor.slateGray |> backgroundValue'
        static member snow = CSSColor.snow |> backgroundValue'
        static member springGreen = CSSColor.springGreen |> backgroundValue'
        static member steelBlue = CSSColor.steelBlue |> backgroundValue'
        static member tan = CSSColor.tan |> backgroundValue'
        static member thistle = CSSColor.thistle |> backgroundValue'
        static member tomato = CSSColor.tomato |> backgroundValue'
        static member turquoise = CSSColor.turquoise |> backgroundValue'
        static member violet = CSSColor.violet |> backgroundValue'
        static member wheat = CSSColor.wheat |> backgroundValue'
        static member whiteSmoke = CSSColor.whiteSmoke |> backgroundValue'
        static member yellowGreen = CSSColor.yellowGreen |> backgroundValue'
        static member rebeccaPurple = CSSColor.rebeccaPurple |> backgroundValue'
        static member Rgb r g b = CSSColor.Rgb(r, g, b) |> backgroundValue'
        static member Rgba r g b a = CSSColor.Rgba(r, g, b, a) |> backgroundValue'
        static member Hex value = CSSColor.Hex value |> backgroundValue'
        static member Hsl h s l = CSSColor.Hsl(h, s, l) |> backgroundValue'
        static member Hsla h s l a  = CSSColor.Hsla (h, s, l, a) |> backgroundValue'
        static member transparent = CSSColor.transparent |> backgroundValue'
        static member currentColor = CSSColor.currentColor |> backgroundValue'

    let BackgroundColor' (color: CSSColor) = BackgroundColor.Value(color)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    let private imageValue value = PropertyValue.cssValue Property.BackgroundImage value
    type BackgroundImage =
        static member Value (image: Image) = image |> imageValue
        static member Url (url: string) = imageValue <| sprintf "url(%s)" url
        (*
        static member LinearGradient (start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.LinearGradient(start, last)
        static member LinearGradient (angle: Units.Angle.Angle, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member LinearGradient (angle: Units.Angle.Angle, colors: CSSColor list)=
            imageValue <| Image.Image.LinearGradient(angle, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: CSSColor list) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(angle,colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member LinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(angle, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: CSSColor list)=
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, (colors: (CSSColor * ILengthPercentage * ILengthPercentage) list)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: (CSSColor * ILengthPercentage * ILengthPercentage), (last: CSSColor * ILengthPercentage * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RadialGradient (start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(start, last)
        static member RadialGradient ((start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RadialGradient(start, last)
        static member RadialGradient (colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(colors)
        static member RadialGradient (colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(colorsAndStop)
        static member RadialGradient (shape: Shape, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, start, last)
        static member RadialGradient (shape: Shape, (start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RadialGradient(shape, start, last)
        static member RadialGradient (shape: Shape, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, colors)
        static member RadialGradient (shape: Shape, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, colorsAndStop)
        static member RadialGradient (shape: Shape, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, position, start, last)
        static member RadialGradient (shape: Shape, position: ImagePosition, (start: (CSSColor * ILengthPercentage)), (last: (CSSColor * ILengthPercentage))) =
            imageValue <| Image.Image.RadialGradient(shape, position, start, last)
        static member RadialGradient (shape: Shape, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, position, colors)
        static member RadialGradient (shape: Shape, position: ImagePosition, colors: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, position, colors)
        static member RadialGradient (shape: Shape, side: Side, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, side, start, last)
        static member RadialGradient (shape: Shape, side: Side, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RadialGradient(shape, side, start, last)
        static member RadialGradient (shape: Shape, side: Side, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, side, colors)
        static member RadialGradient (shape: Shape, side: Side, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, side, colorsAndStop)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, start, last)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, start, last)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, colors)
        static member RadialGradient (shape: Shape, side: Side, position: ImagePosition, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RadialGradient(shape, side, position, colorsAndStop)
        static member RepeatingRadialGradient (start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(start, last)
        static member RepeatingRadialGradient ((start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingRadialGradient(start, last)
        static member RepeatingRadialGradient (colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(colors)
        static member RepeatingRadialGradient (colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, start, last)
        static member RepeatingRadialGradient (shape: Shape, (start: CSSColor * ILengthPercentage), (last: CSSColor * ILengthPercentage)) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, start, last)
        static member RepeatingRadialGradient (shape: Shape, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, colors)
        static member RepeatingRadialGradient (shape: Shape, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, (start: (CSSColor * ILengthPercentage)), (last: (CSSColor * ILengthPercentage))) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, colors)
        static member RepeatingRadialGradient (shape: Shape, position: ImagePosition, colors: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, position, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, colorsAndStop)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor, last: CSSColor) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: CSSColor * ILengthPercentage, last: CSSColor * ILengthPercentage) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: CSSColor list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colorsAndStop: (CSSColor * ILengthPercentage) list) =
            imageValue <| Image.Image.RepeatingRadialGradient(shape, side, position, colorsAndStop)
            *)

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

    let BackgroundPosition' (position: IBackgroundPosition) = BackgroundPosition.Value(position)