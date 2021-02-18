namespace Fss

[<RequireQualifiedAccess>]
module FlexType =
    type AlignContent =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly
        interface IAlignContent

    type AlignItems =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SelfStart
        | SelfEnd
        interface IAlignItems

    type AlignSelf =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SelfStart
        | SelfEnd
        interface IAlignSelf

    type JustifyContent =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly
        | Left
        | Right
        interface IJustifyContent

    type JustifyItems =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | Left
        | Right
        | SelfStart
        | SelfEnd
        | Legacy
        interface IJustifyItems

    type JustifySelf =
        | Start
        | End
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | FirstBaseline
        | LastBaseline
        | Stretch
        | Safe
        | Unsafe
        | SelfStart
        | SelfEnd
        interface IJustifySelf

    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexWrap

    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface IFlexDirection

    type FlexBasis =
        | Fill
        | MaxContent
        | MinContent
        | FitContent
        | Content
        interface IFlexBasis

[<AutoOpen>]
module Flex =

    let private alignContentToString (alignment: IAlignContent) =
        match alignment with
        | :? FlexType.AlignContent as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown align content"

    let private alignItemsToString (alignment: IAlignItems) =
        match alignment with
        | :? FlexType.AlignItems as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown align items"

    let private alignSelfToString (alignment: IAlignSelf) =
        match alignment with
        | :? FlexType.AlignSelf as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown align self"

    let private justifyContentToString (justification: IJustifyContent) =
        match justification with
        | :? FlexType.JustifyContent as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown justify content"

    let private justifyItemsToString (justification: IJustifyItems) =
        match justification with
        | :? FlexType.JustifyItems as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown justify items"

    let private justifySelfToString (justification: IJustifySelf) =
        match justification with
        | :? FlexType.JustifySelf as a -> Utilities.Helpers.duToKebab a
        | :? Normal -> GlobalValue.normal
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown justify self"

    let private flexDirectionToString (direction: IFlexDirection) =
        match direction with
        | :? FlexType.FlexDirection as a -> Utilities.Helpers.duToKebab a
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
        | :? FlexType.FlexWrap as a -> Utilities.Helpers.duToKebab a
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
        | :? FlexType.FlexBasis as b -> Utilities.Helpers.duToKebab b
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
        static member Start = FlexType.AlignContent.Start |> alignContentValue'
        static member End = FlexType.AlignContent.End |> alignContentValue'
        static member FlexStart = FlexType.AlignContent.FlexStart |> alignContentValue'
        static member FlexEnd = FlexType.AlignContent.FlexEnd |> alignContentValue'
        static member Center = FlexType.AlignContent.Center |> alignContentValue'
        static member Baseline = FlexType.AlignContent.Baseline |> alignContentValue'
        static member FirstBaseline = FlexType.AlignContent.FirstBaseline |> alignContentValue'
        static member LastBaseline = FlexType.AlignContent.LastBaseline |> alignContentValue'
        static member Stretch = FlexType.AlignContent.Stretch |> alignContentValue'
        static member Safe = FlexType.AlignContent.Safe |> alignContentValue'
        static member Unsafe = FlexType.AlignContent.Unsafe |> alignContentValue'
        static member SpaceBetween = FlexType.AlignContent.SpaceBetween |> alignContentValue'
        static member SpaceAround = FlexType.AlignContent.SpaceAround |> alignContentValue'
        static member SpaceEvenly = FlexType.AlignContent.SpaceEvenly |> alignContentValue'

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
        static member Start = FlexType.AlignItems.Start |> alignItemsValue'
        static member End = FlexType.AlignItems.End |> alignItemsValue'
        static member FlexStart = FlexType.AlignItems.FlexStart |> alignItemsValue'
        static member FlexEnd = FlexType.AlignItems.FlexEnd |> alignItemsValue'
        static member Center = FlexType.AlignItems.Center |> alignItemsValue'
        static member Baseline = FlexType.AlignItems.Baseline |> alignItemsValue'
        static member FirstBaseline = FlexType.AlignItems.FirstBaseline |> alignItemsValue'
        static member LastBaseline = FlexType.AlignItems.LastBaseline |> alignItemsValue'
        static member Stretch = FlexType.AlignItems.Stretch |> alignItemsValue'
        static member Safe = FlexType.AlignItems.Safe |> alignItemsValue'
        static member Unsafe = FlexType.AlignItems.Unsafe |> alignItemsValue'
        static member SelfStart = FlexType.AlignItems.SelfStart |> alignItemsValue'
        static member SelfEnd = FlexType.AlignItems.SelfEnd |> alignItemsValue'

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
        static member Start = FlexType.AlignSelf.Start |> alignSelfValue'
        static member End = FlexType.AlignSelf.End |> alignSelfValue'
        static member FlexStart = FlexType.AlignSelf.FlexStart |> alignSelfValue'
        static member FlexEnd = FlexType.AlignSelf.FlexEnd |> alignSelfValue'
        static member Center = FlexType.AlignSelf.Center |> alignSelfValue'
        static member Baseline = FlexType.AlignSelf.Baseline |> alignSelfValue'
        static member FirstBaseline = FlexType.AlignSelf.FirstBaseline |> alignSelfValue'
        static member LastBaseline = FlexType.AlignSelf.LastBaseline |> alignSelfValue'
        static member Stretch = FlexType.AlignSelf.Stretch |> alignSelfValue'
        static member Safe = FlexType.AlignSelf.Safe |> alignSelfValue'
        static member Unsafe = FlexType.AlignSelf.Unsafe |> alignSelfValue'
        static member SelfStart = FlexType.AlignSelf.SelfStart |> alignSelfValue'
        static member SelfEnd = FlexType.AlignSelf.SelfEnd |> alignSelfValue'

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
        static member Start = FlexType.JustifyContent.Start |> justifyContentValue'
        static member End = FlexType.JustifyContent.End |> justifyContentValue'
        static member FlexStart = FlexType.JustifyContent.FlexStart |> justifyContentValue'
        static member FlexEnd = FlexType.JustifyContent.FlexEnd |> justifyContentValue'
        static member Center = FlexType.JustifyContent.Center |> justifyContentValue'
        static member Baseline = FlexType.JustifyContent.Baseline |> justifyContentValue'
        static member FirstBaseline = FlexType.JustifyContent.FirstBaseline |> justifyContentValue'
        static member LastBaseline = FlexType.JustifyContent.LastBaseline |> justifyContentValue'
        static member Stretch = FlexType.JustifyContent.Stretch |> justifyContentValue'
        static member Safe = FlexType.JustifyContent.Safe |> justifyContentValue'
        static member Unsafe = FlexType.JustifyContent.Unsafe |> justifyContentValue'
        static member Left = FlexType.JustifyContent.Left |> justifyContentValue'
        static member Right = FlexType.JustifyContent.Right |> justifyContentValue'
        static member SpaceBetween = FlexType.JustifyContent.SpaceBetween |> justifyContentValue'
        static member SpaceAround = FlexType.JustifyContent.SpaceAround |> justifyContentValue'
        static member SpaceEvenly = FlexType.JustifyContent.SpaceEvenly |> justifyContentValue'

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
        static member Start = FlexType.JustifyItems.Start |> justifyItemsValue'
        static member End = FlexType.JustifyItems.End |> justifyItemsValue'
        static member FlexStart = FlexType.JustifyItems.FlexStart |> justifyItemsValue'
        static member FlexEnd = FlexType.JustifyItems.FlexEnd |> justifyItemsValue'
        static member Center = FlexType.JustifyItems.Center |> justifyItemsValue'
        static member Baseline = FlexType.JustifyItems.Baseline |> justifyItemsValue'
        static member FirstBaseline = FlexType.JustifyItems.FirstBaseline |> justifyItemsValue'
        static member LastBaseline = FlexType.JustifyItems.LastBaseline |> justifyItemsValue'
        static member Stretch = FlexType.JustifyItems.Stretch |> justifyItemsValue'
        static member Safe = FlexType.JustifyItems.Safe |> justifyItemsValue'
        static member Unsafe = FlexType.JustifyItems.Unsafe |> justifyItemsValue'
        static member Left = FlexType.JustifyItems.Left |> justifyItemsValue'
        static member Right = FlexType.JustifyItems.Right |> justifyItemsValue'
        static member SelfStart = FlexType.JustifyItems.SelfStart |> justifyItemsValue'
        static member SelfEnd = FlexType.JustifyItems.SelfEnd |> justifyItemsValue'
        static member Legacy = FlexType.JustifyItems.Legacy |> justifyItemsValue'

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
        static member Start = FlexType.JustifySelf.Start |> justifySelfValue'
        static member End = FlexType.JustifySelf.End |> justifySelfValue'
        static member FlexStart = FlexType.JustifySelf.FlexStart |> justifySelfValue'
        static member FlexEnd = FlexType.JustifySelf.FlexEnd |> justifySelfValue'
        static member Center = FlexType.JustifySelf.Center |> justifySelfValue'
        static member Baseline = FlexType.JustifySelf.Baseline |> justifySelfValue'
        static member FirstBaseline = FlexType.JustifySelf.FirstBaseline |> justifySelfValue'
        static member LastBaseline = FlexType.JustifySelf.LastBaseline |> justifySelfValue'
        static member Stretch = FlexType.JustifySelf.Stretch |> justifySelfValue'
        static member Safe = FlexType.JustifySelf.Safe |> justifySelfValue'
        static member Unsafe = FlexType.JustifySelf.Unsafe |> justifySelfValue'
        static member SelfStart = FlexType.JustifySelf.SelfStart |> justifySelfValue'
        static member SelfEnd = FlexType.JustifySelf.SelfEnd |> justifySelfValue'

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
        static member Row = FlexType.Row |> flexDirectionValue'
        static member RowReverse = FlexType.RowReverse |> flexDirectionValue'
        static member Column = FlexType.Column |> flexDirectionValue'
        static member ColumnReverse = FlexType.ColumnReverse |> flexDirectionValue'

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
        static member NoWrap = FlexType.NoWrap |> flexWrapValue'
        static member Wrap = FlexType.Wrap |> flexWrapValue'
        static member WrapReverse = FlexType.WrapReverse |> flexWrapValue'

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
        static member Fill = FlexType.Fill |> flexBasisValue'
        static member MaxContent = FlexType.MaxContent |> flexBasisValue'
        static member MinContent = FlexType.MinContent |> flexBasisValue'
        static member FitContent = FlexType.FitContent |> flexBasisValue'
        static member Content = FlexType.Content |> flexBasisValue'

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
