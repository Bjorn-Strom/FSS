namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss

module Utils =
    let test (testName: string) (attributeList: Types.CssProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> List.map Types.masterTypeHelpers.CssValue

            Expect.equal actual correct testName

    let testNested (testName: string) (attributeList: Types.CssProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> List.map Types.masterTypeHelpers.CssValue
                |> List.map (fun (x, y) ->
                    let properY: string =
                        y :?> Types.CssProperty list
                        |> List.map Types.masterTypeHelpers.CssValue
                        |> List.map (fun x -> $"{x}")
                        |> String.concat ","
                    x ==> properY)

            Expect.equal actual correct testName

    let testString (testName: string) (actual: string) (expected: string) =
        testCase testName <| fun _ ->
            Expect.equal actual expected testName

    let testKeyframes (testName: string) (actual: Keyframes.KeyframeAttribute list) (expected: string list) =
        let actual =
            actual
            |> Keyframes.createAnimationRecord
            |> List.map (fun (key, value) ->
                      sprintf "%s %A" key (Fable.Core.JS.JSON.stringify(value)
                              .Replace("\\", "")
                              .Replace("\"","")
                              .Replace("{", "")
                              .Replace("}", "")
                              .Replace(":", ", ")))

        testCase testName <| fun _ ->
            Expect.equal actual expected testName