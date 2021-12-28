namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Content =
    let Content =
        Content.ContentClasses.Content(Property.Content)

[<AutoOpen>]
module Label =
    /// Gives label to generated CSS string.
    let Label (label: string) =
        (Property.NameLabel, NameLabel(label.Replace(" ", "")))
        |> Rule
