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
                let classname, actual = createFss [ Not [ Selector.onlyChild ] [ Color.red ] ]
                testEqual
                    "Not :only-child"
                    actual
                    $".{classname}:not(:only-child){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.onlyOfType ] [ Color.red ] ]
                testEqual
                    "Not :only-of-type"
                    actual
                    $".{classname}:not(:only-of-type){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.outOfRange ] [ Color.red ] ]
                testEqual
                    "Not :out-of-range"
                    actual
                    $".{classname}:not(:out-of-range){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.past ] [ Color.red ] ]
                testEqual
                    "Not :past"
                    actual
                    $".{classname}:not(:past){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.playing ] [ Color.red ] ]
                testEqual
                    "Not :playing"
                    actual
                    $".{classname}:not(:playing){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.paused ] [ Color.red ] ]
                testEqual
                    "Not :paused"
                    actual
                    $".{classname}:not(:paused){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.placeholderShown ] [ Color.red ] ]
                testEqual
                    "Not :placeholder-shown"
                    actual
                    $".{classname}:not(:placeholder-shown){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.readOnly ] [ Color.red ] ]
                testEqual
                    "Not :read-only"
                    actual
                    $".{classname}:not(:read-only){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.readWrite ] [ Color.red ] ]
                testEqual
                    "Not :read-write"
                    actual
                    $".{classname}:not(:read-write){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.required ] [ Color.red ] ]
                testEqual
                    "Not :required"
                    actual
                    $".{classname}:not(:required){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.root ] [ Color.red ] ] 
                testEqual
                    ":root"
                    actual
                    $".{classname}:not(:root){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.scope ] [ Color.red ] ] 
                testEqual
                    ":scope"
                    actual
                    $".{classname}:not(:scope){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.target ] [ Color.red ] ] 
                testEqual
                    ":target"
                    actual
                    $".{classname}:not(:target){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.targetWithin ] [ Color.red ] ] 
                testEqual
                    ":target-within"
                    actual
                    $".{classname}:not(:target-within){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.valid ] [ Color.red ] ] 
                testEqual
                    ":valid"
                    actual
                    $".{classname}:not(:valid){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.visited ] [ Color.red ] ] 
                testEqual
                    ":visited"
                    actual
                    $".{classname}:not(:visited){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.firstChild ] [ Color.red ] ] 
                testEqual
                    ":first-child"
                    actual
                    $".{classname}:not(:first-child){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.userInvalid ] [ Color.red ] ] 
                testEqual
                    "Not :user-invalid"
                    actual
                    $".{classname}:not(:user-invalid){{color:red;}}"
                let classname, actual = createFss [ Not [ Selector.indeterminate ] [ Color.red ] ] 
                testEqual
                    "Not :indeterminate"
                    actual
                    $".{classname}:not(:indeterminate){{color:red;}}"    
                let classname, actual = createFss [ Not [ Selector.invalid ] [ Color.red ] ] 
                testEqual
                    "Not :invalid"
                    actual
                    $".{classname}:not(:invalid){{color:red;}}"    
                let classname, actual = createFss [ Not [ Selector.inRange ] [ Color.red ] ] 
                testEqual
                    "Not :in-range"
                    actual
                    $".{classname}:not(:in-range){{color:red;}}"    
                let classname, actual = createFss [ Not [ Selector.LastChild ] [ Color.red ] ] 
                testEqual
                    "Not :last-child"
                    actual
                    $".{classname}:not(:last-child){{color:red;}}"    
                let classname, actual = createFss [ Not [ Selector.LastOfType ] [ Color.red ] ] 
                testEqual
                    "Not :last-of-type"
                    actual
                    $".{classname}:not(:last-of-type){{color:red;}}"    
                let classname, actual = createFss [ Not [ Selector.LocalLink ] [ Color.red ] ] 
                testEqual
                    "Not :local-link"
                    actual
                    $".{classname}:not(:local-link){{color:red;}}"    
                let classname, actual = createFss [ Not [ Selector.Link ] [ Color.red ] ] 
                testEqual
                    "Not :link"
                    actual
                    $".{classname}:not(:link){{color:red;}}"    
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
                    "Multiple elements in is"
                    actual
                    $".{classname}:is(.SomeClass,:hover){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.onlyChild ] [ Color.red ] ]
                testEqual
                    "Is :only-child"
                    actual
                    $".{classname}:is(:only-child){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.onlyOfType ] [ Color.red ] ]
                testEqual
                    "Is :only-of-type"
                    actual
                    $".{classname}:is(:only-of-type){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.outOfRange ] [ Color.red ] ]
                testEqual
                    "Is :out-of-range"
                    actual
                    $".{classname}:is(:out-of-range){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.past ] [ Color.red ] ]
                testEqual
                    "Is :past"
                    actual
                    $".{classname}:is(:past){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.playing ] [ Color.red ] ]
                testEqual
                    "Is :playing"
                    actual
                    $".{classname}:is(:playing){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.paused ] [ Color.red ] ]
                testEqual
                    "Is :paused"
                    actual
                    $".{classname}:is(:paused){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.placeholderShown ] [ Color.red ] ]
                testEqual
                    "Is :placeholder-shown"
                    actual
                    $".{classname}:is(:placeholder-shown){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.readOnly ] [ Color.red ] ]
                testEqual
                    "Is :read-only"
                    actual
                    $".{classname}:is(:read-only){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.readWrite ] [ Color.red ] ]
                testEqual
                    "Is :read-write"
                    actual
                    $".{classname}:is(:read-write){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.required ] [ Color.red ] ]
                testEqual
                    "Is :required"
                    actual
                    $".{classname}:is(:required){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.root ] [ Color.red ] ] 
                testEqual
                    ":root"
                    actual
                    $".{classname}:is(:root){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.scope ] [ Color.red ] ] 
                testEqual
                    ":scope"
                    actual
                    $".{classname}:is(:scope){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.target ] [ Color.red ] ] 
                testEqual
                    ":target"
                    actual
                    $".{classname}:is(:target){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.targetWithin ] [ Color.red ] ] 
                testEqual
                    ":target-within"
                    actual
                    $".{classname}:is(:target-within){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.valid ] [ Color.red ] ] 
                testEqual
                    ":valid"
                    actual
                    $".{classname}:is(:valid){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.visited ] [ Color.red ] ] 
                testEqual
                    ":visited"
                    actual
                    $".{classname}:is(:visited){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.firstChild ] [ Color.red ] ] 
                testEqual
                    ":first-child"
                    actual
                    $".{classname}:is(:first-child){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.userInvalid ] [ Color.red ] ] 
                testEqual
                    "Is :user-invalid"
                    actual
                    $".{classname}:is(:user-invalid){{color:red;}}"
                let classname, actual = createFss [ Is [ Selector.indeterminate ] [ Color.red ] ] 
                testEqual
                    "Is :indeterminate"
                    actual
                    $".{classname}:is(:indeterminate){{color:red;}}"    
                let classname, actual = createFss [ Is [ Selector.invalid ] [ Color.red ] ] 
                testEqual
                    "Is :invalid"
                    actual
                    $".{classname}:is(:invalid){{color:red;}}"    
                let classname, actual = createFss [ Is [ Selector.inRange ] [ Color.red ] ] 
                testEqual
                    "Is :in-range"
                    actual
                    $".{classname}:is(:in-range){{color:red;}}"    
                let classname, actual = createFss [ Is [ Selector.LastChild ] [ Color.red ] ] 
                testEqual
                    "Is :last-child"
                    actual
                    $".{classname}:is(:last-child){{color:red;}}"    
                let classname, actual = createFss [ Is [ Selector.LastOfType ] [ Color.red ] ] 
                testEqual
                    "Is :last-of-type"
                    actual
                    $".{classname}:is(:last-of-type){{color:red;}}"    
                let classname, actual = createFss [ Is [ Selector.LocalLink ] [ Color.red ] ] 
                testEqual
                    "Is :local-link"
                    actual
                    $".{classname}:is(:local-link){{color:red;}}"    
                let classname, actual = createFss [ Is [ Selector.Link ] [ Color.red ] ] 
                testEqual
                    "Is :link"
                    actual
                    $".{classname}:is(:link){{color:red;}}"
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
                let classname, actual = createFss [
                    Is [Selector.Tag Fss.Types.Html.Article; Selector.Tag Fss.Types.Html.Section; Selector.Tag Fss.Types.Html.Aside ]  [
                        ! (Selector.Tag Fss.Types.Html.P) [
                            Color.aqua
                        ]
                    ]
                ]
                testEqual
                    ":Is with selector"
                    actual
                    $".{classname}:is(article,section,aside) p{{color:aqua;}}"
                let classname, actual = createFss [
                    ! (Selector.Tag Fss.Types.Html.Article) [
                        ! (Selector.Tag Fss.Types.Html.Section) [
                            Not [ Selector.firstChild ] [
                                Is [Selector.Class "primary"; Selector.Class "secondary"] [
                                    Is [Selector.Tag Fss.Types.Html.H1; Selector.Tag Fss.Types.Html.H2; Selector.Tag Fss.Types.Html.P] [
                                        Color.green
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
                testEqual
                    ":Is with selector"
                    actual
                    $".{classname} article section:not(:first-child):is(.primary,.secondary):is(h1,h2,p){{color:green;}}"
                let classname, actual = createFss [ Where [ Selector.onlyChild ] [ Color.red ] ]
                testEqual
                    "Where :only-child"
                    actual
                    $".{classname}:where(:only-child){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.onlyOfType ] [ Color.red ] ]
                testEqual
                    "Where :only-of-type"
                    actual
                    $".{classname}:where(:only-of-type){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.outOfRange ] [ Color.red ] ]
                testEqual
                    "Where :out-of-range"
                    actual
                    $".{classname}:where(:out-of-range){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.past ] [ Color.red ] ]
                testEqual
                    "Where :past"
                    actual
                    $".{classname}:where(:past){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.playing ] [ Color.red ] ]
                testEqual
                    "Where :playing"
                    actual
                    $".{classname}:where(:playing){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.paused ] [ Color.red ] ]
                testEqual
                    "Where :paused"
                    actual
                    $".{classname}:where(:paused){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.placeholderShown ] [ Color.red ] ]
                testEqual
                    "Where :placeholder-shown"
                    actual
                    $".{classname}:where(:placeholder-shown){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.readOnly ] [ Color.red ] ]
                testEqual
                    "Where :read-only"
                    actual
                    $".{classname}:where(:read-only){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.readWrite ] [ Color.red ] ]
                testEqual
                    "Where :read-write"
                    actual
                    $".{classname}:where(:read-write){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.required ] [ Color.red ] ]
                testEqual
                    "Where :required"
                    actual
                    $".{classname}:where(:required){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.root ] [ Color.red ] ] 
                testEqual
                    ":root"
                    actual
                    $".{classname}:where(:root){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.scope ] [ Color.red ] ] 
                testEqual
                    ":scope"
                    actual
                    $".{classname}:where(:scope){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.target ] [ Color.red ] ] 
                testEqual
                    ":target"
                    actual
                    $".{classname}:where(:target){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.targetWithin ] [ Color.red ] ] 
                testEqual
                    ":target-within"
                    actual
                    $".{classname}:where(:target-within){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.valid ] [ Color.red ] ] 
                testEqual
                    ":valid"
                    actual
                    $".{classname}:where(:valid){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.visited ] [ Color.red ] ] 
                testEqual
                    ":visited"
                    actual
                    $".{classname}:where(:visited){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.firstChild ] [ Color.red ] ] 
                testEqual
                    ":first-child"
                    actual
                    $".{classname}:where(:first-child){{color:red;}}"
                let classname, actual = createFss [ Where [ Selector.userInvalid ] [ Color.red ] ] 
                testEqual
                    "Where :user-invalid"
                    actual
                    $".{classname}:where(:user-invalid){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.onlyChild ] [ Color.red ] ]
                testEqual
                    "Has :only-child"
                    actual
                    $".{classname}:has(:only-child){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.onlyOfType ] [ Color.red ] ]
                testEqual
                    "Has :only-of-type"
                    actual
                    $".{classname}:has(:only-of-type){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.outOfRange ] [ Color.red ] ]
                testEqual
                    "Has :out-of-range"
                    actual
                    $".{classname}:has(:out-of-range){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.past ] [ Color.red ] ]
                testEqual
                    "Has :past"
                    actual
                    $".{classname}:has(:past){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.playing ] [ Color.red ] ]
                testEqual
                    "Has :playing"
                    actual
                    $".{classname}:has(:playing){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.paused ] [ Color.red ] ]
                testEqual
                    "Has :paused"
                    actual
                    $".{classname}:has(:paused){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.placeholderShown ] [ Color.red ] ]
                testEqual
                    "Has :placeholder-shown"
                    actual
                    $".{classname}:has(:placeholder-shown){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.readOnly ] [ Color.red ] ]
                testEqual
                    "Has :read-only"
                    actual
                    $".{classname}:has(:read-only){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.readWrite ] [ Color.red ] ]
                testEqual
                    "Has :read-write"
                    actual
                    $".{classname}:has(:read-write){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.required ] [ Color.red ] ]
                testEqual
                    "Has :required"
                    actual
                    $".{classname}:has(:required){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.root ] [ Color.red ] ] 
                testEqual
                    ":root"
                    actual
                    $".{classname}:has(:root){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.scope ] [ Color.red ] ] 
                testEqual
                    ":scope"
                    actual
                    $".{classname}:has(:scope){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.target ] [ Color.red ] ] 
                testEqual
                    ":target"
                    actual
                    $".{classname}:has(:target){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.targetWithin ] [ Color.red ] ] 
                testEqual
                    ":target-within"
                    actual
                    $".{classname}:has(:target-within){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.valid ] [ Color.red ] ] 
                testEqual
                    ":valid"
                    actual
                    $".{classname}:has(:valid){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.visited ] [ Color.red ] ] 
                testEqual
                    ":visited"
                    actual
                    $".{classname}:has(:visited){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.firstChild ] [ Color.red ] ] 
                testEqual
                    ":first-child"
                    actual
                    $".{classname}:has(:first-child){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.userInvalid ] [ Color.red ] ] 
                testEqual
                    "Has :user-invalid"
                    actual
                    $".{classname}:has(:user-invalid){{color:red;}}"
                let classname, actual = createFss [ Has [ Selector.indeterminate ] [ Color.red ] ] 
                testEqual
                    "Has :indeterminate"
                    actual
                    $".{classname}:has(:indeterminate){{color:red;}}"    
                let classname, actual = createFss [ Has [ Selector.invalid ] [ Color.red ] ] 
                testEqual
                    "Has :invalid"
                    actual
                    $".{classname}:has(:invalid){{color:red;}}"    
                let classname, actual = createFss [ Has [ Selector.inRange ] [ Color.red ] ] 
                testEqual
                    "Has :in-range"
                    actual
                    $".{classname}:has(:in-range){{color:red;}}"    
                let classname, actual = createFss [ Has [ Selector.LastChild ] [ Color.red ] ] 
                testEqual
                    "Has :last-child"
                    actual
                    $".{classname}:has(:last-child){{color:red;}}"    
                let classname, actual = createFss [ Has [ Selector.LastOfType ] [ Color.red ] ] 
                testEqual
                    "Has :last-of-type"
                    actual
                    $".{classname}:has(:last-of-type){{color:red;}}"    
                let classname, actual = createFss [ Has [ Selector.LocalLink ] [ Color.red ] ] 
                testEqual
                    "Has :local-link"
                    actual
                    $".{classname}:has(:local-link){{color:red;}}"    
                let classname, actual = createFss [ Has [ Selector.Link ] [ Color.red ] ] 
                testEqual
                    "Has :link"
                    actual
                    $".{classname}:has(:link){{color:red;}}" 
                let classname, actual = createFss [
                    ! (Selector.Tag Fss.Types.Html.A) [
                        Has [ Selector.Tag Fss.Types.Html.Img; Selector.Tag Fss.Types.Html.Section ] [
                            BorderWidth.value (px 2)
                        ]
                    ]
                ] 
                testEqual
                    "Has child has"
                    actual
                    $".{classname} a:has(img,section){{border-width:2px;}}"
                let classname, actual = createFss [
                    ! (Selector.Tag Fss.Types.Html.Fieldset) [
                        Has [ Selector.required; Selector.invalid ] [
                            !+ (Selector.Tag Fss.Types.Html.Button) [
                                    MatchAttr.Exactly (Fss.Types.Attribute.Type, "submit", [
                                        Cursor.notAllowed
                                    ])
                            ]
                        ]
                    ]
                ] 
                testEqual
                    "Has child and attribute"
                    actual
                    $".{classname} fieldset:has(:required,:invalid) + button[type=\"submit\"]{{cursor:not-allowed;}}"
                let classname, actual = createFss [
                    Has [Selector.Custom "article :first-child"] [
                        MarginBlockStart.value (px 0)
                    ]
                ]
                testEqual
                    "Has with custom escape hatch"
                    actual
                    $".{classname}:has(article :first-child){{margin-block-start:0px;}}"
            ]