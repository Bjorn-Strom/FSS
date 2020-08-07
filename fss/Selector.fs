namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator

module Selector =
    open Html

    type Selector =
        | AdjacentSibling of Html
        | GeneralSibling of Html
        | Child of Html
        | Descendant of Html

    let value (s: Selector): string = 
        match s with
            | AdjacentSibling s -> sprintf " + %s" (Html.value s)
            | GeneralSibling  s -> sprintf " ~ %s" (Html.value s)
            | Child           c -> sprintf " > %s" (Html.value c)
            | Descendant      d -> sprintf " %s" (Html.value d)
