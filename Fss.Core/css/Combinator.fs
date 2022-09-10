namespace Fss

open Fss.Types

[<AutoOpen>]
module Combinator =
    let (!+) (selector: Selector) (rules: Rule list) = CombinatorClasses.Combinator.adjacentSibling selector rules
    let (!~) (selector: Selector) (rules: Rule list) = CombinatorClasses.Combinator.generalSibling selector rules
    let (!>) (selector: Selector) (rules: Rule list) = CombinatorClasses.Combinator.child selector rules
    let (! ) (selector: Selector) (rules: Rule list) = CombinatorClasses.Combinator.descendant selector rules
