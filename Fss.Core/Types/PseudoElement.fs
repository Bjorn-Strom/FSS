namespace Fss

namespace Fss.Types

module PseudoElementClasses =
    type PseudoElement =
        /// Creates an element that is the last child of the selected element
        static member after(rules: Rule list) = (Property.After, Pseudo.PseudoElementMaster rules) |> Rule
        /// Creates an element that is the first child of the selected element
        static member before(rules: Rule list) = (Property.Before, Pseudo.PseudoElementMaster rules) |> Rule
        /// Matches the first letter of the first line
        static member firstLetter(rules: Rule list) = (Property.FirstLetter, Pseudo.PseudoElementMaster rules) |> Rule
        /// Matches the first line
        static member firstLine(rules: Rule list) = (Property.FirstLine, Pseudo.PseudoElementMaster rules) |> Rule
        /// Matches part of the document highlighted by the user
        static member selection(rules: Rule list) = (Property.Selection, Pseudo.PseudoElementMaster rules) |> Rule
        /// Matches marker box of a list item
        static member marker(rules: Rule list) = (Property.Marker, Pseudo.PseudoElementMaster rules) |> Rule
