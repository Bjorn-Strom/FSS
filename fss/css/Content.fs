namespace Fss

[<AutoOpen>]
module Content =

    let private contentTypeToString (content: FssTypes.IContent) =
        match content with
        | :? FssTypes.Content.Content as c -> Utilities.Helpers.duToKebab c
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s |> sprintf "\"%s\""
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Counter.Style as c -> FssTypes.counterStyleHelpers.counterStyleToString c
        | _ -> "Unknown content"

    let private contentValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Content value
    let private contentValue' value =
        value
        |> contentTypeToString
        |> contentValue

    type Content =
        static member openQuote = FssTypes.Content.OpenQuote |> contentValue'
        static member closeQuote = FssTypes.Content.CloseQuote |> contentValue'
        static member noOpenQuote = FssTypes.Content.NoOpenQuote |> contentValue'
        static member noCloseQuote = FssTypes.Content.NoCloseQuote |> contentValue'

        static member counter (counter: FssTypes.Counter.Style) =
            contentValue <| sprintf "counter(%s)" (FssTypes.counterStyleHelpers.counterStyleToString counter)
        static member counters (counter: FssTypes.Counter.Style, listType: FssTypes.IListStyleType) =
            contentValue <| sprintf "counters(%s, %s)" (FssTypes.counterStyleHelpers.counterStyleToString counter) (FssTypes.listStyleHelpers.styleTypeToString listType)
        static member counter (counter: FssTypes.Counter.Style, value: string) =
            contentValue <| sprintf "counter(%s)'%s'" (FssTypes.counterStyleHelpers.counterStyleToString counter) value
        static member counters (counters: FssTypes.Counter.Style list, values: string list) =
            List.zip (List.map FssTypes.counterStyleHelpers.counterStyleToString counters) values
            |> List.map (fun (x, y) -> sprintf "counter(%s) '%s'" x y)
            |> String.concat " "
            |> contentValue
        static member url (url: string) = contentValue <| sprintf "url(%s)" url
        static member url (url: string, altText: string) = contentValue <| sprintf "url(%s) / \"%s\"" url altText
        static member value (value: string) = contentValue <| sprintf "\"%s\"" value
        static member value (content: FssTypes.IContent) = content |> contentValue'
        static member linearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            contentValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member linearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            contentValue <| FssTypes.Image.Image.LinearGradient((angle, gradients))
        static member linearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Percent) list)) list) =
            contentValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member linearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Size) list)) list) =
            contentValue <| FssTypes.Image.Image.LinearGradients(gradients)
        static member repeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            contentValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member repeatingLinearGradient (angle: FssTypes.Angle, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            contentValue <| FssTypes.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member repeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Size) list)) list) =
            contentValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)
        static member repeatingLinearGradients (gradients: (FssTypes.Angle * ((FssTypes.ColorType * FssTypes.Percent) list)) list) =
            contentValue <| FssTypes.Image.Image.RepeatingLinearGradients(gradients)

        static member radialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            contentValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member radialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, xPosition: FssTypes.Percent, yPosition: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            contentValue <| FssTypes.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member radialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType * FssTypes.Percent) list) list) =
            contentValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member radialGradients (gradients: (FssTypes.Image.Shape * FssTypes.Image.Side * FssTypes.Percent * FssTypes.Percent * (FssTypes.ColorType * FssTypes.Size) list) list) =
            contentValue <| FssTypes.Image.Image.RadialGradients(gradients)
        static member repeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Percent) list) =
            contentValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member repeatingRadialGradient (shape: FssTypes.Image.Shape, size: FssTypes.Image.Side, x: FssTypes.Percent, y: FssTypes.Percent, gradients: (FssTypes.ColorType * FssTypes.Size) list) =
            contentValue <| FssTypes.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member attribute (attribute: FssTypes.Attribute.Attribute) =
            contentValue <| sprintf "attr(%A)" (FssTypes.attributeHelpers.attributeToString attribute)

        static member normal = FssTypes.Normal |> contentValue'
        static member none = FssTypes.None' |> contentValue'
        static member inherit' = FssTypes.Inherit |> contentValue'
        static member initial = FssTypes.Initial |> contentValue'
        static member unset = FssTypes.Unset |> contentValue'

    /// <summary>Replaces element with a value.</summary>
    /// <param name="content">
    ///     can be:
    ///     - <c> Content </c>
    ///     - <c> CssString </c>
    ///     - <c> Normal </c>
    ///     - <c> None </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> CounterStyle </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Content' (content: FssTypes.IContent) = Content.value(content)

[<AutoOpen>]
module Label =
    type Label =
        static member value(label: string) =
            (label.Replace(" ", ""))
            |> FssTypes.propertyHelpers.cssValue FssTypes.Property.Label

    /// <summary>Gives label to generated CSS string.</summary>
    /// <param name="label">The name to give to the generated CSS string</param>
    /// <returns>Css property for fss.</returns>
    let Label' (label: string) = Label.value(label)