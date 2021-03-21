namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type BackgroundClip =
        | BorderBox
        | PaddingBox
        | ContentBox
        | Text
        interface Types.IBackgroundClip

    type BackgroundOrigin =
        | BorderBox
        | PaddingBox
        | ContentBox
        interface Types.IBackgroundOrigin

    type BackgroundRepeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface Types.IBackgroundRepeat

    type BackgroundSize =
        | Cover
        | Contain
        interface Types.IBackgroundSize

    type BackgroundAttachment =
        | Scroll
        | Fixed
        | Local
        interface Types.IBackgroundAttachment

    type BackgroundPosition =
        | Top
        | Bottom
        | Left
        | Right
        | Center
        interface Types.IBackgroundPosition

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
        | Color'
        | Luminosity
        interface Types.IBackgroundBlendMode

    type Isolation =
        | Isolate
        interface Types.IIsolation

    type BoxDecorationBreak =
        | Slice
        | Clone
        interface Types.IBoxDecorationBreak