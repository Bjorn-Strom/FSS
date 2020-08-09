namespace Fss

open FontFace
open Value
open Keyframes
open Types

module Fss =
    let fss (attributeList: CSSProperty list) = 
        attributeList |> createCSSObject |> css'

    let keyframes (attributeList: KeyframeAttribute list) = 
        attributeList |> createAnimationObject |> kframes'

    let fontFace (fontFamily: string) (attributeList: FontFace list) =
        attributeList |> createFontFaceObject fontFamily |> css'