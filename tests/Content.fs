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
                    [ Content.Normal ]
                    [ "content" ==> "normal" ]
                test
                    "Content none"
                    [ Content.None ]
                    [ "content" ==> "none" ]
                test
                    "Content image"
                    [ Content.Url "http://www.example.com/test.png" ]
                    [ "content" ==> "url(http://www.example.com/test.png)" ]
                test
                    "Content image with alt text"
                    [ Content.Url("http://www.example.com/test.png", "this is the alt text") ]
                    [ "content" ==> "url(http://www.example.com/test.png) / \"this is the alt text\"" ]
                test
                    "Content linear gradient"
                    [ Content.LinearGradient(deg 45.0, [hex "e66456", px 0; hex "9198e5", px 100]) ]
                    [ "content" ==> "linear-gradient(45.00deg, #e66456 0px, #9198e5 100px)" ]
                test
                    "Content string value"
                    [ Content' (CssString "prefix")]
                    [ "content" ==> "\"prefix\"" ]
                test
                    "Content counter"
                    [ Content.Counter sampleCounter]
                    [ "content" ==> sprintf "counter(%s)" (counterValue sampleCounter) ]
                test
                    "Content counter2"
                    [ Content.Counters (sampleCounter, ListStyleType.UpperLatin) ]
                    [ "content" ==> sprintf "counters(%s, upper-latin)" (counterValue sampleCounter) ]
                test
                    "Content counter2"
                    [ Content.Counter (sampleCounter, ". ")]
                    [ "content" ==> sprintf "counter(%s)'. '" (counterValue sampleCounter)]
                test
                    "Content attribute"
                    [ Content.Attribute Attribute.Title ]
                    [ "content" ==> "attr(title)" ]
                test
                    "Content open quote"
                    [ Content.OpenQuote ]
                    [ "content" ==> "open-quote" ]
                test
                    "Content close quote"
                    [ Content.CloseQuote ]
                    [ "content" ==> "close-quote" ]
                test
                    "Content no open quote"
                    [ Content.NoOpenQuote ]
                    [ "content" ==> "no-open-quote" ]
                test
                    "Content no close quote"
                    [ Content.NoCloseQuote ]
                    [ "content" ==> "no-close-quote" ]
                test
                    "Content inherit"
                    [ Content.Inherit ]
                    [ "content" ==> "inherit" ]
                test
                    "Content initial"
                    [ Content.Initial ]
                    [ "content" ==> "initial" ]
                test
                    "Content unset"
                    [ Content.Unset ]
                    [ "content" ==> "unset" ]

            ]