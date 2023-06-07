namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Background =
    type Clip =
        | BorderBox
        | PaddingBox
        | ContentBox
        | Text

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | BorderBox -> "border-box"
                | PaddingBox -> "padding-box"
                | ContentBox -> "content-box"
                | Text -> "text"

    type Origin =
        | BorderBox
        | PaddingBox
        | ContentBox

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | BorderBox -> "border-box"
                | PaddingBox -> "padding-box"
                | ContentBox -> "content-box"

    type Repeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | RepeatX -> "repeat-x"
                | RepeatY -> "repeat-y"
                | Repeat -> "repeat"
                | Space -> "space"
                | Round -> "round"
                | NoRepeat -> "no-repeat"

    type Size =
        | Cover
        | Contain

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Cover -> "cover"
                | Contain -> "contain"

    type Attachment =
        | Scroll
        | Fixed
        | Local

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Scroll -> "scroll"
                | Fixed -> "fixed"
                | Local -> "local"

    type Position =
        | Top
        | Bottom
        | Left
        | Right
        | Center

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Top -> "top"
                | Bottom -> "bottom"
                | Left -> "left"
                | Right -> "right"
                | Center -> "center"

    type BlendMode =
        | Multiply
        | Screen
        | Overlay
        | Darken
        | Lighten
        | ColorDodge
        | ColorBurn
        | HardLight
        | SoftLight
        | Difference
        | Exclusion
        | Hue
        | Saturation
        | Color
        | Luminosity

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Multiply -> "multiply"
                | Screen -> "screen"
                | Overlay -> "overlay"
                | Darken -> "darken"
                | Lighten -> "lighten"
                | ColorDodge -> "color-dodge"
                | ColorBurn -> "color-burn"
                | HardLight -> "hard-light"
                | SoftLight -> "soft-light"
                | Difference -> "difference"
                | Exclusion -> "exclusion"
                | Hue -> "hue"
                | Saturation -> "saturation"
                | Color -> "color"
                | Luminosity -> "luminosity"

    type Isolation =
        | Isolate

        interface ICssValue with
            member this.StringifyCss() = "isolate"

    type BoxDecorationBreak =
        | Slice
        | Clone

        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Slice -> "slice"
                | Clone -> "clone"

    type Shorthand =
        { Attachment: Attachment option
          Clip: Clip option
          Color: Color option
          Image: Image.Image option
          Origin: Origin option
          Position: Position option
          Repeat: Repeat option
          Size: Size option }

        interface ICssValue with
            member this.StringifyCss() : string =
                let attachmentString =
                    match this.Attachment with
                    | Some attachment -> (attachment :> ICssValue).StringifyCss()
                    | None -> ""

                let clipString =
                    match this.Clip with
                    | Some clip -> (clip :> ICssValue).StringifyCss()
                    | None -> ""

                let colorString =
                    match this.Color with
                    | Some color -> (color :> ICssValue).StringifyCss()
                    | None -> ""

                let imageString =
                    match this.Image with
                    | Some image -> (image :> ICssValue).StringifyCss()
                    | None -> ""

                let originString =
                    match this.Origin with
                    | Some origin -> (origin :> ICssValue).StringifyCss()
                    | None -> ""

                let positionString =
                    match this.Position with
                    | Some position -> (position :> ICssValue).StringifyCss()
                    | None -> ""

                let repeatString =
                    match this.Repeat with
                    | Some repeat -> (repeat :> ICssValue).StringifyCss()
                    | None -> ""

                let sizeString =
                    match this.Size with
                    | Some size -> (size :> ICssValue).StringifyCss()
                    | None -> ""

                [ attachmentString
                  clipString
                  colorString
                  imageString
                  originString
                  positionString
                  repeatString
                  sizeString ]
                |> List.filter (System.String.IsNullOrWhiteSpace >> not)
                |> String.concat " "

