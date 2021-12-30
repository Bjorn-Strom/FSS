namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Content =
    type Content =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        | Counter of CounterProperty
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module ContentClasses =
    type Content(property) =
        inherit ImageClasses.ImageClass(property)
        member this.value(value: string) = (property, Stringed value) |> Rule
        member this.counter(counter: string) =
            let counter = $"counter({counter})"
            (property, String counter) |> Rule
        member this.counter(counter: string, seperator: string) =
            let counter =
                $"counter({counter}, \"{seperator}\")"
            (property, String counter) |> Rule
        member this.attribute(attribute: Attribute.Attribute) =
            let attribute = $"attr({stringifyICssValue attribute})"
            (property, String attribute) |> Rule
        member this.normal = (property, Normal) |> Rule
        member this.openQuote = (property, Content.OpenQuote) |> Rule
        member this.closeQuote = (property, Content.CloseQuote) |> Rule
        member this.noOpenQuote = (property, Content.NoOpenQuote) |> Rule
        member this.noCloseQuote = (property, Content.NoCloseQuote) |> Rule