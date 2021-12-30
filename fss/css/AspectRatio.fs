namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module AspectRatio =
    /// Sets the preferred aspect ratio of the element
    let AspectRatio = AspectRatioClasses.AspectRatio(Property.AspectRatio)
