module Pages

type Page =
    | Overview
    | Installation
    | Philosophy
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
    | Svg
    | Core
    | Fable
    | Feliz
    | Giraffe
    | Troubleshoot
    | Unknown
    | NotFound

let allPages =
    [ Overview
      Installation
      Philosophy
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
      Svg
      Core
      Fable
      Feliz
      Giraffe
      Troubleshoot ]

let stringToPage =
    function
    | "overview" -> Overview
    | "installation" -> Installation
    | "philosophy" -> Philosophy
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
    | "svg" -> Svg
    | "core" -> Core
    | "fable" -> Fable
    | "feliz" -> Feliz
    | "giraffe" -> Giraffe
    | "troubleshoot" -> Troubleshoot
    | _ -> Unknown

let pageToLinkString page =
    let pageString = page.ToString()
    $"{System.Char.ToLower(pageString[0])}{pageString[1..]}"
