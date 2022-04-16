import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, int32_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { int32ToString } from "../../fable-library.3.7.9/Util.js";
import { String$, MasterTypeHelpers_stringifyICssValue, Float, CssRule$reflection, CssRule, None$0027, Normal, CssRuleWithValueFunctions$1$reflection, CssRuleWithValueFunctions$1 } from "./MasterTypes.fs.js";
import { Time$reflection } from "./Units.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";
import { TimingFunction_Timing, TimingFunction_Timing$reflection } from "./TimingFunction.fs.js";

export class Animation_Direction extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Normal", "Reverse", "Alternate", "AlternateReverse"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Animation_Direction$reflection() {
    return union_type("Fss.Types.Animation.Direction", [], Animation_Direction, () => [[], [], [], []]);
}

export class Animation_FillMode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Forwards", "Backwards", "Both"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Animation_FillMode$reflection() {
    return union_type("Fss.Types.Animation.FillMode", [], Animation_FillMode, () => [[], [], []]);
}

export class Animation_IterationCount extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Infinite", "Value"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 1) {
            const v = this$.fields[0] | 0;
            return int32ToString(v);
        }
        else {
            return "infinite";
        }
    }
}

export function Animation_IterationCount$reflection() {
    return union_type("Fss.Types.Animation.IterationCount", [], Animation_IterationCount, () => [[], [["Item", int32_type]]]);
}

export class Animation_PlayState extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Running", "Paused"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Animation_PlayState$reflection() {
    return union_type("Fss.Types.Animation.PlayState", [], Animation_PlayState, () => [[], []]);
}

export class AnimationClasses_AnimationTime extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, ", ");
    }
}

export function AnimationClasses_AnimationTime$reflection() {
    return class_type("Fss.Types.AnimationClasses.AnimationTime", void 0, AnimationClasses_AnimationTime, CssRuleWithValueFunctions$1$reflection(Time$reflection()));
}

export function AnimationClasses_AnimationTime_$ctor_Z207A3CFB(property) {
    return new AnimationClasses_AnimationTime(property);
}

export class AnimationClasses_AnimationDirection extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, ", ");
        this.property_2 = property;
    }
}

export function AnimationClasses_AnimationDirection$reflection() {
    return class_type("Fss.Types.AnimationClasses.AnimationDirection", void 0, AnimationClasses_AnimationDirection, CssRuleWithValueFunctions$1$reflection(Animation_Direction$reflection()));
}

export function AnimationClasses_AnimationDirection_$ctor_Z207A3CFB(property) {
    return new AnimationClasses_AnimationDirection(property);
}

