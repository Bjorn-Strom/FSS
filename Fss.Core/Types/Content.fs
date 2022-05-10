namespace Fss
namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module Content =
    type Content =
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        interface ICssValue with
            member this.StringifyCss() = 
                match this with
                | OpenQuote -> "open-quote"
                | CloseQuote -> "close-quote"
                | NoOpenQuote -> "no-open-quote"
                | NoCloseQuote -> "no-close-quote"

[<RequireQualifiedAccess>]
module ContentClasses =
    type Content(property) =
        inherit ImageClasses.ImageClass(property)
        member this.value(value: string) = (property, Stringed value) |> Rule
        member this.counter(counter: string) =
            let counter = $"counter({counter})"
            (property, String counter) |> Rule
        member this.counter(counter: string, separator: string) =
            let counter =
                $"counter({counter})\"{separator}\""
            (property, String counter) |> Rule
        member this.counter(counters: string list, separators: string list) =
            let separators = List.map (fun s -> $"\"{s}\"") separators
            let counters =
                List.zip counters separators
                |> List.map (fun (c,s) -> $"counter({c}){s}")
                |> String.concat ""
                    
            (property, String counters) |> Rule
        member this.attribute(attribute: Attribute.Attribute) =
            let attribute = $"attr({stringifyICssValue attribute})"
            (property, String attribute) |> Rule
        member this.normal = (property, Normal) |> Rule
        member this.openQuote = (property, Content.OpenQuote) |> Rule
        member this.closeQuote = (property, Content.CloseQuote) |> Rule
        member this.noOpenQuote = (property, Content.NoOpenQuote) |> Rule
        member this.noCloseQuote = (property, Content.NoCloseQuote) |> Rule
