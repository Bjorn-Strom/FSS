namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Display =
    /// Specifies the layout of the elements children.
    let Display =
        Display.DisplayClasses.DisplayClass(Property.Display)
