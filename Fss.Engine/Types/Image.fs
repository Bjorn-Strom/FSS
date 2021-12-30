namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Image =
    type Side =
        | ClosestSide
        | ClosestCorner
        | FarthestSide
        | FarthestCorner
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Shape =
        | Circle
        | Ellipse
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type ObjectFit =
        | Fill
        | Contain
        | Cover
        | ScaleDown
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Rendering =
        | CrispEdges
        | Pixelated
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Image =
        | Url of string
        | UrlAlt of string * Stringed
        | LinearGradient of Angle * (Color * ILengthPercentage) list
        | LinearGradients of (Angle * (Color * ILengthPercentage) list) list
        | RepeatingLinearGradient of Angle * (Color * ILengthPercentage) list
        | RepeatingLinearGradients of (Angle * (Color * ILengthPercentage) list) list
        | RadialGradient of Shape * Side * Percent * Percent * (Color * ILengthPercentage) list
        | RadialGradients of (Shape * Side * Percent * Percent * (Color * ILengthPercentage) list) list
        | RepeatingRadialGradient of Shape * Side * Percent * Percent * (Color * ILengthPercentage) list
        | RepeatingRadialGradients of (Shape * Side * Percent * Percent * (Color * ILengthPercentage) list) list
        | ConicGradientAngle of Angle * Percent * Percent * (Color * Angle) list
        | ConicGradientPercent of Angle * Percent * Percent * (Color * Percent) list
        | RepeatingConicGradientAngle of Angle * Percent * Percent * (Color * Angle) list
        | RepeatingConicGradientPercent of Angle * Percent * Percent * (Color * Percent) list
        interface ICounterValue with
            member this.StringifyCounter() = stringifyICssValue this

        interface ICssValue with
            member this.StringifyCss() =
                let gradientToString (gradients: (Color.Color * ILengthPercentage) list) =
                    List.fold
                        (fun (acc: string) (color, length) ->
                            $"{acc}, {stringifyICssValue color} {lengthPercentageString length}")
                        ""
                        gradients

                let gradientAngleToString (gradients: (Color.Color * Angle) list) =
                    List.fold
                        (fun (acc: string) (color, angle) ->
                            $"{acc}, {stringifyICssValue color} {stringifyICssValue angle}")
                        ""
                        gradients

                let gradientPercentToString (gradients: (Color.Color * Percent) list) =
                    List.fold
                        (fun (acc: string) (color, length) ->
                            $"{acc}, {stringifyICssValue color} {stringifyICssValue length}")
                        ""
                        gradients

                let linearGradientToString (angle, gradients) =
                    $"linear-gradient({stringifyICssValue angle}{gradientToString gradients})"

                let linearGradientsToString gradients =
                    List.map linearGradientToString gradients
                    |> String.concat ", "

                let repeatingLinearGradient (angle, gradients) =
                    $"repeating-linear-gradient({stringifyICssValue angle}{gradientToString gradients})"

                let repeatingLinearGradients gradients =
                    List.map repeatingLinearGradient gradients
                    |> String.concat ", "

                let radialGradientToString (shape, side, x, y, gradients) =
                    $"radial-gradient({shape.ToString().ToLower()} {stringifyICssValue side} at {stringifyICssValue x} {stringifyICssValue y}{gradientToString gradients})"

                let radialGradientsToString gradients =
                    List.map radialGradientToString gradients
                    |> String.concat ", "

                let repeatingRadialGradientToString (shape, side, x, y, gradients) =
                    $"repeating-radial-gradient({shape.ToString().ToLower()} {stringifyICssValue side} at {stringifyICssValue x} {stringifyICssValue y}{gradientToString gradients})"

                let repeatingRadialGradientsToString gradients =
                    List.map repeatingRadialGradientToString gradients
                    |> String.concat ", "

                let conicGradientAngleToString (angle, x, y, gradients) =
                    $"conic-gradient(from {stringifyICssValue angle} at {stringifyICssValue x} {stringifyICssValue y}{gradientAngleToString gradients})"

                let conicGradientPercentToString (angle, x, y, gradients) =
                    $"conic-gradient(from {stringifyICssValue angle} at {stringifyICssValue x} {stringifyICssValue y}{gradientPercentToString gradients})"

                let repeatingConicGradientAngleToString (angle, x, y, gradients) =
                    $"repeating-conic-gradient(from {stringifyICssValue angle} at {stringifyICssValue x} {stringifyICssValue y}{gradientAngleToString gradients})"

                let repeatingConicGradientPercentToString (angle, x, y, gradients) =
                    $"repeating-conic-gradient(from {stringifyICssValue angle} at {stringifyICssValue x} {stringifyICssValue y}{gradientPercentToString gradients})"

                match this with
                | Image.Url u -> $"url({u})"
                | Image.UrlAlt (u, a) -> $"url({u}) / {stringifyICssValue a}"
                | Image.LinearGradient (angle, gradients) -> linearGradientToString (angle, gradients)
                | Image.LinearGradients gradients -> linearGradientsToString gradients
                | Image.RepeatingLinearGradient (angle, gradients) -> repeatingLinearGradient (angle, gradients)
                | Image.RepeatingLinearGradients gradients -> repeatingLinearGradients gradients
                | Image.RadialGradient (shape, side, x, y, gradients) ->
                    radialGradientToString (shape, side, x, y, gradients)
                | Image.RadialGradients gradients -> radialGradientsToString gradients
                | Image.RepeatingRadialGradient (shape, side, x, y, gradients) ->
                    repeatingRadialGradientToString (shape, side, x, y, gradients)
                | Image.RepeatingRadialGradients gradients -> repeatingRadialGradientsToString gradients
                | Image.ConicGradientAngle (angle, x, y, gradients) ->
                    conicGradientAngleToString (angle, x, y, gradients)
                | Image.ConicGradientPercent (angle, x, y, gradients) ->
                    conicGradientPercentToString (angle, x, y, gradients)
                | Image.RepeatingConicGradientAngle (angle, x, y, gradients) ->
                    repeatingConicGradientAngleToString (angle, x, y, gradients)
                | Image.RepeatingConicGradientPercent (angle, x, y, gradients) ->
                    repeatingConicGradientPercentToString (angle, x, y, gradients)

