namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Filter =
    /// Supply a list of filters to be applied to the element.
    let BackdropFilter = FilterClasses.FilterClass(Property.BackdropFilter)

    /// Supply a list of filters to be applied to the element.
    let Filter = FilterClasses.FilterClass(Property.Filter)
