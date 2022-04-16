import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { unitHelpers_lengthPercentageString, unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength, unitHelpers_CssRuleWithLengthNone$reflection, unitHelpers_CssRuleWithLengthNone } from "./Units.fs.js";
import { CssRule$reflection, CssRule, String$ } from "./MasterTypes.fs.js";

export class Perspective_BackfaceVisibility extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Hidden", "Visible"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Perspective_BackfaceVisibility$reflection() {
    return union_type("Fss.Types.Perspective.BackfaceVisibility", [], Perspective_BackfaceVisibility, () => [[], []]);
}

export class PerspectiveClasses_Perspective extends unitHelpers_CssRuleWithLengthNone {
    constructor(property) {
        super(property);
    }
}

export function PerspectiveClasses_Perspective$reflection() {
    return class_type("Fss.Types.PerspectiveClasses.Perspective", void 0, PerspectiveClasses_Perspective, unitHelpers_CssRuleWithLengthNone$reflection());
}

export function PerspectiveClasses_Perspective_$ctor_Z207A3CFB(property) {
    return new PerspectiveClasses_Perspective(property);
}

export class PerspectiveClasses_PerspectiveOrigin extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function PerspectiveClasses_PerspectiveOrigin$reflection() {
    return class_type("Fss.Types.PerspectiveClasses.PerspectiveOrigin", void 0, PerspectiveClasses_PerspectiveOrigin, unitHelpers_CssRuleWithLength$reflection());
}

export function PerspectiveClasses_PerspectiveOrigin_$ctor_Z207A3CFB(property) {
    return new PerspectiveClasses_PerspectiveOrigin(property);
}

export function PerspectiveClasses_PerspectiveOrigin__value_3202B9A0(this$, x, y) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export class PerspectiveClasses_BackfaceVisibility extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function PerspectiveClasses_BackfaceVisibility$reflection() {
    return class_type("Fss.Types.PerspectiveClasses.BackfaceVisibility", void 0, PerspectiveClasses_BackfaceVisibility, CssRule$reflection());
}

export function PerspectiveClasses_BackfaceVisibility_$ctor_Z207A3CFB(property) {
    return new PerspectiveClasses_BackfaceVisibility(property);
}

export function PerspectiveClasses_BackfaceVisibility__get_hidden(this$) {
    const tupledArg = [this$.property_1, new Perspective_BackfaceVisibility(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PerspectiveClasses_BackfaceVisibility__get_visible(this$) {
    const tupledArg = [this$.property_1, new Perspective_BackfaceVisibility(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Perspective.fs.js.map
