namespace FSSTests

open Fet
open Utils
open Fss

module PseudoTests =
     let styles = [ Color.red ]
     let tests =
        testList "Pseudo"
            [
                // let classname, actual = createFss [ Active styles ]
                // testEqual
                //     "Active"
                //     actual
                //     $".{classname}:active{{color:red;}}"
                // let classname, actual = createFss [ AnyLink styles ]
                // testEqual
                //     "AnyLink"
                //     actual
                //     $".{classname}:any-link{{color:red;}}"
                // let classname, actual = createFss [ Blank styles ]
                // testEqual
                //     "Blank"
                //     actual
                //     $".{classname}:blank{{color:red;}}"
                // let classname, actual = createFss [ Checked styles ]
                // testEqual
                //     "Checked"
                //     actual
                //     $".{classname}:checked{{color:red;}}"
                // let classname, actual = createFss [ Current styles ]
                // testEqual
                //     "Current"
                //     actual
                //     $".{classname}:current{{color:red;}}"
                // let classname, actual = createFss [ Disabled styles ]
                // testEqual
                //     "Disabled"
                //     actual
                //     $".{classname}:disabled{{color:red;}}"
                // let classname, actual = createFss [ Empty styles ]
                // testEqual
                //     "Empty"
                //     actual
                //     $".{classname}:empty{{color:red;}}"
                // let classname, actual = createFss [ Enabled styles ]
                // testEqual
                //     "Enabled"
                //     actual
                //     $".{classname}:enabled{{color:red;}}"
                // let classname, actual = createFss [ FirstOfType styles ]
                // testEqual
                //     "FirstOfType"
                //     actual
                //     $".{classname}:first-of-type{{color:red;}}"
                // let classname, actual = createFss [ Focus styles ]
                // testEqual
                //     "Focus"
                //     actual
                //     $".{classname}:focus{{color:red;}}"
                // let classname, actual = createFss [ FocusVisible styles ]
                // testEqual
                //     "FocusVisible"
                //     actual
                //     $".{classname}:focus-visible{{color:red;}}"
                // let classname, actual = createFss [ FocusWithin styles ]
                // testEqual
                //     "FocusWithin"
                //     actual
                //     $".{classname}:focus-within{{color:red;}}"
                // let classname, actual = createFss [ Future styles ]
                // testEqual
                //     "Future"
                //     actual
                //     $".{classname}:future{{color:red;}}"
                // let classname, actual = createFss [ Hover styles ]
                // testEqual
                //     "Hover"
                //     actual
                //     $".{classname}:hover{{color:red;}}"
                // let classname, actual = createFss [ Future styles ]
                // testEqual
                //     "Future"
                //     actual
                //     $".{classname}:future{{color:red;}}"
                // let classname, actual = createFss [ After styles ]
                // testEqual
                //     "After"
                //     actual
                //     $".{classname}::after{{color:red;}}"
                // let classname, actual = createFss [ Before styles ]
                // testEqual
                //     "Before"
                //     actual
                //     $".{classname}::before{{color:red;}}"
                // let classname, actual = createFss [ FirstLetter styles ]
                // testEqual
                //     "FirstLetter"
                //     actual
                //     $".{classname}::first-letter{{color:red;}}"
                // let classname, actual = createFss [ FirstLine styles ]
                // testEqual
                //     "FirstLine"
                //     actual
                //     $".{classname}::first-line{{color:red;}}"
                // let classname, actual = createFss [ Selection styles ]
                // testEqual
                //     "Selection"
                //     actual
                //     $".{classname}::selection{{color:red;}}"
                // let classname, actual = createFss [ Marker styles ]
                // testEqual
                //     "Marker"
                //     actual
                //     $".{classname}::marker{{color:red;}}"
                // let classname, actual = createFss [ Lang("en") styles ]
                // testEqual
                //     "Lang en"
                //     actual
                //     $".{classname}:lang(en){{color:red;}}"
                // let classname, actual = createFss [ NthChild "4" styles ]
                // testEqual
                //     "Nth child 4"
                //     actual
                //     $".{classname}:nth-child(4){{color:red;}}"
                // let classname, actual = createFss [ NthLastChild "4" styles ]
                // testEqual
                //     "Nth last child 4"
                //     actual
                //     $".{classname}:nth-last-child(4){{color:red;}}"
                // let classname, actual = createFss [ NthOfType "4" styles ]
                // testEqual
                //     "Nth of type 4"
                //     actual
                //     $".{classname}:nth-of-type(4){{color:red;}}"
                // let classname, actual = createFss [ NthLastOfType "4" styles ]
                // testEqual
                //     "Nth last of type 4"
                //     actual
                //     $".{classname}:nth-last-of-type(4){{color:red;}}"
                // let classname, actual = createFss [ Placeholder styles ]
                // testEqual
                //     "Placeholder"
                //     actual
                //     $".{classname}::placeholder{{color:red;}}"
            
                let classname, actual = createFss [
                    Class "someClass" [
                        Color.red
                    ]
                ]
                testEqual
                    "Class"
                    actual
                    $".{classname}.someClass{{color:red;}}"
                let classname, actual = createFss [
                    Id "someId" [
                        BackgroundColor.orangeRed
                    ]
                ]
                testEqual
                    "Id"
                    actual
                    $".{classname}#someId{{background-color:orangered;}}"
                let classname, actual = createFss [
                    Not [ Selector.Class "someClass" ] [
                        Display.flex
                    ]
                ]
                testEqual
                    "Not class"
                    actual
                    $".{classname}:not(.someClass){{display:flex;}}"
                let classname, actual = createFss [
                    Not [ Selector.Id "someId" ] [
                        Position.absolute
                    ]
                ]
                testEqual
                    "Not Id"
                    actual
                    $".{classname}:not(#someId){{position:absolute;}}"
                // let classname, actual = createFss [
                //     Not [ Selector.Hover ] [
                //         Display.grid
                //     ]
                // ]
                // testEqual
                //     "Not hover"
                //     actual
                //     $".{classname}:not(:hover){{display:grid;}}"
                let classname, actual = createFss [ Not [ Selector.Active ] [ Color.red ] ]
                testEqual
                    "Not Active"
                    actual
                    $".{classname}:not(:active){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.AnyLink ] [ Color.red ] ]
                testEqual
                    "Not any-link"
                    actual
                    $".{classname}:not(:any-link){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Blank ] [ Color.red ] ]
                testEqual
                    "Not Blank"
                    actual
                    $".{classname}:not(:blank){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Checked ] [ Color.red ] ]
                testEqual
                    "Checked"
                    actual
                    $".{classname}:not(:checked){{color:red;}}"
                // let classname, actual = createFss [ Current styles ]
                // testEqual
                //     "Current"
                //     actual
                //     $".{classname}:current{{color:red;}}"
                // let classname, actual = createFss [ Disabled styles ]
                // testEqual
                //     "Disabled"
                //     actual
                //     $".{classname}:disabled{{color:red;}}"
                // let classname, actual = createFss [ Empty styles ]
                // testEqual
                //     "Empty"
                //     actual
                //     $".{classname}:empty{{color:red;}}"
                // let classname, actual = createFss [ Enabled styles ]
                // testEqual
                //     "Enabled"
                //     actual
                //     $".{classname}:enabled{{color:red;}}"
                // let classname, actual = createFss [ FirstOfType styles ]
                // testEqual
                //     "FirstOfType"
                //     actual
                //     $".{classname}:first-of-type{{color:red;}}"
                // let classname, actual = createFss [ Focus styles ]
                // testEqual
                //     "Focus"
                //     actual
                //     $".{classname}:focus{{color:red;}}"
                // let classname, actual = createFss [ FocusVisible styles ]
                // testEqual
                //     "FocusVisible"
                //     actual
                //     $".{classname}:focus-visible{{color:red;}}"
                // let classname, actual = createFss [ FocusWithin styles ]
                // testEqual
                //     "FocusWithin"
                //     actual
                //     $".{classname}:focus-within{{color:red;}}"
                // let classname, actual = createFss [ Future styles ]
                // testEqual
                //     "Future"
                //     actual
                //     $".{classname}:future{{color:red;}}"
                // let classname, actual = createFss [ Hover styles ]
                // testEqual
                //     "Hover"
                //     actual
                //     $".{classname}:hover{{color:red;}}"
                // let classname, actual = createFss [ Future styles ]
                // testEqual
                //     "Future"
                //     actual
                //     $".{classname}:future{{color:red;}}"
                // let classname, actual = createFss [ After styles ]
                // testEqual
                //     "After"
                //     actual
                //     $".{classname}::after{{color:red;}}"
                // let classname, actual = createFss [ Before styles ]
                // testEqual
                //     "Before"
                //     actual
                //     $".{classname}::before{{color:red;}}"
                // let classname, actual = createFss [ FirstLetter styles ]
                // testEqual
                //     "FirstLetter"
                //     actual
                //     $".{classname}::first-letter{{color:red;}}"
                // let classname, actual = createFss [ FirstLine styles ]
                // testEqual
                //     "FirstLine"
                //     actual
                //     $".{classname}::first-line{{color:red;}}"
                // let classname, actual = createFss [ Selection styles ]
                // testEqual
                //     "Selection"
                //     actual
                //     $".{classname}::selection{{color:red;}}"
                // let classname, actual = createFss [ Marker styles ]
                // testEqual
                //     "Marker"
                //     actual
                //     $".{classname}::marker{{color:red;}}"
                // let classname, actual = createFss [ Lang("en") styles ]
                // testEqual
                //     "Lang en"
                //     actual
                //     $".{classname}:lang(en){{color:red;}}"
                // let classname, actual = createFss [ NthChild "4" styles ]
                // testEqual
                //     "Nth child 4"
                //     actual
                //     $".{classname}:nth-child(4){{color:red;}}"
                // let classname, actual = createFss [ NthLastChild "4" styles ]
                // testEqual
                //     "Nth last child 4"
                //     actual
                //     $".{classname}:nth-last-child(4){{color:red;}}"
                // let classname, actual = createFss [ NthOfType "4" styles ]
                // testEqual
                //     "Nth of type 4"
                //     actual
                //     $".{classname}:nth-of-type(4){{color:red;}}"
                // let classname, actual = createFss [ NthLastOfType "4" styles ]
                // testEqual
                //     "Nth last of type 4"
                //     actual
                //     $".{classname}:nth-last-of-type(4){{color:red;}}"
                // let classname, actual = createFss [ Placeholder styles ]
                // testEqual
                //     "Placeholder"
                //     actual
                //     $".{classname}::placeholder{{color:red;}}"
                
            ]

               //         
               //         Not [ Selector.Class "bla"; Selector.Hover ] [
               //             
               //         ]
               //     ]