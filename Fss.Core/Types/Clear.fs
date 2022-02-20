namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Clear =
    type Clear =
        | Left
        | Right
        | Both
        | InlineStart
        | InlineEnd
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module ClearClasses =
    type Clear(property) =
        inherit CssRuleWithNone(property)
        /// Element is moved clear past left floats
        member this.left = (property, Clear.Left) |> Rule
        /// Element is moved clear past right floats
        member this.right = (property, Clear.Right) |> Rule
        /// Element is moved clear past left and right floats
        member this.both = (property, Clear.Both) |> Rule
        /// Element is moved clear past left floats
        /// For ltr that means left floats
        /// For rtl that means right float
        member this.inlineStart = (property, Clear.InlineStart) |> Rule
        /// Element is moved clear past right floats
        /// For ltr that means right floats
        /// For rtl that means left float
        member this.inlineEnd = (property, Clear.InlineEnd) |> Rule
