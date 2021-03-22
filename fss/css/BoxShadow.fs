namespace Fss

[<AutoOpen>]
module BoxShadow =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
    let rec private boxShadowToString =
        function
            | Types.BoxShadow.Color (x, y, color) ->
                sprintf "%s %s %s"
                    (Types.unitHelpers.sizeToString x)
                    (Types.unitHelpers.sizeToString y)
                    (Types.colorHelpers.colorToString color)
            | Types.BoxShadow.BlurColor (x, y, blur, color) ->
                sprintf "%s %s %s %s"
                    (Types.unitHelpers.sizeToString x)
                    (Types.unitHelpers.sizeToString y)
                    (Types.unitHelpers.sizeToString blur)
                    (Types.colorHelpers.colorToString color)
            | Types.BoxShadow.BlurSpreadColor (x, y, blur, spread, color) ->
                sprintf "%s %s %s %s %s"
                    (Types.unitHelpers.sizeToString x)
                    (Types.unitHelpers.sizeToString y)
                    (Types.unitHelpers.sizeToString blur)
                    (Types.unitHelpers.sizeToString spread)
                    (Types.colorHelpers.colorToString color)
            | Types.BoxShadow.Inset shadow ->
                sprintf "inset %s" <| boxShadowToString shadow

    let private boxShadowValue value = Types.propertyHelpers.cssValue Types.Property.BoxShadow value
    type BoxShadow =
        static member Color (x: Types.Size, y: Types.Size, color: Types.ColorTypeFoo) = Types.BoxShadow.Color(x, y, color)
        static member BlurColor (x: Types.Size, y: Types.Size, blur: Types.Size, color: Types.ColorTypeFoo) =
                Types.BoxShadow.BlurColor(x, y, blur, color)
        static member BlurSpreadColor (x: Types.Size, y: Types.Size, blur: Types.Size, spread: Types.Size, color: Types.ColorTypeFoo) =
                Types.BoxShadow.BlurSpreadColor(x, y, blur, spread, color)

    /// Supply a list of box shadows to be applied to the element.
    let BoxShadows (shadows: Types.BoxShadow.BoxShadow list): Types.CssProperty =
        shadows
        |> Utilities.Helpers.combineComma boxShadowToString
        |> boxShadowValue

    /// Can be used to invert box shadow
    let Inset (shadow: Types.BoxShadow.BoxShadow) = Types.BoxShadow.Inset shadow