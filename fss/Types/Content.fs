namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Content =
        type Content =
            | OpenQuote
            | CloseQuote
            | NoOpenQuote
            | NoCloseQuote
            interface IContent

        type ContentClass (contentValue: string -> CssProperty, contentValue': IContent -> CssProperty) =
            inherit Image.Image(contentValue)
            member this.openQuote = OpenQuote  |> contentValue'
            member this.closeQuote = CloseQuote |> contentValue'
            member this.noOpenQuote = NoOpenQuote |> contentValue'
            member this.noCloseQuote = NoCloseQuote |> contentValue'

            member this.counter (counter: Counter.Style) =
                contentValue <| sprintf "counter(%s)" (counterStyleToString counter)
            member this.counters (counter: Counter.Style, listType: IListStyleType) =
                contentValue <| sprintf "counters(%s, %s)" (counterStyleToString counter) (styleTypeToString listType)
            member this.counter (counter: Counter.Style, value: string) =
                contentValue <| sprintf "counter(%s)'%s'" (counterStyleToString counter) value
            member this.counters (counters: Counter.Style list, values: string list) =
                List.zip (List.map counterStyleToString counters) values
                |> List.map (fun (x, y) -> sprintf "counter(%s) '%s'" x y)
                |> String.concat " "
                |> contentValue
            member this.url (url: string) = contentValue <| sprintf "url(%s)" url
            member this.url (url: string, altText: string) = contentValue <| sprintf "url(%s) / \"%s\"" url altText
            member this.value (value: string) = contentValue <| sprintf "\"%s\"" value
            member this.value (content: IContent) = content |> contentValue'
            member this.attribute (attribute: Attribute.Attribute) =
                contentValue <| sprintf "attr(%A)" (attributeToString attribute)

            member this.normal = Normal |> contentValue'
            member this.none = None' |> contentValue'
            member this.inherit' = Inherit |> contentValue'
            member this.initial = Initial |> contentValue'
            member this.unset = Unset |> contentValue'