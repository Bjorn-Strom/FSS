namespace Fss

namespace Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator
[<RequireQualifiedAccess>]
module SelectorClasses =
    type Selector =
        static member adjacentSibling (html: Html.Html) rules =
            (Property.AdjacentSibling html, Combinator.Combinator rules)
            |> Rule

        static member generalSibling (html: Html.Html) rules =
            (Property.GeneralSibling html, Combinator.Combinator rules)
            |> Rule

        static member child (html: Html.Html) rules =
            (Property.Child html, Combinator.Combinator rules)
            |> Rule

        static member descendant (html: Html.Html) rules =
            (Property.Descendant html, Combinator.Combinator rules)
            |> Rule
