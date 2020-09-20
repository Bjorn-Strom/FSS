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
        | TableColumnGroup
        | TableHeaderGroup
        | TableRowGroup
        | TableFooterGroup
        | TableRow
        | TableCaption

        | None
        interface IDisplay
        interface IGlobal

    let value (v: IDisplay): string =
        match v with
            | :? Global  as g -> GlobalValue.globalValue g
            | :? Display as d -> duToKebab d
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

    let value (v: IFlexDirection): string =
        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? FlexDirection as f -> duToKebab f
            | _ -> "Unknown flex direction"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-wrap
module FlexWrap =
    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexWrap
        interface IGlobal

    let value (v: IFlexWrap): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? FlexWrap as f -> duToKebab f
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

    let value (v: IJustifyContent): string =
        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? JustifyContent as j -> duToKebab j
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

    let value (v: IAlignItems): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? AlignItems as a -> duToKebab a
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

    let value (v: IAlignContent): string =
        match v with
            | :? Global       as g -> GlobalValue.globalValue g
            | :? AlignContent as a -> duToKebab a
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
            
    let value (v: IAlignSelf): string =
        match v with
            | :? Global    as g -> GlobalValue.globalValue g
            | :? AlignSelf as a -> duToKebab a
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
            | :? Global as g -> GlobalValue.globalValue g
            | :? Order  as o -> orderValue o
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
            | :? Global   as g -> GlobalValue.globalValue g
            | :? FlexGrow as s -> flexGrowValue s
            | _ -> "Unknown flex grow"

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-shrink
module FlexShrink =
    type FlexShrink =
        | Shrink of int
        interface IFlexShrink
        interface IGlobal

    let value (v: IFlexShrink): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? FlexShrink as s -> string s
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
            | :? Global  as g -> GlobalValue.globalValue g
            | :? Size    as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | _ -> "Unknown flex basis"

// https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
module VerticalAlign =
    open Fss.Units.Percent
    open Fss.Units.Size

    type VerticalAlign =
        | Baseline
        | Sub
        | Super
        | TextTop
        | TextBottom
        | Middle
        | Top
        | Bottom
        interface IVerticalAlign

    let value (v: IVerticalAlign): string =
        match v with
            | :? Global        as g -> GlobalValue.globalValue g
            | :? Percent       as p -> Units.Percent.value p
            | :? Size          as s -> Units.Size.value s
            | :? VerticalAlign as v -> duToKebab v
            | _ -> "Unknown margin size"

// https://developer.mozilla.org/en-US/docs/Web/CSS/visibility
module Visibility =
    type Visibility =
        | Visible
        | Hidden
        | Collapse
        interface IVisibility

    let value (v: IVisibility): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Visibility as v -> duToString v
            | _ -> "Unknown margin size"

module Opacity =
    type Opacity = Opacity of float

    let value (Opacity v): string =
        v
        |> clamp 0.0 1.0
        |> string
        
// https://developer.mozilla.org/en-US/docs/Web/CSS/position
module Position =
    type Position =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed

    let value (v: Position) = duToString v
