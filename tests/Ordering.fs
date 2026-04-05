namespace FSSTests

open Fet
open Utils
open Fss

module OrderingTests =
    let tests =
       testList "Ordering"
           [
                let _, actual =
                    createFssWithClassname "orderingOne" [
                            Display.flex
                            FlexDirection.column

                            !> (Selector.h2) [
                                important <| MarginBottom.value (px 16)
                            ]

                            Media.query
                                [ Media.MinWidth (px 200)]
                                [
                                    FlexDirection.row
                                    FlexGrow.value 1.0

                                    !> (Selector.h2) [
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
                   ".orderingOne{display:flex;flex-direction:column;& > h2{margin-bottom:16px !important;}@media (min-width:200px) {&{flex-direction:row;flex-grow:1;& > h2{margin-bottom:0px !important;margin-right:16px !important;&:last-child{margin-right:0px !important;}}}}}"
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
                   ".orderingTwo{color:orangered;background-color:blue;text-decoration-color:yellow;&:first-of-type{border-color:gray;border-width:2px;border-style:dashed;}}"

                let _, actual =
                    createFssWithClassname "orderingThree" [
                        Hover [
                            FontWeight.bolder
                        ]
                        FontWeight.normal
                        !> (Selector.p) [
                            FontWeight.bold
                        ]
                        Media.query
                            [ Media.MaxWidth (px 200) ]
                            [ FontWeight.lighter ]
                        !> (Selector.p) [
                            Color.red
                        ]
                    ]

                testEqual
                  "Ordering 3"
                   actual
                   ".orderingThree{&:hover{font-weight:bolder;}font-weight:normal;& > p{font-weight:bold;}@media (max-width:200px) {&{font-weight:lighter;}}& > p{color:red;}}"

                let _, actual =
                    createFssWithClassname "orderingFour" [
                        !> (Selector.p) [
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
                   ".orderingFour{& > p{font-weight:bold;}@media (max-width:200px) {&{font-weight:lighter;}}&:hover{font-weight:bolder;}font-weight:normal;}"

           ]
