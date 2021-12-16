namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module WillChange =
    type WillChange =
        | ScrollPosition
        | Contents
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module WillChangeClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/will-change
        type WillChange(property) =
            inherit CssRuleWithAuto(property)
            member this.value(ident: string) = (property, String ident) |> Rule

            member this.value(idents: string list) =
                (property, String(String.concat ", " idents))
                |> Rule

            member this.scrollPosition = (property, ScrollPosition) |> Rule
            member this.contents = (property, Contents) |> Rule
