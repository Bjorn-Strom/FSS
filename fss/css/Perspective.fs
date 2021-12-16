namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Perspective =
    /// Specifies whether the backface of an element is visible.
    let BackfaceVisibility =
        Perspective.PerspectiveClasses.BackfaceVisibility(Property.BackfaceVisibility)
    /// Specifies vanishing point for the perspective property.
    let PerspectiveOrigin =
        Perspective.PerspectiveClasses.PerspectiveOrigin(Property.PerspectiveOrigin)
    /// Specifies distance in z plane.
    let Perspective =
        Perspective.PerspectiveClasses.Perspective(Property.Perspective)
