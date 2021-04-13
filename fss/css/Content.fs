namespace Fss

open Fable.Core

[<AutoOpen>]
module Content =

    let private contentTypeToString (content: FssTypes.IContent) =
        match content with
        | :? FssTypes.Content.Content as c -> Utilities.Helpers.duToKebab c
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s |> sprintf "\"%s\""
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Counter.Style as c -> FssTypes.counterStyleHelpers.counterStyleToString c
        | _ -> "Unknown content"

    let private contentValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Content
    let private contentValue': (FssTypes.IContent -> FssTypes.CssProperty) = contentTypeToString >> contentValue

    [<Erase>]
    /// Replaces element with a value.
    let Content = FssTypes.Content.ContentClass(contentValue, contentValue')

    /// Replaces element with a value.
    /// Valid parameters:
    /// - Content
    /// - CssString
    /// - Normal
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - CounterStyle
    let Content': (FssTypes.IContent -> FssTypes.CssProperty) = Content.value

[<AutoOpen>]
module Label =
    [<Erase>]
    /// Gives label to generated CSS string.
    type Label =
        static member value(label: string) =
            (label.Replace(" ", ""))
            |> FssTypes.propertyHelpers.cssValue FssTypes.Property.Label

    /// Gives label to generated CSS string.
    let Label' = Label.value