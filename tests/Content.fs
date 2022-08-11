﻿namespace FSSTests

open Fet
open Utils
open Fss

module ContentTests =
    let counterName, counterStyle =
        createCounterStyle [
            System.symbolic
        ]

    let tests =
        testList "Content"
            [
                testCase
                    "Content normal"
                    [ Content.normal ]
                    "{content:normal;}"
                testCase
                    "Content none"
                    [ Content.none ]
                    "{content:none;}"
                testCase
                    "Content image"
                    [ Content.url "http://www.example.com/test.png" ]
                    "{content:url(http://www.example.com/test.png);}"
                testCase
                    "Content image with alt text"
                    [ Content.url("http://www.example.com/test.png", "this is the alt text") ]
                    "{content:url(http://www.example.com/test.png) / \"this is the alt text\";}"
                testCase
                    "Content linear gradient"
                    [ Content.linearGradient((deg 45.0, [hex "e66456", px 0; hex "9198e5", px 100])) ]
                    "{content:linear-gradient(45deg,#e66456 0px,#9198e5 100px);}"
                testCase
                    "Content string value"
                    [ Content.value "prefix"]
                    "{content:\"prefix\";}"
                testCase
                    "Content counter"
                    [ Content.counter counterName]
                    $"{{content:counter({counterName});}}"
                testCase
                    "Content counter2"
                    [ Content.counter (counterName, ". ")]
                    $"{{content:counter({counterName})\". \";}}"
                testCase
                    "Content attribute"
                    [ Content.attribute Fss.Types.Attribute.Title ]
                    "{content:attr(title);}"
                testCase
                    "Content open quote"
                    [ Content.openQuote ]
                    "{content:open-quote;}"
                testCase
                    "Content close quote"
                    [ Content.closeQuote ]
                    "{content:close-quote;}"
                testCase
                    "Content no open quote"
                    [ Content.noOpenQuote ]
                    "{content:no-open-quote;}"
                testCase
                    "Content no close quote"
                    [ Content.noCloseQuote ]
                    "{content:no-close-quote;}"
                testCase
                    "Content inherit"
                    [ Content.inherit' ]
                    "{content:inherit;}"
                testCase
                    "Content initial"
                    [ Content.initial ]
                    "{content:initial;}"
                testCase
                    "Content unset"
                    [ Content.unset ]
                    "{content:unset;}"
                testCase
                    "Content revert"
                    [ Content.revert ]
                    "{content:revert;}"
            ]
