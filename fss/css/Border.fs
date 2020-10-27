namespace Fss

open Fss
open Types
open Global
open Utilities.Helpers

module Border =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    type Width =
        | Thin
        | Medium
        | Thick
        interface IBorderWidth

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
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
        interface IBorderStyle

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    type Collapse =
        | Collapse
        | Separate
        interface IBorderCollapse

    type Value =
        | Value of float
        interface IBorderImageWidth
        interface IBorderImageSlice
        interface IBorderImageOutset

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    type ImageRepeat =
        | Stretch
        | Repeat
        | Round
        | Space
        interface IBorderImageRepeat

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    type ImageSlice =
        | Fill
        interface IBorderImageSlice

module BorderValue =
    open Border
    open Units.Size
    open Units.Percent

    let width (v: IBorderWidth): string =
        match v with
            | :? Global      as g -> GlobalValue.globalValue g
            | :? Width       as b -> duToLowercase b
            | :? Size        as s -> Units.Size.value s
            | :? Percent     as p -> Units.Percent.value p
            | _ -> "Unknown border width"

    let style (v: IBorderStyle): string =
        match v with
            | :? Global      as g -> GlobalValue.globalValue g
            | :? None        as n -> GlobalValue.none n
            | :? Style       as b -> duToLowercase b
            | _ -> "Unknown border style"

    let radius (v: IBorderRadius): string =
        match v with
            | :? Size    as s -> Units.Size.value s
            | :? Percent as p -> Units.Percent.value p
            | :? Global  as g -> GlobalValue.globalValue g
            | _ -> "Unknown border radius"

    let color (v: IBorderColor): string =
        match v with
            | :? Color.CssColor as c -> Color.value c
            | :? Global         as g -> GlobalValue.globalValue g
            | _ -> "Unknown border color"

    let collapse (v: IBorderCollapse): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? Collapse as c -> duToLowercase c
            | _ -> "Unknown border collapse"

    let spacing (v: IBorderSpacing): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Size   as s -> Units.Size.value s
            | _ -> "Unknown border spacing"

    let value (Value v): string = string v

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-width
    let imageWidth (v: IBorderImageWidth): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Auto       as a -> GlobalValue.auto a
            | :? Size       as s -> Units.Size.value s
            | :? Percent    as p -> Units.Percent.value p
            | :? Value      as v -> value v
            | _ -> "Unknown border spacing"

    let imageRepeat (v: IBorderImageRepeat): string =
        match v with
            | :? Global      as g -> GlobalValue.globalValue g
            | :? ImageRepeat as i -> duToLowercase i
            | _ -> "Unknown border repeat"

    let imageSlice (v: IBorderImageSlice): string =
        let stringifySlice (s: ImageSlice) =
            match s with
                | Fill    -> "fill"

        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Percent    as p -> Units.Percent.value p
            | :? ImageSlice as i -> stringifySlice i
            | :? Value      as v -> value v
            | _ -> "Unknown border slice"

    let imageOutset (v: IBorderImageOutset): string =
        match v with
            | :? Global     as g -> GlobalValue.globalValue g
            | :? Value      as v -> value v
            | :? Size       as s -> Units.Size.value s
            | _ -> "Unknown border outset"

