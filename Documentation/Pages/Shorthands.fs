module Page.Shorthands

open Fss
open Fss.Types
open Feliz
open Fable.Core

[<ReactComponent>]
let Shorthands () =
    let borderExample =
        fss [ Label "Border Shorthand"
              Border.value(px 2, Border.Style.Solid, hex "6495ed")
              Padding.value (px 16)
              BorderRadius.value (px 8) ]

    let outlineExample =
        fss [ Label "Outline Shorthand"
              Outline.value(px 3, Outline.Style.Dashed, hex "ff6347")
              Padding.value (px 16) ]

    let fontExample =
        fss [ Label "Font Shorthand"
              Font.value(px 24, "Georgia", style = Font.Style.Italic, weight = Font.Weight.Bold) ]

    let flexContainer =
        fss [ Label "Flex Container"
              Display.flex
              Gap.value (px 8) ]

    let flexGrow =
        fss [ Label "Flex Grow"
              Flex.value(grow = 1.0)
              BackgroundColor.value (hex "e0e7ff")
              Padding.value (px 12)
              BorderRadius.value (px 4)
              TextAlign.center ]

    let flexFixed =
        fss [ Label "Flex Fixed"
              Flex.value(grow = 0.0, shrink = 0.0, basis = px 120)
              BackgroundColor.value (hex "c7d2fe")
              Padding.value (px 12)
              BorderRadius.value (px 4)
              TextAlign.center ]

    let styles =
        [ Html.div [ prop.className borderExample
                     prop.text "Border: 2px solid cornflowerblue" ]
          Html.div [ prop.className outlineExample
                     prop.text "Outline: 3px dashed tomato" ]
          Html.p [ prop.className fontExample
                   prop.text "Font: italic bold 24px Georgia" ]
          Html.div [ prop.className flexContainer
                     prop.children [
                         Html.div [ prop.className flexFixed
                                    prop.text "Fixed 120px" ]
                         Html.div [ prop.className flexGrow
                                    prop.text "Grows" ]
                         Html.div [ prop.className flexFixed
                                    prop.text "Fixed 120px" ] ] ] ]

    Page (Pages.FssPage Pages.Shorthands) styles

JsInterop.exportDefault Shorthands
