namespace Fss

open Fss.Types

// https://developer.mozilla.org/en-US/docs/Web/CSS/@keyframes
[<AutoOpen>]
module Keyframes =

    type Keyframes =
        | Frame of int * Rule list
        | Frames of int list * Rule list

    /// A single percentage of time through an animation when a specified action should occur
    let frame (f: int) (properties: Rule list) = (f, properties) |> Frame
    /// A list percentages of time through an animation when a specified action should occur
    let frames (f: int list) (properties: Rule list) = (f, properties) |> Frames
