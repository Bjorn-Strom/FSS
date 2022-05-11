namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Perspective =
    type BackfaceVisibility =
        | Hidden
        | Visible
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Hidden -> "hidden"
                | Visible -> "visible"

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
        /// THe backface is hidden, making the element invisible when turned away from the user
        member this.hidden = (property, Perspective.Hidden) |> Rule
        /// The back face is visible when turned toward the user
        member this.visible = (property, Perspective.Visible) |> Rule
