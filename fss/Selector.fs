namespace Fss

module Selector =
    open Utilities.Types

    type Selector =
        | AdjacentSibling of string
        | GeneralSibling of string
        | Child of string
        | Descendant of string
        interface ICSSProperty

    let value (s: Selector): string = 
        match s with
            | Descendant d -> sprintf " %s" d
