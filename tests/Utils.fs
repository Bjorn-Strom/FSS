namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fable.Core.JS
open Fss
open Fss.Keyframes

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
                        |> List.collect id
                    x ==> (sprintf "[%s]" <| String.concat "," y)
                )

            Expect.equal actual correct testName

    let testString (testName: string) (actual: string) (expected: string) =
        testCase testName <| fun _ ->
            Expect.equal actual expected testName
            
    type foo = string * string

    let testKeyframes (testName: string) (actual: KeyframeAttribute list) (expected: string list) =       
        let actual =
            actual
            |> createAnimationRecord
            |> List.map (fun (key, value) ->
                      sprintf "%s %A" key (JSON.stringify(value)
                              .Replace("\\", "")
                              .Replace("\"","")
                              .Replace("{", "")
                              .Replace("}", "")
                              .Replace(":", ", ")))
                
        testCase testName <| fun _ ->
            Expect.equal actual expected testName

