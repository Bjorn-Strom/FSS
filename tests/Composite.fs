namespace FSSTests

open Fet
open Utils
open Fss

module CompositeTests =
    let counter =
        createCounterStyle [ System.cyclic
                             Symbols.value [ "" ]
                             Suffix.value " "
                             Prefix.value " " ]

    let font =
        createFontFace
            "DroidSerif"
            [ FontFace.Src.truetype "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf"
              FontFace.FontWeight.value 100
              FontFace.FontStyle.normal ]

    let counterStyle =
       createFss [ ListStyleType.value (fst counter)
                   FontFamily.value (fst font)
                   ! Fss.Types.Html.Li [ After [ Content.value "."  ]]
                   ! Fss.Types.Html.Li [
                       BackgroundColor.aliceBlue
                       Hover [ BackgroundColor.orangeRed ]
                   ]
                   ]

    let container =
       createFss [ Display.flex
                   FlexDirection.column
                   AlignItems.center
                   JustifyContent.center
                   Label "container" ]

    let spinimation =
        createAnimation [ frame 0 [ Custom "transform" "rotate(0deg)" ]
                          frame 100 [ Custom "transform" "rotate(360deg)" ] ]

    let title =
       createFss [ AnimationName.value (fst spinimation)
                   AnimationDuration.value (sec 1)
                   AnimationIterationCount.infinite
                   FontFamily.value "DroidSerif"
                   Hover [ AnimationDuration.value (ms 500) ]
                   Media.query [ Fss.Types.Media.MaxWidth(px 600) ] [
                       BackgroundColor.hex "87ceeb"
                   ]
                   Label "title"
                 ]
    let composition =
        ([$"@counter-style {fst counter} {snd counter}"
          $"@font-face {snd font}"
          $"{snd counterStyle}"
          $"{snd container}"
          $"@keyframes {snd spinimation}"
          $"{snd title}"]
        |> String.concat "")

    let tests =
       testList "Composite"
           [
               test "CompositeTest" <| fun _ ->
                   Expect.equal composition """@counter-style counter-815667792 {system:cyclic;symbols:"";suffix:" ";prefix:" ";}@font-face {font-family:"DroidSerif";src:url(https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf) format('truetype');font-weight:100;font-style:normal;}.css-164366737{list-style-type:counter-815667792;font-family:DroidSerif;}.css-164366737 li::after{content:".";}.css-164366737 li{background-color:aliceblue;}.css-164366737 li:hover{background-color:orangered;}.css-1041483133container{display:flex;flex-direction:column;align-items:center;justify-content:center;}@keyframes animation-553575156{0%{transform:rotate(0deg);}100%{transform:rotate(360deg);}}.css-1092777449title{animation-name:animation-553575156;animation-duration:1s;animation-iteration-count:infinite;font-family:DroidSerif;}.css-1092777449title:hover{animation-duration:500ms;}@media (max-width:600px) {.css-1092777449title{background-color:#87ceeb;}}"""
               testCase
                   "Important"
                   [ important Color.red ]
                   "{color:red !important;}"
               let _, actual = createFssWithClassname "myOwnClassName" [ BorderColor.red; BackgroundColor.green ]
               testEqual
                   "Test creating css with custom classname"
                   actual
                   ".myOwnClassName{border-color:red;background-color:green;}"
           ]
