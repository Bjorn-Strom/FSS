namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Grid =
    type GridAutoFlow =
        | Row
        | Column
        | Dense
        | RowDense
        | ColumnDense
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | RowDense -> "row dense"
                | ColumnDense -> "column dense"
                | _ -> this.ToString().ToLower()

    type GridTemplate =
        | Subgrid
        | Masonry
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type GridPosition =
        | Value of int
        | Ident of string
        | IdentValue of string * int
        | ValueIdentSpan of int * string
        | Span of string
        interface ICssValue with
            member this.StringifyCss() = this.ToString().ToLower()

    type RepeatType =
        | AutoFill
        | AutoFit
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this
        

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-rows
    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-column-rows
    type MinMaxHelper =
        | MinMax1 of ILengthPercentage * Fraction
        | MinMax2 of ILengthPercentage * ILengthPercentage
        | MinMax3 of ILengthPercentage * ContentSize.ContentSize
        | MinMax4 of ContentSize.ContentSize * ILengthPercentage
        | MinMax5 of ContentSize.ContentSize * ContentSize.ContentSize
        | MinMax6 of ContentSize.ContentSize * Fraction
        interface ICssValue with
            member this.StringifyCss() =
                let minmaxValue a b = $"minmax({a}, {b})"

                match this with
                | MinMax1 (lengthPercentage, fraction) ->
                    minmaxValue (lengthPercentageString lengthPercentage) (stringifyICssValue fraction)
                | MinMax2 (lengthPercentage1, lengthPercentage2) ->
                    minmaxValue (lengthPercentageString lengthPercentage1) (lengthPercentageString lengthPercentage2)
                | MinMax3 (lengthPercentage, contentSize) ->
                    minmaxValue (lengthPercentageString lengthPercentage) (stringifyICssValue contentSize)
                | MinMax4 (contentSize, lengthPercentage) ->
                    minmaxValue (stringifyICssValue contentSize) (lengthPercentageString lengthPercentage)
                | MinMax5 (contentSize1, contentSize2) ->
                    minmaxValue (stringifyICssValue contentSize1) (stringifyICssValue contentSize2)
                | MinMax6 (contentSize, fraction) ->
                    minmaxValue (stringifyICssValue contentSize) (stringifyICssValue fraction)

    type MinMax =
        static member MinMax(min, max) = MinMaxHelper.MinMax1(min, max)
        static member MinMax(min, max) = MinMaxHelper.MinMax2(min, max)
        static member MinMax(min, max) = MinMaxHelper.MinMax3(min, max)
        static member MinMax(min, max) = MinMaxHelper.MinMax4(min, max)
        static member MinMax(min, max) = MinMaxHelper.MinMax5(min, max)
        static member MinMax(min, max) = MinMaxHelper.MinMax6(min, max)

    type RepeatHelper =
        | Repeat1 of int * ILengthPercentage
        | Repeat2 of int * Fraction
        | Repeat3 of int * ContentSize.ContentSize
        | Repeat4 of int * ContentSize.ContentSize list
        | Repeat5 of int * ILengthPercentage list
        | Repeat6 of RepeatType * Fraction
        | Repeat7 of RepeatType * ILengthPercentage
        | Repeat8 of RepeatType * ContentSize.ContentSize
        | Repeat9 of int * MinMaxHelper
        interface ICssValue with
            member this.StringifyCss() =
                let repeatValue a b = $"repeat({a}, {b})"

                match this with
                | Repeat1 (value, length) -> repeatValue value (lengthPercentageString length)
                | Repeat2 (value, fraction) -> repeatValue value (stringifyICssValue fraction)
                | Repeat3 (value, contentSize) -> repeatValue value (stringifyICssValue contentSize)
                | Repeat4 (value, contentSizes) ->
                    List.map stringifyICssValue contentSizes
                    |> String.concat " "
                    |> repeatValue value
                | Repeat5 (value, lengthPercentages) ->
                    List.map lengthPercentageString lengthPercentages
                    |> String.concat " "
                    |> repeatValue value
                | Repeat6 (repeat, fraction) ->
                    repeatValue (stringifyICssValue repeat) (stringifyICssValue fraction)
                | Repeat7 (repeat, lengthPercentage) ->
                    repeatValue (stringifyICssValue repeat) (lengthPercentageString lengthPercentage)
                | Repeat8 (repeat, contentSize) ->
                    repeatValue (stringifyICssValue repeat) (stringifyICssValue contentSize)
                | Repeat9 (value, minMax) -> repeatValue value (stringifyICssValue minMax)

    type Repeat =
        static member Repeat(value, length) = Repeat1(value, length)
        static member Repeat(value, length) = Repeat2(value, length)
        static member Repeat(value, length) = Repeat3(value, length)
        static member Repeat(value, length) = Repeat4(value, length)
        static member Repeat(value, length) = Repeat5(value, length)
        static member Repeat(value, length) = Repeat6(value, length)
        static member Repeat(value, length) = Repeat7(value, length)
        static member Repeat(value, length) = Repeat8(value, length)
        static member Repeat(value, length) = Repeat9(value, length)

