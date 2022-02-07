namespace Fss

open Fss.Types

[<AutoOpen>]
module Typography =
    /// Specifies minimum number of lines a container must show at bottom.
    let Orphans = TypographyClasses.Typography(Property.Orphans)
    /// Specifies minimum number of lines a container must show at top.
    let Widows = TypographyClasses.Typography(Property.Widows)
