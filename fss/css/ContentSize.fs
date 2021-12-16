namespace Fss

open Fss.FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/width
// https://developer.mozilla.org/en-US/docs/Web/CSS/height
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-height
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-height
[<AutoOpen>]
module ContentSize =
    /// Specifies an elements width
    let Width =
        ContentSize.ContentClasses.ContentSize(Property.Width)
    /// Specifies an elements height
    let Height =
        ContentSize.ContentClasses.ContentSize(Property.Height)
    /// Specifies an elements min-width
    let MinWidth =
        ContentSize.ContentClasses.ContentSize(Property.MinWidth)
    /// Specifies an elements min-height
    let MinHeight =
        ContentSize.ContentClasses.ContentSize(Property.MinHeight)
    /// Specifies an elements max-width
    let MaxWidth =
        ContentSize.ContentClasses.ContentSize(Property.MaxWidth)
    /// Specifies an elements max-height
    let MaxHeight =
        ContentSize.ContentClasses.ContentSize(Property.MaxHeight)
