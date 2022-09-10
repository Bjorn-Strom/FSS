namespace FSSTests

open Fet
open Utils
open Fss

module CustomTests =
     let tests =
        testList "Custom"
            [
                testCase
                    "Can set custom border"
                    [Custom "border" "4mm ridge rgba(170, 50, 220, .6)"]
                    "{border:4mm ridge rgba(170, 50, 220, .6);}"

                test "Classname selector works" <| fun _ ->
                    let className, actual = (createFss [ Classname "randomClassName" [ Color.red  ] ])
                    Expect.equal actual $".{className}.randomClassName{{color:red;}}"

                test "Id selector works" <| fun _ ->
                    let className, actual = (createFss [ Id "randomId" [ Color.red  ] ])
                    Expect.equal actual $".{className}#randomId{{color:red;}}"
            ]