[<RequireQualifiedAccess>]
module BackgroundClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    type BackgroundClip(property) =
        inherit CssRule(property)
        member this.value(clip: Background.Clip) = (property, clip) |> Rule
        /// Background will extend to outside edge of border
        member this.borderBox = (property, Background.BorderBox) |> Rule
        /// Background will extend to outside edge og padding
        member this.paddingBox = (property, Background.PaddingBox) |> Rule
        /// Background is clipped to content
        member this.contentBox = (property, Background.ContentBox) |> Rule
        /// Background is clipped to the foreground text
        member this.text = (property, Background.Text) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    type BackgroundOrigin(property) =
        inherit CssRule(property)
        member this.value(origin: Background.Origin) = (property, origin) |> Rule
        /// Position background relative to border box
        member this.borderBox = (property, Background.Origin.BorderBox) |> Rule
        /// Position background relative to padding box
        member this.paddingBox = (property, Background.Origin.PaddingBox) |> Rule
        /// Position background relative to content box
        member this.contentBox = (property, Background.Origin.ContentBox) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    type BackgroundRepeat(property) =
        inherit CssRule(property)
        member this.value(repeat: Background.Repeat) = (property, repeat) |> Rule

        member this.value(vertical: Background.Repeat, horizontal: Background.Repeat) =
            let repeat =
                $"{stringifyICssValue vertical} {stringifyICssValue horizontal}"
                |> String

            (property, repeat) |> Rule

        /// Repeats the background in the X-axis enough to cover the painting area
        member this.repeatX = (property, Background.RepeatX) |> Rule
        /// Repeats the background in the Y-axis enough to cover the painting area
        member this.repeatY = (property, Background.RepeatY) |> Rule
        /// Repeats the background enough to cover the entire painting area
        member this.repeat = (property, Background.Repeat) |> Rule
        /// Background is repeated as much as possible without clipping
        member this.space = (property, Background.Space) |> Rule
        /// The background repeats more as there is more room for it to repeat
        member this.round = (property, Background.Round) |> Rule
        /// The backgroind is not repeated
        member this.noRepeat = (property, Background.NoRepeat) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    type BackgroundSize(property) =
        inherit CssRuleWithValueFunctions<Background.Size>(property, ",")

        member this.value(size: ILengthPercentage) =
            (property, lengthPercentageToType size) |> Rule
        member this.value(x: ILengthPercentage, y: ILengthPercentage) =
            let sizes = $"{lengthPercentageString x} {lengthPercentageString y}"
            (property, String sizes) |> Rule
        member this.auto = (property, Auto) |> Rule

        member this.value(horizontal: Background.Size, vertical: Background.Size) =
            let value =
                $"{stringifyICssValue horizontal} {stringifyICssValue vertical}"
                |> String

            (property, value) |> Rule

        /// Scales the image as large as possible to fill the container without cropping or stretching
        member this.cover = (property, Background.Cover) |> Rule
        /// Scales the image as large as possible to fill the container stretching and cropping as necessary
        member this.contain = (property, Background.Contain) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    type BackgroundAttachment(property) =
        inherit CssRule(property)
        member this.value(attachment: Background.Attachment) = (property, attachment) |> Rule
        /// The background image is fixed relative to the element it is within
        member this.scroll = (property, Background.Scroll) |> Rule
        /// The backrgound image is fixed relative to the viewport
        member this.fixed' = (property, Background.Fixed) |> Rule
        /// The background is fixed relative to the elements contents
        member this.local = (property, Background.Local) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-color
    type BackgroundColor(property) =
        inherit ColorClass.Color(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    type BackgroundImage(property) =
        inherit ImageClasses.ImageClass(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
    type BackgroundPosition(property) =
        inherit CssRule(property)

        member this.value(position: ILengthPercentage) =
            (property, lengthPercentageToType position)
            |> Rule

        member this.value(x: ILengthPercentage, y: ILengthPercentage) =
            let value =
                $"{lengthPercentageString x} {lengthPercentageString y}"
                |> String

            (property, value) |> Rule

        member this.value(x: ILengthPercentage, y: ILengthPercentage, offset: ILengthPercentage) =
            let position = $"{lengthPercentageString x} {lengthPercentageString y} {lengthPercentageString offset}"

            (property, position |> String) |> Rule

        member this.value
            (
                x: ILengthPercentage,
                y: ILengthPercentage,
                xOffset: ILengthPercentage,
                yOffset: ILengthPercentage
            ) =
            let position = $"{lengthPercentageString x} {lengthPercentageString y} {lengthPercentageString xOffset} {lengthPercentageString yOffset}"

            (property, position |> String) |> Rule

        /// Aligns the background to the top of its containing element
        member this.top = (property, String "top") |> Rule
        /// Aligns the background to the bottom of its containing element
        member this.bottom = (property, String "bottom") |> Rule
        /// Aligns the background to the left of its containing element
        member this.left = (property, String "left") |> Rule
        /// Aligns the background to the right of its containing element
        member this.right = (property, String "right") |> Rule
        /// Aligns the background in the center of its containing element
        member this.center = (property, String "center") |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-blend-mode
    // FIXME: This and MixBlendMode are quite similar
    type BackgroundBlendMode(property) =
        inherit CssRuleWithValueFunctions<Background.BlendMode>(property, ",")
        /// The top color is final, regardless of what lies beneath
        member this.normal = (property, Normal) |> Rule
        /// The final color is the result of multiplying the top and bottom colors
        member this.multiply = (property, Background.BlendMode.Multiply) |> Rule
        /// The final color is the result of inverting the color, multiplying them and inverting that value
        member this.screen = (property, Background.BlendMode.Screen) |> Rule
        /// The final color is multiply if the bottom color is darker and screen if it is lighter
        member this.overlay = (property, Background.BlendMode.Overlay) |> Rule
        /// The final color is composed of the darkest values from each color channel
        member this.darken = (property, Background.BlendMode.Darken) |> Rule
        /// The final color is composed of the lightest values from each color channel
        member this.lighten = (property, Background.BlendMode.Lighten) |> Rule
        /// The final color is the result of dividing the bottom color by the inverse of the top color
        member this.colorDodge = (property, Background.BlendMode.ColorDodge) |> Rule
        /// The final color is the result of inverting the bottom color dividing the value by teh top color and inverting it
        member this.colorBurn = (property, Background.BlendMode.ColorBurn) |> Rule
        /// The final color is the result of multiply if the top color is darker and screen if it is ligher
        member this.hardLight = (property, Background.BlendMode.HardLight) |> Rule
        /// Similar to hard light but softer
        member this.softLight = (property, Background.BlendMode.SoftLight) |> Rule
        /// The final color is the result of subtracting the darker of the two colors from the lighter one
        member this.difference = (property, Background.BlendMode.Difference) |> Rule
        /// Similar to difference but with less contrast
        member this.exclusion = (property, Background.BlendMode.Exclusion) |> Rule
        /// The final color has the hue of the top color while using the saturation and luminosity of the bottom color
        member this.hue = (property, Background.BlendMode.Hue) |> Rule
        /// The final color has the saturation of the top color, while using the hue and luminosity of the bottom color
        member this.saturation = (property, Background.BlendMode.Saturation) |> Rule
        /// The final color has the hue and saturation of the top color, while using the luminosity of the bottom color
        member this.color = (property, Background.BlendMode.Color) |> Rule
        /// The final color has the luminosity of the top color while using the hue and saturation of the bottom color
        member this.luminosity = (property, Background.BlendMode.Luminosity) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/isolation
    type Isolation(property) =
        inherit CssRuleWithAuto(property)
        member this.value(isolation: Background.Isolation) = (property, isolation) |> Rule
        /// Create a new stacking context
        member this.isolate = (property, Background.Isolate) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-decoration-break
    type BoxDecorationBreak(property) =
        inherit CssRule(property)
        member this.value(decorationBreak: Background.BoxDecorationBreak) = (property, decorationBreak) |> Rule
        /// The box is sliced at all internal edges
        member this.slice = (property, Background.Slice) |> Rule
        /// The edges are rendered indepedently
        member this.clone = (property, Background.Clone) |> Rule
    
    type Background(property) =
        inherit CssRule(property)
        
        member this.value (?attachment, ?clip, ?color, ?image, ?origin, ?position, ?repeat, ?size) =
            let shorthand: Background.Shorthand = {
                Attachment = attachment
                Clip = clip
                Color = color
                Image = image
                Origin = origin
                Position = position
                Repeat = repeat
                Size = size
            }
            (property, shorthand) |> Rule
