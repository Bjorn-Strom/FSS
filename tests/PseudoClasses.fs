namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module PsuedoClasses =
    let tests =
        testList "Psuedo Classes"
            [
                testNested
                    "Active"
                    [ Active [ BackgroundColor Color.red ] ]
                    [":active" ==> "[backgroundColor,#ff0000]"]

                testNested
                    "AnyLink"
                    [ AnyLink [ FontSize (px 250) ] ]
                    [":any-link" ==> "[fontSize,250px]"]

                testNested
                    "Blank"
                    [ Blank [ BackgroundColor Color.blue ] ]
                    [":blank" ==> "[backgroundColor,#0000ff]"]

                testNested
                    "Checked"
                    [ Checked [ Width (px 25) ] ]
                    [":checked" ==> "[width,25px]"]

                testNested
                    "Disabled"
                    [ Disabled [ Width (px 25) ] ]
                    [":disabled" ==> "[width,25px]"]

                testNested
                    "Empty"
                    [ Empty [ Width (px 25) ] ]
                    [":empty" ==> "[width,25px]"]

                testNested
                    "Enabled"
                    [ Enabled [ Width (px 25) ] ]
                    [":enabled" ==> "[width,25px]"]

                testNested
                    "Hover"
                    [ Hover [ Color Color.red ] ]
                    [":hover" ==> "[color,#ff0000]"]

                testNested
                    "Focus"
                    [ Focus [ BackgroundColor Color.red ] ]
                    [":focus" ==> "[backgroundColor,#ff0000]"]

                testNested
                    "First child"
                    [ FirstChild [ BackgroundColor Color.red ] ]
                    [":first-child" ==> "[backgroundColor,#ff0000]"]

                testNested
                    "First of type"
                    [ FirstOfType [ BackgroundColor Color.red ] ]
                    [":first-of-type" ==> "[backgroundColor,#ff0000]"]

                testNested
                    "Visited"
                    [ Visited [ Color Color.orangeRed ] ]
                    [":visited" ==> "[color,#ff4500]"]

                testNested
                    "Indeterminate"
                    [ Indeterminate [ Color Color.orangeRed ] ]
                    [":indeterminate" ==> "[color,#ff4500]"]

                testNested
                    "Invalid"
                    [ Invalid [ Color Color.orangeRed ] ]
                    [":invalid" ==> "[color,#ff4500]"]

                testNested
                    "Lang(en)"
                    [ Lang("en", [ Color Color.orangeRed ]) ]
                    [":lang(en)" ==> "[color,#ff4500]"]

                testNested
                    "Last child"
                    [ LastChild [ BackgroundColor Color.red ] ]
                    [":last-child" ==> "[backgroundColor,#ff0000]"]

                testNested
                    "Last of type"
                    [ LastOfType [ BackgroundColor Color.red ] ]
                    [":last-of-type" ==> "[backgroundColor,#ff0000]"]

                testNested
                    "Link"
                    [ Link [ FontSize (px 250) ] ]
                    [":link" ==> "[fontSize,250px]"]

                testNested
                    "Nth Child 2"
                    [ NthChild("2", [ FontSize (px 250) ]) ]
                    [":nth-child(2)" ==> "[fontSize,250px]"]

                testNested
                    "Nth Child 4n"
                    [ NthChild("4n", [ FontSize (px 250) ]) ]
                    [":nth-child(4n)" ==> "[fontSize,250px]"]

                testNested
                    "Nth Last Child 2"
                    [ NthLastChild("2", [ FontSize (px 250) ]) ]
                    [":nth-last-child(2)" ==> "[fontSize,250px]"]

                testNested
                    "Nth Last Child 4n"
                    [ NthLastChild("4n", [ FontSize (px 250) ]) ]
                    [":nth-last-child(4n)" ==> "[fontSize,250px]"]

                testNested
                    "Nth Last of type 2"
                    [ NthLastOfType("2", [ FontSize (px 250) ]) ]
                    [":nth-last-of-type(2)" ==> "[fontSize,250px]"]

                testNested
                    "Nth Last last of type 4n"
                    [ NthLastOfType("4n", [ FontSize (px 250) ]) ]
                    [":nth-last-of-type(4n)" ==> "[fontSize,250px]"]

                testNested
                    "Only child"
                    [ OnlyChild [ FontSize (px 250) ] ]
                    [":only-child" ==> "[fontSize,250px]"]

                testNested
                    "Only of type"
                    [ OnlyOfType [ FontSize (px 250) ] ]
                    [":only-of-type" ==> "[fontSize,250px]"]

                testNested
                    "Optional"
                    [ Optional [ FontSize (px 250) ] ]
                    [":optional" ==> "[fontSize,250px]"]

                testNested
                    "Out of range"
                    [ OutOfRange [ BackgroundColor Color.black ] ]
                    [":out-of-range" ==> "[backgroundColor,#000000]"]

                testNested
                    "Read only"
                    [ ReadOnly [ BackgroundColor Color.black ] ]
                    [":read-only" ==> "[backgroundColor,#000000]"]

                testNested
                    "Read write"
                    [ ReadWrite [ BackgroundColor Color.black ] ]
                    [":read-write" ==> "[backgroundColor,#000000]"]

                testNested
                    "Required"
                    [ Required [ BackgroundColor Color.black ] ]
                    [":required" ==> "[backgroundColor,#000000]"]

                testNested
                    "Target"
                    [ Target [ BackgroundColor Color.black ] ]
                    [":target" ==> "[backgroundColor,#000000]"]

                testNested
                    "Visited"
                    [ Visited [ BackgroundColor Color.black ] ]
                    [":visited" ==> "[backgroundColor,#000000]"]

            ]