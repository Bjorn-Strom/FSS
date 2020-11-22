namespace Fss

open Fable.Core
open Fable.Core.JsInterop
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

    let rec private createAnimation (attributeList: KeyframeAttribute list) callback =
        attributeList
        |> List.map (
            function
                | Frame (f, ps) ->
                    let ps' =
                        ps
                        |> List.map GlobalValue.CSSValue
                    frameValue f ==> createObj ps'
                | Frames (fs, ps) ->
                    let ps' =
                        ps
                        |> List.map GlobalValue.CSSValue
                    frameValues fs ==> (createObj ps')
        )
        |> callback

    let createAnimationRecord (attributeList: KeyframeAttribute list) = createAnimation attributeList id
    let createAnimationObject (attributeList: KeyframeAttribute list) = createAnimation attributeList createObj