import { unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength, unitHelpers_lengthPercentageString } from "./Units.fs.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { union_type, class_type } from "../../fable-library.3.7.9/Reflection.js";

export class ContentSize_ContentSize extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["MaxContent", "MinContent", "FitContent"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 2) {
            const length = this$.fields[0];
            return `fit-content(${unitHelpers_lengthPercentageString(length)})`;
        }
        else {
            return Helpers_toKebabCase(this$).toLocaleLowerCase();
        }
    }
}

export function ContentSize_ContentSize$reflection() {
    return union_type("Fss.Types.ContentSize.ContentSize", [], ContentSize_ContentSize, () => [[], [], [["Item", class_type("Fss.Types.ILengthPercentage")]]]);
}

export class ContentSizeClasses_ContentSize extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function ContentSizeClasses_ContentSize$reflection() {
    return class_type("Fss.Types.ContentSizeClasses.ContentSize", void 0, ContentSizeClasses_ContentSize, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function ContentSizeClasses_ContentSize_$ctor_Z207A3CFB(property) {
    return new ContentSizeClasses_ContentSize(property);
}

export function ContentSizeClasses_ContentSize__get_maxContent(this$) {
    const tupledArg = [this$.property_3, new ContentSize_ContentSize(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentSizeClasses_ContentSize__get_minContent(this$) {
    const tupledArg = [this$.property_3, new ContentSize_ContentSize(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentSizeClasses_ContentSize__fitContent_Z498FEB3B(this$, fit) {
    const tupledArg = [this$.property_3, new ContentSize_ContentSize(2, fit)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=ContentSize.fs.js.map
