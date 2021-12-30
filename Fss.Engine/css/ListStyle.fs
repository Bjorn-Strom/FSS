namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module ListStyle =
    /// Specifies an image to be used as the list item marker.
    let ListStyleImage = ListStyleClasses.ListStyleImage(Property.ListStyleImage)
    /// Specifies the position of the marker of the list item.
    let ListStylePosition = ListStyleClasses.ListStylePosition(Property.ListStylePosition)
    /// Specifies list style marker.
    let ListStyleType = ListStyleClasses.ListStyleType(Property.ListStyleType)
    /// Resets list style.
    let ListStyle = ListStyleClasses.ListStyle(Property.ListStyle)
