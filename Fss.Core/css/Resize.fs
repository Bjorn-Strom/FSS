namespace Fss

open Fss.Types

[<AutoOpen>]
module Resize =
    /// Specifies how elements are resizable.
    let Resize = ResizeClasses.ResizeClass(Property.Resize)