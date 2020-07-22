namespace Fss

open Utilities.Types

module Property =
    type Property =
        | Label

        | Hover

        | BackgroundColor
        | FontSize
        | Color

        | Border
        | BorderStyle
        | BorderWidth
        | BorderTopWidth
        | BorderRightWidth
        | BorderBottomWidth
        | BorderLeftWidth
        | BorderRadius
        | BorderTopLeftRadius
        | BorderTopRightRadius
        | BorderBottomRightRadius
        | BorderBottomLeftRadius
        | BorderColor
        | BorderTopColor
        | BorderRightColor
        | BorderBottomColor
        | BorderLeftColor

        | Animation
        | AnimationName
        | AnimationDuration
        | AnimationTimingFunction
        | AnimationDelay
        | AnimationIterationCount
        | AnimationDirection
        | AnimationFillMode
        | AnimationPlayState

        | Transform

        interface ICSSProperty

    let value = 
        function 
        | Label -> "label"

        | Hover -> ":hover"

        | BackgroundColor -> "background-color"

        | FontSize -> "font-size"

        | Color -> "color"

        | Border -> "border"
        | BorderStyle -> "border-style"
        | BorderWidth -> "border-width"
        | BorderTopWidth -> "border-top-width"
        | BorderRightWidth -> "border-right-width"
        | BorderBottomWidth -> "border-bottom-width"
        | BorderLeftWidth -> "border-left-width"
        | BorderRadius -> "border-radius"
        | BorderTopLeftRadius -> "border-top-left-radius"
        | BorderTopRightRadius -> "border-top-right-radius"
        | BorderBottomRightRadius -> "border-bottom-right-radius"
        | BorderBottomLeftRadius -> "border-bottom-left-radius"
        | BorderColor -> "border-color"
        | BorderTopColor -> "border-top-color"
        | BorderRightColor -> "border-right-color"
        | BorderBottomColor -> "border-bottom-color"
        | BorderLeftColor -> "border-left-color"

        | Animation -> "animation"
        | AnimationName -> "animation-name"
        | AnimationDuration -> "animation-duration"
        | AnimationTimingFunction -> "animation-timing-function"
        | AnimationDelay -> "animation-delay"
        | AnimationIterationCount -> "animation-iteration-count"
        | AnimationDirection -> "animation-direction"
        | AnimationFillMode -> "animation-fill-mode"
        | AnimationPlayState -> "animation-play-state"

        | Transform -> "transform"

    let label = Label

    let hover = Hover

    let backgroundColor = BackgroundColor

    let fontSize = FontSize

    let color = Color

    let border = Border
    let borderStyle = BorderStyle
    let borderWidth = BorderWidth
    let borderTopWidth = BorderTopWidth
    let borderRightWidth = BorderRightWidth
    let borderBottomWidth = BorderBottomWidth
    let borderLeftWidth = BorderLeftWidth
    let borderRadius = BorderRadius
    let borderTopLeftRadius = BorderTopLeftRadius
    let borderTopRightRadius = BorderTopRightRadius
    let borderBottomRightRadius = BorderBottomRightRadius
    let borderBottomLeftRadius = BorderBottomLeftRadius
    let borderColor = BorderColor
    let borderTopColor = BorderTopColor
    let borderRightColor = BorderRightColor
    let borderBottomColor = BorderBottomColor
    let borderLeftColor = BorderLeftColor

    let animation = Animation
    let animationName = AnimationName
    let animationDuration = AnimationDuration
    let animationTimingFunction = AnimationTimingFunction
    let animationDelay = AnimationDelay
    let animationIterationCount = AnimationIterationCount
    let animationDirection = AnimationDirection
    let animationFillMode = AnimationFillMode
    let animationPlayState = AnimationPlayState

    let transform = Transform