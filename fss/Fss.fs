namespace Fss

open Css

module Fss =
    let fss (attributeList: CSSProperty list) = 
        attributeList |> createCSSObject |> css'

