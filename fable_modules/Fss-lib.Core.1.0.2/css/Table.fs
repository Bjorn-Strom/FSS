namespace Fss

open Fss.Types

[<AutoOpen>]
module Table =
    /// Specifies which side the caption of a table will be.
    let CaptionSide = TableClasses.CaptionSide(Property.CaptionSide)
    /// Specifies whether or not empty cells should have borders.
    let EmptyCells = TableClasses.EmptyCells(Property.EmptyCells)
    /// Specifies table layout.
    let TableLayout = TableClasses.TableLayout(Property.TableLayout)
