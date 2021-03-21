namespace Fss

[<AutoOpen>]
module Content =

    let private contentTypeToString (content: Types.IContent) =
        match content with
        | :? Types.Content as c -> Utilities.Helpers.duToKebab c
        | :? Types.String as s -> Types.StringToString s |> sprintf "\"%s\""
        | :? Types.Normal -> Types.normal
        | :? Types.None' -> Types.none
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.CounterStyle as c -> Types.counterStyleToString c
        | _ -> "Unknown content"

    let private contentValue value = Types.cssValue Types.Property.Content value
    let private contentValue' value =
        value
        |> contentTypeToString
        |> contentValue

    type Content =
        static member OpenQuote = Types.Content.OpenQuote |> contentValue'
        static member CloseQuote = Types.Content.CloseQuote |> contentValue'
        static member NoOpenQuote = Types.Content.NoOpenQuote |> contentValue'
        static member NoCloseQuote = Types.Content.NoCloseQuote |> contentValue'

        static member Counter (counter: Types.CounterStyle) =
            contentValue <| sprintf "counter(%s)" (Types.counterStyleToString counter)
        static member Counters (counter: Types.CounterStyle, listType: Types.IListStyleType) =
            contentValue <| sprintf "counters(%s, %s)" (Types.counterStyleToString counter) (Types.styleTypeToString listType)
        static member Counter (counter: Types.CounterStyle, value: string) =
            contentValue <| sprintf "counter(%s)'%s'" (Types.counterStyleToString counter) value
        static member Counters (counters: Types.CounterStyle list, values: string list) =
            List.zip (List.map Types.counterStyleToString counters) values
            |> List.map (fun (x, y) -> sprintf "counter(%s) '%s'" x y)
            |> String.concat " "
            |> contentValue
        static member Url (url: string) = contentValue <| sprintf "url(%s)" url
        static member Url (url: string, altText: string) = contentValue <| sprintf "url(%s) / \"%s\"" url altText
        static member Value (value: string) = contentValue <| sprintf "\"%s\"" value
        static member Value (content: Types.IContent) = content |> contentValue'
        static member LinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Percent) list) =
            contentValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Size) list) =
            contentValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            contentValue <| Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            contentValue <| Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Size) list) =
            contentValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Types.Angle, gradients: (Types.Color * Types.Percent) list) =
            contentValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Size) list)) list) =
            contentValue <| Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Types.Angle * ((Types.Color * Types.Percent) list)) list) =
            contentValue <| Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Image.Shape, size: Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            contentValue <| Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Image.Shape, size: Image.Side, xPosition: Types.Percent, yPosition: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            contentValue <| Image.Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Image.Shape * Image.Side * Types.Percent * Types.Percent * (Types.Color * Types.Percent) list) list) =
            contentValue <| Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Image.Shape * Image.Side * Types.Percent * Types.Percent * (Types.Color * Types.Size) list) list) =
            contentValue <| Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Image.Shape, size: Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Percent) list) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Image.Shape, size: Image.Side, x: Types.Percent, y: Types.Percent, gradients: (Types.Color * Types.Size) list) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member Attribute (attribute: Types.Attribute) =
            contentValue <| sprintf "attr(%A)" (Types.attributeToString attribute)

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
            |> Types.cssValue Types.Property.Label

    /// <summary>Gives label to generated CSS string.</summary>
    /// <param name="label">The name to give to the generated CSS string</param>
    /// <returns>Css property for fss.</returns>
    let Label' (label: string) = Label.Value(label)