module Pages

type Page =
    | Overview
    | Installation
    | Philosophy
    | New
    | BasicUsage
    | ConditionalStyling
    | Pseudo
    | Composition
    | Labels
    | Transition
    | KeyframesAnimations
    | Combinators
    | MediaQueries
    | GlobalStyles
    | Counters
    | Fonts
    | BackgroundImages
    | Engine
    | Fable
    | Feliz
    | Giraffe
    | Svg
    | Unknown
    | NotFound

let allPages =
    [ Overview
      Installation
      Philosophy
      New
      BasicUsage
      ConditionalStyling
      Pseudo
      Composition
      Labels
      Transition
      KeyframesAnimations
      Combinators
      MediaQueries
      GlobalStyles
      Counters
      Fonts
      BackgroundImages
      Engine
      Fable
      Feliz
      Giraffe
      Svg ]

let stringToPage =
    function
    | "overview" -> Overview
    | "installation" -> Installation
    | "philosophy" -> Philosophy
    | "new" -> New
    | "basicUsage" -> BasicUsage
    | "conditionalStyling" -> ConditionalStyling
    | "pseudo" -> Pseudo
    | "composition" -> Composition
    | "labels" -> Labels
    | "transition" -> Transition
    | "keyframesAnimations" -> KeyframesAnimations
    | "combinators" -> Combinators
    | "mediaQueries" -> MediaQueries
    | "globalStyles" -> GlobalStyles
    | "counters" -> Counters
    | "fonts" -> Fonts
    | "backgroundImages" -> BackgroundImages
    | "engine" -> Engine
    | "fable" -> Fable
    | "feliz" -> Feliz
    | "giraffe" -> Giraffe
    | "svg" -> Svg
    | _ -> Unknown

let pageToLinkString page =
    let pageString = page.ToString()
    $"{System.Char.ToLower(pageString[0])}{pageString[1..]}"
