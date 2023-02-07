namespace Fss

[<AutoOpen>]
module Selector =
    type Selector =
        static member Tag tag = Fss.Types.Selector.Tag tag
        static member Id id = Fss.Types.Selector.Id id
        static member Class class' = Fss.Types.Selector.Class class'
        static member Active = Fss.Types.Selector.Pseudo "active"
        static member AnyLink = Fss.Types.Selector.Pseudo "any-link"
        static member Blank = Fss.Types.Selector.Pseudo "blank"
        static member Checked = Fss.Types.Selector.Pseudo "checked"
        static member Current = Fss.Types.Selector.Pseudo "current"
        static member Disabled = Fss.Types.Selector.Pseudo "disabled"
        static member Empty = Fss.Types.Selector.Pseudo "empty"
        static member Enabled = Fss.Types.Selector.Pseudo "enabled"
        static member FirstOfType = Fss.Types.Selector.Pseudo "first-of-type"
        static member Focus = Fss.Types.Selector.Pseudo "focus"
        static member FocusVisible = Fss.Types.Selector.Pseudo "focus-visible"
        static member FocusWithin = Fss.Types.Selector.Pseudo "focus-within"
        static member Hover = Fss.Types.Selector.Pseudo "hover"
        static member Future = Fss.Types.Selector.Pseudo "future"
        static member Lang language = Fss.Types.Selector.Pseudo $"lang({language})"
        static member NthChild child  = Fss.Types.Selector.Pseudo $"nth-child({child})"
        static member NthLastChild child  = Fss.Types.Selector.Pseudo $"nth-last-child({child})"
        static member NthOfType type' = Fss.Types.Selector.Pseudo $"nth-of-type({type'})"
        static member NthLastOfType type' = Fss.Types.Selector.Pseudo $"nth-last-of-type({type'})"
