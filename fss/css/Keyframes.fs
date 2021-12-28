namespace Fss

open Fss.FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/@keyframes
[<AutoOpen>]
module Keyframes =

    type KeyframeAttribute =
        | Frame of int * Rule list
        | Frames of int list * Rule list

    let frame (f: int) (properties: Rule list) = (f, properties) |> Frame
    let frames (f: int list) (properties: Rule list) = (f, properties) |> Frames
