namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module WillChange =
    type WillChange =
        | ScrollPosition
        | Contents
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module WillChangeClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/will-change
    type WillChange(property) =
        inherit CssRuleWithAuto(property)
        member this.value(ident: string) = (property, String ident) |> Rule

        member this.value(idents: string list) =
            (property, String(String.concat ", " idents))
            |> Rule

        /// Indicates that the scroll position will change
        member this.scrollPosition = (property, WillChange.ScrollPosition) |> Rule
        /// Indicates that the contents will change
        member this.contents = (property, WillChange.Contents) |> Rule
