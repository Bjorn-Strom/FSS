namespace Fss

open Fable.Core

[<AutoOpen>]
module BoxShadow =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
    let rec private boxShadowToString =
        function
            | FssTypes.BoxShadow.Color (x, y, color) ->
                sprintf "%s %s %s"
                    (FssTypes.unitHelpers.sizeToString x)
                    (FssTypes.unitHelpers.sizeToString y)
                    (FssTypes.Color.colorHelpers.colorToString color)
            | FssTypes.BoxShadow.BlurColor (x, y, blur, color) ->
                sprintf "%s %s %s %s"
                    (FssTypes.unitHelpers.sizeToString x)
                    (FssTypes.unitHelpers.sizeToString y)
                    (FssTypes.unitHelpers.sizeToString blur)
                    (FssTypes.Color.colorHelpers.colorToString color)
            | FssTypes.BoxShadow.BlurSpreadColor (x, y, blur, spread, color) ->
                sprintf "%s %s %s %s %s"
                    (FssTypes.unitHelpers.sizeToString x)
                    (FssTypes.unitHelpers.sizeToString y)
                    (FssTypes.unitHelpers.sizeToString blur)
                    (FssTypes.unitHelpers.sizeToString spread)
                    (FssTypes.Color.colorHelpers.colorToString color)
            | FssTypes.BoxShadow.Inset shadow ->
                sprintf "inset %s" <| boxShadowToString shadow

    let private boxShadowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BoxShadow value
    [<Erase>]
    type BoxShadow =
        static member color (x: FssTypes.Size, y: FssTypes.Size, color: FssTypes.Color.ColorType) = FssTypes.BoxShadow.Color(x, y, color)
        static member blurColor (x: FssTypes.Size, y: FssTypes.Size, blur: FssTypes.Size, color: FssTypes.Color.ColorType) =
                FssTypes.BoxShadow.BlurColor(x, y, blur, color)
        static member blurSpreadColor (x: FssTypes.Size, y: FssTypes.Size, blur: FssTypes.Size, spread: FssTypes.Size, color: FssTypes.Color.ColorType) =
                FssTypes.BoxShadow.BlurSpreadColor(x, y, blur, spread, color)

    /// Supply a list of box shadows to be applied to the element.
    let BoxShadows (shadows: FssTypes.BoxShadow.BoxShadow list): FssTypes.CssProperty =
        shadows
        |> Utilities.Helpers.combineComma boxShadowToString
        |> boxShadowValue

    /// Can be used to invert box shadow
    let Inset (shadow: FssTypes.BoxShadow.BoxShadow) = FssTypes.BoxShadow.Inset shadow