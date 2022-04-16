namespace Fss

open Fss.Types

[<AutoOpen>]
module Appearance =
    /// Specifies platform native styling.
    let Appearance = AppearanceClasses.Appearance(Property.Appearance)
