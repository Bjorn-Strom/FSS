namespace Docs

open Fable.React
open Fable.React.Props

module Hamburger =
    let private hamburgerBase width height className =
        svg
            [ SVGAttr.Height height
              SVGAttr.Width width
              SVGAttr.ViewBox "0 0 512 512"
              ClassName className
              ]
            [
                path [ D "M80 160h352M80 256h352M80 352h352"; SVGAttr.Fill "none"; SVGAttr.StrokeLinecap "round"; SVGAttr.StrokeMiterlimit "10"; SVGAttr.StrokeWidth 32; SVGAttr.Stroke "#759DB2" ] []
            ]

    let hamburgerNormal = hamburgerBase 512 512 ""

    let hamburger width height className = hamburgerBase width height className