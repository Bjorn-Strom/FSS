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
                    [ Content Normal ]
                    [ "content" ==> "normal" ]
                    
                test
                    "Content none"
                    [ Content None ]
                    [ "content" ==> "none" ]

                test
                    "Content image"
                    [ Content (Content.Url "http://www.example.com/test.png") ]
                    [ "content" ==> "url(http://www.example.com/test.png)" ]
                    
                test
                    "Content image with alt text"
                    [ Content (Content.UrlWithAlt("http://www.example.com/test.png", "this is the alt text")) ]
                    [ "content" ==> "url(http://www.example.com/test.png) / \"this is the alt text\"" ]
                    
                test
                    "Content linear gradient"
                    [ Content (Content.LinearGradient [hex "e66456"; hex "9198e5"]) ]
                    [ "content" ==> "linear-gradient(#e66456, #9198e5)" ]
                    
                test
                    "Content string value"
                    [ Content (Content.String "prefix")]
                    [ "content" ==> "\"prefix\"" ]
                    
                test
                    "Content counter"
                    [ Content (Content.Counter sampleCounter)]
                    [ "content" ==> "counter(a0)" ]
                    
                test
                    "Content counter2"
                    [ Content (Content.Counter2(sampleCounter, ListStyle.UpperLatin))]
                    [ "content" ==> "counter(a0, upper-latin)" ]
                    
                test
                    "Content counter2"
                    [ Content (Content.Counter2(sampleCounter, ListStyle.ListStyleType.String ". "))]
                    [ "content" ==> "counter(a0, '. ')" ]
                    
                test
                    "Content attribute"
                    [ Content (Content.Attribute Attribute.Title)]
                    [ "content" ==> "attr(title)" ]
                    
                test
                    "Content open quote"
                    [ Content Content.OpenQuote ]
                    [ "content" ==> "open-quote" ]
                    
                test
                    "Content close quote"
                    [ Content Content.CloseQuote ]
                    [ "content" ==> "close-quote" ]
                    
                test
                    "Content no open quote"
                    [ Content Content.NoOpenQuote ]
                    [ "content" ==> "no-open-quote" ]
                    
                test
                    "Content no close quote"
                    [ Content Content.NoCloseQuote ]
                    [ "content" ==> "no-close-quote" ]
                    
                test
                    "Content inherit"
                    [ Content Inherit ]
                    [ "content" ==> "inherit" ]
                    
                test
                    "Content initial"
                    [ Content Initial ]
                    [ "content" ==> "initial" ]
                    
                test
                    "Content unset"
                    [ Content Unset ]
                    [ "content" ==> "unset" ]
                    
            ]