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
    | Transitions
    | KeyframesAnimations
    | Combinators
    | AttributeSelectors
    | MediaQueries
    | ContainerQueries
    | CascadeLayers
    | CssScope
    | StartingStyle
    | CustomProperty
    | ScrollDrivenAnimations
    | GlobalStyles
    | Counters
    | Fonts
    | BackgroundImages
    | Shorthands
    | Svg
    | Colors
    | Unknown

type LibraryPage =
    | Core
    | Fable
    | Feliz
    | Giraffe
    | Falco
    | Static
    | Unknown

type OtherPage =
    | Troubleshoot
    | Changelog
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
      Transitions
      KeyframesAnimations
      Combinators
      AttributeSelectors
      MediaQueries
      ContainerQueries
      CascadeLayers
      CssScope
      StartingStyle
      CustomProperty
      ScrollDrivenAnimations
      GlobalStyles
      Counters
      Fonts
      BackgroundImages
      Shorthands
      Svg
      Colors
    ] |> List.map FssPage

let allLibraryPages =
    [ Core
      Fable
      Feliz
      Giraffe
      Falco
      Static
    ] |> List.map LibraryPage

let allOtherPages =
      [ Troubleshoot
        Changelog
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
    | "transition" -> Some Transitions
    | "keyframesAnimations" -> Some KeyframesAnimations
    | "combinators" -> Some Combinators
    | "attributeSelectors" -> Some AttributeSelectors
    | "mediaQueries" -> Some MediaQueries
    | "containerQueries" -> Some ContainerQueries
    | "cascadeLayers" -> Some CascadeLayers
    | "cssScope" -> Some CssScope
    | "startingStyle" -> Some StartingStyle
    | "customProperty" -> Some CustomProperty
    | "scrollDrivenAnimations" -> Some ScrollDrivenAnimations
    | "globalStyles" -> Some GlobalStyles
    | "counters" -> Some Counters
    | "fonts" -> Some Fonts
    | "backgroundImages" -> Some BackgroundImages
    | "shorthands" -> Some Shorthands
    | "svg" -> Some Svg
    | "colors" -> Some Colors
    | _ -> None

let stringToLibraryPage =
    function
    | "core" -> Some Core
    | "fable" -> Some Fable
    | "feliz" -> Some Feliz
    | "giraffe" -> Some Giraffe
    | "falco" -> Some Falco
    | "static" -> Some Static
    | _ -> None

let stringToOtherPage =
    function
    | "troubleshoot" -> Some Troubleshoot
    | "changelog" -> Some Changelog
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
    | Transitions -> "Transition"
    | KeyframesAnimations -> "KeyframesAnimations"
    | Combinators -> "Combinators"
    | AttributeSelectors -> "AttributeSelectors"
    | MediaQueries -> "MediaQueries"
    | ContainerQueries -> "ContainerQueries"
    | CascadeLayers -> "CascadeLayers"
    | CssScope -> "CssScope"
    | StartingStyle -> "StartingStyle"
    | CustomProperty -> "CustomProperty"
    | ScrollDrivenAnimations -> "ScrollDrivenAnimations"
    | GlobalStyles -> "GlobalStyles"
    | Counters -> "Counters"
    | Fonts -> "Fonts"
    | BackgroundImages -> "BackgroundImages"
    | Shorthands -> "Shorthands"
    | Svg -> "Svg"
    | Colors -> "Colors"
    | _ -> "Unknown"

let libraryPageToString =
    function
    | Core -> "Core"
    | Fable -> "Fable"
    | Feliz -> "Feliz"
    | Giraffe -> "Giraffe"
    | Falco -> "Falco"
    | Static -> "Static"
    | _ -> "Unknown"

let otherPageToString =
    function
    | Troubleshoot -> "Troubleshoot"
    | Changelog -> "Changelog"
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
    | Transitions -> "Transition"
    | KeyframesAnimations -> "Keyframes and animations"
    | Combinators -> "Combinators"
    | AttributeSelectors -> "Attribute selectors"
    | MediaQueries -> "Media queries"
    | ContainerQueries -> "Container queries"
    | CascadeLayers -> "Cascade layers"
    | CssScope -> "CSS Scope"
    | StartingStyle -> "Starting style"
    | CustomProperty -> "Custom properties"
    | ScrollDrivenAnimations -> "Scroll-driven animations"
    | GlobalStyles -> "Global styles"
    | Counters -> "Counters"
    | Fonts -> "Fonts"
    | BackgroundImages -> "Background images"
    | Shorthands -> "Shorthands"
    | Svg -> "Svg"
    | Colors -> "Colors"
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
