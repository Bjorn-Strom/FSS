namespace Fss

namespace Fss.Types

module PseudoElementClasses =
    type PseudoElement =
        /// Creates an element that is the last child of the selected element
        static member after(rules: Rule list) = (Property.After, PseudoMaster.PseudoElementMaster rules) |> Rule
        /// Creates an element that is the first child of the selected element
        static member before(rules: Rule list) = (Property.Before, PseudoMaster.PseudoElementMaster rules) |> Rule
        /// Matches the first letter of the first line
        static member firstLetter(rules: Rule list) = (Property.FirstLetter, PseudoMaster.PseudoElementMaster rules) |> Rule
        /// Matches the first line
        static member firstLine(rules: Rule list) = (Property.FirstLine, PseudoMaster.PseudoElementMaster rules) |> Rule
        /// Matches part of the document highlighted by the user
        static member selection(rules: Rule list) = (Property.Selection, PseudoMaster.PseudoElementMaster rules) |> Rule
        /// Matches marker box of a list item
        static member marker(rules: Rule list) = (Property.Marker, PseudoMaster.PseudoElementMaster rules) |> Rule
        /// Represents the placeholder text in an input or textarea element.
        static member placeholder(rules: Rule list) = (Property.Placeholder, PseudoMaster.PseudoElementMaster rules) |> Rule
