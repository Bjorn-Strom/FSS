namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module ColorSchemeClasses =
    type ColorScheme(property) =
        inherit CssRuleWithNormal(property)
        member this.light = (property, String "light") |> Rule
        member this.dark = (property, String "dark") |> Rule
        member this.lightDark = (property, String "light dark") |> Rule
        member this.darkLight = (property, String "dark light") |> Rule
        member this.onlyLight = (property, String "only light") |> Rule
        member this.onlyDark = (property, String "only dark") |> Rule
