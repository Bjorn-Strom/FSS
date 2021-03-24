namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoClass =

    let private stringifyNthChild (nthChild: FssTypes.INthChild)=
        match nthChild with
        | :? FssTypes.PseudoClass.NthChildType as n -> Utilities.Helpers.duToLowercase n
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | _ -> "Unknown nth child"

    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> FssTypes.CssProperty
    let Active (attributeList: FssTypes.CssProperty list) = pseudoValue ":active" attributeList
    let AnyLink (attributeList: FssTypes.CssProperty list) = pseudoValue ":any-link" attributeList
    let Blank (attributeList: FssTypes.CssProperty list) = pseudoValue ":blank" attributeList
    let Checked (attributeList: FssTypes.CssProperty list) = pseudoValue ":checked" attributeList
    let Current (attributeList: FssTypes.CssProperty list) = pseudoValue ":current" attributeList
    let Disabled (attributeList: FssTypes.CssProperty list) = pseudoValue ":disabled" attributeList
    let Empty (attributeList: FssTypes.CssProperty list) = pseudoValue ":empty" attributeList
    let Enabled (attributeList: FssTypes.CssProperty list) = pseudoValue ":enabled" attributeList
    let FirstOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":first-of-type" attributeList
    let Focus (attributeList: FssTypes.CssProperty list) = pseudoValue ":focus" attributeList
    let FocusVisible (attributeList: FssTypes.CssProperty list) = pseudoValue ":focus-visible" attributeList
    let FocusWithin (attributeList: FssTypes.CssProperty list) = pseudoValue ":focus-within" attributeList
    let Future (attributeList: FssTypes.CssProperty list) = pseudoValue ":future" attributeList
    let Hover (attributeList: FssTypes.CssProperty list) = pseudoValue ":hover" attributeList
    let Indeterminate (attributeList: FssTypes.CssProperty list) = pseudoValue ":indeterminate" attributeList
    let Invalid (attributeList: FssTypes.CssProperty list) = pseudoValue ":invalid" attributeList
    let InRange (attributeList: FssTypes.CssProperty list) = pseudoValue ":in-range" attributeList
    let Lang language (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":lang(%s)" language) attributeList
    let LastChild (attributeList: FssTypes.CssProperty list) = pseudoValue ":last-child" attributeList
    let LastOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":last-of-type" attributeList
    let LocalLink (attributeList: FssTypes.CssProperty list) = pseudoValue ":local-link" attributeList
    let Link (attributeList: FssTypes.CssProperty list) = pseudoValue ":link" attributeList
    let NthChild (n: FssTypes.INthChild) (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastChild n (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" n) attributeList
    let NthLastOfType n (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" n) attributeList
    let NthOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":nth-of-type" attributeList
    let OnlyChild (attributeList: FssTypes.CssProperty list) = pseudoValue ":only-child" attributeList
    let OnlyOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":only-of-type" attributeList
    let Optional (attributeList: FssTypes.CssProperty list) = pseudoValue ":optional" attributeList
    let OutOfRange (attributeList: FssTypes.CssProperty list) = pseudoValue ":out-of-range" attributeList
    let Past (attributeList: FssTypes.CssProperty list) = pseudoValue ":past" attributeList
    let Playing (attributeList: FssTypes.CssProperty list) = pseudoValue ":playing" attributeList
    let Paused (attributeList: FssTypes.CssProperty list) = pseudoValue ":paused" attributeList
    let PlaceholderShown (attributeList: FssTypes.CssProperty list) = pseudoValue ":placeholder-shown" attributeList
    let ReadOnly (attributeList: FssTypes.CssProperty list) = pseudoValue ":read-only" attributeList
    let ReadWrite (attributeList: FssTypes.CssProperty list) = pseudoValue ":read-write" attributeList
    let Required (attributeList: FssTypes.CssProperty list) = pseudoValue ":required" attributeList
    let Root (attributeList: FssTypes.CssProperty list) = pseudoValue ":root" attributeList
    let Scope (attributeList: FssTypes.CssProperty list) = pseudoValue ":scope" attributeList
    let Target (attributeList: FssTypes.CssProperty list) = pseudoValue ":target" attributeList
    let TargetWithin (attributeList: FssTypes.CssProperty list) = pseudoValue ":target-within" attributeList
    let Valid (attributeList: FssTypes.CssProperty list) = pseudoValue ":valid" attributeList
    let Visited (attributeList: FssTypes.CssProperty list) = pseudoValue ":visited" attributeList
    let FirstChild (attributeList: FssTypes.CssProperty list) = pseudoValue ":first-child" attributeList
    let UserInvalid (attributeList: FssTypes.CssProperty list) = pseudoValue ":user-invalid" attributeList
