namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module ContainClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/Reference/Properties/contain
    type Contain(property) =
        inherit CssRuleWithNone(property)
        member this.strict = (property, String "strict") |> Rule
        member this.content = (property, String "content") |> Rule
        member this.size = (property, String "size") |> Rule
        member this.inlineSize = (property, String "inline-size") |> Rule
        member this.layout = (property, String "layout") |> Rule
        member this.style = (property, String "style") |> Rule
        member this.paint = (property, String "paint") |> Rule
        member this.value(values: string list) =
            (property, String(values |> String.concat " ")) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/Reference/Properties/content-visibility
    type ContentVisibility(property) =
        inherit CssRule(property)
        member this.visible = (property, String "visible") |> Rule
        member this.auto = (property, String "auto") |> Rule
        member this.hidden = (property, String "hidden") |> Rule
