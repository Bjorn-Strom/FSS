namespace Fss
namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module Container =
    type Feature =
        | Width of Length
        | MinWidth of Length
        | MaxWidth of Length
        | Height of Length
        | MinHeight of Length
        | MaxHeight of Length
        | InlineSize of Length
        | MinInlineSize of Length
        | MaxInlineSize of Length
        | BlockSize of Length
        | MinBlockSize of Length
        | MaxBlockSize of Length
        | AspectRatio of int * int
        | MinAspectRatio of int * int
        | MaxAspectRatio of int * int
        | Orientation of Media.Orientation
        override this.ToString() =
            match this with
            | Width length -> $"width:{lengthPercentageString length}"
            | MinWidth length -> $"min-width:{lengthPercentageString length}"
            | MaxWidth length -> $"max-width:{lengthPercentageString length}"
            | Height length -> $"height:{lengthPercentageString length}"
            | MinHeight length -> $"min-height:{lengthPercentageString length}"
            | MaxHeight length -> $"max-height:{lengthPercentageString length}"
            | InlineSize length -> $"inline-size:{lengthPercentageString length}"
            | MinInlineSize length -> $"min-inline-size:{lengthPercentageString length}"
            | MaxInlineSize length -> $"max-inline-size:{lengthPercentageString length}"
            | BlockSize length -> $"block-size:{lengthPercentageString length}"
            | MinBlockSize length -> $"min-block-size:{lengthPercentageString length}"
            | MaxBlockSize length -> $"max-block-size:{lengthPercentageString length}"
            | AspectRatio (x, y) -> $"aspect-ratio:{x}/{y}"
            | MinAspectRatio (x, y) -> $"min-aspect-ratio:{x}/{y}"
            | MaxAspectRatio (x, y) -> $"max-aspect-ratio:{x}/{y}"
            | Orientation orientation -> $"orientation:{orientation.Stringify()}"

    type ContainerQueryMaster =
        | ContainerQuery of Feature list * Rule list
        | ContainerQueryNamed of string * Feature list * Rule list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | ContainerQuery (_, rules)
                | ContainerQueryNamed (_, _, rules) ->
                    stringifyList rules

[<RequireQualifiedAccess>]
module ContainerClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/container-type
    type ContainerType(property) =
        inherit CssRuleWithNormal(property)
        member this.size = (property, String "size") |> Rule
        member this.inlineSize = (property, String "inline-size") |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/container-name
    type ContainerName(property) =
        inherit CssRuleWithNone(property)
        member this.value(name: string) = (property, String name) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/container
    type ContainerShorthand(property) =
        inherit CssRuleWithNone(property)
        member this.value(name: string, containerType: string) =
            (property, String $"{name} / {containerType}") |> Rule
