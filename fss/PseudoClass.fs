namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoClass =
    type NthChildType =
        | Odd
        | Even
        interface INthChild

    let private stringifyNthChild (nthChild: INthChild)=
        match nthChild with
        | :? NthChildType as n -> Utilities.Helpers.duToLowercase n
        | :? CssString as s -> GlobalValue.string s
        | :? CssInt as i -> GlobalValue.int i
        | _ -> "Unknown nth child"

    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> CSSProperty
    let Active (attributeList: CSSProperty list) = pseudoValue ":active" attributeList
    let AnyLink (attributeList: CSSProperty list) = pseudoValue ":any-link" attributeList
    let Blank (attributeList: CSSProperty list) = pseudoValue ":blank" attributeList
    let Checked (attributeList: CSSProperty list) = pseudoValue ":checked" attributeList
    let Current (attributeList: CSSProperty list) = pseudoValue ":current" attributeList
    let Disabled (attributeList: CSSProperty list) = pseudoValue ":disabled" attributeList
    let Empty (attributeList: CSSProperty list) = pseudoValue ":empty" attributeList
    let Enabled (attributeList: CSSProperty list) = pseudoValue ":enabled" attributeList
    let FirstOfType (attributeList: CSSProperty list) = pseudoValue ":first-of-type" attributeList
    let Focus (attributeList: CSSProperty list) = pseudoValue ":focus" attributeList
    let FocusVisible (attributeList: CSSProperty list) = pseudoValue ":focus-visible" attributeList
    let FocusWithin (attributeList: CSSProperty list) = pseudoValue ":focus-within" attributeList
    let Future (attributeList: CSSProperty list) = pseudoValue ":future" attributeList
    let Hover (attributeList: CSSProperty list) = pseudoValue ":hover" attributeList
    let Indeterminate (attributeList: CSSProperty list) = pseudoValue ":indeterminate" attributeList
    let Invalid (attributeList: CSSProperty list) = pseudoValue ":invalid" attributeList
    let InRange (attributeList: CSSProperty list) = pseudoValue ":in-range" attributeList
    let Lang language (attributeList: CSSProperty list) = pseudoValue (sprintf ":lang(%s)" language) attributeList
    let LastChild (attributeList: CSSProperty list) = pseudoValue ":last-child" attributeList
    let LastOfType (attributeList: CSSProperty list) = pseudoValue ":last-of-type" attributeList
    let LocalLink (attributeList: CSSProperty list) = pseudoValue ":local-link" attributeList
    let Link (attributeList: CSSProperty list) = pseudoValue ":link" attributeList
    let NthChild (n: INthChild) (attributeList: CSSProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastChild n (attributeList: CSSProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" n) attributeList
    let NthLastOfType n (attributeList: CSSProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" n) attributeList
    let NthOfType (attributeList: CSSProperty list) = pseudoValue ":nth-of-type" attributeList
    let OnlyChild (attributeList: CSSProperty list) = pseudoValue ":only-child" attributeList
    let OnlyOfType (attributeList: CSSProperty list) = pseudoValue ":only-of-type" attributeList
    let Optional (attributeList: CSSProperty list) = pseudoValue ":optional" attributeList
    let OutOfRange (attributeList: CSSProperty list) = pseudoValue ":out-of-range" attributeList
    let Past (attributeList: CSSProperty list) = pseudoValue ":past" attributeList
    let Playing (attributeList: CSSProperty list) = pseudoValue ":playing" attributeList
    let Paused (attributeList: CSSProperty list) = pseudoValue ":paused" attributeList
    let PlaceholderShown (attributeList: CSSProperty list) = pseudoValue ":placeholder-shown" attributeList
    let ReadOnly (attributeList: CSSProperty list) = pseudoValue ":read-only" attributeList
    let ReadWrite (attributeList: CSSProperty list) = pseudoValue ":read-write" attributeList
    let Required (attributeList: CSSProperty list) = pseudoValue ":required" attributeList
    let Root (attributeList: CSSProperty list) = pseudoValue ":root" attributeList
    let Scope (attributeList: CSSProperty list) = pseudoValue ":scope" attributeList
    let Target (attributeList: CSSProperty list) = pseudoValue ":target" attributeList
    let TargetWithin (attributeList: CSSProperty list) = pseudoValue ":target-within" attributeList
    let Valid (attributeList: CSSProperty list) = pseudoValue ":valid" attributeList
    let Visited (attributeList: CSSProperty list) = pseudoValue ":visited" attributeList
    let FirstChild (attributeList: CSSProperty list) = pseudoValue ":first-child" attributeList
    let UserInvalid (attributeList: CSSProperty list) = pseudoValue ":user-invalid" attributeList
