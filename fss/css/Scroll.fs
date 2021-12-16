namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Scroll =
    /// Specifies the Behavior of scrolling.
    let ScrollBehavior =
        Scroll.ScrollClasses.ScrollBehavior(Property.ScrollBehavior)
    /// Specifies the scroll margin on top side of an element.
    let ScrollMarginTop =
        Scroll.ScrollClasses.ScrollMarginDirection(Property.ScrollMarginTop)
    /// Specifies the scroll margin on right side of an element.
    let ScrollMarginRight =
        Scroll.ScrollClasses.ScrollMarginDirection(Property.ScrollMarginRight)
    /// Specifies the scroll margin on bottom side of an element.
    let ScrollMarginBottom =
        Scroll.ScrollClasses.ScrollMarginDirection(Property.ScrollMarginBottom)
    /// Specifies the scroll margin on left side of an element.
    let ScrollMarginLeft =
        Scroll.ScrollClasses.ScrollMarginDirection(Property.ScrollMarginLeft)
    /// Specifies the scroll margin on all sides of an element.
    let ScrollMargin =
        Scroll.ScrollClasses.ScrollMargin(Property.ScrollMargin)
    /// Specifies the scroll padding on top side of an element.
    let ScrollPaddingTop =
        Scroll.ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingTop)
    /// Specifies the scroll padding on right side of an element.
    let ScrollPaddingRight =
        Scroll.ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingRight)
    /// Specifies the scroll padding on bottom side of an element.
    let ScrollPaddingBottom =
        Scroll.ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingBottom)
    /// Specifies the scroll padding on left side of an element.
    let ScrollPaddingLeft =
        Scroll.ScrollClasses.ScrollPaddingDirection(Property.ScrollPaddingLeft)
    /// Specifies the scroll padding on all sides of an element.
    let ScrollPadding =
        Scroll.ScrollClasses.ScrollPadding(Property.ScrollPadding)
    /// Specify browser behavior when scroll hits horizontal boundary.
    let OverscrollBehaviorX =
        Scroll.ScrollClasses.OverScrollBehavior(Property.OverscrollBehaviorX)
    /// Specify browser behavior when scroll hits vertical boundary.
    let OverscrollBehaviorY =
        Scroll.ScrollClasses.OverScrollBehavior(Property.OverscrollBehaviorY)
    /// Specifies how snap points are enforced
    let ScrollSnapType =
        Scroll.ScrollClasses.ScrollSnapType(Property.ScrollSnapType)
    /// Specifies the box’s snap position
    let ScrollSnapAlign =
        Scroll.ScrollClasses.ScrollSnapAlign(Property.ScrollSnapAlign)
    /// Specifies whether the scroll container is allowed to "pass over" possible snap positions.
    let ScrollSnapStop =
        Scroll.ScrollClasses.ScrollSnapStop(Property.ScrollSnapStop)
