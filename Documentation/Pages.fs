module Pages

type FssPage =
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
    | AttributeSelectors
    | MediaQueries
    | GlobalStyles
    | Counters
    | Fonts
    | BackgroundImages
    | Svg
    | Unknown

type LibraryPage =
    | Core
    | Fable
    | Feliz
    | Giraffe
    | Unknown

type OtherPage =
    | Troubleshoot
    | Unknown

type Page =
    | FssPage of FssPage
    | LibraryPage of LibraryPage
    | OtherPage of OtherPage
    | Unknown
    | NotFound

let allFssPages =
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
      AttributeSelectors
      MediaQueries
      GlobalStyles
      Counters
      Fonts
      BackgroundImages
      Svg
    ] |> List.map FssPage

let allLibraryPages =
    [ Core
      Fable
      Feliz
      Giraffe
    ] |> List.map LibraryPage

let allOtherPages =
      [ Troubleshoot
      ] |> List.map OtherPage

let allPages =
    [
        "Fss", allFssPages
        "Libraries", allLibraryPages
        "Other", allOtherPages
    ]

let stringToFssPage =
    function
    | "overview" -> Some Overview
    | "installation" -> Some Installation
    | "philosophy" -> Some Philosophy
    | "basicUsage" -> Some BasicUsage
    | "conditionalStyling" -> Some ConditionalStyling
    | "pseudo" -> Some Pseudo
    | "composition" -> Some Composition
    | "labels" -> Some Labels
    | "transition" -> Some Transition
    | "keyframesAnimations" -> Some KeyframesAnimations
    | "combinators" -> Some Combinators
    | "attributeSelectors" -> Some AttributeSelectors
    | "mediaQueries" -> Some MediaQueries
    | "globalStyles" -> Some GlobalStyles
    | "counters" -> Some Counters
    | "fonts" -> Some Fonts
    | "backgroundImages" -> Some BackgroundImages
    | "svg" -> Some Svg
    | _ -> None

let stringToLibraryPage =
    function
    | "core" -> Some Core
    | "fable" -> Some Fable
    | "feliz" -> Some Feliz
    | "giraffe" -> Some Giraffe
    | _ -> None

let stringToOtherPage =
    function
    | "troubleshoot" -> Some Troubleshoot
    | _ -> None

let stringToPage str =
    match stringToFssPage str, stringToLibraryPage str, stringToOtherPage str with
    | Some fssPage, _, _ -> FssPage fssPage
    | _, Some libraryPage, _ -> LibraryPage libraryPage
    | _, _, Some otherPage -> OtherPage otherPage
    | _ -> Unknown

let fssPageToString =
    function
    | Overview -> "Overview"
    | Installation -> "Installation"
    | Philosophy -> "Philosophy"
    | BasicUsage -> "BasicUsage"
    | ConditionalStyling -> "ConditionalStyling"
    | Pseudo -> "Pseudo"
    | Composition -> "Composition"
    | Labels -> "Labels"
    | Transition -> "Transition"
    | KeyframesAnimations -> "KeyframesAnimations"
    | Combinators -> "Combinators"
    | AttributeSelectors -> "AttributeSelectors"
    | MediaQueries -> "MediaQueries"
    | GlobalStyles -> "GlobalStyles"
    | Counters -> "Counters"
    | Fonts -> "Fonts"
    | BackgroundImages -> "BackgroundImages"
    | Svg -> "Svg"
    | _ -> "Unknown"

let libraryPageToString =
    function
    | Core -> "Core"
    | Fable -> "Fable"
    | Feliz -> "Feliz"
    | Giraffe -> "Giraffe"
    | _ -> "Unknown"

let otherPageToString =
    function
    | Troubleshoot -> "Troubleshoot"
    | _ -> "Unknown"

let fssPageToPrettyString =
    function
    | Overview -> "Overview"
    | Installation -> "Installation"
    | Philosophy -> "Philosophy"
    | BasicUsage -> "Basic usage"
    | ConditionalStyling -> "Conditional styling"
    | Pseudo -> "Pseudo-classes/elements"
    | Composition -> "Composition"
    | Labels -> "Labels"
    | Transition -> "Transition"
    | KeyframesAnimations -> "Keyframes and animations"
    | Combinators -> "Combinators"
    | AttributeSelectors -> "Attribute selectors"
    | MediaQueries -> "Media queries"
    | GlobalStyles -> "Global styles"
    | Counters -> "Counters"
    | Fonts -> "Fonts"
    | BackgroundImages -> "Background images"
    | Svg -> "Svg"
    | _ -> "Unknown"


let pageToPrettyString page =
    match page with
    | FssPage page -> fssPageToPrettyString page
    | LibraryPage page -> libraryPageToString page
    | OtherPage page -> otherPageToString page
    | _ -> "Unknown"

let pageToString page =
    match page with
    | FssPage page -> fssPageToString page
    | LibraryPage page -> libraryPageToString page
    | OtherPage page -> otherPageToString page
    | _ -> "Unknown"

let pageToLinkString page =
    let pageString =
        match page with
        | FssPage page -> fssPageToString page
        | LibraryPage page -> libraryPageToString page
        | OtherPage page -> otherPageToString page
        | NotFound -> "Notfound"
        | Unknown -> "Unknown"

    $"{System.Char.ToLower(pageString[0])}{pageString[1..]}"
