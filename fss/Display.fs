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

// https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction      
module FlexDirection =
    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse

    let value (v: FlexDirection): string =
        match v with
        | Row -> "row"
        | RowReverse -> "rowReverse"
        | Column -> "column"
        | ColumnReverse -> "columnReverse"

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
        