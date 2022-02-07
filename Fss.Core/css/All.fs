namespace Fss

open Fss.Types

[<AutoOpen>]
module All =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/all
    /// Resets all of an elements properties.
    let All = CssRule(Property.All)
