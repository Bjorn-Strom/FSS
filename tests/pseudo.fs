namespace FSSTests

open Fet
open Utils
open Fss

module Psuedo =
     let styles = [ Color.red ]
     let tests =
        testList "Psuedo"
            [
                testPseudoCase
                    "Active"
                    [ Active styles ]
                    (".css-0:active", "color: red;")
                testPseudoCase
                    "AnyLink"
                    [ AnyLink styles ]
                    (".css-0:any-link", "color: red;")
                testPseudoCase
                    "Blank"
                    [ Blank styles ]
                    (".css-0:blank", "color: red;")
                testPseudoCase
                    "Checked"
                    [ Checked styles ]
                    (".css-0:checked", "color: red;")
                testPseudoCase
                    "Current"
                    [ Current styles ]
                    (".css-0:current", "color: red;")
                testPseudoCase
                    "Disabled"
                    [ Disabled styles ]
                    (".css-0:disabled", "color: red;")
                testPseudoCase
                    "Empty"
                    [ Empty styles ]
                    (".css-0:empty", "color: red;")
                testPseudoCase
                    "Enabled"
                    [ Enabled styles ]
                    (".css-0:enabled", "color: red;")
                testPseudoCase
                    "FirstOfType"
                    [ FirstOfType styles ]
                    (".css-0:first-of-type", "color: red;")
                testPseudoCase
                    "Focus"
                    [ Focus styles ]
                    (".css-0:focus", "color: red;")
                testPseudoCase
                    "FocusVisible"
                    [ FocusVisible styles ]
                    (".css-0:focus-visible", "color: red;")
                testPseudoCase
                    "FocusWithin"
                    [ FocusWithin styles ]
                    (".css-0:focus-within", "color: red;")
                testPseudoCase
                    "Future"
                    [ Future styles ]
                    (".css-0:future", "color: red;")
                testPseudoCase
                    "Hover"
                    [ Hover styles ]
                    (".css-0:hover", "color: red;")
                testPseudoCase
                    "Future"
                    [ Future styles ]
                    (".css-0:future", "color: red;")
                testPseudoCase
                    "After"
                    [ After styles ]
                    (".css-0::after", "color: red;")
                testPseudoCase
                    "Before"
                    [ Before styles ]
                    (".css-0::before", "color: red;")
                testPseudoCase
                    "FirstLetter"
                    [ FirstLetter styles ]
                    (".css-0::first-letter", "color: red;")
                testPseudoCase
                    "FirstLine"
                    [ FirstLine styles ]
                    (".css-0::first-line", "color: red;")
                testPseudoCase
                    "Selection"
                    [ Selection styles ]
                    (".css-0::selection", "color: red;")
                testPseudoCase
                    "Marker"
                    [ Marker styles ]
                    (".css-0::marker", "color: red;")
                testPseudoCase
                    "Lang en"
                    [ Lang "en" styles ]
                    (".css-0:lang(en)", "color: red;")
                testPseudoCase
                    "Nth child"
                    [ NthChild "4n" styles ]
                    (".css-0:nth-child(4n)", "color: red;")
                testPseudoCase
                    "Nth last child"
                    [ NthLastChild "4n" styles ]
                    (".css-0:nth-last-child(4n)", "color: red;")
                testPseudoCase
                    "Nth of-type"
                    [ NthOfType "4n" styles ]
                    (".css-0:nth-of-type(4n)", "color: red;")
                testPseudoCase
                    "Nth last of-type"
                    [ NthLastOfType "4n" styles ]
                    (".css-0:nth-last-of-type(4n)", "color: red;")
            ]