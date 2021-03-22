namespace Fss

[<AutoOpen>]
module Content =

    let private contentTypeToString (content: Types.IContent) =
        match content with
        | :? Types.Content.Content as c -> Utilities.Helpers.duToKebab c
        | :? Types.CssString as s -> Types.masterTypeHelpers.StringToString s |> sprintf "\"%s\""
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Counter.Style as c -> Types.counterStyleHelpers.counterStyleToString c
        | _ -> "Unknown content"

    let private contentValue value = Types.propertyHelpers.cssValue Types.Property.Content value
    let private contentValue' value =
        value
        |> contentTypeToString
        |> contentValue

    type Content =
        static member OpenQuote = Types.Content.OpenQuote |> contentValue'
        static member CloseQuote = Types.Content.CloseQuote |> contentValue'
        static member NoOpenQuote = Types.Content.NoOpenQuote |> contentValue'
        static member NoCloseQuote = Types.Content.NoCloseQuote |> contentValue'

        static member Counter (counter: Types.Counter.Style) =
            contentValue <| sprintf "counter(%s)" (Types.counterStyleHelpers.counterStyleToString counter)
        static member Counters (counter: Types.Counter.Style, listType: Types.IListStyleType) =
            contentValue <| sprintf "counters(%s, %s)" (Types.counterStyleHelpers.counterStyleToString counter) (Types.listStyleHelpers.styleTypeToString listType)
        static member Counter (counter: Types.Counter.Style, value: string) =
            contentValue <| sprintf "counter(%s)'%s'" (Types.counterStyleHelpers.counterStyleToString counter) value
        static member Counters (counters: Types.Counter.Style list, values: string list) =
            List.zip (List.map Types.counterStyleHelpers.counterStyleToString counters) values
            |> List.map (fun (x, y) -> sprintf "counter(%s) '%s'" x y)
            |> String.concat " "
            |> contentValue
        static member Url (url: string) = contentValue <| sprintf "url(%s)" url
        static member Url (url: string, altText: string) = contentValue <| sprintf "url(%s) / \"%s\"" url altText
        static member Value (value: string) = contentValue <| sprintf "\"%s\"" value
        static member Value (content: Types.IContent) = content |> contentValue'
        static member LinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo * Types.Percent) list) =
            contentValue <| Types.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo * Types.Size) list) =
            contentValue <| Types.Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo * Types.Percent) list)) list) =
            contentValue <| Types.Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo * Types.Size) list)) list) =
            contentValue <| Types.Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo * Types.Size) list) =
            contentValue <| Types.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.ColorTypeFoo * Types.Percent) list) =
            contentValue <| Types.Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo * Types.Size) list)) list) =
            contentValue <| Types.Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.ColorTypeFoo * Types.Percent) list)) list) =
            contentValue <| Types.Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.ColorTypeFoo * Types.Percent) list) =
            contentValue <| Types.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.ColorTypeFoo * Types.Size) list) =
            contentValue <| Types.Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Types.Image.Shape * Types.Image.Side * Types.Percent * Types.Percent * (Types.ColorTypeFoo * Types.Percent) list) list) =
            contentValue <| Types.Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Types.Image.Shape * Types.Image.Side * Types.Percent * Types.Percent * (Types.ColorTypeFoo * Types.Size) list) list) =
            contentValue <| Types.Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.ColorTypeFoo * Types.Percent) list) =
            contentValue <| Types.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Types.Image.Shape, size: Types.Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.ColorTypeFoo * Types.Size) list) =
            contentValue <| Types.Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member Attribute (attribute: Types.Attribute.Attribute) =
            contentValue <| sprintf "attr(%A)" (Types.attributeHelpers.attributeToString attribute)

        static member Normal = Types.Normal |> contentValue'
        static member None = Types.None' |> contentValue'
        static member Inherit = Types.Inherit |> contentValue'
        static member Initial = Types.Initial |> contentValue'
        static member Unset = Types.Unset |> contentValue'

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
    let Content' (content: Types.IContent) = Content.Value(content)

[<AutoOpen>]
module Label =
    type Label =
        static member Value(label: string) =
            (label.Replace(" ", ""))
            |> Types.propertyHelpers.cssValue Types.Property.Label

    /// <summary>Gives label to generated CSS string.</summary>
    /// <param name="label">The name to give to the generated CSS string</param>
    /// <returns>Css property for fss.</returns>
    let Label' (label: string) = Label.Value(label)