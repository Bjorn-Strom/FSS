namespace Fss

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
        | :? FssTypes.Size as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex basis"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    let private alignContentValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignContent value
    let private alignContentValue' value =
        value
        |> alignContentToString
        |> alignContentValue

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

    /// <summary>Aligns elements vertically in flex.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> AlignContent </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AlignContent' (align: FssTypes.IAlignContent) = AlignContent.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    let private alignItemsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignItems value
    let private alignItemsValue' value =
        value
        |> alignItemsToString
        |> alignItemsValue

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

    /// <summary>Aligns elements along cross axis along the main axis in flex.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> AlignContent </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AlignItems' (align: FssTypes.IAlignItems) = AlignItems.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    let private alignSelfValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignSelf value
    let private alignSelfValue' value =
        value
        |> alignSelfToString
        |> alignSelfValue

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

    /// <summary>Overrides an elements <c>align-items</c> value-.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> AlignContent </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let AlignSelf' (align: FssTypes.IAlignSelf) = AlignSelf.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    let private justifyContentValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifyContent value
    let private justifyContentValue' value =
        value
        |> justifyContentToString
        |> justifyContentValue

    type JustifyContent =
        static member value (justification: FssTypes.IJustifyContent) = justification |> justifyContentValue
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

    /// <summary>Aligns elements horizontally in flex.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> JustifyContent </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let JustifyContent' (align: FssTypes.IJustifyContent) = JustifyContent.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    let private justifyItemsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifyItems value
    let private justifyItemsValue' value =
        value
        |> justifyItemsToString
        |> justifyItemsValue

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

    /// <summary>Specifies default <c>justify-self</c> for items of element.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> JustifyItems </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let JustifyItems' (align: FssTypes.IJustifyItems) = JustifyItems.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    let private justifySelfValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifySelf value
    let private justifySelfValue' value =
        value
        |> justifySelfToString
        |> justifySelfValue
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

    /// <summary>Specifies how elements are justified in its container.</summary>
    /// <param name="align">
    ///     can be:
    ///     - <c> JustifySelf </c>
    ///     - <c> Normal </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let JustifySelf' (align: FssTypes.IJustifySelf) = JustifySelf.value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    let private flexDirectionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexDirection value
    let private flexDirectionValue' value =
        value
        |> flexDirectionToString
        |> flexDirectionValue

    type FlexDirection =
        static member value (direction: FssTypes.IFlexDirection) = direction |> flexDirectionValue'
        static member row = FssTypes.Flex.Direction.Row |> flexDirectionValue'
        static member rowReverse = FssTypes.Flex.Direction.RowReverse |> flexDirectionValue'
        static member column = FssTypes.Flex.Direction.Column |> flexDirectionValue'
        static member columnReverse = FssTypes.Flex.Direction.ColumnReverse |> flexDirectionValue'

        static member inherit' = FssTypes.Inherit |> flexDirectionValue'
        static member initial = FssTypes.Initial |> flexDirectionValue'
        static member unset = FssTypes.Unset |> flexDirectionValue'

    /// <summary>Specifies in which direction items in a flex container are oriented.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexDirection' (direction: FssTypes.IFlexDirection) = FlexDirection.value(direction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    let private flexWrapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexWrap value
    let private flexWrapValue' value =
        value
        |> flexWrapToString
        |> flexWrapValue
    type FlexWrap =
        static member value (direction: FssTypes.IFlexWrap) = direction |> flexWrapValue'
        static member noWrap = FssTypes.Flex.NoWrap |> flexWrapValue'
        static member wrap = FssTypes.Flex.Wrap |> flexWrapValue'
        static member wrapReverse = FssTypes.Flex.WrapReverse |> flexWrapValue'

        static member inherit' = FssTypes.Inherit |> flexWrapValue'
        static member initial = FssTypes.Initial |> flexWrapValue'
        static member unset = FssTypes.Unset |> flexWrapValue'

    /// <summary>Specifies if flex items can wrap onto multiple lines.</summary>
    /// <param name="wrap">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexWrap' (wrap: FssTypes.IFlexWrap) = FlexWrap.value(wrap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    let private orderValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Order value
    let private orderValue' value =
        value
        |> orderToString
        |> orderValue
    type Order =
        static member value (order: FssTypes.IOrder) = order |> orderValue'

        static member inherit' = FssTypes.Inherit |> orderValue'
        static member initial = FssTypes.Initial |> orderValue'
        static member unset = FssTypes.Unset |> orderValue'

    /// <summary>Specify order of items in flex.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Order' (order: FssTypes.IOrder) = Order.value(order)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    let private flexGrowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexGrow value
    let private flexGrowValue' value =
        value
        |> flexGrowToString
        |> flexGrowValue

    type FlexGrow =
        static member value (grow: FssTypes.IFlexGrow) = grow |> flexGrowValue'

        static member inherit' = FssTypes.Inherit |> flexGrowValue'
        static member initial = FssTypes.Initial |> flexGrowValue'
        static member unset = FssTypes.Unset |> flexGrowValue'

    /// <summary>Sets grow factor of flex item.</summary>
    /// <param name="grow">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexGrow' (grow: FssTypes.IFlexGrow) = FlexGrow.value(grow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    let private flexShrinkValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexShrink value
    let private flexShrinkValue' value =
        value
        |> flexShrinkToString
        |> flexShrinkValue

    type FlexShrink =
        static member value (shrink: FssTypes.IFlexShrink) = shrink |> flexShrinkValue'
        static member inherit' = FssTypes.Inherit |> flexShrinkValue'
        static member initial = FssTypes.Initial |> flexShrinkValue'
        static member unset =  FssTypes.Unset |> flexShrinkValue'

    /// <summary>Sets shrink factor of flex item.</summary>
    /// <param name="shrink">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexShrink' (shrink: FssTypes.IFlexShrink) = FlexShrink.value(shrink)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    let private flexBasisValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexBasis value
    let private flexBasisValue' value =
        value
        |> flexBasisToString
        |> flexBasisValue

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

    /// <summary>Sets initial main size of flex item.</summary>
    /// <param name="basis">
    ///     can be:
    ///     - <c> FlexBasis </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexBasis' (basis: FssTypes.IFlexBasis) = FlexBasis.value(basis)
