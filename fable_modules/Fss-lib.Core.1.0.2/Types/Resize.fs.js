import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNone$reflection, CssRuleWithNone } from "./MasterTypes.fs.js";

export class Resize_Resize extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Both", "Horizontal", "Vertical", "Block", "Inline"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Resize_Resize$reflection() {
    return union_type("Fss.Types.Resize.Resize", [], Resize_Resize, () => [[], [], [], [], []]);
}

export class ResizeClasses_ResizeClass extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ResizeClasses_ResizeClass$reflection() {
    return class_type("Fss.Types.ResizeClasses.ResizeClass", void 0, ResizeClasses_ResizeClass, CssRuleWithNone$reflection());
}

export function ResizeClasses_ResizeClass_$ctor_Z207A3CFB(property) {
    return new ResizeClasses_ResizeClass(property);
}

export function ResizeClasses_ResizeClass__value_665B0DA6(this$, resize) {
    const tupledArg = [this$.property_2, resize];
    return [tupledArg[0], tupledArg[1]];
}

export function ResizeClasses_ResizeClass__get_both(this$) {
    const tupledArg = [this$.property_2, new Resize_Resize(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ResizeClasses_ResizeClass__get_horizontal(this$) {
    const tupledArg = [this$.property_2, new Resize_Resize(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ResizeClasses_ResizeClass__get_vertical(this$) {
    const tupledArg = [this$.property_2, new Resize_Resize(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ResizeClasses_ResizeClass__get_block(this$) {
    const tupledArg = [this$.property_2, new Resize_Resize(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function ResizeClasses_ResizeClass__get_inline$0027(this$) {
    const tupledArg = [this$.property_2, new Resize_Resize(4)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Resize.fs.js.map