[<RequireQualifiedAccess>]
module GridClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-area
    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-column
    type GridPosition(property) =
        inherit CssRuleWithAuto(property)
        member this.value(area: string) =
            (property, String area) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-column-start
    type GridColumn(property) =
        inherit CssRuleWithAuto(property)
        member this.value(area: string) = (property, String area) |> Rule
        member this.value(value: int) = (property, Int value) |> Rule

        member this.value(value: int, area: string) =
            let value = $"{value} {area}"
            (property, String value) |> Rule

        member this.span(value: int) =
            let value = $"span {value}"
            (property, String value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-row
    type GridRow(property) =
        inherit GridPosition(property)

        member this.value(area: string, value: int) =
            (property, DividerMaster(area, (string value)) ) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/gap
    type GridGap(property) =
        inherit CssRuleWithNormal(property)

        member this.value(gap: ILengthPercentage) =
            (property, lengthPercentageToType gap) |> Rule

    type GridTwoGap(property) =
        inherit GridGap(property)

        member this.value(rowGap: ILengthPercentage, columnGap: ILengthPercentage) =
            let value =
                $"{lengthPercentageString rowGap} {lengthPercentageString columnGap}"
                |> String

            (property, value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-rows
    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-columns
    type GridTemplate(property) =
        inherit CssRuleWithAutoNone(property)

        member this.value(template: ILengthPercentage) =
            (property, lengthPercentageToType template)
            |> Rule

        member this.minMax(min: ILengthPercentage, max: Fraction) =
            (property, Grid.MinMax.MinMax(min, max)) |> Rule

        member this.minMax(min: ILengthPercentage, max: ILengthPercentage) =
            (property, Grid.MinMax.MinMax(min, max)) |> Rule

        member this.minMax(min: ILengthPercentage, max: ContentSize.ContentSize) =
            (property, Grid.MinMax.MinMax(min, max)) |> Rule

        member this.minMax(min: ContentSize.ContentSize, max: ILengthPercentage) =
            (property, Grid.MinMax.MinMax(min, max)) |> Rule

        member this.minMax(min: ContentSize.ContentSize, max: ContentSize.ContentSize) =
            (property, Grid.MinMax.MinMax(min, max)) |> Rule

        member this.minMax(min: ContentSize.ContentSize, max: Fraction) =
            (property, Grid.MinMax.MinMax(min, max)) |> Rule

        member this.fitContent(fitContent: ILengthPercentage) =
            (property, ContentSize.FitContent fitContent)
            |> Rule

        member this.repeat(number: int, size: ILengthPercentage) =
            (property, Grid.Repeat.Repeat(number, size))
            |> Rule

        member this.repeat(value: int, fraction: Fraction) =
            (property, Grid.Repeat.Repeat(value, fraction))
            |> Rule

        member this.repeat(value: int, contentSize: ContentSize.ContentSize) =
            (property, Grid.Repeat.Repeat(value, contentSize))
            |> Rule

        member this.repeat(value: int, contentSizes: ContentSize.ContentSize list) =
            (property, Grid.Repeat.Repeat(value, contentSizes))
            |> Rule

        member this.repeat(value: int, sizes: ILengthPercentage list) =
            (property, Grid.Repeat.Repeat(value, sizes))
            |> Rule

        member this.repeat(value: Grid.RepeatType, fraction: Fraction) =
            (property, Grid.Repeat.Repeat(value, fraction))
            |> Rule

        member this.repeat(value: Grid.RepeatType, length: ILengthPercentage) =
            (property, Grid.Repeat.Repeat(value, length))
            |> Rule

        member this.repeat(value: Grid.RepeatType, contentSize: ContentSize.ContentSize) =
            (property, Grid.Repeat.Repeat(value, contentSize))
            |> Rule

        member this.repeat(value: int, minMax: Grid.MinMaxHelper) =
            (property, Grid.Repeat.Repeat(value, minMax))
            |> Rule

        member this.subgrid = (property, Grid.Subgrid) |> Rule
        member this.masonry = (property, Grid.Masonry) |> Rule

    type AutoHelper =
        | Fractions of Fraction list
        | ContentSizes of ContentSize.ContentSize list
        | Length of Length list
        | Percent of Percent list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Fractions fractions ->
                    fractions
                    |> List.map stringifyICssValue
                    |> String.concat " "
                | ContentSizes sizes ->
                    List.map stringifyICssValue sizes
                    |> String.concat " "
                | Length lengths ->
                    List.map stringifyICssValue lengths
                    |> String.concat " "
                | Percent percents ->
                    List.map stringifyICssValue percents
                    |> String.concat " "

    type GridAuto(property) =
        inherit ContentSizeClasses.ContentSize(property)
        member this.value(fraction: Fraction) = (property, fraction) |> Rule
        member this.value(fraction: Fraction list) = (property, Fractions fraction) |> Rule
        member this.value(sizes: Length list) = (property, Length sizes) |> Rule
        member this.value(sizes: Percent list) = (property, Percent sizes) |> Rule

        member this.value(contentSizes: ContentSize.ContentSize list) =
            (property, ContentSizes contentSizes) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow
    type GridAutoFlow(property) =
        inherit CssRule(property)
        member this.row = (property, Grid.Row) |> Rule
        member this.column = (property, Grid.Column) |> Rule
        member this.dense = (property, Grid.Dense) |> Rule
        member this.rowDense = (property, Grid.RowDense) |> Rule
        member this.columnDense = (property, Grid.ColumnDense) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template-areas
    type GridTemplateAreas(property) =
        inherit CssRuleWithNone(property)
        member this.value(values: string list) =
            let values =
                let v = String.concat " " values
                $"\"{v}\""
            (property, String values) |> Rule
        member this.value(values: string list list) =
            let values =
                    values
                    |> List.map (fun x -> String.concat " " x)
                    |> List.fold (fun acc x -> $"{acc} \"{x}\"") ""
                    
            (property, String values) |> Rule
