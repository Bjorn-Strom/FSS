import { Length$reflection, unitHelpers_lengthPercentageString } from "./Units.fs.js";
import { String$, CssRuleWithNone$reflection, CssRuleWithNone, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { Color_Color$reflection } from "./Color.fs.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";

export class BoxShadow_BoxShadow extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Color", "BlurColor", "BlurSpreadColor", "Inset"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const yOffset_1 = this$.fields[1];
                const xOffset_1 = this$.fields[0];
                const color_1 = this$.fields[3];
                const blur = this$.fields[2];
                return `${unitHelpers_lengthPercentageString(xOffset_1)} ${unitHelpers_lengthPercentageString(yOffset_1)} ${unitHelpers_lengthPercentageString(blur)} ${MasterTypeHelpers_stringifyICssValue(color_1)}`;
            }
            case 2: {
                const yOffset_2 = this$.fields[1];
                const xOffset_2 = this$.fields[0];
                const spread = this$.fields[3];
                const color_2 = this$.fields[4];
                const blur_1 = this$.fields[2];
                return `${unitHelpers_lengthPercentageString(xOffset_2)} ${unitHelpers_lengthPercentageString(yOffset_2)} ${unitHelpers_lengthPercentageString(blur_1)} ${unitHelpers_lengthPercentageString(spread)} ${MasterTypeHelpers_stringifyICssValue(color_2)}`;
            }
            case 3: {
                const shadow = this$.fields[0];
                return `inset ${MasterTypeHelpers_stringifyICssValue(shadow)}`;
            }
            default: {
                const yOffset = this$.fields[1];
                const xOffset = this$.fields[0];
                const color = this$.fields[2];
                return `${unitHelpers_lengthPercentageString(xOffset)} ${unitHelpers_lengthPercentageString(yOffset)} ${MasterTypeHelpers_stringifyICssValue(color)}`;
            }
        }
    }
}

export function BoxShadow_BoxShadow$reflection() {
    return union_type("Fss.Types.BoxShadow.BoxShadow", [], BoxShadow_BoxShadow, () => [[["Item1", Length$reflection()], ["Item2", Length$reflection()], ["Item3", Color_Color$reflection()]], [["Item1", Length$reflection()], ["Item2", Length$reflection()], ["Item3", Length$reflection()], ["Item4", Color_Color$reflection()]], [["Item1", Length$reflection()], ["Item2", Length$reflection()], ["Item3", Length$reflection()], ["Item4", Length$reflection()], ["Item5", Color_Color$reflection()]], [["Item", BoxShadow_BoxShadow$reflection()]]]);
}

export class BoxShadowClasses_BoxShadowClass extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function BoxShadowClasses_BoxShadowClass$reflection() {
    return class_type("Fss.Types.BoxShadowClasses.BoxShadowClass", void 0, BoxShadowClasses_BoxShadowClass, CssRuleWithNone$reflection());
}

export function BoxShadowClasses_BoxShadowClass_$ctor_Z207A3CFB(property) {
    return new BoxShadowClasses_BoxShadowClass(property);
}

export function BoxShadowClasses_BoxShadowClass__value_1BA9B866(this$, xOffset, yOffset, color) {
    const tupledArg = [this$.property_2, new BoxShadow_BoxShadow(0, xOffset, yOffset, color)];
    return [tupledArg[0], tupledArg[1]];
}

export function BoxShadowClasses_BoxShadowClass__value_Z259E9AEE(this$, xOffset, yOffset, blur, color) {
    const tupledArg = [this$.property_2, new BoxShadow_BoxShadow(1, xOffset, yOffset, blur, color)];
    return [tupledArg[0], tupledArg[1]];
}

export function BoxShadowClasses_BoxShadowClass__value_Z6ABC551A(this$, xOffset, yOffset, blur, spread, color) {
    const tupledArg = [this$.property_2, new BoxShadow_BoxShadow(2, xOffset, yOffset, blur, spread, color)];
    return [tupledArg[0], tupledArg[1]];
}

export function BoxShadowClasses_BoxShadowClass__value_191ACECC(this$, boxShadows) {
    const value = join(", ", map(MasterTypeHelpers_stringifyICssValue, boxShadows));
    const tupledArg = [this$.property_2, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function BoxShadowClasses_BoxShadowClass__Inset_Z5DE0E4DA(this$, boxShadow) {
    const tupledArg = [this$.property_2, new BoxShadow_BoxShadow(3, boxShadow)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=BoxShadow.fs.js.map
