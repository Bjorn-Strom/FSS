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
            [ FontFace.Src.truetype "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf"
              FontFace.FontWeight.value 100
              FontFace.FontStyle.normal ]

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
        $"{fst <| List.head counterStyle} {{"
        $"list-style-type: {fst counter};"
        "font-family: DroidSerif;"
        "}"
        $"{fst <| List.head counterStyle} li::after {{"
        "content: \".\";"
        "}"
        $"{fst <| List.head counterStyle} li {{"
        "background-color: aliceblue;"
        "}"
        $"{fst <| List.head counterStyle} li:hover {{"
        "background-color: orangered;"
        "}"
        $"{fst <| List.head container} {{"
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
        $"{fst <| List.head title} {{"
        $"animation-name: {fst spinimation};"
        "animation-duration: 1s;"
        "animation-iteration-count: infinite;"
        "font-family: DroidSerif;"
        "}"
        $"{fst <| List.head title}:hover {{"
        "animation-duration: 500ms;"
        "}"
        "@media (max-width: 600px) {"
        $"{fst <| List.head title} {{"
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
           
           
    printfn "%A" counterStyle