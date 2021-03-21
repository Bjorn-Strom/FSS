namespace Fss
open FssTypes

[<AutoOpen>]
module Typography =
    let private orphansToString (orphans: IOrphans) =
        match orphans with
        | :? CssInt as i -> cssIntToString i
        | :? Global as g -> global' g
        | _ -> "Unknown orphans"

    let private widowsToString (widows: IWidows) =
        match widows with
        | :? CssInt as i -> cssIntToString i
        | :? Global as g -> global' g
        | _ -> "Unknown widows"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/orphans
    let private orphansValue value = PropertyValue.cssValue Property.Orphans value
    let private orphansValue' value =
        value
        |> orphansToString
        |> orphansValue
    type Orphans =
        static member Value (orphans: IOrphans) = orphans |> orphansValue'
        static member Inherit = Inherit |> orphansValue'
        static member Initial = Initial |> orphansValue'
        static member Unset = Unset |> orphansValue'

    /// <summary>Specifies minimum number of lines a container must show at bottom.</summary>
    /// <param name="orphans">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Orphans' (orphans: IOrphans) = orphans |> Orphans.Value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/widows
    let private widowsValue value = PropertyValue.cssValue Property.Widows value
    let private widowsValue' value =
        value
        |> widowsToString
        |> widowsValue

    type Widows =
        static member Value (widows: IWidows) = widows |> widowsValue'
        static member Inherit = Inherit |> widowsValue'
        static member Initial = Initial |> widowsValue'
        static member Unset = Unset |> widowsValue'

    /// <summary>Specifies minimum number of lines a container must show at top.</summary>
    /// <param name="widows">
    ///     can be:
    ///     - <c> CssInt </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Widows' (widows: IWidows) = widows |> Widows.Value
