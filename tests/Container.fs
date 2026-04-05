namespace FSSTests

open Fss
open Fet
open Utils

module ContainerTests =
    let tests =
        testList "Container"
            [
                // Container properties
                testCase
                    "ContainerType size"
                    [ ContainerType.size ]
                    "{container-type:size;}"
                testCase
                    "ContainerType inline-size"
                    [ ContainerType.inlineSize ]
                    "{container-type:inline-size;}"
                testCase
                    "ContainerType normal"
                    [ ContainerType.normal ]
                    "{container-type:normal;}"
                testCase
                    "ContainerType inherit"
                    [ ContainerType.inherit' ]
                    "{container-type:inherit;}"
                testCase
                    "ContainerType initial"
                    [ ContainerType.initial ]
                    "{container-type:initial;}"
                testCase
                    "ContainerType unset"
                    [ ContainerType.unset ]
                    "{container-type:unset;}"
                testCase
                    "ContainerName value"
                    [ ContainerName.value "sidebar" ]
                    "{container-name:sidebar;}"
                testCase
                    "ContainerName none"
                    [ ContainerName.none ]
                    "{container-name:none;}"
                testCase
                    "ContainerName inherit"
                    [ ContainerName.inherit' ]
                    "{container-name:inherit;}"
                testCase
                    "Container shorthand"
                    [ ContainerShorthand.value("sidebar", "inline-size") ]
                    "{container:sidebar / inline-size;}"
                testCase
                    "Container shorthand none"
                    [ ContainerShorthand.none ]
                    "{container:none;}"

                // Container queries
                test "Container query with min-width" <| fun _ ->
                    let className, actual = createFss [ Container.query [ Container.MinWidth (px 500) ] [ BackgroundColor.red ] ]
                    Expect.equal actual (sprintf ".%s{@container (min-width:500px) {&{background-color:red;}}}" className)

                test "Container query with min and max width" <| fun _ ->
                    let className, actual = createFss [ Container.query [ Container.MinWidth (px 500); Container.MaxWidth (px 1000) ] [ BackgroundColor.red ] ]
                    Expect.equal actual (sprintf ".%s{@container (min-width:500px) and (max-width:1000px) {&{background-color:red;}}}" className)

                test "Container query named" <| fun _ ->
                    let className, actual = createFss [ Container.queryNamed "sidebar" [ Container.MinWidth (px 400) ] [ FontSize.value (px 14) ] ]
                    Expect.equal actual (sprintf ".%s{@container sidebar (min-width:400px) {&{font-size:14px;}}}" className)

                test "Container query with inline-size" <| fun _ ->
                    let className, actual = createFss [ Container.query [ Container.MinInlineSize (px 300) ] [ Display.flex ] ]
                    Expect.equal actual (sprintf ".%s{@container (min-inline-size:300px) {&{display:flex;}}}" className)

                test "Container query with height" <| fun _ ->
                    let className, actual = createFss [ Container.query [ Container.MinHeight (px 200) ] [ Color.red ] ]
                    Expect.equal actual (sprintf ".%s{@container (min-height:200px) {&{color:red;}}}" className)
            ]
