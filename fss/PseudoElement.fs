namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoElement =
    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> FssTypes.CssProperty
    type PseudoElement =
        static member afterElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::after" attributeList
        static member beforeElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::before" attributeList
        static member firstLetterElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::first-letter" attributeList
        static member firstLineElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::first-line" attributeList
        static member selectionElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::selection" attributeList
        static member markerElement (attributeList: FssTypes.CssProperty list) = pseudoValue "::marker" attributeList

    let After       (attributeList: FssTypes.CssProperty list) = PseudoElement.afterElement attributeList
    let Before      (attributeList: FssTypes.CssProperty list) = PseudoElement.beforeElement attributeList
    let FirstLetter (attributeList: FssTypes.CssProperty list) = PseudoElement.firstLetterElement attributeList
    let FirstLine   (attributeList: FssTypes.CssProperty list) = PseudoElement.firstLineElement attributeList
    let Selection   (attributeList: FssTypes.CssProperty list) = PseudoElement.selectionElement attributeList
    let Marker      (attributeList: FssTypes.CssProperty list) = PseudoElement.markerElement attributeList
