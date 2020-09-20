namespace Fss

open Global
open Types
open Fss.Utilities.Helpers

module Display =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/display
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
        | TableColumnGroup
        | TableHeaderGroup
        | TableRowGroup
        | TableFooterGroup
        | TableRow
        | TableCaption
        interface IDisplay

module DisplayValue =
    open Display

    let display (v: IDisplay): string =
        match v with
            | :? Global  as g -> GlobalValue.globalValue g
            | :? Display as d -> duToKebab d
            | _ -> "Unknown display"

module Flex =
    open Units.Size

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction      
    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface IFlexDirection

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexWrap

    // https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    type JustifyContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | SpaceEvenly
        interface IJustifyContent

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    type AlignItems =
        | FlexStart
        | FlexEnd
        | Center
        | Baseline
        | Stretch
        interface IAlignItems

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    type AlignContent =
        | FlexStart
        | FlexEnd
        | Center
        | SpaceBetween
        | SpaceAround
        | Stretch
        interface IAlignContent

    // https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    type AlignSelf = 
        | Auto
        | FlexStart 
        | FlexEnd 
        | Center 
        | Baseline 
        | Stretch
        interface IAlignSelf
            
    // https://developer.mozilla.org/en-US/docs/Web/CSS/order
    type Order = 
        | Order of int
        interface IOrder

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-grow
    type FlexGrow = 
        | Grow of int
        interface IFlexGrow

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
    type FlexShrink =
        | Shrink of int
        interface IFlexShrink

    // https://developer.mozilla.org/en-US/docs/Web/CSS/flex-basis
    type FlexBasis = 
        | FlexBasis of Size
        interface IFlexBasis

module FlexValue =
    open Flex
    open Units.Size
    open Units.Percent

    let flexDirection (v: IFlexDirection): string =
        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? FlexDirection as f -> duToKebab f
            | _ -> "Unknown flex direction"

    let flexWrap (v: IFlexWrap): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? FlexWrap as f -> duToKebab f
            | _ -> "Unknown flex wrap"

    let justifyContent (v: IJustifyContent): string =
        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? JustifyContent as j -> duToKebab j
            | _ -> "Unknown justify content"

    let alignItems (v: IAlignItems): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? AlignItems as a -> duToKebab a
            | _ -> "Unknown align items"

    let alignContent (v: IAlignContent): string =
        match v with
            | :? Global       as g -> GlobalValue.globalValue g
            | :? AlignContent as a -> duToKebab a
            | _ -> "Unknown align content"

    let alignSelf (v: IAlignSelf): string =
        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? AlignSelf as a -> duToKebab a
            | _ -> "Unknown align self"

    let order (v: IOrder): string =
        let stringifyOrder (Order o): string = string  o
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Order  as o -> stringifyOrder o
            | _ -> "Unknown order"

    let flexGrow (v: IFlexGrow): string =
        let stringifyFlexGrow (Grow f) = string f
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? FlexGrow as s -> stringifyFlexGrow s
            | _ -> "Unknown flex grow"

    let flexShrink (v: IFlexShrink): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? FlexShrink as s -> string s
            | _ -> "Unknown flex shrink"

    let flexBasis (v: IFlexBasis): string =
        match v with
            | :? Global  as g -> GlobalValue.globalValue g
            | :? Size    as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | _ -> "Unknown flex basis"    