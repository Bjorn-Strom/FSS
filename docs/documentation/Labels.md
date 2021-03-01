## Labels

[Labels](https://emotion.sh/docs/labels) is yet another benefit from using [Emotion-Js](https://github.com/emotion-js/emotion) . It is a CSS property called label which appends any name to the generated classname making it more readable.
```fsharp
let styleWithoutLabel = fss [ Color.red ]
let styleWithLabel = fss [ Color.hotPink; Label' "HotPinkLabel" ]
div [ ClassName styleWithoutLabel ] [ str styleWithoutLabel ]
div [ ClassName styleWithLabel ] [ str styleWithLabel ]
```