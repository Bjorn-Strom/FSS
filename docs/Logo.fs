namespace Docs

open Feliz

module Logo =
    let private logoBase (width: float) (height: float) (className: string) =
        Svg.svg
            [ svg.height height
              svg.width width
              svg.viewBox(0, 0, 256, 256)
              svg.className className
              svg.children
                [
                    Svg.path [
                        svg.d"M42.5899 223.961L24.6418 12.3286L230.696 13.3351L211.628 224.019L127.656 248.523L42.5899 223.961Z"
                        svg.fill "#27303B"
                        svg.stroke "#9A9A9A" ]
                    Svg.path [
                        svg.d "M127 28V232L196.339 212.593L214 28H127Z"
                        svg.fill "#29A9DF" ]
                    Svg.path [
                        svg.d "M127 45V87.1552L84.1148 126.528L127 165.845V208L40 126.397L127 45Z"
                        svg.fill "#29A9DF" ]
                    Svg.path [
                        svg.d "M127 45V87.1552L167.699 126.968L127 166.246V208L212 126.837L127 45Z"
                        svg.fill "#27303B"
                    ]
                ]
                ]

    let logoNormal = logoBase 256 256 ""

    let logo width height className = logoBase width height className