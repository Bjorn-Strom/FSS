module Page.Colors

open Fss
open Fss.Types
open Feliz
open Fable.Core

[<ReactComponent>]
let Colors () =
    let lightDarkBox =
        fss [ Label "Light Dark Box"
              Color.lightDark (Fss.Types.Color.Hex "1a1a2e") (Fss.Types.Color.Hex "f5f5dc")
              BackgroundColor.lightDark (Fss.Types.Color.Hex "fffbe6") (Fss.Types.Color.Hex "1a1a2e")
              Border.value(px 3, Border.Style.Solid, lightDark (Fss.Types.Color.Hex "e6a817") (Fss.Types.Color.Hex "7c6fe0"))
              Padding.value (px 24)
              BorderRadius.value (px 8)
              FontSize.value (px 16) ]

    let colorMixExample =
        fss [ Label "Color Mix"
              BackgroundColor.colorMix "srgb" Fss.Types.Color.Red 50 Fss.Types.Color.Blue 50
              Color.white
              Padding.value (px 16)
              BorderRadius.value (px 8)
              TextAlign.center ]

    let styles =
        [ Html.div [ prop.className lightDarkBox
                     prop.text "This box uses light-dark() — toggle the theme to see it change!" ]
          Html.div [ prop.className colorMixExample
                     prop.text "color-mix(in srgb, red 50%, blue 50%)" ] ]

    Page (Pages.FssPage Pages.Colors) styles

JsInterop.exportDefault Colors
