namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Appearance =
    /// Specifies platform native styling.
    let Appearance = AppearanceClasses.Appearance(Property.Appearance)
