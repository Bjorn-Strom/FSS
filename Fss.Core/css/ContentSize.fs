namespace Fss

open Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/width
// https://developer.mozilla.org/en-US/docs/Web/CSS/height
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-height
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-height
[<AutoOpen>]
module ContentSizeCss =
    /// Specifies an elements width
    let Width = ContentSizeClasses.ContentSize(Property.Width)
    /// Specifies an elements height
    let Height = ContentSizeClasses.ContentSize(Property.Height)
    /// Specifies an elements min-width
    let MinWidth = ContentSizeClasses.ContentSize(Property.MinWidth)
    /// Specifies an elements min-height
    let MinHeight = ContentSizeClasses.ContentSize(Property.MinHeight)
    /// Specifies an elements max-width
    let MaxWidth = ContentSizeClasses.ContentSize(Property.MaxWidth)
    /// Specifies an elements max-height
    let MaxHeight = ContentSizeClasses.ContentSize(Property.MaxHeight)
