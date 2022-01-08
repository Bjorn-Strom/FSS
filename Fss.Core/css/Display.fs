namespace Fss

open Fss.Types

[<AutoOpen>]
module Display =
    /// Specifies the layout of the elements children.
    let Display = DisplayClasses.DisplayClass(Property.Display)
