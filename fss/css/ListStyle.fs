namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module ListStyle =
    /// Specifies an image to be used as the list item marker.
    let ListStyleImage =
        ListStyle.ListStyleClasses.ListStyleImage(Property.ListStyleImage)
    /// Specifies the position of the marker of the list item.
    let ListStylePosition =
        ListStyle.ListStyleClasses.ListStylePosition(Property.ListStylePosition)
    /// Specifies list style marker.
    let ListStyleType =
        ListStyle.ListStyleClasses.ListStyleType(Property.ListStyleType)
    /// Resets list style.
    let ListStyle =
        ListStyle.ListStyleClasses.ListStyle(Property.ListStyle)
