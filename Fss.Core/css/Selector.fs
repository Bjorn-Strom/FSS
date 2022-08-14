namespace Fss

open Fss.Types

[<AutoOpen>]
module Selector =
    let (!+) (html: Html.Html) (rules: Rule list) = CombinatorClasses.Combinator.adjacentSibling html rules
    let (!~) (html: Html.Html) (rules: Rule list) = CombinatorClasses.Combinator.generalSibling html rules
    let (!>) (html: Html.Html) (rules: Rule list) = CombinatorClasses.Combinator.child html rules
    let (! ) (html: Html.Html) (rules: Rule list) = CombinatorClasses.Combinator.descendant html rules
