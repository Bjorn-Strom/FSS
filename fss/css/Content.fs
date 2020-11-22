namespace Fss

open Fss

module ContentType =
    type ContentType =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        interface IContent

[<AutoOpen>]
module Content =
    open ContentType

    let private contentTypeToString (content: IContent) =
        let stringifyContent =
            function
                | OpenQuote -> "open-quote"
                | CloseQuote -> "close-quote"
                | NoOpenQuote -> "no-open-quote"
                | NoCloseQuote -> "no-close-quote"

        match content with
        | :? ContentType as c -> stringifyContent c
        | :? CssString as s -> GlobalValue.string s |> sprintf "\"%s\""
        | :? Normal -> GlobalValue.normal
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | :? CounterStyle as c -> counterValue c
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

        static member Counter (counter: CounterStyle) =
            contentValue <| sprintf "counter(%s)" (counterValue counter)
        static member Counter (counter: CounterStyle, listType: IListStyleType) =
            contentValue <| sprintf "counters(%s, %s)" (counterValue counter) (ListStyleTypeType.styleTypeToString listType)
        static member Counter (counter: CounterStyle, value: string) =
            contentValue <| sprintf "counters(%s, '%s')" (counterValue counter) value
        static member Url (url: string) = contentValue <| sprintf "url(%s)" url
        static member Url (url: string, altText: string) = contentValue <| sprintf "url(%s) / \"%s\"" url altText
        static member Value (value: string) = contentValue <| sprintf "\"%s\"" value
        static member Value (content: IContent) = content |> contentValue'
        (*
        static member LinearGradient (c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "linear-gradient(%s, %s)"
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member LinearGradient (angle: Units.Angle.Angle, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member LinearGradient (sideOrCorner: SideOrCorner, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "linear-gradient(%s, %s, %s)"
                (string sideOrCorner)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member LinearGradient (sideOrCorner: SideOrCorner, c1: CSSColor, c2: CSSColor, percent: Units.Percent.Percent) =
            contentValue
            <| sprintf "linear-gradient(%s, %s, %s, %s)"
                (string sideOrCorner)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
                (Units.Percent.value percent)
        static member LinearGradient (angle: Units.Angle.Angle, c1: CSSColor, c2: CSSColor, percent: Units.Percent.Percent) =
            contentValue
            <| sprintf "linear-gradient(%s, %s, %s, %s)"
                (Units.Angle.value angle)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
                (Units.Percent.value percent)
        static member RepeatingLinearGradient (c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-linear-gradient(%s, %s)"
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-linear-gradient(%s, %s, %s)"
                (Units.Angle.value angle)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-linear-gradient(%s, %s, %s)"
                (string sideOrCorner)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingLinearGradient (sideOrCorner: SideOrCorner, c1: CSSColor, c2: CSSColor, percent: Units.Percent.Percent) =
            contentValue
            <| sprintf "repeating-linear-gradient(%s, %s, %s, %s)"
                (string sideOrCorner)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
                (Units.Percent.value percent)
        static member RepeatingLinearGradient (angle: Units.Angle.Angle, c1: CSSColor, c2: CSSColor, percent: Units.Percent.Percent) =
            contentValue
            <| sprintf "repeating-linear-gradient(%s, %s, %s, %s)"
                (Units.Angle.value angle)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
                (Units.Percent.value percent)
        static member RadialGradient (c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "radial-gradient(%s, %s)"
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RadialGradient (shape: Shape, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "radial-gradient(%s, %s, %s)"
                (string shape)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RadialGradient (shape: Shape, side: Side, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "radial-gradient(%s, %s, %s, %s)"
                (string shape)
                (string side)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RadialGradient (shape: Shape, sideOrCorner: SideOrCorner, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "radial-gradient(%s at %s, %s, %s)"
                (string shape)
                (string sideOrCorner)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RadialGradient (shape: Shape, s1: SideOrCorner, s2: SideOrCorner, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "radial-gradient(%s at %s %s, %s, %s)"
                (string shape)
                (string s1)
                (string s2)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingRadialGradient (c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-radial-gradient(%s, %s)"
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingRadialGradient (shape: Shape, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-radial-gradient(%s, %s, %s)"
                (string shape)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingRadialGradient (shape: Shape, side: Side, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-radial-gradient(%s, %s, %s, %s)"
                (string shape)
                (string side)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingRadialGradient (shape: Shape, sideOrCorner: SideOrCorner, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-radial-gradient(%s at %s, %s, %s)"
                (string shape)
                (string sideOrCorner)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        static member RepeatingRadialGradient (shape: Shape, s1: SideOrCorner, s2: SideOrCorner, c1: CSSColor, c2: CSSColor) =
            contentValue
            <| sprintf "repeating-radial-gradient(%s at %s %s, %s, %s)"
                (string shape)
                (string s1)
                (string s2)
                (CSSColorValue.color c1)
                (CSSColorValue.color c2)
        *)
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
        static member Value(label: string) = PropertyValue.cssValue Property.Label label
    let Label' (label: string) = Label.Value(label)