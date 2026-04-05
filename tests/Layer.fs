namespace FSSTests

open Fss
open Fet
open Utils

module LayerTests =
    let tests =
        testList "Layer"
            [
                // Layer.define creates a CascadeLayer
                test "Layer define" <| fun _ ->
                    let (CascadeLayer name) = Layer.define "utilities"
                    Expect.equal name "utilities"

                // Named layer
                test "Named layer" <| fun _ ->
                    let utilities = Layer.define "utilities"
                    let className, actual = createFss [ Layer.layer utilities [ Color.red ] ]
                    Expect.equal actual (sprintf ".%s{@layer utilities {&{color:red;}}}" className)

                test "Named layer with multiple rules" <| fun _ ->
                    let base' = Layer.define "base"
                    let className, actual = createFss [ Layer.layer base' [ Color.red; Display.flex ] ]
                    Expect.equal actual (sprintf ".%s{@layer base {&{color:red;display:flex;}}}" className)

                test "Anonymous layer" <| fun _ ->
                    let className, actual = createFss [ Layer.anonymous [ Color.blue ] ]
                    Expect.equal actual (sprintf ".%s{@layer {&{color:blue;}}}" className)

                test "Multiple named layers" <| fun _ ->
                    let base' = Layer.define "base"
                    let theme = Layer.define "theme"
                    let className, actual = createFss [
                        Layer.layer base' [ Color.red ]
                        Layer.layer theme [ Color.blue ]
                    ]
                    Expect.equal actual (sprintf ".%s{@layer base {&{color:red;}}@layer theme {&{color:blue;}}}" className)

                test "Layer with other rules" <| fun _ ->
                    let utilities = Layer.define "utilities"
                    let className, actual = createFss [
                        Display.flex
                        Layer.layer utilities [ Color.red ]
                    ]
                    Expect.equal actual (sprintf ".%s{display:flex;@layer utilities {&{color:red;}}}" className)

                // Layer order declaration
                test "Layer order declaration" <| fun _ ->
                    let base' = Layer.define "base"
                    let components = Layer.define "components"
                    let utilities = Layer.define "utilities"
                    let actual = createLayerOrder [ base'; components; utilities ]
                    Expect.equal actual "@layer base, components, utilities;"

                test "Layer order declaration single" <| fun _ ->
                    let reset = Layer.define "reset"
                    let actual = createLayerOrder [ reset ]
                    Expect.equal actual "@layer reset;"
            ]
