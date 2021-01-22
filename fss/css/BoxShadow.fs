namespace Fss

[<RequireQualifiedAccess>]
module BoxShadowType =
    type BoxShadow =
        | Color of Units.Size.Size * Units.Size.Size * CssColor
        | BlurColor of Units.Size.Size * Units.Size.Size * Units.Size.Size * CssColor
        | BlurSpreadColor of Units.Size.Size * Units.Size.Size * Units.Size.Size * Units.Size.Size * CssColor
        | Inset of BoxShadow


[<AutoOpen>]
module BoxShadow =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
    let rec private boxShadowToString =
        function
            | BoxShadowType.Color (x, y, color) ->
                sprintf "%s %s %s"
                    (Units.Size.value x)
                    (Units.Size.value y)
                    (CssColorValue.color color)
            | BoxShadowType.BlurColor (x, y, blur, color) ->
                sprintf "%s %s %s %s"
                    (Units.Size.value x)
                    (Units.Size.value y)
                    (Units.Size.value blur)
                    (CssColorValue.color color)
            | BoxShadowType.BlurSpreadColor (x, y, blur, spread, color) ->
                sprintf "%s %s %s %s %s"
                    (Units.Size.value x)
                    (Units.Size.value y)
                    (Units.Size.value blur)
                    (Units.Size.value spread)
                    (CssColorValue.color color)
            | BoxShadowType.Inset shadow ->
                sprintf "inset %s" <| boxShadowToString shadow

    let private boxShadowValue value = PropertyValue.cssValue Property.BoxShadow value
    type BoxShadow =
        static member Color (x: Units.Size.Size, y: Units.Size.Size, color: CssColor) = BoxShadowType.Color(x, y, color)
        static member BlurColor (x: Units.Size.Size, y: Units.Size.Size, blur: Units.Size.Size, color: CssColor) =
                BoxShadowType.BlurColor(x, y, blur, color)
        static member BlurSpreadColor (x: Units.Size.Size, y: Units.Size.Size, blur: Units.Size.Size, spread: Units.Size.Size, color: CssColor) =
                BoxShadowType.BlurSpreadColor(x, y, blur, spread, color)

    /// Supply a list of box shadows to be applied to the element.
    let BoxShadows (shadows: BoxShadowType.BoxShadow list): CSSProperty =
        shadows
        |> Utilities.Helpers.combineComma boxShadowToString
        |> boxShadowValue

    /// Can be used to invert box shadow
    let Inset (shadow: BoxShadowType.BoxShadow) = BoxShadowType.Inset shadow