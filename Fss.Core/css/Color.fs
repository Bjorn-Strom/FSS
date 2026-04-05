namespace Fss

open Fss.Types

[<AutoOpen>]
module Color =
    /// Controls the accent color of form elements like checkboxes and radio buttons
    let AccentColor = AccentClasses.AccentColor(Property.AccentColor)
    /// Declares which color schemes the element can be rendered in
    let ColorScheme = ColorSchemeClasses.ColorScheme(Property.ColorScheme)
    /// Specifies the foreground color of an elements text
    let Color = ColorClass.Color(Property.Color)
    /// Specifies how the user agent can optimize the appearance of the element
    let ColorAdjust =
        ColorClass.ColorAdjust(Property.ColorAdjust)
