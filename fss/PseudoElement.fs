namespace Fss

open Fable.Core.JsInterop
open FssTypes

[<AutoOpen>]
module PseudoElement =
    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> CssProperty
    type PseudoElement =
        static member AfterElement (attributeList: CssProperty list) = pseudoValue "::after" attributeList
        static member BeforeElement (attributeList: CssProperty list) = pseudoValue "::before" attributeList
        static member FirstLetterElement (attributeList: CssProperty list) = pseudoValue "::first-letter" attributeList
        static member FirstLineElement (attributeList: CssProperty list) = pseudoValue "::first-line" attributeList
        static member SelectionElement (attributeList: CssProperty list) = pseudoValue "::selection" attributeList
        static member MarkerElement (attributeList: CssProperty list) = pseudoValue "::marker" attributeList

    let After       (attributeList: CssProperty list) = PseudoElement.AfterElement attributeList
    let Before      (attributeList: CssProperty list) = PseudoElement.BeforeElement attributeList
    let FirstLetter (attributeList: CssProperty list) = PseudoElement.FirstLetterElement attributeList
    let FirstLine   (attributeList: CssProperty list) = PseudoElement.FirstLineElement attributeList
    let Selection   (attributeList: CssProperty list) = PseudoElement.SelectionElement attributeList
    let Marker      (attributeList: CssProperty list) = PseudoElement.MarkerElement attributeList
