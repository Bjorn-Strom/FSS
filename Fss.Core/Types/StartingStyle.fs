namespace Fss
namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module StartingStyleAtRule =
    type StartingStyleMaster =
        | StartingStyle of Rule list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | StartingStyle rules ->
                    stringifyList rules
