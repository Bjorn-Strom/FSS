namespace Fss

open Fss.Types

[<AutoOpen>]
module Word =
    /// Specifies length of space between words.
    let WordSpacing = WordClasses.WordSpacing(Property.WordSpacing)
    /// Specify when line breaks should happen.
    let WordBreak = WordClasses.WordBreakClass(Property.WordBreak)
