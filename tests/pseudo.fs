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
                    $".{classname}:active{{color:red;}}"
                let classname, actual = createFss [ AnyLink styles ]
                testEqual
                    "AnyLink"
                    actual
                    $".{classname}:any-link{{color:red;}}"
                let classname, actual = createFss [ Blank styles ]
                testEqual
                    "Blank"
                    actual
                    $".{classname}:blank{{color:red;}}"
                let classname, actual = createFss [ Checked styles ]
                testEqual
                    "Checked"
                    actual
                    $".{classname}:checked{{color:red;}}"
                let classname, actual = createFss [ Current styles ]
                testEqual
                    "Current"
                    actual
                    $".{classname}:current{{color:red;}}"
                let classname, actual = createFss [ Disabled styles ]
                testEqual
                    "Disabled"
                    actual
                    $".{classname}:disabled{{color:red;}}"
                let classname, actual = createFss [ Empty styles ]
                testEqual
                    "Empty"
                    actual
                    $".{classname}:empty{{color:red;}}"
                let classname, actual = createFss [ Enabled styles ]
                testEqual
                    "Enabled"
                    actual
                    $".{classname}:enabled{{color:red;}}"
                let classname, actual = createFss [ FirstOfType styles ]
                testEqual
                    "FirstOfType"
                    actual
                    $".{classname}:first-of-type{{color:red;}}"
                let classname, actual = createFss [ Focus styles ]
                testEqual
                    "Focus"
                    actual
                    $".{classname}:focus{{color:red;}}"
                let classname, actual = createFss [ FocusVisible styles ]
                testEqual
                    "FocusVisible"
                    actual
                    $".{classname}:focus-visible{{color:red;}}"
                let classname, actual = createFss [ FocusWithin styles ]
                testEqual
                    "FocusWithin"
                    actual
                    $".{classname}:focus-within{{color:red;}}"
                let classname, actual = createFss [ Future styles ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:future{{color:red;}}"
                let classname, actual = createFss [ Hover styles ]
                testEqual
                    "Hover"
                    actual
                    $".{classname}:hover{{color:red;}}"
                let classname, actual = createFss [ Future styles ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:future{{color:red;}}"
                let classname, actual = createFss [ After styles ]
                testEqual
                    "After"
                    actual
                    $".{classname}::after{{color:red;}}"
                let classname, actual = createFss [ Before styles ]
                testEqual
                    "Before"
                    actual
                    $".{classname}::before{{color:red;}}"
                let classname, actual = createFss [ FirstLetter styles ]
                testEqual
                    "FirstLetter"
                    actual
                    $".{classname}::first-letter{{color:red;}}"
                let classname, actual = createFss [ FirstLine styles ]
                testEqual
                    "FirstLine"
                    actual
                    $".{classname}::first-line{{color:red;}}"
                let classname, actual = createFss [ Selection styles ]
                testEqual
                    "Selection"
                    actual
                    $".{classname}::selection{{color:red;}}"
                let classname, actual = createFss [ Marker styles ]
                testEqual
                    "Marker"
                    actual
                    $".{classname}::marker{{color:red;}}"
                let classname, actual = createFss [ Lang("en") styles ]
                testEqual
                    "Lang en"
                    actual
                    $".{classname}:lang(en){{color:red;}}"
                let classname, actual = createFss [ NthChild "4" styles ]
                testEqual
                    "Nth child 4"
                    actual
                    $".{classname}:nth-child(4){{color:red;}}"
                let classname, actual = createFss [ NthLastChild "4" styles ]
                testEqual
                    "Nth last child 4"
                    actual
                    $".{classname}:nth-last-child(4){{color:red;}}"
                let classname, actual = createFss [ NthOfType "4" styles ]
                testEqual
                    "Nth of type 4"
                    actual
                    $".{classname}:nth-of-type(4){{color:red;}}"
                let classname, actual = createFss [ NthLastOfType "4" styles ]
                testEqual
                    "Nth last of type 4"
                    actual
                    $".{classname}:nth-last-of-type(4){{color:red;}}"
                let classname, actual = createFss [ Placeholder styles ]
                testEqual
                    "Placeholder"
                    actual
                    $".{classname}::placeholder{{color:red;}}"
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
                let classname, actual = createFss [
                    Not [ Selector.Hover ] [
                        Display.grid
                    ]
                ]
                testEqual
                    "Not hover"
                    actual
                    $".{classname}:not(:hover){{display:grid;}}"
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
                let classname, actual = createFss [ Not [ Selector.Current ] [ Color.red ] ]
                testEqual
                    "Current"
                    actual
                    $".{classname}:not(:current){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Disabled ] [ Color.red ] ]
                testEqual
                    "Disabled"
                    actual
                    $".{classname}:not(:disabled){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Empty ] [ Color.red ] ]
                testEqual
                    "Empty"
                    actual
                    $".{classname}:not(:empty){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Enabled ] [ Color.red ] ]
                testEqual
                    "Enabled"
                    actual
                    $".{classname}:not(:enabled){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.FirstOfType ] [ Color.red ] ]
                testEqual
                    "FirstOfType"
                    actual
                    $".{classname}:not(:first-of-type){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Focus ] [ Color.red ] ]
                testEqual
                    "Focus"
                    actual
                    $".{classname}:not(:focus){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.FocusVisible ] [ Color.red ] ]
                testEqual
                    "FocusVisible"
                    actual
                    $".{classname}:not(:focus-visible){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.FocusWithin ] [ Color.red ] ]
                testEqual
                    "FocusWithin"
                    actual
                    $".{classname}:not(:focus-within){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Future ] [ Color.red ] ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:not(:future){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Hover ] [ Color.red ] ]
                testEqual
                    "Hover"
                    actual
                    $".{classname}:not(:hover){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Future ] [ Color.red ] ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:not(:future){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Lang("en") ] [ Color.red ] ]
                testEqual
                    "Lang en"
                    actual
                    $".{classname}:not(:lang(en)){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.NthChild "4" ] [ Color.red ] ]
                testEqual
                    "Nth child 4"
                    actual
                    $".{classname}:not(:nth-child(4)){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.NthLastChild "4" ] [ Color.red ] ]
                testEqual
                    "Nth last child 4"
                    actual
                    $".{classname}:not(:nth-last-child(4)){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.NthOfType "4" ] [ Color.red ] ]
                testEqual
                    "Nth of type 4"
                    actual
                    $".{classname}:not(:nth-of-type(4)){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.NthLastOfType "4" ] [ Color.red ] ]
                testEqual
                    "Nth last of type 4"
                    actual
                    $".{classname}:not(:nth-last-of-type(4)){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.Class "SomeClass"; Selector.Hover ] [ Color.red ] ]
                testEqual
                    "Multiple elements in not"
                    actual
                    $".{classname}:not(.SomeClass,:hover){{color:red;}}"
                let classname, actual = createFss [
                    Is [ Selector.Class "someClass" ] [
                        Display.flex
                    ]
                ]
                testEqual
                    "Is class"
                    actual
                    $".{classname}:is(.someClass){{display:flex;}}"
                let classname, actual = createFss [
                    Is [ Selector.Id "someId" ] [
                        Position.absolute
                    ]
                ]
                testEqual
                    "Is Id"
                    actual
                    $".{classname}:is(#someId){{position:absolute;}}"
                let classname, actual = createFss [
                    Is [ Selector.Hover ] [
                        Display.grid
                    ]
                ]
                testEqual
                    "Is hover"
                    actual
                    $".{classname}:is(:hover){{display:grid;}}"
                let classname, actual = createFss [ Is [ Selector.Active ] [ Color.red ] ]
                testEqual
                    "Is Active"
                    actual
                    $".{classname}:is(:active){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.AnyLink ] [ Color.red ] ]
                testEqual
                    "Is any-link"
                    actual
                    $".{classname}:is(:any-link){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Blank ] [ Color.red ] ]
                testEqual
                    "Is Blank"
                    actual
                    $".{classname}:is(:blank){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Checked ] [ Color.red ] ]
                testEqual
                    "Checked"
                    actual
                    $".{classname}:is(:checked){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Current ] [ Color.red ] ]
                testEqual
                    "Current"
                    actual
                    $".{classname}:is(:current){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Disabled ] [ Color.red ] ]
                testEqual
                    "Disabled"
                    actual
                    $".{classname}:is(:disabled){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Empty ] [ Color.red ] ]
                testEqual
                    "Empty"
                    actual
                    $".{classname}:is(:empty){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Enabled ] [ Color.red ] ]
                testEqual
                    "Enabled"
                    actual
                    $".{classname}:is(:enabled){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.FirstOfType ] [ Color.red ] ]
                testEqual
                    "FirstOfType"
                    actual
                    $".{classname}:is(:first-of-type){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Focus ] [ Color.red ] ]
                testEqual
                    "Focus"
                    actual
                    $".{classname}:is(:focus){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.FocusVisible ] [ Color.red ] ]
                testEqual
                    "FocusVisible"
                    actual
                    $".{classname}:is(:focus-visible){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.FocusWithin ] [ Color.red ] ]
                testEqual
                    "FocusWithin"
                    actual
                    $".{classname}:is(:focus-within){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Future ] [ Color.red ] ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:is(:future){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Hover ] [ Color.red ] ]
                testEqual
                    "Hover"
                    actual
                    $".{classname}:is(:hover){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Future ] [ Color.red ] ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:is(:future){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Lang("en") ] [ Color.red ] ]
                testEqual
                    "Lang en"
                    actual
                    $".{classname}:is(:lang(en)){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.NthChild "4" ] [ Color.red ] ]
                testEqual
                    "Nth child 4"
                    actual
                    $".{classname}:is(:nth-child(4)){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.NthLastChild "4" ] [ Color.red ] ]
                testEqual
                    "Nth last child 4"
                    actual
                    $".{classname}:is(:nth-last-child(4)){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.NthOfType "4" ] [ Color.red ] ]
                testEqual
                    "Nth of type 4"
                    actual
                    $".{classname}:is(:nth-of-type(4)){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.NthLastOfType "4" ] [ Color.red ] ]
                testEqual
                    "Nth last of type 4"
                    actual
                    $".{classname}:is(:nth-last-of-type(4)){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.Class "SomeClass"; Selector.Hover ] [ Color.red ] ]
                testEqual
                    "Multiple elements in not"
                    actual
                    $".{classname}:is(.SomeClass,:hover){{color:red;}}"
                let classname, actual = createFss [
                    Where [ Selector.Class "someClass" ] [
                        Display.flex
                    ]
                ]
                testEqual
                    "Where class"
                    actual
                    $".{classname}:where(.someClass){{display:flex;}}"
                let classname, actual = createFss [
                    Where [ Selector.Id "someId" ] [
                        Position.absolute
                    ]
                ]
                testEqual
                    "Where Id"
                    actual
                    $".{classname}:where(#someId){{position:absolute;}}"
                let classname, actual = createFss [
                    Where [ Selector.Hover ] [
                        Display.grid
                    ]
                ]
                testEqual
                    "Where hover"
                    actual
                    $".{classname}:where(:hover){{display:grid;}}"
                let classname, actual = createFss [ Where [ Selector.Active ] [ Color.red ] ]
                testEqual
                    "Where Active"
                    actual
                    $".{classname}:where(:active){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.AnyLink ] [ Color.red ] ]
                testEqual
                    "Where any-link"
                    actual
                    $".{classname}:where(:any-link){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Blank ] [ Color.red ] ]
                testEqual
                    "Where Blank"
                    actual
                    $".{classname}:where(:blank){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Checked ] [ Color.red ] ]
                testEqual
                    "Checked"
                    actual
                    $".{classname}:where(:checked){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Current ] [ Color.red ] ]
                testEqual
                    "Current"
                    actual
                    $".{classname}:where(:current){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Disabled ] [ Color.red ] ]
                testEqual
                    "Disabled"
                    actual
                    $".{classname}:where(:disabled){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Empty ] [ Color.red ] ]
                testEqual
                    "Empty"
                    actual
                    $".{classname}:where(:empty){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Enabled ] [ Color.red ] ]
                testEqual
                    "Enabled"
                    actual
                    $".{classname}:where(:enabled){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.FirstOfType ] [ Color.red ] ]
                testEqual
                    "FirstOfType"
                    actual
                    $".{classname}:where(:first-of-type){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Focus ] [ Color.red ] ]
                testEqual
                    "Focus"
                    actual
                    $".{classname}:where(:focus){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.FocusVisible ] [ Color.red ] ]
                testEqual
                    "FocusVisible"
                    actual
                    $".{classname}:where(:focus-visible){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.FocusWithin ] [ Color.red ] ]
                testEqual
                    "FocusWithin"
                    actual
                    $".{classname}:where(:focus-within){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Future ] [ Color.red ] ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:where(:future){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Hover ] [ Color.red ] ]
                testEqual
                    "Hover"
                    actual
                    $".{classname}:where(:hover){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Future ] [ Color.red ] ]
                testEqual
                    "Future"
                    actual
                    $".{classname}:where(:future){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Lang("en") ] [ Color.red ] ]
                testEqual
                    "Lang en"
                    actual
                    $".{classname}:where(:lang(en)){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.NthChild "4" ] [ Color.red ] ]
                testEqual
                    "Nth child 4"
                    actual
                    $".{classname}:where(:nth-child(4)){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.NthLastChild "4" ] [ Color.red ] ]
                testEqual
                    "Nth last child 4"
                    actual
                    $".{classname}:where(:nth-last-child(4)){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.NthOfType "4" ] [ Color.red ] ]
                testEqual
                    "Nth of type 4"
                    actual
                    $".{classname}:where(:nth-of-type(4)){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.NthLastOfType "4" ] [ Color.red ] ]
                testEqual
                    "Nth last of type 4"
                    actual
                    $".{classname}:where(:nth-last-of-type(4)){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.Class "SomeClass"; Selector.Hover ] [ Color.red ] ]
                testEqual
                    "Multiple elements in not"
                    actual
                    $".{classname}:where(.SomeClass,:hover){{color:red;}}"
            ]