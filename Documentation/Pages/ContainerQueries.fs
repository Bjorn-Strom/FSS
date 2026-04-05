module Page.ContainerQueries

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let ContainerQueries () =
    let sliderValue, setSliderValue = React.useState 800

    let outerWrapper =
        fss [ Display.flex
              FlexDirection.column
              Gap.value (px 16) ]

    let sliderStyle =
        fss [ Width.value (pct 100)
              Cursor.pointer ]

    let sliderLabel =
        fss [ FontFamily.value "monospace"
              FontSize.value (px 14)
              Color.gray ]

    let container =
        fss [ ContainerType.inlineSize
              Display.flex
              FlexWrap.wrap
              Gap.value (px 16)
              Padding.value (px 16)
              BackgroundColor.hex "#f0f0f0"
              BorderRadius.value (px 8) ]

    let card =
        fss [ Display.flex
              FlexDirection.column
              BackgroundColor.white
              BorderRadius.value (px 8)
              Overflow.hidden
              BoxShadow.value (px 0, px 2, px 8, Fss.Types.Color.Rgba(0, 0, 0, 0.1))
              Width.value (pct 100)

              Container.query [ Container.MinWidth (px 500) ] [
                  FlexDirection.row
              ] ]

    let cardImage =
        fss [ BackgroundColor.hex "#6c5ce7"
              MinHeight.value (px 120)
              Display.flex
              AlignItems.center
              JustifyContent.center
              Color.white
              FontWeight.bold
              FontSize.value (px 18)
              Padding.value (px 16)

              Container.query [ Container.MinWidth (px 500) ] [
                  MinWidth.value (px 180)
                  MinHeight.auto
              ] ]

    let cardBody =
        fss [ Padding.value (px 16)
              Display.flex
              FlexDirection.column
              Gap.value (px 8) ]

    let cardTitle =
        fss [ FontWeight.bold
              FontSize.value (px 16)
              Margin.value (px 0)

              Container.query [ Container.MinWidth (px 500) ] [
                  FontSize.value (px 20)
              ] ]

    let cardText =
        fss [ FontSize.value (px 14)
              Color.hex "#666"
              LineHeight.value 1.5
              Margin.value (px 0) ]

    let cardTag =
        fss [ Display.none

              Container.query [ Container.MinWidth (px 500) ] [
                  Display.inlineBlock
                  BackgroundColor.hex "#dfe6e9"
                  Padding.value (px 4, px 8)
                  BorderRadius.value (px 4)
                  FontSize.value (px 12)
                  Color.hex "#636e72"
              ] ]

    let makeCard (color: string) (icon: string) (title: string) (text: string) (tag: string) =
        Html.div [ prop.className card
                   prop.children [
                       Html.div [ prop.className cardImage
                                  prop.style [ style.backgroundColor color ]
                                  prop.text icon ]
                       Html.div [ prop.className cardBody
                                  prop.children [
                                      Html.p [ prop.className cardTitle; prop.text title ]
                                      Html.p [ prop.className cardText; prop.text text ]
                                      Html.span [ prop.className cardTag; prop.text tag ] ] ] ] ]

    let styles =
        [ Html.div [ prop.className outerWrapper
                     prop.children [
                         Html.div [
                             Html.label [ prop.className sliderLabel
                                          prop.text $"Container width: {sliderValue}px" ]
                             Html.input [ prop.type'.range
                                          prop.min 250
                                          prop.max 900
                                          prop.value sliderValue
                                          prop.className sliderStyle
                                          prop.onChange (fun (v: int) -> setSliderValue v) ] ]
                         Html.div [ prop.className container
                                    prop.style [ style.width sliderValue ]
                                    prop.children [
                                        makeCard "#6c5ce7" "CSS" "Container Queries"
                                            "Style elements based on their container size, not the viewport."
                                            "Layout"
                                        makeCard "#00b894" "F#" "Type-Safe Styling"
                                            "Fss gives you compile-time guarantees for your CSS."
                                            "DX"
                                        makeCard "#e17055" "Fss" "Reusable Components"
                                            "Cards adapt to their container. Same component, any context."
                                            "Architecture" ] ] ] ] ]

    Page (Pages.FssPage Pages.ContainerQueries) styles

JsInterop.exportDefault ContainerQueries
