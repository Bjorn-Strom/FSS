namespace Fss

module BoxShadowType =
    type BoxShadow =
        | Shadow of IBoxShadow
        | Color of Units.Size.Size * Units.Size.Size * CssColor
        | BlurColor of Units.Size.Size * Units.Size.Size * Units.Size.Size * CssColor
        | BlurSpreadColor of Units.Size.Size * Units.Size.Size * Units.Size.Size * Units.Size.Size * CssColor
        interface IBoxShadow

[<AutoOpen>]
module BoxShadow =
    open BoxShadowType

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
    let private boxShadowToString (boxShadow: IBoxShadow) =
        let stringifyBoxShadow =
            function
                | Color (x, y, color) ->
                    sprintf "%s %s %s"
                        (Units.Size.value x)
                        (Units.Size.value y)
                        (CssColorValue.color color)
                | BlurColor (x, y, blur, color) ->
                    sprintf "%s %s %s %s"
                        (Units.Size.value x)
                        (Units.Size.value y)
                        (Units.Size.value blur)
                        (CssColorValue.color color)
                | BlurSpreadColor (x, y, blur, spread, color) ->
                    sprintf "%s %s %s %s %s"
                        (Units.Size.value x)
                        (Units.Size.value y)
                        (Units.Size.value blur)
                        (Units.Size.value spread)
                        (CssColorValue.color color)
                | _ -> "Must be a box shadow type"

        match boxShadow with
        | :? BoxShadow as b -> stringifyBoxShadow b
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown box shadow"

    let private boxShadowValue value = PropertyValue.cssValue Property.BoxShadow value
    let private boxShadowValue' value =
        value
        |> boxShadowToString
        |> boxShadowValue
    let private boxShadowValues (values: BoxShadow list) =
        values
        |> Utilities.Helpers.combineComma boxShadowToString
        |> boxShadowValue

    type BoxShadow =
        static member Value (boxShadow: IBoxShadow) = boxShadow |> boxShadowValue'
        static member Color (x: Units.Size.Size, y: Units.Size.Size, color: CssColor) =
                Color(x, y, color) |> boxShadowValue'
        static member BlurColor (x: Units.Size.Size, y: Units.Size.Size, blur: Units.Size.Size, color: CssColor) =
                BlurColor(x, y, blur, color) |> boxShadowValue'
        static member BlurSpreadColor (x: Units.Size.Size, y: Units.Size.Size, blur: Units.Size.Size, spread: Units.Size.Size, color: CssColor) =
                BlurSpreadColor(x, y, blur, spread, color) |> boxShadowValue'
        static member Values (boxShadows: BoxShadowType.BoxShadow list) = boxShadowValues boxShadows

        static member Inherit = Inherit |> boxShadowValue'
        static member Initial = Initial |> boxShadowValue'
        static member Unset = Unset |> boxShadowValue'
        static member None = None |> boxShadowValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="boxShadow">
    ///     can be:
    ///     - <c> BoxShadowType </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let BoxShadow' (boxShadow: IBoxShadow) = boxShadow |> BoxShadow.Value
