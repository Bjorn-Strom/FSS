namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Word =
    type WordBreak =
        | WordBreak
        | BreakAll
        | KeepAll
        interface ICssValue with
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module WordClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
        type WordBreakClass(property) =
            inherit CssRuleWithNormal(property)
            member this.wordBreak = (property, WordBreak) |> Rule
            member this.breakAll = (property, BreakAll) |> Rule
            member this.keepAll = (property, KeepAll) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/word-spacing
        type WordSpacing(property) =
            inherit CssRuleWithLengthNormal(property)
