namespace Fss

module ColumnType =
    type ColumnSpan =
        | All
        interface IColumnSpan

    type ColumnRuleWidth =
        | Thin
        | Medium
        | Thick
        interface IColumnRuleWidth

    type ColumnRuleStyle =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        interface IColumnRuleStyle

[<AutoOpen>]
module Column =
    open ColumnType

    let private columnGapToString (gap: IColumnGap) =
        match gap with
        | :? Keywords as k -> GlobalValue.keywords k
        | :? Normal -> GlobalValue.normal
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | _ -> "Unknown column gap"

    let private columnSpanToString (span: IColumnSpan) =
        let stringifyColumnSpan =
            function
                | All -> "all"

        match span with
        | :? ColumnSpan as c -> stringifyColumnSpan c
        | :? Keywords as k -> GlobalValue.keywords k
        | :? None -> GlobalValue.none
        | _ -> "Unknown column span"

    let private columnRuleWidthToString (ruleWidth: IColumnRuleWidth) =
        let stringifyRuleWidth =
            function
                | Thin -> "thin"
                | Medium -> "medium"
                | Thick -> "thick"

        match ruleWidth with
        | :? ColumnRuleWidth as w -> stringifyRuleWidth w
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown column rule width"

    let private columnRuleStyleToString (style: IColumnRuleStyle) =
        let stringifyStyle =
            function
                | Hidden -> "hidden"
                | Dotted -> "dotted"
                | Dashed -> "dashed"
                | Solid -> "solid"
                | Double -> "double"
                | Groove -> "groove"
                | Ridge -> "ridge"
                | Inset -> "inset"
                | Outset -> "outset"

        match style with
        | :? ColumnRuleStyle as b -> stringifyStyle b
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown column style"


    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-gap
    let private columnGapValue value = PropertyValue.cssValue Property.ColumnGap value
    let private columnGapValue' value =
        value
        |> columnGapToString
        |> columnGapValue
    type ColumnGap =
        static member Value (gap: IColumnGap) = gap |> columnGapValue'
        static member Inherit = Inherit |> columnGapValue'
        static member Initial = Initial |> columnGapValue'
        static member Unset = Unset |> columnGapValue'
        static member Normal = Normal |> columnGapValue'

    let ColumnGap' (columnGap: IColumnGap) = ColumnGap.Value(columnGap)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-span
    let private columnSpanValue value = PropertyValue.cssValue Property.ColumnSpan value
    let private columnSpanValue' value =
        value
        |> columnSpanToString
        |> columnSpanValue

    type ColumnSpan =
        static member Value(span: IColumnSpan) = span |> columnSpanValue'
        static member All = All |> columnSpanValue'
        static member Inherit = Inherit |> columnSpanValue'
        static member Initial = Initial |> columnSpanValue'
        static member Unset = Unset |> columnSpanValue'
        static member None = None |> columnSpanValue'

    let ColumnSpan' (span: IColumnSpan) = ColumnSpan.Value(span)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    let private columnRuleWidthValue value = PropertyValue.cssValue Property.ColumnRuleWidth value
    let private columnRuleWidthValue' value =
        value
        |> columnRuleWidthToString
        |> columnRuleWidthValue

    type ColumnRuleWidth =
        static member Value (ruleWidth: IColumnRuleWidth) = ruleWidth |> columnRuleWidthValue'
        static member Thin = Thin |> columnRuleWidthValue'
        static member Medium = Medium |> columnRuleWidthValue'
        static member Thick = Thick |> columnRuleWidthValue'
        static member Inherit = Inherit |> columnRuleWidthValue'
        static member Initial = Initial |> columnRuleWidthValue'
        static member Unset = Unset |> columnRuleWidthValue'

    let ColumnRuleWidth' (ruleWidth: IColumnRuleWidth) = ruleWidth |> ColumnRuleWidth.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-style
    let private styleValue value = PropertyValue.cssValue Property.ColumnRuleStyle value
    let private styleValue' value =
        value
        |> columnRuleStyleToString
        |> styleValue

    type ColumnRuleStyle =
        static member Value (style: IColumnRuleStyle) = style |> styleValue'
        static member Hidden = Hidden |> styleValue'
        static member Dotted = Dotted |> styleValue'
        static member Dashed = Dashed |> styleValue'
        static member Solid = Solid |> styleValue'
        static member Double = Double |> styleValue'
        static member Groove = Groove |> styleValue'
        static member Ridge = Ridge |> styleValue'
        static member Inset = Inset |> styleValue'
        static member Outset = Outset |> styleValue'

        static member None = None |> styleValue'
        static member Inherit = Inherit |> styleValue'
        static member Initial = Initial |> styleValue'
        static member Unset = Unset |> styleValue'

    let ColumnRuleStyle' (style: IColumnRuleStyle) = ColumnRuleStyle.Value(style)
