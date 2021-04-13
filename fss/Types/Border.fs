namespace Fss

namespace Fss.FssTypes

    [<RequireQualifiedAccess>]
    module Border =
        type Width =
            | Thin
            | Medium
            | Thick
            interface IBorderWidth

        type BorderValue (valueFunction: IBorderWidth -> CssProperty) =
            member this.value (width: IBorderWidth) = width |> valueFunction
            member this.thin = Width.Thin |> valueFunction
            member this.medium = Width.Medium |> valueFunction
            member this.thick = Width.Thick |> valueFunction

            member this.inherit' = Inherit |> valueFunction
            member this.initial = Initial |> valueFunction
            member this.unset = Unset |> valueFunction

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
            interface IBorderStyle

        type BorderSideStyle (valueFunction: IBorderStyle -> CssProperty) =
            member this.value (style: IBorderStyle) = style |> valueFunction
            member this.hidden = Hidden |> valueFunction
            member this.dotted = Dotted |> valueFunction
            member this.dashed = Dashed |> valueFunction
            member this.solid = Solid |> valueFunction
            member this.double = Double |> valueFunction
            member this.groove = Groove |> valueFunction
            member this.ridge = Ridge |> valueFunction
            member this.inset = Inset |> valueFunction
            member this.outset = Outset |> valueFunction

            member this.none = None' |> valueFunction
            member this.inherit' = Inherit |> valueFunction
            member this.initial = Initial |> valueFunction
            member this.unset = Unset |> valueFunction

        type BorderStyle (styleToString: IBorderStyle -> string, valueFunction: string -> CssProperty) =
            member this.value (vertical: IBorderStyle, horizontal: IBorderStyle) =
                sprintf "%s %s"
                    (styleToString vertical)
                    (styleToString horizontal)
                |> valueFunction
            member this.value (top: IBorderStyle, horizontal: IBorderStyle, bottom: IBorderStyle) =
                sprintf "%s %s %s"
                    (styleToString top)
                    (styleToString horizontal)
                    (styleToString bottom)
                |> valueFunction
            member this.value (top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle, left: IBorderStyle) =
                sprintf "%s %s %s %s"
                    (styleToString top)
                    (styleToString right)
                    (styleToString bottom)
                    (styleToString left)
                |> valueFunction

        type BorderColor (colorToString: IBorderColor -> string, valueFunction: string -> CssProperty, valueFunction': IBorderColor -> CssProperty) =
            inherit ColorBase<CssProperty> (valueFunction')
            member this.value (color: IBorderColor) = color |> valueFunction'
            member this.value (horizontal: IBorderColor, vertical: IBorderColor) =
                sprintf "%s %s"
                    (colorToString horizontal)
                    (colorToString vertical)
                |> valueFunction
            member this.value (top: IBorderColor, vertical: IBorderColor, bottom: IBorderColor) =
                sprintf "%s %s %s"
                    (colorToString top)
                    (colorToString vertical)
                    (colorToString bottom)
                |> valueFunction
            member this.value (top: IBorderColor, right: IBorderColor, bottom: IBorderColor, left: IBorderColor) =
                sprintf "%s %s %s %s"
                    (colorToString top)
                    (colorToString right)
                    (colorToString bottom)
                    (colorToString left)
                |> valueFunction
            member this.inherit' = Inherit |> valueFunction'
            member this.initial = Initial |> valueFunction'
            member this.unset = Unset |> valueFunction'

        type BorderSideColor (valueFunction: IBorderColor -> CssProperty) =
            inherit ColorBase<CssProperty> (valueFunction)
            member this.value color = color |> valueFunction
            member this.inherit' = Inherit |> valueFunction
            member this.initial = Initial |> valueFunction
            member this.unset = Unset |> valueFunction

        type Collapse =
            | Collapse
            | Separate
            interface IBorderCollapse

        type ImageOutset =
            | ImageOutset of float
            interface IBorderImageOutset

        type ImageRepeat =
            | Stretch
            | Repeat
            | Round
            | Space
            interface IBorderRepeat

        type ImageSlice =
            | Value of float
            | Fill
            interface IBorderImageSlice

        type BorderImage (valueFunction: string -> CssProperty, valueFunction': IBorderImageSource -> CssProperty) =
            inherit Image.Image(valueFunction)
            member this.value value = value |> valueFunction'
            member this.none = None' |> valueFunction'
            member this.inherit' = Inherit |> valueFunction'
            member this.initial = Initial |> valueFunction'
            member this.unset = Unset |> valueFunction'



