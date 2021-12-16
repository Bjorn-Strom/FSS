namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Flex =
    /// Specifies in which direction items in a flex container are oriented.
    let FlexDirection =
        Flex.FlexClasses.FlexDirection(Property.FlexDirection)
    /// Specifies if flex items can wrap onto multiple lines.
    let FlexWrap =
        Flex.FlexClasses.FlexWrap(Property.FlexWrap)
    /// Sets initial main size of flex item.
    let FlexBasis =
        Flex.FlexClasses.FlexBasis(Property.FlexBasis)
    /// Aligns elements horizontally in flex.
    let JustifyContent =
        Flex.FlexClasses.JustifyContent(Property.JustifyContent)
    /// Specifies how elements are justified in its container.
    let JustifySelf =
        Flex.FlexClasses.JustifySelf(Property.JustifySelf)
    /// Specifies default justify-self for items of element.
    let JustifyItems =
        Flex.FlexClasses.JustifyItems(Property.JustifyItems)
    /// Overrides an elements align-items value.
    let AlignSelf =
        Flex.FlexClasses.AlignSelf(Property.AlignSelf)
    /// Aligns elements along cross axis along the main axis in flex.
    let AlignItems =
        Flex.FlexClasses.AlignItems(Property.AlignItems)
    /// Aligns elements vertically in flex.
    let AlignContent =
        Flex.FlexClasses.AlignContent(Property.AlignContent)
    /// Specify order of items in flex.
    let Order = Flex.FlexClasses.Order(Property.Order)
    /// Sets shrink factor of flex item.
    let FlexShrink =
        Flex.FlexClasses.FlexShrinkGrow(Property.FlexShrink)
    /// Sets grow factor of flex item.
    let FlexGrow =
        Flex.FlexClasses.FlexShrinkGrow(Property.FlexGrow)
