namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

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
                // todo: Kan upcast to string bli en funksjon?
                | Color (xOffset, yOffset, color) ->
                    $"{lengthPercentageString xOffset} {lengthPercentageString yOffset} {(color :> ICssValue).Stringify()}"
                | BlurColor (xOffset, yOffset, blur, color) ->
                    $"{lengthPercentageString xOffset} {lengthPercentageString yOffset} {lengthPercentageString blur} {(color :> ICssValue).Stringify()}"
                | BlurSpreadColor (xOffset, yOffset, blur, spread, color) ->
                    $"{lengthPercentageString xOffset} {lengthPercentageString yOffset} {lengthPercentageString blur} {lengthPercentageString spread} {(color :> ICssValue).Stringify()}"
                | Inset shadow -> $"inset {(shadow :> ICssValue).Stringify()}"
                // TODO: KAn denne også funksjoneres?
                | Shadows shadows ->
                    shadows
                    |> List.map (fun x -> (x :> ICssValue).Stringify())
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
