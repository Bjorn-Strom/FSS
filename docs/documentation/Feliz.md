### Feliz

New in Fss 2.0 is Feliz integration.
Just open the Feliz.Fss namespace and you are good to go.

Fss introduces a new member to the `prop` type called `css`.
Here you can write Fss as usual or by using the styles module.

```fsharp
open Feliz
open Feliz.Fss

[<ReactComponent>]
let Button() =
    Html.button [
        prop.css [
            style.backgroundColor.hex "44c767"
            style.borderRadius' (px 30)
            style.borderWidth' (px 1)
            style.borderStyle.solid
            style.borderColor.hex "18ab29"
            style.display.inlineBlock
            style.cursor.pointer
            style.fontSize' (px 17)
            style.hover
                [
                    BackgroundColor.hex "5cbf2a"
                ]
        ]
        prop.text "Click me"
    ]
```