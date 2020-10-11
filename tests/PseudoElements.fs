namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module PseudoElements =
    let tests =
        testList "Pseudo Elements"
            [
                testNested
                    "Before"
                    [ Before [ Color Color.red ] ]
                    [ "::before" ==> "[color,#ff0000]" ]
                    
                testNested
                    "After"
                    [ After [ Color Color.red ] ]
                    [ "::after" ==> "[color,#ff0000]" ]
                    
                testNested
                    "FirstLine"
                    [ FirstLine [ Color Color.red ] ]
                    [ "::first-line" ==> "[color,#ff0000]" ]
                    
                testNested
                    "FirstLetter"
                    [ FirstLetter [ Color Color.red ] ]
                    [ "::first-letter" ==> "[color,#ff0000]" ]
                    
                testNested
                    "Selection"
                    [ Selection [ Color Color.red ] ]
                    [ "::selection" ==> "[color,#ff0000]" ]
            ]