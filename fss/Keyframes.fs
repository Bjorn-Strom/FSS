namespace Fss

open Fable.Core
open Fable.Core.JsInterop
open Utilities.Helpers

open FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/@keyframes
module Keyframes =
    [<ImportMember("@emotion/css")>]
    let private keyframes(x) = jsNative
    let keyframes' x = keyframes(x)

    type KeyframeAttribute =
        | Frame of int * CssProperty list
        | Frames of int list * CssProperty list

    let frameValue f = sprintf "%d%%" f
    let frameValues fs = combineList fs frameValue ", "

    let rec private createAnimation (attributeList: KeyframeAttribute list) callback =
        attributeList
        |> List.map (
            function
                | Frame (f, ps) ->
                    let ps' =
                        ps
                        |> List.map GlobalValue.CssValue
                    frameValue f ==> createObj ps'
                | Frames (fs, ps) ->
                    let ps' =
                        ps
                        |> List.map GlobalValue.CssValue
                    frameValues fs ==> (createObj ps')
        )
        |> callback

    let createAnimationRecord (attributeList: KeyframeAttribute list) = createAnimation attributeList id
    let createAnimationObject (attributeList: KeyframeAttribute list) = createAnimation attributeList createObj