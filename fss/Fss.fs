namespace Fss

open Value
open Keyframes

module Fss =
    let fss (attributeList: CSSProperty list) = 
        attributeList |> createCSSObject |> css'

    let keyframes (attributeList: KeyframeAttribute list) = 
        attributeList |> createAnimationObject |> kframes'