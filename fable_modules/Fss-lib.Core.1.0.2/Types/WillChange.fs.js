import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { String$, CssRuleWithAuto$reflection, CssRuleWithAuto } from "./MasterTypes.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";

export class WillChange_WillChange extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ScrollPosition", "Contents"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function WillChange_WillChange$reflection() {
    return union_type("Fss.Types.WillChange.WillChange", [], WillChange_WillChange, () => [[], []]);
}

export class WillChangeClasses_WillChange extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function WillChangeClasses_WillChange$reflection() {
    return class_type("Fss.Types.WillChangeClasses.WillChange", void 0, WillChangeClasses_WillChange, CssRuleWithAuto$reflection());
}

export function WillChangeClasses_WillChange_$ctor_Z207A3CFB(property) {
    return new WillChangeClasses_WillChange(property);
}

export function WillChangeClasses_WillChange__value_Z721C83C5(this$, ident) {
    const tupledArg = [this$.property_2, new String$(0, ident)];
    return [tupledArg[0], tupledArg[1]];
}

export function WillChangeClasses_WillChange__value_1334CEF1(this$, idents) {
    const tupledArg = [this$.property_2, new String$(0, join(", ", idents))];
    return [tupledArg[0], tupledArg[1]];
}

export function WillChangeClasses_WillChange__get_scrollPosition(this$) {
    const tupledArg = [this$.property_2, new WillChange_WillChange(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function WillChangeClasses_WillChange__get_contents(this$) {
    const tupledArg = [this$.property_2, new WillChange_WillChange(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=WillChange.fs.js.map
