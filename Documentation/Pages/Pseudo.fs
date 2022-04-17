module Page.Pseudo

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Pseudo ()  =
    let hoverStyle =
        fss [ Label "Hover Style"
              Padding.value (px 40)
              Width.value (px 100)
              BackgroundColor.orangeRed
              FontSize.value (px 20)
              BorderRadius.value (px 5)
              Color.white
              Hover [ BackgroundColor.chartreuse
                      Color.black ] ]

    let beforeAndAfter =
        let beforeAndAfter =
            [ Content.value ""
              Display.inlineBlock
              BackgroundColor.orangeRed
              Width.value (px 10)
              Height.value (px 10) ]

        fss [ Label "Before And After"
              Before beforeAndAfter
              After beforeAndAfter ]

    let styles =
        [ Html.div [ prop.className hoverStyle
                     prop.text "Hover me!" ]
          Html.div [ prop.className beforeAndAfter
                     prop.text " Some content surrounded by stuff " ] ]
        
    Page Pages.Pseudo styles

JsInterop.exportDefault Pseudo