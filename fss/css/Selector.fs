namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Selector =
    let (!+) (html: Html.Html) (rules: Rule list) =
        Selector.SelectorClasses.Selector.adjacentSibling html rules
    let (!~) (html: Html.Html) (rules: Rule list) =
        Selector.SelectorClasses.Selector.generalSibling html rules
    let (!>) (html: Html.Html) (rules: Rule list) =
        Selector.SelectorClasses.Selector.child html rules
    let (! ) (html: Html.Html) (rules: Rule list) =
        Selector.SelectorClasses.Selector.descendant html rules