export function AnimationClasses_AnimationDirection__get_normal(this$) {
    const tupledArg = [this$.property_2, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationDirection__get_reverse(this$) {
    const tupledArg = [this$.property_2, new Animation_Direction(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationDirection__get_alternate(this$) {
    const tupledArg = [this$.property_2, new Animation_Direction(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationDirection__get_alternateReverse(this$) {
    const tupledArg = [this$.property_2, new Animation_Direction(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class AnimationClasses_AnimationFillMode extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, ", ");
        this.property_2 = property;
    }
}

export function AnimationClasses_AnimationFillMode$reflection() {
    return class_type("Fss.Types.AnimationClasses.AnimationFillMode", void 0, AnimationClasses_AnimationFillMode, CssRuleWithValueFunctions$1$reflection(Animation_FillMode$reflection()));
}

export function AnimationClasses_AnimationFillMode_$ctor_Z207A3CFB(property) {
    return new AnimationClasses_AnimationFillMode(property);
}

export function AnimationClasses_AnimationFillMode__get_none(this$) {
    const tupledArg = [this$.property_2, new None$0027(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationFillMode__get_forwards(this$) {
    const tupledArg = [this$.property_2, new Animation_FillMode(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationFillMode__get_backwards(this$) {
    const tupledArg = [this$.property_2, new Animation_FillMode(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationFillMode__get_both(this$) {
    const tupledArg = [this$.property_2, new Animation_FillMode(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class AnimationClasses_AnimationIterationCount extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function AnimationClasses_AnimationIterationCount$reflection() {
    return class_type("Fss.Types.AnimationClasses.AnimationIterationCount", void 0, AnimationClasses_AnimationIterationCount, CssRule$reflection());
}

export function AnimationClasses_AnimationIterationCount_$ctor_Z207A3CFB(property) {
    return new AnimationClasses_AnimationIterationCount(property);
}

export function AnimationClasses_AnimationIterationCount__value_5E38073B(this$, iterationCount) {
    const tupledArg = [this$.property_1, new Float(0, iterationCount)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationIterationCount__value_46D9DA4E(this$, iterationCounts) {
    const iterationCounts_1 = join(", ", map(MasterTypeHelpers_stringifyICssValue, iterationCounts));
    const tupledArg = [this$.property_1, new String$(0, iterationCounts_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationIterationCount__get_infinite(this$) {
    const tupledArg = [this$.property_1, new Animation_IterationCount(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class AnimationClasses_AnimationName extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function AnimationClasses_AnimationName$reflection() {
    return class_type("Fss.Types.AnimationClasses.AnimationName", void 0, AnimationClasses_AnimationName, CssRule$reflection());
}

export function AnimationClasses_AnimationName_$ctor_Z207A3CFB(property) {
    return new AnimationClasses_AnimationName(property);
}

export function AnimationClasses_AnimationName__value_Z721C83C5(this$, name) {
    const tupledArg = [this$.property_1, new String$(0, name)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationName__value_1334CEF1(this$, names) {
    const names_1 = join(", ", names);
    const tupledArg = [this$.property_1, new String$(0, names_1)];
    return [tupledArg[0], tupledArg[1]];
}

export class AnimationClasses_AnimationPlayState extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, ", ");
        this.property_2 = property;
    }
}

export function AnimationClasses_AnimationPlayState$reflection() {
    return class_type("Fss.Types.AnimationClasses.AnimationPlayState", void 0, AnimationClasses_AnimationPlayState, CssRuleWithValueFunctions$1$reflection(Animation_PlayState$reflection()));
}

export function AnimationClasses_AnimationPlayState_$ctor_Z207A3CFB(property) {
    return new AnimationClasses_AnimationPlayState(property);
}

export function AnimationClasses_AnimationPlayState__get_running(this$) {
    const tupledArg = [this$.property_2, new Animation_PlayState(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationPlayState__get_paused(this$) {
    const tupledArg = [this$.property_2, new Animation_PlayState(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class AnimationClasses_AnimationTimingFunction extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, ", ");
        this.property_2 = property;
    }
}

export function AnimationClasses_AnimationTimingFunction$reflection() {
    return class_type("Fss.Types.AnimationClasses.AnimationTimingFunction", void 0, AnimationClasses_AnimationTimingFunction, CssRuleWithValueFunctions$1$reflection(TimingFunction_Timing$reflection()));
}

export function AnimationClasses_AnimationTimingFunction_$ctor_Z207A3CFB(property) {
    return new AnimationClasses_AnimationTimingFunction(property);
}

export function AnimationClasses_AnimationTimingFunction__get_ease(this$) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__get_easeIn(this$) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__get_easeOut(this$) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__get_easeInOut(this$) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__get_linear(this$) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__get_stepStart(this$) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__get_stepEnd(this$) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__cubicBezier_77D16AC0(this$, a, b, c, d) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(7, a, b, c, d)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__step_Z524259A4(this$, steps) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(8, steps)];
    return [tupledArg[0], tupledArg[1]];
}

export function AnimationClasses_AnimationTimingFunction__step_Z49132226(this$, steps, stepType) {
    const tupledArg = [this$.property_2, new TimingFunction_Timing(9, steps, stepType)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Animation.fs.js.map
