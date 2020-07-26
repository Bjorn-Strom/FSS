namespace Fss

open Utilities.Global

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
        interface IDisplay
        interface IGlobal


    let private displayValue (v: Display): string =
        match v with
            | Inline -> "inline"
            | InlineBlock -> "inline-block"
            | Block -> "block"
            | RunIn -> "run-in"
            | Flex -> "flex"
            | Grid -> "grid"
            | FlowRoot -> "flow-root"

            | Table -> "table"
            | TableCell -> "table-cell"
            | TableColumn -> "table-column"
            | TableColGroup -> "table-col-group"
            | TableHeaderGroup -> "table-header-group"
            | TableRowGroup -> "table-row-group"
            | TableFooterGroup -> "table-footer-group"
            | TableRow -> "table-row"
            | TableCaption -> "table-caption"

            | None -> "none"

    let value (v: IDisplay): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? Display as d -> displayValue d
            | _ -> "Unknown display"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction      
module FlexDirection =
    open Utilities.Types

    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface IFlexDirection
        interface IGlobal

    let private flexDirectionValue (v: FlexDirection): string =
        match v with
        | Row -> "row"
        | RowReverse -> "row-reverse"
        | Column -> "column"
        | ColumnReverse -> "column-reverse"

    let value (v: IFlexDirection): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? FlexDirection as f -> flexDirectionValue f
            | _ -> "Unknown flex direction"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
module FlexWrap =
    open Utilities.Types
    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexWrap
        interface IGlobal

    let private flexWrapValue (v: FlexWrap): string =
        match v with 
            | NoWrap -> "nowrap"
            | Wrap -> "wrap"
            | WrapReverse -> "wrap-reverse"

    let value (v: IFlexWrap): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? FlexWrap as f -> flexWrapValue f
            | _ -> "Unknown flex wrap"

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
        interface IJustifyContent
        interface IGlobal

    let private justifyContentValue (v: JustifyContent): string =
        match v with 
            | FlexStart -> "flex-start"
            | FlexEnd -> "flex-end"
            | Center -> "center"
            | SpaceBetween -> "space-between"
            | SpaceAround -> "space-around"
            | SpaceEvenly -> "space-evenly"

    let value (v: IJustifyContent): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? JustifyContent as j -> justifyContentValue j
            | _ -> "Unknown justify content"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
module AlignItems =
    open Utilities.Types
    type AlignItems =
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | Stretch
        interface IAlignItems
        interface IGlobal

    let private alignItemsValue (v: AlignItems): string =
        match v with 
            | FlexStart -> "flex-start"
            | FlexEnd -> "flex-end"
            | Center -> "center"
            | Baseline -> "baseline"
            | Stretch -> "stretch"

    let value (v: IAlignItems): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? AlignItems as a -> alignItemsValue a
            | _ -> "Unknown align items"

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
        interface IAlignContent
        interface IGlobal

    let private alignContentValue (v: AlignContent): string =
        match v with 
            | FlexStart -> "flex-start"
            | FlexEnd -> "flex-end"
            | Center -> "center"
            | SpaceBetween -> "space-between"
            | SpaceAround -> "space-around"
            | Stretch -> "stretch"

    let value (v: IAlignContent): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? AlignContent as a -> alignContentValue a
            | _ -> "Unknown align content"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
module AlignSelf =
    open Utilities.Types
            
    type AlignSelf = 
        | Auto
        | FlexStart 
        | FlexEnd 
        | Center 
        | Baseline 
        | Stretch
        interface IAlignSelf
        interface IGlobal
            
    let private alignSelfValue (v: AlignSelf): string =
        match v with
            | Auto -> "auto"
            | FlexStart -> "flex-start"
            | FlexEnd -> "flex-end"
            | Center -> "center"
            | Baseline -> "baseline"
            | Stretch -> "stretch"

    let value (v: IAlignSelf): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? AlignSelf as a -> alignSelfValue a
            | _ -> "Unknown align self"

// https://developer.mozilla.org/en-US/docs/Web/CSS/order
module Order =
    open Utilities.Types

    type Order = 
        | Order of int
        interface IOrder
        interface IGlobal

    let private orderValue (Order o): string = string  o

    let value (v: IOrder): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? Order as o -> orderValue o
            | _ -> "Unknown order"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
module FlexGrow =
    open Utilities.Types

    type FlexGrow = 
        | Grow of int
        interface IFlexGrow
        interface IGlobal

    let private flexGrowValue (Grow f) = string f

    let value (v: IFlexGrow): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? FlexGrow as s -> flexGrowValue s
            | _ -> "Unknown flex grow"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
module FlexShrink =
    open Utilities.Types

    type FlexShrink =
        | Shrink of int
        interface IFlexShrink
        interface IGlobal

    let private flexShrinkValue (Shrink f) = string f

    let value (v: IFlexShrink): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? FlexShrink as s -> flexShrinkValue s
            | _ -> "Unknown flex shrink"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
module FlexBasis =
    open Fss.Units.Size
    open Utilities.Types

    type FlexBasis = 
        | FlexBasis of Size
        interface IFlexBasis
        interface IGlobal

    let value (v: IFlexBasis): string =
        match v with
            | :? Global as g -> Utilities.Global.value g
            | :? Size as s -> Units.Size.value s
            | _ -> "Unknown flex basis"

