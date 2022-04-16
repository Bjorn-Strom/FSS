import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { CssRuleWithNormal$reflection, CssRuleWithNormal, String$, MasterTypeHelpers_stringifyICssValue, CssRuleWithAuto$reflection, CssRuleWithAuto } from "./MasterTypes.fs.js";

export class Overflow_Overflow extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Visible", "Hidden", "Clip", "Scroll"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Overflow_Overflow$reflection() {
    return union_type("Fss.Types.Overflow.Overflow", [], Overflow_Overflow, () => [[], [], [], []]);
}

export class Overflow_Wrap extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["BreakWord", "Anywhere"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Overflow_Wrap$reflection() {
    return union_type("Fss.Types.Overflow.Wrap", [], Overflow_Wrap, () => [[], []]);
}

export class OverflowClasses_OverflowClass extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function OverflowClasses_OverflowClass$reflection() {
    return class_type("Fss.Types.OverflowClasses.OverflowClass", void 0, OverflowClasses_OverflowClass, CssRuleWithAuto$reflection());
}

export function OverflowClasses_OverflowClass_$ctor_Z207A3CFB(property) {
    return new OverflowClasses_OverflowClass(property);
}

export function OverflowClasses_OverflowClass__value_5BFAED40(this$, overflowX, overflowY) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(overflowX)} ${MasterTypeHelpers_stringifyICssValue(overflowY)}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export function OverflowClasses_OverflowClass__get_visible(this$) {
    const tupledArg = [this$.property_2, new Overflow_Overflow(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function OverflowClasses_OverflowClass__get_hidden(this$) {
    const tupledArg = [this$.property_2, new Overflow_Overflow(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function OverflowClasses_OverflowClass__get_clip(this$) {
    const tupledArg = [this$.property_2, new Overflow_Overflow(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function OverflowClasses_OverflowClass__get_scroll(this$) {
    const tupledArg = [this$.property_2, new Overflow_Overflow(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class OverflowClasses_OverflowWrap extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function OverflowClasses_OverflowWrap$reflection() {
    return class_type("Fss.Types.OverflowClasses.OverflowWrap", void 0, OverflowClasses_OverflowWrap, CssRuleWithNormal$reflection());
}

export function OverflowClasses_OverflowWrap_$ctor_Z207A3CFB(property) {
    return new OverflowClasses_OverflowWrap(property);
}

export function OverflowClasses_OverflowWrap__get_breakWord(this$) {
    const tupledArg = [this$.property_2, new Overflow_Wrap(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function OverflowClasses_OverflowWrap__get_anywhere(this$) {
    const tupledArg = [this$.property_2, new Overflow_Wrap(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Overflow.fs.js.map
