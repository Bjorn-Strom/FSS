namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module BoxShadow =
    type BoxShadow =
        | Color of Length * Length * Color
        | BlurColor of Length * Length * Length * Color
        | BlurSpreadColor of Length * Length * Length * Length * Color
        | Inset of BoxShadow
        | Shadows of BoxShadow list
        interface ICssValue with
            member this.Stringify() =
                match this with
                | Color (xOffset, yOffset, color) ->
                    $"{lengthPercentageString xOffset} {lengthPercentageString yOffset} {stringifyICssValue color}"
                | BlurColor (xOffset, yOffset, blur, color) ->
                    $"{lengthPercentageString xOffset} {lengthPercentageString yOffset} {lengthPercentageString blur} {stringifyICssValue color}"
                | BlurSpreadColor (xOffset, yOffset, blur, spread, color) ->
                    $"{lengthPercentageString xOffset} {lengthPercentageString yOffset} {lengthPercentageString blur} {lengthPercentageString spread} {stringifyICssValue color}"
                | Inset shadow -> $"inset {stringifyICssValue shadow}"
                // TODO: KAn denne også funksjoneres?
                | Shadows shadows ->
                    shadows
                    |> List.map stringifyICssValue
                    |> String.concat ", "

    [<RequireQualifiedAccess>]
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
    module BoxShadowClasses =
        type BoxShadowClass(property) =
            inherit CssRuleWithNone(property)

            member this.value(xOffset: Length, yOffset: Length, color: Color) =
                (property, Color(xOffset, yOffset, color)) |> Rule

            member this.value(xOffset: Length, yOffset: Length, blur: Length, color: Color) =
                (property, BlurColor(xOffset, yOffset, blur, color))
                |> Rule

            member this.value(xOffset: Length, yOffset: Length, blur: Length, spread: Length, color: Color) =
                (property, BlurSpreadColor(xOffset, yOffset, blur, spread, color))
                |> Rule

            member this.value(boxShadows: BoxShadow list) = (property, Shadows boxShadows) |> Rule

            member this.Inset(boxShadow: BoxShadow) = (property, Inset boxShadow) |> Rule
