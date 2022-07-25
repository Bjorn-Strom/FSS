namespace FSSTests

open Fet
open Utils
open Fss

module PseudoTests =
     let styles = [ Color.red ]
     let createPseudoTest (ruleList: Fss.Types.Rule list) =
         let className, styles = createFss ruleList
         let styles = snd (styles |> List.head)
         
         className, $"{className} {styles}"
         
     let tests =
        testList "Pseudo"
            [
                let classname, actual = createPseudoTest [ Active styles ]
                testEqual
                    "Active"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ AnyLink styles ]
                testEqual
                    "AnyLink"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Blank styles ]
                testEqual
                    "Blank"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Checked styles ]
                testEqual
                    "Checked"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Current styles ]
                testEqual
                    "Current"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Disabled styles ]
                testEqual
                    "Disabled"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Empty styles ]
                testEqual
                    "Empty"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Enabled styles ]
                testEqual
                    "Enabled"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ FirstOfType styles ]
                testEqual
                    "FirstOfType"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Focus styles ]
                testEqual
                    "Focus"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ FocusVisible styles ]
                testEqual
                    "FocusVisible"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ FocusWithin styles ]
                testEqual
                    "FocusWithin"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Future styles ]
                testEqual
                    "Future"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Hover styles ]
                testEqual
                    "Hover"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Future styles ]
                testEqual
                    "Future"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ After styles ]
                testEqual
                    "After"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Before styles ]
                testEqual
                    "Before"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ FirstLetter styles ]
                testEqual
                    "FirstLetter"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ FirstLine styles ]
                testEqual
                    "FirstLine"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Selection styles ]
                testEqual
                    "Selection"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Marker styles ]
                testEqual
                    "Marker"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Lang("en") styles ]
                testEqual
                    "Lang en"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ NthChild "4" styles ]
                testEqual
                    "Nth child 4"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ NthLastChild "4" styles ]
                testEqual
                    "Nth last child 4"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ NthOfType "4" styles ]
                testEqual
                    "Nth of type 4"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ NthLastOfType "4" styles ]
                testEqual
                    "Nth last of type 4"
                    actual
                    $"{classname} {{ color: red; }}"
                let classname, actual = createPseudoTest [ Placeholder styles ]
                testEqual
                    "Placeholder"
                    actual
                    $"{classname} {{ color: red; }}"
            ]