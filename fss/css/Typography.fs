namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Typography =
    /// Specifies minimum number of lines a container must show at bottom.
    let Orphans =
        Typography.TypographyClasses.Typography(Property.Orphans)
    /// Specifies minimum number of lines a container must show at top.
    let Widows =
        Typography.TypographyClasses.Typography(Property.Widows)
