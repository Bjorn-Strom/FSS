namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module PseudoClass =

    let Active rules = PseudoClass.PseudoClassClasses.PseudoClass.active rules
    let AnyLink rules = PseudoClass.PseudoClassClasses.PseudoClass.anyLink rules
    let Blank rules = PseudoClass.PseudoClassClasses.PseudoClass.blank rules
    let Checked rules = PseudoClass.PseudoClassClasses.PseudoClass.checked' rules
    let Current rules = PseudoClass.PseudoClassClasses.PseudoClass.current rules
    let Disabled rules = PseudoClass.PseudoClassClasses.PseudoClass.disabled rules
    let Empty rules = PseudoClass.PseudoClassClasses.PseudoClass.empty rules
    let Enabled rules = PseudoClass.PseudoClassClasses.PseudoClass.enabled rules
    let FirstOfType rules = PseudoClass.PseudoClassClasses.PseudoClass.firstOfType rules
    let Focus rules = PseudoClass.PseudoClassClasses.PseudoClass.focus rules
    let FocusVisible rules = PseudoClass.PseudoClassClasses.PseudoClass.focusVisible rules
    let FocusWithin rules = PseudoClass.PseudoClassClasses.PseudoClass.focusWithin rules
    let Future rules = PseudoClass.PseudoClassClasses.PseudoClass.future rules
    let Hover rules = PseudoClass.PseudoClassClasses.PseudoClass.hover rules
    let Indeterminate rules = PseudoClass.PseudoClassClasses.PseudoClass.indeterminate rules
    let Invalid rules = PseudoClass.PseudoClassClasses.PseudoClass.invalid rules
    let InRange rules = PseudoClass.PseudoClassClasses.PseudoClass.inRange rules
    let Lang language rules = PseudoClass.PseudoClassClasses.PseudoClass.lang language rules
    let LastChild rules = PseudoClass.PseudoClassClasses.PseudoClass.lastChild rules
    let LastOfType rules = PseudoClass.PseudoClassClasses.PseudoClass.lastOfType rules
    let LocalLink rules = PseudoClass.PseudoClassClasses.PseudoClass.localLink rules
    let Link rules = PseudoClass.PseudoClassClasses.PseudoClass.link rules
    let NthChild (n: string) rules = PseudoClass.PseudoClassClasses.PseudoClass.nthChild n rules
    let NthLastChild (n: string) rules = PseudoClass.PseudoClassClasses.PseudoClass.nthLastChild n rules
    let NthOfType (n: string) rules = PseudoClass.PseudoClassClasses.PseudoClass.nthOfType n rules
    let NthLastOfType (n: string) rules = PseudoClass.PseudoClassClasses.PseudoClass.nthLastOfType n rules
    let OnlyChild rules = PseudoClass.PseudoClassClasses.PseudoClass.onlyChild rules
    let OnlyOfType rules = PseudoClass.PseudoClassClasses.PseudoClass.onlyOfType rules
    let Optional rules = PseudoClass.PseudoClassClasses.PseudoClass.optional rules
    let OutOfRange rules = PseudoClass.PseudoClassClasses.PseudoClass.outOfRange rules
    let Past rules = PseudoClass.PseudoClassClasses.PseudoClass.past rules
    let Playing rules = PseudoClass.PseudoClassClasses.PseudoClass.playing rules
    let Paused rules = PseudoClass.PseudoClassClasses.PseudoClass.paused rules
    let PlaceholderShown rules = PseudoClass.PseudoClassClasses.PseudoClass.placeholderShown rules
    let ReadOnly rules = PseudoClass.PseudoClassClasses.PseudoClass.readOnly rules
    let ReadWrite rules = PseudoClass.PseudoClassClasses.PseudoClass.readWrite rules
    let Required rules = PseudoClass.PseudoClassClasses.PseudoClass.required rules
    let Root rules = PseudoClass.PseudoClassClasses.PseudoClass.root rules
    let Scope rules = PseudoClass.PseudoClassClasses.PseudoClass.scope rules
    let Target rules = PseudoClass.PseudoClassClasses.PseudoClass.target rules
    let TargetWithin rules = PseudoClass.PseudoClassClasses.PseudoClass.targetWithin rules
    let Valid rules = PseudoClass.PseudoClassClasses.PseudoClass.valid rules
    let Visited rules = PseudoClass.PseudoClassClasses.PseudoClass.visited rules
    let FirstChild rules = PseudoClass.PseudoClassClasses.PseudoClass.firstChild rules
    let UserInvalid rules = PseudoClass.PseudoClassClasses.PseudoClass.userInvalid rules
