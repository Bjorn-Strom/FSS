namespace Fss

open Fss
open Fss
open Fss
open Types
open Global
open Utilities.Helpers
open Color

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

// https://developer.mozilla.org/en-US/docs/Web/CSS/border
type Border =
    {
        Width : IBorderWidth option
        Style : IBorderStyle option
        Color : CssColor option
    }

    with
        interface IBorder
        static member Create(?Width, ?Style, ?Color) = { Width = Width; Style = Style; Color = Color } :> IBorder

module BorderValue =
    open Border
    open Units.Size
    open Units.Percent

    let FOOBAR (b: Border) = Border.Create(Width = Border.Medium, Style = Border.Dashed, Color = Color.green)

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
            | :? Style as b -> duToLowercase b
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

    let border (b: IBorder): string =
        let stringifyBorder (b: Border): string =
            [Option.map width b.Width; Option.map style b.Style; Option.map color b.Color]
            |> List.filter(fun x -> x.IsSome)
            |> List.map (fun x -> if x.IsSome then x.Value else "")
            |> String.concat " "

        match b with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Border as b -> stringifyBorder b
            | _ -> "unknown border value"
