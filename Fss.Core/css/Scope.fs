namespace Fss

open Fss.Types

[<AutoOpen>]
module ScopeCss =
    type Scope =
        /// Scope rules to elements matching the root selector
        static member scope (root: string) (rules: Rule list) =
            (Property.ScopeRule, ScopeAtRule.ScopeRoot(root, rules))
            |> Rule
        /// Scope rules with a lower boundary (donut scope)
        static member scopeTo (root: string) (limit: string) (rules: Rule list) =
            (Property.ScopeRule, ScopeAtRule.ScopeRootTo(root, limit, rules))
            |> Rule
        /// Implicit scope (scopes to the nearest scope root)
        static member implicit (rules: Rule list) =
            (Property.ScopeRule, ScopeAtRule.ScopeImplicit(rules))
            |> Rule
