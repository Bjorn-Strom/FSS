namespace Fss

open Fss

[<RequireQualifiedAccess>]
module ContentType =
    type Content =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        interface IContent

[<AutoOpen>]
module Content =

    let private contentTypeToString (content: IContent) =
        match content with
        | :? ContentType.Content as c -> Utilities.Helpers.duToKebab c
        | :? CssString as s -> GlobalValue.string s |> sprintf "\"%s\""
        | :? Normal -> GlobalValue.normal
        | :? None' -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | :? CounterType.CounterStyle as c -> counterValue c
        | _ -> "Unknown content"

    let private contentValue value = PropertyValue.cssValue Property.Content value
    let private contentValue' value =
        value
        |> contentTypeToString
        |> contentValue

    type Content =
        static member OpenQuote = ContentType.OpenQuote |> contentValue'
        static member CloseQuote = ContentType.CloseQuote |> contentValue'
        static member NoOpenQuote = ContentType.NoOpenQuote |> contentValue'
        static member NoCloseQuote = ContentType.NoCloseQuote |> contentValue'

        static member Counter (counter: CounterType.CounterStyle) =
            contentValue <| sprintf "counter(%s)" (counterValue counter)
        static member Counters (counter: CounterType.CounterStyle, listType: IListStyleType) =
            contentValue <| sprintf "counters(%s, %s)" (counterValue counter) (ListStyleTypeType.styleTypeToString listType)
        static member Counter (counter: CounterType.CounterStyle, value: string) =
            contentValue <| sprintf "counter(%s)'%s'" (counterValue counter) value
        static member Counters (counters: CounterType.CounterStyle list, values: string list) =
            List.zip (List.map counterValue counters) values
            |> List.map (fun (x, y) -> sprintf "counter(%s) '%s'" x y)
            |> String.concat " "
            |> contentValue
        static member Url (url: string) = contentValue <| sprintf "url(%s)" url
        static member Url (url: string, altText: string) = contentValue <| sprintf "url(%s) / \"%s\"" url altText
        static member Value (value: string) = contentValue <| sprintf "\"%s\"" value
        static member Value (content: IContent) = content |> contentValue'
        static member LinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Percent.Percent) list) =
            contentValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Size.Size) list) =
            contentValue <| Image.Image.LinearGradient((angle, gradients))
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            contentValue <| Image.Image.LinearGradients(gradients)
        static member LinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            contentValue <| Image.Image.LinearGradients(gradients)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Size.Size) list) =
            contentValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, gradients: (CssColor * Units.Percent.Percent) list) =
            contentValue <| Image.Image.RepeatingLinearGradient((angle, gradients))
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Size.Size) list)) list) =
            contentValue <| Image.Image.RepeatingLinearGradients(gradients)
        static member RepeatingLinearGradients (gradients: (Units.Angle.Angle * ((CssColor * Units.Percent.Percent) list)) list) =
            contentValue <| Image.Image.RepeatingLinearGradients(gradients)

        static member RadialGradient (shape: Shape, size: Side, xPosition: Units.Percent.Percent, yPosition: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            contentValue <| Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradient (shape: Shape, size: Side, xPosition: Units.Percent.Percent, yPosition: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            contentValue <| Image.RadialGradient (shape, size, xPosition, yPosition, gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Percent.Percent) list) list) =
            contentValue <| Image.Image.RadialGradients(gradients)
        static member RadialGradients (gradients: (Shape * Side * Units.Percent.Percent * Units.Percent.Percent * (CssColor * Units.Size.Size) list) list) =
            contentValue <| Image.Image.RadialGradients(gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Percent.Percent) list) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member RepeatingRadialGradient (shape: Shape, size: Side, x: Units.Percent.Percent, y: Units.Percent.Percent, gradients: (CssColor * Units.Size.Size) list) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, size, x, y, gradients)
        static member Attribute (attribute: Attribute.Attribute) =
            contentValue <| sprintf "attr(%A)" (AttributeValues.attribute attribute)

        static member Normal = Normal |> contentValue'
        static member None = None' |> contentValue'
        static member Inherit = Inherit |> contentValue'
        static member Initial = Initial |> contentValue'
        static member Unset = Unset |> contentValue'

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
    let Content' (content: IContent) = Content.Value(content)

[<AutoOpen>]
module Label =
    type Label =
        static member Value(label: string) =
            (label.Replace(" ", ""))
            |> PropertyValue.cssValue Property.Label

    /// <summary>Gives label to generated CSS string.</summary>
    /// <param name="label">The name to give to the generated CSS string</param>
    /// <returns>Css property for fss.</returns>
    let Label' (label: string) = Label.Value(label)