module App

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Browser

open src.Arithmetic
open src.POJO


type Model =
    { Count: int; InputA: int; InputB: int; Result: int }

type Msg =
    | Increment
    | Decrement
    | AddInputA of int
    | AddInputB of int
    | SetResult of int

let init() =
    { Count = 0; InputA = 0; InputB = 0; Result = 0; }

let update (msg: Msg) (model: Model): Model =
    match msg with
    | Increment ->
        { model with Count = model.Count + 1 }

    | Decrement ->
        { model with Count = model.Count - 1 }

    | AddInputA number ->
        { model with InputA = number }

    | AddInputB number ->
        { model with InputB = number }

    | SetResult number ->
        { model with Result = number }


let render (model: Model) (dispatch: Msg -> unit) =

    console.log (createPersonPOJO ())
  
    div []
        [
            button [ OnClick (fun _ -> dispatch Increment);  ] [ str "+" ]
            button [ OnClick (fun _ -> dispatch Decrement)] [ str "-" ]
            str (string model.Count)


            div [ ]
                [
                    input [Type "Number"; Value model.InputA; OnChange (fun e -> dispatch <| AddInputA e.target?value)]
                    input [Type "Number"; Value model.InputB; OnChange (fun e -> dispatch <| AddInputB e.target?value)]

                    button [OnClick (fun _ -> dispatch <| SetResult (add model.InputA model.InputB))] [ str "Add"]
                    button [OnClick (fun _ -> dispatch <| SetResult (multiply model.InputA model.InputB))]  [ str "Multiply"]
                    button [OnClick (fun _ -> dispatch <| SetResult (subtract model.InputA model.InputB))]  [ str "Subtract"]
                    button [OnClick (fun _ -> dispatch <| SetResult (divide model.InputA model.InputB))]  [ str "Divide"]
                    str (string (sprintf "Result: %A" model.Result))
                ]
        ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
