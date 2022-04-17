module Page.Counters

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Counters () =
    let mozillaExampleCounter =
        counterStyle [ System.fixed'
                       Symbols.value [ "Ⓐ"
                                       "Ⓑ"
                                       "Ⓒ"
                                       "Ⓓ"
                                       "Ⓔ"
                                       "Ⓕ"
                                       "Ⓖ"
                                       "Ⓗ"
                                       "Ⓘ"
                                       "Ⓙ"
                                       "Ⓚ"
                                       "Ⓛ"
                                       "Ⓜ"
                                       "Ⓝ"
                                       "Ⓞ"
                                       "Ⓟ"
                                       "Ⓠ"
                                       "Ⓡ"
                                       "Ⓢ"
                                       "Ⓣ"
                                       "Ⓤ"
                                       "Ⓥ"
                                       "Ⓦ"
                                       "Ⓧ"
                                       "Ⓨ"
                                       "Ⓩ" ]
                       Suffix.value " " ]

    let mozillaExampleStyle =
        fss [ Label "Mozilla Example Style"
              ListStyleType.value mozillaExampleCounter ]

    let indexCounter =
        counterStyle [ CounterLabel "indexCounter" ]

    let subCounter =
        counterStyle [ CounterLabel "subCounter" ]

    let sectionStyle =
        fss [ Label "Section"
              FontFamily.value "Roboto, sans-serif"
              CounterReset.value indexCounter ]

    let commonBefore =
        [ FontWeight.value 500
          Color.hex "48f" ]

    let commonStyle =
        [ Margin.value (px 0, px 0, px 1)
          Padding.value (px 5, px 10) ]

    let count =
        fss [ Label "Count"
              yield! commonStyle
              CounterReset.value subCounter
              CounterIncrement.value indexCounter
              BackgroundColor.hex "#222426"
              Before [ yield! commonBefore
                       Content.counter (indexCounter, ". ") ] ]

    let sub =
        fss [ Label "Sub"
              yield! commonStyle
              CounterIncrement.value subCounter
              TextIndent.value (em 1.)
              Color.hex "BDB7AF"
              Before [ yield! commonBefore
                       Content.counter ([ indexCounter; subCounter ], [ "."; "." ])
                       MarginRight.value (px 5) ] ]

    let styles =
        [ Html.ul [ prop.className mozillaExampleStyle
                    prop.children [ Html.li "one"
                                    Html.li "two"
                                    Html.li "three"
                                    Html.li "four"
                                    Html.li "five"
                                    Html.li "one"
                                    Html.li "two"
                                    Html.li "three"
                                    Html.li "four"
                                    Html.li "five"
                                    Html.li "one"
                                    Html.li "two"
                                    Html.li "three"
                                    Html.li "four"
                                    Html.li "five"
                                    Html.li "one"
                                    Html.li "two"
                                    Html.li "three"
                                    Html.li "four"
                                    Html.li "five"
                                    Html.li "one"
                                    Html.li "two"
                                    Html.li "three"
                                    Html.li "four"
                                    Html.li "five"
                                    Html.li "one"
                                    Html.li "two"
                                    Html.li "three"
                                    Html.li "four"
                                    Html.li "five" ] ]
          Html.section [ prop.className sectionStyle
                         prop.children [ Html.p [ prop.className count
                                                  prop.text "Item" ]
                                         Html.p [ prop.className count
                                                  prop.text "Item" ]
                                         Html.p [ prop.className count
                                                  prop.text "Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ]
                                         Html.p [ prop.className count
                                                  prop.text "Item" ]
                                         Html.p [ prop.className count
                                                  prop.text "Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ]
                                         Html.p [ prop.className count
                                                  prop.text "Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ]
                                         Html.p [ prop.className count
                                                  prop.text "Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ]
                                         Html.p [ prop.className sub
                                                  prop.text "Sub-Item" ] ] ] ]

    Page Pages.Counters styles

JsInterop.exportDefault Counters
