namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Outline =
    type Width =
        | Thin
        | Medium
        | Thick
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    type Style =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        interface ICssValue with
            member this.Stringify() = this.ToString().ToLower()

    [<RequireQualifiedAccess>]
    module OutlineClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/outline
        type Outline(property) =
            inherit CssRule(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/outline
        type OutlineColor(property) =
            inherit ColorClass.Color(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
        type OutlineWidth(property) =
            inherit CssRuleWithLength(property)
            member this.thin = (property, Thin) |> Rule
            member this.medium = (property, Medium) |> Rule
            member this.thick = (property, Thick) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
        type OutlineStyle(property) =
            inherit CssRuleWithNone(property)
            member this.hidden = (property, Hidden) |> Rule
            member this.dotted = (property, Dotted) |> Rule
            member this.dashed = (property, Dashed) |> Rule
            member this.solid = (property, Solid) |> Rule
            member this.double = (property, Double) |> Rule
            member this.groove = (property, Groove) |> Rule
            member this.ridge = (property, Ridge) |> Rule
            member this.inset = (property, Inset) |> Rule
            member this.outset = (property, Outset) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-offset
        type OutlineOffset(property) =
            inherit CssRuleWithLength(property)
