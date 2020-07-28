namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Value
open Utilities.Helpers

// https://developer.mozilla.org/en-US/docs/Web/CSS/@keyframes
module Keyframes =
    [<Import("keyframes", from="emotion")>]
    let private kframes(x) = jsNative
    let kframes' x = kframes(x)

    type KeyframeAttribute =
        | Frame of int * CSSProperty list
        | Frames of int list * CSSProperty list

    let frameValue f = sprintf "%d%%" f
    let frameValues fs = combineList fs frameValue ", "

    let rec createAnimationObject (attributeList: KeyframeAttribute list) =
        attributeList
        |> List.map (
            function 
                | Frame (f, ps) -> frameValue f ==> createCSSObject ps
                | Frames (fs, ps) -> frameValues fs ==> createCSSObject ps
        ) |> createObj

    let frame (f: int) (properties: CSSProperty list) = (f, properties) |> Frame
    let frames (f: int list) (properties: CSSProperty list) = (f, properties) |> Frames