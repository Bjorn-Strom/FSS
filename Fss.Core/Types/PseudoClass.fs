namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module PseudoClass =
    type Nth =
        | Odd
        | Even

[<RequireQualifiedAccess>]
module PseudoClassClasses =
    type PseudoClass =
        /// When an element is activated by the user, like being clicked
        static member active(rules: Rule list) = (Property.Active, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When an element matches either link or visited
        static member anyLink(rules: Rule list) = (Property.AnyLink, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When a user input element is empty
        static member blank(rules: Rule list) = (Property.Blank, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When elements like check boxes or radio buttons are toggled on
        static member checked'(rules: Rule list) = (Property.Checked, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element or an ancestor of an element
        static member current(rules: Rule list) = (Property.Current, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When an element is in a disabled state
        static member disabled(rules: Rule list) = (Property.Disabled, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When an element ahs no children other than white-space characters
        static member empty(rules: Rule list) = (Property.Empty, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When an element is in an enabled state
        static member enabled(rules: Rule list) = (Property.Enabled, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the first of a given type selector
        static member firstOfType(rules: Rule list) = (Property.FirstOfType, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches when an element has focus
        static member focus(rules: Rule list) = (Property.Focus, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches when an element has focus and it should be visibly focused
        static member focusVisible(rules: Rule list) = (Property.FocusVisible, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches when an element and any descendant elements where focus is applied
        static member focusWithin(rules: Rule list) = (Property.FocusWithin, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches and element that occurs after the current element
        static member future(rules: Rule list) = (Property.Future, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When an element is being hovered
        static member hover(rules: Rule list) = (Property.Hover, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// When an element is in an indeterminate state
        static member indeterminate(rules: Rule list) = (Property.Indeterminate, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element with invalid contents
        static member invalid(rules: Rule list) = (Property.Invalid, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches elements with range limitations in a specific range
        static member inRange(rules: Rule list) = (Property.InRange, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches based on content language
        static member lang language (rules: Rule list) = (Property.Lang language, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the last of its children
        static member lastChild(rules: Rule list) = (Property.LastChild, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the last element of given type
        static member lastOfType(rules: Rule list) = (Property.LastOfType, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches links whose URL is on the same page as target URL
        static member localLink(rules: Rule list) = (Property.LocalLink, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches links that have not been visited
        static member link(rules: Rule list) = (Property.Link, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the NTH child starting from the beginning of the children
        static member nthChild (n: string) (rules: Rule list) = (Property.NthChild n, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the NTH child starting from the end of the children
        static member nthLastChild (n:string ) (rules: Rule list) = (Property.NthLastChild n, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the NTH of type starting from the start of the children
        static member nthOfType (n: string) (rules: Rule list) = (Property.NthOfType n, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the NTH of type starting from the end of the children
        static member nthLastOfType (n: string) (rules: Rule list) = (Property.NthLastOfType n, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element with no sibling
        static member onlyChild(rules: Rule list) = (Property.OnlyChild, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element with no siblings og the chosen type selector
        static member onlyOfType(rules: Rule list) = (Property.OnlyOfType, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches optional form elements
        static member optional(rules: Rule list) = (Property.Optional, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Applies to elements of range limitations when the selected value is outside of the allowed range
        static member outOfRange(rules: Rule list) = (Property.OutOfRange, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element that occurs before the current element
        static member past(rules: Rule list) = (Property.Past, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element capable of playing when it is playing
        static member playing(rules: Rule list) = (Property.Playing, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element capable of playing when it is paused
        static member paused(rules: Rule list) = (Property.Paused, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an input element that is displaying a placeholder text
        static member placeholderShown(rules: Rule list) = (Property.PlaceholderShown, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches any element that cannot be changed by the user
        static member readOnly(rules: Rule list) = (Property.ReadOnly, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches any element that can be changed by the user
        static member readWrite(rules: Rule list) = (Property.ReadWrite, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches any form element that is required
        static member required(rules: Rule list) = (Property.Required, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the root element of the document
        static member root(rules: Rule list) = (Property.Root, PseudoMaster.PseudoClassMaster rules) |> Rule
        ///
        static member scope(rules: Rule list) = (Property.Scope, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element which is the target of the document url
        static member target(rules: Rule list) = (Property.Target, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element which is the target of the document url
        /// As wll as all descendants which do
        static member targetWithin(rules: Rule list) = (Property.TargetWithin, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches an element with valid contents
        static member valid(rules: Rule list) = (Property.Valid, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches a visited url
        static member visited(rules: Rule list) = (Property.Visited, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches the first child
        static member firstChild(rules: Rule list) = (Property.FirstChild, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches a element with incorrect input after it has been used by the user
        static member userInvalid(rules: Rule list) = (Property.UserInvalid, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches a list of elements that does not match a a list of selectors
        static member not (selectors: Selector list) (rules: Rule list) = (Property.Not selectors, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches any elements that can be selected by any of the selectors in the list
        static member is (selectors: Selector list) (rules: Rule list) = (Property.Is selectors, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Matches any elements that can be selected by any of the selectors in the list
        static member where (selectors: Selector list) (rules: Rule list) = (Property.Where selectors, PseudoMaster.PseudoClassMaster rules) |> Rule
        /// Targets an element which contains a set of other elements
        static member has (selectors: Selector list) (rules: Rule list) = (Property.Has selectors, PseudoMaster.PseudoClassMaster rules) |> Rule
