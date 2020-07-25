namespace Fss

open Value

module Fss =
    let fss (attributeList: CSSProperty list) = 
        attributeList |> createCSSObject |> css'

