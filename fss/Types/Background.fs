namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Background =
        type Clip =
            | BorderBox
            | PaddingBox
            | ContentBox
            | Text
            interface IBackgroundClip

        type Origin =
            | BorderBox
            | PaddingBox
            | ContentBox
            interface IBackgroundOrigin

        type Repeat =
            | RepeatX
            | RepeatY
            | Repeat
            | Space
            | Round
            | NoRepeat
            interface IBackgroundRepeat

        type Size =
            | Cover
            | Contain
            interface IBackgroundSize

        type Attachment =
            | Scroll
            | Fixed
            | Local
            interface IBackgroundAttachment

        type Position =
            | Top
            | Bottom
            | Left
            | Right
            | Center
            interface IBackgroundPosition

        type BlendMode =
            | Multiply
            | Screen
            | Overlay
            | Darken
            | Lighten
            | ColorDodge
            | ColorBurn
            | HardLight
            | SoftLight
            | Difference
            | Exclusion
            | Hue
            | Saturation
            | Color
            | Luminosity
            interface IBackgroundBlendMode

        type Isolation =
            | Isolate
            interface IIsolation

        type BoxDecorationBreak =
            | Slice
            | Clone
            interface IBoxDecorationBreak

        type BackgroundImage (valueFunction: string -> CssProperty) =
            inherit Image.Image(valueFunction)