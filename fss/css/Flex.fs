namespace Fss
open FssTypes

[<AutoOpen>]
module Flex =

    let private alignContentToString (alignment: IAlignContent) =
        match alignment with
        | :? AlignContent as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown align content"

    let private alignItemsToString (alignment: IAlignItems) =
        match alignment with
        | :? AlignItems as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown align items"

    let private alignSelfToString (alignment: IAlignSelf) =
        match alignment with
        | :? AlignSelf as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown align self"

    let private justifyContentToString (justification: IJustifyContent) =
        match justification with
        | :? JustifyContent as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown justify content"

    let private justifyItemsToString (justification: IJustifyItems) =
        match justification with
        | :? JustifyItems as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown justify items"

    let private justifySelfToString (justification: IJustifySelf) =
        match justification with
        | :? JustifySelf as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> normal
        | :? Global as g -> global' g
        | _ -> "Unknown justify self"

    let private flexDirectionToString (direction: IFlexDirection) =
        match direction with
        | :? FlexDirection as a -> Utilities.Helpers.duToKebab a
        | :? Global as g -> global' g
        | _ -> "Unknown flex direction"

    let private flexToString(flex: IFlex) =
        match flex with
        | :? Global as g -> global' g
        | :? Auto -> auto
        | :? None' -> none
        | _ -> "Unknown flex"

    let private flexWrapToString (direction: IFlexWrap) =
        match direction with
        | :? FlexWrap as a -> Utilities.Helpers.duToKebab a
        | :? Global as g -> global' g
        | _ -> "Unknown flex wrap"

    let private orderToString (order: IOrder) =
        match order with
        | :? CssInt as i -> cssIntToString i
        | :? Global as g -> global' g
        | _ -> "Unknown order"

    let private flexGrowToString (flexGrow: IFlexGrow) =
        match flexGrow with
        | :? CssFloat as f -> cssFloatToString f
        | :? Global as g -> global' g
        | _ -> "Unknown flex grow"

    let private flexShrinkToString (flexShrink: IFlexShrink) =
        match flexShrink with
        | :? CssFloat as f -> cssFloatToString f
        | :? Global as g -> global' g
        | _ -> "Unknown flex shrink"

    let private flexBasisToString (basis: IFlexBasis) =
        match basis with
        | :? FlexBasis as b -> Utilities.Helpers.duToKebab b
        | :? Auto -> auto
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> global' g
        | _ -> "Unknown flex basis"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    let private alignContentValue value = PropertyValue.cssValue Property.AlignContent value
    let private alignContentValue' value =
        value
        |> alignContentToString
        |> alignContentValue

    type AlignContent =
        static member Value (alignment: IAlignContent) = alignment |> alignContentValue'
        static member Start = FssTypes.AlignContent.Start |> alignContentValue'
        static member End = FssTypes.AlignContent.End |> alignContentValue'
        static member FlexStart = FssTypes.AlignContent.FlexStart |> alignContentValue'
        static member FlexEnd = FssTypes.AlignContent.FlexEnd |> alignContentValue'
        static member Center = FssTypes.AlignContent.Center |> alignContentValue'
        static member Baseline = FssTypes.AlignContent.Baseline |> alignContentValue'
        static member FirstBaseline = FssTypes.AlignContent.FirstBaseline |> alignContentValue'
        static member LastBaseline = FssTypes.AlignContent.LastBaseline |> alignContentValue'
        static member Stretch = FssTypes.AlignContent.Stretch |> alignContentValue'
        static member Safe = FssTypes.AlignContent.Safe |> alignContentValue'
        static member Unsafe = FssTypes.AlignContent.Unsafe |> alignContentValue'
        static member SpaceBetween = FssTypes.AlignContent.SpaceBetween |> alignContentValue'
        static member SpaceAround = FssTypes.AlignContent.SpaceAround |> alignContentValue'
        static member SpaceEvenly = FssTypes.AlignContent.SpaceEvenly |> alignContentValue'

        static member Normal = Normal |> alignContentValue'
        static member Inherit = Inherit |> alignContentValue'
        static member Initial = Initial |> alignContentValue'
        static member Unset = Unset |> alignContentValue'

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
    let AlignContent' (align: IAlignContent) = AlignContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    let private alignItemsValue value = PropertyValue.cssValue Property.AlignItems value
    let private alignItemsValue' value =
        value
        |> alignItemsToString
        |> alignItemsValue

    type AlignItems =
        static member Value (alignment: IAlignItems) = alignment |> alignItemsValue'
        static member Start = FssTypes.AlignItems.Start |> alignItemsValue'
        static member End = FssTypes.AlignItems.End |> alignItemsValue'
        static member FlexStart = FssTypes.AlignItems.FlexStart |> alignItemsValue'
        static member FlexEnd = FssTypes.AlignItems.FlexEnd |> alignItemsValue'
        static member Center = FssTypes.AlignItems.Center |> alignItemsValue'
        static member Baseline = FssTypes.AlignItems.Baseline |> alignItemsValue'
        static member FirstBaseline = FssTypes.AlignItems.FirstBaseline |> alignItemsValue'
        static member LastBaseline = FssTypes.AlignItems.LastBaseline |> alignItemsValue'
        static member Stretch = FssTypes.AlignItems.Stretch |> alignItemsValue'
        static member Safe = FssTypes.AlignItems.Safe |> alignItemsValue'
        static member Unsafe = FssTypes.AlignItems.Unsafe |> alignItemsValue'
        static member SelfStart = FssTypes.AlignItems.SelfStart |> alignItemsValue'
        static member SelfEnd = FssTypes.AlignItems.SelfEnd |> alignItemsValue'

        static member Normal = Normal |> alignItemsValue'
        static member Inherit = Inherit |> alignItemsValue'
        static member Initial = Initial |> alignItemsValue'
        static member Unset = Unset |> alignItemsValue'

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
    let AlignItems' (align: IAlignItems) = AlignItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    let private alignSelfValue value = PropertyValue.cssValue Property.AlignSelf value
    let private alignSelfValue' value =
        value
        |> alignSelfToString
        |> alignSelfValue

    type AlignSelf =
        static member Value (alignment: IAlignSelf) = alignment |> alignSelfValue'
        static member Start = FssTypes.AlignSelf.Start |> alignSelfValue'
        static member End = FssTypes.AlignSelf.End |> alignSelfValue'
        static member FlexStart = FssTypes.AlignSelf.FlexStart |> alignSelfValue'
        static member FlexEnd = FssTypes.AlignSelf.FlexEnd |> alignSelfValue'
        static member Center = FssTypes.AlignSelf.Center |> alignSelfValue'
        static member Baseline = FssTypes.AlignSelf.Baseline |> alignSelfValue'
        static member FirstBaseline = FssTypes.AlignSelf.FirstBaseline |> alignSelfValue'
        static member LastBaseline = FssTypes.AlignSelf.LastBaseline |> alignSelfValue'
        static member Stretch = FssTypes.AlignSelf.Stretch |> alignSelfValue'
        static member Safe = FssTypes.AlignSelf.Safe |> alignSelfValue'
        static member Unsafe = FssTypes.AlignSelf.Unsafe |> alignSelfValue'
        static member SelfStart = FssTypes.AlignSelf.SelfStart |> alignSelfValue'
        static member SelfEnd = FssTypes.AlignSelf.SelfEnd |> alignSelfValue'

        static member Normal = Normal |> alignSelfValue'
        static member Inherit = Inherit |> alignSelfValue'
        static member Initial = Initial |> alignSelfValue'
        static member Unset = Unset |> alignSelfValue'

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
    let AlignSelf' (align: IAlignSelf) = AlignSelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    let private justifyContentValue value = PropertyValue.cssValue Property.JustifyContent value
    let private justifyContentValue' value =
        value
        |> justifyContentToString
        |> justifyContentValue

    type JustifyContent =
        static member Value (justification: IJustifyContent) = justification |> justifyContentValue
        static member Start = FssTypes.JustifyContent.Start |> justifyContentValue'
        static member End = FssTypes.JustifyContent.End |> justifyContentValue'
        static member FlexStart = FssTypes.JustifyContent.FlexStart |> justifyContentValue'
        static member FlexEnd = FssTypes.JustifyContent.FlexEnd |> justifyContentValue'
        static member Center = FssTypes.JustifyContent.Center |> justifyContentValue'
        static member Baseline = FssTypes.JustifyContent.Baseline |> justifyContentValue'
        static member FirstBaseline = FssTypes.JustifyContent.FirstBaseline |> justifyContentValue'
        static member LastBaseline = FssTypes.JustifyContent.LastBaseline |> justifyContentValue'
        static member Stretch = FssTypes.JustifyContent.Stretch |> justifyContentValue'
        static member Safe = FssTypes.JustifyContent.Safe |> justifyContentValue'
        static member Unsafe = FssTypes.JustifyContent.Unsafe |> justifyContentValue'
        static member Left = FssTypes.JustifyContent.Left |> justifyContentValue'
        static member Right = FssTypes.JustifyContent.Right |> justifyContentValue'
        static member SpaceBetween = FssTypes.JustifyContent.SpaceBetween |> justifyContentValue'
        static member SpaceAround = FssTypes.JustifyContent.SpaceAround |> justifyContentValue'
        static member SpaceEvenly = FssTypes.JustifyContent.SpaceEvenly |> justifyContentValue'

        static member Normal = Normal |> justifyContentValue'
        static member Inherit = Inherit |> justifyContentValue'
        static member Initial = Initial |> justifyContentValue'
        static member Unset = Unset |> justifyContentValue'

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
    let JustifyContent' (align: IJustifyContent) = JustifyContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    let private justifyItemsValue value = PropertyValue.cssValue Property.JustifyItems value
    let private justifyItemsValue' value =
        value
        |> justifyItemsToString
        |> justifyItemsValue

    type JustifyItems =
        static member Value (justification: IJustifyItems) = justification |> justifyItemsValue'
        static member Start = FssTypes.JustifyItems.Start |> justifyItemsValue'
        static member End = FssTypes.JustifyItems.End |> justifyItemsValue'
        static member FlexStart = FssTypes.JustifyItems.FlexStart |> justifyItemsValue'
        static member FlexEnd = FssTypes.JustifyItems.FlexEnd |> justifyItemsValue'
        static member Center = FssTypes.JustifyItems.Center |> justifyItemsValue'
        static member Baseline = FssTypes.JustifyItems.Baseline |> justifyItemsValue'
        static member FirstBaseline = FssTypes.JustifyItems.FirstBaseline |> justifyItemsValue'
        static member LastBaseline = FssTypes.JustifyItems.LastBaseline |> justifyItemsValue'
        static member Stretch = FssTypes.JustifyItems.Stretch |> justifyItemsValue'
        static member Safe = FssTypes.JustifyItems.Safe |> justifyItemsValue'
        static member Unsafe = FssTypes.JustifyItems.Unsafe |> justifyItemsValue'
        static member Left = FssTypes.JustifyItems.Left |> justifyItemsValue'
        static member Right = FssTypes.JustifyItems.Right |> justifyItemsValue'
        static member SelfStart = FssTypes.JustifyItems.SelfStart |> justifyItemsValue'
        static member SelfEnd = FssTypes.JustifyItems.SelfEnd |> justifyItemsValue'
        static member Legacy = FssTypes.JustifyItems.Legacy |> justifyItemsValue'

        static member Normal = Normal |> justifyItemsValue'
        static member Inherit = Inherit |> justifyItemsValue'
        static member Initial = Initial |> justifyItemsValue'
        static member Unset = Unset |> justifyItemsValue'

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
    let JustifyItems' (align: IJustifyItems) = JustifyItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    let private justifySelfValue value = PropertyValue.cssValue Property.JustifySelf value
    let private justifySelfValue' value =
        value
        |> justifySelfToString
        |> justifySelfValue
    type JustifySelf =
        static member Value (justification: IJustifySelf) = justification |> justifySelfValue'
        static member Start = FssTypes.JustifySelf.Start |> justifySelfValue'
        static member End = FssTypes.JustifySelf.End |> justifySelfValue'
        static member FlexStart = FssTypes.JustifySelf.FlexStart |> justifySelfValue'
        static member FlexEnd = FssTypes.JustifySelf.FlexEnd |> justifySelfValue'
        static member Center = FssTypes.JustifySelf.Center |> justifySelfValue'
        static member Baseline = FssTypes.JustifySelf.Baseline |> justifySelfValue'
        static member FirstBaseline = FssTypes.JustifySelf.FirstBaseline |> justifySelfValue'
        static member LastBaseline = FssTypes.JustifySelf.LastBaseline |> justifySelfValue'
        static member Stretch = FssTypes.JustifySelf.Stretch |> justifySelfValue'
        static member Safe = FssTypes.JustifySelf.Safe |> justifySelfValue'
        static member Unsafe = FssTypes.JustifySelf.Unsafe |> justifySelfValue'
        static member SelfStart = FssTypes.JustifySelf.SelfStart |> justifySelfValue'
        static member SelfEnd = FssTypes.JustifySelf.SelfEnd |> justifySelfValue'

        static member Normal = Normal |> justifySelfValue'
        static member Inherit = Inherit |> justifySelfValue'
        static member Initial = Initial |> justifySelfValue'
        static member Unset = Unset |> justifySelfValue'

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
    let JustifySelf' (align: IJustifySelf) = JustifySelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    let private flexDirectionValue value = PropertyValue.cssValue Property.FlexDirection value
    let private flexDirectionValue' value =
        value
        |> flexDirectionToString
        |> flexDirectionValue

    type FlexDirection =
        static member Value (direction: IFlexDirection) = direction |> flexDirectionValue'
        static member Row = FssTypes.FlexDirection.Row |> flexDirectionValue'
        static member RowReverse = FssTypes.FlexDirection.RowReverse |> flexDirectionValue'
        static member Column = FssTypes.FlexDirection.Column |> flexDirectionValue'
        static member ColumnReverse = FssTypes.FlexDirection.ColumnReverse |> flexDirectionValue'

        static member Inherit = Inherit |> flexDirectionValue'
        static member Initial = Initial |> flexDirectionValue'
        static member Unset = Unset |> flexDirectionValue'

    /// <summary>Specifies in which direction items in a flex container are oriented.</summary>
    /// <param name="direction">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexDirection' (direction: IFlexDirection) = FlexDirection.Value(direction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    let private flexWrapValue value = PropertyValue.cssValue Property.FlexWrap value
    let private flexWrapValue' value =
        value
        |> flexWrapToString
        |> flexWrapValue
    type FlexWrap =
        static member Value (direction: IFlexWrap) = direction |> flexWrapValue'
        static member NoWrap = FssTypes.FlexWrap.NoWrap |> flexWrapValue'
        static member Wrap = FssTypes.FlexWrap.Wrap |> flexWrapValue'
        static member WrapReverse = FssTypes.FlexWrap.WrapReverse |> flexWrapValue'

        static member Inherit = Inherit |> flexWrapValue'
        static member Initial = Initial |> flexWrapValue'
        static member Unset = Unset |> flexWrapValue'

    /// <summary>Specifies if flex items can wrap onto multiple lines.</summary>
    /// <param name="wrap">
    ///     can be:
    ///     - <c> FlexDirection </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexWrap' (wrap: IFlexWrap) = FlexWrap.Value(wrap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    let private orderValue value = PropertyValue.cssValue Property.Order value
    let private orderValue' value =
        value
        |> orderToString
        |> orderValue
    type Order =
        static member Value (order: IOrder) = order |> orderValue'

        static member Inherit = Inherit |> orderValue'
        static member Initial = Initial |> orderValue'
        static member Unset = Unset |> orderValue'

    /// <summary>Specify order of items in flex.</summary>
    /// <param name="order">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Order' (order: IOrder) = Order.Value(order)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    let private flexGrowValue value = PropertyValue.cssValue Property.FlexGrow value
    let private flexGrowValue' value =
        value
        |> flexGrowToString
        |> flexGrowValue

    type FlexGrow =
        static member Value (grow: IFlexGrow) = grow |> flexGrowValue'

        static member Inherit = Inherit |> flexGrowValue'
        static member Initial = Initial |> flexGrowValue'
        static member Unset = Unset |> flexGrowValue'

    /// <summary>Sets grow factor of flex item.</summary>
    /// <param name="grow">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexGrow' (grow: IFlexGrow) = FlexGrow.Value(grow)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    let private flexShrinkValue value = PropertyValue.cssValue Property.FlexShrink value
    let private flexShrinkValue' value =
        value
        |> flexShrinkToString
        |> flexShrinkValue

    type FlexShrink =
        static member Value (shrink: IFlexShrink) = shrink |> flexShrinkValue'
        static member Inherit = Inherit |> flexShrinkValue'
        static member Initial = Initial |> flexShrinkValue'
        static member Unset =  Unset |> flexShrinkValue'

    /// <summary>Sets shrink factor of flex item.</summary>
    /// <param name="shrink">
    ///     can be:
    ///     - <c> CssFloat </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let FlexShrink' (shrink: IFlexShrink) = FlexShrink.Value(shrink)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    let private flexBasisValue value = PropertyValue.cssValue Property.FlexBasis value
    let private flexBasisValue' value =
        value
        |> flexBasisToString
        |> flexBasisValue

    type FlexBasis =
        static member Value (basis: IFlexBasis) = basis |> flexBasisValue'
        static member Fill = FssTypes.FlexBasis.Fill |> flexBasisValue'
        static member MaxContent = FssTypes.FlexBasis.MaxContent |> flexBasisValue'
        static member MinContent = FssTypes.FlexBasis.MinContent |> flexBasisValue'
        static member FitContent = FssTypes.FlexBasis.FitContent |> flexBasisValue'
        static member Content = FssTypes.FlexBasis.Content |> flexBasisValue'

        static member Auto = Auto |> flexBasisValue'
        static member Inherit = Inherit |> flexBasisValue'
        static member Initial = Initial |> flexBasisValue'
        static member Unset = Unset |> flexBasisValue'

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
    let FlexBasis' (basis: IFlexBasis) = FlexBasis.Value(basis)
