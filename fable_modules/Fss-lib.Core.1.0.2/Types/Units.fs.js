import { String$, CssRuleWithAuto$reflection, CssRuleWithAuto, None$0027, Normal, CssRule$reflection, CssRule, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, string_type, float64_type, union_type, int32_type } from "../../fable-library.3.7.9/Reflection.js";

export class Percent extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Percent"];
    }
    StringifyFontFace() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCss() {
        const this$ = this;
        const p = this$.fields[0] | 0;
        return `${p}%`;
    }
}

export function Percent$reflection() {
    return union_type("Fss.Types.Percent", [], Percent, () => [[["Item", int32_type]]]);
}

export class Length extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Px", "In", "Cm", "Mm", "Pt", "Pc", "Em\u0027", "Rem", "Ex", "Ch", "Vw", "Vh", "VMax", "VMin"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const i = this$.fields[0];
                return `${i}in`;
            }
            case 2: {
                const c = this$.fields[0];
                return `${c}cm`;
            }
            case 3: {
                const m = this$.fields[0];
                return `${m}mm`;
            }
            case 4: {
                const p_1 = this$.fields[0];
                return `${p_1}pt`;
            }
            case 5: {
                const p_2 = this$.fields[0];
                return `${p_2}pc`;
            }
            case 6: {
                const e = this$.fields[0];
                return `${e}em`;
            }
            case 7: {
                const r = this$.fields[0];
                return `${r}rem`;
            }
            case 8: {
                const e_1 = this$.fields[0];
                return `${e_1}ex`;
            }
            case 9: {
                const c_1 = this$.fields[0];
                return `${c_1}ch`;
            }
            case 10: {
                const v = this$.fields[0];
                return `${v}vw`;
            }
            case 11: {
                const v_1 = this$.fields[0];
                return `${v_1}vh`;
            }
            case 12: {
                const v_2 = this$.fields[0];
                return `${v_2}vmax`;
            }
            case 13: {
                const v_3 = this$.fields[0];
                return `${v_3}vmin`;
            }
            default: {
                const p = this$.fields[0] | 0;
                return `${p}px`;
            }
        }
    }
}

export function Length$reflection() {
    return union_type("Fss.Types.Length", [], Length, () => [[["Item", int32_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]]]);
}

export class Angle extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Deg", "Grad", "Rad", "Turn"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const g = this$.fields[0];
                return `${g}grad`;
            }
            case 2: {
                const r = this$.fields[0];
                return `${r}rad`;
            }
            case 3: {
                const t = this$.fields[0];
                return `${t}turn`;
            }
            default: {
                const d = this$.fields[0];
                return `${d}deg`;
            }
        }
    }
}

export function Angle$reflection() {
    return union_type("Fss.Types.Angle", [], Angle, () => [[["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]]]);
}

export class Resolution extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Dpi"];
    }
    StringifyCss() {
        const this$ = this;
        const dpi = this$.fields[0];
        return `${dpi}dpi`;
    }
}

export function Resolution$reflection() {
    return union_type("Fss.Types.Resolution", [], Resolution, () => [[["Item", string_type]]]);
}

export class Time extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Sec", "Ms"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 1) {
            const ms = this$.fields[0];
            return `${ms}ms`;
        }
        else {
            const s = this$.fields[0];
            return `${s}s`;
        }
    }
}

export function Time$reflection() {
    return union_type("Fss.Types.Time", [], Time, () => [[["Item", float64_type]], [["Item", float64_type]]]);
}

export class Fraction extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fr"];
    }
    StringifyCss() {
        const this$ = this;
        const f = this$.fields[0];
        return `${f}fr`;
    }
}

export function Fraction$reflection() {
    return union_type("Fss.Types.Fraction", [], Fraction, () => [[["Item", float64_type]]]);
}

export function unitHelpers_lengthPercentageToType(lp) {
    if (lp instanceof Percent) {
        const p = lp;
        return p;
    }
    else if (lp instanceof Length) {
        const l = lp;
        return l;
    }
    else {
        return new Length(0, 0);
    }
}

export function unitHelpers_lengthPercentageString(lp) {
    if (lp instanceof Percent) {
        const p = lp;
        return MasterTypeHelpers_stringifyICssValue(p);
    }
    else if (lp instanceof Length) {
        const l = lp;
        return MasterTypeHelpers_stringifyICssValue(l);
    }
    else {
        return "";
    }
}

