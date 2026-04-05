namespace FSSTests

open Fss
open Fet
open Utils

module ScopeTests =
    let tests =
        testList "Scope"
            [
                test "Scope with root selector" <| fun _ ->
                    let className, actual = createFss [ Scope.scope ".card" [ Color.red ] ]
                    Expect.equal actual (sprintf ".%s{@scope (.card) {&{color:red;}}}" className)

                test "Scope with root selector and multiple rules" <| fun _ ->
                    let className, actual = createFss [ Scope.scope ".card" [ Color.red; Display.flex ] ]
                    Expect.equal actual (sprintf ".%s{@scope (.card) {&{color:red;display:flex;}}}" className)

                test "Scope with donut (to)" <| fun _ ->
                    let className, actual = createFss [ Scope.scopeTo ".card" ".card-content" [ Color.blue ] ]
                    Expect.equal actual (sprintf ".%s{@scope (.card) to (.card-content) {&{color:blue;}}}" className)

                test "Implicit scope" <| fun _ ->
                    let className, actual = createFss [ Scope.implicit [ FontSize.value (px 14) ] ]
                    Expect.equal actual (sprintf ".%s{@scope {&{font-size:14px;}}}" className)

                test "Scope with other rules" <| fun _ ->
                    let className, actual = createFss [
                        Display.flex
                        Scope.scope ".sidebar" [ Color.green ]
                    ]
                    Expect.equal actual (sprintf ".%s{display:flex;@scope (.sidebar) {&{color:green;}}}" className)

                test "Multiple scopes" <| fun _ ->
                    let className, actual = createFss [
                        Scope.scope ".header" [ Color.red ]
                        Scope.scope ".footer" [ Color.blue ]
                    ]
                    Expect.equal actual (sprintf ".%s{@scope (.header) {&{color:red;}}@scope (.footer) {&{color:blue;}}}" className)
            ]
