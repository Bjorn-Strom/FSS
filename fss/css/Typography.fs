namespace Fss

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
    let private orphansValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Orphans value
    let private orphansValue' value =
        value
        |> orphansToString
        |> orphansValue
    type Orphans =
        static member Value (orphans: FssTypes.IOrphans) = orphans |> orphansValue'
        static member Inherit = FssTypes.Inherit |> orphansValue'
        static member Initial = FssTypes.Initial |> orphansValue'
        static member Unset = FssTypes.Unset |> orphansValue'

    /// <summary>Specifies minimum number of lines a container must show at bottom.</summary>
    /// <param name="orphans">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Orphans' (orphans: FssTypes.IOrphans) = orphans |> Orphans.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/widows
    let private widowsValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Widows value
    let private widowsValue' value =
        value
        |> widowsToString
        |> widowsValue

    type Widows =
        static member Value (widows: FssTypes.IWidows) = widows |> widowsValue'
        static member Inherit = FssTypes.Inherit |> widowsValue'
        static member Initial = FssTypes.Initial |> widowsValue'
        static member Unset = FssTypes.Unset |> widowsValue'

    /// <summary>Specifies minimum number of lines a container must show at top.</summary>
    /// <param name="widows">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Widows' (widows: FssTypes.IWidows) = widows |> Widows.Value
