namespace Fss

open Fss.FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
[<AutoOpen>]
module Visibility =
    /// Specifies in which order the fill and strokes are drawn.
    let PaintOrder =
        PaintOrder.PaintOrderClasses.PaintOrderClass(Property.PaintOrder)
    /// Specifies the opacity of an element.
    let Opacity =
        Visibility.VisibilityClasses.Opacity(Property.Opacity)
    /// Specifies the z-index of an element
    let ZIndex =
        Visibility.VisibilityClasses.ZIndex(Property.ZIndex)
    /// Specifies if an element is visible.
    let Visibility =
        Visibility.VisibilityClasses.Visibility(Property.Visibility)
