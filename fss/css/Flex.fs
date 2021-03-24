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
        static member Value (alignment: FssTypes.IAlignContent) = alignment |> alignContentValue'
        static member Start = FssTypes.Flex.AlignContent.Start |> alignContentValue'
        static member End = FssTypes.Flex.AlignContent.End |> alignContentValue'
        static member FlexStart = FssTypes.Flex.AlignContent.FlexStart |> alignContentValue'
        static member FlexEnd = FssTypes.Flex.AlignContent.FlexEnd |> alignContentValue'
        static member Center = FssTypes.Flex.AlignContent.Center |> alignContentValue'
        static member Baseline = FssTypes.Flex.AlignContent.Baseline |> alignContentValue'
        static member FirstBaseline = FssTypes.Flex.AlignContent.FirstBaseline |> alignContentValue'
        static member LastBaseline = FssTypes.Flex.AlignContent.LastBaseline |> alignContentValue'
        static member Stretch = FssTypes.Flex.AlignContent.Stretch |> alignContentValue'
        static member Safe = FssTypes.Flex.AlignContent.Safe |> alignContentValue'
        static member Unsafe = FssTypes.Flex.AlignContent.Unsafe |> alignContentValue'
        static member SpaceBetween = FssTypes.Flex.AlignContent.SpaceBetween |> alignContentValue'
        static member SpaceAround = FssTypes.Flex.AlignContent.SpaceAround |> alignContentValue'
        static member SpaceEvenly = FssTypes.Flex.AlignContent.SpaceEvenly |> alignContentValue'

        static member Normal = FssTypes.Normal |> alignContentValue'
        static member Inherit = FssTypes.Inherit |> alignContentValue'
        static member Initial = FssTypes.Initial |> alignContentValue'
        static member Unset = FssTypes.Unset |> alignContentValue'

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
    let AlignContent' (align: FssTypes.IAlignContent) = AlignContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    let private alignItemsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignItems value
    let private alignItemsValue' value =
        value
        |> alignItemsToString
        |> alignItemsValue

    type AlignItems =
        static member Value (alignment: FssTypes.IAlignItems) = alignment |> alignItemsValue'
        static member Start = FssTypes.Flex.AlignItems.Start |> alignItemsValue'
        static member End = FssTypes.Flex.AlignItems.End |> alignItemsValue'
        static member FlexStart = FssTypes.Flex.AlignItems.FlexStart |> alignItemsValue'
        static member FlexEnd = FssTypes.Flex.AlignItems.FlexEnd |> alignItemsValue'
        static member Center = FssTypes.Flex.AlignItems.Center |> alignItemsValue'
        static member Baseline = FssTypes.Flex.AlignItems.Baseline |> alignItemsValue'
        static member FirstBaseline = FssTypes.Flex.AlignItems.FirstBaseline |> alignItemsValue'
        static member LastBaseline = FssTypes.Flex.AlignItems.LastBaseline |> alignItemsValue'
        static member Stretch = FssTypes.Flex.AlignItems.Stretch |> alignItemsValue'
        static member Safe = FssTypes.Flex.AlignItems.Safe |> alignItemsValue'
        static member Unsafe = FssTypes.Flex.AlignItems.Unsafe |> alignItemsValue'
        static member SelfStart = FssTypes.Flex.AlignItems.SelfStart |> alignItemsValue'
        static member SelfEnd = FssTypes.Flex.AlignItems.SelfEnd |> alignItemsValue'

        static member Normal = FssTypes.Normal |> alignItemsValue'
        static member Inherit = FssTypes.Inherit |> alignItemsValue'
        static member Initial = FssTypes.Initial |> alignItemsValue'
        static member Unset = FssTypes.Unset |> alignItemsValue'

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
    let AlignItems' (align: FssTypes.IAlignItems) = AlignItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    let private alignSelfValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.AlignSelf value
    let private alignSelfValue' value =
        value
        |> alignSelfToString
        |> alignSelfValue

    type AlignSelf =
        static member Value (alignment: FssTypes.IAlignSelf) = alignment |> alignSelfValue'
        static member Start = FssTypes.Flex.AlignSelf.Start |> alignSelfValue'
        static member End = FssTypes.Flex.AlignSelf.End |> alignSelfValue'
        static member FlexStart = FssTypes.Flex.AlignSelf.FlexStart |> alignSelfValue'
        static member FlexEnd = FssTypes.Flex.AlignSelf.FlexEnd |> alignSelfValue'
        static member Center = FssTypes.Flex.AlignSelf.Center |> alignSelfValue'
        static member Baseline = FssTypes.Flex.AlignSelf.Baseline |> alignSelfValue'
        static member FirstBaseline = FssTypes.Flex.AlignSelf.FirstBaseline |> alignSelfValue'
        static member LastBaseline = FssTypes.Flex.AlignSelf.LastBaseline |> alignSelfValue'
        static member Stretch = FssTypes.Flex.AlignSelf.Stretch |> alignSelfValue'
        static member Safe = FssTypes.Flex.AlignSelf.Safe |> alignSelfValue'
        static member Unsafe = FssTypes.Flex.AlignSelf.Unsafe |> alignSelfValue'
        static member SelfStart = FssTypes.Flex.AlignSelf.SelfStart |> alignSelfValue'
        static member SelfEnd = FssTypes.Flex.AlignSelf.SelfEnd |> alignSelfValue'

        static member Normal = FssTypes.Normal |> alignSelfValue'
        static member Inherit = FssTypes.Inherit |> alignSelfValue'
        static member Initial = FssTypes.Initial |> alignSelfValue'
        static member Unset = FssTypes.Unset |> alignSelfValue'

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
    let AlignSelf' (align: FssTypes.IAlignSelf) = AlignSelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    let private justifyContentValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifyContent value
    let private justifyContentValue' value =
        value
        |> justifyContentToString
        |> justifyContentValue

    type JustifyContent =
        static member Value (justification: FssTypes.IJustifyContent) = justification |> justifyContentValue
        static member Start = FssTypes.Flex.JustifyContent.Start |> justifyContentValue'
        static member End = FssTypes.Flex.JustifyContent.End |> justifyContentValue'
        static member FlexStart = FssTypes.Flex.JustifyContent.FlexStart |> justifyContentValue'
        static member FlexEnd = FssTypes.Flex.JustifyContent.FlexEnd |> justifyContentValue'
        static member Center = FssTypes.Flex.JustifyContent.Center |> justifyContentValue'
        static member Baseline = FssTypes.Flex.JustifyContent.Baseline |> justifyContentValue'
        static member FirstBaseline = FssTypes.Flex.JustifyContent.FirstBaseline |> justifyContentValue'
        static member LastBaseline = FssTypes.Flex.JustifyContent.LastBaseline |> justifyContentValue'
        static member Stretch = FssTypes.Flex.JustifyContent.Stretch |> justifyContentValue'
        static member Safe = FssTypes.Flex.JustifyContent.Safe |> justifyContentValue'
        static member Unsafe = FssTypes.Flex.JustifyContent.Unsafe |> justifyContentValue'
        static member Left = FssTypes.Flex.JustifyContent.Left |> justifyContentValue'
        static member Right = FssTypes.Flex.JustifyContent.Right |> justifyContentValue'
        static member SpaceBetween = FssTypes.Flex.JustifyContent.SpaceBetween |> justifyContentValue'
        static member SpaceAround = FssTypes.Flex.JustifyContent.SpaceAround |> justifyContentValue'
        static member SpaceEvenly = FssTypes.Flex.JustifyContent.SpaceEvenly |> justifyContentValue'

        static member Normal = FssTypes.Normal |> justifyContentValue'
        static member Inherit = FssTypes.Inherit |> justifyContentValue'
        static member Initial = FssTypes.Initial |> justifyContentValue'
        static member Unset = FssTypes.Unset |> justifyContentValue'

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
    let JustifyContent' (align: FssTypes.IJustifyContent) = JustifyContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    let private justifyItemsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifyItems value
    let private justifyItemsValue' value =
        value
        |> justifyItemsToString
        |> justifyItemsValue

    type JustifyItems =
        static member Value (justification: FssTypes.IJustifyItems) = justification |> justifyItemsValue'
        static member Start = FssTypes.Flex.JustifyItems.Start |> justifyItemsValue'
        static member End = FssTypes.Flex.JustifyItems.End |> justifyItemsValue'
        static member FlexStart = FssTypes.Flex.JustifyItems.FlexStart |> justifyItemsValue'
        static member FlexEnd = FssTypes.Flex.JustifyItems.FlexEnd |> justifyItemsValue'
        static member Center = FssTypes.Flex.JustifyItems.Center |> justifyItemsValue'
        static member Baseline = FssTypes.Flex.JustifyItems.Baseline |> justifyItemsValue'
        static member FirstBaseline = FssTypes.Flex.JustifyItems.FirstBaseline |> justifyItemsValue'
        static member LastBaseline = FssTypes.Flex.JustifyItems.LastBaseline |> justifyItemsValue'
        static member Stretch = FssTypes.Flex.JustifyItems.Stretch |> justifyItemsValue'
        static member Safe = FssTypes.Flex.JustifyItems.Safe |> justifyItemsValue'
        static member Unsafe = FssTypes.Flex.JustifyItems.Unsafe |> justifyItemsValue'
        static member Left = FssTypes.Flex.JustifyItems.Left |> justifyItemsValue'
        static member Right = FssTypes.Flex.JustifyItems.Right |> justifyItemsValue'
        static member SelfStart = FssTypes.Flex.JustifyItems.SelfStart |> justifyItemsValue'
        static member SelfEnd = FssTypes.Flex.JustifyItems.SelfEnd |> justifyItemsValue'
        static member Legacy = FssTypes.Flex.JustifyItems.Legacy |> justifyItemsValue'

        static member Normal = FssTypes.Normal |> justifyItemsValue'
        static member Inherit = FssTypes.Inherit |> justifyItemsValue'
        static member Initial = FssTypes.Initial |> justifyItemsValue'
        static member Unset = FssTypes.Unset |> justifyItemsValue'

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
    let JustifyItems' (align: FssTypes.IJustifyItems) = JustifyItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    let private justifySelfValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.JustifySelf value
    let private justifySelfValue' value =
        value
        |> justifySelfToString
        |> justifySelfValue
    type JustifySelf =
        static member Value (justification: FssTypes.IJustifySelf) = justification |> justifySelfValue'
        static member Start = FssTypes.Flex.JustifySelf.Start |> justifySelfValue'
        static member End = FssTypes.Flex.JustifySelf.End |> justifySelfValue'
        static member FlexStart = FssTypes.Flex.JustifySelf.FlexStart |> justifySelfValue'
        static member FlexEnd = FssTypes.Flex.JustifySelf.FlexEnd |> justifySelfValue'
        static member Center = FssTypes.Flex.JustifySelf.Center |> justifySelfValue'
        static member Baseline = FssTypes.Flex.JustifySelf.Baseline |> justifySelfValue'
        static member FirstBaseline = FssTypes.Flex.JustifySelf.FirstBaseline |> justifySelfValue'
        static member LastBaseline = FssTypes.Flex.JustifySelf.LastBaseline |> justifySelfValue'
        static member Stretch = FssTypes.Flex.JustifySelf.Stretch |> justifySelfValue'
        static member Safe = FssTypes.Flex.JustifySelf.Safe |> justifySelfValue'
        static member Unsafe = FssTypes.Flex.JustifySelf.Unsafe |> justifySelfValue'
        static member SelfStart = FssTypes.Flex.JustifySelf.SelfStart |> justifySelfValue'
        static member SelfEnd = FssTypes.Flex.JustifySelf.SelfEnd |> justifySelfValue'

        static member Normal = FssTypes.Normal |> justifySelfValue'
        static member Inherit = FssTypes.Inherit |> justifySelfValue'
        static member Initial = FssTypes.Initial |> justifySelfValue'
        static member Unset = FssTypes.Unset |> justifySelfValue'

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
    let JustifySelf' (align: FssTypes.IJustifySelf) = JustifySelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    let private flexDirectionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexDirection value
    let private flexDirectionValue' value =
        value
        |> flexDirectionToString
        |> flexDirectionValue

    type FlexDirection =
        static member Value (direction: FssTypes.IFlexDirection) = direction |> flexDirectionValue'
        static member Row = FssTypes.Flex.Direction.Row |> flexDirectionValue'
        static member RowReverse = FssTypes.Flex.Direction.RowReverse |> flexDirectionValue'
        static member Column = FssTypes.Flex.Direction.Column |> flexDirectionValue'
        static member ColumnReverse = FssTypes.Flex.Direction.ColumnReverse |> flexDirectionValue'

        static member Inherit = FssTypes.Inherit |> flexDirectionValue'
        static member Initial = FssTypes.Initial |> flexDirectionValue'
        static member Unset = FssTypes.Unset |> flexDirectionValue'

    /// <summary>Specifies in which direction items in a flex container are oriented.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexDirection' (direction: FssTypes.IFlexDirection) = FlexDirection.Value(direction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    let private flexWrapValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexWrap value
    let private flexWrapValue' value =
        value
        |> flexWrapToString
        |> flexWrapValue
    type FlexWrap =
        static member Value (direction: FssTypes.IFlexWrap) = direction |> flexWrapValue'
        static member NoWrap = FssTypes.Flex.NoWrap |> flexWrapValue'
        static member Wrap = FssTypes.Flex.Wrap |> flexWrapValue'
        static member WrapReverse = FssTypes.Flex.WrapReverse |> flexWrapValue'

        static member Inherit = FssTypes.Inherit |> flexWrapValue'
        static member Initial = FssTypes.Initial |> flexWrapValue'
        static member Unset = FssTypes.Unset |> flexWrapValue'

    /// <summary>Specifies if flex items can wrap onto multiple lines.</summary>
    /// <param name="wrap">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexWrap' (wrap: FssTypes.IFlexWrap) = FlexWrap.Value(wrap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    let private orderValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Order value
    let private orderValue' value =
        value
        |> orderToString
        |> orderValue
    type Order =
        static member Value (order: FssTypes.IOrder) = order |> orderValue'

        static member Inherit = FssTypes.Inherit |> orderValue'
        static member Initial = FssTypes.Initial |> orderValue'
        static member Unset = FssTypes.Unset |> orderValue'

    /// <summary>Specify order of items in flex.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Order' (order: FssTypes.IOrder) = Order.Value(order)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    let private flexGrowValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexGrow value
    let private flexGrowValue' value =
        value
        |> flexGrowToString
        |> flexGrowValue

    type FlexGrow =
        static member Value (grow: FssTypes.IFlexGrow) = grow |> flexGrowValue'

        static member Inherit = FssTypes.Inherit |> flexGrowValue'
        static member Initial = FssTypes.Initial |> flexGrowValue'
        static member Unset = FssTypes.Unset |> flexGrowValue'

    /// <summary>Sets grow factor of flex item.</summary>
    /// <param name="grow">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexGrow' (grow: FssTypes.IFlexGrow) = FlexGrow.Value(grow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    let private flexShrinkValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexShrink value
    let private flexShrinkValue' value =
        value
        |> flexShrinkToString
        |> flexShrinkValue

    type FlexShrink =
        static member Value (shrink: FssTypes.IFlexShrink) = shrink |> flexShrinkValue'
        static member Inherit = FssTypes.Inherit |> flexShrinkValue'
        static member Initial = FssTypes.Initial |> flexShrinkValue'
        static member Unset =  FssTypes.Unset |> flexShrinkValue'

    /// <summary>Sets shrink factor of flex item.</summary>
    /// <param name="shrink">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexShrink' (shrink: FssTypes.IFlexShrink) = FlexShrink.Value(shrink)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    let private flexBasisValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.FlexBasis value
    let private flexBasisValue' value =
        value
        |> flexBasisToString
        |> flexBasisValue

    type FlexBasis =
        static member Value (basis: FssTypes.IFlexBasis) = basis |> flexBasisValue'
        static member Fill = FssTypes.Flex.Basis.Fill |> flexBasisValue'
        static member MaxContent = FssTypes.Flex.Basis.MaxContent |> flexBasisValue'
        static member MinContent = FssTypes.Flex.Basis.MinContent |> flexBasisValue'
        static member FitContent = FssTypes.Flex.Basis.FitContent |> flexBasisValue'
        static member Content = FssTypes.Flex.Basis.Content |> flexBasisValue'

        static member Auto = FssTypes.Auto |> flexBasisValue'
        static member Inherit = FssTypes.Inherit |> flexBasisValue'
        static member Initial = FssTypes.Initial |> flexBasisValue'
        static member Unset = FssTypes.Unset |> flexBasisValue'

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
    let FlexBasis' (basis: FssTypes.IFlexBasis) = FlexBasis.Value(basis)
