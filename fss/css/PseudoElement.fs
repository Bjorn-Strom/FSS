namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module PseudoElement =
    let After rules = PseudoElement.PseudoElementClasses.PseudoElement.after rules
    let Before rules = PseudoElement.PseudoElementClasses.PseudoElement.before rules
    let FirstLetter rules = PseudoElement.PseudoElementClasses.PseudoElement.firstLetter rules
    let FirstLine rules = PseudoElement.PseudoElementClasses.PseudoElement.firstLine rules
    let Selection rules = PseudoElement.PseudoElementClasses.PseudoElement.selection rules
    let Marker rules = PseudoElement.PseudoElementClasses.PseudoElement.marker rules
