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
        interface ILengthPercentage

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

    type Shorthand =
        { Width: ILengthPercentage option
          Style: Style option
          Color: Color option }
        interface ICssValue with
            member this.StringifyCss() =
                let widthString =
                    match this.Width with
                    | Some width ->
                        match width with
                        | :? Width as w -> (w :> ICssValue).StringifyCss()
                        | :? Percent as p -> stringifyICssValue p
                        | :? Length as l -> stringifyICssValue l
                        | _ -> ""
                    | None -> ""
                let styleString =
                    match this.Style with
                    | Some style -> (style :> ICssValue).StringifyCss()
                    | None -> ""
                let colorString =
                    match this.Color with
                    | Some color -> (color :> ICssValue).StringifyCss()
                    | None -> ""
                $"{widthString} {styleString} {colorString}".Replace("  ", " ").Trim()

[<RequireQualifiedAccess>]
module OutlineClasses =
    type OutlineStyleValues() =
        member _.Hidden = Outline.Style.Hidden
        member _.Dotted = Outline.Style.Dotted
        member _.Dashed = Outline.Style.Dashed
        member _.Solid = Outline.Style.Solid
        member _.Double = Outline.Style.Double
        member _.Groove = Outline.Style.Groove
        member _.Ridge = Outline.Style.Ridge
        member _.Inset = Outline.Style.Inset
        member _.Outset = Outline.Style.Outset

    type OutlineWidthValues() =
        member _.Thin = Outline.Width.Thin
        member _.Medium = Outline.Width.Medium
        member _.Thick = Outline.Width.Thick

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    type Outline(property) =
        inherit CssRule(property)
        member this.value(?width: ILengthPercentage, ?style: Outline.Style, ?color: Color) =
            let shorthand: Outline.Shorthand = { Color = color; Style = style; Width = width }
            (property, shorthand) |> Rule
        member this.none = (property, None') |> Rule
        member _.Style = OutlineStyleValues()
        member _.Width = OutlineWidthValues()
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
