namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Descendant =
    let tests =
        testList "Descendants"
            [
                testNested
                    "Descendant"
                    [ ! Html.P [ BackgroundColor Color.red ] ]
                    [ " p" ==> "[backgroundColor,#ff0000]" ]

                testNested
                    "Child"
                    [ !> Html.P [ BackgroundColor Color.red ] ]
                    [ " > p" ==> "[backgroundColor,#ff0000]" ]

                testNested
                    "Adjacent Sibling"
                    [ !+ Html.P [ BackgroundColor Color.red ] ]
                    [ " + p" ==> "[backgroundColor,#ff0000]" ]

                testNested
                    "General Sibling"
                    [ !~ Html.P [ BackgroundColor Color.red ] ]
                    [ " ~ p" ==> "[backgroundColor,#ff0000]" ]

                testNested
                    "Composed descendants"
                    [
                        ! Html.Div
                            [
                                !> Html.Div
                                    [
                                        !> Html.P
                                            [
                                                !+ Html.P
                                                    [
                                                        Color Color.purple
                                                        FontSize (px 25)
                                                    ]
                                            ]
                                    ]

                            ]
                    ]
                    [ " div" ==> "[ > div,[ > p,[ + p,[color,#800080; fontSize,25px]]]]"]

            ]
