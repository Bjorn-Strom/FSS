## Counters

Counters are pretty cool and allows you to define style for well, counters.

You can use the counters as list style type or as content. Examples follow:

Example from [mdn](https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style).

```fsharp
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
```

<example/>

Another example found [here](https://codepen.io/mkmueller/pen/pHiqb)

```fsharp
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
```

<example/>