export class unitHelpers_CssRuleWithLength extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function unitHelpers_CssRuleWithLength$reflection() {
    return class_type("Fss.Types.unitHelpers.CssRuleWithLength", void 0, unitHelpers_CssRuleWithLength, CssRule$reflection());
}

export function unitHelpers_CssRuleWithLength_$ctor_Z207A3CFB(property) {
    return new unitHelpers_CssRuleWithLength(property);
}

export function unitHelpers_CssRuleWithLength__value_Z498FEB3B(this$, length) {
    const tupledArg = [this$.property_1, unitHelpers_lengthPercentageToType(length)];
    return [tupledArg[0], tupledArg[1]];
}

export class unitHelpers_CssRuleWithLengthNormal extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function unitHelpers_CssRuleWithLengthNormal$reflection() {
    return class_type("Fss.Types.unitHelpers.CssRuleWithLengthNormal", void 0, unitHelpers_CssRuleWithLengthNormal, unitHelpers_CssRuleWithLength$reflection());
}

export function unitHelpers_CssRuleWithLengthNormal_$ctor_Z207A3CFB(property) {
    return new unitHelpers_CssRuleWithLengthNormal(property);
}

export function unitHelpers_CssRuleWithLengthNormal__get_normal(this$) {
    const tupledArg = [this$.property_2, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class unitHelpers_CssRuleWithLengthNone extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function unitHelpers_CssRuleWithLengthNone$reflection() {
    return class_type("Fss.Types.unitHelpers.CssRuleWithLengthNone", void 0, unitHelpers_CssRuleWithLengthNone, unitHelpers_CssRuleWithLength$reflection());
}

export function unitHelpers_CssRuleWithLengthNone_$ctor_Z207A3CFB(property) {
    return new unitHelpers_CssRuleWithLengthNone(property);
}

export function unitHelpers_CssRuleWithLengthNone__get_none(this$) {
    const tupledArg = [this$.property_2, new None$0027(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class unitHelpers_CssRuleWithAutoLength extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function unitHelpers_CssRuleWithAutoLength$reflection() {
    return class_type("Fss.Types.unitHelpers.CssRuleWithAutoLength", void 0, unitHelpers_CssRuleWithAutoLength, CssRuleWithAuto$reflection());
}

export function unitHelpers_CssRuleWithAutoLength_$ctor_Z207A3CFB(property) {
    return new unitHelpers_CssRuleWithAutoLength(property);
}

export function unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(this$, length) {
    const tupledArg = [this$.property_2, unitHelpers_lengthPercentageToType(length)];
    return [tupledArg[0], tupledArg[1]];
}

export class unitHelpers_CssRuleWithAutoLengthNone extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function unitHelpers_CssRuleWithAutoLengthNone$reflection() {
    return class_type("Fss.Types.unitHelpers.CssRuleWithAutoLengthNone", void 0, unitHelpers_CssRuleWithAutoLengthNone, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function unitHelpers_CssRuleWithAutoLengthNone_$ctor_Z207A3CFB(property) {
    return new unitHelpers_CssRuleWithAutoLengthNone(property);
}

export function unitHelpers_CssRuleWithAutoLengthNone__get_none(this$) {
    const tupledArg = [this$.property_3, new None$0027(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class unitHelpers_DirectionalLength extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function unitHelpers_DirectionalLength$reflection() {
    return class_type("Fss.Types.unitHelpers.DirectionalLength", void 0, unitHelpers_DirectionalLength, CssRule$reflection());
}

export function unitHelpers_DirectionalLength_$ctor_Z207A3CFB(property) {
    return new unitHelpers_DirectionalLength(property);
}

export function unitHelpers_DirectionalLength__value_Z498FEB3B(this$, length) {
    const tupledArg = [this$.property_1, unitHelpers_lengthPercentageToType(length)];
    return [tupledArg[0], tupledArg[1]];
}

export function unitHelpers_DirectionalLength__value_3202B9A0(this$, vertical, horizontal) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(vertical)} ${unitHelpers_lengthPercentageString(horizontal)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export function unitHelpers_DirectionalLength__value_Z3BD6069B(this$, top, horizontal, bottom) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(top)} ${unitHelpers_lengthPercentageString(horizontal)} ${unitHelpers_lengthPercentageString(bottom)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export function unitHelpers_DirectionalLength__value_ZE6CD40(this$, top, right, bottom, left) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(top)} ${unitHelpers_lengthPercentageString(right)} ${unitHelpers_lengthPercentageString(bottom)} ${unitHelpers_lengthPercentageString(left)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Units.fs.js.map
