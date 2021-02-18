namespace Fss

open Fable.Core.JsInterop
open Fss

[<AutoOpen>]
module PseudoElement =
    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> CSSProperty
    type PseudoElement =
        static member AfterElement (attributeList: CSSProperty list) = pseudoValue "::after" attributeList
        static member BeforeElement (attributeList: CSSProperty list) = pseudoValue "::before" attributeList
        static member FirstLetterElement (attributeList: CSSProperty list) = pseudoValue "::first-letter" attributeList
        static member FirstLineElement (attributeList: CSSProperty list) = pseudoValue "::first-line" attributeList
        static member SelectionElement (attributeList: CSSProperty list) = pseudoValue "::selection" attributeList
        static member MarkerElement (attributeList: CSSProperty list) = pseudoValue "::marker" attributeList

    let After       (attributeList: CSSProperty list) = PseudoElement.AfterElement attributeList
    let Before      (attributeList: CSSProperty list) = PseudoElement.BeforeElement attributeList
    let FirstLetter (attributeList: CSSProperty list) = PseudoElement.FirstLetterElement attributeList
    let FirstLine   (attributeList: CSSProperty list) = PseudoElement.FirstLineElement attributeList
    let Selection   (attributeList: CSSProperty list) = PseudoElement.SelectionElement attributeList
    let Marker      (attributeList: CSSProperty list) = PseudoElement.MarkerElement attributeList
