namespace Fss

open Fable.Core

[<AutoOpen>]
module Typography =
    let private orphansToString (orphans: FssTypes.IOrphans) =
        match orphans with
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown orphans"

    let private widowsToString (widows: FssTypes.IWidows) =
        match widows with
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown widows"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/orphans
    let private orphansValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Orphans
    let private orphansValue' = orphansToString >> orphansValue

    [<Erase>]
    /// Specifies minimum number of lines a container must show at bottom.
    type Orphans =
        static member value (orphans: FssTypes.IOrphans) = orphans |> orphansValue'
        static member inherit' = FssTypes.Inherit |> orphansValue'
        static member initial = FssTypes.Initial |> orphansValue'
        static member unset = FssTypes.Unset |> orphansValue'

    /// Specifies minimum number of lines a container must show at bottom.
    /// Valid parameters:
    /// - CssInt
    /// - Inherit
    /// - Initial
    /// - Unset
    let Orphans' = Orphans.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/widows
    let private widowsValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Widows
    let private widowsValue' = widowsToString >> widowsValue

    [<Erase>]
    /// Specifies minimum number of lines a container must show at top.
    type Widows =
        static member value (widows: FssTypes.IWidows) = widows |> widowsValue'
        static member inherit' = FssTypes.Inherit |> widowsValue'
        static member initial = FssTypes.Initial |> widowsValue'
        static member unset = FssTypes.Unset |> widowsValue'

    /// Specifies minimum number of lines a container must show at top.
    /// Valid parameters:
    /// - CssInt
    /// - Inherit
    /// - Initial
    /// - Unset
    let Widows' = Widows.value
