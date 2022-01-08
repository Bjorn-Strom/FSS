namespace Fss

namespace Fss.Types

module PseudoElementClasses =
    type PseudoElement =
        static member after(rules: Rule list) =
            (Property.After, Pseudo.PseudoElement rules)
            |> Rule

        static member before(rules: Rule list) =
            (Property.Before, Pseudo.PseudoElement rules)
            |> Rule

        static member firstLetter(rules: Rule list) =
            (Property.FirstLetter, Pseudo.PseudoElement rules)
            |> Rule

        static member firstLine(rules: Rule list) =
            (Property.FirstLine, Pseudo.PseudoElement rules)
            |> Rule

        static member selection(rules: Rule list) =
            (Property.Selection, Pseudo.PseudoElement rules)
            |> Rule

        static member marker(rules: Rule list) =
            (Property.Marker, Pseudo.PseudoElement rules)
            |> Rule
