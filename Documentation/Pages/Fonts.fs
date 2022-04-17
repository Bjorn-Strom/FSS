module Page.Fonts

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Fonts ()  =
    let grapeNutsStyle =
        fss [ Label "Grape Nuts Style"
              FontFamily.value "grapeNuts"
              FontSize.value (px 24) ]

    let droidSerifFont =
        fontFaces
            "DroidSerif"
            [ [ FontFace.Src.truetype("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf")
                FontFace.FontWeight.bold
                FontFace.FontStyle.normal
                FontFace.FontDisplay.swap ]
              [ FontFace.Src.truetype("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf")
                FontFace.FontWeight.normal
                FontFace.FontStyle.normal
                FontFace.FontDisplay.swap ] ]

    let modernaFont =
        fontFace
            "moderna"
            [ FontFace.Src.sources
                  [ Fss.Types.FontFace.Woff2 "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2"
                    Fss.Types.FontFace.Woff "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff"
                    Fss.Types.FontFace.Truetype "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf"
                    Fss.Types.FontFace.Svg "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg" ]
              FontFace.FontWeight.normal
              FontFace.FontStyle.normal
              FontFace.FontDisplay.swap ]

    let droidSerif =
        fss [ Label "Droid Serif"
              FontFamily.value droidSerifFont ]

    let droidSerifBold =
        fss [ Label "Droid Serif Bold"
              FontFamily.value droidSerifFont
              FontWeight.bold ]

    let moderna =
        fss [ Label "Moderna"
              FontFamily.value modernaFont ]

    let styles =
         [ Html.p [ prop.className grapeNutsStyle
                    prop.text "This font is Grape Nuts, some nice text this huh?" ]
           Html.div [ Html.p [ prop.text "Droid serif"
                               prop.className droidSerif ]
                      Html.p [ prop.text "Droid serif bold"
                               prop.className droidSerifBold
                                ]
                      Html.p [ prop.text "Moderna"
                               prop.className moderna
                                ] ] ]
        
    Page Pages.Fonts styles

JsInterop.exportDefault Fonts