namespace FSSTests

open Fet
open Utils
open Fss

module Selector =
    let createSelector (ruleList: FssTypes.Rule list) =
        let className, fss = (createFss ruleList)
        let selector, css =
            fss
            |> List.rev
            |> List.head
        className, $"{selector} {css}"
     
    let tests =
       testList "Selector"
           [
               let className, actual = createSelector [ !+ FssTypes.Html.All [ Color.blue ] ]
               testEqual
                   "Adjacent sibling"
                   actual
                   $".{className} + all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !+ FssTypes.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "Adjacent sibling"
                   actual
                   $".{className} + all {{ color: blue; }}"
                   
               let className, actual = createSelector [ !~ FssTypes.Html.All [ Color.blue ] ]
               testEqual
                   "General sibling"
                   actual
                   $".{className} ~ all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !~ FssTypes.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "General sibling"
                   actual
                   $".{className} ~ all {{ color: blue; }}"
                   
               let className, actual = createSelector [ !> FssTypes.Html.All [ Color.blue ] ]
               testEqual
                   "Child"
                   actual
                   $".{className} > all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !> FssTypes.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "Child"
                   actual
                   $".{className} > all {{ color: blue; }}"
                   
               let className, actual = createSelector [ !  FssTypes.Html.All [ Color.blue ] ]
               testEqual
                   "Descendant"
                   actual
                   $".{className} all {{ color: blue; }}"
               let className, actual = createSelector [ Color.red; !  FssTypes.Html.All [ Color.blue ]; BackgroundColor.orangeRed ]
               testEqual
                   "Descendant" 
                   actual
                   $".{className} all {{ color: blue; }}"
                   
               let className, actual = createSelector [ Color.red; !+ FssTypes.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "Adjacent sibling with pseudo" 
                   actual
                   $".{className} + all:hover {{ background-color: aqua; }}"
               let className, actual = createSelector [ Color.red; !~ FssTypes.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "General sibling with pseudo" 
                   actual
                   $".{className} ~ all:hover {{ background-color: aqua; }}"
               let className, actual = createSelector [ Color.red; !>  FssTypes.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "Child with pseudo" 
                   actual
                   $".{className} > all:hover {{ background-color: aqua; }}"
               let className, actual = createSelector [ Color.red; !  FssTypes.Html.All [ Hover [ BackgroundColor.aqua ] ]; BackgroundColor.orangeRed ]
               testEqual
                   "Descendant with pseudo" 
                   actual
                   $".{className} all:hover {{ background-color: aqua; }}"
               let className, actual =
                   createSelector [ ! FssTypes.Html.All [ !> FssTypes.Html.All [ !+ FssTypes.Html.All [ !~ FssTypes.Html.A [ Visited [ Color.white ] ] ] ] ] ]
               testEqual
                   "Descendant with nested selectors" 
                   actual
                   $".{className} all > all + all ~ a:visited {{ color: white; }}"
                   
               let className, actual =
                  createSelector [ !+ FssTypes.Html.All [ BorderColor.green
                                                          Hover [ BorderColor.red ]
                                                          Media.query
                                                        [ FssTypes.Media.MaxHeight (em 2) ]
                                                        [ Content.value "Query in pseudo" ]
                                      ]]

              testEqual
                  "adjacent sibling with nested selectors"
                  actual
                  $".{className} + all {{ @media (max-height: 2em) {{ content: \"Query in pseudo\"; }} }}"
           ]