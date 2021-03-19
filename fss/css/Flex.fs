namespace Fss
open FssTypes

[<AutoOpen>]
module Flex =

    let private alignContentToString (alignment: IAlignContent) =
        match alignment with
        | :? Flex.AlignContent as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown align content"

    let private alignItemsToString (alignment: IAlignItems) =
        match alignment with
        | :? Flex.AlignItems as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown align items"

    let private alignSelfToString (alignment: IAlignSelf) =
        match alignment with
        | :? Flex.AlignSelf as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown align self"

    let private justifyContentToString (justification: IJustifyContent) =
        match justification with
        | :? Flex.JustifyContent as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown justify content"

    let private justifyItemsToString (justification: IJustifyItems) =
        match justification with
        | :? Flex.JustifyItems as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown justify items"

    let private justifySelfToString (justification: IJustifySelf) =
        match justification with
        | :? Flex.JustifySelf as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown justify self"

    let private flexDirectionToString (direction: IFlexDirection) =
        match direction with
        | :? Flex.FlexDirection as a -> Utilities.Helpers.duToKebab a
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown flex direction"

    let private flexToString(flex: IFlex) =
        match flex with
        | :? Global as g -> GlobalValue.global' g
        | :? Auto -> GlobalValue.auto
        | :? None' -> GlobalValue.none
        | _ -> "Unknown flex"

    let private flexWrapToString (direction: IFlexWrap) =
        match direction with
        | :? Flex.FlexWrap as a -> Utilities.Helpers.duToKebab a
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown flex wrap"

    let private orderToString (order: IOrder) =
        match order with
        | :? CssInt as i -> GlobalValue.int i
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown order"

    let private flexGrowToString (flexGrow: IFlexGrow) =
        match flexGrow with
        | :? Global.CssFloat as f -> GlobalValue.float f
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown flex grow"

    let private flexShrinkToString (flexShrink: IFlexShrink) =
        match flexShrink with
        | :? Global.CssFloat as f -> GlobalValue.float f
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown flex shrink"

    let private flexBasisToString (basis: IFlexBasis) =
        match basis with
        | :? Flex.FlexBasis as b -> Utilities.Helpers.duToKebab b
        | :? Auto -> GlobalValue.auto
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown flex basis"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    let private alignContentValue value = PropertyValue.cssValue Property.AlignContent value
    let private alignContentValue' value =
        value
        |> alignContentToString
        |> alignContentValue

    type AlignContent =
        static member Value (alignment: IAlignContent) = alignment |> alignContentValue'
        static member Start = Flex.AlignContent.Start |> alignContentValue'
        static member End = Flex.AlignContent.End |> alignContentValue'
        static member FlexStart = Flex.AlignContent.FlexStart |> alignContentValue'
        static member FlexEnd = Flex.AlignContent.FlexEnd |> alignContentValue'
        static member Center = Flex.AlignContent.Center |> alignContentValue'
        static member Baseline = Flex.AlignContent.Baseline |> alignContentValue'
        static member FirstBaseline = Flex.AlignContent.FirstBaseline |> alignContentValue'
        static member LastBaseline = Flex.AlignContent.LastBaseline |> alignContentValue'
        static member Stretch = Flex.AlignContent.Stretch |> alignContentValue'
        static member Safe = Flex.AlignContent.Safe |> alignContentValue'
        static member Unsafe = Flex.AlignContent.Unsafe |> alignContentValue'
        static member SpaceBetween = Flex.AlignContent.SpaceBetween |> alignContentValue'
        static member SpaceAround = Flex.AlignContent.SpaceAround |> alignContentValue'
        static member SpaceEvenly = Flex.AlignContent.SpaceEvenly |> alignContentValue'

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
        static member Start = Flex.AlignItems.Start |> alignItemsValue'
        static member End = Flex.AlignItems.End |> alignItemsValue'
        static member FlexStart = Flex.AlignItems.FlexStart |> alignItemsValue'
        static member FlexEnd = Flex.AlignItems.FlexEnd |> alignItemsValue'
        static member Center = Flex.AlignItems.Center |> alignItemsValue'
        static member Baseline = Flex.AlignItems.Baseline |> alignItemsValue'
        static member FirstBaseline = Flex.AlignItems.FirstBaseline |> alignItemsValue'
        static member LastBaseline = Flex.AlignItems.LastBaseline |> alignItemsValue'
        static member Stretch = Flex.AlignItems.Stretch |> alignItemsValue'
        static member Safe = Flex.AlignItems.Safe |> alignItemsValue'
        static member Unsafe = Flex.AlignItems.Unsafe |> alignItemsValue'
        static member SelfStart = Flex.AlignItems.SelfStart |> alignItemsValue'
        static member SelfEnd = Flex.AlignItems.SelfEnd |> alignItemsValue'

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
        static member Start = Flex.AlignSelf.Start |> alignSelfValue'
        static member End = Flex.AlignSelf.End |> alignSelfValue'
        static member FlexStart = Flex.AlignSelf.FlexStart |> alignSelfValue'
        static member FlexEnd = Flex.AlignSelf.FlexEnd |> alignSelfValue'
        static member Center = Flex.AlignSelf.Center |> alignSelfValue'
        static member Baseline = Flex.AlignSelf.Baseline |> alignSelfValue'
        static member FirstBaseline = Flex.AlignSelf.FirstBaseline |> alignSelfValue'
        static member LastBaseline = Flex.AlignSelf.LastBaseline |> alignSelfValue'
        static member Stretch = Flex.AlignSelf.Stretch |> alignSelfValue'
        static member Safe = Flex.AlignSelf.Safe |> alignSelfValue'
        static member Unsafe = Flex.AlignSelf.Unsafe |> alignSelfValue'
        static member SelfStart = Flex.AlignSelf.SelfStart |> alignSelfValue'
        static member SelfEnd = Flex.AlignSelf.SelfEnd |> alignSelfValue'

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
        static member Start = Flex.JustifyContent.Start |> justifyContentValue'
        static member End = Flex.JustifyContent.End |> justifyContentValue'
        static member FlexStart = Flex.JustifyContent.FlexStart |> justifyContentValue'
        static member FlexEnd = Flex.JustifyContent.FlexEnd |> justifyContentValue'
        static member Center = Flex.JustifyContent.Center |> justifyContentValue'
        static member Baseline = Flex.JustifyContent.Baseline |> justifyContentValue'
        static member FirstBaseline = Flex.JustifyContent.FirstBaseline |> justifyContentValue'
        static member LastBaseline = Flex.JustifyContent.LastBaseline |> justifyContentValue'
        static member Stretch = Flex.JustifyContent.Stretch |> justifyContentValue'
        static member Safe = Flex.JustifyContent.Safe |> justifyContentValue'
        static member Unsafe = Flex.JustifyContent.Unsafe |> justifyContentValue'
        static member Left = Flex.JustifyContent.Left |> justifyContentValue'
        static member Right = Flex.JustifyContent.Right |> justifyContentValue'
        static member SpaceBetween = Flex.JustifyContent.SpaceBetween |> justifyContentValue'
        static member SpaceAround = Flex.JustifyContent.SpaceAround |> justifyContentValue'
        static member SpaceEvenly = Flex.JustifyContent.SpaceEvenly |> justifyContentValue'

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
        static member Start = Flex.JustifyItems.Start |> justifyItemsValue'
        static member End = Flex.JustifyItems.End |> justifyItemsValue'
        static member FlexStart = Flex.JustifyItems.FlexStart |> justifyItemsValue'
        static member FlexEnd = Flex.JustifyItems.FlexEnd |> justifyItemsValue'
        static member Center = Flex.JustifyItems.Center |> justifyItemsValue'
        static member Baseline = Flex.JustifyItems.Baseline |> justifyItemsValue'
        static member FirstBaseline = Flex.JustifyItems.FirstBaseline |> justifyItemsValue'
        static member LastBaseline = Flex.JustifyItems.LastBaseline |> justifyItemsValue'
        static member Stretch = Flex.JustifyItems.Stretch |> justifyItemsValue'
        static member Safe = Flex.JustifyItems.Safe |> justifyItemsValue'
        static member Unsafe = Flex.JustifyItems.Unsafe |> justifyItemsValue'
        static member Left = Flex.JustifyItems.Left |> justifyItemsValue'
        static member Right = Flex.JustifyItems.Right |> justifyItemsValue'
        static member SelfStart = Flex.JustifyItems.SelfStart |> justifyItemsValue'
        static member SelfEnd = Flex.JustifyItems.SelfEnd |> justifyItemsValue'
        static member Legacy = Flex.JustifyItems.Legacy |> justifyItemsValue'

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
        static member Start = Flex.JustifySelf.Start |> justifySelfValue'
        static member End = Flex.JustifySelf.End |> justifySelfValue'
        static member FlexStart = Flex.JustifySelf.FlexStart |> justifySelfValue'
        static member FlexEnd = Flex.JustifySelf.FlexEnd |> justifySelfValue'
        static member Center = Flex.JustifySelf.Center |> justifySelfValue'
        static member Baseline = Flex.JustifySelf.Baseline |> justifySelfValue'
        static member FirstBaseline = Flex.JustifySelf.FirstBaseline |> justifySelfValue'
        static member LastBaseline = Flex.JustifySelf.LastBaseline |> justifySelfValue'
        static member Stretch = Flex.JustifySelf.Stretch |> justifySelfValue'
        static member Safe = Flex.JustifySelf.Safe |> justifySelfValue'
        static member Unsafe = Flex.JustifySelf.Unsafe |> justifySelfValue'
        static member SelfStart = Flex.JustifySelf.SelfStart |> justifySelfValue'
        static member SelfEnd = Flex.JustifySelf.SelfEnd |> justifySelfValue'

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
        static member Row = Flex.Row |> flexDirectionValue'
        static member RowReverse = Flex.RowReverse |> flexDirectionValue'
        static member Column = Flex.Column |> flexDirectionValue'
        static member ColumnReverse = Flex.ColumnReverse |> flexDirectionValue'

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
        static member NoWrap = Flex.NoWrap |> flexWrapValue'
        static member Wrap = Flex.Wrap |> flexWrapValue'
        static member WrapReverse = Flex.WrapReverse |> flexWrapValue'

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
        static member Fill = Flex.Fill |> flexBasisValue'
        static member MaxContent = Flex.MaxContent |> flexBasisValue'
        static member MinContent = Flex.MinContent |> flexBasisValue'
        static member FitContent = Flex.FitContent |> flexBasisValue'
        static member Content = Flex.Content |> flexBasisValue'

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
