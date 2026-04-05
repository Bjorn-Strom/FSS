namespace Fss

/// Represents a named CSS cascade layer
type CascadeLayer = CascadeLayer of string

namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module Layer =
    type LayerMaster =
        | LayerNamed of string * Rule list
        | LayerAnonymous of Rule list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | LayerNamed (_, rules)
                | LayerAnonymous rules ->
                    stringifyList rules
