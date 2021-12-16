namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Composite =
        | Add
        | Subtract
        | Intersect
        | Exclude
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Mode =
        | Alpha
        | Luminance
        | MatchSource
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Repeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    type Size =
        | Contain
        | Cover
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()



    [<RequireQualifiedAccess>]
    module MaskClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
        type MaskClip(property) =
            inherit CssRule(property)
            member this.contentBox = (property, ContentBox) |> Rule
            member this.paddingBox = (property, PaddingBox) |> Rule
            member this.borderBox = (property, BorderBox) |> Rule
            member this.marginBox = (property, MarginBox) |> Rule
            member this.fillBox = (property, FillBox) |> Rule
            member this.strokeBox = (property, StrokeBox) |> Rule
            member this.viewBox = (property, ViewBox) |> Rule
            member this.noClip = (property, NoClip) |> Rule
            member this.border = (property, Border) |> Rule
            member this.padding = (property, Padding) |> Rule
            member this.content = (property, Content) |> Rule
            member this.text = (property, Text) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-composite
        type MaskComposite(property) =
            inherit CssRule(property)
            member this.add = (property, Add) |> Rule
            member this.subtract = (property, Subtract) |> Rule
            member this.intersect = (property, Intersect) |> Rule
            member this.exclude = (property, Exclude) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-image
        type MaskImage(property) =
            inherit Image.ImageClasses.ImageClass(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-mode
        type MaskMode(property) =
            inherit CssRule(property)

            member this.value(modes: Mode list) =
                let value =
                    modes
                    |> List.map (fun x -> (x :> ICssValue).Stringify())
                    |> String.concat ", "

                (property, String value) |> Rule

            member this.alpha = (property, Alpha) |> Rule
            member this.luminance = (property, Luminance) |> Rule
            member this.matchSource = (property, MatchSource) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-origin
        type MaskOrigin(property) =
            inherit CssRule(property)
            // TODO: GJør dette over alt?
            member this.value(origins: Origin list) =
                let value =
                    List.map (fun x -> (x :> ICssValue).Stringify()) origins
                    |> String.concat ", "

                (property, String value) |> Rule

            member this.contentBox = (property, ContentBox) |> Rule
            member this.paddingBox = (property, PaddingBox) |> Rule
            member this.borderBox = (property, BorderBox) |> Rule
            member this.marginBox = (property, MarginBox) |> Rule
            member this.fillBox = (property, FillBox) |> Rule
            member this.strokeBox = (property, StrokeBox) |> Rule
            member this.viewBox = (property, ViewBox) |> Rule
            member this.content = (property, Content) |> Rule
            member this.padding = (property, Padding) |> Rule
            member this.border = (property, Border) |> Rule
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

            member this.value(x: Repeat, y: Repeat) =
                let value =
                    $"{(x :> ICssValue).Stringify()} {(y :> ICssValue).Stringify()}"
                    |> String

                (property, value) |> Rule

            member this.value(values: (Repeat * Repeat) list) =
                let value =
                    List.map (fun (x, y) -> $"{(x :> ICssValue).Stringify()} {(y :> ICssValue).Stringify()}") values
                    |> String.concat ", "

                (property, String value) |> Rule

            member this.repeatX = (property, RepeatX) |> Rule
            member this.repeatY = (property, RepeatY) |> Rule
            member this.repeat = (property, Repeat) |> Rule
            member this.space = (property, Space) |> Rule
            member this.round = (property, Round) |> Rule
            member this.noRepeat = (property, NoRepeat) |> Rule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-size
        type MaskSize(property) =
            inherit CssRuleWithAutoLength(property)
            member this.contain = (property, Contain) |> Rule
            member this.cover = (property, Cover) |> Rule

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