[<RequireQualifiedAccess>]
module ImageClasses =
    type Image =
        static member url(url: string) = Url url
        static member urlAlt(url: string, alt: string) = Image.UrlAlt(url, Stringed alt)

        static member linearGradient(gradients: Angle * (Color * ILengthPercentage) list) =
            Image.LinearGradient gradients

        static member linearGradients(gradients: (Angle * (Color * ILengthPercentage) list) list) =
            Image.LinearGradients gradients


        static member repeatingLinearGradient(gradients: Angle * (Color * ILengthPercentage) list) =
            Image.RepeatingLinearGradient gradients


        static member repeatingLinearGradients(gradients: (Angle * (Color * ILengthPercentage) list) list) =
            Image.RepeatingLinearGradients gradients


        static member radialGradient
            (
                shape: Image.Shape,
                size: Image.Side,
                x: Percent,
                y: Percent,
                gradients: (Color * ILengthPercentage) list
            ) =
            Image.RadialGradient(shape, size, x, y, gradients)


        static member radialGradients
            (gradients: (Image.Shape * Image.Side * Percent * Percent * (Color * ILengthPercentage) list) list)
            =
            Image.RadialGradients(gradients)


        static member repeatingRadialGradient
            (
                shape: Image.Shape,
                size: Image.Side,
                x: Percent,
                y: Percent,
                gradients: (Color * ILengthPercentage) list
            ) =
            Image.RepeatingRadialGradient(shape, size, x, y, gradients)

        static member conicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Angle) list) =
            Image.ConicGradientAngle(angle, x, y, gradients)


        static member conicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Percent) list) =
            Image.ConicGradientPercent(angle, x, y, gradients)


        static member repeatingConicGradient
            (
                angle: Angle,
                x: Percent,
                y: Percent,
                gradients: (Color * Angle) list
            ) =
            Image.RepeatingConicGradientAngle(angle, x, y, gradients)


        static member repeatingConicGradient
            (
                angle: Angle,
                x: Percent,
                y: Percent,
                gradients: (Color * Percent) list
            ) =
            Image.RepeatingConicGradientPercent(angle, x, y, gradients)

    type ImageClass(property) =
        inherit CssRuleWithNone(property)
        member this.url(url: string) = (property, Image.url url) |> Rule

        member this.url(url: string, alt: string) =
            (property, Image.urlAlt (url, alt)) |> Rule

        member this.linearGradient(gradients: Angle * (Color * ILengthPercentage) list) =
            (property, Image.linearGradient gradients) |> Rule

        member this.linearGradients(gradients: (Angle * (Color * ILengthPercentage) list) list) =
            (property, Image.linearGradients gradients)
            |> Rule

        member this.repeatingLinearGradient(gradients: Angle * (Color * ILengthPercentage) list) =
            (property, Image.RepeatingLinearGradient gradients)
            |> Rule

        member this.repeatingLinearGradients(gradients: (Angle * (Color * ILengthPercentage) list) list) =
            (property, Image.RepeatingLinearGradients gradients)
            |> Rule

        member this.radialGradient
            (
                shape: Image.Shape,
                size: Image.Side,
                x: Percent,
                y: Percent,
                gradients: (Color * ILengthPercentage) list
            ) =
            (property, Image.RadialGradient(shape, size, x, y, gradients))
            |> Rule

        member this.radialGradients
            (gradients: (Image.Shape * Image.Side * Percent * Percent * (Color * ILengthPercentage) list) list)
            =
            (property, Image.RadialGradients(gradients))
            |> Rule


        member this.repeatingRadialGradient
            (
                shape: Image.Shape,
                size: Image.Side,
                x: Percent,
                y: Percent,
                gradients: (Color * ILengthPercentage) list
            ) =
            (property, Image.RepeatingRadialGradient(shape, size, x, y, gradients))
            |> Rule

        member this.conicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Angle) list) =
            (property, Image.ConicGradientAngle(angle, x, y, gradients))
            |> Rule


        member this.conicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Percent) list) =
            (property, Image.ConicGradientPercent(angle, x, y, gradients))
            |> Rule


        member this.repeatingConicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Angle) list) =
            (property, Image.RepeatingConicGradientAngle(angle, x, y, gradients))
            |> Rule


        member this.repeatingConicGradient
            (
                angle: Angle,
                x: Percent,
                y: Percent,
                gradients: (Color * Percent) list
            ) =
            (property, Image.RepeatingConicGradientPercent(angle, x, y, gradients))
            |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/object-fit
    type ObjectFit(property) =
        inherit CssRuleWithNone(property)
        member this.fill = (property, Image.Fill) |> Rule
        member this.contain = (property, Image.Contain) |> Rule
        member this.cover = (property, Image.Cover) |> Rule
        member this.scaleDown = (property, Image.ScaleDown) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/object-position
    type ObjectPosition(property) =
        inherit CssRule(property)

        member this.value(x: ILengthPercentage, y: ILengthPercentage) =
            let value =
                $"{lengthPercentageString x} {lengthPercentageString y}"
                |> String

            (property, value) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/image-rendering
    type ImageRendering(property) =
        inherit CssRuleWithAuto(property)
        member this.crispEdges = (property, Image.CrispEdges) |> Rule
        member this.pixelated = (property, Image.Pixelated) |> Rule
