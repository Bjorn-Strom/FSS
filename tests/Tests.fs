module Tests

open Fable.Mocha
open Fable.Core.JsInterop



let glamorHowToTests =
    testList "Glamor CSS howto list" [

        testCase "Apply a style to an element" <| fun () ->
            let result = createObj []
            let expected = 
                createObj 
                    [
                        "color" ==> "red"
                    ]
            Expect.equal result expected "Applying style to an element"

        testCase "psuedo classes" <| fun () ->
            let result = createObj []
            let expected =
                createObj
                    [
                        ":hover" ==>
                        createObj
                            [
                                "color" ==> "blue"
                            ]
                    ]
            Expect.equal result expected "Applying psuedoclass"

        testCase "child selectors" <| fun () ->
            let result = createObj []
            let expected = 
                createObj
                    [
                        "display" ==> "block"
                        "& .bold" ==> createObj [ "fontWeight" ==> "bold" ]
                        "& .one" ==> createObj [ "color" ==> "blue" ]
                        ":hover .two" ==> createObj [ "color" ==> "red" ]
                    ]
            Expect.equal result expected "Applying child selectors"

        testCase "siblings" <| fun () ->
            let result = createObj []
            let expected =
                createObj
                    [
                        "& li:first-of-type + li" ==> createObj [ "color" ==> "red" ]
                    ]
            Expect.equal result expected "Sibling selectors"

        testCase "media queries" <| fun () ->
            let result = createObj []
            let expected =
                createObj
                    [
                        "position" ==> "relative"
                        "width" ==> "100%"
                        "maxWidth" ==> 960
                        "margin" ==> "0 auto"
                        "padding" ==> "0 20px"
                        "boxSizing" ==> "border-box"

                        ":after" ==> 
                            createObj
                                [
                                    "content" ==> "\"\""
                                    "display" ==> "table"
                                    "clear" ==> "both"
                                ]

                        "@media(min-width: 400px)" ==>
                            createObj
                                [
                                    "width" ==> "85%"
                                    "padding" ==> 0
                                ]
                    ]
            Expect.equal result expected "Media queries"

        testCase "Animation keyframes" <| fun () ->
            let result = createObj []
            let expected = createObj []
            Expect.equal result expected "animation keyframes"

    ]

Mocha.runTests glamorHowToTests |> ignore