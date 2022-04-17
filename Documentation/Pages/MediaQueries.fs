module Page.MediaQueries

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let MediaQueries () =
    let mediaQueryExamples =
        fss [ Label "Media query examples"
              Width.value (px 200)
              Height.value (px 200)
              BackgroundColor.blue

              Media.query [ Fss.Types.Media.MinWidth(px 700) ] [
                  BackgroundColor.pink
                  Color.orangeRed
              ]

              Media.queryFor
                  Fss.Types.Media.Print
                  []
                  [ MarginTop.value (px 200)
                    Transform.value [ Transform.rotate (deg 45.0) ]
                    BackgroundColor.red ]

              Media.query [ Fss.Types.Media.Orientation Fss.Types.Media.Landscape ] [
                  Color.green
                  BackgroundColor.orangeRed
                  FontSize.value (px 28)
              ] ]

    let styles =
        [ Html.div [ prop.className mediaQueryExamples
                     prop.text "Changing width changes me" ] ]

    Page Pages.MediaQueries styles

JsInterop.exportDefault MediaQueries
