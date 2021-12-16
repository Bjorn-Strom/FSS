namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Filter =
    /// Supply a list of filters to be applied to the element.
    let BackdropFilter =
        Filter.FilterClasses.FilterClass(Property.BackdropFilter)

    /// Supply a list of filters to be applied to the element.
    let Filter =
        Filter.FilterClasses.FilterClass(Property.Filter)
