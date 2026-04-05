module Theme

type Theme =
    { BackgroundColor: Fss.Types.Color.Color
      TextColor: Fss.Types.Color.Color
      Opposite: Fss.Types.Color.Color
      TopBar: Fss.Types.Color.Color
      Accent: Fss.Types.Color.Color
      CodeBackground: Fss.Types.Color.Color
      BorderColor: Fss.Types.Color.Color
      MutedText: Fss.Types.Color.Color
    }

let LightTheme =
    { BackgroundColor = Fss.Types.Color.Hex "fff"
      TextColor = Fss.Types.Color.Black
      Opposite = Fss.Types.Color.Hex "191919"
      TopBar = Fss.Types.Color.Hex "fff"
      Accent = Fss.Types.Color.Hex "29A9DF"
      CodeBackground = Fss.Types.Color.Hex "f6f8fa"
      BorderColor = Fss.Types.Color.Hex "e1e4e8"
      MutedText = Fss.Types.Color.Hex "6a737d"
    }

let DarkTheme =
    { BackgroundColor = Fss.Types.Color.Hex "191919"
      TextColor = Fss.Types.Color.LightGray
      Opposite = Fss.Types.Color.Hex "fff"
      TopBar = Fss.Types.Color.Hex "222222"
      Accent = Fss.Types.Color.Hex "29A9DF"
      CodeBackground = Fss.Types.Color.Hex "2d2d2d"
      BorderColor = Fss.Types.Color.Hex "444"
      MutedText = Fss.Types.Color.Hex "8b949e"
    }

let stringToTheme str =
    match str with
    | "dark" -> DarkTheme
    | "light" -> LightTheme
    | _ -> DarkTheme

open Browser
open Fable.Core.JsInterop
let initialTheme =
    let defaultDark = window.matchMedia("(prefers-color-scheme: dark").matches
    let storage = window.localStorage.getItem("theme")

    if isNullOrUndefined storage then
        if not defaultDark then
            LightTheme
        else
            DarkTheme
    else
        stringToTheme storage
