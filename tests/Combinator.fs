namespace FSSTests

open Fet
open Utils
open Fss

module CombinatorTests =
    let tests =
       testList "Combinator"
           [
               let className, actual = createFss [ !+ (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               testEqual
                   "Adjacent sibling 1 with Html Tag"
                   actual
                   $".{className} + *{{color:blue;}}"
               let className, actual = createFss [ Color.red; !+ (Selector.Tag Fss.Types.Html.All) [ Color.blue ];  ]
               testEqual
                   "Adjacent sibling 2 with Html Tag"
                   actual
                   $".{className}{{color:red;}}.{className} + *{{color:blue;}}"
               let className, actual = createFss [ !~ (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               testEqual
                   "General sibling 1 with Html Tag"
                   actual
                   $".{className} ~ *{{color:blue;}}"
               let className, actual = createFss [ Color.red; !~ (Selector.Tag Fss.Types.Html.All) [ Color.blue ];  ]
               testEqual
                   "General sibling 2 with Html Tag"
                   actual
                   $".{className}{{color:red;}}.{className} ~ *{{color:blue;}}"
               let className, actual = createFss [ !> (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               testEqual
                   "Child 1 with Html Tag"
                   actual
                   $".{className} > *{{color:blue;}}"
               let className, actual = createFss [ Color.red; !> (Selector.Tag Fss.Types.Html.All) [ Color.blue ];  ]
               testEqual
                   "Child 2 with Html Tag"
                   actual
                   $".{className}{{color:red;}}.{className} > *{{color:blue;}}"
               let className, actual = createFss [ !  (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               testEqual
                   "Descendant 1 with Html Tag"
                   actual
                   $".{className} *{{color:blue;}}"
               let className, actual = createFss [ Color.red; !  (Selector.Tag Fss.Types.Html.All) [ Color.blue ]]
               testEqual
                   "Descendant 2 with Html Tag"
                   actual
                   $".{className}{{color:red;}}.{className} *{{color:blue;}}"
               let className, actual = createFss [ Color.red; !+ (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "Adjacent sibling with pseudo"
                   actual
                   $".{className}{{color:red;}}.{className} + *:hover{{background-color:aqua;}}"
               let className, actual = createFss [ Color.red; !~ (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "General sibling with pseudo"
                   actual
                   $".{className}{{color:red;}}.{className} ~ *:hover{{background-color:aqua;}}"
               let className, actual = createFss [ Color.red; !>  (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "Child with pseudo"
                   actual
                   $".{className}{{color:red;}}.{className} > *:hover{{background-color:aqua;}}"
               let className, actual = createFss [ Color.red; !  (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               testEqual
                   "Descendant with pseudo"
                   actual
                   $".{className}{{color:red;}}.{className} *:hover{{background-color:aqua;}}"
               let className, actual = createFss [ ! (Selector.Tag Fss.Types.Html.All) [ !> (Selector.Tag Fss.Types.Html.All) [ !+ (Selector.Tag Fss.Types.Html.All) [ !~ (Selector.Tag Fss.Types.Html.A) [ Visited [ Color.white ] ] ] ] ] ]
               testEqual
                   "Descendant with nested selectors"
                   actual
                   $".{className} * > * + * ~ a:visited{{color:white;}}"

               let className, actual =
                  createFss [ !+ (Selector.Tag Fss.Types.Html.All) [
                                                      BorderColor.green
                                                      Hover [ BorderColor.red ]
                                                      Media.query
                                                         [ Media.MaxHeight (em 2) ]
                                                         [ Content.value "Query in pseudo" ] ]]
               testEqual
                  "adjacent sibling with nested selectors"
                  actual
                  $""".{className} + *{{border-color:green;}}.{className} + *:hover{{border-color:red;}}@media (max-height:2em) {{.{className} + *{{content:"Query in pseudo";}}}}"""
               let className, actual = createFss [ !+ (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "Adjacent sibling 1 with class"
                   actual
                   $".{className} + .SomeClass{{color:blue;}}"
               let className, actual = createFss [ Color.red; !+ (Selector.Class "SomeClass") [ Color.blue ];  ]
               testEqual
                   "Adjacent sibling 2 with class"
                   actual
                   $".{className}{{color:red;}}.{className} + .SomeClass{{color:blue;}}"
               let className, actual = createFss [ !~ (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "General sibling 1 with class"
                   actual
                   $".{className} ~ .SomeClass{{color:blue;}}"
               let className, actual = createFss [ Color.red; !~ (Selector.Class "SomeClass") [ Color.blue ];  ]
               testEqual
                   "General sibling 2 with class"
                   actual
                   $".{className}{{color:red;}}.{className} ~ .SomeClass{{color:blue;}}"
               let className, actual = createFss [ !> (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "Child 1 with class"
                   actual
                   $".{className} > .SomeClass{{color:blue;}}"
               let className, actual = createFss [ Color.red; !> (Selector.Class "SomeClass") [ Color.blue ];  ]
               testEqual
                   "Child 2 with class"
                   actual
                   $".{className}{{color:red;}}.{className} > .SomeClass{{color:blue;}}"
               let className, actual = createFss [ !  (Selector.Class "SomeClass") [ Color.blue ] ]
               testEqual
                   "Descendant 1 with class"
                   actual
                   $".{className} .SomeClass{{color:blue;}}"
               let className, actual = createFss [ Color.red; !  (Selector.Class "SomeClass") [ Color.blue ]]
               testEqual
                   "Descendant 2 with class"
                   actual
                   $".{className}{{color:red;}}.{className} .SomeClass{{color:blue;}}"
               let className, actual = createFss [ !+ (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "Adjacent sibling 1 with id"
                   actual
                   $".{className} + #SomeId{{color:blue;}}"
               let className, actual = createFss [ Color.red; !+ (Selector.Id "SomeId") [ Color.blue ];  ]
               testEqual
                   "Adjacent sibling 2 with id"
                   actual
                   $".{className}{{color:red;}}.{className} + #SomeId{{color:blue;}}"
               let className, actual = createFss [ !~ (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "General sibling 1 with id"
                   actual
                   $".{className} ~ #SomeId{{color:blue;}}"
               let className, actual = createFss [ Color.red; !~ (Selector.Id "SomeId") [ Color.blue ];  ]
               testEqual
                   "General sibling 2 with id"
                   actual
                   $".{className}{{color:red;}}.{className} ~ #SomeId{{color:blue;}}"
               let className, actual = createFss [ !> (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "Child 1 with id"
                   actual
                   $".{className} > #SomeId{{color:blue;}}"
               let className, actual = createFss [ Color.red; !> (Selector.Id "SomeId") [ Color.blue ];  ]
               testEqual
                   "Child 2 with id"
                   actual
                   $".{className}{{color:red;}}.{className} > #SomeId{{color:blue;}}"
               let className, actual = createFss [ ! (Selector.Id "SomeId") [ Color.blue ] ]
               testEqual
                   "Descendant 1 with id"
                   actual
                   $".{className} #SomeId{{color:blue;}}"
               let className, actual = createFss [ Color.red; ! (Selector.Id "SomeId") [ Color.blue ]]
               testEqual
                   "Descendant 2 with id"
                   actual
                   $".{className}{{color:red;}}.{className} #SomeId{{color:blue;}}"

               let aClassName, _ = createFss [ Color.blue ]
               let className, actual = createFss [ Color.red; ! (Selector.Tag Fss.Types.Html.Div) [
                   Color.orangeRed
                   !> (Selector.Class "someClass") [
                      Display.grid
                      !+ (Selector.Tag Fss.Types.Html.A) [
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
                   $".{className}{{color:red;}}.{className} div{{color:orangered;}}.{className} div > .someClass{{display:grid;}}.{className} div > .someClass + a{{color:darkorange;}}.{className} div ~ #someId{{display:block;}}.{className} div ~ #someId .{aClassName}{{flex-direction:column;}}.{className} div ~ #someId .{aClassName} #anotherId{{flex-direction:row;}}"
           ]
