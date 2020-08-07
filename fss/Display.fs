namespace Fss

open Global
open Types
open Fss.Utilities.Helpers

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
        interface IDisplay
        interface IGlobal


    let private displayValue (v: Display): string = duToKebab v

    let value (v: IDisplay): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Display as d -> displayValue d
            | _ -> "Unknown display"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction      
module FlexDirection =
    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface IFlexDirection
        interface IGlobal

    let private flexDirectionValue (v: FlexDirection): string = duToKebab v

    let value (v: IFlexDirection): string =
        match v with
            | :? Global as g -> Global.value g
            | :? FlexDirection as f -> flexDirectionValue f
            | _ -> "Unknown flex direction"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
module FlexWrap =
    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexWrap
        interface IGlobal

    let private flexWrapValue (v: FlexWrap): string = duToKebab v

    let value (v: IFlexWrap): string =
        match v with
            | :? Global as g -> Global.value g
            | :? FlexWrap as f -> flexWrapValue f
            | _ -> "Unknown flex wrap"

// https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
module JustifyContent =
    type JustifyContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly
        interface IJustifyContent
        interface IGlobal

    let private justifyContentValue (v: JustifyContent): string = duToKebab v

    let value (v: IJustifyContent): string =
        match v with
            | :? Global as g -> Global.value g
            | :? JustifyContent as j -> justifyContentValue j
            | _ -> "Unknown justify content"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
module AlignItems =
    type AlignItems =
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | Stretch
        interface IAlignItems
        interface IGlobal

    let private alignItemsValue (v: AlignItems): string = duToKebab v
    
    let value (v: IAlignItems): string =
        match v with
            | :? Global as g -> Global.value g
            | :? AlignItems as a -> alignItemsValue a
            | _ -> "Unknown align items"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
module AlignContent =

    type AlignContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | Stretch
        interface IAlignContent
        interface IGlobal

    let private alignContentValue (v: AlignContent): string = duToKebab v

    let value (v: IAlignContent): string =
        match v with
            | :? Global as g -> Global.value g
            | :? AlignContent as a -> alignContentValue a
            | _ -> "Unknown align content"

// https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
module AlignSelf =
            
    type AlignSelf = 
        | Auto
        | FlexStart 
        | FlexEnd 
        | Center 
        | Baseline 
        | Stretch
        interface IAlignSelf
        interface IGlobal
            
    let private alignSelfValue (v: AlignSelf): string = duToKebab v

    let value (v: IAlignSelf): string =
        match v with
            | :? Global as g -> Global.value g
            | :? AlignSelf as a -> alignSelfValue a
            | _ -> "Unknown align self"

// https://developer.mozilla.org/en-US/docs/Web/CSS/order
module Order =

    type Order = 
        | Order of int
        interface IOrder
        interface IGlobal

    let private orderValue (Order o): string = string  o

    let value (v: IOrder): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Order as o -> orderValue o
            | _ -> "Unknown order"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
module FlexGrow =

    type FlexGrow = 
        | Grow of int
        interface IFlexGrow
        interface IGlobal

    let private flexGrowValue (Grow f) = string f

    let value (v: IFlexGrow): string =
        match v with
            | :? Global as g -> Global.value g
            | :? FlexGrow as s -> flexGrowValue s
            | _ -> "Unknown flex grow"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
module FlexShrink =
    type FlexShrink =
        | Shrink of int
        interface IFlexShrink
        interface IGlobal

    let private flexShrinkValue (Shrink f) = string f

    let value (v: IFlexShrink): string =
        match v with
            | :? Global as g -> Global.value g
            | :? FlexShrink as s -> flexShrinkValue s
            | _ -> "Unknown flex shrink"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
module FlexBasis =
    open Units.Size
    open Units.Percent

    type FlexBasis = 
        | FlexBasis of Size
        interface IFlexBasis
        interface IGlobal

    let value (v: IFlexBasis): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Size as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | _ -> "Unknown flex basis"

