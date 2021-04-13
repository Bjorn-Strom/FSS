namespace Fss

open Fable.Core

[<AutoOpen>]
module WillChange =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/will-change
    let private stringifyWillChange (willChange: FssTypes.IWillChange) =
        match willChange with
        | :? FssTypes.WillChange.WillChange as wc ->
            match wc with
            | FssTypes.WillChange.Ident s -> s
            | _ -> Utilities.Helpers.duToKebab wc
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown will change"

    let private willChangeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.WillChange
    let private willChangeValue' = stringifyWillChange >> willChangeValue

    [<Erase>]
    /// Hints to browser how an element is expected to change.
    type WillChange =
        static member value (willChange: FssTypes.IWillChange) = willChange |> willChangeValue'
        static member scrollPosition = FssTypes.WillChange.ScrollPosition |> willChangeValue'
        static member contents = FssTypes.WillChange.Contents |> willChangeValue'
        static member ident ident = FssTypes.WillChange.Ident ident |> willChangeValue'
        static member idents (idents: string list) =
            FssTypes.WillChange.Ident (String.concat "," idents) |> willChangeValue'

        static member auto = FssTypes.Auto |> willChangeValue'

    /// Hints to browser how an element is expected to change.
    /// Valid parameters:
    /// - WillChange
    /// - Auto
    let WillChange' = WillChange.value
