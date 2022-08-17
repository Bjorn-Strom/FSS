namespace Fss
namespace Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator
[<RequireQualifiedAccess>]
module CombinatorClasses =
    type Combinator =
        static member adjacentSibling (selector: Selector) rules =
            (Property.AdjacentSibling selector, CombinatorMaster.CombinatorMaster rules)
            |> Rule

        static member generalSibling (selector: Selector) rules =
            (Property.GeneralSibling selector, CombinatorMaster.CombinatorMaster rules)
            |> Rule

        static member child (selector: Selector) rules =
            (Property.Child selector, CombinatorMaster.CombinatorMaster rules)
            |> Rule

        static member descendant (selector: Selector) rules =
            (Property.Descendant selector, CombinatorMaster.CombinatorMaster rules)
            |> Rule
