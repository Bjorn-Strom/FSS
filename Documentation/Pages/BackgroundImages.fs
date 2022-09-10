module Page.BackgroundImages

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let BackgroundImages () =
    let box =
        [ Width.value (px 200)
          Height.value (px 200) ]

    let linearGradientStyle1 =
        fss [ Label "Linear gradient style 1"
              yield! box
              BackgroundImage.linearGradient (
                  (deg 0.,
                   [ hex "e66465", pct 0
                     hex "9198e5", pct 100 ])
              ) ]

    let linearGradientStyle2 =
        fss [ yield! box
              Label "Linear gradient style 2"
              BackgroundImage.linearGradient (
                  (turn 0.25,
                   [ hex "3f87a6", pct 0
                     hex "ebf8e1", pct 50
                     hex "f69d3c", pct 100 ])
              ) ]

    let linearGradientStyle3 =
        fss [ yield! box
              Label "Linear gradient style 3"
              BackgroundImage.linearGradient (
                  (deg 270.,
                   [ hex "333", pct 0
                     hex "333", pct 50
                     hex "eee", pct 75
                     hex "333", pct 75 ])
              ) ]

    let repeatingLinearGradientStyle1 =
        fss [ yield! box
              Label "Repeating Linear gradient style 1"
              BackgroundImage.repeatingLinearGradient (
                  (deg 0.,
                   [ hex "e66465", px 0
                     hex "e66465", px 20
                     hex "9198e5", px 20
                     hex "9198e5", px 25 ])
              ) ]

    let repeatingLinearGradientStyle2 =
        fss [ yield! box
              Label "Repeating Linear gradient style 2"
              BackgroundImage.repeatingLinearGradient (
                  (deg 45.,
                   [ hex "3f87a6", px 0
                     hex "ebf8e1", px 15
                     hex "f69d3c", px 20 ])
              ) ]

    let repeatingLinearGradientsStyle3 =
        fss [ yield! box
              BackgroundImage.repeatingLinearGradients [ deg 217.,
                                                         [ rgba 255 0 0 0.8, pct 0
                                                           rgba 255 0 0 0.0, pct 70 ]
                                                         deg 127.,
                                                         [ rgba 0 255 0 0.8, pct 0
                                                           rgba 0 255 0 0.0, pct 70 ]
                                                         deg 336.,
                                                         [ rgba 0 0 255 0.8, pct 0
                                                           rgba 0 0 255 0.0, pct 70 ] ] ]

    let radialGradientStyle1 =
        fss [ yield! box
              Label "Radial Gradient style 1"
              BackgroundImage.radialGradient (
                  Fss.Types.Image.Ellipse,
                  Fss.Types.Image.FarthestCorner,
                  pct 50,
                  pct 50,
                  [ hex "e66465", pct 0
                    hex "9198e5", pct 100 ]
              ) ]

    let radialGradientStyle2 =
        fss [ Label "Radial Gradient style 2"
              yield! box
              BackgroundImage.radialGradient (
                  Fss.Types.Image.Ellipse,
                  Fss.Types.Image.ClosestSide,
                  pct 50,
                  pct 50,
                  [ hex "3f87a6", pct 0
                    hex "ebf8e1", pct 50
                    hex "f69d3c", pct 100 ]
              ) ]

    let radialGradientStyle3 =
        fss [ yield! box
              Label "Radial Gradient style 3"
              BackgroundImage.radialGradient (
                  Fss.Types.Image.Circle,
                  Fss.Types.Image.FarthestCorner,
                  pct 100,
                  pct 50,
                  [ hex "333", pct 0
                    hex "333", pct 50
                    hex "eee", pct 75
                    hex "333", pct 75 ]
              ) ]

    let repeatingRadialGradientStyle1 =
        fss [ Label "Repeating Radial Gradient style 1"
              yield! box
              BackgroundImage.repeatingRadialGradient (
                  Fss.Types.Image.Ellipse,
                  Fss.Types.Image.FarthestCorner,
                  pct 50,
                  pct 50,
                  [ hex "e66465", pct 0
                    hex "9198e5", pct 20 ]
              ) ]

    let repeatingRadialGradientStyle2 =
        fss [ Label "Repeating Radial Gradient style 2"
              yield! box
              BackgroundImage.repeatingRadialGradient (
                  Fss.Types.Image.Ellipse,
                  Fss.Types.Image.ClosestSide,
                  pct 50,
                  pct 50,
                  [ hex "3f87a6", pct 0
                    hex "ebf8e1", pct 50
                    hex "f69d3c", pct 100 ]
              ) ]

    let repeatingRadialGradientStyle3 =
        fss [ Label "Repeating Radial Gradient style 3"
              yield! box
              BackgroundImage.repeatingRadialGradient (
                  Fss.Types.Image.Circle,
                  Fss.Types.Image.FarthestCorner,
                  pct 100,
                  pct 50,
                  [ hex "333", px 0
                    hex "333", px 10
                    hex "eee", px 10
                    hex "eee", px 20 ]
              ) ]

    let conicGradientStyle1 =
        fss [ Label "Conic gradient style 1"
              yield! box
              BackgroundImage.conicGradient (
                  deg 0.,
                  pct 50,
                  pct 50,
                  [ Fss.Types.Color.Red, deg 0.
                    Fss.Types.Color.Orange, deg 90.
                    Fss.Types.Color.Yellow, deg 180.
                    Fss.Types.Color.Green, deg 270.
                    Fss.Types.Color.Blue, deg 360. ]
              ) ]

    let conicGradientStyle2 =
        fss [ Label "Conic gradient style 2"
              yield! box
              BackgroundImage.conicGradient (
                  rad 3.1416,
                  pct 10,
                  pct 50,
                  [ hex "#e66465", deg 0.
                    hex "#9198e5", deg 360. ]
              ) ]

    let conicGradientStyle3 =
        fss [ Label "Conic gradient style 3"
              yield! box
              BackgroundImage.conicGradient (
                  deg 0.,
                  pct 50,
                  pct 50,
                  [ Fss.Types.Color.Red, deg 6.
                    Fss.Types.Color.Orange, deg 6.
                    Fss.Types.Color.Orange, deg 18.
                    Fss.Types.Color.Yellow, deg 18.
                    Fss.Types.Color.Yellow, deg 45.
                    Fss.Types.Color.Green, deg 45.
                    Fss.Types.Color.Green, deg 110.
                    Fss.Types.Color.Blue, deg 110.
                    Fss.Types.Color.Blue, deg 200.
                    Fss.Types.Color.Purple, deg 200. ]
              ) ]

    let conicGradientStyle4 =
        fss [ Label "Conic gradient style 4"
              yield! box
              BorderRadius.value (px 200)
              BackgroundImage.conicGradient (
                  deg 0.,
                  pct 50,
                  pct 50,
                  [ Fss.Types.Color.Yellow, deg (360. / 6.)
                    Fss.Types.Color.Lime, deg <| (360. / 6.) * 2.
                    Fss.Types.Color.Blue, deg <| (360. / 6.) * 3.
                    Fss.Types.Color.Violet, deg <| (360. / 6.) * 4.
                    Fss.Types.Color.Red, deg <| (360. / 6.) * 5.
                    Fss.Types.Color.Yellow, deg <| (360. / 6.) * 6. ]
              ) ]

    let repeatingConicGradientStyle =
        fss [ Label "Repeating conic gradient style"
              yield! box
              BackgroundSize.value (px 50, px 50)
              BorderColor.black
              BorderStyle.solid
              BorderWidth.value (px 1)
              BackgroundImage.repeatingConicGradient (
                  deg 0.,
                  pct 50,
                  pct 50,
                  [ Fss.Types.Color.White, pct 0
                    Fss.Types.Color.White, pct 25
                    Fss.Types.Color.Black, pct 25
                    Fss.Types.Color.Black, pct 50 ]
              ) ]

    let styles =
        [ Html.div [ prop.className (fss [ Label "Flex 1"; Display.flex ])
                     prop.children [ Html.div [ prop.className linearGradientStyle1 ]
                                     Html.div [ prop.className linearGradientStyle2 ]
                                     Html.div [ prop.className linearGradientStyle3 ] ] ]
          Html.div [ prop.className (fss [ Label "Flex 2"; Display.flex ])
                     prop.children [ Html.div [ prop.className repeatingLinearGradientStyle1 ]
                                     Html.div [ prop.className repeatingLinearGradientStyle2 ]
                                     Html.div [ prop.className repeatingLinearGradientsStyle3 ] ] ]
          Html.div [ prop.className (fss [ Label "Flex 3"; Display.flex ])
                     prop.children [ Html.div [ prop.className radialGradientStyle1 ]
                                     Html.div [ prop.className radialGradientStyle2 ]
                                     Html.div [ prop.className radialGradientStyle3 ] ] ]
          Html.div [ prop.className (fss [ Label "Flex 4"; Display.flex ])
                     prop.children [ Html.div [ prop.className repeatingRadialGradientStyle1 ]
                                     Html.div [ prop.className repeatingRadialGradientStyle2 ]
                                     Html.div [ prop.className repeatingRadialGradientStyle3 ] ] ]
          Html.div [ prop.className (fss [ Label "Flex 1"; Display.flex ])
                     prop.children [ Html.div [ prop.className conicGradientStyle1 ]
                                     Html.div [ prop.className conicGradientStyle2 ]
                                     Html.div [ prop.className conicGradientStyle3 ]
                                     Html.div [ prop.className conicGradientStyle4 ] ] ]
          Html.div [ prop.className (fss [ Label "Flex 1"; Display.flex ])
                     prop.children [ Html.div [ prop.className repeatingConicGradientStyle ] ] ] ]

    Page (Pages.FssPage Pages.BackgroundImages) styles

JsInterop.exportDefault BackgroundImages
