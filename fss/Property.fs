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

        | Transition

        interface ICSSProperty

    let value = 
        function 
        | Label -> "label"

        | Hover -> ":hover"

        | BackgroundColor -> "backgroundColor"

        | FontSize -> "fontSize"

        | Color -> "color"

        | Border -> "border"
        | BorderStyle -> "borderStyle"
        | BorderWidth -> "borderWidth"
        | BorderTopWidth -> "borderTopWidth"
        | BorderRightWidth -> "borderRightWidth"
        | BorderBottomWidth -> "borderBottomWidth"
        | BorderLeftWidth -> "borderLeftWidth"
        | BorderRadius -> "borderRadius"
        | BorderTopLeftRadius -> "borderTopLeftRadius"
        | BorderTopRightRadius -> "borderTopRightRadius"
        | BorderBottomRightRadius -> "borderBottomRightRadius"
        | BorderBottomLeftRadius -> "borderBottomLeftRadius"
        | BorderColor -> "borderColor"
        | BorderTopColor -> "borderTopCcolor"
        | BorderRightColor -> "borderRightColor"
        | BorderBottomColor -> "borderBottomColor"
        | BorderLeftColor -> "borderLeftColor"

        | Animation -> "animation"
        | AnimationName -> "animationName"
        | AnimationDuration -> "animationDuration"
        | AnimationTimingFunction -> "animationTimingFunction"
        | AnimationDelay -> "animationDelay"
        | AnimationIterationCount -> "animationIterationCount"
        | AnimationDirection -> "animationDirection"
        | AnimationFillMode -> "animationFillMode"
        | AnimationPlayState -> "animationPlayState"

        | Transform -> "transform"

        | Transition -> "transition"

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

    let transition = Transition