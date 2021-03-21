namespace FssTypes

type BackgroundClip =
    | BorderBox
    | PaddingBox
    | ContentBox
    | Text
    interface IBackgroundClip

type BackgroundOrigin =
    | BorderBox
    | PaddingBox
    | ContentBox
    interface IBackgroundOrigin

type BackgroundRepeat =
    | RepeatX
    | RepeatY
    | Repeat
    | Space
    | Round
    | NoRepeat
    interface IBackgroundRepeat

type BackgroundSize =
    | Cover
    | Contain
    interface IBackgroundSize

type BackgroundAttachment =
    | Scroll
    | Fixed
    | Local
    interface IBackgroundAttachment

type BackgroundPosition =
    | Top
    | Bottom
    | Left
    | Right
    | Center
    interface IBackgroundPosition

type BackgroundBlendMode =
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

