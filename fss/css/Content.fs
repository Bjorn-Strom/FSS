namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Content =
    let Content =
        Content.ContentClasses.Content(Property.Content)



// TODO:
//[<AutoOpen>]
//module Label =
//
//    /// Gives label to generated CSS string.
//    type Label =
//        static member value(label: string) =
//            (label.Replace(" ", ""))
//            |> FssTypes.propertyHelpers.cssValue FssTypes.Property.Label
//
//    /// Gives label to generated CSS string.
//    let Label' = Label.value
