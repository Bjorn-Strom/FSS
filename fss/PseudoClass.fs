namespace Fss

open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoClass =

    let private stringifyNthChild (nthChild: Types.INthChild)=
        match nthChild with
        | :? Types.PseudoClass.NthChildType as n -> Utilities.Helpers.duToLowercase n
        | :? Types.CssString as s -> Types.masterTypeHelpers.StringToString s
        | :? Types.CssInt as i -> Types.masterTypeHelpers.IntToString i
        | _ -> "Unknown nth child"

    let private pseudoValue value attributeList = value ==> (attributeList |> fss) |> Types.CssProperty
    let Active (attributeList: Types.CssProperty list) = pseudoValue ":active" attributeList
    let AnyLink (attributeList: Types.CssProperty list) = pseudoValue ":any-link" attributeList
    let Blank (attributeList: Types.CssProperty list) = pseudoValue ":blank" attributeList
    let Checked (attributeList: Types.CssProperty list) = pseudoValue ":checked" attributeList
    let Current (attributeList: Types.CssProperty list) = pseudoValue ":current" attributeList
    let Disabled (attributeList: Types.CssProperty list) = pseudoValue ":disabled" attributeList
    let Empty (attributeList: Types.CssProperty list) = pseudoValue ":empty" attributeList
    let Enabled (attributeList: Types.CssProperty list) = pseudoValue ":enabled" attributeList
    let FirstOfType (attributeList: Types.CssProperty list) = pseudoValue ":first-of-type" attributeList
    let Focus (attributeList: Types.CssProperty list) = pseudoValue ":focus" attributeList
    let FocusVisible (attributeList: Types.CssProperty list) = pseudoValue ":focus-visible" attributeList
    let FocusWithin (attributeList: Types.CssProperty list) = pseudoValue ":focus-within" attributeList
    let Future (attributeList: Types.CssProperty list) = pseudoValue ":future" attributeList
    let Hover (attributeList: Types.CssProperty list) = pseudoValue ":hover" attributeList
    let Indeterminate (attributeList: Types.CssProperty list) = pseudoValue ":indeterminate" attributeList
    let Invalid (attributeList: Types.CssProperty list) = pseudoValue ":invalid" attributeList
    let InRange (attributeList: Types.CssProperty list) = pseudoValue ":in-range" attributeList
    let Lang language (attributeList: Types.CssProperty list) = pseudoValue (sprintf ":lang(%s)" language) attributeList
    let LastChild (attributeList: Types.CssProperty list) = pseudoValue ":last-child" attributeList
    let LastOfType (attributeList: Types.CssProperty list) = pseudoValue ":last-of-type" attributeList
    let LocalLink (attributeList: Types.CssProperty list) = pseudoValue ":local-link" attributeList
    let Link (attributeList: Types.CssProperty list) = pseudoValue ":link" attributeList
    let NthChild (n: Types.INthChild) (attributeList: Types.CssProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastChild n (attributeList: Types.CssProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" n) attributeList
    let NthLastOfType n (attributeList: Types.CssProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" n) attributeList
    let NthOfType (attributeList: Types.CssProperty list) = pseudoValue ":nth-of-type" attributeList
    let OnlyChild (attributeList: Types.CssProperty list) = pseudoValue ":only-child" attributeList
    let OnlyOfType (attributeList: Types.CssProperty list) = pseudoValue ":only-of-type" attributeList
    let Optional (attributeList: Types.CssProperty list) = pseudoValue ":optional" attributeList
    let OutOfRange (attributeList: Types.CssProperty list) = pseudoValue ":out-of-range" attributeList
    let Past (attributeList: Types.CssProperty list) = pseudoValue ":past" attributeList
    let Playing (attributeList: Types.CssProperty list) = pseudoValue ":playing" attributeList
    let Paused (attributeList: Types.CssProperty list) = pseudoValue ":paused" attributeList
    let PlaceholderShown (attributeList: Types.CssProperty list) = pseudoValue ":placeholder-shown" attributeList
    let ReadOnly (attributeList: Types.CssProperty list) = pseudoValue ":read-only" attributeList
    let ReadWrite (attributeList: Types.CssProperty list) = pseudoValue ":read-write" attributeList
    let Required (attributeList: Types.CssProperty list) = pseudoValue ":required" attributeList
    let Root (attributeList: Types.CssProperty list) = pseudoValue ":root" attributeList
    let Scope (attributeList: Types.CssProperty list) = pseudoValue ":scope" attributeList
    let Target (attributeList: Types.CssProperty list) = pseudoValue ":target" attributeList
    let TargetWithin (attributeList: Types.CssProperty list) = pseudoValue ":target-within" attributeList
    let Valid (attributeList: Types.CssProperty list) = pseudoValue ":valid" attributeList
    let Visited (attributeList: Types.CssProperty list) = pseudoValue ":visited" attributeList
    let FirstChild (attributeList: Types.CssProperty list) = pseudoValue ":first-child" attributeList
    let UserInvalid (attributeList: Types.CssProperty list) = pseudoValue ":user-invalid" attributeList
