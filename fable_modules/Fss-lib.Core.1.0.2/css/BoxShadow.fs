namespace Fss

open Fss.Types

[<AutoOpen>]
module BoxShadow =
    /// Supply a list of box shadows to be applied to the element.
    let BoxShadow = BoxShadowClasses.BoxShadowClass(Property.BoxShadow)
