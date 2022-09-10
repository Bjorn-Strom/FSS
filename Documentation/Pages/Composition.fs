module Page.Composition

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Composition () =
    let baseStyle =
        [ Label "Base Style"
          BackgroundColor.darkGreen
          Color.turquoise ]

    let danger = [ Label "Danger"; Color.red ]

    let styles =
        [ Html.div [ Html.div [ prop.className (fss baseStyle)
                                prop.text "This will be turquoise" ]

                     Html.div [ prop.className (fss <| danger @ baseStyle)
                                prop.text
                                    "This will be also be turquoise since the base styles overwrite the danger styles." ]

                     Html.div [ prop.className (fss <| baseStyle @ danger)
                                prop.text "This will be red" ] ] ]

    Page (Pages.FssPage Pages.Composition) styles

JsInterop.exportDefault Composition
