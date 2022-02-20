namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Word =
    type WordBreak =
        | WordBreak
        | BreakAll
        | KeepAll
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module WordClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-break
    type WordBreakClass(property) =
        inherit CssRuleWithNormal(property)
        member this.wordBreak = (property, Word.WordBreak) |> Rule
        /// To avoid overflow word breaks will be inserted between any two characters
        member this.breakAll = (property, Word.BreakAll) |> Rule
        /// Word breaks should not be used for Asian texts
        member this.keepAll = (property, Word.KeepAll) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/word-spacing
    type WordSpacing(property) =
        inherit CssRuleWithLengthNormal(property)
