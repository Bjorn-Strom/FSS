namespace Fss

[<AutoOpen>]
module Typography =
    let private orphansToString (orphans: Types.IOrphans) =
        match orphans with
        | :? Types.Int as i -> Types.IntToString i
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown orphans"

    let private widowsToString (widows: Types.IWidows) =
        match widows with
        | :? Types.Int as i -> Types.IntToString i
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown widows"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/orphans
    let private orphansValue value = Types.cssValue Types.Property.Orphans value
    let private orphansValue' value =
        value
        |> orphansToString
        |> orphansValue
    type Orphans =
        static member Value (orphans: Types.IOrphans) = orphans |> orphansValue'
        static member Inherit = Types.Inherit |> orphansValue'
        static member Initial = Types.Initial |> orphansValue'
        static member Unset = Types.Unset |> orphansValue'

    /// <summary>Specifies minimum number of lines a container must show at bottom.</summary>
    /// <param name="orphans">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Orphans' (orphans: Types.IOrphans) = orphans |> Orphans.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/widows
    let private widowsValue value = Types.cssValue Types.Property.Widows value
    let private widowsValue' value =
        value
        |> widowsToString
        |> widowsValue

    type Widows =
        static member Value (widows: Types.IWidows) = widows |> widowsValue'
        static member Inherit = Types.Inherit |> widowsValue'
        static member Initial = Types.Initial |> widowsValue'
        static member Unset = Types.Unset |> widowsValue'

    /// <summary>Specifies minimum number of lines a container must show at top.</summary>
    /// <param name="widows">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Widows' (widows: Types.IWidows) = widows |> Widows.Value
