import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Pseudo, Property_CssProperty } from "./MasterTypes.fs.js";

export class PseudoClass_Nth extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Odd", "Even"];
    }
}

export function PseudoClass_Nth$reflection() {
    return union_type("Fss.Types.PseudoClass.Nth", [], PseudoClass_Nth, () => [[], []]);
}

export class PseudoClassClasses_PseudoClass {
    constructor() {
    }
}

export function PseudoClassClasses_PseudoClass$reflection() {
    return class_type("Fss.Types.PseudoClassClasses.PseudoClass", void 0, PseudoClassClasses_PseudoClass);
}

export function PseudoClassClasses_PseudoClass_active_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(315), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_anyLink_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(316), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_blank_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(317), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_checked$0027_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(318), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_current_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(319), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_disabled_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(320), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_empty_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(321), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_enabled_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(322), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_firstOfType_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(324), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_focus_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(325), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_focusVisible_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(326), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_focusWithin_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(327), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_future_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(328), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_hover_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(329), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_indeterminate_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(330), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_invalid_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(331), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_inRange_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(332), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_lang(language, rules) {
    const tupledArg = [new Property_CssProperty(333, language), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_lastChild_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(334), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_lastOfType_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(335), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_localLink_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(337), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_link_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(336), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_nthChild(n, rules) {
    const tupledArg = [new Property_CssProperty(338, n), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_nthLastChild(n, rules) {
    const tupledArg = [new Property_CssProperty(339, n), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_nthOfType(n, rules) {
    const tupledArg = [new Property_CssProperty(341, n), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_nthLastOfType(n, rules) {
    const tupledArg = [new Property_CssProperty(340, n), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_onlyChild_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(342), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_onlyOfType_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(343), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_optional_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(344), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_outOfRange_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(345), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_past_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(346), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_playing_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(347), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_paused_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(348), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_placeholderShown_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(349), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_readOnly_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(350), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_readWrite_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(351), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_required_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(352), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_root_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(353), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_scope_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(354), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_target_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(355), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_targetWithin_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(356), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_valid_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(357), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_visited_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(358), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_firstChild_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(323), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function PseudoClassClasses_PseudoClass_userInvalid_72C268A9(rules) {
    const tupledArg = [new Property_CssProperty(359), new Pseudo(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=PseudoClass.fs.js.map
