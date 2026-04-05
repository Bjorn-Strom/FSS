namespace Fss
namespace Fss.Types

open Fss.Types

[<RequireQualifiedAccess>]
module ScopeAtRule =
    type ScopeMaster =
        | ScopeRoot of string * Rule list
        | ScopeRootTo of string * string * Rule list
        | ScopeImplicit of Rule list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | ScopeRoot (_, rules)
                | ScopeRootTo (_, _, rules)
                | ScopeImplicit rules ->
                    stringifyList rules
