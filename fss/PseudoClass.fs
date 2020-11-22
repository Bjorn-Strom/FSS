namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoClass =
    type NthChildType =
        | Odd
        | Even
        interface INthChild

    let private stringifyNthChild (nthChild: INthChild)=
        let stringifyNthChild =
            function
                | Odd -> "odd"
                | Even -> "even"

        match nthChild with
        | :? NthChildType as n -> stringifyNthChild n
        | :? CssString as s -> GlobalValue.string s
        | :? CssInt as i -> GlobalValue.int i

    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> CSSProperty
    let Active (attributeList: CSSProperty list) = pseudoValue ":active" attributeList
    let AnyLink (attributeList: CSSProperty list) = pseudoValue ":any-link" attributeList
    let Blank (attributeList: CSSProperty list) = pseudoValue ":blank" attributeList
    let Checked (attributeList: CSSProperty list) = pseudoValue ":checked" attributeList
    let Disabled (attributeList: CSSProperty list) = pseudoValue ":disabled" attributeList
    let Empty (attributeList: CSSProperty list) = pseudoValue ":empty" attributeList
    let Enabled (attributeList: CSSProperty list) = pseudoValue ":enabled" attributeList
    let FirstOfType (attributeList: CSSProperty list) = pseudoValue ":first-of-type" attributeList
    let Focus (attributeList: CSSProperty list) = pseudoValue ":focus" attributeList
    let Hover (attributeList: CSSProperty list) = pseudoValue ":hover" attributeList
    let Indeterminate (attributeList: CSSProperty list) = pseudoValue ":indeterminate" attributeList
    let Invalid (attributeList: CSSProperty list) = pseudoValue ":invalid" attributeList
    let Lang language (attributeList: CSSProperty list) = pseudoValue (sprintf ":lang(%s)" language) attributeList
    let LastChild (attributeList: CSSProperty list) = pseudoValue ":last-child" attributeList
    let LastOfType (attributeList: CSSProperty list) = pseudoValue ":last-of-type" attributeList
    let Link (attributeList: CSSProperty list) = pseudoValue ":link" attributeList
    let NthChild (n: INthChild) (attributeList: CSSProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastChild n (attributeList: CSSProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" n) attributeList
    let NthLastOfType n (attributeList: CSSProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" n) attributeList
    let NthOfType (attributeList: CSSProperty list) = pseudoValue ":nth-of-type" attributeList
    let OnlyChild (attributeList: CSSProperty list) = pseudoValue ":only-child" attributeList
    let OnlyOfType (attributeList: CSSProperty list) = pseudoValue ":only-of-type" attributeList
    let Optional (attributeList: CSSProperty list) = pseudoValue ":optional" attributeList
    let OutOfRange (attributeList: CSSProperty list) = pseudoValue ":out-of-range" attributeList
    let ReadOnly (attributeList: CSSProperty list) = pseudoValue ":read-only" attributeList
    let ReadWrite (attributeList: CSSProperty list) = pseudoValue ":read-write" attributeList
    let Required (attributeList: CSSProperty list) = pseudoValue ":required" attributeList
    let Target (attributeList: CSSProperty list) = pseudoValue ":target" attributeList
    let Valid (attributeList: CSSProperty list) = pseudoValue ":valid" attributeList
    let Visited (attributeList: CSSProperty list) = pseudoValue ":visited" attributeList
    let FirstChild (attributeList: CSSProperty list) = pseudoValue ":first-child" attributeList