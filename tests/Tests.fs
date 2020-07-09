module Tests

open Fable.Mocha

open src.Arithmetic

let arithmeticTests =
    testList "Arithmetic tests" [

        testCase "plus works" <| fun () ->
            Expect.equal (add 1 1) 2 "plus"

        testCase "subctract works" <| fun () ->
            Expect.equal (subtract 1 1) 0 "subtract"
        
        testCase "multiplication works" <| fun () ->
            Expect.equal (multiply 10 2) 20 "multiply"

        testCase "divide works" <| fun () ->
            Expect.equal (divide 10 2) 5 "divide"
    ]

Mocha.runTests arithmeticTests |> ignore