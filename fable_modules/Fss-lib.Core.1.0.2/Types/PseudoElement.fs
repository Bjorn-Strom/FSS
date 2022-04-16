namespace Fss

namespace Fss.Types

module PseudoElementClasses =
    type PseudoElement =
        static member after(rules: Rule list) =
            (Property.After, Pseudo.PseudoElementMaster rules)
            |> Rule

        static member before(rules: Rule list) =
            (Property.Before, Pseudo.PseudoElementMaster rules)
            |> Rule

        static member firstLetter(rules: Rule list) =
            (Property.FirstLetter, Pseudo.PseudoElementMaster rules)
            |> Rule

        static member firstLine(rules: Rule list) =
            (Property.FirstLine, Pseudo.PseudoElementMaster rules)
            |> Rule

        static member selection(rules: Rule list) =
            (Property.Selection, Pseudo.PseudoElementMaster rules)
            |> Rule

        static member marker(rules: Rule list) =
            (Property.Marker, Pseudo.PseudoElementMaster rules)
            |> Rule
