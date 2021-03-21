namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoElement =
    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> Types.CssProperty
    type PseudoElement =
        static member AfterElement (attributeList: Types.CssProperty list) = pseudoValue "::after" attributeList
        static member BeforeElement (attributeList: Types.CssProperty list) = pseudoValue "::before" attributeList
        static member FirstLetterElement (attributeList: Types.CssProperty list) = pseudoValue "::first-letter" attributeList
        static member FirstLineElement (attributeList: Types.CssProperty list) = pseudoValue "::first-line" attributeList
        static member SelectionElement (attributeList: Types.CssProperty list) = pseudoValue "::selection" attributeList
        static member MarkerElement (attributeList: Types.CssProperty list) = pseudoValue "::marker" attributeList

    let After       (attributeList: Types.CssProperty list) = PseudoElement.AfterElement attributeList
    let Before      (attributeList: Types.CssProperty list) = PseudoElement.BeforeElement attributeList
    let FirstLetter (attributeList: Types.CssProperty list) = PseudoElement.FirstLetterElement attributeList
    let FirstLine   (attributeList: Types.CssProperty list) = PseudoElement.FirstLineElement attributeList
    let Selection   (attributeList: Types.CssProperty list) = PseudoElement.SelectionElement attributeList
    let Marker      (attributeList: Types.CssProperty list) = PseudoElement.MarkerElement attributeList
