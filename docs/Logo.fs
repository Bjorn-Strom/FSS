namespace Docs

open Fable.React
open Fable.React.Props

module Logo =
    let private logoBase width height =
        svg
            [ SVGAttr.Height height
              SVGAttr.Width width
              SVGAttr.ViewBox "0 0 91 91"
              SVGAttr.Fill "none"
              ]
            [
                path [ D "M15.4417 79.3631L9.11028 4.7064L81.6526 5.06075L74.9261 79.3839L45.3774 88.0067L15.4417 79.3631Z"; SVGAttr.Fill "#27303B"; SVGAttr.Stroke "#9A9A9A" ] [ ]
                path [ D "M46 10.178V82.5L70.0933 75.6198L76.2301 10.178H46Z"; SVGAttr.Fill "#29A9DF" ] [ ]
                path [ D "M44 16V31L29.4003 45.0098L44 59V74L14.382 44.9632L44 16Z"; SVGAttr.Fill "#29A9DF" ] [ ]
                path [ D "M46 16V31L60.0484 45.1667L46 59.1427V74L75.3403 45.1198L46 16Z"; SVGAttr.Fill "#27303B" ] [ ]
                path [ D "M43.5746 34.8877L43.4707 54.9806L33.2294 44.947L43.5746 34.8877"; SVGAttr.Fill "white" ] [ ]
            ]

    let logoNormal = logoBase 91 91

    let logo width height = logoBase width height