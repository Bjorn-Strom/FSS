import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, int32_type, float64_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { interpolate, printf, toText } from "../../fable-library.3.7.9/String.js";
import { CssRule$reflection, CssRule, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";

export class TimingFunction_Step extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["JumpStart", "JumpEnd", "JumpNone", "JumpBoth", "Start", "End"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function TimingFunction_Step$reflection() {
    return union_type("Fss.Types.TimingFunction.Step", [], TimingFunction_Step, () => [[], [], [], [], [], []]);
}

export class TimingFunction_Timing extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Ease", "EaseIn", "EaseOut", "EaseInOut", "Linear", "StepStart", "StepEnd", "CubicBezier", "Steps", "StepsWithTerm"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 7: {
                const p4 = this$.fields[3];
                const p3 = this$.fields[2];
                const p2 = this$.fields[1];
                const p1 = this$.fields[0];
                return toText(printf("cubic-bezier(%.2f, %.2f, %.2f, %.2f)"))(p1)(p2)(p3)(p4);
            }
            case 8: {
                const n = this$.fields[0] | 0;
                return toText(printf("steps(%d)"))(n);
            }
            case 9: {
                const term = this$.fields[1];
                const n_1 = this$.fields[0] | 0;
                return toText(interpolate("steps(%d%P(), %s%P())", [n_1, MasterTypeHelpers_stringifyICssValue(term)]));
            }
            default: {
                return Helpers_toKebabCase(this$);
            }
        }
    }
}

export function TimingFunction_Timing$reflection() {
    return union_type("Fss.Types.TimingFunction.Timing", [], TimingFunction_Timing, () => [[], [], [], [], [], [], [], [["Item1", float64_type], ["Item2", float64_type], ["Item3", float64_type], ["Item4", float64_type]], [["Item", int32_type]], [["Item1", int32_type], ["Item2", TimingFunction_Step$reflection()]]]);
}

export class TimingFunctionClasses_TimingFunction extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TimingFunctionClasses_TimingFunction$reflection() {
    return class_type("Fss.Types.TimingFunctionClasses.TimingFunction", void 0, TimingFunctionClasses_TimingFunction, CssRule$reflection());
}

export function TimingFunctionClasses_TimingFunction_$ctor_Z207A3CFB(property) {
    return new TimingFunctionClasses_TimingFunction(property);
}

export function TimingFunctionClasses_TimingFunction__get_ease(this$) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__get_easeIn(this$) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__get_easeOut(this$) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__get_easeInOut(this$) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__get_linear(this$) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__get_stepStart(this$) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__get_stepEnd(this$) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__cubicBezier_77D16AC0(this$, p1, p2, p3, p4) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(7, p1, p2, p3, p4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__step_Z524259A4(this$, steps) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(8, steps)];
    return [tupledArg[0], tupledArg[1]];
}

export function TimingFunctionClasses_TimingFunction__step_Z49132226(this$, steps, jumpTerm) {
    const tupledArg = [this$.property_1, new TimingFunction_Timing(9, steps, jumpTerm)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=TimingFunction.fs.js.map
