namespace FSSTests

open Fet
open Utils
open Fss

module Composite =
    let counter =
        counterStyle [ System.cyclic
                       Symbols.value [ "" ]
                       Suffix.value " "
                       Prefix.value " " ]

    let font =
        fontFace
            "DroidSerif"
            [ Src.truetype "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf"
              FontFace.FontWeight.value 100
              FontFace.FontStyle.normal ]

    //// TODO: FIX
    let counterStyle =
        fss [ ListStyleType.ident (fst counter)
              FontFamily.value (fst font)
              ! FssTypes.Html.Li [ After [ Content.value "."  ]] 
              ! FssTypes.Html.Li [
                  BackgroundColor.aliceBlue
                  Hover [ BackgroundColor.orangeRed ]
              ]
              Label "counter"
              ]

    let container =
        fss [ Display.flex
              FlexDirection.column
              AlignItems.center
              JustifyContent.center
              Label "container" ]

    let spinimation =
        keyframes [ frame 0 [ Custom "transform" "rotate(0deg)" ]
                    frame 100 [ Custom "transform" "rotate(360deg)" ] ]

    let title =
        fss [ AnimationName.value (fst spinimation)
              AnimationDuration.value (sec 1)
              AnimationIterationCount.infinite
              FontFamily.value "DroidSerif"
              Hover [ AnimationDuration.value (ms 500) ]
              Media.query [ FssTypes.Media.MaxWidth(px 600) ] [
                  BackgroundColor.hex "87ceeb"
              ]
              Label "title"
            ]
    let composition =
        ([$"@counter-style {fst counter} {{ {snd counter} }}"
          $"@font-face {{ {snd font} }}"
          yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") counterStyle
          yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") container
          $"@keyframes {fst spinimation} {{ {snd spinimation} }}"
          yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") title
        ]
        |> String.concat "").Replace(" ", "").Replace("\n", "")
        
    let correct =
        (String.concat ""
          [ "@counter-style counter-1307384566 { system: cyclic;"
            "symbols: \"\";"
            "suffix: \" \";"
            "prefix: \" \"; }"
            "@font-face { font-family: \"DroidSerif\";"
            "src: url(https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf) format('truetype');"
            "font-weight: 100;"
            "font-style: normal; }"
            ".css-1809775240-counter { list-style-type: counter-1307384566;font-family: DroidSerif; }"
            ".css-1809775240-counter + li::after { content: \".\"; }"
            ".css-1809775240-counter + li { background-color: aliceblue; }"
            ".css-1809775240-counter + li:hover { background-color: orangered; }"
            ".css-525896048-container { display: flex;flex-direction: column;align-items: center;justify-content: center; }"
            "@keyframes animation-449288920 {  0% { transform: rotate(0deg); } 100% { transform: rotate(360deg); } }"
            ".css--1116097773-title { animation-name: animation-449288920;animation-duration: 1s;animation-iteration-count: infinite;font-family: DroidSerif; }"
            ".css--1116097773-title:hover { animation-duration: 500ms; }"
            "@media (max-width: 600px)  { .css--1116097773-title  { background-color: #87ceeb; }; }" ]).Replace(" ", "").Replace("\n", "")
        
    let tests =
       testList "Composite"
           [
               test "CompositeTest" <| fun _ ->
                   Expect.equal composition correct
           ]