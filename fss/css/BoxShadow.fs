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

    let private boxShadowValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BoxShadow
    [<Erase>]
    type BoxShadow =
        static member color (x: FssTypes.Length, y: FssTypes.Length, color: FssTypes.Color.ColorType) = FssTypes.BoxShadow.Color(x, y, color)
        static member blurColor (x: FssTypes.Length, y: FssTypes.Length, blur: FssTypes.Length, color: FssTypes.Color.ColorType) =
                FssTypes.BoxShadow.BlurColor(x, y, blur, color)
        static member blurSpreadColor (x: FssTypes.Length, y: FssTypes.Length, blur: FssTypes.Length, spread: FssTypes.Length, color: FssTypes.Color.ColorType) =
                FssTypes.BoxShadow.BlurSpreadColor(x, y, blur, spread, color)

    /// Supply a list of box shadows to be applied to the element.
    let BoxShadows = Utilities.Helpers.combineComma boxShadowToString >> boxShadowValue

    /// Can be used to invert box shadow
    let Inset = FssTypes.BoxShadow.Inset