namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Mask =
    type Clip =
        | ContentBox
        | PaddingBox
        | BorderBox
        | MarginBox
        | FillBox
        | StrokeBox
        | ViewBox
        | NoClip
        | Border
        | Padding
        | Content
        | Text
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Composite =
        | Add
        | Subtract
        | Intersect
        | Exclude
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type Mode =
        | Alpha
        | Luminance
        | MatchSource
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Origin =
        | ContentBox
        | PaddingBox
        | BorderBox
        | MarginBox
        | FillBox
        | StrokeBox
        | ViewBox
        | Content
        | Padding
        | Border
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
        | Contain
        | Cover
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

[<RequireQualifiedAccess>]
module MaskClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
    type MaskClip(property) =
        inherit CssRule(property)
        member this.contentBox = (property, Mask.ContentBox) |> Rule
        member this.paddingBox = (property, Mask.PaddingBox) |> Rule
        member this.borderBox = (property, Mask.BorderBox) |> Rule
        member this.marginBox = (property, Mask.MarginBox) |> Rule
        member this.fillBox = (property, Mask.FillBox) |> Rule
        member this.strokeBox = (property, Mask.StrokeBox) |> Rule
        member this.viewBox = (property, Mask.ViewBox) |> Rule
        member this.noClip = (property, Mask.NoClip) |> Rule
        member this.border = (property, Mask.Border) |> Rule
        member this.padding = (property, Mask.Padding) |> Rule
        member this.content = (property, Mask.Content) |> Rule
        member this.text = (property, Mask.Text) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-composite
    type MaskComposite(property) =
        inherit CssRule(property)
        member this.add = (property, Mask.Add) |> Rule
        member this.subtract = (property, Mask.Subtract) |> Rule
        member this.intersect = (property, Mask.Intersect) |> Rule
        member this.exclude = (property, Mask.Exclude) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-image
    type MaskImage(property) =
        inherit ImageClasses.ImageClass(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-mode
    type MaskMode(property) =
        inherit CssRule(property)

        member this.value(modes: Mask.Mode list) =
            let value =
                modes
                |> List.map stringifyICssValue
                |> String.concat ", "

            (property, String value) |> Rule

        member this.alpha = (property, Mask.Alpha) |> Rule
        member this.luminance = (property, Mask.Luminance) |> Rule
        member this.matchSource = (property, Mask.MatchSource) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-origin
    type MaskOrigin(property) =
        inherit CssRule(property)
        member this.value(origins: Mask.Origin list) =
            let value =
                List.map stringifyICssValue origins
                |> String.concat ", "

            (property, String value) |> Rule

        member this.contentBox = (property, Mask.ContentBox) |> Rule
        member this.paddingBox = (property, Mask.PaddingBox) |> Rule
        member this.borderBox = (property, Mask.BorderBox) |> Rule
        member this.marginBox = (property, Mask.MarginBox) |> Rule
        member this.fillBox = (property, Mask.FillBox) |> Rule
        member this.strokeBox = (property, Mask.StrokeBox) |> Rule
        member this.viewBox = (property, Mask.ViewBox) |> Rule
        member this.content = (property, Mask.Content) |> Rule
        member this.padding = (property, Mask.Padding) |> Rule
        member this.border = (property, Mask.Border) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-position
    type MaskPosition(property) =
        inherit CssRule(property)

        member this.value(x: ILengthPercentage, y: ILengthPercentage) =
            let value =
                $"{lengthPercentageString x} {lengthPercentageString y}"
                |> String

            (property, value) |> Rule

        member this.value(values: (ILengthPercentage * ILengthPercentage) list) =
            let value =
                List.map (fun (x, y) -> $"{lengthPercentageString x} {lengthPercentageString y}") values
                |> String.concat ", "

            (property, String value) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-repeat
    type MaskRepeat(property) =
        inherit CssRule(property)

        member this.value(x: Mask.Repeat, y: Mask.Repeat) =
            let value =
                $"{stringifyICssValue x} {stringifyICssValue y}"
                |> String

            (property, value) |> Rule

        member this.value(values: (Mask.Repeat * Mask.Repeat) list) =
            let value =
                List.map (fun (x, y) -> $"{stringifyICssValue x} {stringifyICssValue y}") values
                |> String.concat ", "

            (property, String value) |> Rule

        member this.repeatX = (property, Mask.RepeatX) |> Rule
        member this.repeatY = (property, Mask.RepeatY) |> Rule
        member this.repeat = (property, Mask.Repeat) |> Rule
        member this.space = (property, Mask.Space) |> Rule
        member this.round = (property, Mask.Round) |> Rule
        member this.noRepeat = (property, Mask.NoRepeat) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-size
    type MaskSize(property) =
        inherit CssRuleWithAutoLength(property)
        member this.contain = (property, Mask.Contain) |> Rule
        member this.cover = (property, Mask.Cover) |> Rule

        member this.value(x: ILengthPercentage, y: ILengthPercentage) =
            let value =
                $"{lengthPercentageString x} {lengthPercentageString y}"
                |> String

            (property, value) |> Rule

        member this.value(values: ILengthPercentage list) =
            let value =
                List.map lengthPercentageString values
                |> String.concat ", "

            (property, String value) |> Rule
