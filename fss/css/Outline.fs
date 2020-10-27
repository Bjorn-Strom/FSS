namespace Fss

module Outline =
    open Types

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-color
    type Color =
        | Invert
        interface IOutlineColor

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-width
    type Width =
        | Thin
        | Medium
        | Thick
        interface IOutlineWidth

    // https://developer.mozilla.org/en-US/docs/Web/CSS/outline-style
    type Style =
        | Hidden
        | Dotted
        | Dashed
        | Solid
        | Double
        | Groove
        | Ridge
        | Inset
        | Outset
        | None
        interface IOutlineStyle

module OutlineValue =
    open Global
    open Types
    open Outline
    open Color
    open Units.Size
    open Utilities.Helpers

    let width (v: IOutlineWidth): string =
        match v with
            | :? Global      as g -> GlobalValue.globalValue g
            | :? Width       as b -> duToLowercase b
            | :? Size        as s -> Units.Size.value s
            | _ -> "Unknown border width"

    let style (v: IOutlineStyle): string =
        match v with
            | :? Global      as g -> GlobalValue.globalValue g
            | :? None        as n -> GlobalValue.none n
            | :? Style       as b -> duToLowercase b
            | _ -> "Unknown outline style"

    let color (v: IOutlineColor): string =
        match v with
        | :? Global   as g -> GlobalValue.globalValue g
        | :? CssColor as c -> Color.value c
        | :? Color    as c -> duToLowercase c
        | _ -> "Unknown outline color"