namespace Fss

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
