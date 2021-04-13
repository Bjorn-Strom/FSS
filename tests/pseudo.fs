namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Psuedo =
     let someCss = [ Color.red ]
     let someCssName = fss [ Color.red ]
     let tests =
        testList "Psuedo"
            [
                testCase
                    "Psuedo active"
                    [ Active someCss ]
                    [ ":active" ==> someCssName ]
                testCase
                    "AnyLink"
                    [ AnyLink someCss ]
                    [ ":any-link" ==> someCssName]
                testCase
                    "Blank"
                    [ Blank someCss ]
                    [ ":blank" ==> someCssName]
                testCase
                    "Checked"
                    [ Checked someCss ]
                    [ ":checked" ==> someCssName]
                testCase
                    "Current"
                    [ Current someCss ]
                    [ ":current" ==> someCssName]
                testCase
                    "Disabled"
                    [ Disabled someCss ]
                    [ ":disabled" ==> someCssName]
                testCase
                    "Empty"
                    [ Empty someCss ]
                    [ ":empty" ==> someCssName]
                testCase
                    "Enabled"
                    [ Enabled someCss ]
                    [ ":enabled" ==> someCssName]
                testCase
                    "FirstOfType"
                    [ FirstOfType someCss ]
                    [ ":first-of-type" ==> someCssName]
                testCase
                    "Focus"
                    [ Focus someCss ]
                    [ ":focus" ==> someCssName]
                testCase
                    "FocusVisible"
                    [ FocusVisible someCss ]
                    [ ":focus-visible" ==> someCssName]
                testCase
                    "FocusWithin"
                    [ FocusWithin someCss ]
                    [ ":focus-within" ==> someCssName]
                testCase
                    "Future"
                    [ Future someCss ]
                    [ ":future" ==> someCssName]
                testCase
                    "Hover"
                    [ Hover someCss ]
                    [ ":hover" ==> someCssName]
                testCase
                    "Indeterminate"
                    [ Indeterminate someCss ]
                    [ ":indeterminate" ==> someCssName]
                testCase
                    "Invalid"
                    [ Invalid someCss ]
                    [ ":invalid" ==> someCssName]
                testCase
                    "InRange"
                    [ InRange someCss ]
                    [ ":in-range" ==> someCssName]
                testCase
                    "Lang"
                    [ Lang "en" someCss ]
                    [ ":lang(en)" ==> someCssName]
                testCase
                    "LastChild"
                    [ LastChild someCss ]
                    [ ":last-child" ==> someCssName]
                testCase
                    "LastOfType"
                    [ LastOfType someCss ]
                    [ ":last-of-type" ==> someCssName]
                testCase
                    "LocalLink"
                    [ LocalLink someCss ]
                    [ ":local-link" ==> someCssName]
                testCase
                    "Link"
                    [ Link someCss ]
                    [ ":link" ==> someCssName]
                testCase
                    "NthChild 2"
                    [ NthChild (FssTypes.CssInt 2) someCss ]
                    [ ":nth-child(2)" ==> someCssName]
                testCase
                    "NthChild 4n"
                    [ NthChild (FssTypes.CssString "4n") someCss ]
                    [ ":nth-child(4n)" ==> someCssName]
                testCase
                    "NthChild even"
                    [ NthChild FssTypes.PseudoClass.Even someCss ]
                    [ ":nth-child(even)" ==> someCssName]
                testCase
                    "NthChild odd"
                    [ NthChild FssTypes.PseudoClass.Odd someCss ]
                    [ ":nth-child(odd)" ==> someCssName]
                testCase
                    "NthLastChild 2"
                    [ NthLastChild (FssTypes.CssInt 2) someCss ]
                    [ ":nth-last-child(2)" ==> someCssName]
                testCase
                    "NthLastChild 4n"
                    [ NthLastChild (FssTypes.CssString "4n") someCss ]
                    [ ":nth-last-child(4n)" ==> someCssName]
                testCase
                    "NthLastChild even"
                    [ NthLastChild FssTypes.PseudoClass.Even someCss ]
                    [ ":nth-last-child(even)" ==> someCssName]
                testCase
                    "NthLastChild odd"
                    [ NthLastChild FssTypes.PseudoClass.Odd someCss ]
                    [ ":nth-last-child(odd)" ==> someCssName]
                testCase
                    "NthLastOfType 2"
                    [ NthLastOfType (FssTypes.CssInt 2) someCss ]
                    [ ":nth-last-of-type(2)" ==> someCssName]
                testCase
                    "NthLastOfType 4n"
                    [ NthLastOfType (FssTypes.CssString "4n") someCss ]
                    [ ":nth-last-of-type(4n)" ==> someCssName]
                testCase
                    "NthLastOfType even"
                    [ NthLastOfType FssTypes.PseudoClass.Even someCss ]
                    [ ":nth-last-of-type(even)" ==> someCssName]
                testCase
                    "NthLastOfType odd"
                    [ NthLastOfType FssTypes.PseudoClass.Odd someCss ]
                    [ ":nth-last-of-type(odd)" ==> someCssName]
                testCase
                    "NthOfType 2"
                    [ NthOfType (FssTypes.CssInt 2) someCss ]
                    [ ":nth-of-type(2)" ==> someCssName]
                testCase
                    "NthOfType 4n"
                    [ NthOfType (FssTypes.CssString "4n") someCss ]
                    [ ":nth-of-type(4n)" ==> someCssName]
                testCase
                    "NthOfType even"
                    [ NthOfType FssTypes.PseudoClass.Even someCss ]
                    [ ":nth-of-type(even)" ==> someCssName]
                testCase
                    "NthOfType odd"
                    [ NthOfType FssTypes.PseudoClass.Odd someCss ]
                    [ ":nth-of-type(odd)" ==> someCssName]
                testCase
                    "OnlyChild"
                    [ OnlyChild someCss ]
                    [ ":only-child" ==> someCssName]
                testCase
                    "OnlyOfType"
                    [ OnlyOfType someCss ]
                    [ ":only-of-type" ==> someCssName]
                testCase
                    "Optional"
                    [ Optional someCss ]
                    [ ":optional" ==> someCssName]
                testCase
                    "OutOfRange"
                    [ OutOfRange someCss ]
                    [ ":out-of-range" ==> someCssName]
                testCase
                    "Past"
                    [ Past someCss ]
                    [ ":past" ==> someCssName]
                testCase
                    "Playing"
                    [ Playing someCss ]
                    [ ":playing" ==> someCssName]
                testCase
                    "Paused"
                    [ Paused someCss ]
                    [ ":paused" ==> someCssName]
                testCase
                    "PlaceholderShown"
                    [ PlaceholderShown someCss ]
                    [ ":placeholder-shown" ==> someCssName]
                testCase
                    "ReadOnly"
                    [ ReadOnly someCss ]
                    [ ":read-only" ==> someCssName]
                testCase
                    "ReadWrite"
                    [ ReadWrite someCss ]
                    [ ":read-write" ==> someCssName]
                testCase
                    "Required"
                    [ Required someCss ]
                    [ ":required" ==> someCssName]
                testCase
                    "Root"
                    [ Root someCss ]
                    [ ":root" ==> someCssName]
                testCase
                    "Scope"
                    [ Scope someCss ]
                    [ ":scope" ==> someCssName]
                testCase
                    "Target"
                    [ Target someCss ]
                    [ ":target" ==> someCssName]
                testCase
                    "TargetWithin"
                    [ TargetWithin someCss ]
                    [ ":target-within" ==> someCssName]
                testCase
                    "Valid"
                    [ Valid someCss ]
                    [ ":valid" ==> someCssName]
                testCase
                    "Visited"
                    [ Visited someCss ]
                    [ ":visited" ==> someCssName]
                testCase
                    "FirstChild"
                    [ FirstChild someCss ]
                    [ ":first-child" ==> someCssName]
                testCase
                    "UserInvalid"
                    [ UserInvalid someCss ]
                    [ ":user-invalid" ==> someCssName]
                testCase
                    "is div"
                    [ Is [ FssTypes.Html.Div ] someCss ]
                    [ ":is(div)" ==> someCssName]
                testCase
                    "is section article aside nav"
                    [ Is [ FssTypes.Html.Section; FssTypes.Html.Article; FssTypes.Html.Aside; FssTypes.Html.Nav ] someCss ]
                    [ ":is(section, article, aside, nav)" ==> someCssName]
                testCase
                    "After"
                    [After someCss ]
                    ["::after" ==> someCssName]
                testCase
                    "Before"
                    [Before someCss ]
                    ["::before" ==> someCssName]
                testCase
                    "FirstLetter"
                    [FirstLetter someCss]
                    ["::first-letter" ==> someCssName]
                testCase
                    "FirstLine"
                    [FirstLine someCss]
                    ["::first-line" ==> someCssName]
                testCase
                    "Selection"
                    [Selection someCss ]
                    ["::selection" ==> someCssName]
                testCase
                    "Marker"
                    [Marker someCss]
                    ["::marker" ==> someCssName]
            ]