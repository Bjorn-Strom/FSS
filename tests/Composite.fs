namespace FSSTests

open Fet
open Utils
open Fss

module Composite =
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
        createFss [ ListStyleType.ident (fst counter)
                    FontFamily.value (fst font)
                    ! FssTypes.Html.Li [ After [ Content.value "."  ]] 
                    ! FssTypes.Html.Li [
                        BackgroundColor.aliceBlue
                        Hover [ BackgroundColor.orangeRed ]
                    ]
                    Label "counter"
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
                    Media.query [ FssTypes.Media.MaxWidth(px 600) ] [
                        BackgroundColor.hex "87ceeb"
                    ]
                    Label "title"
                  ]
    let composition =
        ([$"@counter-style {fst counter} {{ {snd counter} }}"
          $"@font-face {{ {snd font} }}"
          yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") (snd counterStyle)
          yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") (snd container)
          $"@keyframes {fst spinimation} {{ {snd spinimation} }}"
          yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") (snd title)
        ]
        |> String.concat "").Replace(" ", "").Replace("\n", "")
        
    let correct = ([
        $"@counter-style {fst counter} {{"
        "system: cyclic;"
        "symbols: \"\";"
        "suffix: \"\";"
        "prefix: \"\";"
        "}"
        "@font-face {"
        "font-family: \"DroidSerif\";"
        "src: url(https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf)"
        "format('truetype');"
        "font-weight: 100;"
        "font-style: normal;"
        "}"
        $"{fst <| List.head (snd counterStyle)} {{"
        $"list-style-type: {fst counter};"
        "font-family: DroidSerif;"
        "}"
        $"{fst <| List.head (snd counterStyle)} li::after {{"
        "content: \".\";"
        "}"
        $"{fst <| List.head (snd counterStyle)} li {{"
        "background-color: aliceblue;"
        "}"
        $"{fst <| List.head (snd counterStyle)} li:hover {{"
        "background-color: orangered;"
        "}"
        $"{fst <| List.head (snd container)} {{"
        "display: flex;"
        "flex-direction: column;"
        "align-items: center;"
        "justify-content: center;"
        "}"
        $"@keyframes {fst spinimation} {{"
        "0% {"
        "transform: rotate(0deg);"
        "}"
        "100% {"
        "transform: rotate(360deg);"
        "}"
        "}"
        $"{fst <| List.head (snd title)} {{"
        $"animation-name: {fst spinimation};"
        "animation-duration: 1s;"
        "animation-iteration-count: infinite;"
        "font-family: DroidSerif;"
        "}"
        $"{fst <| List.head (snd title)}:hover {{"
        "animation-duration: 500ms;"
        "}"
        "@media (max-width: 600px) {"
        $"{fst <| List.head (snd title)} {{"
        "background-color: #87ceeb;"
        "};}" ] |> String.concat "").Replace(" ", "").Replace("\n", "")
        
    let tests =
       testList "Composite"
           [
               test "CompositeTest" <| fun _ ->
                   Expect.equal composition correct
               testCase
                   "Important"
                   [ important Color.red ]
                   "color: red !important;"
           ]