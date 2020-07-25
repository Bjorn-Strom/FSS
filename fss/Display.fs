namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/display
module Display =
    open Utilities.Types

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
        interface ICSSProperty


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
    type IFlex = interface end

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction      
module FlexDirection =
    open Utilities.Types

    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface ICSSProperty

    let value (v: FlexDirection): string =
        match v with
        | Row -> "row"
        | RowReverse -> "row-reverse"
        | Column -> "column"
        | ColumnReverse -> "column-reverse"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
module FlexWrap =
    open Utilities.Types
    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface ICSSProperty

    let value (v: FlexWrap): string =
        match v with 
            | NoWrap -> "nowrap"
            | Wrap -> "wrap"
            | WrapReverse -> "wrap-reverse"  

// https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
module JustifyContent =
    open Utilities.Types
    type JustifyContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly
        interface ICSSProperty

    let value (v: JustifyContent): string =
        match v with 
            | FlexStart -> "flex-start"
            | FlexEnd -> "flex-end"
            | Center -> "center"
            | SpaceBetween -> "space-between"
            | SpaceAround -> "space-around"
            | SpaceEvenly -> "space-evenly"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
module AlignItems =
    open Utilities.Types
    type AlignItems =
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | Stretch
        interface ICSSProperty

    let value (v: AlignItems): string =
        match v with 
            | FlexStart -> "flex-start"
            | FlexEnd -> "flex-end"
            | Center -> "center"
            | Baseline -> "baseline"
            | Stretch -> "stretch"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
module AlignContent =
    open Utilities.Types

    type AlignContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | Stretch
        interface ICSSProperty

    let value (v: AlignContent): string =
        match v with 
            | FlexStart -> "flex-start"
            | FlexEnd -> "flex-end"
            | Center -> "center"
            | SpaceBetween -> "space-between"
            | SpaceAround -> "space-around"
            | Stretch -> "stretch"

// https://developer.mozilla.org/en-US/docs/Web/CSS/order
module Order =
    open Utilities.Types

    type Order = 
        | Order of int
        interface ICSSProperty

    let value (Order o): string = string  o

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
module FlexGrow =
    open FlexTypes
    open Utilities.Types

    type FlexGrow = 
        | FlexGrow of int
        interface ICSSProperty
        interface IFlex

    let value (FlexGrow f) = string f

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
module FlexShrink =
    open FlexTypes
    open Utilities.Types

    type FlexShrink =
        | FlexShrink of int
        interface ICSSProperty
        interface IFlex

    let value (FlexShrink f) = string f

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
module FlexBasis =
    open Fss.Units.Size
    open FlexTypes
    open Utilities.Types

    type FlexBasis = 
        | FlexBasis of Size
        interface IFlex
        interface ICSSProperty

    let value (FlexBasis v) = Units.Size.value v

module Flex =
    open Utilities.Types
    open Utilities.Global
    open FlexTypes
    open FlexGrow
    open FlexShrink
    open FlexBasis

    type Flex = 
        | Flex of IFlex list
        interface ICSSProperty

    let value (v: ICSSProperty): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? FlexGrow as f -> FlexGrow.value f
            | :? FlexShrink as f -> FlexShrink.value f
            | :? FlexBasis as f -> FlexBasis.value f
            | _ -> "Unknown flex type"

module AlignSelf =
    open Utilities.Types

    type AlignSelf = 
        | Auto
        | FlexStart 
        | FlexEnd 
        | Center 
        | Baseline 
        | Stretch
        interface ICSSProperty

    let value (v: AlignSelf): string =
        match v with
            | Auto -> "auto"
            | FlexStart -> "flexStart"
            | FlexEnd -> "flexEnd"
            | Center -> "center"
            | Baseline -> "baseline"
            | Stretch -> "stretch"