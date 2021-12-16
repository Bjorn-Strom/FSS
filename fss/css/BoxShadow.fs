namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module BoxShadow =
    /// Supply a list of box shadows to be applied to the element.
    let BoxShadow =
        BoxShadow.BoxShadowClasses.BoxShadowClass(Property.BoxShadow)
