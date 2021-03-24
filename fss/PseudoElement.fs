namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoElement =
    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> FssTypes.CssProperty
    type PseudoElement =
        static member AfterElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::after" attributeList
        static member BeforeElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::before" attributeList
        static member FirstLetterElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::first-letter" attributeList
        static member FirstLineElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::first-line" attributeList
        static member SelectionElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::selection" attributeList
        static member MarkerElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::marker" attributeList

    let After       (attributeList: FssTypes.CssProperty list) = PseudoElement.AfterElement attributeList
    let Before      (attributeList: FssTypes.CssProperty list) = PseudoElement.BeforeElement attributeList
    let FirstLetter (attributeList: FssTypes.CssProperty list) = PseudoElement.FirstLetterElement attributeList
    let FirstLine   (attributeList: FssTypes.CssProperty list) = PseudoElement.FirstLineElement attributeList
    let Selection   (attributeList: FssTypes.CssProperty list) = PseudoElement.SelectionElement attributeList
    let Marker      (attributeList: FssTypes.CssProperty list) = PseudoElement.MarkerElement attributeList
