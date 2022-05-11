namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Outline =
    type Width =
        | Thin
        | Medium
        | Thick
        interface ICssValue with
            member this.StringifyCss() = 
                match this with
                | Thin -> "thin"
                | Medium -> "medium"
                | Thick -> "thick"

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
            member this.StringifyCss() =
                match this with
                | Hidden -> "hidden"
                | Dotted -> "dotted"
                | Dashed -> "dashed"
                | Solid -> "solid"
                | Double -> "double"
                | Groove -> "groove"
                | Ridge -> "ridge"
                | Inset -> "inset"
                | Outset -> "outset"

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
        member this.thin = (property, Outline.Thin) |> Rule
        member this.medium = (property, Outline.Medium) |> Rule
        member this.thick = (property, Outline.Thick) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
    type OutlineStyle(property) =
        inherit CssRuleWithNone(property)
        member this.hidden = (property, Outline.Hidden) |> Rule
        member this.dotted = (property, Outline.Dotted) |> Rule
        member this.dashed = (property, Outline.Dashed) |> Rule
        member this.solid = (property, Outline.Solid) |> Rule
        member this.double = (property, Outline.Double) |> Rule
        member this.groove = (property, Outline.Groove) |> Rule
        member this.ridge = (property, Outline.Ridge) |> Rule
        member this.inset = (property, Outline.Inset) |> Rule
        member this.outset = (property, Outline.Outset) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-offset
    type OutlineOffset(property) =
        inherit CssRuleWithLength(property)
