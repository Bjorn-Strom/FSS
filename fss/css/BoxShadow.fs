namespace Fss

open FssTypes

[<AutoOpen>]
module BoxShadow =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
    let rec private boxShadowToString =
        function
            | BoxShadow.Color (x, y, color) ->
                sprintf "%s %s %s"
                    (Units.Size.value x)
                    (Units.Size.value y)
                    (CssColorValue.color color)
            | BoxShadow.BlurColor (x, y, blur, color) ->
                sprintf "%s %s %s %s"
                    (Units.Size.value x)
                    (Units.Size.value y)
                    (Units.Size.value blur)
                    (CssColorValue.color color)
            | BoxShadow.BlurSpreadColor (x, y, blur, spread, color) ->
                sprintf "%s %s %s %s %s"
                    (Units.Size.value x)
                    (Units.Size.value y)
                    (Units.Size.value blur)
                    (Units.Size.value spread)
                    (CssColorValue.color color)
            | BoxShadow.Inset shadow ->
                sprintf "inset %s" <| boxShadowToString shadow

    let private boxShadowValue value = PropertyValue.cssValue Property.BoxShadow value
    type BoxShadow =
        static member Color (x: Units.Size.Size, y: Units.Size.Size, color: CssColor) = BoxShadow.Color(x, y, color)
        static member BlurColor (x: Units.Size.Size, y: Units.Size.Size, blur: Units.Size.Size, color: CssColor) =
                BoxShadow.BlurColor(x, y, blur, color)
        static member BlurSpreadColor (x: Units.Size.Size, y: Units.Size.Size, blur: Units.Size.Size, spread: Units.Size.Size, color: CssColor) =
                BoxShadow.BlurSpreadColor(x, y, blur, spread, color)

    /// Supply a list of box shadows to be applied to the element.
    let BoxShadows (shadows: FssTypes.BoxShadow list): CssProperty =
        shadows
        |> Utilities.Helpers.combineComma boxShadowToString
        |> boxShadowValue

    /// Can be used to invert box shadow
    let Inset (shadow: FssTypes.BoxShadow) = BoxShadow.Inset shadow