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

        type Image =
            static member Url (url: string) = sprintf "url(%s)" url
            static member LinearGradient (gradients: Angle * (ColorType * Percent) list) =
                stringifyLinearPercent gradients
            static member LinearGradient (gradients: Angle * (ColorType * Length) list) =
                stringifyLinearPixels gradients
            static member LinearGradients (gradients: (Angle * ((ColorType * Length) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyLinearPixels gradients
            static member LinearGradients (gradients: (Angle * ((ColorType * Percent) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyLinearPercent gradients
            static member RepeatingLinearGradient (gradients: Angle * (ColorType * Percent) list) =
                stringifyRepeatingLinearPercent gradients
            static member RepeatingLinearGradient (gradients: Angle * (ColorType * Length) list) =
                stringifyRepeatingLinearPixels gradients
            static member RepeatingLinearGradients (gradients: (Angle * ((ColorType * Length) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPixels gradients
            static member RepeatingLinearGradients (gradients: (Angle * ((ColorType * Percent) list)) list) =
                Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPercent gradients

            static member RadialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyRadialPercent(shape, size, x, y, gradients)
            static member RadialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Length) list) =
                stringifyRadialPx(shape, size, x, y, gradients)
            static member RadialGradients (gradients: (Shape * Side * Percent * Percent * (ColorType * Percent) list) list) =
                Fss.Utilities.Helpers.combineComma stringifyRadialPercent gradients
            static member RadialGradients (gradients: (Shape * Side * Percent * Percent * (ColorType * Length) list) list) =
                Fss.Utilities.Helpers.combineComma stringifyRadialPx gradients
            static member RepeatingRadialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyRepeatingRadialPercent(shape, size, x, y, gradients)
            static member RepeatingRadialGradient (shape: Shape, size: Side, x: Percent, y: Percent, gradients: (ColorType * Length) list) =
                stringifyRepeatingRadialPx(shape, size, x, y, gradients)

            static member ConicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Angle) list) =
                stringifyConicGradientAngle angle x y gradients
            static member RepeatingConicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Angle) list) =
                stringifyRepeatingConicAngle angle x y gradients
            static member ConicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyConicGradientPercent angle x y gradients
            static member RepeatingConicGradient (angle: Angle, x: Percent, y: Percent, gradients: (ColorType * Percent) list) =
                stringifyRepeatingConicPercent angle x y gradients

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

