namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss
open Fss.Keyframes

module Utils =
    open Fable.Core
    [<Emit("Object.values($0)")>]
    let objectValues (x: 'a) = jsNative

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



    let testKeyframes (testName: string) (keyframes: KeyframeAttribute list) (correct: (string * obj) list) =
        let correct =
            keyframes
            |> createAnimationObject
            |>  (fun x ->
                         Fable.Core.JS.console.log("x: ", x)
                         x)

        Fable.Core.JS.console.log(Fable.Core.JS.Object.keys(correct))
        Fable.Core.JS.console.log(objectValues(correct))


        testCase testName <| fun _ ->
            Expect.equal keyframes [] testName

