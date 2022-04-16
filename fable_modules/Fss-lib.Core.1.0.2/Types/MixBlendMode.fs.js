import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNormal$reflection, CssRuleWithNormal } from "./MasterTypes.fs.js";

export class MixBlendMode_MixBlendMode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Multiply", "Screen", "Overlay", "Darken", "Lighten", "ColorDodge", "ColorBurn", "HardLight", "SoftLight", "Difference", "Exclusion", "Hue", "Saturation", "Color", "Luminosity"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function MixBlendMode_MixBlendMode$reflection() {
    return union_type("Fss.Types.MixBlendMode.MixBlendMode", [], MixBlendMode_MixBlendMode, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class MixBlendModeClasses_MixBlendMode extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function MixBlendModeClasses_MixBlendMode$reflection() {
    return class_type("Fss.Types.MixBlendModeClasses.MixBlendMode", void 0, MixBlendModeClasses_MixBlendMode, CssRuleWithNormal$reflection());
}

export function MixBlendModeClasses_MixBlendMode_$ctor_Z207A3CFB(property) {
    return new MixBlendModeClasses_MixBlendMode(property);
}

export function MixBlendModeClasses_MixBlendMode__get_multiply(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_screen(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_overlay(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_darken(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_lighten(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_colorDodge(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_colorBurn(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_hardLight(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_softLight(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_difference(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_exclusion(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_hue(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_saturation(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_color(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function MixBlendModeClasses_MixBlendMode__get_luminosity(this$) {
    const tupledArg = [this$.property_2, new MixBlendMode_MixBlendMode(14)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=MixBlendMode.fs.js.map
