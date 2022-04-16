import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNormal$reflection, CssRuleWithNormal } from "./MasterTypes.fs.js";
import { unitHelpers_CssRuleWithLengthNormal$reflection, unitHelpers_CssRuleWithLengthNormal } from "./Units.fs.js";

export class Word_WordBreak extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["WordBreak", "BreakAll", "KeepAll"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Word_WordBreak$reflection() {
    return union_type("Fss.Types.Word.WordBreak", [], Word_WordBreak, () => [[], [], []]);
}

export class WordClasses_WordBreakClass extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function WordClasses_WordBreakClass$reflection() {
    return class_type("Fss.Types.WordClasses.WordBreakClass", void 0, WordClasses_WordBreakClass, CssRuleWithNormal$reflection());
}

export function WordClasses_WordBreakClass_$ctor_Z207A3CFB(property) {
    return new WordClasses_WordBreakClass(property);
}

export function WordClasses_WordBreakClass__get_wordBreak(this$) {
    const tupledArg = [this$.property_2, new Word_WordBreak(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function WordClasses_WordBreakClass__get_breakAll(this$) {
    const tupledArg = [this$.property_2, new Word_WordBreak(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function WordClasses_WordBreakClass__get_keepAll(this$) {
    const tupledArg = [this$.property_2, new Word_WordBreak(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class WordClasses_WordSpacing extends unitHelpers_CssRuleWithLengthNormal {
    constructor(property) {
        super(property);
    }
}

export function WordClasses_WordSpacing$reflection() {
    return class_type("Fss.Types.WordClasses.WordSpacing", void 0, WordClasses_WordSpacing, unitHelpers_CssRuleWithLengthNormal$reflection());
}

export function WordClasses_WordSpacing_$ctor_Z207A3CFB(property) {
    return new WordClasses_WordSpacing(property);
}

//# sourceMappingURL=Word.fs.js.map
