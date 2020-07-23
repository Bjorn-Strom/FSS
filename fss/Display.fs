namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/display
module Display =
    type Display =
        | Inline
        | InlineBlock
        | Block
        | RunIn
        | Flex
        | Grid
        | FlowRoot

        | Table
        | TableCell
        | TableColumn
        | TableColGroup
        | TableHeaderGroup
        | TableRowGroup
        | TableFooterGroup
        | TableRow
        | TableCaption

        | None


    let value (v: Display): string =
        match v with
            | Inline -> "inline"
            | InlineBlock -> "inlineBlock"
            | Block -> "block"
            | RunIn -> "runIn"
            | Flex -> "flex"
            | Grid -> "grid"
            | FlowRoot -> "flowRoot"

            | Table -> "table"
            | TableCell -> "tableCell"
            | TableColumn -> "tableColumn"
            | TableColGroup -> "tableColGroup"
            | TableHeaderGroup -> "tableHeaderGroup"
            | TableRowGroup -> "tableRowGroup"
            | TableFooterGroup -> "tableFooterGroup"
            | TableRow -> "tableRow"
            | TableCaption -> "tableCaption"

            | None -> "none"

module FlexTypes =
    type IFlexFlow = interface end
    type IFlex = interface end

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction      
module FlexDirection =
    open FlexTypes
    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface IFlexFlow

    let value (v: FlexDirection): string =
        match v with
        | Row -> "row"
        | RowReverse -> "rowReverse"
        | Column -> "column"
        | ColumnReverse -> "columnReverse"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
module FlexWrap =
    open FlexTypes
    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexFlow

    let value (v: FlexWrap): string =
        match v with 
            | NoWrap -> "noWrap"
            | Wrap -> "wrap"
            | WrapReverse -> "wrapReverse"  

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-flow
module FlexFlow =
    open FlexTypes
    open FlexDirection
    open FlexWrap

    let value (v: IFlexFlow): string =
        match v with
            | :? FlexDirection as fd -> FlexDirection.value fd
            | :? FlexWrap as fw -> FlexWrap.value fw
            | _ -> "Unknown flex flow value"

// https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
module JustifyContent = 
    type JustifyContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly

    let value (v: JustifyContent): string =
        match v with 
            | FlexStart -> "flexStart"
            | FlexEnd -> "flexEnd"
            | Center -> "center"
            | SpaceBetween -> "spaceBetween"
            | SpaceAround -> "spaceAround"
            | SpaceEvenly -> "spaceEvenly"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
module AlignItems =
    type AlignItems =
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | Stretch

    let value (v: AlignItems): string =
        match v with 
            | FlexStart -> "flexStart"
            | FlexEnd -> "flexEnd"
            | Center -> "center"
            | Baseline -> "baseline"
            | Stretch -> "stretch"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
module AlignContent =
    type AlignContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | Stretch

    let value (v: AlignContent): string =
        match v with 
            | FlexStart -> "flexStart"
            | FlexEnd -> "flexEnd"
            | Center -> "center"
            | SpaceBetween -> "spaceBetween"
            | SpaceAround -> "spaceAround"
            | Stretch -> "stretch"

// https://developer.mozilla.org/en-US/docs/Web/CSS/order
module Order =
    open FlexTypes
    type Order = 
        | Order of int

    let value (Order o) = o

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
module FlexGrow =
    open FlexTypes

    type FlexGrow = 
        | FlexGrow of int
        interface IFlex

    let value (FlexGrow f) = string f

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
module FlexShrink =
    open FlexTypes
    type FlexShrink =
        | FlexShrink of int
        interface IFlex

    let value (FlexShrink f) = string f

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
module FlexBasis =
    open Fss.Units.Size
    open FlexTypes

    type FlexBasis = 
        | FlexBasis of Size
        interface IFlex

    let value (FlexBasis v) = Units.Size.value v

module Flex =
    open FlexTypes
    open FlexGrow
    open FlexShrink
    open FlexBasis

    type Flex = Flex of IFlex list

    let value (v: IFlex): string =
        match v with
            | :? FlexGrow as f -> FlexGrow.value f
            | :? FlexShrink as f -> FlexShrink.value f
            | :? FlexBasis as f -> FlexBasis.value f
            | _ -> "Unknown flex type"

module AlignSelf =
    type AlignSelf = 
        | Auto
        | FlexStart 
        | FlexEnd 
        | Center 
        | Baseline 
        | Stretch

    let value (v: AlignSelf) =
        match v with
            | Auto -> "auto"
            | FlexStart -> "flexStart"
            | FlexEnd -> "flexEnd"
            | Center -> "center"
            | Baseline -> "baseline"
            | Stretch -> "stretch"