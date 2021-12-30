namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Scroll =
    /// Specifies the Behavior of scrolling.
    let ScrollBehavior = ScrollClasses.ScrollBehavior(Property.ScrollBehavior)
    /// Specifies the scroll margin on top side of an element.
    let ScrollMarginTop = ScrollClasses.ScrollMarginDirection(Property.ScrollMarginTop)
    /// Specifies the scroll margin on right side of an element.
    let ScrollMarginRight = ScrollClasses.ScrollMarginDirection(Property.ScrollMarginRight)
    /// Specifies the scroll margin on bottom side of an element.
    let ScrollMarginBottom = ScrollClasses.ScrollMarginDirection(Property.ScrollMarginBottom)
    /// Specifies the scroll margin on left side of an element.
    let ScrollMarginLeft = ScrollClasses.ScrollMarginDirection(Property.ScrollMarginLeft)
    /// Specifies the scroll margin on all sides of an element.
    let ScrollMargin = ScrollClasses.ScrollMargin(Property.ScrollMargin)
    /// Specifies the scroll padding on top side of an element.
    let ScrollPaddingTop = ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingTop)
    /// Specifies the scroll padding on right side of an element.
    let ScrollPaddingRight = ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingRight)
    /// Specifies the scroll padding on bottom side of an element.
    let ScrollPaddingBottom = ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingBottom)
    /// Specifies the scroll padding on left side of an element.
    let ScrollPaddingLeft = ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingLeft)
    /// Specifies the scroll padding on all sides of an element.
    let ScrollPadding = ScrollClasses.ScrollPadding(Property.ScrollPadding)
    /// Specify browser behavior when scroll hits horizontal boundary.
    let OverscrollBehaviorX = ScrollClasses.OverScrollBehavior(Property.OverscrollBehaviorX)
    /// Specify browser behavior when scroll hits vertical boundary.
    let OverscrollBehaviorY = ScrollClasses.OverScrollBehavior(Property.OverscrollBehaviorY)
    /// Specifies how snap points are enforced
    let ScrollSnapType = ScrollClasses.ScrollSnapType(Property.ScrollSnapType)
    /// Specifies the box’s snap position
    let ScrollSnapAlign = ScrollClasses.ScrollSnapAlign(Property.ScrollSnapAlign)
    /// Specifies whether the scroll container is allowed to "pass over" possible snap positions.
    let ScrollSnapStop = ScrollClasses.ScrollSnapStop(Property.ScrollSnapStop)
