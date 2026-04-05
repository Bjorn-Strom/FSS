namespace FSSTests

open Fet
open Utils
open Fss

module CombinatorTests =
    let tests =
       testList "Combinator"
           [
               let className, actual = createFss [ !+ Selector.all [ Color.blue ] ]
               testEqual
                   "Adjacent sibling 1 with Html Tag"
                   actual
                   (sprintf ".%s{& + *{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !+ (Selector.all) [ Color.blue ];  ]
               testEqual
                   "Adjacent sibling 2 with Html Tag"
                   actual
                   (sprintf ".%s{color:red;& + *{color:blue;}}" className)
               let className, actual = createFss [ !~ (Selector.all) [ Color.blue ] ]
               testEqual
                   "General sibling 1 with Html Tag"
                   actual
                   (sprintf ".%s{& ~ *{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !~ (Selector.all) [ Color.blue ];  ]
               testEqual
                   "General sibling 2 with Html Tag"
                   actual
                   (sprintf ".%s{color:red;& ~ *{color:blue;}}" className)
               let className, actual = createFss [ !> (Selector.all) [ Color.blue ] ]
               testEqual
                   "Child 1 with Html Tag"
                   actual
                   (sprintf ".%s{& > *{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !> (Selector.all) [ Color.blue ];  ]
               testEqual
                   "Child 2 with Html Tag"
                   actual
                   (sprintf ".%s{color:red;& > *{color:blue;}}" className)
               let className, actual = createFss [ !  (Selector.all) [ Color.blue ] ]
               testEqual
                   "Descendant 1 with Html Tag"
                   actual
                   (sprintf ".%s{& *{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !  (Selector.all) [ Color.blue ]]
               testEqual
                   "Descendant 2 with Html Tag"
                   actual
                   (sprintf ".%s{color:red;& *{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !+ (Selector.all) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "Adjacent sibling with pseudo"
                   actual
                   (sprintf ".%s{color:red;& + *{&:hover{background-color:aqua;}}}" className)
               let className, actual = createFss [ Color.red; !~ (Selector.all) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "General sibling with pseudo"
                   actual
                   (sprintf ".%s{color:red;& ~ *{&:hover{background-color:aqua;}}}" className)
               let className, actual = createFss [ Color.red; !>  (Selector.all) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "Child with pseudo"
                   actual
                   (sprintf ".%s{color:red;& > *{&:hover{background-color:aqua;}}}" className)
               let className, actual = createFss [ Color.red; !  (Selector.all) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "Descendant with pseudo"
                   actual
                   (sprintf ".%s{color:red;& *{&:hover{background-color:aqua;}}}" className)
               let className, actual = createFss [ ! (Selector.all) [ !> (Selector.all) [ !+ (Selector.all) [ !~ (Selector.a) [ Visited [ Color.white ] ] ] ] ] ]
               testEqual
                   "Descendant with nested selectors"
                   actual
                   (sprintf ".%s{& *{& > *{& + *{& ~ a{&:visited{color:white;}}}}}}" className)

               let className, actual =
                  createFss [ !+ (Selector.all) [
                                                      BorderColor.green
                                                      Hover [ BorderColor.red ]
                                                      Media.query
                                                         [ Media.MaxHeight (em 2) ]
                                                         [ Content.value "Query in pseudo" ] ]]
               testEqual
                  "adjacent sibling with nested selectors"
                  actual
                  (sprintf """.%s{& + *{border-color:green;&:hover{border-color:red;}@media (max-height:2em) {&{content:"Query in pseudo";}}}}""" className)
               let className, actual = createFss [ !+ (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "Adjacent sibling 1 with class"
                   actual
                   (sprintf ".%s{& + .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !+ (Selector.Class "SomeClass") [ Color.blue ];  ]
               testEqual
                   "Adjacent sibling 2 with class"
                   actual
                   (sprintf ".%s{color:red;& + .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ !~ (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "General sibling 1 with class"
                   actual
                   (sprintf ".%s{& ~ .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !~ (Selector.Class "SomeClass") [ Color.blue ];  ]
               testEqual
                   "General sibling 2 with class"
                   actual
                   (sprintf ".%s{color:red;& ~ .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ !> (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "Child 1 with class"
                   actual
                   (sprintf ".%s{& > .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !> (Selector.Class "SomeClass") [ Color.blue ];  ]
               testEqual
                   "Child 2 with class"
                   actual
                   (sprintf ".%s{color:red;& > .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ !  (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "Descendant 1 with class"
                   actual
                   (sprintf ".%s{& .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !  (Selector.Class "SomeClass") [ Color.blue ]]
               testEqual
                   "Descendant 2 with class"
                   actual
                   (sprintf ".%s{color:red;& .SomeClass{color:blue;}}" className)
               let className, actual = createFss [ !+ (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "Adjacent sibling 1 with id"
                   actual
                   (sprintf ".%s{& + #SomeId{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !+ (Selector.Id "SomeId") [ Color.blue ];  ]
               testEqual
                   "Adjacent sibling 2 with id"
                   actual
                   (sprintf ".%s{color:red;& + #SomeId{color:blue;}}" className)
               let className, actual = createFss [ !~ (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "General sibling 1 with id"
                   actual
                   (sprintf ".%s{& ~ #SomeId{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !~ (Selector.Id "SomeId") [ Color.blue ];  ]
               testEqual
                   "General sibling 2 with id"
                   actual
                   (sprintf ".%s{color:red;& ~ #SomeId{color:blue;}}" className)
               let className, actual = createFss [ !> (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "Child 1 with id"
                   actual
                   (sprintf ".%s{& > #SomeId{color:blue;}}" className)
               let className, actual = createFss [ Color.red; !> (Selector.Id "SomeId") [ Color.blue ];  ]
               testEqual
                   "Child 2 with id"
                   actual
                   (sprintf ".%s{color:red;& > #SomeId{color:blue;}}" className)
               let className, actual = createFss [ ! (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "Descendant 1 with id"
                   actual
                   (sprintf ".%s{& #SomeId{color:blue;}}" className)
               let className, actual = createFss [ Color.red; ! (Selector.Id "SomeId") [ Color.blue ]]
               testEqual
                   "Descendant 2 with id"
                   actual
                   (sprintf ".%s{color:red;& #SomeId{color:blue;}}" className)

               let aClassName, _ = createFss [ Color.blue ]
               let className, actual = createFss [ Color.red; ! (Selector.div) [
                   Color.orangeRed
                   !> (Selector.Class "someClass") [
                      Display.grid
                      !+ (Selector.a) [
                          Color.darkOrange
                      ]
                   ]
                   !~ (Selector.Id "someId") [
                       Display.block
                       ! (Selector.Class aClassName) [
                           FlexDirection.column
                           ! (Selector.Id "anotherId") [
                               FlexDirection.row
                           ]
                       ]
                   ]
                ]]
               testEqual
                   "Nested combinators combining  all combinators and all selector types"
                   actual
                   (sprintf ".%s{color:red;& div{color:orangered;& > .someClass{display:grid;& + a{color:darkorange;}}& ~ #someId{display:block;& .%s{flex-direction:column;& #anotherId{flex-direction:row;}}}}}" className aClassName)
           ]
