namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Perspective =
    /// Specifies whether the backface of an element is visible.
    let BackfaceVisibility = PerspectiveClasses.BackfaceVisibility(Property.BackfaceVisibility)
    /// Specifies vanishing point for the perspective property.
    let PerspectiveOrigin = PerspectiveClasses.PerspectiveOrigin(Property.PerspectiveOrigin)
    /// Specifies distance in z plane.
    let Perspective = PerspectiveClasses.Perspective(Property.Perspective)
