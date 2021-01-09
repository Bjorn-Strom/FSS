namespace Fss

open Fss

module ContentType =
    type Content =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        interface IContent

[<AutoOpen>]
module Content =
    open ContentType

    let private contentTypeToString (content: IContent) =
        match content with
        | :? Content as c -> Utilities.Helpers.duToKebab c
        | :? CssString as s -> GlobalValue.string s |> sprintf "\"%s\""
        | :? Normal -> GlobalValue.normal
        | :? None -> GlobalValue.none
        | :? Global as g -> GlobalValue.global' g
        | :? CounterType.CounterStyle as c -> counterValue c
        | _ -> "Unknown content"

    let private contentValue value = PropertyValue.cssValue Property.Content value
    let private contentValue' value =
        value
        |> contentTypeToString
        |> contentValue

    type Content =
        static member OpenQuote = OpenQuote |> contentValue'
        static member CloseQuote = CloseQuote |> contentValue'
        static member NoOpenQuote = NoOpenQuote |> contentValue'
        static member NoCloseQuote = NoCloseQuote |> contentValue'

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
        static member LinearGradient (start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.LinearGradient(start, last)
        static member LinearGradient (angle: Units.Angle.Angle, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.LinearGradient(angle, start, last)
        static member LinearGradient (sideOrCorner: SideOrCorner, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.LinearGradient(sideOrCorner, start, last)
        static member LinearGradient (colors: IColorStop list) =
            contentValue <| Image.Image.LinearGradient(colors)
        static member LinearGradient (angle: Units.Angle.Angle, colors: IColorStop list) =
            contentValue <| Image.Image.LinearGradient(angle, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: IColorStop list) =
            contentValue <| Image.Image.LinearGradient(sideOrCorner, colors)
        static member LinearGradient (sideOrCorner: SideOrCorner, colors: CssColor list) =
            contentValue <| Image.Image.LinearGradient(sideOrCorner, colors)

        static member RepeatingLinearGradient (start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RepeatingLinearGradient(start, last)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RepeatingLinearGradient(angle, start, last)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, start, last)
        static member RepeatingLinearGradient (colors: IColorStop list) =
            contentValue <| Image.Image.RepeatingLinearGradient(colors)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, colors: IColorStop list) =
            contentValue <| Image.Image.RepeatingLinearGradient(angle, colors)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, colors: IColorStop list) =
            contentValue <| Image.Image.RepeatingLinearGradient(sideOrCorner, colors)

        static member RadialGradient (start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RadialGradient(start, last)
        static member RadialGradient (colors: IColorStop list) =
            contentValue <| Image.Image.RadialGradient(colors)
        static member RadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RadialGradient(shape, start, last)
        static member RadialGradient (side: Side, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RadialGradient(side, start, last)
        static member RadialGradient (side: Side, colors: IColorStop list) =
            contentValue <| Image.Image.RadialGradient(side, colors)
        static member RadialGradient (shape: Shape, colors: IColorStop list) =
            contentValue <| Image.Image.RadialGradient(shape, colors)
        static member RadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RadialGradient(shape, side, start, last)
        static member RadialGradient (shape: Shape, side: Side, colors: IColorStop list) =
            contentValue <| Image.Image.RadialGradient(shape, side, colors)

        static member RepeatingRadialGradient (start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RepeatingRadialGradient(start, last)
        static member RepeatingRadialGradient (colors: IColorStop list) =
            contentValue <| Image.Image.RepeatingRadialGradient(colors)
        static member RepeatingRadialGradient (shape: Shape, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, start, last)
        static member RepeatingRadialGradient (shape: Shape, colors: IColorStop list) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, side, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, colors: IColorStop list) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, side, colors)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, start: IColorStop, last: IColorStop) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, side, position, start, last)
        static member RepeatingRadialGradient (shape: Shape, side: Side, position: ImagePosition, colors: IColorStop list) =
            contentValue <| Image.Image.RepeatingRadialGradient(shape, side, position, colors)
        static member Attribute (attribute: Attribute.Attribute) =
            contentValue <| sprintf "attr(%A)" (AttributeValues.attribute attribute)

        static member Normal = Normal |> contentValue'
        static member None = None |> contentValue'
        static member Inherit = Inherit |> contentValue'
        static member Initial = Initial |> contentValue'
        static member Unset = Unset |> contentValue'

    let Content' (content: IContent) = Content.Value(content)

[<AutoOpen>]
module Label =
    type Label =
        static member Value(label: string) =
            (label.Replace(" ", ""))
            |> PropertyValue.cssValue Property.Label
    let Label' (label: string) = Label.Value(label)