namespace Fss

open Fable.Core
open Fable.Core.JsInterop

[<AutoOpen>]
module PseudoClass =
    let private stringifyNthChild (nth: FssTypes.INth)=
        match nth with
        | :? FssTypes.PseudoClass.Nth as n -> Utilities.Helpers.duToLowercase n
        | :? FssTypes.CssString as s -> FssTypes.masterTypeHelpers.StringToString s
        | :? FssTypes.CssInt as i -> FssTypes.masterTypeHelpers.IntToString i
        | _ -> "Unknown nth"

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
        static member nthChild (n: FssTypes.INth) (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
        static member nthLastChild (n: FssTypes.INth) (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-child(%s)" (stringifyNthChild n)) attributeList
        static member nthLastOfType (n: FssTypes.INth) (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-last-of-type(%s)" (stringifyNthChild n)) attributeList
        static member nthOfType (n: FssTypes.INth) (attributeList: FssTypes.CssProperty list) = pseudoValue (sprintf ":nth-of-type(%s)" (stringifyNthChild n)) attributeList
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
        static member is (html: FssTypes.Html.Html list, attributeList: FssTypes.CssProperty list) =
            pseudoValue $":is({Utilities.Helpers.combineComma FssTypes.htmlHelpers.htmlToString html})" attributeList

    let Active attributeList = PseudoClass.active attributeList
    let AnyLink attributeList = PseudoClass.anyLink attributeList
    let Blank attributeList = PseudoClass.blank attributeList
    let Checked attributeList = PseudoClass.``checked`` attributeList
    let Current attributeList = PseudoClass.current attributeList
    let Disabled attributeList = PseudoClass.disabled attributeList
    let Empty attributeList = PseudoClass.empty attributeList
    let Enabled attributeList = PseudoClass.enabled attributeList
    let FirstOfType attributeList = PseudoClass.firstOfType attributeList
    let Focus attributeList = PseudoClass.focus attributeList
    let FocusVisible attributeList = PseudoClass.focusVisible attributeList
    let FocusWithin attributeList = PseudoClass.focusWithin attributeList
    let Future attributeList = PseudoClass.future attributeList
    let Hover attributeList = PseudoClass.hover attributeList
    let Indeterminate attributeList = PseudoClass.indeterminate attributeList
    let Invalid attributeList = PseudoClass.invalid attributeList
    let InRange attributeList = PseudoClass.inRange attributeList
    let Lang language attributeList = pseudoValue (sprintf ":lang(%s)" language) attributeList
    let LastChild attributeList = PseudoClass.lastChild attributeList
    let LastOfType attributeList = PseudoClass.lastOfType attributeList
    let LocalLink attributeList = PseudoClass.localLink attributeList
    let Link attributeList = PseudoClass.link attributeList
    let NthChild (n: FssTypes.INth) attributeList = pseudoValue (sprintf ":nth-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastChild (n: FssTypes.INth) attributeList = pseudoValue (sprintf ":nth-last-child(%s)" (stringifyNthChild n)) attributeList
    let NthLastOfType (n: FssTypes.INth) attributeList = pseudoValue (sprintf ":nth-last-of-type(%s)" (stringifyNthChild n)) attributeList
    let NthOfType (n: FssTypes.INth) attributeList = PseudoClass.nthOfType n attributeList
    let OnlyChild attributeList = PseudoClass.onlyChild attributeList
    let OnlyOfType attributeList = PseudoClass.onlyOfType attributeList
    let Optional attributeList = PseudoClass.optional attributeList
    let OutOfRange attributeList = PseudoClass.outOfRange attributeList
    let Past attributeList = PseudoClass.past attributeList
    let Playing attributeList = PseudoClass.playing attributeList
    let Paused attributeList = PseudoClass.paused attributeList
    let PlaceholderShown attributeList = PseudoClass.placeholderShown attributeList
    let ReadOnly attributeList = PseudoClass.readOnly attributeList
    let ReadWrite attributeList = PseudoClass.readWrite attributeList
    let Required attributeList = PseudoClass.required attributeList
    let Root attributeList = PseudoClass.root attributeList
    let Scope attributeList = PseudoClass.scope attributeList
    let Target attributeList = PseudoClass.target attributeList
    let TargetWithin attributeList = PseudoClass.targetWithin attributeList
    let Valid attributeList = PseudoClass.valid attributeList
    let Visited attributeList = PseudoClass.visited attributeList
    let FirstChild attributeList = PseudoClass.firstChild attributeList
    let UserInvalid attributeList = PseudoClass.userInvalid attributeList
    let Is html attributeList = PseudoClass.is(html, attributeList)
