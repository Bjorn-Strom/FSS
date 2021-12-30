namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module PseudoElement =
    let After rules = PseudoElementClasses.PseudoElement.after rules
    let Before rules = PseudoElementClasses.PseudoElement.before rules
    let FirstLetter rules = PseudoElementClasses.PseudoElement.firstLetter rules
    let FirstLine rules = PseudoElementClasses.PseudoElement.firstLine rules
    let Selection rules = PseudoElementClasses.PseudoElement.selection rules
    let Marker rules = PseudoElementClasses.PseudoElement.marker rules
