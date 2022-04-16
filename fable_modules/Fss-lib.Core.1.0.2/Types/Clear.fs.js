import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNone$reflection, CssRuleWithNone } from "./MasterTypes.fs.js";

export class Clear_Clear extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Left", "Right", "Both", "InlineStart", "InlineEnd"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Clear_Clear$reflection() {
    return union_type("Fss.Types.Clear.Clear", [], Clear_Clear, () => [[], [], [], [], []]);
}

export class ClearClasses_Clear extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ClearClasses_Clear$reflection() {
    return class_type("Fss.Types.ClearClasses.Clear", void 0, ClearClasses_Clear, CssRuleWithNone$reflection());
}

export function ClearClasses_Clear_$ctor_Z207A3CFB(property) {
    return new ClearClasses_Clear(property);
}

export function ClearClasses_Clear__get_left(this$) {
    const tupledArg = [this$.property_2, new Clear_Clear(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClearClasses_Clear__get_right(this$) {
    const tupledArg = [this$.property_2, new Clear_Clear(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClearClasses_Clear__get_both(this$) {
    const tupledArg = [this$.property_2, new Clear_Clear(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClearClasses_Clear__get_inlineStart(this$) {
    const tupledArg = [this$.property_2, new Clear_Clear(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClearClasses_Clear__get_inlineEnd(this$) {
    const tupledArg = [this$.property_2, new Clear_Clear(4)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Clear.fs.js.map
