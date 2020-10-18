namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss

module Utils =
    let test (testName: string) (attributeList: CSSProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> createCSSRecord

            Expect.equal actual correct testName

    let testNested (testName: string) (attributeList: CSSProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> createCSSRecord
                |> List.map (fun (x: string, y: obj) ->
                    let y: string list =
                        y :?> string list list
                        |> List.head
                    x ==> (sprintf "[%s]" <| String.concat "," y)
                )

            Expect.equal actual correct testName
            
    let testString (testName: string) (actual: string) (expected: string) =
        testCase testName <| fun _ ->
            Expect.equal actual expected testName

