namespace Fss

namespace Fss.FssTypes

open Fss.FssTypes

[<RequireQualifiedAccess>]
module Content =
    type Content =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        | Counter of CounterProperty
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module ContentClasses =
        type ContentHelper =
            | Attribute of Attribute.Attribute
            interface ICssValue with
                member this.Stringify() =
                    match this with
                    | Attribute a -> $"attr({stringifyICssValue a})"

        type Content(property) =
            inherit Image.ImageClasses.ImageClass(property)
            member this.value(value: string) = (property, Stringed value) |> Rule
            // TODO: Egen counter type en eller annen gang
            member this.counter(counter: string) = (property, String counter) |> Rule
            member this.attribute(attribute: Attribute.Attribute) = (property, Attribute attribute) |> Rule
            member this.normal = (property, Normal) |> Rule
            member this.openQuote = (property, OpenQuote) |> Rule
            member this.closeQuote = (property, CloseQuote) |> Rule
            member this.noOpenQuote = (property, NoOpenQuote) |> Rule
            member this.noCloseQuote = (property, NoCloseQuote) |> Rule
