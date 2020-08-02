namespace Fss

open Value
open Keyframes

module Fss =
    let fss (attributeList: CSSProperty list) = 
        attributeList |> createCSSObject
        |> fun x -> 
            Browser.Dom.console.log x
            x
        |> css'

    let keyframes (attributeList: KeyframeAttribute list) = 
        attributeList |> createAnimationObject |> kframes'