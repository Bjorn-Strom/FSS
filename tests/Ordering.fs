namespace FSSTests

open Fet
open Utils
open Fss
open Fss.Types

module OrderingTests =
    let tests =
       testList "Ordering"
           [
                let normalSelectorMedia =
                    (createFssWithClassname "orderingOne" [
                            Display.flex
                            FlexDirection.column
                            
                            !> Html.H2 [
                                important <| MarginBottom.value (px 16)
                            ]
                      
                            Media.query
                                [ Fss.Types.Media.MinWidth (px 200)]
                                [
                                    FlexDirection.row
                                    FlexGrow.value 1.0
                       
                                    !> Html.H2 [
                                        important <| MarginBottom.value (px 0)
                                        important <| MarginRight.value (px 16)
                                   
                                        LastChild [
                                            important <| MarginRight.value (px 0)
                                        ]
                                    ]
                            ]
                     ])
                    |> snd
                    |> List.map (fun (x, y) ->
                        $"{x.ToString()} {y.ToString()}")
                    |> String.concat ""
                    
               testEqual
                   "Test creating css with custom classname"
                   normalSelectorMedia
                   "orderingOne { display: flex;flex-direction: column; }orderingOne > h2 { margin-bottom: 16px !important; }@media (min-width: 200px) { orderingOne { flex-direction: row;flex-grow: 1; }orderingOne > h2 { margin-bottom: 0px !important;margin-right: 16px !important; }orderingOne > h2:last-child { margin-right: 0px !important; } }"
           ]