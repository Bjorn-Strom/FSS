namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss
open Fss.Media

module Utils =
    let test (testName: string) (attributeList: FssTypes.CssProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> List.map FssTypes.masterTypeHelpers.CssValue

            Expect.equal actual correct testName

    let testMedia (testName: string) (featureList: FssTypes.Media.Feature list) (attributeList: FssTypes.CssProperty list) (correct: (string * obj)) =
        testCase testName <| fun _ ->
            let actual = mediaFeature featureList |> sprintf "@media %s" ==> (attributeList |> List.map FssTypes.masterTypeHelpers.CssValue)

            Expect.equal (actual.ToString()) (correct.ToString()) testName

    let testMediaFor (testName: string) device (featureList: FssTypes.Media.Feature list) (attributeList: FssTypes.CssProperty list) (correct: (string * obj)) =
        testCase testName <| fun _ ->
            let actual = sprintf "@media %s %s" (deviceLabel device) (mediaFeature featureList)  ==> (attributeList |> List.map FssTypes.masterTypeHelpers.CssValue)

            Expect.equal (actual.ToString()) (correct.ToString()) testName

    let testNested (testName: string) (attributeList: FssTypes.CssProperty list) (correct: (string * obj) list) =
        testCase testName <| fun _ ->
            let actual =
                attributeList
                |> List.map FssTypes.masterTypeHelpers.CssValue
                |> List.map (fun (x, y) ->
                    let properY: string =
                        y :?> FssTypes.CssProperty list
                        |> List.map FssTypes.masterTypeHelpers.CssValue
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