namespace Fss

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
        $"{Types.colorToString color} {Types.percentToString stop}"

    let private stringifyGradientPx (color, stop) =
        $"{Types.colorToString color} {Types.sizeToString stop}"

    let  private stringifyLinearPercent gradients =
        let (angle, gradients) = gradients
        $"linear-gradient({Types.angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

    let private stringifyLinearPixels gradients =
        let (angle, gradients) = gradients
        $"linear-gradient({Types.angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients})"

    let private stringifyRepeatingLinearPercent gradients =
        let (angle, gradients) = gradients
        $"repeating-linear-gradient({Types.angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

    let private stringifyRepeatingLinearPixels gradients =
        let (angle, gradients) = gradients
        $"repeating-linear-gradient({Types.angleToString angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients})"

    let private stringifyRadialPercent (gradient: Shape * Side * Types.Percent * Types.Percent * (Types.Color * Types.Percent) list) =
        let shape, size, x, y, gradients = gradient
        let shape = Fss.Utilities.Helpers.duToLowercase shape
        let size = Fss.Utilities.Helpers.duToKebab size
        let gradients = Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients
        $"radial-gradient({shape} {size} at {Types.percentToString x} {Types.percentToString y}, {gradients})"

    let private stringifyRadialPx (gradient: Shape * Side * Types.Percent * Types.Percent * (Types.Color * Types.Size) list) =
        let shape, size, x, y, gradients = gradient
        let shape = Fss.Utilities.Helpers.duToLowercase shape
        let size = Fss.Utilities.Helpers.duToKebab size
        let gradients = Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients
        $"radial-gradient({shape} {size} at {Types.percentToString x} {Types.percentToString y}, {gradients})"

    let private stringifyRepeatingRadialPercent (gradient: Shape * Side * Types.Percent * Types.Percent * (Types.Color * Types.Percent) list) =
        $"repeating-{stringifyRadialPercent gradient}"

    let private stringifyRepeatingRadialPx (gradient: Shape * Side * Types.Percent * Types.Percent * (Types.Color * Types.Size) list) =
        $"repeating-{stringifyRadialPx gradient}"

    let private stringifyConicAngle (color, angle) =
        $"{Types.colorToString color} {Types.angleToString angle}"

    let private stringifyConicPercent (color, angle) =
        $"{Types.colorToString color} {Types.percentToString angle}"

    let private stringifyConicGradientAngle angle x y gradients =
        let angle = Types.angleToString angle
        let x = Types.percentToString x
        let y = Types.percentToString y
        let gradients = Fss.Utilities.Helpers.combineComma stringifyConicAngle gradients
        $"conic-Gradient(from {angle} at {x} {y}, {gradients})"

    let private stringifyConicGradientPercent angle x y gradients =
        let angle = Types.angleToString angle
        let x = Types.percentToString x
        let y = Types.percentToString y
        let gradients = Fss.Utilities.Helpers.combineComma stringifyConicPercent gradients
        $"conic-Gradient(from {angle} at {x} {y}, {gradients})"

    let private stringifyRepeatingConicAngle angle x y gradients =
        $"repeating-{stringifyConicGradientAngle angle x y gradients}"

    let private stringifyRepeatingConicPercent angle x y gradients =
        $"repeating-{stringifyConicGradientPercent angle x y gradients}"

    type Image =
        static member Url (url: string) = sprintf "url(%s)" url
        static member LinearGradient (gradients: Types.Angle * (Types.Color * Types.Percent) list) =
            stringifyLinearPercent gradients
        static member LinearGradient (gradients: Types.Angle * (Types.Color * Types.Size) list) =
            stringifyLinearPixels gradients
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyLinearPixels gradients
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyLinearPercent gradients
        static member RepeatingLinearGradient (gradients: Types.Angle * (Types.Color * Types.Percent) list) =
            stringifyRepeatingLinearPercent gradients
        static member RepeatingLinearGradient (gradients: Types.Angle * (Types.Color * Types.Size) list) =
            stringifyRepeatingLinearPixels gradients
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPixels gradients
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPercent gradients

        static member RadialGradient (shape: Shape, size: Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            stringifyRadialPercent(shape, size, x, y, gradients)
        static member RadialGradient (shape: Shape, size: Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            stringifyRadialPx(shape, size, x, y, gradients)
        static member RadialGradients (gradients: (Shape * Side * Types.Percent * Types.Percent * (Types.Color * Types.Percent) list) list) =
            Fss.Utilities.Helpers.combineComma stringifyRadialPercent gradients
        static member RadialGradients (gradients: (Shape * Side * Types.Percent * Types.Percent * (Types.Color * Types.Size) list) list) =
            Fss.Utilities.Helpers.combineComma stringifyRadialPx gradients
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            stringifyRepeatingRadialPercent(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            stringifyRepeatingRadialPx(shape, size, x, y, gradients)

        static member ConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Angle) list) =
            stringifyConicGradientAngle angle x y gradients
        static member RepeatingConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Angle) list) =
            stringifyRepeatingConicAngle angle x y gradients
        static member ConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            stringifyConicGradientPercent angle x y gradients
        static member RepeatingConicGradient (angle: Types.Angle, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            stringifyRepeatingConicPercent angle x y gradients

