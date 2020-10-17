namespace Fss

open Fss.Utilities
open Types
open Units.Angle
open Units.Percent
open Utilities.Helpers
open Global

module Background =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    type Origin =
        | BorderBox
        | PaddingBox
        | ContentBox
        interface IBackgroundOrigin

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    type Clip =
        | BorderBox
        | PaddingBox
        | ContentBox
        | Text
        interface IBackgroundClip

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    type Repeat =
        | RepeatX
        | RepeatY
        | Repeat
        | Space
        | Round
        | NoRepeat
        interface IBackgroundRepeat

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    type Size =
        | Cover
        | Contain
        interface IBackgroundSize

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    type Attachment =
        | Scroll
        | Fixed
        | Local
        interface IBackgroundAttachment

module BackgroundValues =
    open Background
    let origin (v: IBackgroundOrigin): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Origin as b -> duToKebab b
            | _ -> "Unknown background origin"

    let clip (v: IBackgroundClip): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Clip as b -> duToKebab b
            | _ -> "Unknown background clip"

    let repeat (v: IBackgroundRepeat): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Repeat as b -> duToKebab b
            | _ -> "Unknown background repeat"

    let size (v: IBackgroundSize): string =
        match v with
            | :? Global          as g -> GlobalValue.globalValue g
            | :? Auto            as a -> GlobalValue.auto a
            | :? Units.Size.Size as s -> Units.Size.value s
            | :? Percent         as p -> Units.Percent.value p
            | :? Size            as b -> duToLowercase b
            | _ -> "Unknown background size"

    let attachment (v: IBackgroundAttachment): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Attachment as b -> duToLowercase b
            | _ -> "Unknown background attachment"