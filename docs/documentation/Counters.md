## Counters

Counters are pretty cool and allows you to define style for well, counters.

You can use the counters as list style type or as content. Examples follow:

Example from [mdn](https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style).

```fsharp
let mozillaExampleCounter =
    counterStyle
        [
            System.fixed'
            Symbols.strings ["Ⓐ"; "Ⓑ"; "Ⓒ"; "Ⓓ"; "Ⓔ";
                              "Ⓕ"; "Ⓖ"; "Ⓗ"; "Ⓘ"; "Ⓙ";
                              "Ⓚ"; "Ⓛ"; "Ⓜ"; "Ⓝ"; "Ⓞ";
                              "Ⓟ"; "Ⓠ"; "Ⓡ"; "Ⓢ"; "Ⓣ";
                              "Ⓤ"; "Ⓥ"; "Ⓦ"; "Ⓧ"; "Ⓨ"; "Ⓩ"]
            Suffix.value " "
        ]
let mozillaExampleStyle = fss [ ListStyleType' mozillaExampleCounter ]
```

</example>

Another example found [here](https://codepen.io/mkmueller/pen/pHiqb)

```fsharp
let commonBefore =
    [
       FontWeight' (FssTypes.CssInt 500)
       Color.hex "48f"
   ]
let commonStyle =
   [
       Margin.value (px 0, px 0, px 1)
       Padding.value (px 5, px 10)
    ]
let count =
    fss
        [
            yield! commonStyle
            CounterReset' subCounter
            CounterIncrement' indexCounter
            BackgroundColor.hex "eee"
            Before
                [
                    yield! commonBefore
                    Content.counter(indexCounter,". ")
                ]
        ]
let sub =
    fss
        [
            yield! commonStyle
            CounterIncrement' subCounter
            TextIndent' (em 1.)
            Color.hex "444"
            Before
                [
                    yield! commonBefore
                    Content.counters([indexCounter; subCounter], [".";"."])
                    MarginRight' (px 5)
                ]
        ]
section [ ClassName sectionStyle ]
    [
        p [ ClassName count] [ str "Item" ]
        p [ ClassName count] [ str "Item" ]
        p [ ClassName count] [ str "Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
        p [ ClassName count] [ str "Item" ]
        p [ ClassName count] [ str "Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
        p [ ClassName count] [ str "Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
        p [ ClassName count] [ str "Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
        p [ ClassName sub] [ str "Sub-Item" ]
    ]
```

</example>
