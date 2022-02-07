namespace Fss

open Fss.Types

[<AutoOpen>]
module Cursor =
    /// Specifies how elements behave before a generated box.
    let Cursor = CursorClasses.CursorParent(Property.Cursor)
