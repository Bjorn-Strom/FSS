namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module PseudoClass =
    type Nth =
        | Odd
        | Even

[<RequireQualifiedAccess>]
module PseudoClassClasses =
    type PseudoClass =
        static member active(rules: Rule list) =
            (Property.Active, Pseudo.PseudoClass rules)
            |> Rule

        static member anyLink(rules: Rule list) =
            (Property.AnyLink, Pseudo.PseudoClass rules)
            |> Rule

        static member blank(rules: Rule list) =
            (Property.Blank, Pseudo.PseudoClass rules) |> Rule

        static member checked'(rules: Rule list) =
            (Property.Checked, Pseudo.PseudoClass rules)
            |> Rule

        static member current(rules: Rule list) =
            (Property.Current, Pseudo.PseudoClass rules)
            |> Rule

        static member disabled(rules: Rule list) =
            (Property.Disabled, Pseudo.PseudoClass rules)
            |> Rule

        static member empty(rules: Rule list) =
            (Property.Empty, Pseudo.PseudoClass rules) |> Rule

        static member enabled(rules: Rule list) =
            (Property.Enabled, Pseudo.PseudoClass rules)
            |> Rule

        static member firstOfType(rules: Rule list) =
            (Property.FirstOfType, Pseudo.PseudoClass rules)
            |> Rule

        static member focus(rules: Rule list) =
            (Property.Focus, Pseudo.PseudoClass rules) |> Rule

        static member focusVisible(rules: Rule list) =
            (Property.FocusVisible, Pseudo.PseudoClass rules)
            |> Rule

        static member focusWithin(rules: Rule list) =
            (Property.FocusWithin, Pseudo.PseudoClass rules)
            |> Rule

        static member future(rules: Rule list) =
            (Property.Future, Pseudo.PseudoClass rules)
            |> Rule

        static member hover(rules: Rule list) =
            (Property.Hover, Pseudo.PseudoClass rules) |> Rule

        static member indeterminate(rules: Rule list) =
            (Property.Indeterminate, Pseudo.PseudoClass rules)
            |> Rule

        static member invalid(rules: Rule list) =
            (Property.Invalid, Pseudo.PseudoClass rules)
            |> Rule

        static member inRange(rules: Rule list) =
            (Property.InRange, Pseudo.PseudoClass rules)
            |> Rule
        static member lang language (rules: Rule list) =
            (Property.Lang language, Pseudo.PseudoClass rules) |> Rule
        static member lastChild(rules: Rule list) =
            (Property.LastChild, Pseudo.PseudoClass rules)
            |> Rule

        static member lastOfType(rules: Rule list) =
            (Property.LastOfType, Pseudo.PseudoClass rules)
            |> Rule

        static member localLink(rules: Rule list) =
            (Property.LocalLink, Pseudo.PseudoClass rules)
            |> Rule

        static member link(rules: Rule list) =
            (Property.Link, Pseudo.PseudoClass rules) |> Rule
        static member nthChild (n: string) (rules: Rule list) =
            (Property.NthChild n, Pseudo.PseudoClass rules) |> Rule
        static member nthLastChild (n:string ) (rules: Rule list) =
            (Property.NthLastChild n, Pseudo.PseudoClass rules) |> Rule
        static member nthOfType (n: string) (rules: Rule list) =
            (Property.NthOfType n, Pseudo.PseudoClass rules) |> Rule
        static member nthLastOfType (n: string) (rules: Rule list) =
            (Property.NthLastOfType n, Pseudo.PseudoClass rules) |> Rule
        static member onlyChild(rules: Rule list) =
            (Property.OnlyChild, Pseudo.PseudoClass rules)
            |> Rule

        static member onlyOfType(rules: Rule list) =
            (Property.OnlyOfType, Pseudo.PseudoClass rules)
            |> Rule

        static member optional(rules: Rule list) =
            (Property.Optional, Pseudo.PseudoClass rules)
            |> Rule

        static member outOfRange(rules: Rule list) =
            (Property.OutOfRange, Pseudo.PseudoClass rules)
            |> Rule

        static member past(rules: Rule list) =
            (Property.Past, Pseudo.PseudoClass rules) |> Rule

        static member playing(rules: Rule list) =
            (Property.Playing, Pseudo.PseudoClass rules)
            |> Rule

        static member paused(rules: Rule list) =
            (Property.Paused, Pseudo.PseudoClass rules)
            |> Rule

        static member placeholderShown(rules: Rule list) =
            (Property.PlaceholderShown, Pseudo.PseudoClass rules)
            |> Rule

        static member readOnly(rules: Rule list) =
            (Property.ReadOnly, Pseudo.PseudoClass rules)
            |> Rule

        static member readWrite(rules: Rule list) =
            (Property.ReadWrite, Pseudo.PseudoClass rules)
            |> Rule

        static member required(rules: Rule list) =
            (Property.Required, Pseudo.PseudoClass rules)
            |> Rule

        static member root(rules: Rule list) =
            (Property.Root, Pseudo.PseudoClass rules) |> Rule

        static member scope(rules: Rule list) =
            (Property.Scope, Pseudo.PseudoClass rules) |> Rule

        static member target(rules: Rule list) =
            (Property.Target, Pseudo.PseudoClass rules)
            |> Rule

        static member targetWithin(rules: Rule list) =
            (Property.TargetWithin, Pseudo.PseudoClass rules)
            |> Rule

        static member valid(rules: Rule list) =
            (Property.Valid, Pseudo.PseudoClass rules) |> Rule

        static member visited(rules: Rule list) =
            (Property.Visited, Pseudo.PseudoClass rules)
            |> Rule

        static member firstChild(rules: Rule list) =
            (Property.FirstChild, Pseudo.PseudoClass rules)
            |> Rule

        static member userInvalid(rules: Rule list) =
            (Property.UserInvalid, Pseudo.PseudoClass rules)
            |> Rule