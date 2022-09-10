module Moon

open Feliz

let private iconBase (width: int) (height: int) (className: string) =
    Svg.svg [ svg.height height
              svg.width width
              svg.viewBox (0, 0, width, height)
              svg.className className
              svg.children [ Svg.path [ svg.d "M0 0h24v24H0z"
                                        svg.fill "none"
                                      ]
                             Svg.path [ svg.d "M10 7a7 7 0 0 0 12 4.9v.1c0 5.523-4.477 10-10 10S2 17.523 2 12 6.477 2 12 2h.1A6.979 6.979 0 0 0 10 7zm-6 5a8 8 0 0 0 15.062 3.762A9 9 0 0 1 8.238 4.938 7.999 7.999 0 0 0 4 12z"
                                        svg.fill "000" ]
                           ]
            ]

let iconNormal = iconBase 24 24 ""

let iconClassName className = iconBase 24 24 className
