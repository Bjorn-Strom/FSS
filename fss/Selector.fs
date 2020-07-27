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
            | Descendant d -> sprintf " %s" (Html.value d)
