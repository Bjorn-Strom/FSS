namespace FSSTests

open Fet
open Utils
open Fss

module CombinatorTests =
    let tests =
       testList "Combinator"
           [
               // let className, actual = createFss [ !+ (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               // testEqual
               //     "Adjacent sibling 1 with Html Tag"
               //     actual
               //     $".{className} + *{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !+ (Selector.Tag Fss.Types.Html.All) [ Color.blue ];  ]
               // testEqual
               //     "Adjacent sibling 2 with Html Tag"
               //     actual
               //     $".{className}{{color:red;}}.{className} + *{{color:blue;}}"
               // let className, actual = createFss [ !~ (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               // testEqual
               //     "General sibling 1 with Html Tag"
               //     actual
               //     $".{className} ~ *{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !~ (Selector.Tag Fss.Types.Html.All) [ Color.blue ];  ]
               // testEqual
               //     "General sibling 2 with Html Tag"
               //     actual
               //     $".{className}{{color:red;}}.{className} ~ *{{color:blue;}}"
               // let className, actual = createFss [ !> (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               // testEqual
               //     "Child 1 with Html Tag"
               //     actual
               //     $".{className} > *{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !> (Selector.Tag Fss.Types.Html.All) [ Color.blue ];  ]
               // testEqual
               //     "Child 2 with Html Tag"
               //     actual
               //     $".{className}{{color:red;}}.{className} > *{{color:blue;}}"
               // let className, actual = createFss [ !  (Selector.Tag Fss.Types.Html.All) [ Color.blue ] ]
               // testEqual
               //     "Descendant 1 with Html Tag"
               //     actual
               //     $".{className} *{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !  (Selector.Tag Fss.Types.Html.All) [ Color.blue ]]
               // testEqual
               //     "Descendant 2 with Html Tag"
               //     actual
               //     $".{className}{{color:red;}}.{className} *{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !+ (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               // testEqual
               //     "Adjacent sibling with pseudo"
               //     actual
               //     $".{className}{{color:red;}}.{className} + *:hover{{background-color:aqua;}}"
               // let className, actual = createFss [ Color.red; !~ (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               // testEqual
               //     "General sibling with pseudo"
               //     actual
               //     $".{className}{{color:red;}}.{className} ~ *:hover{{background-color:aqua;}}"
               // let className, actual = createFss [ Color.red; !>  (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               // testEqual
               //     "Child with pseudo"
               //     actual
               //     $".{className}{{color:red;}}.{className} > *:hover{{background-color:aqua;}}"
               // let className, actual = createFss [ Color.red; !  (Selector.Tag Fss.Types.Html.All) [ Hover [ BackgroundColor.aqua ] ]]
               // testEqual
               //     "Descendant with pseudo"
               //     actual
               //     $".{className}{{color:red;}}.{className} *:hover{{background-color:aqua;}}"
               // let className, actual = createFss [ ! (Selector.Tag Fss.Types.Html.All) [ !> (Selector.Tag Fss.Types.Html.All) [ !+ (Selector.Tag Fss.Types.Html.All) [ !~ (Selector.Tag Fss.Types.Html.A) [ Visited [ Color.white ] ] ] ] ] ]
               // testEqual
               //     "Descendant with nested selectors"
               //     actual
               //     $".{className} * > * + * ~ a:visited{{color:white;}}"
               //
               // let className, actual =
               //    createFss [ !+ (Selector.Tag Fss.Types.Html.All) [
               //                                        BorderColor.green
               //                                        Hover [ BorderColor.red ]
               //                                        Media.query
               //                                           [ Media.MaxHeight (em 2) ]
               //                                           [ Content.value "Query in pseudo" ] ]]
               // testEqual
               //    "adjacent sibling with nested selectors"
               //    actual
               //    $""".{className} + *{{border-color:green;}}.{className} + *:hover{{border-color:red;}}@media (max-height:2em) {{.{className} + *{{content:"Query in pseudo";}}}}"""
               // let className, actual = createFss [ !+ (Selector.Class "SomeClass") [ Color.blue ] ]
               // testEqual
               //     "Adjacent sibling 1 with class"
               //     actual
               //     $".{className} + .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !+ (Selector.Class "SomeClass") [ Color.blue ];  ]
               // testEqual
               //     "Adjacent sibling 2 with class"
               //     actual
               //     $".{className}{{color:red;}}.{className} + .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ !~ (Selector.Class "SomeClass") [ Color.blue ] ]
               // testEqual
               //     "General sibling 1 with class"
               //     actual
               //     $".{className} ~ .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !~ (Selector.Class "SomeClass") [ Color.blue ];  ]
               // testEqual
               //     "General sibling 2 with class"
               //     actual
               //     $".{className}{{color:red;}}.{className} ~ .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ !> (Selector.Class "SomeClass") [ Color.blue ] ]
               // testEqual
               //     "Child 1 with class"
               //     actual
               //     $".{className} > .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !> (Selector.Class "SomeClass") [ Color.blue ];  ]
               // testEqual
               //     "Child 2 with class"
               //     actual
               //     $".{className}{{color:red;}}.{className} > .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ !  (Selector.Class "SomeClass") [ Color.blue ] ]
               // testEqual
               //     "Descendant 1 with class"
               //     actual
               //     $".{className} .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !  (Selector.Class "SomeClass") [ Color.blue ]]
               // testEqual
               //     "Descendant 2 with class"
               //     actual
               //     $".{className}{{color:red;}}.{className} .SomeClass{{color:blue;}}"
               // let className, actual = createFss [ !+ (Selector.Id "SomeId") [ Color.blue ] ]
               // testEqual
               //     "Adjacent sibling 1 with id"
               //     actual
               //     $".{className} + #SomeId{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !+ (Selector.Id "SomeId") [ Color.blue ];  ]
               // testEqual
               //     "Adjacent sibling 2 with id"
               //     actual
               //     $".{className}{{color:red;}}.{className} + #SomeId{{color:blue;}}"
               // let className, actual = createFss [ !~ (Selector.Id "SomeId") [ Color.blue ] ]
               // testEqual
               //     "General sibling 1 with id"
               //     actual
               //     $".{className} ~ #SomeId{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !~ (Selector.Id "SomeId") [ Color.blue ];  ]
               // testEqual
               //     "General sibling 2 with id"
               //     actual
               //     $".{className}{{color:red;}}.{className} ~ #SomeId{{color:blue;}}"
               // let className, actual = createFss [ !> (Selector.Id "SomeId") [ Color.blue ] ]
               // testEqual
               //     "Child 1 with id"
               //     actual
               //     $".{className} > #SomeId{{color:blue;}}"
               // let className, actual = createFss [ Color.red; !> (Selector.Id "SomeId") [ Color.blue ];  ]
               // testEqual
               //     "Child 2 with id"
               //     actual
               //     $".{className}{{color:red;}}.{className} > #SomeId{{color:blue;}}"
               // let className, actual = createFss [ ! (Selector.Id "SomeId") [ Color.blue ] ]
               // testEqual
               //     "Descendant 1 with id"
               //     actual
               //     $".{className} #SomeId{{color:blue;}}"
               // let className, actual = createFss [ Color.red; ! (Selector.Id "SomeId") [ Color.blue ]]
               // testEqual
               //     "Descendant 2 with id"
               //     actual
               //     $".{className}{{color:red;}}.{className} #SomeId{{color:blue;}}"
               //
               // let aClassName, _ = createFss [ Color.blue ]
               // let className, actual = createFss [ Color.red; ! (Selector.Tag Fss.Types.Html.Div) [
               //     Color.orangeRed
               //     !> (Selector.Class "someClass") [
               //        Display.grid
               //        !+ (Selector.Tag Fss.Types.Html.A) [
               //            Color.darkOrange
               //        ]
               //     ]
               //     !~ (Selector.Id "someId") [
               //         Display.block
               //         ! (Selector.Class aClassName) [
               //             FlexDirection.column
               //             ! (Selector.Id "anotherId") [
               //                 FlexDirection.row
               //             ]
               //         ]
               //     ]
               //  ]]
               // testEqual
               //     "Nested combinators combining  all combinators and all selector types"
               //     actual
               //     $".{className}{{color:red;}}.{className} div{{color:orangered;}}.{className} div > .someClass{{display:grid;}}.{className} div > .someClass + a{{color:darkorange;}}.{className} div ~ #someId{{display:block;}}.{className} div ~ #someId .{aClassName}{{flex-direction:column;}}.{className} div ~ #someId .{aClassName} #anotherId{{flex-direction:row;}}"
               //     
               //
               
               
               
               // Siste alternativ
               // let blah =
               //     createFssWithClassname "blo" [
               //         Class "bla" [
               //             
               //         ]
               //         Id' "blo2" [
               //             
               //         ]
               //         Not (Selector.Hover "") [
               //             Color.red
               //         ]
               //         
               //         Not [ Selector.Class "bla"; Selector.Hover ] [
               //             
               //         ]
               //     ]
                   // .blo.bla
                   // .blo#blo2
                
                (*
                
                            Den CSSen han delte, er også tredelt ser det ut til.
                            alt som matcher:
                            - .dx-datagrid-rowsview .dx-row-focused.dx-data-row .dx-command-edit:not(.dx-focused) .dx-link
                            - .dx-datagrid-rowsview .dx-row-focused.dx-data-row > td:not(.dx-focused)
                            - .dx-datagrid-rowsview .dx-row-focused.dx-data-row > tr > td:not(.dx-focused)
                            Er det som skal ha styling på seg.
                            Når man deler det opp slik så er jo alle 3 veldig like. Bortsett fra den sisteselectoren.
                            Tror dette kan bli skrevet ganske smooth med Fss
                            
                *)
               (*
.dx-datagrid-rowsview .dx-row-focused.dx-data-row .dx-command-edit:not(.dx-focused) .dx-link { 
  background-color: blue;
  color: orangered;
}
.dx-datagrid-rowsview .dx-row-focused.dx-data-row > td:not(.dx-focused) {
  background-color: blue;
  color: orangered;
}
.dx-datagrid-rowsview .dx-row-focused.dx-data-row > tr > td:not(.dx-focused) {
  background-color: blue;
  color: orangered;
}

               *)
                   
               
               let className, actual =
                   createFssWithClassname "dx-datagrid-rowsview" [
                           ! (Selector.Class "dx-row-focused") [
                               Class "dx-data-row" [
                                   ! (Selector.Class "dx-command-edit") [
                                       Not [Selector.Class "dx-focused"] [
                                           ! (Selector.Class "dx-link") [
                                                BackgroundColor.blue
                                                Color.orangeRed
                                           ]
                                       ]
                                   ]
                                   !> (Selector.Tag Fss.Types.Html.Td) [
                                       Not [Selector.Class "dx-focused"] [
                                            BackgroundColor.blue
                                            Color.orangeRed
                                       ]
                                   ]
                                   !> (Selector.Tag Fss.Types.Html.Tr) [
                                       !> (Selector.Tag Fss.Types.Html.Td) [
                                           Not [Selector.Class "dx-focused"] [
                                                BackgroundColor.blue
                                                Color.orangeRed
                                           ]
                                       ]
                                  ]
                               ]
                           ]
                       ]
               testEqual
                    ""
                    $"{actual}"
                    ".dx-datagrid-rowsview .dx-row-focused.dx-data-row .dx-command-edit:not(.dx-focused) .dx-link {background-color:blue;color:orangered;}"
                    
                    
               // I assume this one exists already
               let foo = createFssWithClassname "css647538688" [
                   
               ]
                    
               let classname, actual =
                createFssWithClassname "dx-row-focused" [
                    ! (Selector.Class (fst foo)) [
                        Color.white
                    ]
                ]
                    
                    
               testEqual
                    ""
                    $"{actual}"
                    ""
                    
               // let className, actual =
               //     createFssWithClassname "dx-datagrid-rowsview" [
               //         ! (Selector.Class "dx-row-focused.dx-data-row") [
               //             // TODO: Legg til not pseudo klassen?
               //             ! (Selector.Class "dx-command-edit:not(.dx-focused)") [
               //                 ! (Selector.Class "dx-link")
               //                     [
               //                          Color.orangeRed
               //                          BackgroundColor.blue
               //                     ]
               //             ]
               //         ]
               //     ]
               // testEqual
               //      ""
               //      $"{actual}"
               //      ".dx-datagrid-rowsview .dx-row-focused.dx-data-row > td:not(.dx-focused){background-color:#1f8fb9;color:#2a2a2a;}"
           ]