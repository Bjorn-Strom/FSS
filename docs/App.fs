module App

open Feliz
open Feliz.Fss

[<ReactComponent>]
let Counter() =
    let (count, setCount) = React.useState(0)
    Html.div [
        Html.button [
            prop.style [ style.marginRight 5 ]
            prop.onClick (fun _ -> setCount(count + 1))
            prop.text "Increment"
        ]

        Html.button [
            prop.style [ style.marginLeft 5 ]
            prop.onClick (fun _ -> setCount(count - 1))
            prop.text "Decrement"
        ]

        Html.h1 [
            prop.text count
            prop.css [
                style.backgroundColor.green
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(Counter(), document.getElementById "elmish-app")