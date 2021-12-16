namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Grid =
    /// Specifies position in grid by area name.
    let GridArea =
        GridClasses.GridPosition(Property.GridArea)
    /// Specifies position in grid by column.
    let GridColumn =
        GridClasses.GridPosition(Property.GridColumn)
    /// Specifies start position in grid column.
    let GridColumnStart =
        GridClasses.GridColumn(Property.GridColumnStart)
    /// Specifies end position in grid column.
    let GridColumnEnd =
        GridClasses.GridColumn(Property.GridColumnEnd)
    /// Specifies position in grid by row.
    let GridRow = GridClasses.GridRow(Property.GridRow)
    /// Specifies start position in grid row.
    let GridRowStart =
        GridClasses.GridColumn(Property.GridRowStart)
    /// Specifies end position in grid row.
    let GridRowEnd =
        GridClasses.GridColumn(Property.GridRowEnd)
    /// Specifies gap between rows and column in grid.
    let GridGap = GridClasses.GridTwoGap(Property.GridGap)
    /// Specifies gap between rows in grid.
    let GridRowGap = GridClasses.GridGap(Property.GridRowGap)
    /// Specifies gap between columns in grid.
    let GridColumnGap =
        GridClasses.GridGap(Property.GridColumnGap)
    // Specifies line names and size of grid rows
    let GridTemplateRows =
        GridClasses.GridTemplate(Property.GridTemplateRows)
    // Specifies line names and size of grid columns
    let GridTemplateColumns =
        GridClasses.GridTemplate(Property.GridTemplateColumns)
    /// Defines auto generated grid columns.
    let GridAutoColumns =
        GridClasses.GridAuto(Property.GridAutoColumns)
    /// Defines auto generated grid row.
    let GridAutoRows =
        GridClasses.GridAuto(Property.GridAutoRows)
    /// Specifies how the auto placement algorithm works.
    let GridAutoFlow =
        GridClasses.GridAutoFlow(Property.GridAutoFlow)
    /// Resets grid template area.
    let GridTemplateAreas =
        GridClasses.GridTemplateAreas(Property.GridTemplateAreas)
