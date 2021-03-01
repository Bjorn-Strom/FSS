## Counters

Counters are pretty cool and allows you to define style for well, counters.

You can use the counters as list style type or as content. Examples follow:

Example from [mdn](https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style).

```fsharp
let mozillaExampleCounter =
    counterStyle
        [
            System.Fixed
            Symbols.Strings ["Ⓐ"; "Ⓑ"; "Ⓒ"; "Ⓓ"; "Ⓔ";
                              "Ⓕ"; "Ⓖ"; "Ⓗ"; "Ⓘ"; "Ⓙ";
                              "Ⓚ"; "Ⓛ"; "Ⓜ"; "Ⓝ"; "Ⓞ";
                              "Ⓟ"; "Ⓠ"; "Ⓡ"; "Ⓢ"; "Ⓣ";
                              "Ⓤ"; "Ⓥ"; "Ⓦ"; "Ⓧ"; "Ⓨ"; "Ⓩ"]
            Suffix.Value " "
        ]
let mozillaExampleStyle = fss [ ListStyleType' mozillaExampleCounter ]
```

Another example found [here](https://codepen.io/mkmueller/pen/pHiqb)

```fsharp
let commonBefore =
    [
       FontWeight' (CssInt 500)
       Color.Hex "48f"
   ]
let commonStyle =
   [
       Margin.Value (px 0, px 0, px 1)
       Padding.Value (px 5, px 10)
    ]
let count =
    fss
        [
            yield! commonStyle
            CounterReset' subCounter
            CounterIncrement' indexCounter
            BackgroundColor.Hex "eee"
            Before
                [
                    yield! commonBefore
                    Content.Counter(indexCounter,". ")
                ]
        ]
let sub =
    fss
        [
            yield! commonStyle
            CounterIncrement' subCounter
            TextIndent' (em 1.)
            Color.Hex "444"
            Before
                [
                    yield! commonBefore
                    Content.Counters([indexCounter; subCounter], [".";"."])
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