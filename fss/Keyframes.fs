namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Utilities.Types

module Keyframes =
    [<Import("keyframes", from="emotion")>]
    let private kframes(x) = jsNative
    let private kframes' x = kframes(x)

    type Frame = int

    let frame (n: Frame) (props: ICss list) = 0 // "0%": "background-color: red"

    let keyframes = 0

    (*
        keyframes
            [
                frame 0, [] 
                frames [ [0; 100] , []]
            ]
    *)
