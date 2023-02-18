namespace Fss

open Fss.Types

[<AutoOpen>]
module PseudoClass =
    let Active rules = PseudoClassClasses.PseudoClass.active rules
    let AnyLink rules = PseudoClassClasses.PseudoClass.anyLink rules
    let Blank rules = PseudoClassClasses.PseudoClass.blank rules
    let Checked rules = PseudoClassClasses.PseudoClass.checked' rules
    let Current rules = PseudoClassClasses.PseudoClass.current rules
    let Disabled rules = PseudoClassClasses.PseudoClass.disabled rules
    let Empty rules = PseudoClassClasses.PseudoClass.empty rules
    let Enabled rules = PseudoClassClasses.PseudoClass.enabled rules
    let FirstOfType rules = PseudoClassClasses.PseudoClass.firstOfType rules
    let Focus rules = PseudoClassClasses.PseudoClass.focus rules
    let FocusVisible rules = PseudoClassClasses.PseudoClass.focusVisible rules
    let FocusWithin rules = PseudoClassClasses.PseudoClass.focusWithin rules
    let Future rules = PseudoClassClasses.PseudoClass.future rules
    let Hover rules = PseudoClassClasses.PseudoClass.hover rules
    let Indeterminate rules = PseudoClassClasses.PseudoClass.indeterminate rules
    let Invalid rules = PseudoClassClasses.PseudoClass.invalid rules
    let InRange rules = PseudoClassClasses.PseudoClass.inRange rules
    let Lang language rules = PseudoClassClasses.PseudoClass.lang language rules
    let LastChild rules = PseudoClassClasses.PseudoClass.lastChild rules
    let LastOfType rules = PseudoClassClasses.PseudoClass.lastOfType rules
    let LocalLink rules = PseudoClassClasses.PseudoClass.localLink rules
    let Link rules = PseudoClassClasses.PseudoClass.link rules
    let NthChild (n: string) rules = PseudoClassClasses.PseudoClass.nthChild n rules
    let NthLastChild (n: string) rules = PseudoClassClasses.PseudoClass.nthLastChild n rules
    let NthOfType (n: string) rules = PseudoClassClasses.PseudoClass.nthOfType n rules
    let NthLastOfType (n: string) rules = PseudoClassClasses.PseudoClass.nthLastOfType n rules
    let OnlyChild rules = PseudoClassClasses.PseudoClass.onlyChild rules
    let OnlyOfType rules = PseudoClassClasses.PseudoClass.onlyOfType rules
    let Optional rules = PseudoClassClasses.PseudoClass.optional rules
    let OutOfRange rules = PseudoClassClasses.PseudoClass.outOfRange rules
    let Past rules = PseudoClassClasses.PseudoClass.past rules
    let Playing rules = PseudoClassClasses.PseudoClass.playing rules
    let Paused rules = PseudoClassClasses.PseudoClass.paused rules
    let PlaceholderShown rules = PseudoClassClasses.PseudoClass.placeholderShown rules
    let ReadOnly rules = PseudoClassClasses.PseudoClass.readOnly rules
    let ReadWrite rules = PseudoClassClasses.PseudoClass.readWrite rules
    let Required rules = PseudoClassClasses.PseudoClass.required rules
    let Root rules = PseudoClassClasses.PseudoClass.root rules
    let Scope rules = PseudoClassClasses.PseudoClass.scope rules
    let Target rules = PseudoClassClasses.PseudoClass.target rules
    let TargetWithin rules = PseudoClassClasses.PseudoClass.targetWithin rules
    let Valid rules = PseudoClassClasses.PseudoClass.valid rules
    let Visited rules = PseudoClassClasses.PseudoClass.visited rules
    let FirstChild rules = PseudoClassClasses.PseudoClass.firstChild rules
    let UserInvalid rules = PseudoClassClasses.PseudoClass.userInvalid rules
    let Not (selectors: Selector list) rules = PseudoClassClasses.PseudoClass.not selectors rules
    let Is (selectors: Selector list) rules = PseudoClassClasses.PseudoClass.is selectors rules
    let Where (selectors: Selector list) rules = PseudoClassClasses.PseudoClass.where selectors rules
    
[<AutoOpen>]
module ClassIdProperties =
    let Class class' rules = (Property.Class class', ClassnameMaster rules) |> Rule
    let Id id' rules = (Property.Class id', IdMaster rules) |> Rule