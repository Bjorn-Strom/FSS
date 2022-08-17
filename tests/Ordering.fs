namespace FSSTests

open Fet
open Utils
open Fss
open Fss.Types

module OrderingTests =
    let tests =
       testList "Ordering"
           [
                let _, actual =
                    createFssWithClassname "orderingOne" [
                            Display.flex
                            FlexDirection.column

                            !> (Selector.Tag Html.H2) [
                                important <| MarginBottom.value (px 16)
                            ]

                            Media.query
                                [ Media.MinWidth (px 200)]
                                [
                                    FlexDirection.row
                                    FlexGrow.value 1.0

                                    !> (Selector.Tag Html.H2) [
                                        important <| MarginBottom.value (px 0)
                                        important <| MarginRight.value (px 16)

                                        LastChild [
                                            important <| MarginRight.value (px 0)
                                        ]
                                    ]
                            ]
                     ]

                testEqual
                   "Ordering 1"
                   actual
                   ".orderingOne{display:flex;flex-direction:column;}.orderingOne > h2{margin-bottom:16px !important;}@media (min-width:200px) {.orderingOne{flex-direction:row;flex-grow:1;}.orderingOne > h2{margin-bottom:0px !important;margin-right:16px !important;}.orderingOne > h2:last-child{margin-right:0px !important;}}"
                let _, actual =
                    createFssWithClassname "orderingTwo" [
                        Color.orangeRed
                        BackgroundColor.blue
                        TextDecorationColor.yellow

                        FirstOfType [
                            BorderColor.gray
                            BorderWidth.value (px 2)
                            BorderStyle.dashed
                        ]
                    ]

                testEqual
                   "Ordering 2"
                   actual
                   ".orderingTwo{color:orangered;background-color:blue;text-decoration-color:yellow;}.orderingTwo:first-of-type{border-color:gray;border-width:2px;border-style:dashed;}"

                let _, actual =
                    createFssWithClassname "orderingThree" [
                        Hover [
                            FontWeight.bolder
                        ]
                        FontWeight.normal
                        !> (Selector.Tag Html.P) [
                            FontWeight.bold
                        ]
                        Media.query
                            [ Media.MaxWidth (px 200) ]
                            [ FontWeight.lighter ]
                        !> (Selector.Tag Html.P) [
                            Color.red
                        ]
                    ]

                testEqual
                  "Ordering 3"
                   actual
                   ".orderingThree:hover{font-weight:bolder;}.orderingThree{font-weight:normal;}.orderingThree > p{font-weight:bold;}@media (max-width:200px) {.orderingThree{font-weight:lighter;}}.orderingThree > p{color:red;}"

                let _, actual =
                    createFssWithClassname "orderingFour" [
                        !> (Selector.Tag Html.P) [
                            FontWeight.bold
                        ]
                        Media.query
                            [ Media.MaxWidth (px 200) ]
                            [ FontWeight.lighter ]
                        Hover [
                            FontWeight.bolder
                        ]
                        FontWeight.normal
                    ]

                testEqual
                   "Ordering 4"
                   actual
                   ".orderingFour > p{font-weight:bold;}@media (max-width:200px) {.orderingFour{font-weight:lighter;}}.orderingFour:hover{font-weight:bolder;}.orderingFour{font-weight:normal;}"

           ]
