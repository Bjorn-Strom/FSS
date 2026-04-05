namespace FSSTests

open Fet
open Utils
open Fss

module PseudoTests =
     let styles = [ Color.red ]
     let tests =
        testList "Pseudo"
            [
                let classname, actual = createFss [ Active styles ]
                testEqual
                    "Active"
                    actual
                    (sprintf ".%s{&:active{color:red;}}" classname)
                let classname, actual = createFss [ AnyLink styles ]
                testEqual
                    "AnyLink"
                    actual
                    (sprintf ".%s{&:any-link{color:red;}}" classname)
                let classname, actual = createFss [ Blank styles ]
                testEqual
                    "Blank"
                    actual
                    (sprintf ".%s{&:blank{color:red;}}" classname)
                let classname, actual = createFss [ Checked styles ]
                testEqual
                    "Checked"
                    actual
                    (sprintf ".%s{&:checked{color:red;}}" classname)
                let classname, actual = createFss [ Current styles ]
                testEqual
                    "Current"
                    actual
                    (sprintf ".%s{&:current{color:red;}}" classname)
                let classname, actual = createFss [ Disabled styles ]
                testEqual
                    "Disabled"
                    actual
                    (sprintf ".%s{&:disabled{color:red;}}" classname)
                let classname, actual = createFss [ Empty styles ]
                testEqual
                    "Empty"
                    actual
                    (sprintf ".%s{&:empty{color:red;}}" classname)
                let classname, actual = createFss [ Enabled styles ]
                testEqual
                    "Enabled"
                    actual
                    (sprintf ".%s{&:enabled{color:red;}}" classname)
                let classname, actual = createFss [ FirstOfType styles ]
                testEqual
                    "FirstOfType"
                    actual
                    (sprintf ".%s{&:first-of-type{color:red;}}" classname)
                let classname, actual = createFss [ Focus styles ]
                testEqual
                    "Focus"
                    actual
                    (sprintf ".%s{&:focus{color:red;}}" classname)
                let classname, actual = createFss [ FocusVisible styles ]
                testEqual
                    "FocusVisible"
                    actual
                    (sprintf ".%s{&:focus-visible{color:red;}}" classname)
                let classname, actual = createFss [ FocusWithin styles ]
                testEqual
                    "FocusWithin"
                    actual
                    (sprintf ".%s{&:focus-within{color:red;}}" classname)
                let classname, actual = createFss [ Future styles ]
                testEqual
                    "Future"
                    actual
                    (sprintf ".%s{&:future{color:red;}}" classname)
                let classname, actual = createFss [ Hover styles ]
                testEqual
                    "Hover"
                    actual
                    (sprintf ".%s{&:hover{color:red;}}" classname)
                let classname, actual = createFss [ Future styles ]
                testEqual
                    "Future"
                    actual
                    (sprintf ".%s{&:future{color:red;}}" classname)
                let classname, actual = createFss [ After styles ]
                testEqual
                    "After"
                    actual
                    (sprintf ".%s{&::after{color:red;}}" classname)
                let classname, actual = createFss [ Before styles ]
                testEqual
                    "Before"
                    actual
                    (sprintf ".%s{&::before{color:red;}}" classname)
                let classname, actual = createFss [ FirstLetter styles ]
                testEqual
                    "FirstLetter"
                    actual
                    (sprintf ".%s{&::first-letter{color:red;}}" classname)
                let classname, actual = createFss [ FirstLine styles ]
                testEqual
                    "FirstLine"
                    actual
                    (sprintf ".%s{&::first-line{color:red;}}" classname)
                let classname, actual = createFss [ Selection styles ]
                testEqual
                    "Selection"
                    actual
                    (sprintf ".%s{&::selection{color:red;}}" classname)
                let classname, actual = createFss [ Marker styles ]
                testEqual
                    "Marker"
                    actual
                    (sprintf ".%s{&::marker{color:red;}}" classname)
                let classname, actual = createFss [ Lang("en") styles ]
                testEqual
                    "Lang en"
                    actual
                    (sprintf ".%s{&:lang(en){color:red;}}" classname)
                let classname, actual = createFss [ NthChild "4" styles ]
                testEqual
                    "Nth child 4"
                    actual
                    (sprintf ".%s{&:nth-child(4){color:red;}}" classname)
                let classname, actual = createFss [ NthLastChild "4" styles ]
                testEqual
                    "Nth last child 4"
                    actual
                    (sprintf ".%s{&:nth-last-child(4){color:red;}}" classname)
                let classname, actual = createFss [ NthOfType "4" styles ]
                testEqual
                    "Nth of type 4"
                    actual
                    (sprintf ".%s{&:nth-of-type(4){color:red;}}" classname)
                let classname, actual = createFss [ NthLastOfType "4" styles ]
                testEqual
                    "Nth last of type 4"
                    actual
                    (sprintf ".%s{&:nth-last-of-type(4){color:red;}}" classname)
                let classname, actual = createFss [ Placeholder styles ]
                testEqual
                    "Placeholder"
                    actual
                    (sprintf ".%s{&::placeholder{color:red;}}" classname)
                let classname, actual = createFss [ Scoped styles ]
                testEqual
                    "Scoped"
                    actual
                    (sprintf ".%s{&:scope{color:red;}}" classname)
                let classname, actual = createFss [ Has [Selector.Class "foo"] styles ]
                testEqual
                    "Has"
                    actual
                    (sprintf ".%s{&:has(.foo){color:red;}}" classname)
                let classname, actual = createFss [ Is [Selector.h1; Selector.h2; Selector.h3] styles ]
                testEqual
                    "Is"
                    actual
                    (sprintf ".%s{&:is(h1,h2,h3){color:red;}}" classname)
                let classname, actual = createFss [ Where [Selector.Class "card"; Selector.Class "panel"] styles ]
                testEqual
                    "Where"
                    actual
                    (sprintf ".%s{&:where(.card,.panel){color:red;}}" classname)
            ]
