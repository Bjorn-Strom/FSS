open Fss

let counter =
    counterStyle [ System.cyclic
                   Symbols.value [ "❤️"
                                   "✨"
                                   "🔥"
                                   "😊"
                                   "😂"
                                   "🥺"
                                   "❤️‍🔥"
                                   "👍"
                                   "🥰"
                                   "🐻"
                                   "🍔"
                                   "⚽"
                                   "💨"
                                   "🎨"
                                   " 🐶" ]
                   Suffix.value " "
                   Prefix.value " " ]

let font =
    fontFace
        "DroidSerif"
        [ Src.truetype "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf"
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

let foo =
    [
      $"@counter-style {fst counter} {{ {snd counter} }}"
      $"@font-face {{ {snd font} }}"
      yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") counterStyle
      yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") container
      $"@keyframes {fst spinimation} {{ {snd spinimation} }}"
      yield! List.map (fun x -> $"{fst x} {{ {snd x} }}") title
    ]
    |> String.concat "\n"

printfn "%A" foo
