namespace src

open Fable.Core
open Fable.Core.JsInterop

module Arithmetic =
    let add x y = x + y
    let multiply x y = x * y
    let divide x y = x / y
    let subtract x y = x - y

module POJO =
    let createPersonPOJO () =
        createObj
            [
                "Name" ==> "Bjørn"
                "LastName" ==> "Strøm"
                "Address" ==> 
                createObj
                    [
                        "Street" ==> "Street 2"
                        "City" ==> "City 1"
                        "Country" ==> "Country 42"
                    ]
            ]