module Page.Pseudo

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Pseudo () =
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

    let highlightStyle =
        fss [ Label "Highlight"
              BackgroundColor.yellow
              Padding.value (px 4) ]

    let containerStyle =
        fss [ Label "Has Container"
              Padding.value (px 16)
              Border.value (px 2, Border.Style.Solid, Fss.Types.Color.Gray)
              Has [Selector.Class highlightStyle] [
                  BorderColor.orange
                  Border.value (px 2, Border.Style.Solid, Fss.Types.Color.Orange)
              ] ]

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
          Html.div [ prop.className containerStyle
                     prop.children [
                         Html.p [ prop.text "This container has a " ]
                         Html.span [ prop.className highlightStyle
                                     prop.text "highlighted" ]
                         Html.p [ prop.text " child — so it gets an orange border via :has()" ]
                     ] ]
          Html.div [ prop.className beforeAndAfter
                     prop.text " Some content surrounded by stuff " ] ]

    Page (Pages.FssPage Pages.Pseudo) styles

JsInterop.exportDefault Pseudo
