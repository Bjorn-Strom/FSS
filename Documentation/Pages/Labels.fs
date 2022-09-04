module Page.Labels

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Labels () =
    let styleWithoutLabel = fss [ Color.red ]

    let styleWithLabel =
        fss [ Label "Style With Label"
              Color.hotPink
              Label "HotPinkLabel" ]

    let styles =
        [ Html.div [ Html.div [ prop.className styleWithoutLabel
                                prop.text styleWithoutLabel ]
                     Html.div [ prop.className styleWithLabel
                                prop.text styleWithLabel ] ] ]

    Page (Pages.FssPage Pages.Labels) styles

JsInterop.exportDefault Labels
