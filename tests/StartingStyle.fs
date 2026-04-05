namespace FSSTests

open Fss
open Fet
open Utils

module StartingStyleTests =
    let tests =
        testList "StartingStyle"
            [
                test "Starting style with single rule" <| fun _ ->
                    let className, actual = createFss [ StartingStyle.style [ Opacity.value 0.0 ] ]
                    Expect.equal actual (sprintf ".%s{@starting-style {&{opacity:0;}}}" className)

                test "Starting style with multiple rules" <| fun _ ->
                    let className, actual = createFss [ StartingStyle.style [ Opacity.value 0.0; BackgroundColor.transparent ] ]
                    Expect.equal actual (sprintf ".%s{@starting-style {&{opacity:0;background-color:transparent;}}}" className)

                test "Starting style alongside other rules" <| fun _ ->
                    let className, actual = createFss [
                        Opacity.value 1.0
                        TransitionProperty.opacity
                        StartingStyle.style [ Opacity.value 0.0 ]
                    ]
                    Expect.equal actual (sprintf ".%s{opacity:1;transition-property:opacity;@starting-style {&{opacity:0;}}}" className)
            ]
