namespace Fss

open Fss.Types

[<AutoOpen>]
module StartingStyleCss =
    type StartingStyle =
        /// Define starting styles for entry transitions
        static member style (rules: Rule list) =
            (Property.StartingStyle, StartingStyleAtRule.StartingStyle(rules))
            |> Rule
