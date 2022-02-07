namespace FSSTests

open Fet
open Utils
open Fss

module SelectorTests =
    let createSelector (ruleList: Fss.Types.Rule list) =
        let className, fss = (createFss ruleList)
        let selector, css =
            fss
            |> List.rev
            |> List.head
        className, $"{selector} {css}"
     
    let tests =
       testList "Selector"
           [
               let className, actual = createSelector [ !+ Fss.Types.Html.All [ Color.blue ] ]
               testEqual
                   "Adjacent sibling"
                   actual
                   $".{className} + all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !+ Fss.Types.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "Adjacent sibling"
                   actual
                   $".{className} + all {{ color: blue; }}"
                   
               let className, actual = createSelector [ !~ Fss.Types.Html.All [ Color.blue ] ]
               testEqual
                   "General sibling"
                   actual
                   $".{className} ~ all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !~ Fss.Types.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "General sibling"
                   actual
                   $".{className} ~ all {{ color: blue; }}"
                   
               let className, actual = createSelector [ !> Fss.Types.Html.All [ Color.blue ] ]
               testEqual
                   "Child"
                   actual
                   $".{className} > all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !> Fss.Types.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "Child"
                   actual
                   $".{className} > all {{ color: blue; }}"
                   
               let className, actual = createSelector [ !  Fss.Types.Html.All [ Color.blue ] ]
               testEqual
                   "Descendant"
                   actual
                   $".{className} all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !  Fss.Types.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "Descendant" 
                   actual
                   $".{className} all {{ color: blue; }}"
                   
               let className, actual = createSelector [ Color.red; !+ Fss.Types.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "Adjacent sibling with pseudo" 
                   actual
                   $".{className} + all:hover {{ background-color: aqua; }}"
               let className, actual = createSelector [ Color.red; !~ Fss.Types.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "General sibling with pseudo" 
                   actual
                   $".{className} ~ all:hover {{ background-color: aqua; }}"
               let className, actual = createSelector [ Color.red; !>  Fss.Types.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "Child with pseudo" 
                   actual
                   $".{className} > all:hover {{ background-color: aqua; }}"
               let className, actual = createSelector [ Color.red; !  Fss.Types.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "Descendant with pseudo" 
                   actual
                   $".{className} all:hover {{ background-color: aqua; }}"
               let className, actual =
                   createSelector [ ! Fss.Types.Html.All [ !> Fss.Types.Html.All [ !+ Fss.Types.Html.All [ !~ Fss.Types.Html.A [ Visited [ Color.white ] ] ] ] ] ]
               testEqual
                   "Descendant with nested selectors" 
                   actual
                   $".{className} all > all + all ~ a:visited {{ color: white; }}"
                   
               let className, actual =
                  createFss [ !+ Fss.Types.Html.All [ BorderColor.green
                                                      Hover [ BorderColor.red ]
                                                      Media.query
                                                         [ Fss.Types.Media.MaxHeight (em 2) ]
                                                         [ Content.value "Query in pseudo" ]
                                      ]]
                  
               let actual =
                  actual
                  |> List.map (fun (x,y) -> $"{x} {y}")
                  |> String.concat ""
                  
              testEqual
                  "adjacent sibling with nested selectors"
                  actual
                  $""".{className} + all {{ border-color: green; }}.{className} + all:hover {{ border-color: red; }}@media (max-height: 2em) {{ .{className} + all {{ content: "Query in pseudo"; }} }}"""
              
           ]