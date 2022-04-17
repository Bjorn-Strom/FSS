module Page.ConditionalStyling

open Fss
open Feliz
open Fable.Core

open Store

type ButtonSize =
    | Small
    | Big

[<ReactComponent>]
let ConditionalStyling ()  =
    let buttonStyle buttonType =
        fss [ match buttonType with
              | Big ->
                  Height.value (px 80)
                  Width.value (px 80)
              | Small ->
                  Height.value (px 40)
                  Width.value (px 40) ]

    let styles = 
         [ Html.div [ prop.children [ Html.button [ prop.className (buttonStyle Small)
                                                    prop.text "Small" ]

                                      Html.button [ prop.className (buttonStyle Big)
                                                    prop.text "Big" ] ] ] ]
    Page Pages.ConditionalStyling styles

JsInterop.exportDefault ConditionalStyling