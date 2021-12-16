namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Table =
    /// Specifies which side the caption of a table will be.
    let CaptionSide =
        Table.TableClasses.CaptionSide(Property.CaptionSide)
    /// Specifies whether or not empty cells should have borders.
    let EmptyCells =
        Table.TableClasses.EmptyCells(Property.EmptyCells)
    /// Specifies table layout.
    let TableLayout =
        Table.TableClasses.TableLayout(Property.TableLayout)
