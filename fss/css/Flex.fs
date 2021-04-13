namespace Fss

open Fable.Core

[<AutoOpen>]
module Flex =
    let private alignContentToString (alignment: FssTypes.IAlignContent) =
        match alignment with
        | :? FssTypes.Flex.AlignContent as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align content"

    let private alignItemsToString (alignment: FssTypes.IAlignItems) =
        match alignment with
        | :? FssTypes.Flex.AlignItems as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align items"

    let private alignSelfToString (alignment: FssTypes.IAlignSelf) =
        match alignment with
        | :? FssTypes.Flex.AlignSelf as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align self"

    let private justifyContentToString (justification: FssTypes.IJustifyContent) =
        match justification with
        | :? FssTypes.Flex.JustifyContent as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify content"

    let private justifyItemsToString (justification: FssTypes.IJustifyItems) =
        match justification with
        | :? FssTypes.Flex.JustifyItems as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify items"

    let private justifySelfToString (justification: FssTypes.IJustifySelf) =
        match justification with
        | :? FssTypes.Flex.JustifySelf as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify self"

    let private flexDirectionToString (direction: FssTypes.IFlexDirection) =
        match direction with
        | :? FssTypes.Flex.Direction as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex direction"

    let private flexToString(flex: FssTypes.IFlex) =
        match flex with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown flex"

    let private flexWrapToString (direction: FssTypes.IFlexWrap) =
        match direction with
        | :? FssTypes.Flex.Wrap as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex wrap"

    let private orderToString (order: FssTypes.IOrder) =
        match order with
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown order"

    let private flexGrowToString (flexGrow: FssTypes.IFlexGrow) =
        match flexGrow with
        | :? FssTypes.CssFloat as f -> FssTypes.masterTypeHelpers.FloatToString f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex grow"

    let private flexShrinkToString (flexShrink: FssTypes.IFlexShrink) =
        match flexShrink with
        | :? FssTypes.CssFloat as f -> FssTypes.masterTypeHelpers.FloatToString f
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex shrink"

    let private flexBasisToString (basis: FssTypes.IFlexBasis) =
        match basis with
        | :? FssTypes.Flex.Basis as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex basis"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    let private alignContentValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignContent
    let private alignContentValue' = alignContentToString >> alignContentValue

    [<Erase>]
    /// Aligns elements vertically in flex.
    type AlignContent =
        static member value (alignment: FssTypes.IAlignContent) = alignment |> alignContentValue'
        static member start' = FssTypes.Flex.AlignContent.Start |> alignContentValue'
        static member end' = FssTypes.Flex.AlignContent.End |> alignContentValue'
        static member flexStart = FssTypes.Flex.AlignContent.FlexStart |> alignContentValue'
        static member flexEnd = FssTypes.Flex.AlignContent.FlexEnd |> alignContentValue'
        static member center = FssTypes.Flex.AlignContent.Center |> alignContentValue'
        static member baseline = FssTypes.Flex.AlignContent.Baseline |> alignContentValue'
        static member firstBaseline = FssTypes.Flex.AlignContent.FirstBaseline |> alignContentValue'
        static member lastBaseline = FssTypes.Flex.AlignContent.LastBaseline |> alignContentValue'
        static member stretch = FssTypes.Flex.AlignContent.Stretch |> alignContentValue'
        static member safe = FssTypes.Flex.AlignContent.Safe |> alignContentValue'
        static member unsafe = FssTypes.Flex.AlignContent.Unsafe |> alignContentValue'
        static member spaceBetween = FssTypes.Flex.AlignContent.SpaceBetween |> alignContentValue'
        static member spaceAround = FssTypes.Flex.AlignContent.SpaceAround |> alignContentValue'
        static member spaceEvenly = FssTypes.Flex.AlignContent.SpaceEvenly |> alignContentValue'

        static member normal = FssTypes.Normal |> alignContentValue'
        static member inherit' = FssTypes.Inherit |> alignContentValue'
        static member initial = FssTypes.Initial |> alignContentValue'
        static member unset = FssTypes.Unset |> alignContentValue'

    /// Aligns elements vertically in flex.
    /// Valid parameters:
    /// - AlignContent
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let AlignContent' = AlignContent.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    let private alignItemsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignItems
    let private alignItemsValue' = alignItemsToString >> alignItemsValue

    [<Erase>]
    /// Aligns elements along cross axis along the main axis in flex.
    type AlignItems =
        static member value (alignment: FssTypes.IAlignItems) = alignment |> alignItemsValue'
        static member start = FssTypes.Flex.AlignItems.Start |> alignItemsValue'
        static member end' = FssTypes.Flex.AlignItems.End |> alignItemsValue'
        static member flexStart = FssTypes.Flex.AlignItems.FlexStart |> alignItemsValue'
        static member flexEnd = FssTypes.Flex.AlignItems.FlexEnd |> alignItemsValue'
        static member center = FssTypes.Flex.AlignItems.Center |> alignItemsValue'
        static member baseline = FssTypes.Flex.AlignItems.Baseline |> alignItemsValue'
        static member firstBaseline = FssTypes.Flex.AlignItems.FirstBaseline |> alignItemsValue'
        static member lastBaseline = FssTypes.Flex.AlignItems.LastBaseline |> alignItemsValue'
        static member stretch = FssTypes.Flex.AlignItems.Stretch |> alignItemsValue'
        static member safe = FssTypes.Flex.AlignItems.Safe |> alignItemsValue'
        static member unsafe = FssTypes.Flex.AlignItems.Unsafe |> alignItemsValue'
        static member selfStart = FssTypes.Flex.AlignItems.SelfStart |> alignItemsValue'
        static member selfEnd = FssTypes.Flex.AlignItems.SelfEnd |> alignItemsValue'

        static member normal = FssTypes.Normal |> alignItemsValue'
        static member inherit' = FssTypes.Inherit |> alignItemsValue'
        static member initial = FssTypes.Initial |> alignItemsValue'
        static member unset = FssTypes.Unset |> alignItemsValue'

    /// Aligns elements along cross axis along the main axis in flex.
    /// Valid parameters:
    /// - AlignContent
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let AlignItems' = AlignItems.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    let private alignSelfValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignSelf
    let private alignSelfValue' = alignSelfToString >> alignSelfValue

    [<Erase>]
    /// Overrides an elements align-items value.
    type AlignSelf =
        static member value (alignment: FssTypes.IAlignSelf) = alignment |> alignSelfValue'
        static member start = FssTypes.Flex.AlignSelf.Start |> alignSelfValue'
        static member end' = FssTypes.Flex.AlignSelf.End |> alignSelfValue'
        static member flexStart = FssTypes.Flex.AlignSelf.FlexStart |> alignSelfValue'
        static member flexEnd = FssTypes.Flex.AlignSelf.FlexEnd |> alignSelfValue'
        static member center = FssTypes.Flex.AlignSelf.Center |> alignSelfValue'
        static member baseline = FssTypes.Flex.AlignSelf.Baseline |> alignSelfValue'
        static member firstBaseline = FssTypes.Flex.AlignSelf.FirstBaseline |> alignSelfValue'
        static member lastBaseline = FssTypes.Flex.AlignSelf.LastBaseline |> alignSelfValue'
        static member stretch = FssTypes.Flex.AlignSelf.Stretch |> alignSelfValue'
        static member safe = FssTypes.Flex.AlignSelf.Safe |> alignSelfValue'
        static member unsafe = FssTypes.Flex.AlignSelf.Unsafe |> alignSelfValue'
        static member selfStart = FssTypes.Flex.AlignSelf.SelfStart |> alignSelfValue'
        static member selfEnd = FssTypes.Flex.AlignSelf.SelfEnd |> alignSelfValue'

        static member normal = FssTypes.Normal |> alignSelfValue'
        static member inherit' = FssTypes.Inherit |> alignSelfValue'
        static member initial = FssTypes.Initial |> alignSelfValue'
        static member unset = FssTypes.Unset |> alignSelfValue'

    /// Overrides an elements align-items value.
    /// Valid parameters:
    /// - AlignContent
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let AlignSelf' = AlignSelf.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    let private justifyContentValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifyContent
    let private justifyContentValue': (FssTypes.IJustifyContent -> FssTypes.CssProperty) = justifyContentToString >> justifyContentValue

    [<Erase>]
    /// Aligns elements horizontally in flex.
    type JustifyContent =
        static member value (justification: FssTypes.IJustifyContent) = justification |> justifyContentValue'
        static member start = FssTypes.Flex.JustifyContent.Start |> justifyContentValue'
        static member end' = FssTypes.Flex.JustifyContent.End |> justifyContentValue'
        static member flexStart = FssTypes.Flex.JustifyContent.FlexStart |> justifyContentValue'
        static member flexEnd = FssTypes.Flex.JustifyContent.FlexEnd |> justifyContentValue'
        static member center = FssTypes.Flex.JustifyContent.Center |> justifyContentValue'
        static member baseline = FssTypes.Flex.JustifyContent.Baseline |> justifyContentValue'
        static member firstBaseline = FssTypes.Flex.JustifyContent.FirstBaseline |> justifyContentValue'
        static member lastBaseline = FssTypes.Flex.JustifyContent.LastBaseline |> justifyContentValue'
        static member stretch = FssTypes.Flex.JustifyContent.Stretch |> justifyContentValue'
        static member safe = FssTypes.Flex.JustifyContent.Safe |> justifyContentValue'
        static member unsafe = FssTypes.Flex.JustifyContent.Unsafe |> justifyContentValue'
        static member left = FssTypes.Flex.JustifyContent.Left |> justifyContentValue'
        static member right = FssTypes.Flex.JustifyContent.Right |> justifyContentValue'
        static member spaceBetween = FssTypes.Flex.JustifyContent.SpaceBetween |> justifyContentValue'
        static member spaceAround = FssTypes.Flex.JustifyContent.SpaceAround |> justifyContentValue'
        static member spaceEvenly = FssTypes.Flex.JustifyContent.SpaceEvenly |> justifyContentValue'

        static member normal = FssTypes.Normal |> justifyContentValue'
        static member inherit' = FssTypes.Inherit |> justifyContentValue'
        static member initial = FssTypes.Initial |> justifyContentValue'
        static member unset = FssTypes.Unset |> justifyContentValue'

    /// Aligns elements horizontally in flex.
    /// Valid parameters:
    /// - JustifyContent
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let JustifyContent' = JustifyContent.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    let private justifyItemsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifyItems
    let private justifyItemsValue' = justifyItemsToString >> justifyItemsValue

    [<Erase>]
    /// Specifies default justify-self for items of element.
    type JustifyItems =
        static member value (justification: FssTypes.IJustifyItems) = justification |> justifyItemsValue'
        static member start = FssTypes.Flex.JustifyItems.Start |> justifyItemsValue'
        static member end' = FssTypes.Flex.JustifyItems.End |> justifyItemsValue'
        static member flexStart = FssTypes.Flex.JustifyItems.FlexStart |> justifyItemsValue'
        static member flexEnd = FssTypes.Flex.JustifyItems.FlexEnd |> justifyItemsValue'
        static member center = FssTypes.Flex.JustifyItems.Center |> justifyItemsValue'
        static member baseline = FssTypes.Flex.JustifyItems.Baseline |> justifyItemsValue'
        static member firstBaseline = FssTypes.Flex.JustifyItems.FirstBaseline |> justifyItemsValue'
        static member lastBaseline = FssTypes.Flex.JustifyItems.LastBaseline |> justifyItemsValue'
        static member stretch = FssTypes.Flex.JustifyItems.Stretch |> justifyItemsValue'
        static member safe = FssTypes.Flex.JustifyItems.Safe |> justifyItemsValue'
        static member unsafe = FssTypes.Flex.JustifyItems.Unsafe |> justifyItemsValue'
        static member left = FssTypes.Flex.JustifyItems.Left |> justifyItemsValue'
        static member right = FssTypes.Flex.JustifyItems.Right |> justifyItemsValue'
        static member selfStart = FssTypes.Flex.JustifyItems.SelfStart |> justifyItemsValue'
        static member selfEnd = FssTypes.Flex.JustifyItems.SelfEnd |> justifyItemsValue'
        static member legacy = FssTypes.Flex.JustifyItems.Legacy |> justifyItemsValue'

        static member normal = FssTypes.Normal |> justifyItemsValue'
        static member inherit' = FssTypes.Inherit |> justifyItemsValue'
        static member initial = FssTypes.Initial |> justifyItemsValue'
        static member unset = FssTypes.Unset |> justifyItemsValue'

    /// Specifies default justify-self for items of element.
    /// Valid parameters:
    /// - JustifyItems
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let JustifyItems' = JustifyItems.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    let private justifySelfValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifySelf
    let private justifySelfValue' = justifySelfToString >> justifySelfValue

    [<Erase>]
    /// Specifies how elements are justified in its container.
    type JustifySelf =
        static member value (justification: FssTypes.IJustifySelf) = justification |> justifySelfValue'
        static member start = FssTypes.Flex.JustifySelf.Start |> justifySelfValue'
        static member end' = FssTypes.Flex.JustifySelf.End |> justifySelfValue'
        static member flexStart = FssTypes.Flex.JustifySelf.FlexStart |> justifySelfValue'
        static member flexEnd = FssTypes.Flex.JustifySelf.FlexEnd |> justifySelfValue'
        static member center = FssTypes.Flex.JustifySelf.Center |> justifySelfValue'
        static member baseline = FssTypes.Flex.JustifySelf.Baseline |> justifySelfValue'
        static member firstBaseline = FssTypes.Flex.JustifySelf.FirstBaseline |> justifySelfValue'
        static member lastBaseline = FssTypes.Flex.JustifySelf.LastBaseline |> justifySelfValue'
        static member stretch = FssTypes.Flex.JustifySelf.Stretch |> justifySelfValue'
        static member safe = FssTypes.Flex.JustifySelf.Safe |> justifySelfValue'
        static member unsafe = FssTypes.Flex.JustifySelf.Unsafe |> justifySelfValue'
        static member selfStart = FssTypes.Flex.JustifySelf.SelfStart |> justifySelfValue'
        static member selfEnd = FssTypes.Flex.JustifySelf.SelfEnd |> justifySelfValue'

        static member normal = FssTypes.Normal |> justifySelfValue'
        static member inherit' = FssTypes.Inherit |> justifySelfValue'
        static member initial = FssTypes.Initial |> justifySelfValue'
        static member unset = FssTypes.Unset |> justifySelfValue'

    /// Specifies how elements are justified in its container.
    /// Valid parameters:
    /// - JustifySelf
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let JustifySelf' = JustifySelf.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    let private flexDirectionValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexDirection
    let private flexDirectionValue' = flexDirectionToString >> flexDirectionValue

    [<Erase>]
    /// Specifies in which direction items in a flex container are oriented.
    type FlexDirection =
        static member value (direction: FssTypes.IFlexDirection) = direction |> flexDirectionValue'
        static member row = FssTypes.Flex.Direction.Row |> flexDirectionValue'
        static member rowReverse = FssTypes.Flex.Direction.RowReverse |> flexDirectionValue'
        static member column = FssTypes.Flex.Direction.Column |> flexDirectionValue'
        static member columnReverse = FssTypes.Flex.Direction.ColumnReverse |> flexDirectionValue'

        static member inherit' = FssTypes.Inherit |> flexDirectionValue'
        static member initial = FssTypes.Initial |> flexDirectionValue'
        static member unset = FssTypes.Unset |> flexDirectionValue'

    /// Specifies in which direction items in a flex container are oriented.
    /// Valid parameters:
    /// - FlexDirection
    /// - Inherit
    /// - Initial
    /// - Unset
    let FlexDirection' = FlexDirection.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    let private flexWrapValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexWrap
    let private flexWrapValue' = flexWrapToString >> flexWrapValue

    [<Erase>]
    /// Specifies if flex items can wrap onto multiple lines.
    type FlexWrap =
        static member value (direction: FssTypes.IFlexWrap) = direction |> flexWrapValue'
        static member noWrap = FssTypes.Flex.NoWrap |> flexWrapValue'
        static member wrap = FssTypes.Flex.Wrap |> flexWrapValue'
        static member wrapReverse = FssTypes.Flex.WrapReverse |> flexWrapValue'

        static member inherit' = FssTypes.Inherit |> flexWrapValue'
        static member initial = FssTypes.Initial |> flexWrapValue'
        static member unset = FssTypes.Unset |> flexWrapValue'

    /// Specifies if flex items can wrap onto multiple lines.
    /// Valid parameters:
    /// - FlexDirection
    /// - Inherit
    /// - Initial
    /// - Unset
    let FlexWrap' = FlexWrap.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    let private orderValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Order
    let private orderValue' = orderToString >> orderValue
    [<Erase>]
    type Order =
        static member value (order: FssTypes.IOrder) = order |> orderValue'

        static member inherit' = FssTypes.Inherit |> orderValue'
        static member initial = FssTypes.Initial |> orderValue'
        static member unset = FssTypes.Unset |> orderValue'

    /// Specify order of items in flex.
    /// - CssInt
    /// - Inherit
    /// - Initial
    /// - Unset
    let Order' = Order.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    let private flexGrowValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexGrow
    let private flexGrowValue' = flexGrowToString >> flexGrowValue

    [<Erase>]
    /// Sets grow factor of flex item.
    type FlexGrow =
        static member value (grow: FssTypes.IFlexGrow) = grow |> flexGrowValue'

        static member inherit' = FssTypes.Inherit |> flexGrowValue'
        static member initial = FssTypes.Initial |> flexGrowValue'
        static member unset = FssTypes.Unset |> flexGrowValue'

    /// Sets grow factor of flex item.
    /// Valid parameters:
    /// - CssFloat
    /// - Inherit
    /// - Initial
    /// - Unset
    let FlexGrow' = FlexGrow.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    let private flexShrinkValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexShrink
    let private flexShrinkValue' = flexShrinkToString >> flexShrinkValue

    [<Erase>]
    /// Sets shrink factor of flex item.
    type FlexShrink =
        static member value (shrink: FssTypes.IFlexShrink) = shrink |> flexShrinkValue'
        static member inherit' = FssTypes.Inherit |> flexShrinkValue'
        static member initial = FssTypes.Initial |> flexShrinkValue'
        static member unset =  FssTypes.Unset |> flexShrinkValue'

    /// Sets shrink factor of flex item.
    /// Valid parameters:
    /// - CssFloat
    /// - Inherit
    /// - Initial
    /// - Unset
    let FlexShrink' = FlexShrink.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    let private flexBasisValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexBasis
    let private flexBasisValue' = flexBasisToString >> flexBasisValue

    [<Erase>]
    /// Sets initial main size of flex item.
    type FlexBasis =
        static member value (basis: FssTypes.IFlexBasis) = basis |> flexBasisValue'
        static member fill = FssTypes.Flex.Basis.Fill |> flexBasisValue'
        static member maxContent = FssTypes.Flex.Basis.MaxContent |> flexBasisValue'
        static member minContent = FssTypes.Flex.Basis.MinContent |> flexBasisValue'
        static member fitContent = FssTypes.Flex.Basis.FitContent |> flexBasisValue'
        static member content = FssTypes.Flex.Basis.Content |> flexBasisValue'

        static member auto = FssTypes.Auto |> flexBasisValue'
        static member inherit' = FssTypes.Inherit |> flexBasisValue'
        static member initial = FssTypes.Initial |> flexBasisValue'
        static member unset = FssTypes.Unset |> flexBasisValue'

    /// Sets initial main size of flex item.
    /// Valid parameters:
    /// - FlexBasis
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    /// - Units.Size
    /// - Units.Percent
    let FlexBasis' = FlexBasis.value
