namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Content =
    let sampleCounter =
        counterStyle []

    let tests =
        testList "Content"
            [
                test
                    "Content normal"
                    [ Content.normal ]
                    [ "content" ==> "normal" ]
                test
                    "Content none"
                    [ Content.none ]
                    [ "content" ==> "none" ]
                test
                    "Content image"
                    [ Content.url "http://www.example.com/test.png" ]
                    [ "content" ==> "url(http://www.example.com/test.png)" ]
                test
                    "Content image with alt text"
                    [ Content.url("http://www.example.com/test.png", "this is the alt text") ]
                    [ "content" ==> "url(http://www.example.com/test.png) / \"this is the alt text\"" ]
                test
                    "Content linear gradient"
                    [ Content.linearGradient(deg 45.0, [hex "e66456", px 0; hex "9198e5", px 100]) ]
                    [ "content" ==> "linear-gradient(45.00deg, #e66456 0px, #9198e5 100px)" ]
                test
                    "Content string value"
                    [ Content' (FssTypes.CssString "prefix")]
                    [ "content" ==> "\"prefix\"" ]
                test
                    "Content counter"
                    [ Content.counter sampleCounter]
                    [ "content" ==> sprintf "counter(%s)" (FssTypes.counterStyleHelpers.counterStyleToString sampleCounter) ]
                test
                    "Content counter2"
                    [ Content.counters (sampleCounter, FssTypes.ListStyle.Type.UpperLatin) ]
                    [ "content" ==> sprintf "counters(%s, upper-latin)" (FssTypes.counterStyleHelpers.counterStyleToString sampleCounter) ]
                test
                    "Content counter2"
                    [ Content.counter (sampleCounter, ". ")]
                    [ "content" ==> sprintf "counter(%s)'. '" (FssTypes.counterStyleHelpers.counterStyleToString sampleCounter)]
                test
                    "Content attribute"
                    [ Content.attribute FssTypes.Attribute.Title ]
                    [ "content" ==> "attr(title)" ]
                test
                    "Content open quote"
                    [ Content.openQuote ]
                    [ "content" ==> "open-quote" ]
                test
                    "Content close quote"
                    [ Content.closeQuote ]
                    [ "content" ==> "close-quote" ]
                test
                    "Content no open quote"
                    [ Content.noOpenQuote ]
                    [ "content" ==> "no-open-quote" ]
                test
                    "Content no close quote"
                    [ Content.noCloseQuote ]
                    [ "content" ==> "no-close-quote" ]
                test
                    "Content inherit"
                    [ Content.inherit' ]
                    [ "content" ==> "inherit" ]
                test
                    "Content initial"
                    [ Content.initial ]
                    [ "content" ==> "initial" ]
                test
                    "Content unset"
                    [ Content.unset ]
                    [ "content" ==> "unset" ]

            ]