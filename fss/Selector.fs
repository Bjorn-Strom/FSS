namespace Fss

module Selector =
    open Utilities.Types
    open Html

    type Selector =
        | AdjacentSibling of Html
        | GeneralSibling of Html
        | Child of Html
        | Descendant of Html
        interface ICSSProperty

    let value (s: Selector): string = 
        match s with
            | Descendant d -> sprintf " %s" (Html.value d)
