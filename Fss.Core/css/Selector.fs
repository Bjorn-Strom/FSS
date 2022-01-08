namespace Fss

open Fss.Types

[<AutoOpen>]
module Selector =
    let (!+) (html: Html.Html) (rules: Rule list) = SelectorClasses.Selector.adjacentSibling html rules
    let (!~) (html: Html.Html) (rules: Rule list) = SelectorClasses.Selector.generalSibling html rules
    let (!>) (html: Html.Html) (rules: Rule list) = SelectorClasses.Selector.child html rules
    let (! ) (html: Html.Html) (rules: Rule list) = SelectorClasses.Selector.descendant html rules
