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
                    "color: red;"
                testPseudoCase
                    "AnyLink"
                    [ AnyLink styles ]
                    "color: red;"
                testPseudoCase
                    "Blank"
                    [ Blank styles ]
                    "color: red;"
                testPseudoCase
                    "Checked"
                    [ Checked styles ]
                    "color: red;"
                testPseudoCase
                    "Current"
                    [ Current styles ]
                    "color: red;"
                testPseudoCase
                    "Disabled"
                    [ Disabled styles ]
                    "color: red;"
                testPseudoCase
                    "Empty"
                    [ Empty styles ]
                    "color: red;"
                testPseudoCase
                    "Enabled"
                    [ Enabled styles ]
                    "color: red;"
                testPseudoCase
                    "FirstOfType"
                    [ FirstOfType styles ]
                    "color: red;"
                testPseudoCase
                    "Focus"
                    [ Focus styles ]
                    "color: red;"
                testPseudoCase
                    "FocusVisible"
                    [ FocusVisible styles ]
                    "color: red;"
                testPseudoCase
                    "FocusWithin"
                    [ FocusWithin styles ]
                    "color: red;"
                testPseudoCase
                    "Future"
                    [ Future styles ]
                    "color: red;"
                testPseudoCase
                    "Hover"
                    [ Hover styles ]
                    "color: red;"
                testPseudoCase
                    "Future"
                    [ Future styles ]
                    "color: red;"
                testPseudoCase
                    "After"
                    [ After styles ]
                    "color: red;"
                testPseudoCase
                    "Before"
                    [ Before styles ]
                    "color: red;"
                testPseudoCase
                    "FirstLetter"
                    [ FirstLetter styles ]
                    "color: red;"
                testPseudoCase
                    "FirstLine"
                    [ FirstLine styles ]
                    "color: red;"
                testPseudoCase
                    "Selection"
                    [ Selection styles ]
                    "color: red;"
                testPseudoCase
                    "Marker"
                    [ Marker styles ]
                    "color: red;"
            ]