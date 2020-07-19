namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Utilities.Types


open Color


module Keyframes =
    [<Import("keyframes", from="emotion")>]
    let private kframes(x) = jsNative
    let kframes' x = kframes(x)


    type KeyframeAttribute =
        | Frame of int * ICSSProperty list
        | Frames of int list * ICSSProperty list

    let rec private createPOJO (attributeList: KeyframeAttribute list) =
        attributeList
        |> List.map (
            function 
                | Frame (f, ps) -> sprintf "%d%%" f ==> "foo"
        )

        (*

            keyframes
                [
                    frame 0, [ BackgroundColor red; Color blue ]
                ]

        *)


        (*
                [
                    "background-color" ==> "red"
                    "color" ==> "blue"
                ]
            "100%" ==> createObj
                [
                    "background-color" ==> "blue"
                    "color" ==> "red"
                ]
        ]
        *)

    (*
    type Frame = int

    let frame (n: Frame) (props: ICSSProperty list) = 0 
    
        {
            "0%": { "background-color: red", "color: blue" }
            "100%": { "background-color: blue", "color: red"}
        }

    type KeyFrame = 
        | KeyFrame of obj
        interface IAnimation

    let keyframes = 0

        keyframes
            [
                frame 0, [] 
                frames [ [0; 100] , []]
            ]
    *)
