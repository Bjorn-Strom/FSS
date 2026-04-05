namespace Fss

open Fss.Types

[<AutoOpen>]
module Contain =
    /// Controls whether an element's content can affect the rest of the page layout.
    let Contain = ContainClasses.Contain(Property.Contain)
    /// Controls whether an element renders its contents at all.
    let ContentVisibility = ContainClasses.ContentVisibility(Property.ContentVisibility)
