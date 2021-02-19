namespace Fss

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
        $"linear-gradient({Units.Angle.value angle}, {Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

    let private stringifyLinearPixels gradients =
        let (angle, gradients) = gradients
        $"linear-gradient({Units.Angle.value angle}, {Utilities.Helpers.combineComma stringifyGradientPx gradients})"

    let private stringifyRepeatingLinearPercent gradients =
        let (angle, gradients) = gradients
        $"repeating-linear-gradient({Units.Angle.value angle}, {Utilities.Helpers.combineComma stringifyGradientPercent gradients})"

    let private stringifyRepeatingLinearPixels gradients =
        let (angle, gradients) = gradients
        $"repeating-linear-gradient({Units.Angle.value angle}, {Utilities.Helpers.combineComma stringifyGradientPx gradients})"

    let private stringifyRadialPercent (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) =
        let shape, size, x, y, gradients = gradient
        let shape = Utilities.Helpers.duToLowercase shape
        let size = Utilities.Helpers.duToKebab size
        let gradients = Utilities.Helpers.combineComma stringifyGradientPercent gradients
        $"radial-gradient({shape} {size} at {Units.Percent.value x} {Units.Percent.value y}, {gradients})"

    let private stringifyRadialPx (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) =
        let shape, size, x, y, gradients = gradient
        let shape = Utilities.Helpers.duToLowercase shape
        let size = Utilities.Helpers.duToKebab size
        let gradients = Utilities.Helpers.combineComma stringifyGradientPx gradients
        $"radial-gradient({shape} {size} at {Units.Percent.value x} {Units.Percent.value y}, {gradients})"

    let private stringifyRepeatingRadialPercent (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) =
        $"repeating-{stringifyRadialPercent gradient}"

    let private stringifyRepeatingRadialPx (gradient: Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) =
        $"repeating-{stringifyRadialPx gradient}"


    type Image =
        static member Url (url: string) = sprintf "url(%s)" url
        static member LinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Percent.Percent) list) =
            stringifyLinearPercent gradients
        static member LinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Size.Size) list) =
            stringifyLinearPixels gradients
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            Utilities.Helpers.combineComma stringifyLinearPixels gradients
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            Utilities.Helpers.combineComma stringifyLinearPercent gradients
        static member RepeatingLinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Percent.Percent) list) =
            stringifyRepeatingLinearPercent gradients
        static member RepeatingLinearGradient (gradients: Units.Angle.Angle * (CssColor * Units.Size.Size) list) =
            stringifyRepeatingLinearPixels gradients
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            Utilities.Helpers.combineComma stringifyRepeatingLinearPixels gradients
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            Utilities.Helpers.combineComma stringifyRepeatingLinearPercent gradients

        static member RadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            stringifyRadialPercent(shape, size, x, y, gradients)
        static member RadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            stringifyRadialPx(shape, size, x, y, gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) list) =
            Utilities.Helpers.combineComma stringifyRadialPercent gradients
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) list) =
            Utilities.Helpers.combineComma stringifyRadialPx gradients
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            stringifyRepeatingRadialPercent(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            stringifyRepeatingRadialPx(shape, size, x, y, gradients)
