namespace Fss
namespace Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator
[<RequireQualifiedAccess>]
module CombinatorClasses =
    type Combinator =
        static member adjacentSibling (html: Html.Html) rules =
            (Property.AdjacentSibling html, CombinatorMaster.CombinatorMaster rules)
            |> Rule

        static member generalSibling (html: Html.Html) rules =
            (Property.GeneralSibling html, CombinatorMaster.CombinatorMaster rules)
            |> Rule

        static member child (html: Html.Html) rules =
            (Property.Child html, CombinatorMaster.CombinatorMaster rules)
            |> Rule

        static member descendant (html: Html.Html) rules =
            (Property.Descendant html, CombinatorMaster.CombinatorMaster rules)
            |> Rule
