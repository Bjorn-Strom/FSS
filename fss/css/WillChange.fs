namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module WillChange =
    let WillChange =
        WillChange.WillChangeClasses.WillChange(Property.WillChange)
