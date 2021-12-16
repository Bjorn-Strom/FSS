namespace Fss

open Fss.FssTypes

module Word =
    /// Specifies length of space between words.
    let WordSpacing =
        Word.WordClasses.WordSpacing(Property.WordSpacing)
    /// Specify when line breaks should happen.
    let WordBreak =
        Word.WordClasses.WordBreakClass(Property.WordBreak)
