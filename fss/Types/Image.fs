namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Image =
        type Side =
            | ClosestSide
            | ClosestCorner
            | FarthestSide
            | FarthestCorner

        type Shape =
            | Circle
            | Ellipse

        let private stringifyGradientPercent (color, stop) =
            $"{colorToString color} {percentToString stop}"

        let private stringifyGradientPx (color, stop) =
            $"{colorToString color} {sizeToString stop}"

        let  private stringifyLinearPercent gradients =
            let (angle, gradients) = gradients
            $"linear-gradient({angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

        let private stringifyLinearPixels gradients =
            let (angle, gradients) = gradients
            $"linear-gradient({angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients})"

        let private stringifyRepeatingLinearPercent gradients =
            let (angle, gradients) = gradients
            $"repeating-linear-gradient({angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

        let private stringifyRepeatingLinearPixels gradients =
            let (angle, gradients) = gradients
            $"repeating-linear-gradient({angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients})"

        let private stringifyRadialPercent (gradient: Shape * Side * Percent * Percent * (ColorType * Percent) list) =
            let shape, size, x, y, gradients = gradient
            let shape = Fss.Utilities.Helpers.duToLowercase shape
            let size = Fss.Utilities.Helpers.duToKebab size
            let gradients = Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients
            $"radial-gradient({shape} {size} at {percentToString x} {percentToString y}, {gradients})"

        let private stringifyRadialPx (gradient: Shape * Side * Percent * Percent * (ColorType * Length) list) =
            let shape, size, x, y, gradients = gradient
            let shape = Fss.Utilities.Helpers.duToLowercase shape
            let size = Fss.Utilities.Helpers.duToKebab size
            let gradients = Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients
            $"radial-gradient({shape} {size} at {percentToString x} {percentToString y}, {gradients})"

        let private stringifyRepeatingRadialPercent (gradient: Shape * Side * Percent * Percent * (ColorType * Percent) list) =
            $"repeating-{stringifyRadialPercent gradient}"

        let private stringifyRepeatingRadialPx (gradient: Shape * Side * Percent * Percent * (ColorType * Length) list) =
            $"repeating-{stringifyRadialPx gradient}"

        let private stringifyConicAngle (color, angle) =
            $"{colorToString color} {angleToString angle}"

        let private stringifyConicPercent (color, angle) =
            $"{colorToString color} {percentToString angle}"

        let private stringifyConicGradientAngle angle x y gradients =
            let angle = angleToString angle
            let x = percentToString x
            let y = percentToString y
            let gradients = Fss.Utilities.Helpers.combineComma stringifyConicAngle gradients
            $"conic-Gradient(from {angle} at {x} {y}, {gradients})"

        let private stringifyConicGradientPercent angle x y gradients =
            let angle = angleToString angle
            let x = percentToString x
            let y = percentToString y
            let gradients = Fss.Utilities.Helpers.combineComma stringifyConicPercent gradients
            $"conic-Gradient(from {angle} at {x} {y}, {gradients})"

        let private stringifyRepeatingConicAngle angle x y gradients =
            $"repeating-{stringifyConicGradientAngle angle x y gradients}"

        let private stringifyRepeatingConicPercent angle x y gradients =
            $"repeating-{stringifyConicGradientPercent angle x y gradients}"

        type Image (valueFunction: string -> CssProperty) =
            member this.url (url: string) = sprintf "url(%s)" url |> valueFunction
            member this.linearGradient (gradients: Angle * (ColorType * Percent) list) =
                stringifyLinearPercent gradients |> valueFunction
            member this.linearGradient (gradients: Angle * (ColorType * Length) list) =
                stringifyLinearPixels gradients |> valueFunction
            member this.linearGradients (gradients: (Angle * ((ColorType * Length) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyLinearPixels gradients |> valueFunction
            member this.linearGradients (gradients: (Angle * ((ColorType * Percent) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyLinearPercent gradients |> valueFunction
            member this.repeatingLinearGradient (gradients: Angle * (ColorType * Percent) list) =
                stringifyRepeatingLinearPercent gradients |> valueFunction
            member this.repeatingLinearGradient (gradients: Angle * (ColorType * Length) list) =
                stringifyRepeatingLinearPixels gradients |> valueFunction
            member this.repeatingLinearGradients (gradients: (Angle * ((ColorType * Length) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPixels gradients |> valueFunction
            member this.repeatingLinearGradients (gradients: (Angle * ((ColorType * Percent) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPercent gradients |> valueFunction

            member this.radialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyRadialPercent(shape, size, x, y, gradients) |> valueFunction
            member this.radialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Length) list) =
                stringifyRadialPx(shape, size, x, y, gradients) |> valueFunction
            member this.radialGradients (gradients: (Shape * Side * Percent * Percent * (ColorType * Percent) list) list) =
                Fss.Utilities.Helpers.combineComma stringifyRadialPercent gradients |> valueFunction
            member this.radialGradients (gradients: (Shape * Side * Percent * Percent * (ColorType * Length) list) list) =
                Fss.Utilities.Helpers.combineComma stringifyRadialPx gradients |> valueFunction
            member this.repeatingRadialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyRepeatingRadialPercent(shape, size, x, y, gradients) |> valueFunction
            member this.repeatingRadialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Length) list) =
                stringifyRepeatingRadialPx(shape, size, x, y, gradients) |> valueFunction

            member this.conicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Angle) list) =
                stringifyConicGradientAngle angle x y gradients |> valueFunction
            member this.repeatingConicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Angle) list) =
                stringifyRepeatingConicAngle angle x y gradients |> valueFunction
            member this.conicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyConicGradientPercent angle x y gradients |> valueFunction
            member this.repeatingConicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyRepeatingConicPercent angle x y gradients |> valueFunction

        type ObjectFit =
            | Fill
            | Contain
            | Cover
            | ScaleDown
            interface IObjectFit

        type Rendering =
            | CrispEdges
            | Pixelated
            interface IImageRendering

