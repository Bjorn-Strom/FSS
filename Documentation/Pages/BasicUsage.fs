module Page.BasicUsage

open Fss
open Feliz
open Fable.Core

open Store

[<ReactComponent>]
let BasicUsage ()  =
    let borderStyle =
        fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)" ]

    let styles =
        [ Html.div [ prop.className borderStyle
                     prop.text "Border style made with custom escape hatch" ] ]
    Page Pages.BasicUsage styles

JsInterop.exportDefault BasicUsage