module Hamburger
    
open Feliz
let private hamburgerBase (width: int) (height: int) (className: string) =
    Svg.svg
        [ svg.height height
          svg.width width
          svg.viewBox(0, 0, 512, 512)
          svg.className className
          svg.children
        [
            Svg.path [
                svg.d "M80 160h352M80 256h352M80 352h352"
                svg.fill "none"
                //svg.stroke SVGAttr.StrokeLinecap "round";
                //lSVGAttr.StrokeMiterlimit "10";
                svg.strokeWidth 32
                svg.stroke "#759DB2"
            ]
        ]]

let hamburgerNormal = hamburgerBase 512 512 ""

let hamburger width height className = hamburgerBase width height className