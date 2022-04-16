namespace Fss

open Fss.Types

[<AutoOpen>]
module Color =
    /// Specifies the foreground color of an elements text
    let Color = ColorClass.Color(Property.Color)
    /// Specifies how the user agent can optimize the appearance of the element
    let ColorAdjust =
        ColorClass.ColorAdjust(Property.ColorAdjust)
