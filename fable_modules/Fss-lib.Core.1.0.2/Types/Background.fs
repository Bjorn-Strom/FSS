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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Origin =
        | BorderBox
        | PaddingBox
        | ContentBox
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Repeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Size =
        | Cover
        | Contain
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Attachment =
        | Scroll
        | Fixed
        | Local
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Position =
        | Top
        | Bottom
        | Left
        | Right
        | Center
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

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
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Isolation =
        | Isolate
        interface ICssValue with
            member this.StringifyCss() = "isolate"

    type BoxDecorationBreak =
        | Slice
        | Clone
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

[<RequireQualifiedAccess>]
module BackgroundClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    type BackgroundClip(property) =
        inherit CssRule(property)
        member this.value(clip: Background.Clip) = (property, clip) |> Rule
        member this.borderBox = (property, Background.BorderBox) |> Rule

        member this.paddingBox =
            (property, Background.PaddingBox) |> Rule

        member this.contentBox =
            (property, Background.ContentBox) |> Rule

        member this.text = (property, Background.Text) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    type BackgroundOrigin(property) =
        inherit CssRule(property)
        member this.value(origin: Background.Origin) = (property, origin) |> Rule

        member this.borderBox =
            (property, Background.Origin.BorderBox) |> Rule

        member this.paddingBox =
            (property, Background.Origin.PaddingBox) |> Rule

        member this.contentBox =
            (property, Background.Origin.ContentBox) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    type BackgroundRepeat(property) =
        inherit CssRule(property)
        member this.value(repeat: Background.Repeat) = (property, repeat) |> Rule

        member this.value(vertical: Background.Repeat, horizontal: Background.Repeat) =
            let repeat =
                $"{stringifyICssValue vertical} {stringifyICssValue horizontal}"
                |> String

            (property, repeat) |> Rule

        member this.repeatX = (property, Background.RepeatX) |> Rule
        member this.repeatY = (property, Background.RepeatY) |> Rule
        member this.repeat = (property, Background.Repeat) |> Rule
        member this.space = (property, Background.Space) |> Rule
        member this.round = (property, Background.Round) |> Rule
        member this.noRepeat = (property, Background.NoRepeat) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    type BackgroundSize(property) =
        inherit CssRuleWithValueFunctions<Background.Size>(property, ", ")

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

        member this.cover = (property, Background.Cover) |> Rule
        member this.contain = (property, Background.Contain) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    type BackgroundAttachment(property) =
        inherit CssRule(property)
        member this.value(attachment: Background.Attachment) = (property, attachment) |> Rule
        member this.scroll = (property, Background.Scroll) |> Rule
        member this.fixed' = (property, Background.Fixed) |> Rule
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

        member this.top = (property, String "top") |> Rule

        member this.bottom = (property, String "bottom") |> Rule

        member this.left = (property, String "left") |> Rule

        member this.right = (property, String "right") |> Rule

        member this.center = (property, String "center") |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-blend-mode
    type BackgroundBlendMode(property) =
        inherit CssRuleWithValueFunctions<Background.BlendMode>(property, ", ")
        member this.normal =
            (property, Normal) |> Rule
        member this.multiply =
            (property, Background.BlendMode.Multiply) |> Rule

        member this.screen =
            (property, Background.BlendMode.Screen) |> Rule

        member this.overlay =
            (property, Background.BlendMode.Overlay) |> Rule

        member this.darken =
            (property, Background.BlendMode.Darken) |> Rule

        member this.lighten =
            (property, Background.BlendMode.Lighten) |> Rule

        member this.colorDodge =
            (property, Background.BlendMode.ColorDodge)
            |> Rule

        member this.colorBurn =
            (property, Background.BlendMode.ColorBurn) |> Rule

        member this.hardLight =
            (property, Background.BlendMode.HardLight) |> Rule

        member this.softLight =
            (property, Background.BlendMode.SoftLight) |> Rule

        member this.difference =
            (property, Background.BlendMode.Difference)
            |> Rule

        member this.exclusion =
            (property, Background.BlendMode.Exclusion) |> Rule

        member this.hue =
            (property, Background.BlendMode.Hue) |> Rule

        member this.saturation =
            (property, Background.BlendMode.Saturation)
            |> Rule

        member this.color =
            (property, Background.BlendMode.Color) |> Rule

        member this.luminosity =
            (property, Background.BlendMode.Luminosity)
            |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/isolation
    type Isolation(property) =
        inherit CssRuleWithAuto(property)
        member this.value(isolation: Background.Isolation) = (property, isolation) |> Rule
        member this.isolate = (property, Background.Isolate) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-decoration-break
    type BoxDecorationBreak(property) =
        inherit CssRule(property)
        member this.value(decorationBreak: Background.BoxDecorationBreak) = (property, decorationBreak) |> Rule
        member this.slice = (property, Background.Slice) |> Rule
        member this.clone = (property, Background.Clone) |> Rule
