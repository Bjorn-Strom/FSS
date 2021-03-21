namespace Fss

[<AutoOpen>]
module Flex =

    let private alignContentToString (alignment: Types.IAlignContent) =
        match alignment with
        | :? Types.AlignContent as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align content"

    let private alignItemsToString (alignment: Types.IAlignItems) =
        match alignment with
        | :? Types.AlignItems as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align items"

    let private alignSelfToString (alignment: Types.IAlignSelf) =
        match alignment with
        | :? Types.AlignSelf as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown align self"

    let private justifyContentToString (justification: Types.IJustifyContent) =
        match justification with
        | :? Types.JustifyContent as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify content"

    let private justifyItemsToString (justification: Types.IJustifyItems) =
        match justification with
        | :? Types.JustifyItems as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify items"

    let private justifySelfToString (justification: Types.IJustifySelf) =
        match justification with
        | :? Types.JustifySelf as a -> Utilities.Helpers.duToKebab a
        | :? Types.Normal -> Types.masterTypeHelpers.normal
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown justify self"

    let private flexDirectionToString (direction: Types.IFlexDirection) =
        match direction with
        | :? Types.FlexDirection as a -> Utilities.Helpers.duToKebab a
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
        | :? Types.FlexWrap as a -> Utilities.Helpers.duToKebab a
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
        | :? Types.FlexBasis as b -> Utilities.Helpers.duToKebab b
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
        static member Start = Types.AlignContent.Start |> alignContentValue'
        static member End = Types.AlignContent.End |> alignContentValue'
        static member FlexStart = Types.AlignContent.FlexStart |> alignContentValue'
        static member FlexEnd = Types.AlignContent.FlexEnd |> alignContentValue'
        static member Center = Types.AlignContent.Center |> alignContentValue'
        static member Baseline = Types.AlignContent.Baseline |> alignContentValue'
        static member FirstBaseline = Types.AlignContent.FirstBaseline |> alignContentValue'
        static member LastBaseline = Types.AlignContent.LastBaseline |> alignContentValue'
        static member Stretch = Types.AlignContent.Stretch |> alignContentValue'
        static member Safe = Types.AlignContent.Safe |> alignContentValue'
        static member Unsafe = Types.AlignContent.Unsafe |> alignContentValue'
        static member SpaceBetween = Types.AlignContent.SpaceBetween |> alignContentValue'
        static member SpaceAround = Types.AlignContent.SpaceAround |> alignContentValue'
        static member SpaceEvenly = Types.AlignContent.SpaceEvenly |> alignContentValue'

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
        static member Start = Types.AlignItems.Start |> alignItemsValue'
        static member End = Types.AlignItems.End |> alignItemsValue'
        static member FlexStart = Types.AlignItems.FlexStart |> alignItemsValue'
        static member FlexEnd = Types.AlignItems.FlexEnd |> alignItemsValue'
        static member Center = Types.AlignItems.Center |> alignItemsValue'
        static member Baseline = Types.AlignItems.Baseline |> alignItemsValue'
        static member FirstBaseline = Types.AlignItems.FirstBaseline |> alignItemsValue'
        static member LastBaseline = Types.AlignItems.LastBaseline |> alignItemsValue'
        static member Stretch = Types.AlignItems.Stretch |> alignItemsValue'
        static member Safe = Types.AlignItems.Safe |> alignItemsValue'
        static member Unsafe = Types.AlignItems.Unsafe |> alignItemsValue'
        static member SelfStart = Types.AlignItems.SelfStart |> alignItemsValue'
        static member SelfEnd = Types.AlignItems.SelfEnd |> alignItemsValue'

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
        static member Start = Types.AlignSelf.Start |> alignSelfValue'
        static member End = Types.AlignSelf.End |> alignSelfValue'
        static member FlexStart = Types.AlignSelf.FlexStart |> alignSelfValue'
        static member FlexEnd = Types.AlignSelf.FlexEnd |> alignSelfValue'
        static member Center = Types.AlignSelf.Center |> alignSelfValue'
        static member Baseline = Types.AlignSelf.Baseline |> alignSelfValue'
        static member FirstBaseline = Types.AlignSelf.FirstBaseline |> alignSelfValue'
        static member LastBaseline = Types.AlignSelf.LastBaseline |> alignSelfValue'
        static member Stretch = Types.AlignSelf.Stretch |> alignSelfValue'
        static member Safe = Types.AlignSelf.Safe |> alignSelfValue'
        static member Unsafe = Types.AlignSelf.Unsafe |> alignSelfValue'
        static member SelfStart = Types.AlignSelf.SelfStart |> alignSelfValue'
        static member SelfEnd = Types.AlignSelf.SelfEnd |> alignSelfValue'

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
        static member Start = Types.JustifyContent.Start |> justifyContentValue'
        static member End = Types.JustifyContent.End |> justifyContentValue'
        static member FlexStart = Types.JustifyContent.FlexStart |> justifyContentValue'
        static member FlexEnd = Types.JustifyContent.FlexEnd |> justifyContentValue'
        static member Center = Types.JustifyContent.Center |> justifyContentValue'
        static member Baseline = Types.JustifyContent.Baseline |> justifyContentValue'
        static member FirstBaseline = Types.JustifyContent.FirstBaseline |> justifyContentValue'
        static member LastBaseline = Types.JustifyContent.LastBaseline |> justifyContentValue'
        static member Stretch = Types.JustifyContent.Stretch |> justifyContentValue'
        static member Safe = Types.JustifyContent.Safe |> justifyContentValue'
        static member Unsafe = Types.JustifyContent.Unsafe |> justifyContentValue'
        static member Left = Types.JustifyContent.Left |> justifyContentValue'
        static member Right = Types.JustifyContent.Right |> justifyContentValue'
        static member SpaceBetween = Types.JustifyContent.SpaceBetween |> justifyContentValue'
        static member SpaceAround = Types.JustifyContent.SpaceAround |> justifyContentValue'
        static member SpaceEvenly = Types.JustifyContent.SpaceEvenly |> justifyContentValue'

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
        static member Start = Types.JustifyItems.Start |> justifyItemsValue'
        static member End = Types.JustifyItems.End |> justifyItemsValue'
        static member FlexStart = Types.JustifyItems.FlexStart |> justifyItemsValue'
        static member FlexEnd = Types.JustifyItems.FlexEnd |> justifyItemsValue'
        static member Center = Types.JustifyItems.Center |> justifyItemsValue'
        static member Baseline = Types.JustifyItems.Baseline |> justifyItemsValue'
        static member FirstBaseline = Types.JustifyItems.FirstBaseline |> justifyItemsValue'
        static member LastBaseline = Types.JustifyItems.LastBaseline |> justifyItemsValue'
        static member Stretch = Types.JustifyItems.Stretch |> justifyItemsValue'
        static member Safe = Types.JustifyItems.Safe |> justifyItemsValue'
        static member Unsafe = Types.JustifyItems.Unsafe |> justifyItemsValue'
        static member Left = Types.JustifyItems.Left |> justifyItemsValue'
        static member Right = Types.JustifyItems.Right |> justifyItemsValue'
        static member SelfStart = Types.JustifyItems.SelfStart |> justifyItemsValue'
        static member SelfEnd = Types.JustifyItems.SelfEnd |> justifyItemsValue'
        static member Legacy = Types.JustifyItems.Legacy |> justifyItemsValue'

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
        static member Start = Types.JustifySelf.Start |> justifySelfValue'
        static member End = Types.JustifySelf.End |> justifySelfValue'
        static member FlexStart = Types.JustifySelf.FlexStart |> justifySelfValue'
        static member FlexEnd = Types.JustifySelf.FlexEnd |> justifySelfValue'
        static member Center = Types.JustifySelf.Center |> justifySelfValue'
        static member Baseline = Types.JustifySelf.Baseline |> justifySelfValue'
        static member FirstBaseline = Types.JustifySelf.FirstBaseline |> justifySelfValue'
        static member LastBaseline = Types.JustifySelf.LastBaseline |> justifySelfValue'
        static member Stretch = Types.JustifySelf.Stretch |> justifySelfValue'
        static member Safe = Types.JustifySelf.Safe |> justifySelfValue'
        static member Unsafe = Types.JustifySelf.Unsafe |> justifySelfValue'
        static member SelfStart = Types.JustifySelf.SelfStart |> justifySelfValue'
        static member SelfEnd = Types.JustifySelf.SelfEnd |> justifySelfValue'

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
        static member Row = Types.FlexDirection.Row |> flexDirectionValue'
        static member RowReverse = Types.FlexDirection.RowReverse |> flexDirectionValue'
        static member Column = Types.FlexDirection.Column |> flexDirectionValue'
        static member ColumnReverse = Types.FlexDirection.ColumnReverse |> flexDirectionValue'

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
        static member NoWrap = Types.FlexWrap.NoWrap |> flexWrapValue'
        static member Wrap = Types.FlexWrap.Wrap |> flexWrapValue'
        static member WrapReverse = Types.FlexWrap.WrapReverse |> flexWrapValue'

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
        static member Fill = Types.FlexBasis.Fill |> flexBasisValue'
        static member MaxContent = Types.FlexBasis.MaxContent |> flexBasisValue'
        static member MinContent = Types.FlexBasis.MinContent |> flexBasisValue'
        static member FitContent = Types.FlexBasis.FitContent |> flexBasisValue'
        static member Content = Types.FlexBasis.Content |> flexBasisValue'

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
