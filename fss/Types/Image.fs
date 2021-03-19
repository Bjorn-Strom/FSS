namespace FssTypes

[<AutoOpen>]
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
        $"{CssColorValue.color color} {Units.Percent.value stop}"

    let private stringifyGradientPx (color, stop) =
        $"{CssColorValue.color color} {Units.Size.value stop}"

    let  private stringifyLinearPercent gradients =
        let (angle, gradients) = gradients
        $"linear-gradient({Units.Angle.value angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

    let private stringifyLinearPixels gradients =
        let (angle, gradients) = gradients
        $"linear-gradient({Units.Angle.value angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients})"

    let private stringifyRepeatingLinearPercent gradients =
        let (angle, gradients) = gradients
        $"repeating-linear-gradient({Units.Angle.value angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

    let private stringifyRepeatingLinearPixels gradients =
        let (angle, gradients) = gradients
        $"repeating-linear-gradient({Units.Angle.value angle}, {Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients})"

    let private stringifyRadialPercent (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) =
        let shape, size, x, y, gradients = gradient
        let shape = Fss.Utilities.Helpers.duToLowercase shape
        let size = Fss.Utilities.Helpers.duToKebab size
        let gradients = Fss.Utilities.Helpers.combineComma stringifyGradientPercent gradients
        $"radial-gradient({shape} {size} at {Units.Percent.value x} {Units.Percent.value y}, {gradients})"

    let private stringifyRadialPx (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) =
        let shape, size, x, y, gradients = gradient
        let shape = Fss.Utilities.Helpers.duToLowercase shape
        let size = Fss.Utilities.Helpers.duToKebab size
        let gradients = Fss.Utilities.Helpers.combineComma stringifyGradientPx gradients
        $"radial-gradient({shape} {size} at {Units.Percent.value x} {Units.Percent.value y}, {gradients})"

    let private stringifyRepeatingRadialPercent (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) =
        $"repeating-{stringifyRadialPercent gradient}"

    let private stringifyRepeatingRadialPx (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) =
        $"repeating-{stringifyRadialPx gradient}"

    let private stringifyConicAngle (color, angle) =
        $"{CssColorValue.color color} {Units.Angle.value angle}"

    let private stringifyConicPercent (color, angle) =
        $"{CssColorValue.color color} {Units.Percent.value angle}"

    let private stringifyConicGradientAngle angle x y gradients =
        let angle = Units.Angle.value angle
        let x = Units.Percent.value x
        let y = Units.Percent.value y
        let gradients = Fss.Utilities.Helpers.combineComma stringifyConicAngle gradients
        $"conic-Gradient(from {angle} at {x} {y}, {gradients})"

    let private stringifyConicGradientPercent angle x y gradients =
        let angle = Units.Angle.value angle
        let x = Units.Percent.value x
        let y = Units.Percent.value y
        let gradients = Fss.Utilities.Helpers.combineComma stringifyConicPercent gradients
        $"conic-Gradient(from {angle} at {x} {y}, {gradients})"

    let private stringifyRepeatingConicAngle angle x y gradients =
        $"repeating-{stringifyConicGradientAngle angle x y gradients}"

    let private stringifyRepeatingConicPercent angle x y gradients =
        $"repeating-{stringifyConicGradientPercent angle x y gradients}"

    type Image =
        static member Url (url: string) = sprintf "url(%s)" url
        static member LinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Percent.Percent) list) =
            stringifyLinearPercent gradients
        static member LinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Size.Size) list) =
            stringifyLinearPixels gradients
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyLinearPixels gradients
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyLinearPercent gradients
        static member RepeatingLinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Percent.Percent) list) =
            stringifyRepeatingLinearPercent gradients
        static member RepeatingLinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Size.Size) list) =
            stringifyRepeatingLinearPixels gradients
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPixels gradients
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            Fss.Utilities.Helpers.combineComma stringifyRepeatingLinearPercent gradients

        static member RadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            stringifyRadialPercent(shape, size, x, y, gradients)
        static member RadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            stringifyRadialPx(shape, size, x, y, gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) list) =
            Fss.Utilities.Helpers.combineComma stringifyRadialPercent gradients
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) list) =
            Fss.Utilities.Helpers.combineComma stringifyRadialPx gradients
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            stringifyRepeatingRadialPercent(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            stringifyRepeatingRadialPx(shape, size, x, y, gradients)

        static member ConicGradient (angle: Units.Angle.Angle, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Angle.Angle) list) =
            stringifyConicGradientAngle angle x y gradients
        static member RepeatingConicGradient (angle: Units.Angle.Angle, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Angle.Angle) list) =
            stringifyRepeatingConicAngle angle x y gradients
        static member ConicGradient (angle: Units.Angle.Angle, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            stringifyConicGradientPercent angle x y gradients
        static member RepeatingConicGradient (angle: Units.Angle.Angle, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            stringifyRepeatingConicPercent angle x y gradients

