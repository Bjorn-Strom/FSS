namespace Fss

open Fable.Core
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
    [<Erase>]
    type PseudoClass =
        static member active (attributeList: FssTypes.CssProperty list) = pseudoValue ":active" attributeList
        static member anyLink (attributeList: FssTypes.CssProperty list) = pseudoValue ":any-link" attributeList
        static member blank (attributeList: FssTypes.CssProperty list) = pseudoValue ":blank" attributeList
        static member ``checked`` (attributeList: FssTypes.CssProperty list) = pseudoValue ":checked" attributeList
        static member current (attributeList: FssTypes.CssProperty list) = pseudoValue ":current" attributeList
        static member disabled (attributeList: FssTypes.CssProperty list) = pseudoValue ":disabled" attributeList
        static member empty (attributeList: FssTypes.CssProperty list) = pseudoValue ":empty" attributeList
        static member enabled (attributeList: FssTypes.CssProperty list) = pseudoValue ":enabled" attributeList
        static member firstOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":first-of-type" attributeList
        static member focus (attributeList: FssTypes.CssProperty list) = pseudoValue ":focus" attributeList
        static member focusVisible (attributeList: FssTypes.CssProperty list) = pseudoValue ":focus-visible" attributeList
        static member focusWithin (attributeList: FssTypes.CssProperty list) = pseudoValue ":focus-within" attributeList
        static member future (attributeList: FssTypes.CssProperty list) = pseudoValue ":future" attributeList
        static member hover (attributeList: FssTypes.CssProperty list) = pseudoValue ":hover" attributeList
        static member indeterminate (attributeList: FssTypes.CssProperty list) = pseudoValue ":indeterminate" attributeList
        static member invalid (attributeList: FssTypes.CssProperty list) = pseudoValue ":invalid" attributeList
        static member inRange (attributeList: FssTypes.CssProperty list) = pseudoValue ":in-range" attributeList
        static member lang language (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":lang(%s)" language) attributeList
        static member lastChild (attributeList: FssTypes.CssProperty list) = pseudoValue ":last-child" attributeList
        static member lastOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":last-of-type" attributeList
        static member localLink (attributeList: FssTypes.CssProperty list) = pseudoValue ":local-link" attributeList
        static member link (attributeList: FssTypes.CssProperty list) = pseudoValue ":link" attributeList
        static member nthChild (n: FssTypes.INthChild) (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
        static member nthLastChild n (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" n) attributeList
        static member nthLastOfType n (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" n) attributeList
        static member nthOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":nth-of-type" attributeList
        static member onlyChild (attributeList: FssTypes.CssProperty list) = pseudoValue ":only-child" attributeList
        static member onlyOfType (attributeList: FssTypes.CssProperty list) = pseudoValue ":only-of-type" attributeList
        static member optional (attributeList: FssTypes.CssProperty list) = pseudoValue ":optional" attributeList
        static member outOfRange (attributeList: FssTypes.CssProperty list) = pseudoValue ":out-of-range" attributeList
        static member past (attributeList: FssTypes.CssProperty list) = pseudoValue ":past" attributeList
        static member playing (attributeList: FssTypes.CssProperty list) = pseudoValue ":playing" attributeList
        static member paused (attributeList: FssTypes.CssProperty list) = pseudoValue ":paused" attributeList
        static member placeholderShown (attributeList: FssTypes.CssProperty list) = pseudoValue ":placeholder-shown" attributeList
        static member readOnly (attributeList: FssTypes.CssProperty list) = pseudoValue ":read-only" attributeList
        static member readWrite (attributeList: FssTypes.CssProperty list) = pseudoValue ":read-write" attributeList
        static member required (attributeList: FssTypes.CssProperty list) = pseudoValue ":required" attributeList
        static member root (attributeList: FssTypes.CssProperty list) = pseudoValue ":root" attributeList
        static member scope (attributeList: FssTypes.CssProperty list) = pseudoValue ":scope" attributeList
        static member target (attributeList: FssTypes.CssProperty list) = pseudoValue ":target" attributeList
        static member targetWithin (attributeList: FssTypes.CssProperty list) = pseudoValue ":target-within" attributeList
        static member valid (attributeList: FssTypes.CssProperty list) = pseudoValue ":valid" attributeList
        static member visited (attributeList: FssTypes.CssProperty list) = pseudoValue ":visited" attributeList
        static member firstChild (attributeList: FssTypes.CssProperty list) = pseudoValue ":first-child" attributeList
        static member userInvalid (attributeList: FssTypes.CssProperty list) = pseudoValue ":user-invalid" attributeList

    let Active (attributeList: FssTypes.CssProperty list) = PseudoClass.active attributeList
    let AnyLink (attributeList: FssTypes.CssProperty list) = PseudoClass.anyLink attributeList
    let Blank (attributeList: FssTypes.CssProperty list) = PseudoClass.blank attributeList
    let Checked (attributeList: FssTypes.CssProperty list) = PseudoClass.``checked`` attributeList
    let Current (attributeList: FssTypes.CssProperty list) = PseudoClass.current attributeList
    let Disabled (attributeList: FssTypes.CssProperty list) = PseudoClass.disabled attributeList
    let Empty (attributeList: FssTypes.CssProperty list) = PseudoClass.empty attributeList
    let Enabled (attributeList: FssTypes.CssProperty list) = PseudoClass.enabled attributeList
    let FirstOfType (attributeList: FssTypes.CssProperty list) = PseudoClass.firstOfType attributeList
    let Focus (attributeList: FssTypes.CssProperty list) = PseudoClass.focus attributeList
    let FocusVisible (attributeList: FssTypes.CssProperty list) = PseudoClass.focusVisible attributeList
    let FocusWithin (attributeList: FssTypes.CssProperty list) = PseudoClass.focusWithin attributeList
    let Future (attributeList: FssTypes.CssProperty list) = PseudoClass.future attributeList
    let Hover (attributeList: FssTypes.CssProperty list) = PseudoClass.hover attributeList
    let Indeterminate (attributeList: FssTypes.CssProperty list) = PseudoClass.indeterminate attributeList
    let Invalid (attributeList: FssTypes.CssProperty list) = PseudoClass.invalid attributeList
    let InRange (attributeList: FssTypes.CssProperty list) = PseudoClass.inRange attributeList
    let Lang language (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":lang(%s)" language) attributeList
    let LastChild (attributeList: FssTypes.CssProperty list) = PseudoClass.lastChild attributeList
    let LastOfType (attributeList: FssTypes.CssProperty list) = PseudoClass.lastOfType attributeList
    let LocalLink (attributeList: FssTypes.CssProperty list) = PseudoClass.localLink attributeList
    let Link (attributeList: FssTypes.CssProperty list) = PseudoClass.link attributeList
    let NthChild (n: FssTypes.INthChild) (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastChild n (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" n) attributeList
    let NthLastOfType n (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" n) attributeList
    let NthOfType (attributeList: FssTypes.CssProperty list) = PseudoClass.nthOfType attributeList
    let OnlyChild (attributeList: FssTypes.CssProperty list) = PseudoClass.onlyChild attributeList
    let OnlyOfType (attributeList: FssTypes.CssProperty list) = PseudoClass.onlyOfType attributeList
    let Optional (attributeList: FssTypes.CssProperty list) = PseudoClass.optional attributeList
    let OutOfRange (attributeList: FssTypes.CssProperty list) = PseudoClass.outOfRange attributeList
    let Past (attributeList: FssTypes.CssProperty list) = PseudoClass.past attributeList
    let Playing (attributeList: FssTypes.CssProperty list) = PseudoClass.playing attributeList
    let Paused (attributeList: FssTypes.CssProperty list) = PseudoClass.paused attributeList
    let PlaceholderShown (attributeList: FssTypes.CssProperty list) = PseudoClass.placeholderShown attributeList
    let ReadOnly (attributeList: FssTypes.CssProperty list) = PseudoClass.readOnly attributeList
    let ReadWrite (attributeList: FssTypes.CssProperty list) = PseudoClass.readWrite attributeList
    let Required (attributeList: FssTypes.CssProperty list) = PseudoClass.required attributeList
    let Root (attributeList: FssTypes.CssProperty list) = PseudoClass.root attributeList
    let Scope (attributeList: FssTypes.CssProperty list) = PseudoClass.scope attributeList
    let Target (attributeList: FssTypes.CssProperty list) = PseudoClass.target attributeList
    let TargetWithin (attributeList: FssTypes.CssProperty list) = PseudoClass.targetWithin attributeList
    let Valid (attributeList: FssTypes.CssProperty list) = PseudoClass.valid attributeList
    let Visited (attributeList: FssTypes.CssProperty list) = PseudoClass.visited attributeList
    let FirstChild (attributeList: FssTypes.CssProperty list) = PseudoClass.firstChild attributeList
    let UserInvalid (attributeList: FssTypes.CssProperty list) = PseudoClass.userInvalid attributeList
