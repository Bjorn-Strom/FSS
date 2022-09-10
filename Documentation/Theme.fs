module Theme

type Theme =
    { BackgroundColor: Fss.Types.Color.Color
      TextColor: Fss.Types.Color.Color
      Opposite: Fss.Types.Color.Color
      TopBar: Fss.Types.Color.Color
    }

let LightTheme =
    { BackgroundColor = Fss.Types.Color.Hex "fff"
      TextColor = Fss.Types.Color.Black
      Opposite = Fss.Types.Color.Hex "191919"
      TopBar = Fss.Types.Color.Hex "fff"
    }

let DarkTheme =
    { BackgroundColor = Fss.Types.Color.Hex "191919"
      TextColor = Fss.Types.Color.LightGray
      Opposite = Fss.Types.Color.Hex "fff"
      TopBar = Fss.Types.Color.Hex "222222"
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
