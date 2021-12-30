namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Cursor =
    /// Specifies how elements behave before a generated box.
    let Cursor = CursorClasses.CursorParent(Property.Cursor)
