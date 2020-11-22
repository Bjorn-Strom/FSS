namespace Fss

module FlexType =
    type AlignContentType =
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

    type AlignItemsType =
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

    type AlignSelfType =
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

    type JustifyContentType =
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

    type JustifyItemsType =
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

    type JustifySelfType =
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

    type FlexWrapType =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexWrap

    type FlexDirectionType =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface IFlexDirection

    type FlexBasisType =
        | Fill
        | MaxContent
        | MinContent
        | FitContent
        | Content
        interface IFlexBasis

[<AutoOpen>]
module Flex =
    open FlexType

    let private alignContentToString (alignment: IAlignContent) =
        let stringifyAlignment =
            function
                | AlignContentType.Start -> "start"
                | AlignContentType.End -> "end"
                | AlignContentType.FlexStart -> "flex-start"
                | AlignContentType.FlexEnd -> "flex-end"
                | AlignContentType.Center -> "center"
                | AlignContentType.Baseline -> "baseline"
                | AlignContentType.FirstBaseline -> "first baseline"
                | AlignContentType.LastBaseline -> "last baseline"
                | AlignContentType.Stretch -> "stretch"
                | AlignContentType.Safe -> "safe"
                | AlignContentType.Unsafe -> "unsafe"
                | AlignContentType.SpaceBetween -> "space-between"
                | AlignContentType.SpaceAround -> "space-around"
                | AlignContentType.SpaceEvenly -> "space-evenly"

        match alignment with
        | :? AlignContentType as a -> stringifyAlignment a
        | :? Normal -> GlobalValue.normal
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown align content"

    let private alignItemsToString (alignment: IAlignItems) =
        let stringifyAlignment =
            function
                | AlignItemsType.Start -> "start"
                | AlignItemsType.End -> "end"
                | AlignItemsType.FlexStart -> "flex-start"
                | AlignItemsType.FlexEnd -> "flex-end"
                | AlignItemsType.Center -> "center"
                | AlignItemsType.Baseline -> "baseline"
                | AlignItemsType.FirstBaseline -> "first baseline"
                | AlignItemsType.LastBaseline -> "last baseline"
                | AlignItemsType.Stretch -> "stretch"
                | AlignItemsType.Safe -> "safe"
                | AlignItemsType.Unsafe -> "unsafe"
                | AlignItemsType.SelfStart -> "self-start"
                | AlignItemsType.SelfEnd -> "self-end"

        match alignment with
        | :? AlignItemsType as a -> stringifyAlignment a
        | :? Normal -> GlobalValue.normal
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown align items"

    let private alignSelfToString (alignment: IAlignSelf) =
        let stringifyAlignment =
            function
                | AlignSelfType.Start -> "start"
                | AlignSelfType.End -> "end"
                | AlignSelfType.FlexStart -> "flex-start"
                | AlignSelfType.FlexEnd -> "flex-end"
                | AlignSelfType.Center -> "center"
                | AlignSelfType.Baseline -> "baseline"
                | AlignSelfType.FirstBaseline -> "first baseline"
                | AlignSelfType.LastBaseline -> "last baseline"
                | AlignSelfType.Stretch -> "stretch"
                | AlignSelfType.Safe -> "safe"
                | AlignSelfType.Unsafe -> "unsafe"
                | AlignSelfType.SelfStart -> "self-start"
                | AlignSelfType.SelfEnd -> "self-end"

        match alignment with
        | :? AlignSelfType as a -> stringifyAlignment a
        | :? Normal -> GlobalValue.normal
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown align self"

    let private justifyContentToString (justification: IJustifyContent) =
        let stringifyJustification =
            function
                | JustifyContentType.Start -> "start"
                | JustifyContentType.End -> "end"
                | JustifyContentType.FlexStart -> "flex-start"
                | JustifyContentType.FlexEnd -> "flex-end"
                | JustifyContentType.Center -> "center"
                | JustifyContentType.Baseline -> "baseline"
                | JustifyContentType.FirstBaseline -> "first baseline"
                | JustifyContentType.LastBaseline -> "last baseline"
                | JustifyContentType.Stretch -> "stretch"
                | JustifyContentType.Safe -> "safe"
                | JustifyContentType.Unsafe -> "unsafe"
                | JustifyContentType.SpaceBetween -> "space-between"
                | JustifyContentType.SpaceAround -> "space-around"
                | JustifyContentType.SpaceEvenly -> "space-evenly"
                | JustifyContentType.Left -> "left"
                | JustifyContentType.Right -> "right"

        match justification with
        | :? JustifyContentType as a -> stringifyJustification a
        | :? Normal -> GlobalValue.normal
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown justify content"


    let private justifyItemsToString (justification: IJustifyItems) =
        let stringifyJustification =
            function
                | JustifyItemsType.Start -> "start"
                | JustifyItemsType.End -> "end"
                | JustifyItemsType.FlexStart -> "flex-start"
                | JustifyItemsType.FlexEnd -> "flex-end"
                | JustifyItemsType.Center -> "center"
                | JustifyItemsType.Baseline -> "baseline"
                | JustifyItemsType.FirstBaseline -> "first baseline"
                | JustifyItemsType.LastBaseline -> "last baseline"
                | JustifyItemsType.Stretch -> "stretch"
                | JustifyItemsType.Safe -> "safe"
                | JustifyItemsType.Unsafe -> "unsafe"
                | JustifyItemsType.Left -> "left"
                | JustifyItemsType.Right -> "right"
                | JustifyItemsType.SelfStart -> "self-start"
                | JustifyItemsType.SelfEnd -> "self-end"
                | JustifyItemsType.Legacy -> "legacy"

        match justification with
        | :? JustifyItemsType as a -> stringifyJustification a
        | :? Normal -> GlobalValue.normal
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown justify items"

    let private justifySelfToString (justification: IJustifySelf) =
        let stringifyJustification =
            function
                | JustifySelfType.Start -> "start"
                | JustifySelfType.End -> "end"
                | JustifySelfType.FlexStart -> "flex-start"
                | JustifySelfType.FlexEnd -> "flex-end"
                | JustifySelfType.Center -> "center"
                | JustifySelfType.Baseline -> "baseline"
                | JustifySelfType.FirstBaseline -> "first baseline"
                | JustifySelfType.LastBaseline -> "last baseline"
                | JustifySelfType.Stretch -> "stretch"
                | JustifySelfType.Safe -> "safe"
                | JustifySelfType.Unsafe -> "unsafe"
                | JustifySelfType.SelfStart -> "self-start"
                | JustifySelfType.SelfEnd -> "self-end"

        match justification with
        | :? JustifySelfType as a -> stringifyJustification a
        | :? Normal -> GlobalValue.normal
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown justify self"

    let private flexDirectionToString (direction: IFlexDirection) =
        let stringifyJustification =
            function
                | Row -> "row"
                | RowReverse -> "row-reverse"
                | Column -> "column"
                | ColumnReverse -> "column-reverse"

        match direction with
        | :? FlexDirectionType as a -> stringifyJustification a
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown flex direction"

    let private flexWrapToString (direction: IFlexWrap) =
        let stringifyJustification =
            function
                | NoWrap -> "no-wrap"
                | Wrap -> "wrap"
                | WrapReverse -> "wrap-reverse"

        match direction with
        | :? FlexWrapType as a -> stringifyJustification a
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown flex wrap"

    let private orderToString (order: IOrder) =
        match order with
        | :? CssInt as i -> GlobalValue.int i
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown order"

    let private flexGrowToString (flexGrow: IFlexGrow) =
        match flexGrow with
        | :? Global.CssFloat as f -> GlobalValue.float f
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown flex grow"

    let private flexShrinkToString (flexShrink: IFlexShrink) =
        match flexShrink with
        | :? Global.CssFloat as f -> GlobalValue.float f
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown flex shrink"

    let private flexBasisToString (basis: IFlexBasis) =
        let stringifyBasis =
            function
                | Fill -> "fill"
                | MaxContent -> "max-content"
                | MinContent -> "min-content"
                | FitContent -> "fit-content"
                | Content -> "content"

        match basis with
        | :? FlexBasisType as b -> stringifyBasis b
        | :? Auto -> GlobalValue.auto
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown flex basis"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    let private alignContentValue value = PropertyValue.cssValue Property.AlignContent value
    let private alignContentValue' value =
        value
        |> alignContentToString
        |> alignContentValue

    type AlignContent =
        static member Value (alignment: IAlignContent) = alignment |> alignContentValue'
        static member Start = AlignContentType.Start |> alignContentValue'
        static member End = AlignContentType.End |> alignContentValue'
        static member FlexStart = AlignContentType.FlexStart |> alignContentValue'
        static member FlexEnd = AlignContentType.FlexEnd |> alignContentValue'
        static member Center = AlignContentType.Center |> alignContentValue'
        static member Baseline = AlignContentType.Baseline |> alignContentValue'
        static member FirstBaseline = AlignContentType.FirstBaseline |> alignContentValue'
        static member LastBaseline = AlignContentType.LastBaseline |> alignContentValue'
        static member Stretch = AlignContentType.Stretch |> alignContentValue'
        static member Safe = AlignContentType.Safe |> alignContentValue'
        static member Unsafe = AlignContentType.Unsafe |> alignContentValue'
        static member SpaceBetween = AlignContentType.SpaceBetween |> alignContentValue'
        static member SpaceAround = AlignContentType.SpaceAround |> alignContentValue'
        static member SpaceEvenly = AlignContentType.SpaceEvenly |> alignContentValue'

        static member Normal = Normal |> alignContentValue'
        static member Inherit = Inherit |> alignContentValue'
        static member Initial = Initial |> alignContentValue'
        static member Unset = Unset |> alignContentValue'

    let AlignContent' (align: IAlignContent) = AlignContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    let private alignItemsValue value = PropertyValue.cssValue Property.AlignItems value
    let private alignItemsValue' value =
        value
        |> alignItemsToString
        |> alignItemsValue

    type AlignItems =
        static member Value (alignment: IAlignItems) = alignment |> alignItemsValue'
        static member Start = AlignItemsType.Start |> alignItemsValue'
        static member End = AlignItemsType.End |> alignItemsValue'
        static member FlexStart = AlignItemsType.FlexStart |> alignItemsValue'
        static member FlexEnd = AlignItemsType.FlexEnd |> alignItemsValue'
        static member Center = AlignItemsType.Center |> alignItemsValue'
        static member Baseline = AlignItemsType.Baseline |> alignItemsValue'
        static member FirstBaseline = AlignItemsType.FirstBaseline |> alignItemsValue'
        static member LastBaseline = AlignItemsType.LastBaseline |> alignItemsValue'
        static member Stretch = AlignItemsType.Stretch |> alignItemsValue'
        static member Safe = AlignItemsType.Safe |> alignItemsValue'
        static member Unsafe = AlignItemsType.Unsafe |> alignItemsValue'
        static member SelfStart = AlignItemsType.SelfStart |> alignItemsValue'
        static member SelfEnd = AlignItemsType.SelfEnd |> alignItemsValue'

        static member Normal = Normal |> alignItemsValue'
        static member Inherit = Inherit |> alignItemsValue'
        static member Initial = Initial |> alignItemsValue'
        static member Unset = Unset |> alignItemsValue'

    let AlignItems' (align: IAlignItems) = AlignItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    let private alignSelfValue value = PropertyValue.cssValue Property.AlignSelf value
    let private alignSelfValue' value =
        value
        |> alignSelfToString
        |> alignSelfValue

    type AlignSelf =
        static member Value (alignment: IAlignSelf) = alignment |> alignSelfValue'
        static member Start = AlignSelfType.Start |> alignSelfValue'
        static member End = AlignSelfType.End |> alignSelfValue'
        static member FlexStart = AlignSelfType.FlexStart |> alignSelfValue'
        static member FlexEnd = AlignSelfType.FlexEnd |> alignSelfValue'
        static member Center = AlignSelfType.Center |> alignSelfValue'
        static member Baseline = AlignSelfType.Baseline |> alignSelfValue'
        static member FirstBaseline = AlignSelfType.FirstBaseline |> alignSelfValue'
        static member LastBaseline = AlignSelfType.LastBaseline |> alignSelfValue'
        static member Stretch = AlignSelfType.Stretch |> alignSelfValue'
        static member Safe = AlignSelfType.Safe |> alignSelfValue'
        static member Unsafe = AlignSelfType.Unsafe |> alignSelfValue'
        static member SelfStart = AlignSelfType.SelfStart |> alignSelfValue'
        static member SelfEnd = AlignSelfType.SelfEnd |> alignSelfValue'

        static member Normal = Normal |> alignSelfValue'
        static member Inherit = Inherit |> alignSelfValue'
        static member Initial = Initial |> alignSelfValue'
        static member Unset = Unset |> alignSelfValue'

    let AlignSelf' (align: IAlignSelf) = AlignSelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    let private justifyContentValue value = PropertyValue.cssValue Property.JustifyContent value
    let private justifyContentValue' value =
        value
        |> justifyContentToString
        |> justifyContentValue

    type JustifyContent =
        static member Value (justification: IJustifyContent) = justification |> justifyContentValue
        static member Start = JustifyContentType.Start |> justifyContentValue'
        static member End = JustifyContentType.End |> justifyContentValue'
        static member FlexStart = JustifyContentType.FlexStart |> justifyContentValue'
        static member FlexEnd = JustifyContentType.FlexEnd |> justifyContentValue'
        static member Center = JustifyContentType.Center |> justifyContentValue'
        static member Baseline = JustifyContentType.Baseline |> justifyContentValue'
        static member FirstBaseline = JustifyContentType.FirstBaseline |> justifyContentValue'
        static member LastBaseline = JustifyContentType.LastBaseline |> justifyContentValue'
        static member Stretch = JustifyContentType.Stretch |> justifyContentValue'
        static member Safe = JustifyContentType.Safe |> justifyContentValue'
        static member Unsafe = JustifyContentType.Unsafe |> justifyContentValue'
        static member Left = JustifyContentType.Left |> justifyContentValue'
        static member Right = JustifyContentType.Right |> justifyContentValue'
        static member SpaceBetween = JustifyContentType.SpaceBetween |> justifyContentValue'
        static member SpaceAround = JustifyContentType.SpaceAround |> justifyContentValue'
        static member SpaceEvenly = JustifyContentType.SpaceEvenly |> justifyContentValue'

        static member Normal = Normal |> justifyContentValue'
        static member Inherit = Inherit |> justifyContentValue'
        static member Initial = Initial |> justifyContentValue'
        static member Unset = Unset |> justifyContentValue'

    let JustifyContent' (align: IJustifyContent) = JustifyContent.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    let private justifyItemsValue value = PropertyValue.cssValue Property.JustifyItems value
    let private justifyItemsValue' value =
        value
        |> justifyItemsToString
        |> justifyItemsValue

    type JustifyItems =
        static member Value (justification: IJustifyItems) = justification |> justifyItemsValue'
        static member Start = JustifyItemsType.Start |> justifyItemsValue'
        static member End = JustifyItemsType.End |> justifyItemsValue'
        static member FlexStart = JustifyItemsType.FlexStart |> justifyItemsValue'
        static member FlexEnd = JustifyItemsType.FlexEnd |> justifyItemsValue'
        static member Center = JustifyItemsType.Center |> justifyItemsValue'
        static member Baseline = JustifyItemsType.Baseline |> justifyItemsValue'
        static member FirstBaseline = JustifyItemsType.FirstBaseline |> justifyItemsValue'
        static member LastBaseline = JustifyItemsType.LastBaseline |> justifyItemsValue'
        static member Stretch = JustifyItemsType.Stretch |> justifyItemsValue'
        static member Safe = JustifyItemsType.Safe |> justifyItemsValue'
        static member Unsafe = JustifyItemsType.Unsafe |> justifyItemsValue'
        static member Left = JustifyItemsType.Left |> justifyItemsValue'
        static member Right = JustifyItemsType.Right |> justifyItemsValue'
        static member SelfStart = JustifyItemsType.SelfStart |> justifyItemsValue'
        static member SelfEnd = JustifyItemsType.SelfEnd |> justifyItemsValue'
        static member Legacy = JustifyItemsType.Legacy |> justifyItemsValue'

        static member Normal = Normal |> justifyItemsValue'
        static member Inherit = Inherit |> justifyItemsValue'
        static member Initial = Initial |> justifyItemsValue'
        static member Unset = Unset |> justifyItemsValue'

    let JustifyItems' (align: IJustifyItems) = JustifyItems.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    let private justifySelfValue value = PropertyValue.cssValue Property.JustifySelf value
    let private justifySelfValue' value =
        value
        |> justifySelfToString
        |> justifySelfValue
    type JustifySelf =
        static member Value (justification: IJustifySelf) = justification |> justifySelfValue'
        static member Start = Start |> justifySelfValue'
        static member End = End |> justifySelfValue'
        static member FlexStart = FlexStart |> justifySelfValue'
        static member FlexEnd = FlexEnd |> justifySelfValue'
        static member Center = Center |> justifySelfValue'
        static member Baseline = Baseline |> justifySelfValue'
        static member FirstBaseline = FirstBaseline |> justifySelfValue'
        static member LastBaseline = LastBaseline |> justifySelfValue'
        static member Stretch = Stretch |> justifySelfValue'
        static member Safe = Safe |> justifySelfValue'
        static member Unsafe = Unsafe |> justifySelfValue'
        static member SelfStart = SelfStart |> justifySelfValue'
        static member SelfEnd = SelfEnd |> justifySelfValue'

        static member Normal = Normal |> justifySelfValue'
        static member Inherit = Inherit |> justifySelfValue'
        static member Initial = Initial |> justifySelfValue'
        static member Unset = Unset |> justifySelfValue'

    let JustifySelf' (align: IJustifySelf) = JustifySelf.Value(align)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction
    let private flexDirectionValue value = PropertyValue.cssValue Property.FlexDirection value
    let private flexDirectionValue' value =
        value
        |> flexDirectionToString
        |> flexDirectionValue

    type FlexDirection =
        static member Value (direction: IFlexDirection) = direction |> flexDirectionValue'
        static member Row = Row |> flexDirectionValue'
        static member RowReverse = RowReverse |> flexDirectionValue'
        static member Column = Column |> flexDirectionValue'
        static member ColumnReverse = ColumnReverse |> flexDirectionValue'

        static member Inherit = Inherit |> flexDirectionValue'
        static member Initial = Initial |> flexDirectionValue'
        static member Unset = Unset |> flexDirectionValue'

    let FlexDirection' (direction: IFlexDirection) = FlexDirection.Value(direction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    let private flexWrapValue value = PropertyValue.cssValue Property.FlexWrap value
    let private flexWrapValue' value =
        value
        |> flexWrapToString
        |> flexWrapValue
    type FlexWrap =
        static member Value (direction: IFlexWrap) = direction |> flexWrapValue'
        static member NoWrap = NoWrap |> flexWrapValue'
        static member Wrap = Wrap |> flexWrapValue'
        static member WrapReverse = WrapReverse |> flexWrapValue'

        static member Inherit = Inherit |> flexWrapValue'
        static member Initial = Initial |> flexWrapValue'
        static member Unset = Unset |> flexWrapValue'

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

    let FlexShrink' (shrink: IFlexShrink) = FlexShrink.Value(shrink)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    let private flexBasisValue value = PropertyValue.cssValue Property.FlexBasis value
    let private flexBasisValue' value =
        value
        |> flexBasisToString
        |> flexBasisValue

    type FlexBasis =
        static member Value (basis: IFlexBasis) = basis |> flexBasisValue'
        static member Fill = Fill |> flexBasisValue'
        static member MaxContent = MaxContent |> flexBasisValue'
        static member MinContent = MinContent |> flexBasisValue'
        static member FitContent = FitContent |> flexBasisValue'
        static member Content = Content |> flexBasisValue'

        static member Auto = Auto |> flexBasisValue'
        static member Inherit = Inherit |> flexBasisValue'
        static member Initial = Initial |> flexBasisValue'
        static member Unset = Unset |> flexBasisValue'

    let FlexBasis' (basis: IFlexBasis) = FlexBasis.Value(basis)