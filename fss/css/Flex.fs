namespace Fss

[<AutoOpen>]
module Flex =

    let private alignContentToString (alignment: Types.IAlignContent) =
        match alignment with
        | :? Types.Flex.AlignContent as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align content"

    let private alignItemsToString (alignment: Types.IAlignItems) =
        match alignment with
        | :? Types.Flex.AlignItems as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align items"

    let private alignSelfToString (alignment: Types.IAlignSelf) =
        match alignment with
        | :? Types.Flex.AlignSelf as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align self"

    let private justifyContentToString (justification: Types.IJustifyContent) =
        match justification with
        | :? Types.Flex.JustifyContent as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify content"

    let private justifyItemsToString (justification: Types.IJustifyItems) =
        match justification with
        | :? Types.Flex.JustifyItems as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify items"

    let private justifySelfToString (justification: Types.IJustifySelf) =
        match justification with
        | :? Types.Flex.JustifySelf as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify self"

    let private flexDirectionToString (direction: Types.IFlexDirection) =
        match direction with
        | :? Types.Flex.Direction as a -> Utilities.Helpers.duToKebab a
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex direction"

    let private flexToString(flex: Types.IFlex) =
        match flex with
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown flex"

    let private flexWrapToString (direction: Types.IFlexWrap) =
        match direction with
        | :? Types.Flex.Wrap as a -> Utilities.Helpers.duToKebab a
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex wrap"

    let private orderToString (order: Types.IOrder) =
        match order with
        | :? Types.CssInt as i -> Types.masterTypeHelpers.IntToString i
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown order"

    let private flexGrowToString (flexGrow: Types.IFlexGrow) =
        match flexGrow with
        | :? Types.CssFloat as f -> Types.masterTypeHelpers.FloatToString f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex grow"

    let private flexShrinkToString (flexShrink: Types.IFlexShrink) =
        match flexShrink with
        | :? Types.CssFloat as f -> Types.masterTypeHelpers.FloatToString f
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex shrink"

    let private flexBasisToString (basis: Types.IFlexBasis) =
        match basis with
        | :? Types.Flex.Basis as b -> Utilities.Helpers.duToKebab b
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | :? Types.Size as s -> Types.unitHelpers.sizeToString s
        | :? Types.Percent as p -> Types.unitHelpers.percentToString p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown flex basis"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    let private alignContentValue value = Types.propertyHelpers.cssValue Types.Property.AlignContent value
    let private alignContentValue' value =
        value
        |> alignContentToString
        |> alignContentValue

    type AlignContent =
        static member Value (alignment: Types.IAlignContent) = alignment |> alignContentValue'
        static member Start = Types.Flex.AlignContent.Start |> alignContentValue'
        static member End = Types.Flex.AlignContent.End |> alignContentValue'
        static member FlexStart = Types.Flex.AlignContent.FlexStart |> alignContentValue'
        static member FlexEnd = Types.Flex.AlignContent.FlexEnd |> alignContentValue'
        static member Center = Types.Flex.AlignContent.Center |> alignContentValue'
        static member Baseline = Types.Flex.AlignContent.Baseline |> alignContentValue'
        static member FirstBaseline = Types.Flex.AlignContent.FirstBaseline |> alignContentValue'
        static member LastBaseline = Types.Flex.AlignContent.LastBaseline |> alignContentValue'
        static member Stretch = Types.Flex.AlignContent.Stretch |> alignContentValue'
        static member Safe = Types.Flex.AlignContent.Safe |> alignContentValue'
        static member Unsafe = Types.Flex.AlignContent.Unsafe |> alignContentValue'
        static member SpaceBetween = Types.Flex.AlignContent.SpaceBetween |> alignContentValue'
        static member SpaceAround = Types.Flex.AlignContent.SpaceAround |> alignContentValue'
        static member SpaceEvenly = Types.Flex.AlignContent.SpaceEvenly |> alignContentValue'

        static member Normal = Types.Normal |> alignContentValue'
        static member Inherit = Types.Inherit |> alignContentValue'
        static member Initial = Types.Initial |> alignContentValue'
        static member Unset = Types.Unset |> alignContentValue'

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
    let AlignContent' (align: Types.IAlignContent) = AlignContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    let private alignItemsValue value = Types.propertyHelpers.cssValue Types.Property.AlignItems value
    let private alignItemsValue' value =
        value
        |> alignItemsToString
        |> alignItemsValue

    type AlignItems =
        static member Value (alignment: Types.IAlignItems) = alignment |> alignItemsValue'
        static member Start = Types.Flex.AlignItems.Start |> alignItemsValue'
        static member End = Types.Flex.AlignItems.End |> alignItemsValue'
        static member FlexStart = Types.Flex.AlignItems.FlexStart |> alignItemsValue'
        static member FlexEnd = Types.Flex.AlignItems.FlexEnd |> alignItemsValue'
        static member Center = Types.Flex.AlignItems.Center |> alignItemsValue'
        static member Baseline = Types.Flex.AlignItems.Baseline |> alignItemsValue'
        static member FirstBaseline = Types.Flex.AlignItems.FirstBaseline |> alignItemsValue'
        static member LastBaseline = Types.Flex.AlignItems.LastBaseline |> alignItemsValue'
        static member Stretch = Types.Flex.AlignItems.Stretch |> alignItemsValue'
        static member Safe = Types.Flex.AlignItems.Safe |> alignItemsValue'
        static member Unsafe = Types.Flex.AlignItems.Unsafe |> alignItemsValue'
        static member SelfStart = Types.Flex.AlignItems.SelfStart |> alignItemsValue'
        static member SelfEnd = Types.Flex.AlignItems.SelfEnd |> alignItemsValue'

        static member Normal = Types.Normal |> alignItemsValue'
        static member Inherit = Types.Inherit |> alignItemsValue'
        static member Initial = Types.Initial |> alignItemsValue'
        static member Unset = Types.Unset |> alignItemsValue'

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
    let AlignItems' (align: Types.IAlignItems) = AlignItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    let private alignSelfValue value = Types.propertyHelpers.cssValue Types.Property.AlignSelf value
    let private alignSelfValue' value =
        value
        |> alignSelfToString
        |> alignSelfValue

    type AlignSelf =
        static member Value (alignment: Types.IAlignSelf) = alignment |> alignSelfValue'
        static member Start = Types.Flex.AlignSelf.Start |> alignSelfValue'
        static member End = Types.Flex.AlignSelf.End |> alignSelfValue'
        static member FlexStart = Types.Flex.AlignSelf.FlexStart |> alignSelfValue'
        static member FlexEnd = Types.Flex.AlignSelf.FlexEnd |> alignSelfValue'
        static member Center = Types.Flex.AlignSelf.Center |> alignSelfValue'
        static member Baseline = Types.Flex.AlignSelf.Baseline |> alignSelfValue'
        static member FirstBaseline = Types.Flex.AlignSelf.FirstBaseline |> alignSelfValue'
        static member LastBaseline = Types.Flex.AlignSelf.LastBaseline |> alignSelfValue'
        static member Stretch = Types.Flex.AlignSelf.Stretch |> alignSelfValue'
        static member Safe = Types.Flex.AlignSelf.Safe |> alignSelfValue'
        static member Unsafe = Types.Flex.AlignSelf.Unsafe |> alignSelfValue'
        static member SelfStart = Types.Flex.AlignSelf.SelfStart |> alignSelfValue'
        static member SelfEnd = Types.Flex.AlignSelf.SelfEnd |> alignSelfValue'

        static member Normal = Types.Normal |> alignSelfValue'
        static member Inherit = Types.Inherit |> alignSelfValue'
        static member Initial = Types.Initial |> alignSelfValue'
        static member Unset = Types.Unset |> alignSelfValue'

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
    let AlignSelf' (align: Types.IAlignSelf) = AlignSelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    let private justifyContentValue value = Types.propertyHelpers.cssValue Types.Property.JustifyContent value
    let private justifyContentValue' value =
        value
        |> justifyContentToString
        |> justifyContentValue

    type JustifyContent =
        static member Value (justification: Types.IJustifyContent) = justification |> justifyContentValue
        static member Start = Types.Flex.JustifyContent.Start |> justifyContentValue'
        static member End = Types.Flex.JustifyContent.End |> justifyContentValue'
        static member FlexStart = Types.Flex.JustifyContent.FlexStart |> justifyContentValue'
        static member FlexEnd = Types.Flex.JustifyContent.FlexEnd |> justifyContentValue'
        static member Center = Types.Flex.JustifyContent.Center |> justifyContentValue'
        static member Baseline = Types.Flex.JustifyContent.Baseline |> justifyContentValue'
        static member FirstBaseline = Types.Flex.JustifyContent.FirstBaseline |> justifyContentValue'
        static member LastBaseline = Types.Flex.JustifyContent.LastBaseline |> justifyContentValue'
        static member Stretch = Types.Flex.JustifyContent.Stretch |> justifyContentValue'
        static member Safe = Types.Flex.JustifyContent.Safe |> justifyContentValue'
        static member Unsafe = Types.Flex.JustifyContent.Unsafe |> justifyContentValue'
        static member Left = Types.Flex.JustifyContent.Left |> justifyContentValue'
        static member Right = Types.Flex.JustifyContent.Right |> justifyContentValue'
        static member SpaceBetween = Types.Flex.JustifyContent.SpaceBetween |> justifyContentValue'
        static member SpaceAround = Types.Flex.JustifyContent.SpaceAround |> justifyContentValue'
        static member SpaceEvenly = Types.Flex.JustifyContent.SpaceEvenly |> justifyContentValue'

        static member Normal = Types.Normal |> justifyContentValue'
        static member Inherit = Types.Inherit |> justifyContentValue'
        static member Initial = Types.Initial |> justifyContentValue'
        static member Unset = Types.Unset |> justifyContentValue'

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
    let JustifyContent' (align: Types.IJustifyContent) = JustifyContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    let private justifyItemsValue value = Types.propertyHelpers.cssValue Types.Property.JustifyItems value
    let private justifyItemsValue' value =
        value
        |> justifyItemsToString
        |> justifyItemsValue

    type JustifyItems =
        static member Value (justification: Types.IJustifyItems) = justification |> justifyItemsValue'
        static member Start = Types.Flex.JustifyItems.Start |> justifyItemsValue'
        static member End = Types.Flex.JustifyItems.End |> justifyItemsValue'
        static member FlexStart = Types.Flex.JustifyItems.FlexStart |> justifyItemsValue'
        static member FlexEnd = Types.Flex.JustifyItems.FlexEnd |> justifyItemsValue'
        static member Center = Types.Flex.JustifyItems.Center |> justifyItemsValue'
        static member Baseline = Types.Flex.JustifyItems.Baseline |> justifyItemsValue'
        static member FirstBaseline = Types.Flex.JustifyItems.FirstBaseline |> justifyItemsValue'
        static member LastBaseline = Types.Flex.JustifyItems.LastBaseline |> justifyItemsValue'
        static member Stretch = Types.Flex.JustifyItems.Stretch |> justifyItemsValue'
        static member Safe = Types.Flex.JustifyItems.Safe |> justifyItemsValue'
        static member Unsafe = Types.Flex.JustifyItems.Unsafe |> justifyItemsValue'
        static member Left = Types.Flex.JustifyItems.Left |> justifyItemsValue'
        static member Right = Types.Flex.JustifyItems.Right |> justifyItemsValue'
        static member SelfStart = Types.Flex.JustifyItems.SelfStart |> justifyItemsValue'
        static member SelfEnd = Types.Flex.JustifyItems.SelfEnd |> justifyItemsValue'
        static member Legacy = Types.Flex.JustifyItems.Legacy |> justifyItemsValue'

        static member Normal = Types.Normal |> justifyItemsValue'
        static member Inherit = Types.Inherit |> justifyItemsValue'
        static member Initial = Types.Initial |> justifyItemsValue'
        static member Unset = Types.Unset |> justifyItemsValue'

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
    let JustifyItems' (align: Types.IJustifyItems) = JustifyItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    let private justifySelfValue value = Types.propertyHelpers.cssValue Types.Property.JustifySelf value
    let private justifySelfValue' value =
        value
        |> justifySelfToString
        |> justifySelfValue
    type JustifySelf =
        static member Value (justification: Types.IJustifySelf) = justification |> justifySelfValue'
        static member Start = Types.Flex.JustifySelf.Start |> justifySelfValue'
        static member End = Types.Flex.JustifySelf.End |> justifySelfValue'
        static member FlexStart = Types.Flex.JustifySelf.FlexStart |> justifySelfValue'
        static member FlexEnd = Types.Flex.JustifySelf.FlexEnd |> justifySelfValue'
        static member Center = Types.Flex.JustifySelf.Center |> justifySelfValue'
        static member Baseline = Types.Flex.JustifySelf.Baseline |> justifySelfValue'
        static member FirstBaseline = Types.Flex.JustifySelf.FirstBaseline |> justifySelfValue'
        static member LastBaseline = Types.Flex.JustifySelf.LastBaseline |> justifySelfValue'
        static member Stretch = Types.Flex.JustifySelf.Stretch |> justifySelfValue'
        static member Safe = Types.Flex.JustifySelf.Safe |> justifySelfValue'
        static member Unsafe = Types.Flex.JustifySelf.Unsafe |> justifySelfValue'
        static member SelfStart = Types.Flex.JustifySelf.SelfStart |> justifySelfValue'
        static member SelfEnd = Types.Flex.JustifySelf.SelfEnd |> justifySelfValue'

        static member Normal = Types.Normal |> justifySelfValue'
        static member Inherit = Types.Inherit |> justifySelfValue'
        static member Initial = Types.Initial |> justifySelfValue'
        static member Unset = Types.Unset |> justifySelfValue'

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
    let JustifySelf' (align: Types.IJustifySelf) = JustifySelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    let private flexDirectionValue value = Types.propertyHelpers.cssValue Types.Property.FlexDirection value
    let private flexDirectionValue' value =
        value
        |> flexDirectionToString
        |> flexDirectionValue

    type FlexDirection =
        static member Value (direction: Types.IFlexDirection) = direction |> flexDirectionValue'
        static member Row = Types.Flex.Direction.Row |> flexDirectionValue'
        static member RowReverse = Types.Flex.Direction.RowReverse |> flexDirectionValue'
        static member Column = Types.Flex.Direction.Column |> flexDirectionValue'
        static member ColumnReverse = Types.Flex.Direction.ColumnReverse |> flexDirectionValue'

        static member Inherit = Types.Inherit |> flexDirectionValue'
        static member Initial = Types.Initial |> flexDirectionValue'
        static member Unset = Types.Unset |> flexDirectionValue'

    /// <summary>Specifies in which direction items in a flex container are oriented.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexDirection' (direction: Types.IFlexDirection) = FlexDirection.Value(direction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    let private flexWrapValue value = Types.propertyHelpers.cssValue Types.Property.FlexWrap value
    let private flexWrapValue' value =
        value
        |> flexWrapToString
        |> flexWrapValue
    type FlexWrap =
        static member Value (direction: Types.IFlexWrap) = direction |> flexWrapValue'
        static member NoWrap = Types.Flex.NoWrap |> flexWrapValue'
        static member Wrap = Types.Flex.Wrap |> flexWrapValue'
        static member WrapReverse = Types.Flex.WrapReverse |> flexWrapValue'

        static member Inherit = Types.Inherit |> flexWrapValue'
        static member Initial = Types.Initial |> flexWrapValue'
        static member Unset = Types.Unset |> flexWrapValue'

    /// <summary>Specifies if flex items can wrap onto multiple lines.</summary>
    /// <param name="wrap">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexWrap' (wrap: Types.IFlexWrap) = FlexWrap.Value(wrap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    let private orderValue value = Types.propertyHelpers.cssValue Types.Property.Order value
    let private orderValue' value =
        value
        |> orderToString
        |> orderValue
    type Order =
        static member Value (order: Types.IOrder) = order |> orderValue'

        static member Inherit = Types.Inherit |> orderValue'
        static member Initial = Types.Initial |> orderValue'
        static member Unset = Types.Unset |> orderValue'

    /// <summary>Specify order of items in flex.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Order' (order: Types.IOrder) = Order.Value(order)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    let private flexGrowValue value = Types.propertyHelpers.cssValue Types.Property.FlexGrow value
    let private flexGrowValue' value =
        value
        |> flexGrowToString
        |> flexGrowValue

    type FlexGrow =
        static member Value (grow: Types.IFlexGrow) = grow |> flexGrowValue'

        static member Inherit = Types.Inherit |> flexGrowValue'
        static member Initial = Types.Initial |> flexGrowValue'
        static member Unset = Types.Unset |> flexGrowValue'

    /// <summary>Sets grow factor of flex item.</summary>
    /// <param name="grow">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexGrow' (grow: Types.IFlexGrow) = FlexGrow.Value(grow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    let private flexShrinkValue value = Types.propertyHelpers.cssValue Types.Property.FlexShrink value
    let private flexShrinkValue' value =
        value
        |> flexShrinkToString
        |> flexShrinkValue

    type FlexShrink =
        static member Value (shrink: Types.IFlexShrink) = shrink |> flexShrinkValue'
        static member Inherit = Types.Inherit |> flexShrinkValue'
        static member Initial = Types.Initial |> flexShrinkValue'
        static member Unset =  Types.Unset |> flexShrinkValue'

    /// <summary>Sets shrink factor of flex item.</summary>
    /// <param name="shrink">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexShrink' (shrink: Types.IFlexShrink) = FlexShrink.Value(shrink)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    let private flexBasisValue value = Types.propertyHelpers.cssValue Types.Property.FlexBasis value
    let private flexBasisValue' value =
        value
        |> flexBasisToString
        |> flexBasisValue

    type FlexBasis =
        static member Value (basis: Types.IFlexBasis) = basis |> flexBasisValue'
        static member Fill = Types.Flex.Basis.Fill |> flexBasisValue'
        static member MaxContent = Types.Flex.Basis.MaxContent |> flexBasisValue'
        static member MinContent = Types.Flex.Basis.MinContent |> flexBasisValue'
        static member FitContent = Types.Flex.Basis.FitContent |> flexBasisValue'
        static member Content = Types.Flex.Basis.Content |> flexBasisValue'

        static member Auto = Types.Auto |> flexBasisValue'
        static member Inherit = Types.Inherit |> flexBasisValue'
        static member Initial = Types.Initial |> flexBasisValue'
        static member Unset = Types.Unset |> flexBasisValue'

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
    let FlexBasis' (basis: Types.IFlexBasis) = FlexBasis.Value(basis)
