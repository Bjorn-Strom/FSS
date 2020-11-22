namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss
open Keyframes

module Utils =
    let test (testName: string) (attributeList: CSSProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> List.map GlobalValue.CSSValue

            Expect.equal actual correct testName

    let testNested (testName: string) (attributeList: CSSProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> List.map GlobalValue.CSSValue
                |> List.map (fun (x: string, y: obj) ->
                    let y: string list =
                        y :?> string list list
                       |> List.collect id
                    x ==> (sprintf "[%s]" <| String.concat "," y)
                )

            Expect.equal actual correct testName

    let testString (testName: string) (actual: string) (expected: string) =
        testCase testName <| fun _ ->
            Expect.equal actual expected testName

    let testKeyframes (testName: string) (actual: KeyframeAttribute list) (expected: string list) =
        let actual =
            actual
            |> createAnimationRecord
            |> List.map (fun (key, value) ->
                      sprintf "%s %A" key (Fable.Core.JS.JSON.stringify(value)
                              .Replace("\\", "")
                              .Replace("\"","")
                              .Replace("{", "")
                              .Replace("}", "")
                              .Replace(":", ", ")))

        testCase testName <| fun _ ->
            Expect.equal actual expected testName