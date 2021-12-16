namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Perspective =
    type BackfaceVisibility =
        | Hidden
        | Visible
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    [<RequireQualifiedAccess>]
    module PerspectiveClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/perspective
        type Perspective(property) =
            inherit CssRuleWithLengthNone(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/perspective-origin
        type PerspectiveOrigin(property) =
            inherit CssRuleWithLength(property)

            member this.value(x: ILengthPercentage, y: ILengthPercentage) =
                let value =
                    $"{lengthPercentageString x} {lengthPercentageString y}"
                    |> String

                (property, value) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/backface-visibility
        type BackfaceVisibility(property) =
            inherit CssRule(property)
            member this.hidden = (property, Hidden) |> Rule
            member this.visible = (property, Visible) |> Rule
