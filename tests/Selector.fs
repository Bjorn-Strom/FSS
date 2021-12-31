namespace FSSTests

open Fet
open Utils
open Fss

module Selector =
    let createSelector (ruleList: FssTypes.Rule list) =
        let fss = (createFss ruleList)
        let selector, css =
            snd fss
            |> List.rev
            |> List.head
        let className = fst fss
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
                // Todo: Descendant med media query
           ]