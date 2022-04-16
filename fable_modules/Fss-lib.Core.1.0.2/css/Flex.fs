namespace Fss

open Fss.Types

[<AutoOpen>]
module Flex =
    /// Specifies in which direction items in a flex container are oriented.
    let FlexDirection = FlexClasses.FlexDirection(Property.FlexDirection)
    /// Specifies if flex items can wrap onto multiple lines.
    let FlexWrap = FlexClasses.FlexWrap(Property.FlexWrap)
    /// Sets initial main size of flex item.
    let FlexBasis = FlexClasses.FlexBasis(Property.FlexBasis)
    /// Aligns elements horizontally in flex.
    let JustifyContent = FlexClasses.JustifyContent(Property.JustifyContent)
    /// Specifies how elements are justified in its container.
    let JustifySelf = FlexClasses.JustifySelf(Property.JustifySelf)
    /// Specifies default justify-self for items of element.
    let JustifyItems = FlexClasses.JustifyItems(Property.JustifyItems)
    /// Overrides an elements align-items value.
    let AlignSelf = FlexClasses.AlignSelf(Property.AlignSelf)
    /// Aligns elements along cross axis along the main axis in flex.
    let AlignItems = FlexClasses.AlignItems(Property.AlignItems)
    /// Aligns elements vertically in flex.
    let AlignContent = FlexClasses.AlignContent(Property.AlignContent)
    /// Specify order of items in flex.
    let Order = FlexClasses.Order(Property.Order)
    /// Sets shrink factor of flex item.
    let FlexShrink = FlexClasses.FlexShrinkGrow(Property.FlexShrink)
    /// Sets grow factor of flex item.
    let FlexGrow = FlexClasses.FlexShrinkGrow(Property.FlexGrow)
