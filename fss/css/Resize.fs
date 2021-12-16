namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Resize =
    /// Specifies how elements are resizable.
    let Resize = Resize.ResizeClasses.ResizeClass(Property.Resize)