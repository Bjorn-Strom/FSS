namespace Fss

open Fable.Core.JsInterop

open FssTypes

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

    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> CssProperty
    let Active (attributeList: CssProperty list) = pseudoValue ":active" attributeList
    let AnyLink (attributeList: CssProperty list) = pseudoValue ":any-link" attributeList
    let Blank (attributeList: CssProperty list) = pseudoValue ":blank" attributeList
    let Checked (attributeList: CssProperty list) = pseudoValue ":checked" attributeList
    let Current (attributeList: CssProperty list) = pseudoValue ":current" attributeList
    let Disabled (attributeList: CssProperty list) = pseudoValue ":disabled" attributeList
    let Empty (attributeList: CssProperty list) = pseudoValue ":empty" attributeList
    let Enabled (attributeList: CssProperty list) = pseudoValue ":enabled" attributeList
    let FirstOfType (attributeList: CssProperty list) = pseudoValue ":first-of-type" attributeList
    let Focus (attributeList: CssProperty list) = pseudoValue ":focus" attributeList
    let FocusVisible (attributeList: CssProperty list) = pseudoValue ":focus-visible" attributeList
    let FocusWithin (attributeList: CssProperty list) = pseudoValue ":focus-within" attributeList
    let Future (attributeList: CssProperty list) = pseudoValue ":future" attributeList
    let Hover (attributeList: CssProperty list) = pseudoValue ":hover" attributeList
    let Indeterminate (attributeList: CssProperty list) = pseudoValue ":indeterminate" attributeList
    let Invalid (attributeList: CssProperty list) = pseudoValue ":invalid" attributeList
    let InRange (attributeList: CssProperty list) = pseudoValue ":in-range" attributeList
    let Lang language (attributeList: CssProperty list) = pseudoValue (sprintf ":lang(%s)" language) attributeList
    let LastChild (attributeList: CssProperty list) = pseudoValue ":last-child" attributeList
    let LastOfType (attributeList: CssProperty list) = pseudoValue ":last-of-type" attributeList
    let LocalLink (attributeList: CssProperty list) = pseudoValue ":local-link" attributeList
    let Link (attributeList: CssProperty list) = pseudoValue ":link" attributeList
    let NthChild (n: INthChild) (attributeList: CssProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastChild n (attributeList: CssProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" n) attributeList
    let NthLastOfType n (attributeList: CssProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" n) attributeList
    let NthOfType (attributeList: CssProperty list) = pseudoValue ":nth-of-type" attributeList
    let OnlyChild (attributeList: CssProperty list) = pseudoValue ":only-child" attributeList
    let OnlyOfType (attributeList: CssProperty list) = pseudoValue ":only-of-type" attributeList
    let Optional (attributeList: CssProperty list) = pseudoValue ":optional" attributeList
    let OutOfRange (attributeList: CssProperty list) = pseudoValue ":out-of-range" attributeList
    let Past (attributeList: CssProperty list) = pseudoValue ":past" attributeList
    let Playing (attributeList: CssProperty list) = pseudoValue ":playing" attributeList
    let Paused (attributeList: CssProperty list) = pseudoValue ":paused" attributeList
    let PlaceholderShown (attributeList: CssProperty list) = pseudoValue ":placeholder-shown" attributeList
    let ReadOnly (attributeList: CssProperty list) = pseudoValue ":read-only" attributeList
    let ReadWrite (attributeList: CssProperty list) = pseudoValue ":read-write" attributeList
    let Required (attributeList: CssProperty list) = pseudoValue ":required" attributeList
    let Root (attributeList: CssProperty list) = pseudoValue ":root" attributeList
    let Scope (attributeList: CssProperty list) = pseudoValue ":scope" attributeList
    let Target (attributeList: CssProperty list) = pseudoValue ":target" attributeList
    let TargetWithin (attributeList: CssProperty list) = pseudoValue ":target-within" attributeList
    let Valid (attributeList: CssProperty list) = pseudoValue ":valid" attributeList
    let Visited (attributeList: CssProperty list) = pseudoValue ":visited" attributeList
    let FirstChild (attributeList: CssProperty list) = pseudoValue ":first-child" attributeList
    let UserInvalid (attributeList: CssProperty list) = pseudoValue ":user-invalid" attributeList
